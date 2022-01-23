using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctChotDoanhThuGuiKeToan : Form
    {
        public object IDDanhMucChungTu = null;
        ctChotDoanhThuGuiKeToanBUS BUS = null;
        DataSet dsData = null;
        public frm_ctChotDoanhThuGuiKeToan()
        {
            InitializeComponent();
            txtTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtDenNgay.DateTime = txtTuNgay.DateTime.AddMonths(1).AddDays(-1);
        }
        private void List()
        {
            ////Khách hàng
            //DanhMucKhachHangBUS DanhMucKhachHangBUS = new DanhMucKhachHangBUS();
            //DataTable dtKhachHang = DanhMucKhachHangBUS.Valid(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
            //cboIDDanhMucKhachHang.dtValid = dtKhachHang;
            //cboIDDanhMucKhachHang.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang));
            //cboIDDanhMucKhachHang.procedureName = DanhMucKhachHang.listProcedureName;
            //cboIDDanhMucKhachHang.DataSource = dtKhachHang;
            //cboIDDanhMucKhachHang.ValueMember = "ID";
            //cboIDDanhMucKhachHang.DisplayMember = "Ten";
            ////Sale
            //DanhMucNhanSuBUS DanhMucNhanSuBUS = new DanhMucNhanSuBUS();
            //DataTable dtSale = DanhMucNhanSuBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu)), null);
            //cboIDDanhMucSale.dtValid = dtSale;
            //cboIDDanhMucSale.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu));
            //cboIDDanhMucSale.procedureName = DanhMucNhanSu.listProcedureName;
            //cboIDDanhMucSale.DataSource = dtSale;
            //cboIDDanhMucSale.ValueMember = "ID";
            //cboIDDanhMucSale.DisplayMember = "Ten";
            //
            BUS = new ctChotDoanhThuGuiKeToanBUS();
            dsData = BUS.List(IDDanhMucChungTu, txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucKhachHang.Value, cboIDDanhMucSale.Value);
            ugChungTuChuaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
            ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
            ugChungTuChuaChotDoanhThu.DataSource = dsData.Tables[ctDonHang.tableName];
            ugChungTuDaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
            ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
            ugChungTuDaChotDoanhThu.DataSource = dsData.Tables[ctChotDoanhThuGuiKeToan.tableName];
            //
            ugChungTuChuaChotDoanhThu.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow; //Biểu tượng lọc đặt trên tiêu đề cột
            ugChungTuDaChotDoanhThu.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow; //Biểu tượng lọc đặt trên tiêu đề cột
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Clear();
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Clear();
            //
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].DefaultCellValue = false;
            //Thêm dòng tổng cộng và định dạng
            ugChungTuChuaChotDoanhThu.DisplayLayout.Override.SummaryFooterAppearance.BackColor = System.Drawing.Color.LightSteelBlue; //Màu nền cho dòng tổng cộng
            ugChungTuChuaChotDoanhThu.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False; //Hiển thị caption của dòng tổng cộng
            ugChungTuChuaChotDoanhThu.DisplayLayout.Override.SummaryValueAppearance.BackColor = System.Drawing.Color.LightSteelBlue; //Màu nền của dòng tổng cộng
            //ugChungTuChuaChotDoanhThu.DisplayLayout.Override.SummaryValueAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True; //Màu nền của dòng tổng cộng
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienCuoc", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienCuoc"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuoc"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuoc"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuoc"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuoc"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienThuTuc", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienThuTuc"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienThuTuc"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienThuTuc"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienThuTuc"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienThuTuc"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienDoanhThuKhac", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienDoanhThuKhac"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienDoanhThuKhac"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienDoanhThuKhac"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienDoanhThuKhac"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienDoanhThuKhac"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienHoaHong", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienHoaHong"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienHoaHong"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienHoaHong"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienHoaHong"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienHoaHong"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienTrichPhanTram", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienTrichPhanTram"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTrichPhanTram"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTrichPhanTram"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTrichPhanTram"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTrichPhanTram"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("TongGiamDoanhThu", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["TongGiamDoanhThu"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["TongGiamDoanhThu"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["TongGiamDoanhThu"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["TongGiamDoanhThu"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["TongGiamDoanhThu"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            //
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].DefaultCellValue = false;
            //Thêm dòng tổng cộng và định dạng
            ugChungTuDaChotDoanhThu.DisplayLayout.Override.SummaryFooterAppearance.BackColor = System.Drawing.Color.LightSteelBlue; //Màu nền cho dòng tổng cộng
            ugChungTuDaChotDoanhThu.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False; //Hiển thị caption của dòng tổng cộng
            ugChungTuDaChotDoanhThu.DisplayLayout.Override.SummaryValueAppearance.BackColor = System.Drawing.Color.LightSteelBlue; //Màu nền của dòng tổng cộng
            //ugChungTuDaChotDoanhThu.DisplayLayout.Override.SummaryValueAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True; //Màu nền của dòng tổng cộng
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienCuoc", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienCuoc"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuoc"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuoc"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuoc"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuoc"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienThuTuc", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienThuTuc"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienThuTuc"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienThuTuc"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienThuTuc"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienThuTuc"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienDoanhThuKhac", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienDoanhThuKhac"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienDoanhThuKhac"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienDoanhThuKhac"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienDoanhThuKhac"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienDoanhThuKhac"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienHoaHong", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienHoaHong"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienHoaHong"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienHoaHong"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienHoaHong"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienHoaHong"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienTrichPhanTram", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienTrichPhanTram"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTrichPhanTram"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTrichPhanTram"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTrichPhanTram"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTrichPhanTram"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("TongGiamDoanhThu", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["TongGiamDoanhThu"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["TongGiamDoanhThu"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["TongGiamDoanhThu"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["TongGiamDoanhThu"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["TongGiamDoanhThu"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";



        }

        private void frm_ctChotDoanhThuGuiKeToan_Load(object sender, EventArgs e)
        {
            tabDaChot.Height = (this.Height - groupFilter.Height - cmdChot.Height - cmdHuyChot.Height) / 2;
            List();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            List();
        }

        private void ugChungTuChuaChotDoanhThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (ugChungTuChuaChotDoanhThu.ActiveRow != null && e.KeyCode == Keys.Space)
            {
                if (ugChungTuChuaChotDoanhThu.ActiveRow.Cells["LuaChon"].Value == DBNull.Value)
                    ugChungTuChuaChotDoanhThu.ActiveRow.Cells["LuaChon"].Value = true;
                else
                    ugChungTuChuaChotDoanhThu.ActiveRow.Cells["LuaChon"].Value = !Convert.ToBoolean(ugChungTuChuaChotDoanhThu.ActiveRow.Cells["LuaChon"].Value);
                ugChungTuChuaChotDoanhThu.UpdateData();
            }
        }

        private void ugChungTuChuaChotDoanhThu_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell != null && e.Cell.Column.Key == "LuaChon")
            {
                if (e.Cell.Value == DBNull.Value)
                    e.Cell.Value = true;
                else
                    e.Cell.Value = !(Convert.ToBoolean(e.Cell.Value));
                ugChungTuChuaChotDoanhThu.UpdateData();
            }
        }

        private void ugChungTuDaChotDoanhThu_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell != null && e.Cell.Column.Key == "LuaChon")
            {
                if (e.Cell.Value == DBNull.Value)
                    e.Cell.Value = true;
                else
                    e.Cell.Value = !(Convert.ToBoolean(e.Cell.Value));
                ugChungTuDaChotDoanhThu.UpdateData();
            }
        }

        private void ugChungTuDaChotDoanhThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (ugChungTuDaChotDoanhThu.ActiveRow != null && e.KeyCode == Keys.Space)
            {
                if (ugChungTuDaChotDoanhThu.ActiveRow.Cells["LuaChon"].Value == DBNull.Value)
                    ugChungTuDaChotDoanhThu.ActiveRow.Cells["LuaChon"].Value = true;
                else
                    ugChungTuDaChotDoanhThu.ActiveRow.Cells["LuaChon"].Value = !Convert.ToBoolean(ugChungTuDaChotDoanhThu.ActiveRow.Cells["LuaChon"].Value);
                ugChungTuDaChotDoanhThu.UpdateData();
            }
        }

        private void cmdChot_Click(object sender, EventArgs e)
        {
            //Chốt doanh thu
            List<ctChotDoanhThuGuiKeToan> objList = new List<ctChotDoanhThuGuiKeToan>();
            foreach (DataRow dr in dsData.Tables[ctDonHang.tableName].Rows)
            {
                if (!coreCommon.coreCommon.IsNull(dr["LuaChon"]) && dr["LuaChon"].ToString() == "True")
                {
                    objList.Add(new ctChotDoanhThuGuiKeToan
                    {
                        IDDanhMucChungTu = IDDanhMucChungTu,
                        IDChungTu = dr["ID"],
                        IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung
                    }
                    );
                }
            }
            if (objList.Count > 0)
            {
                if (coreCommon.coreCommon.QuestionMessage("Xác nhận chốt doanh thu những đơn hàng đã chọn?", 0) == DialogResult.Yes)
                {
                    Boolean Saved = BUS.Insert(objList);
                    if (Saved)
                    {
                        BUS = new ctChotDoanhThuGuiKeToanBUS();
                        dsData = BUS.List(IDDanhMucChungTu, txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucKhachHang.Value, cboIDDanhMucSale.Value);
                        ugChungTuChuaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
                        ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
                        ugChungTuChuaChotDoanhThu.DataSource = dsData.Tables[ctDonHang.tableName];
                        ugChungTuDaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
                        ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
                        ugChungTuDaChotDoanhThu.DataSource = dsData.Tables[ctChotDoanhThuGuiKeToan.tableName];
                        //
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.Default; //Biểu tượng lọc đặt trên tiêu đề cột
                        ugChungTuDaChotDoanhThu.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.Default; //Biểu tượng lọc đặt trên tiêu đề cột
                                                                                                                                          //
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].DefaultCellValue = false;
                        //
                        ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
                        ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
                        ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                        ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].DefaultCellValue = false;
                    }
                }
            }
            else
                coreCommon.coreCommon.ErrorMessageOkOnly("Không có đơn hàng cần chốt doanh thu!");
        }

        private void cmdHuyChot_Click(object sender, EventArgs e)
        {
            //Hủy Chốt doanh thu
            List<ctChotDoanhThuGuiKeToan> objList = new List<ctChotDoanhThuGuiKeToan>();
            foreach (DataRow dr in dsData.Tables[ctChotDoanhThuGuiKeToan.tableName].Rows)
            {
                if (!coreCommon.coreCommon.IsNull(dr["LuaChon"]) && dr["LuaChon"].ToString() == "True")
                {
                    objList.Add(new ctChotDoanhThuGuiKeToan
                    {
                        IDDanhMucChungTu = IDDanhMucChungTu,
                        ID = dr["IDctChotDoanhThuGuiKeToan"],
                        IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung
                    }
                    );
                }
            }
            if (objList.Count > 0)
            {
                if (coreCommon.coreCommon.QuestionMessage("Xác nhận hủy chốt doanh thu những đơn hàng đã chọn?", 0) == DialogResult.Yes)
                {
                    Boolean Deleted = BUS.Delete(objList);
                    if (Deleted)
                    {
                        BUS = new ctChotDoanhThuGuiKeToanBUS();
                        dsData = BUS.List(IDDanhMucChungTu, txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucKhachHang.Value, cboIDDanhMucSale.Value);
                        ugChungTuChuaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
                        ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
                        ugChungTuChuaChotDoanhThu.DataSource = dsData.Tables[ctDonHang.tableName];
                        ugChungTuDaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
                        ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
                        ugChungTuDaChotDoanhThu.DataSource = dsData.Tables[ctChotDoanhThuGuiKeToan.tableName];
                        //
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.Default; //Biểu tượng lọc đặt trên tiêu đề cột
                        ugChungTuDaChotDoanhThu.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.Default; //Biểu tượng lọc đặt trên tiêu đề cột
                                                                                                                                          //
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].DefaultCellValue = false;
                        //
                        ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
                        ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
                        ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                        ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["LuaChon"].DefaultCellValue = false;
                    }
                }
            }
            else
                coreCommon.coreCommon.ErrorMessageOkOnly("Không có đơn hàng cần hủy chốt doanh thu!");
        }
    }
}
