
namespace cenCommonUIapps.cenLogistics.Forms
{
    partial class frm_ctDieuHanh
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
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.saLabel4 = new coreControls.saLabel();
            this.cboIDDanhMucNhomHangVanChuyen = new coreControls.saComboDanhMuc();
            this.txtTruck = new coreControls.saNumericBox();
            this.txtCont = new coreControls.saNumericBox();
            this.txtTotal = new coreControls.saNumericBox();
            this.saLabel5 = new coreControls.saLabel();
            this.saLabel3 = new coreControls.saLabel();
            this.saLabel6 = new coreControls.saLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIDDanhMucNhomHangVanChuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
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
            this.ug.Size = new System.Drawing.Size(1140, 388);
            this.ug.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ug_InitializeRow);
            // 
            // UltraToolbarsManager1
            // 
            this.UltraToolbarsManager1.MenuSettings.ForceSerialization = true;
            this.UltraToolbarsManager1.ToolbarSettings.ForceSerialization = true;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.saLabel5);
            this.ultraGroupBox2.Controls.Add(this.saLabel3);
            this.ultraGroupBox2.Controls.Add(this.saLabel6);
            this.ultraGroupBox2.Controls.Add(this.txtTruck);
            this.ultraGroupBox2.Controls.Add(this.txtCont);
            this.ultraGroupBox2.Controls.Add(this.txtTotal);
            this.ultraGroupBox2.Controls.Add(this.cboIDDanhMucNhomHangVanChuyen);
            this.ultraGroupBox2.Controls.Add(this.saLabel4);
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 25);
            this.ultraGroupBox2.Size = new System.Drawing.Size(1140, 37);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel1, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel2, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel4, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.cboIDDanhMucNhomHangVanChuyen, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.ultraButton1, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.txtTuNgay, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.txtTotal, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.txtDenNgay, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.txtCont, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.txtTruck, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel6, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel3, 0);
            this.ultraGroupBox2.Controls.SetChildIndex(this.saLabel5, 0);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(500, 6);
            this.ultraButton1.Size = new System.Drawing.Size(73, 21);
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.DateTime = new System.DateTime(2020, 11, 30, 0, 0, 0, 0);
            this.txtDenNgay.Location = new System.Drawing.Point(219, 6);
            this.txtDenNgay.Value = new System.DateTime(2020, 11, 30, 0, 0, 0, 0);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.DateTime = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            this.txtTuNgay.Location = new System.Drawing.Point(54, 6);
            this.txtTuNgay.Value = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            // 
            // saLabel4
            // 
            appearance17.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel4.Appearance = appearance17;
            this.saLabel4.AutoSize = true;
            this.saLabel4.Location = new System.Drawing.Point(325, 6);
            this.saLabel4.Name = "saLabel4";
            this.saLabel4.Size = new System.Drawing.Size(63, 14);
            this.saLabel4.TabIndex = 7;
            this.saLabel4.Text = "Nhóm hàng";
            // 
            // cboIDDanhMucNhomHangVanChuyen
            // 
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            this.cboIDDanhMucNhomHangVanChuyen.Appearance = appearance16;
            this.cboIDDanhMucNhomHangVanChuyen.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboIDDanhMucNhomHangVanChuyen.AutoSize = false;
            this.cboIDDanhMucNhomHangVanChuyen.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cboIDDanhMucNhomHangVanChuyen.Location = new System.Drawing.Point(394, 6);
            this.cboIDDanhMucNhomHangVanChuyen.Name = "cboIDDanhMucNhomHangVanChuyen";
            this.cboIDDanhMucNhomHangVanChuyen.NullText = "Tất cả";
            this.cboIDDanhMucNhomHangVanChuyen.Size = new System.Drawing.Size(100, 21);
            this.cboIDDanhMucNhomHangVanChuyen.TabIndex = 10;
            // 
            // txtTruck
            // 
            this.txtTruck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTruck.Appearance = appearance13;
            this.txtTruck.AutoSize = false;
            this.txtTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTruck.Location = new System.Drawing.Point(1063, 6);
            this.txtTruck.MaskInput = "-n,nnn";
            this.txtTruck.Name = "txtTruck";
            this.txtTruck.Nullable = true;
            this.txtTruck.PromptChar = ' ';
            this.txtTruck.ReadOnly = true;
            this.txtTruck.Size = new System.Drawing.Size(65, 21);
            this.txtTruck.TabIndex = 124;
            this.txtTruck.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // txtCont
            // 
            this.txtCont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtCont.Appearance = appearance14;
            this.txtCont.AutoSize = false;
            this.txtCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCont.Location = new System.Drawing.Point(911, 6);
            this.txtCont.MaskInput = "-n,nnn";
            this.txtCont.Name = "txtCont";
            this.txtCont.Nullable = true;
            this.txtCont.PromptChar = ' ';
            this.txtCont.ReadOnly = true;
            this.txtCont.Size = new System.Drawing.Size(65, 21);
            this.txtCont.TabIndex = 125;
            this.txtCont.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTotal.Appearance = appearance15;
            this.txtTotal.AutoSize = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(759, 6);
            this.txtTotal.MaskInput = "-n,nnn";
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Nullable = true;
            this.txtTotal.PromptChar = ' ';
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(65, 21);
            this.txtTotal.TabIndex = 126;
            this.txtTotal.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // saLabel5
            // 
            this.saLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel5.Appearance = appearance10;
            this.saLabel5.AutoSize = true;
            this.saLabel5.Location = new System.Drawing.Point(1025, 6);
            this.saLabel5.Name = "saLabel5";
            this.saLabel5.Size = new System.Drawing.Size(32, 14);
            this.saLabel5.TabIndex = 127;
            this.saLabel5.Text = "Truck";
            // 
            // saLabel3
            // 
            this.saLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel3.Appearance = appearance11;
            this.saLabel3.AutoSize = true;
            this.saLabel3.Location = new System.Drawing.Point(875, 6);
            this.saLabel3.Name = "saLabel3";
            this.saLabel3.Size = new System.Drawing.Size(28, 14);
            this.saLabel3.TabIndex = 128;
            this.saLabel3.Text = "Cont";
            // 
            // saLabel6
            // 
            this.saLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel6.Appearance = appearance12;
            this.saLabel6.AutoSize = true;
            this.saLabel6.Location = new System.Drawing.Point(723, 6);
            this.saLabel6.Name = "saLabel6";
            this.saLabel6.Size = new System.Drawing.Size(30, 14);
            this.saLabel6.TabIndex = 129;
            this.saLabel6.Text = "Tổng";
            // 
            // frm_ctDieuHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 450);
            this.Name = "frm_ctDieuHanh";
            this.Text = "frm_ctHopDongVanChuyen";
            ((System.ComponentModel.ISupportInitialize)(this.ug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIDDanhMucNhomHangVanChuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saComboDanhMuc cboIDDanhMucNhomHangVanChuyen;
        private coreControls.saLabel saLabel4;
        private coreControls.saNumericBox txtTruck;
        private coreControls.saNumericBox txtCont;
        private coreControls.saNumericBox txtTotal;
        private coreControls.saLabel saLabel5;
        private coreControls.saLabel saLabel3;
        private coreControls.saLabel saLabel6;
    }
}