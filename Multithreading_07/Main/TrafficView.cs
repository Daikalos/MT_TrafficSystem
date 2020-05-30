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
    class TrafficView : ThreadObject
    {
        private GroupBox myGrpBoxTraffic;
        private Traffic myTraffic;

        public TrafficView(GroupBox grpBoxTraffic, Traffic traffic)
        {
            this.myGrpBoxTraffic = grpBoxTraffic;
            this.myTraffic = traffic;

            StartThread();
        }

        public override void Update()
        {
            while (IsRunning)
            {
                Thread.Sleep((int)((1.0f / 60.0f) * 1000));

                myGrpBoxTraffic.InvokeIfRequired(() => 
                {
                    myGrpBoxTraffic.Refresh();
                });
            }
        }

        public void Draw(object sender, PaintEventArgs e)
        {
            for (int i = myTraffic.Cars.Count - 1; i >= 0; i--)
            {
                Car car = myTraffic.Cars[i];
                e.Graphics.FillRectangle(new SolidBrush(car.Color), car.DrawRect);
            }
        }
    }
}
