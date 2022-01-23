namespace cenCommonUIapps.cenLogistics.Forms
{
    partial class frmWorkingInProgress
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmdOK = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraProgressBar1 = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cmdStart = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.ultraGroupBox1.Controls.Add(this.cmdStart);
            this.ultraGroupBox1.Controls.Add(this.cmdOK);
            this.ultraGroupBox1.Controls.Add(this.ultraGroupBox2);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(636, 260);
            this.ultraGroupBox1.TabIndex = 0;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Location = new System.Drawing.Point(558, 234);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "&Close";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGroupBox2.Appearance = appearance2;
            this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rectangular3D;
            this.ultraGroupBox2.Controls.Add(this.ultraProgressBar1);
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(636, 233);
            this.ultraGroupBox2.TabIndex = 0;
            this.ultraGroupBox2.UseAppStyling = false;
            // 
            // ultraProgressBar1
            // 
            this.ultraProgressBar1.Location = new System.Drawing.Point(3, 105);
            this.ultraProgressBar1.Name = "ultraProgressBar1";
            this.ultraProgressBar1.Size = new System.Drawing.Size(630, 23);
            this.ultraProgressBar1.TabIndex = 1;
            this.ultraProgressBar1.Text = "[Formatted]";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // cmdStart
            // 
            this.cmdStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStart.Location = new System.Drawing.Point(477, 234);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.Text = "&Bắt đầu";
            this.cmdStart.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // frmWorkingInProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 260);
            this.ControlBox = false;
            this.Controls.Add(this.ultraGroupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWorkingInProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWorkingInProgress";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraButton cmdOK;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinProgressBar.UltraProgressBar ultraProgressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Infragistics.Win.Misc.UltraButton cmdStart;
    }
}