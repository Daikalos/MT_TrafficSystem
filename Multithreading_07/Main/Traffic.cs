using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace Multithreading_07
{
    class Traffic : ThreadObject
    {
        private GroupBox myGrpBoxTraffic;

        private readonly List<Car> myCars;
        private readonly TrafficQueue myTrafficQueue;
        private readonly Tunnel myTunnel;

        private float mySpawnCarDelay;

        public List<Car> Cars => myCars;
        public Tunnel tunnel => myTunnel;

        public Traffic(GroupBox grpBoxTraffic)
        {
            this.myGrpBoxTraffic = grpBoxTraffic;

            myTrafficQueue = new TrafficQueue();
            myTunnel = new Tunnel(myGrpBoxTraffic);

            myCars = new List<Car>();
            mySpawnCarDelay = 2.0f;

            StartThread();
        }

        /// <summary>
        /// Spawns a car after having reached delay time
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

                for (int i = myCars.Count - 1; i >= 0; i--)
                {
                    if (!myCars[i].IsRunning)
                    {
                        myCars.RemoveAt(i);
                    }
                }
            }

            myCars.ForEach(c => c.IsRunning = false);
        }

        public void AddCar(Car carToAdd)
        {
            myCars.Add(carToAdd);
        }

        public void RemoveCar(Car carToRemove)
        {
            myCars.Remove(carToRemove);
        }
    }
}
