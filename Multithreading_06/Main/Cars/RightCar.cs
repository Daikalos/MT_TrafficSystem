using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Multithreading_06
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

                //When having spawned while on the way to enter the tunnel
                if (!myEnterTunnel)
                {
                    QueueRightSide();

                    myEnterTunnel = EnteringRightSide();
                }

                //When having entered the tunnel while on the way to exit the tunnel
                if (myEnterTunnel && !myExitTunnel)
                {
                    myExitTunnel = ExitingLeftSide();
                }

                //When having entered and left the tunnel, will be removed when outside the group box
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
                if (myPosition.X - (mySize.Width / 2) - carCheckWaitPos <= myTunnel.RightSide)
                {
                    myTrafficQueue.AddToRightQueue(this);
                }
            }
            else
            {
                //If the car is in the queue, set the position to the waiting position
                if (myPosition.X - (mySize.Width / 2) - carWaitPos <= myTunnel.RightSide)
                {
                    myPosition = new PointF(myTunnel.RightSide + (mySize.Width / 2) + carWaitPos, myPosition.Y);
                }
            }
        }

        private bool EnteringRightSide()
        {
            //If the car is in the queue, is first to enter and has reached tunnel entry
            if (myTrafficQueue.RightCarQueue.Contains(this))
            {
                if (myTrafficQueue.PositionInRightQueue(this) == 0 && myPosition.X <= myTunnel.RightSide + (mySize.Width / 2))
                {
                    EnterTunnelRightSide();

                    return true;
                }
            }
            return false;
        }
        private void EnterTunnelRightSide()
        {            
            //Attempt to enter the tunnel
            myTunnel.EnterTunnelRightSide();

            //If the car has successfully entered the tunnel, remove from queue
            myTrafficQueue.RemoveFromRightQueue();
            myPosition = new PointF(myPosition.X, myGrpBoxTraffic.Height / 2);
        }

        private bool ExitingLeftSide()
        {
            //If the car has reached the left side of the tunnel (exit)
            if (myPosition.X - (mySize.Width / 2) <= myTunnel.LeftSide)
            {
                ExitTunnelLeftSide();

                return true;
            }
            return false;
        }
        private void ExitTunnelLeftSide()
        {
            myTunnel.ExitTunnelLeftSide();

            myPosition = new PointF(myPosition.X, (myGrpBoxTraffic.Height / 2) - (mySize.Height / 2) - 4);
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
