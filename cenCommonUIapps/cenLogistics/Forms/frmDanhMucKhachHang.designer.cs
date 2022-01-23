namespace cenCommonUIapps.cenLogistics.Forms
{
    partial class frmDanhMucKhachHang
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BindingList`1", -1);
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
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabChiTiet)).BeginInit();
            this.tabChiTiet.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiTietfilterBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ug
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ug.DisplayLayout.Appearance = appearance1;
            this.ug.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            ultraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            ultraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            ultraGridBand1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            this.ug.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ug.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ug.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ug.DisplayLayout.EmptyRowSettings.ShowEmptyRows = true;
            this.ug.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ug.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ug.DisplayLayout.MaxColScrollRegions = 1;
            this.ug.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ug.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.ug.DisplayLayout.Override.ActiveRowAppearance = appearance3;
            this.ug.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.ug.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.ug.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ug.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            this.ug.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ug.DisplayLayout.Override.CellAppearance = appearance5;
            this.ug.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ug.DisplayLayout.Override.CellPadding = 0;
            this.ug.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.ug.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.ug.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.ug.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.ug.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.ug.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            this.ug.DisplayLayout.Override.RowAppearance = appearance8;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.ug.DisplayLayout.Override.RowSelectorAppearance = appearance9;
            this.ug.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.ug.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex;
            this.ug.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ug.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.ug.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ug.DisplayLayout.Override.SummaryFooterAppearance = appearance10;
            this.ug.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance11.FontData.BoldAsString = "True";
            appearance11.FontData.SizeInPoints = 9F;
            this.ug.DisplayLayout.Override.SummaryValueAppearance = appearance11;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ug.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.ug.DisplayLayout.RowSelectorImages.ActiveAndAddNewRowImage = null;
            this.ug.DisplayLayout.RowSelectorImages.ActiveAndDataChangedImage = null;
            this.ug.DisplayLayout.RowSelectorImages.ActiveRowImage = null;
            this.ug.DisplayLayout.RowSelectorImages.AddNewRowImage = null;
            this.ug.DisplayLayout.RowSelectorImages.DataChangedImage = null;
            this.ug.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ug.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ug.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.ug.DisplayLayout.UseFixedHeaders = true;
            this.ug.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ug.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ug.Location = new System.Drawing.Point(0, 25);
            this.ug.Size = new System.Drawing.Size(543, 211);
            // 
            // tabChiTiet
            // 
            this.tabChiTiet.Size = new System.Drawing.Size(543, 161);
            this.tabChiTiet.TabPageMargins.ForceSerialization = true;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Size = new System.Drawing.Size(539, 135);
            // 
            // ugChiTiet
            // 
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugChiTiet.DisplayLayout.Appearance = appearance13;
            this.ugChiTiet.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugChiTiet.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ugChiTiet.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugChiTiet.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ugChiTiet.DisplayLayout.MaxColScrollRegions = 1;
            this.ugChiTiet.DisplayLayout.MaxRowScrollRegions = 1;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugChiTiet.DisplayLayout.Override.ActiveCellAppearance = appearance14;
            appearance15.BackColor = System.Drawing.SystemColors.Highlight;
            appearance15.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugChiTiet.DisplayLayout.Override.ActiveRowAppearance = appearance15;
            this.ugChiTiet.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugChiTiet.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            this.ugChiTiet.DisplayLayout.Override.CardAreaAppearance = appearance16;
            appearance17.BorderColor = System.Drawing.Color.Silver;
            appearance17.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugChiTiet.DisplayLayout.Override.CellAppearance = appearance17;
            this.ugChiTiet.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugChiTiet.DisplayLayout.Override.CellPadding = 0;
            appearance18.BackColor = System.Drawing.SystemColors.Control;
            appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance18.BorderColor = System.Drawing.SystemColors.Window;
            this.ugChiTiet.DisplayLayout.Override.GroupByRowAppearance = appearance18;
            appearance19.TextHAlignAsString = "Left";
            this.ugChiTiet.DisplayLayout.Override.HeaderAppearance = appearance19;
            this.ugChiTiet.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugChiTiet.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            this.ugChiTiet.DisplayLayout.Override.RowAppearance = appearance20;
            this.ugChiTiet.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance21.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugChiTiet.DisplayLayout.Override.TemplateAddRowAppearance = appearance21;
            this.ugChiTiet.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugChiTiet.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugChiTiet.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.ugChiTiet.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugChiTiet.Size = new System.Drawing.Size(539, 135);
            // 
            // txtChiTietfilterBox
            // 
            this.txtChiTietfilterBox.Size = new System.Drawing.Size(543, 26);
            // 
            // uSplitter
            // 
            this.uSplitter.Location = new System.Drawing.Point(0, 236);
            this.uSplitter.Size = new System.Drawing.Size(543, 6);
            // 
            // UltraToolbarsManager1
            // 
            this.UltraToolbarsManager1.MenuSettings.ForceSerialization = true;
            this.UltraToolbarsManager1.ToolbarSettings.ForceSerialization = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // frmDanhMucKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 429);
            this.Name = "frmDanhMucKhachHang";
            this.Text = "frmDanhMuc";
            ((System.ComponentModel.ISupportInitialize)(this.ug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabChiTiet)).EndInit();
            this.tabChiTiet.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiTietfilterBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}