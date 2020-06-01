using System;
using System.Windows.Forms;
using System.Reflection;

namespace Multithreading_07
{
    public partial class MainForm : Form
    {
        private Traffic myTraffic;
        private TrafficView myDrawTraffic;

        public static MainForm Form;

        public MainForm()
        {
            InitializeComponent();
            EnableDoubleBuffer();

            Form = this;
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

        public void UpdateLeftSideStatus(int activeCount, int queueCount)
        {
            LblLeftActiveCount.InvokeIfRequired(() =>
            {
                LblLeftActiveCount.Text = activeCount.ToString();
            });
            LblLeftQueueCount.InvokeIfRequired(() =>
            {
                LblLeftQueueCount.Text = queueCount.ToString();
            });
        }

        public void UpdateTunnelStatus(int leftActiveCount, int rightActiveCount)
        {
            LblTunnelLeftActiveCount.InvokeIfRequired(() =>
            {
                LblTunnelLeftActiveCount.Text = leftActiveCount.ToString();
            });
            LblTunnelRightActiveCount.InvokeIfRequired(() =>
            {
                LblTunnelRightActiveCount.Text = rightActiveCount.ToString();
            });
        }

        public void UpdateRightSideStatus(int activeCount, int queueCount)
        {
            LblRightActiveCount.InvokeIfRequired(() =>
            {
                LblRightActiveCount.Text = activeCount.ToString();
            });
            LblRightQueueCount.InvokeIfRequired(() =>
            {
                LblRightQueueCount.Text = queueCount.ToString();
            });
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
