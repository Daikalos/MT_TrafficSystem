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

namespace Multithreading_07
{
    class Car
    {
        private PointF myPosition;
        private PointF myVelocity;

        private Color myColor;

        private bool myStopCar;
        private int myDrivingSide;

        public Car()
        {


            myColor = AssignRandomColor();
        }

        public void Move()
        {


            myPosition = myPosition.Add(myVelocity);
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
