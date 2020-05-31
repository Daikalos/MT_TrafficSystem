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
        private readonly GroupBox myGrpBoxTraffic;

        private readonly SemaphoreSlim myPassingLeftCars;
        private readonly SemaphoreSlim myPassingRightCars;

        private readonly TrafficLights myTrafficLights;

        private PointF myPosition;
        private Size mySize;

        private int myMaxPassingCars;

        private int myLeftPassingCarsCount;
        private int myRightPassingCarsCount;

        public TrafficLights TrafficLights => myTrafficLights;

        public PointF Position => myPosition;
        public Size Size => mySize;

        public int TunnelEntryLeftSide => (int)(myPosition.X - (mySize.Width / 2));
        public int TunnelEntryRightSide => (int)(myPosition.X + (mySize.Width / 2));

        public int PassingLeftCarsCount => myLeftPassingCarsCount;
        public int PassingRightCarsCount => myRightPassingCarsCount;

        public Tunnel(GroupBox grpBoxTraffic)
        {
            this.myGrpBoxTraffic = grpBoxTraffic;

            myMaxPassingCars = 3;
            myPassingLeftCars = new SemaphoreSlim(myMaxPassingCars, myMaxPassingCars);
            myPassingRightCars = new SemaphoreSlim(myMaxPassingCars, myMaxPassingCars);

            myTrafficLights = new TrafficLights(this);

            myPosition = new PointF((grpBoxTraffic.Width / 2), (grpBoxTraffic.Height / 2));
            mySize = new Size(321, 61);
        }

        public void EnterTunnelLeftSide()
        {
            myPassingLeftCars.Wait();
            myTrafficLights.StopEntryLeft();

            myLeftPassingCarsCount++;
        }
        public void ExitTunnelRightSide()
        {
            myPassingLeftCars.Release();

            myLeftPassingCarsCount--;
        }

        public void EnterTunnelRightSide()
        {
            myPassingRightCars.Wait();
            myTrafficLights.StopEntryRight();

            myRightPassingCarsCount++;
        }
        public void ExitTunnelLeftSide()
        {
            myPassingRightCars.Release();

            myRightPassingCarsCount--;
        }
    }
}
