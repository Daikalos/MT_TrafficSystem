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
using System.Threading;

namespace Multithreading_07
{
    class Tunnel
    {
        private GroupBox myGrpBoxTraffic;

        private SemaphoreSlim myPassingLeftCars;
        private SemaphoreSlim myPassingRightCars;

        private object myAllowEntryLeft = new object();
        private object myAllowEntryRight = new object();

        private PointF myPosition;
        private Size mySize;

        private int myMaxPassingCars;

        public PointF Position => myPosition;
        public Size Size => mySize;

        public Tunnel(GroupBox grpBoxTraffic)
        {
            this.myGrpBoxTraffic = grpBoxTraffic;

            myPosition = new PointF((grpBoxTraffic.Width / 2), (grpBoxTraffic.Height / 2));
            mySize = new Size(321, 61);

            myMaxPassingCars = 3;

            myPassingLeftCars = new SemaphoreSlim(myMaxPassingCars, myMaxPassingCars);
            myPassingRightCars = new SemaphoreSlim(myMaxPassingCars, myMaxPassingCars);
        }

        public void EnterTunnelLeftSide()
        {
            if (myPassingRightCars.CurrentCount != myMaxPassingCars)
            {
                //If there are currently cars passing through on the right side, wait for entry pulse
                lock (myAllowEntryLeft)
                {
                    Monitor.Wait(myAllowEntryLeft);
                }
            }
            myPassingLeftCars.Wait();
        }
        public void EnterTunnelRightSide()
        {
            if (myPassingLeftCars.CurrentCount != myMaxPassingCars)
            {
                //If there are currently cars passing through on the left side, wait for entry pulse
                lock (myAllowEntryRight)
                {
                    Monitor.Wait(myAllowEntryRight);
                }
            }
            myPassingRightCars.Wait();
        }

        public void ExitTunnelLeftSide()
        {
            myPassingRightCars.Release();
            if (myPassingRightCars.CurrentCount == myMaxPassingCars)
            {
                //When there is no more passing cars from right side, allow entry from left side
                lock (myAllowEntryLeft)
                {
                    Monitor.Pulse(myAllowEntryLeft);
                }
            }
        }
        public void ExitTunnelRightSide()
        {
            myPassingLeftCars.Release();
            if (myPassingLeftCars.CurrentCount == myMaxPassingCars)
            {
                //When there is no more passing cars from left side, allow entry to right side
                lock (myAllowEntryRight)
                {
                    Monitor.Pulse(myAllowEntryRight);
                }
            }
        }
    }
}
