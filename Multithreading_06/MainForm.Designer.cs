namespace Multithreading_06
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.GrpBoxTraffic = new System.Windows.Forms.GroupBox();
            this.GrpBoxLeft = new System.Windows.Forms.GroupBox();
            this.LblLeftQueueCount = new System.Windows.Forms.Label();
            this.LblLeftActiveCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpBoxRight = new System.Windows.Forms.GroupBox();
            this.LblRightQueueCount = new System.Windows.Forms.Label();
            this.LblRightActiveCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GrpBoxTunnel = new System.Windows.Forms.GroupBox();
            this.LblTunnelLeftActiveCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblTunnelRightActiveCount = new System.Windows.Forms.Label();
            this.GrpBoxLeft.SuspendLayout();
            this.GrpBoxRight.SuspendLayout();
            this.GrpBoxTunnel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("RussellSquare", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.Location = new System.Drawing.Point(12, 217);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(160, 48);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start Sim";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Font = new System.Drawing.Font("RussellSquare", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStop.Location = new System.Drawing.Point(178, 217);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(160, 48);
            this.BtnStop.TabIndex = 1;
            this.BtnStop.Text = "Stop Sim";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // GrpBoxTraffic
            // 
            this.GrpBoxTraffic.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GrpBoxTraffic.BackgroundImage = global::Multithreading_06.Properties.Resources.tunnel;
            this.GrpBoxTraffic.Font = new System.Drawing.Font("RussellSquare", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBoxTraffic.Location = new System.Drawing.Point(12, 12);
            this.GrpBoxTraffic.Name = "GrpBoxTraffic";
            this.GrpBoxTraffic.Size = new System.Drawing.Size(768, 128);
            this.GrpBoxTraffic.TabIndex = 2;
            this.GrpBoxTraffic.TabStop = false;
            this.GrpBoxTraffic.Text = "Traffic";
            this.GrpBoxTraffic.Paint += new System.Windows.Forms.PaintEventHandler(this.GrpBoxTraffic_Paint);
            // 
            // GrpBoxLeft
            // 
            this.GrpBoxLeft.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GrpBoxLeft.Controls.Add(this.LblLeftQueueCount);
            this.GrpBoxLeft.Controls.Add(this.LblLeftActiveCount);
            this.GrpBoxLeft.Controls.Add(this.label2);
            this.GrpBoxLeft.Controls.Add(this.label1);
            this.GrpBoxLeft.Font = new System.Drawing.Font("RussellSquare", 12F, System.Drawing.FontStyle.Bold);
            this.GrpBoxLeft.Location = new System.Drawing.Point(13, 147);
            this.GrpBoxLeft.Name = "GrpBoxLeft";
            this.GrpBoxLeft.Size = new System.Drawing.Size(251, 64);
            this.GrpBoxLeft.TabIndex = 3;
            this.GrpBoxLeft.TabStop = false;
            this.GrpBoxLeft.Text = "Left Side";
            // 
            // LblLeftQueueCount
            // 
            this.LblLeftQueueCount.AutoSize = true;
            this.LblLeftQueueCount.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.LblLeftQueueCount.Location = new System.Drawing.Point(65, 41);
            this.LblLeftQueueCount.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.LblLeftQueueCount.Name = "LblLeftQueueCount";
            this.LblLeftQueueCount.Size = new System.Drawing.Size(17, 18);
            this.LblLeftQueueCount.TabIndex = 3;
            this.LblLeftQueueCount.Text = "0";
            // 
            // LblLeftActiveCount
            // 
            this.LblLeftActiveCount.AutoSize = true;
            this.LblLeftActiveCount.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.LblLeftActiveCount.Location = new System.Drawing.Point(65, 23);
            this.LblLeftActiveCount.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.LblLeftActiveCount.Name = "LblLeftActiveCount";
            this.LblLeftActiveCount.Size = new System.Drawing.Size(17, 18);
            this.LblLeftActiveCount.TabIndex = 2;
            this.LblLeftActiveCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Active:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Queue: ";
            // 
            // GrpBoxRight
            // 
            this.GrpBoxRight.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GrpBoxRight.Controls.Add(this.LblRightQueueCount);
            this.GrpBoxRight.Controls.Add(this.LblRightActiveCount);
            this.GrpBoxRight.Controls.Add(this.label5);
            this.GrpBoxRight.Controls.Add(this.label4);
            this.GrpBoxRight.Font = new System.Drawing.Font("RussellSquare", 12F, System.Drawing.FontStyle.Bold);
            this.GrpBoxRight.Location = new System.Drawing.Point(529, 147);
            this.GrpBoxRight.Name = "GrpBoxRight";
            this.GrpBoxRight.Size = new System.Drawing.Size(251, 64);
            this.GrpBoxRight.TabIndex = 4;
            this.GrpBoxRight.TabStop = false;
            this.GrpBoxRight.Text = "Right Side";
            // 
            // LblRightQueueCount
            // 
            this.LblRightQueueCount.AutoSize = true;
            this.LblRightQueueCount.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.LblRightQueueCount.Location = new System.Drawing.Point(65, 41);
            this.LblRightQueueCount.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.LblRightQueueCount.Name = "LblRightQueueCount";
            this.LblRightQueueCount.Size = new System.Drawing.Size(17, 18);
            this.LblRightQueueCount.TabIndex = 4;
            this.LblRightQueueCount.Text = "0";
            // 
            // LblRightActiveCount
            // 
            this.LblRightActiveCount.AutoSize = true;
            this.LblRightActiveCount.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.LblRightActiveCount.Location = new System.Drawing.Point(65, 23);
            this.LblRightActiveCount.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.LblRightActiveCount.Name = "LblRightActiveCount";
            this.LblRightActiveCount.Size = new System.Drawing.Size(17, 18);
            this.LblRightActiveCount.TabIndex = 4;
            this.LblRightActiveCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.label5.Location = new System.Drawing.Point(12, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Queue: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Active:";
            // 
            // GrpBoxTunnel
            // 
            this.GrpBoxTunnel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GrpBoxTunnel.Controls.Add(this.LblTunnelRightActiveCount);
            this.GrpBoxTunnel.Controls.Add(this.label6);
            this.GrpBoxTunnel.Controls.Add(this.LblTunnelLeftActiveCount);
            this.GrpBoxTunnel.Controls.Add(this.label3);
            this.GrpBoxTunnel.Font = new System.Drawing.Font("RussellSquare", 12F, System.Drawing.FontStyle.Bold);
            this.GrpBoxTunnel.Location = new System.Drawing.Point(270, 146);
            this.GrpBoxTunnel.Name = "GrpBoxTunnel";
            this.GrpBoxTunnel.Size = new System.Drawing.Size(252, 65);
            this.GrpBoxTunnel.TabIndex = 5;
            this.GrpBoxTunnel.TabStop = false;
            this.GrpBoxTunnel.Text = "Tunnel Road";
            // 
            // LblTunnelLeftActiveCount
            // 
            this.LblTunnelLeftActiveCount.AutoSize = true;
            this.LblTunnelLeftActiveCount.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.LblTunnelLeftActiveCount.Location = new System.Drawing.Point(99, 23);
            this.LblTunnelLeftActiveCount.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.LblTunnelLeftActiveCount.Name = "LblTunnelLeftActiveCount";
            this.LblTunnelLeftActiveCount.Size = new System.Drawing.Size(17, 18);
            this.LblTunnelLeftActiveCount.TabIndex = 4;
            this.LblTunnelLeftActiveCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Left Active:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.label6.Location = new System.Drawing.Point(12, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Right Active:";
            // 
            // LblTunnelRightActiveCount
            // 
            this.LblTunnelRightActiveCount.AutoSize = true;
            this.LblTunnelRightActiveCount.Font = new System.Drawing.Font("RussellSquare", 10F);
            this.LblTunnelRightActiveCount.Location = new System.Drawing.Point(99, 41);
            this.LblTunnelRightActiveCount.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.LblTunnelRightActiveCount.Name = "LblTunnelRightActiveCount";
            this.LblTunnelRightActiveCount.Size = new System.Drawing.Size(17, 18);
            this.LblTunnelRightActiveCount.TabIndex = 6;
            this.LblTunnelRightActiveCount.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(789, 273);
            this.Controls.Add(this.GrpBoxTunnel);
            this.Controls.Add(this.GrpBoxRight);
            this.Controls.Add(this.GrpBoxLeft);
            this.Controls.Add(this.GrpBoxTraffic);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Name = "MainForm";
            this.Text = "Multithreading_06";
            this.GrpBoxLeft.ResumeLayout(false);
            this.GrpBoxLeft.PerformLayout();
            this.GrpBoxRight.ResumeLayout(false);
            this.GrpBoxRight.PerformLayout();
            this.GrpBoxTunnel.ResumeLayout(false);
            this.GrpBoxTunnel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.GroupBox GrpBoxTraffic;
        private System.Windows.Forms.GroupBox GrpBoxLeft;
        private System.Windows.Forms.GroupBox GrpBoxRight;
        private System.Windows.Forms.GroupBox GrpBoxTunnel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblLeftQueueCount;
        private System.Windows.Forms.Label LblLeftActiveCount;
        private System.Windows.Forms.Label LblTunnelLeftActiveCount;
        private System.Windows.Forms.Label LblRightQueueCount;
        private System.Windows.Forms.Label LblRightActiveCount;
        private System.Windows.Forms.Label LblTunnelRightActiveCount;
        private System.Windows.Forms.Label label6;
    }
}

