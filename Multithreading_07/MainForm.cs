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
    public partial class MainForm : Form
    {
        private Traffic myTraffic;
        private TrafficView myDrawTraffic;

        public MainForm()
        {
            InitializeComponent();
            EnableDoubleBuffer();
        }

        private void GrpBoxTraffic_Paint(object sender, PaintEventArgs e)
        {
            if (myTraffic != null && myTraffic.IsRunning)
            {
                myDrawTraffic.Draw(sender, e);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            myTraffic = new Traffic(GrpBoxTraffic);
            myDrawTraffic = new TrafficView(GrpBoxTraffic, myTraffic);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            myTraffic.IsRunning = false;
            myDrawTraffic.IsRunning = false;
        }

        private void EnableDoubleBuffer()
        {
            //Enable doublebuffer for traffic to reduce flicker
            typeof(GroupBox).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
                | BindingFlags.Instance | BindingFlags.NonPublic, null,
                GrpBoxTraffic, new object[] { true });
        }
    }
}
