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
    /// <summary>
    /// Car spawned from the left side of the screen
    /// </summary>
    class LeftCar : Car
    {
        public LeftCar(GroupBox grpBoxTraffic, TrafficQueue trafficQueue, Tunnel tunnel) : base(grpBoxTraffic, trafficQueue, tunnel)
        {
            myVelocity = new PointF(mySpeed, 0);
            myPosition = new PointF(-mySize.Width, (myGrpBoxTraffic.Height / 2) + (mySize.Height / 2) + 4);
        }

        public override void Update()
        {
            while (IsRunning)
            {
                Thread.Sleep((int)((1.0f / 60.0f) * 1000));

                if (!myEnterTunnel)
                {
                    QueueLeftSide();

                    myEnterTunnel = EnteringLeftSide();
                }
                if (!myExitTunnel)
                {
                    myExitTunnel = ExitingRightSide();
                }

                if (myEnterTunnel && myExitTunnel)
                {
                    OutsideRightBoundary();
                }

                myPosition = myPosition.Add(myVelocity);
            }
        }


        private void QueueLeftSide()
        {
            int carWaitPos = (myTrafficQueue.PositionInLeftQueue(this) * (mySize.Width + 2));
            int carCheckWaitPos = (myTrafficQueue.LeftCarQueue.Count * (mySize.Width + 2));

            //If the current car is not in queue
            if (!myTrafficQueue.LeftCarQueue.Contains(this))
            {
                //Check for if the car has passed the waiting position of the total cars in queue
                if (myPosition.X + (mySize.Width / 2) + carCheckWaitPos >= myTunnel.TunnelEntryLeftSide)
                {
                    myTrafficQueue.AddToLeftQueue(this);
                }
            }
            else
            {
                //If the car is in the queue and has reached wait pos, set the position to the waiting position
                if (myPosition.X + (mySize.Width / 2) + carWaitPos >= myTunnel.TunnelEntryLeftSide)
                {
                    myPosition = new PointF(myTunnel.TunnelEntryLeftSide - (mySize.Width / 2) - carWaitPos, myPosition.Y);
                }
            }
        }

        private bool EnteringLeftSide()
        {
            //If the car is in the queue, is first to enter and has reached tunnel entry
            if (myTrafficQueue.LeftCarQueue.Contains(this))
            {
                if (myTrafficQueue.PositionInLeftQueue(this) == 0 && myPosition.X + (mySize.Width / 2) >= myTunnel.TunnelEntryLeftSide)
                {
                    EnterTunnelLeftSide();

                    return true;
                }
            }
            return false;
        }
        private void EnterTunnelLeftSide()
        {
            myTunnel.EnterTunnelLeftSide();
            myTrafficQueue.RemoveFromLeftQueue();

            myPosition = new PointF(myPosition.X, myGrpBoxTraffic.Height / 2);
        }

        private bool ExitingRightSide()
        {
            if (myPosition.X + (mySize.Width / 2) >= myTunnel.TunnelEntryRightSide)
            {
                ExitTunnelRightSide();

                return true;
            }
            return false;
        }
        private void ExitTunnelRightSide()
        {
            myPosition = new PointF(myPosition.X, (myGrpBoxTraffic.Height / 2) + (mySize.Height / 2) + 4);

            myTunnel.ExitTunnelRightSide();
        }

        private void OutsideRightBoundary()
        {
            if (myPosition.X - (mySize.Width / 2) > myGrpBoxTraffic.Width)
            {
                IsRunning = false;
            }
        }
    }
}
