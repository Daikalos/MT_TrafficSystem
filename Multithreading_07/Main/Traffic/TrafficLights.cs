using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Multithreading_07
{
    class TrafficLights : ThreadObject
    {
        private Tunnel myTunnel;

        private CurrentAllowEntry myCurrentAllowEntry;

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

                myCurrentAllowEntry();
            }
        }

        private delegate void CurrentAllowEntry();

        public void StopEntryLeft()
        {
            lock (myAllowEntryLeft)
            {
                Monitor.Wait(myAllowEntryLeft);
            }
        }
        public void AllowEntryLeft()
        {
            if (myTunnel.PassingLeftCarsCount == 0)
            {
                lock (myAllowEntryRight)
                {
                    Monitor.Pulse(myAllowEntryRight);
                }
            }
        }

        public void StopEntryRight()
        {
            lock (myAllowEntryRight)
            {
                Monitor.Wait(myAllowEntryRight);
            }
        }
        public void AllowEntryRight()
        {
            if (myTunnel.PassingRightCarsCount == 0)
            {
                lock (myAllowEntryLeft)
                {
                    Monitor.Pulse(myAllowEntryLeft);
                }
            }
        }
    }
}
