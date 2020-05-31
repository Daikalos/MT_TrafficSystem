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
    /// Car spawned from the right side of the screen
    /// </summary>
    class RightCar : Car
    {
        public RightCar(GroupBox grpBoxTraffic, TrafficQueue trafficQueue, Tunnel tunnel) : base(grpBoxTraffic, trafficQueue, tunnel)
        {
            myVelocity = new PointF(-mySpeed, 0);
            myPosition = new PointF(myGrpBoxTraffic.Width, (myGrpBoxTraffic.Height / 2) - (mySize.Height / 2) - 4);
        }

        public override void Update()
        {
            while (IsRunning)
            {
                Thread.Sleep((int)((1.0f / 60.0f) * 1000));

                if (!myEnterTunnel)
                {
                    QueueRightSide();

                    myEnterTunnel = EnteringRightSide();
                }
                if (!myExitTunnel)
                {
                    myExitTunnel = ExitingLeftSide();
                }

                if (myEnterTunnel && myExitTunnel)
                {
                    OutsideLeftBoundary();
                }

                myPosition = myPosition.Add(myVelocity);
            }
        }

        private void QueueRightSide()
        {
            int carWaitPos = (myTrafficQueue.PositionInRightQueue(this) * (mySize.Width + 2));
            int carCheckWaitPos = (myTrafficQueue.RightCarQueue.Count * (mySize.Width + 2));

            //If the current car is not in queue
            if (!myTrafficQueue.RightCarQueue.Contains(this))
            {
                //Check for if the car has passed the waiting position of the total cars in queue
                if (myPosition.X - (mySize.Width / 2) - carCheckWaitPos <= myTunnel.TunnelEntryRightSide)
                {
                    myTrafficQueue.AddToRightQueue(this);
                }
            }
            else
            {
                //If the car is in the queue, set the position to the waiting position
                if (myPosition.X - (mySize.Width / 2) - carWaitPos <= myTunnel.TunnelEntryRightSide)
                {
                    myPosition = new PointF(myTunnel.TunnelEntryRightSide + (mySize.Width / 2) + carWaitPos, myPosition.Y);
                }
            }
        }

        private bool EnteringRightSide()
        {
            //If the car is in the queue, is first to enter and has reached tunnel entry
            if (myTrafficQueue.RightCarQueue.Contains(this))
            {
                if (myTrafficQueue.PositionInRightQueue(this) == 0 && myPosition.X <= myTunnel.TunnelEntryRightSide + (mySize.Width / 2))
                {
                    EnterTunnelRightSide();

                    return true;
                }
            }
            return false;
        }
        private void EnterTunnelRightSide()
        {
            myTunnel.EnterTunnelRightSide();
            myTrafficQueue.RemoveFromRightQueue();

            myPosition = new PointF(myPosition.X, myGrpBoxTraffic.Height / 2);
        }

        private bool ExitingLeftSide()
        {
            if (myPosition.X - (mySize.Width / 2) < myTunnel.Position.X - (myTunnel.Size.Width / 2))
            {
                ExitTunnelLeftSide();

                return true;
            }
            return false;
        }
        private void ExitTunnelLeftSide()
        {
            myPosition = new PointF(myPosition.X, (myGrpBoxTraffic.Height / 2) - (mySize.Height / 2) - 4);

            myTunnel.ExitTunnelLeftSide();
        }

        private void OutsideLeftBoundary()
        {
            if (myPosition.X + (mySize.Width / 2) < 0)
            {
                IsRunning = false;
            }
        }
    }
}
