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
        private Tunnel myTunnel;
        private TrafficQueue myTrafficQueue;
        private TrafficLights myTrafficLights;

        public TrafficView(GroupBox grpBoxTraffic, Traffic traffic)
        {
            this.myGrpBoxTraffic = grpBoxTraffic;
            this.myTraffic = traffic;

            this.myTunnel = myTraffic.Tunnel;
            this.myTrafficQueue = myTraffic.TrafficQueue;
            this.myTrafficLights = myTunnel.TrafficLights;

            StartThread();
            MyThread.Name = "TrafficView";
        }

        public override void Update()
        {
            while (IsRunning)
            {
                Thread.Sleep((int)((1.0f / 30.0f) * 1000));

                MainForm.Form.UpdateLeftSideStatus(myTraffic.LeftCarCount, myTrafficQueue.LeftCarQueue.Count);
                MainForm.Form.UpdateTunnelStatus(myTunnel.PassingLeftCarsCount, myTunnel.PassingRightCarsCount);
                MainForm.Form.UpdateRightSideStatus(myTraffic.RightCarCount, myTrafficQueue.RightCarQueue.Count);

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

            if (myTrafficLights.SwitchAllowEntry)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), new RectangleF(200, 100, 20, 20));
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), new RectangleF(548, 100, 20, 20));
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), new RectangleF(548, 100, 20, 20));
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), new RectangleF(200, 100, 20, 20));
            }
        }
    }
}
