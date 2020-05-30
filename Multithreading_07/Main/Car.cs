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
    class Car : ThreadObject
    {
        protected readonly GroupBox myGrpBoxTraffic;
        protected readonly TrafficQueue myTrafficQueue;
        protected readonly Tunnel myTunnel;

        protected PointF myPosition;
        protected PointF myVelocity;

        protected Color myColor;
        protected Size mySize;

        protected bool myEnterTunnel;
        protected bool myExitTunnel;

        protected float mySpeed;

        public RectangleF DrawRect => new RectangleF(myPosition.X - (mySize.Width / 2), myPosition.Y - (mySize.Height / 2), mySize.Width, mySize.Height);
        public Color Color => myColor;

        public Car(GroupBox grpBoxTraffic, TrafficQueue trafficQueue, Tunnel tunnel)
        {
            this.myGrpBoxTraffic = grpBoxTraffic;
            this.myTrafficQueue = trafficQueue;
            this.myTunnel = tunnel;

            mySize = new Size(32, 12);

            myEnterTunnel = false;
            myExitTunnel = false;

            mySpeed = 1.5f;

            myColor = AssignRandomColor();

            StartThread();
        }

        public override void Update()
        {
            //Empty, need to override
        }

        private Color AssignRandomColor()
        {
            int randomNumber = StaticRandom.RandomNumber(0, 5);
            switch (randomNumber)
            {
                case 0:
                    return Color.Red;
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.Cyan;
                case 3:
                    return Color.Lime;
                case 4:
                    return Color.Maroon;
                default:
                    return Color.Magenta;
            }
        }
    }
}
