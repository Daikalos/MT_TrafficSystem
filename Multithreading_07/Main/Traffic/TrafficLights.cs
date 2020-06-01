using System.Threading;
using System.Diagnostics;

namespace Multithreading_07
{
    class TrafficLights : ThreadObject
    {
        private Tunnel myTunnel;

        private CurrentAllowEntry myCurrentAllowEntry; //Used to switch which side to notify that is waiting

        private readonly object myAllowEntryLeft = new object();
        private readonly object myAllowEntryRight = new object();

        private bool mySwitchAllowEntry; 
        private float mySwitchEntryDelay;

        public bool SwitchAllowEntry => mySwitchAllowEntry;

        public TrafficLights(Tunnel tunnel)
        {
            this.myTunnel = tunnel;

            myCurrentAllowEntry = AllowEntryLeft;

            mySwitchAllowEntry = true;
            mySwitchEntryDelay = 14.0f;

            StartThread();
            MyThread.Name = "TrafficLights";
        }

        public override void Update()
        {
            Stopwatch switchEntryTimer = Stopwatch.StartNew();

            while (IsRunning)
            {
                //If the timer reached delay, switch which side is allowed to enter
                if ((float)switchEntryTimer.Elapsed.TotalSeconds >= mySwitchEntryDelay)
                {
                    mySwitchAllowEntry = !mySwitchAllowEntry;
                    if (mySwitchAllowEntry)
                    {
                        myCurrentAllowEntry = AllowEntryLeft;
                    }
                    else
                    {
                        myCurrentAllowEntry = AllowEntryRight;
                    }

                    switchEntryTimer.Restart();
                }

                //Notify the currently waiting car to be allowed to pass
                myCurrentAllowEntry();
            }
        }

        private delegate void CurrentAllowEntry();

        public void StopEntryLeft()
        {
            //Wait until notified
            lock (myAllowEntryLeft)
            {
                Monitor.Wait(myAllowEntryLeft);
            }
        }
        public void AllowEntryLeft()
        {
            //If there are currently no passing cars from opposite side, notify left car to be allowed to pass
            if (myTunnel.PassingRightCarsCount == 0)
            {
                lock (myAllowEntryLeft)
                {
                    Monitor.Pulse(myAllowEntryLeft);
                }
            }
        }

        public void StopEntryRight()
        {
            //Wait until notified
            lock (myAllowEntryRight)
            {
                Monitor.Wait(myAllowEntryRight);
            }
        }
        public void AllowEntryRight()
        {
            //If there are currently no passing cars from opposite side, notify right car to be allowed to pass
            if (myTunnel.PassingLeftCarsCount == 0)
            {
                lock (myAllowEntryRight)
                {
                    Monitor.Pulse(myAllowEntryRight);
                }
            }
        }
    }
}
