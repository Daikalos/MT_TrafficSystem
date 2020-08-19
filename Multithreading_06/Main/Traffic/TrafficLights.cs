using System.Threading;
using System.Diagnostics;

namespace Multithreading_06
{
    class TrafficLights : ThreadObject
    {
        private Tunnel myTunnel; //Used to check how many are currently in the tunnel

        private CurrentAllowEntry myCurrentAllowEntry; //Used to switch which side to notify that is waiting

        private readonly object myAllowEntryLeft = new object();  //Used as condition synchronization for waiting/notifying cars
        private readonly object myAllowEntryRight = new object();

        private bool mySwitchAllowEntry;  //Currently which side is being notified
        private float mySwitchEntryDelay; //Delay before traffic lights switches sides

        public bool SwitchAllowEntry => mySwitchAllowEntry;

        public TrafficLights(Tunnel tunnel)
        {
            this.myTunnel = tunnel;

            myCurrentAllowEntry = AllowEntryLeft;

            mySwitchAllowEntry = true;
            mySwitchEntryDelay = 12.0f;

            StartThread();
            MyThread.Name = "TrafficLights";
        }

        public override void Update()
        {
            Stopwatch switchEntryTimer = Stopwatch.StartNew();

            while (IsRunning)
            {
                //If the timer reaches delay, switch which side is allowed to enter
                if ((float)switchEntryTimer.Elapsed.TotalSeconds >= mySwitchEntryDelay)
                {
                    mySwitchAllowEntry = !mySwitchAllowEntry;
                    myCurrentAllowEntry =  (mySwitchAllowEntry) ? new CurrentAllowEntry(AllowEntryLeft) : AllowEntryRight;

                    switchEntryTimer.Restart();
                }

                //Notify the currently waiting car to be allowed to pass
                myCurrentAllowEntry();
            }
        }

        private delegate void CurrentAllowEntry();

        public void StopEntryLeft()
        {
            //Wait at entry until notified
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
            //Wait at entry until notified
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
