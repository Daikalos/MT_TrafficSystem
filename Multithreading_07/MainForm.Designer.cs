namespace Multithreading_07
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
            this.GrpBoxTunnel = new System.Windows.Forms.GroupBox();
            this.GrpBoxLeft = new System.Windows.Forms.GroupBox();
            this.GrpBoxRight = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("RussellSquare", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.Location = new System.Drawing.Point(12, 306);
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
            this.BtnStop.Location = new System.Drawing.Point(178, 306);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(160, 48);
            this.BtnStop.TabIndex = 1;
            this.BtnStop.Text = "Stop Sim";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // GrpBoxTunnel
            // 
            this.GrpBoxTunnel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GrpBoxTunnel.BackgroundImage = global::Multithreading_07.Properties.Resources.tunnel;
            this.GrpBoxTunnel.Font = new System.Drawing.Font("RussellSquare", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBoxTunnel.Location = new System.Drawing.Point(12, 12);
            this.GrpBoxTunnel.Name = "GrpBoxTunnel";
            this.GrpBoxTunnel.Size = new System.Drawing.Size(768, 128);
            this.GrpBoxTunnel.TabIndex = 2;
            this.GrpBoxTunnel.TabStop = false;
            this.GrpBoxTunnel.Text = "Tunnel";
            this.GrpBoxTunnel.Paint += new System.Windows.Forms.PaintEventHandler(this.GrpBoxTunnel_Paint);
            // 
            // GrpBoxLeft
            // 
            this.GrpBoxLeft.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GrpBoxLeft.Font = new System.Drawing.Font("RussellSquare", 12F, System.Drawing.FontStyle.Bold);
            this.GrpBoxLeft.Location = new System.Drawing.Point(13, 147);
            this.GrpBoxLeft.Name = "GrpBoxLeft";
            this.GrpBoxLeft.Size = new System.Drawing.Size(251, 153);
            this.GrpBoxLeft.TabIndex = 3;
            this.GrpBoxLeft.TabStop = false;
            this.GrpBoxLeft.Text = "Left Road";
            // 
            // GrpBoxRight
            // 
            this.GrpBoxRight.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GrpBoxRight.Font = new System.Drawing.Font("RussellSquare", 12F, System.Drawing.FontStyle.Bold);
            this.GrpBoxRight.Location = new System.Drawing.Point(529, 147);
            this.GrpBoxRight.Name = "GrpBoxRight";
            this.GrpBoxRight.Size = new System.Drawing.Size(251, 153);
            this.GrpBoxRight.TabIndex = 4;
            this.GrpBoxRight.TabStop = false;
            this.GrpBoxRight.Text = "Right Road";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox1.Font = new System.Drawing.Font("RussellSquare", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(270, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 153);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tunnel Road";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(789, 363);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GrpBoxRight);
            this.Controls.Add(this.GrpBoxLeft);
            this.Controls.Add(this.GrpBoxTunnel);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Name = "MainForm";
            this.Text = "Multithreading_07";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.GroupBox GrpBoxTunnel;
        private System.Windows.Forms.GroupBox GrpBoxLeft;
        private System.Windows.Forms.GroupBox GrpBoxRight;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

