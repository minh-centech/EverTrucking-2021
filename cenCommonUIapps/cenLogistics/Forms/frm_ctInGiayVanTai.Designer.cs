
namespace cenCommonUIapps.cenLogistics.Forms
{
    partial class frm_ctInGiayVanTai
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            this.saLabel4 = new coreControls.saLabel();
            this.cboIDDanhMucChuXe = new coreControls.saComboDanhMuc();
            ((System.ComponentModel.ISupportInitialize)(this.ug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboIDDanhMucChuXe)).BeginInit();
            this.SuspendLayout();
            // 
            // ug
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ug.DisplayLayout.Appearance = appearance1;
            this.ug.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ug.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ug.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ug.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ug.DisplayLayout.MaxColScrollRegions = 1;
            this.ug.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ug.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Highlight;
            appearance3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ug.DisplayLayout.Override.ActiveRowAppearance = appearance3;
            this.ug.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ug.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            this.ug.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ug.DisplayLayout.Override.CellAppearance = appearance5;
            this.ug.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ug.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.ug.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.ug.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.ug.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ug.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            this.ug.DisplayLayout.Override.RowAppearance = appearance8;
            this.ug.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ug.DisplayLayout.Override.TemplateAddRowAppearance = appearance9;
            this.ug.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ug.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ug.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.ug.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ug.Location = new System.Drawing.Point(0, 62);
            this.ug.Size = new System.Drawing.Size(938, 388);
            this.ug.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ug_InitializeRow);
            this.ug.AfterRowActivate += new System.EventHandler(this.ug_AfterRowActivate);
            // 
            // UltraToolbarsManager1
            // 
            this.UltraToolbarsManager1.MenuSettings.ForceSerialization = true;
            this.UltraToolbarsManager1.ToolbarSettings.ForceSerialization = true;
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.DateTime = new System.DateTime(2020, 11, 30, 0, 0, 0, 0);
            this.txtDenNgay.Location = new System.Drawing.Point(219, 8);
            this.txtDenNgay.Value = new System.DateTime(2020, 11, 30, 0, 0, 0, 0);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.DateTime = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            this.txtTuNgay.Location = new System.Drawing.Point(54, 8);
            this.txtTuNgay.Value = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.cboIDDanhMucChuXe);
            this.ultraGroupBox2.Controls.Add(this.saLabel4);
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 25);
            this.ultraGroupBox2.Size = new System.Drawing.Size(938, 37);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel1, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel2, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel4, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.cboIDDanhMucChuXe, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.ultraButton1, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.txtTuNgay, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.txtDenNgay, 0);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(642, 8);
            // 
            // saLabel4
            // 
            appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel4.Appearance = appearance11;
            this.saLabel4.AutoSize = true;
            this.saLabel4.Location = new System.Drawing.Point(325, 8);
            this.saLabel4.Name = "saLabel4";
            this.saLabel4.Size = new System.Drawing.Size(40, 14);
            this.saLabel4.TabIndex = 7;
            this.saLabel4.Text = "Chủ xe";
            // 
            // cboIDDanhMucChuXe
            // 
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.cboIDDanhMucChuXe.Appearance = appearance10;
            this.cboIDDanhMucChuXe.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboIDDanhMucChuXe.AutoSize = false;
            this.cboIDDanhMucChuXe.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cboIDDanhMucChuXe.Location = new System.Drawing.Point(371, 8);
            this.cboIDDanhMucChuXe.Name = "cboIDDanhMucChuXe";
            this.cboIDDanhMucChuXe.NullText = "Tất cả";
            this.cboIDDanhMucChuXe.Size = new System.Drawing.Size(265, 21);
            this.cboIDDanhMucChuXe.TabIndex = 10;
            // 
            // frm_ctInGiayVanTai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 450);
            this.Name = "frm_ctInGiayVanTai";
            this.Text = "frm_ctHopDongVanChuyen";
            ((System.ComponentModel.ISupportInitialize)(this.ug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboIDDanhMucChuXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saComboDanhMuc cboIDDanhMucChuXe;
        private coreControls.saLabel saLabel4;
    }
}