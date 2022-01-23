
namespace cenCommonUIapps.cenLogistics.Forms
{
    partial class frm_ctChiPhiVanTaiBoSung
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
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.cboIDDanhMucNhomHangVanChuyen = new coreControls.saComboDanhMuc();
            this.saLabel4 = new coreControls.saLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIDDanhMucNhomHangVanChuyen)).BeginInit();
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
            this.ug.Size = new System.Drawing.Size(991, 388);
            this.ug.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ug_InitializeRow);
            // 
            // UltraToolbarsManager1
            // 
            this.UltraToolbarsManager1.MenuSettings.ForceSerialization = true;
            this.UltraToolbarsManager1.ToolbarSettings.ForceSerialization = true;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.cboIDDanhMucNhomHangVanChuyen);
            this.ultraGroupBox2.Controls.Add(this.saLabel4);
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 25);
            this.ultraGroupBox2.Size = new System.Drawing.Size(991, 37);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel1, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel2, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.ultraButton1, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.txtTuNgay, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.txtDenNgay, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel4, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.cboIDDanhMucNhomHangVanChuyen, 0);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(621, 4);
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.DateTime = new System.DateTime(2020, 11, 30, 0, 0, 0, 0);
            this.txtDenNgay.Value = new System.DateTime(2020, 11, 30, 0, 0, 0, 0);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.DateTime = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            this.txtTuNgay.Value = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            // 
            // cboIDDanhMucNhomHangVanChuyen
            // 
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.cboIDDanhMucNhomHangVanChuyen.Appearance = appearance10;
            this.cboIDDanhMucNhomHangVanChuyen.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboIDDanhMucNhomHangVanChuyen.AutoSize = false;
            this.cboIDDanhMucNhomHangVanChuyen.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cboIDDanhMucNhomHangVanChuyen.Location = new System.Drawing.Point(394, 5);
            this.cboIDDanhMucNhomHangVanChuyen.Name = "cboIDDanhMucNhomHangVanChuyen";
            this.cboIDDanhMucNhomHangVanChuyen.NullText = "Tất cả";
            this.cboIDDanhMucNhomHangVanChuyen.Size = new System.Drawing.Size(221, 21);
            this.cboIDDanhMucNhomHangVanChuyen.TabIndex = 10;
            // 
            // saLabel4
            // 
            appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel4.Appearance = appearance11;
            this.saLabel4.AutoSize = true;
            this.saLabel4.Location = new System.Drawing.Point(325, 6);
            this.saLabel4.Name = "saLabel4";
            this.saLabel4.Size = new System.Drawing.Size(63, 14);
            this.saLabel4.TabIndex = 7;
            this.saLabel4.Text = "Nhóm hàng";
            // 
            // frm_ctChiPhiVanTaiBoSung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 450);
            this.Name = "frm_ctChiPhiVanTaiBoSung";
            this.Text = "frm_ctHopDongVanChuyen";
            ((System.ComponentModel.ISupportInitialize)(this.ug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIDDanhMucNhomHangVanChuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private coreControls.saComboDanhMuc cboIDDanhMucNhomHangVanChuyen;
        private coreControls.saLabel saLabel4;
    }
}