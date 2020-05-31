﻿using System;
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

        private readonly SemaphoreSlim myPassingLeftCars;  //Used for cars to wait if tunnel has reached max passing cars
        private readonly SemaphoreSlim myPassingRightCars; //Not used as a method for counting total active cars in tunnel

        private readonly TrafficLights myTrafficLights;

        private PointF myPosition; //Position of tunnel
        private Size mySize;       //Size of tunnel

        private int myMaxPassingCars; //Maximum amount of cars that can pass through tunnel at once

        private int myLeftPassingCarsCount; //Amount of cars that are currently passing through tunnel
        private int myRightPassingCarsCount;

        public TrafficLights TrafficLights => myTrafficLights;

        public PointF Position => myPosition;
        public Size Size => mySize;

        public int LeftSide => (int)(myPosition.X - (mySize.Width / 2));
        public int RightSide => (int)(myPosition.X + (mySize.Width / 2));

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

            //If the car is allowed entry, increase counter
            myLeftPassingCarsCount++;
        }
        public void ExitTunnelRightSide()
        {
            myPassingLeftCars.Release();

            //If the car has left the tunnel, reduce counter
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
