using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Multithreading_06
{
    class Traffic : ThreadObject
    {
        private readonly GroupBox myGrpBoxTraffic;

        private readonly List<Car> myCars;
        private readonly TrafficQueue myTrafficQueue; //Queue created at entry of tunnel
        private readonly Tunnel myTunnel;             //Tunnnel object, also used for controlling safe-way passage through tunnel

        private readonly object mySyncCarList = new object(); //Used to prevent out-of-sync error when getting car count

        private readonly float mySpawnCarDelay;

        public List<Car> Cars => myCars;
        public TrafficQueue TrafficQueue => myTrafficQueue;
        public Tunnel Tunnel => myTunnel;

        public int LeftCarCount 
        {
            get
            { 
                lock (mySyncCarList) 
                { 
                    return myCars.Count(b => b is LeftCar); 
                } 
            } 
        }
        public int RightCarCount
        {
            get
            {
                lock (mySyncCarList)
                {
                    return myCars.Count(b => b is RightCar);
                }
            }
        }

        public Traffic(GroupBox grpBoxTraffic)
        {
            this.myGrpBoxTraffic = grpBoxTraffic;

            myTrafficQueue = new TrafficQueue();
            myTunnel = new Tunnel(myGrpBoxTraffic);

            myCars = new List<Car>();
            mySpawnCarDelay = 2.0f;

            StartThread();
            MyThread.Name = "Traffic";
        }

        /// <summary>
        /// Controls spawn and removal -logic of cars
        /// </summary>
        public override void Update()
        {
            Stopwatch spawnCarTimer = Stopwatch.StartNew();

            while(IsRunning)
            {
                if ((float)spawnCarTimer.Elapsed.TotalSeconds > mySpawnCarDelay)
                {
                    int direction = StaticRandom.RandomNumber(0, 2);
                    if (direction == 0 && myTrafficQueue.LeftCarQueue.Count < myTrafficQueue.LeftMaxCount)
                    {
                        AddCar(new LeftCar(myGrpBoxTraffic, myTrafficQueue, myTunnel));
                    }
                    if (direction == 1 && myTrafficQueue.RightCarQueue.Count < myTrafficQueue.RightMaxCount)
                    {
                        AddCar(new RightCar(myGrpBoxTraffic, myTrafficQueue, myTunnel));
                    }

                    spawnCarTimer.Restart();
                }

                RemoveInactiveCars();
            }

            myCars.ForEach(c => c.IsRunning = false);
            myTunnel.TrafficLights.IsRunning = false;
        }

        /// <summary>
        /// Whenever a car is no longer running, remove from list
        /// </summary>
        private void RemoveInactiveCars()
        {
            for (int i = myCars.Count - 1; i >= 0; i--)
            {
                if (!myCars[i].IsRunning)
                {
                    RemoveCar(myCars[i]);
                }
            }
        }

        public void AddCar(Car carToAdd)
        {
            lock (mySyncCarList)
            {
                myCars.Add(carToAdd);
            }
        }
        public void RemoveCar(Car carToRemove)
        {
            lock (mySyncCarList)
            {
                myCars.Remove(carToRemove);
            }
        }
    }
}
