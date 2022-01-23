namespace cenCommonUIapps.cenLogistics.Forms
{
    partial class frmImageViewer
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
            this.ultraListView2 = new Infragistics.Win.UltraWinListView.UltraListView();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            ((System.ComponentModel.ISupportInitialize)(this.ultraListView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraListView2
            // 
            this.ultraListView2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraListView2.Location = new System.Drawing.Point(3, 3);
            this.ultraListView2.Name = "ultraListView2";
            this.ultraListView2.Size = new System.Drawing.Size(1145, 180);
            this.ultraListView2.TabIndex = 0;
            this.ultraListView2.Text = "ultraListView2";
            this.ultraListView2.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Thumbnails;
            this.ultraListView2.ViewSettingsThumbnails.ImageSize = new System.Drawing.Size(60, 60);
            this.ultraListView2.ViewSettingsThumbnails.ItemSize = new System.Drawing.Size(-1, -1);
            this.ultraListView2.ViewSettingsTiles.ImageSize = new System.Drawing.Size(80, 80);
            this.ultraListView2.ItemActivated += new Infragistics.Win.UltraWinListView.ItemActivatedEventHandler(this.ultraListView2_ItemActivated);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rectangular3D;
            this.ultraGroupBox1.Controls.Add(this.ultraListView2);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 557);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1151, 186);
            this.ultraGroupBox1.TabIndex = 119;
            this.ultraGroupBox1.UseAppStyling = false;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rectangular3D;
            this.ultraGroupBox2.Controls.Add(this.ultraPictureBox1);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(1151, 557);
            this.ultraGroupBox2.TabIndex = 120;
            this.ultraGroupBox2.UseAppStyling = false;
            // 
            // ultraPictureBox1
            // 
            this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPictureBox1.Location = new System.Drawing.Point(3, 3);
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            this.ultraPictureBox1.ScaleImage = Infragistics.Win.ScaleImage.Always;
            this.ultraPictureBox1.Size = new System.Drawing.Size(1145, 551);
            this.ultraPictureBox1.TabIndex = 2;
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.BackColor = System.Drawing.SystemColors.Control;
            this.ultraSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraSplitter1.Location = new System.Drawing.Point(0, 554);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 141;
            this.ultraSplitter1.Size = new System.Drawing.Size(1151, 3);
            this.ultraSplitter1.TabIndex = 121;
            // 
            // frmImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 743);
            this.Controls.Add(this.ultraSplitter1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmImageViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImageViewer";
            this.Load += new System.EventHandler(this.frmImageViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraListView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinListView.UltraListView ultraListView2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
    }
}