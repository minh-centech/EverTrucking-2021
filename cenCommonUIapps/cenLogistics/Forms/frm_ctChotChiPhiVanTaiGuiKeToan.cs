using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using coreDTO;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctChotChiPhiVanTaiGuiKeToan : Form
    {
        public object IDDanhMucChungTu = null;
        ctChotChiPhiVanTaiGuiKeToanBUS BUS = null;
        DataSet dsData = null;
        public frm_ctChotChiPhiVanTaiGuiKeToan()
        {
            InitializeComponent();
            txtTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtDenNgay.DateTime = txtTuNgay.DateTime.AddMonths(1).AddDays(-1);
        }
        private void List()
        {
            ////Nhóm hàng vận chuyển
            //DanhMucDoiTuongBUS DanhMucNhomHangVanChuyenBUS = new DanhMucDoiTuongBUS();
            //DataTable dtNhomHangVanChuyen = DanhMucNhomHangVanChuyenBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen)), null);
            //cboIDDanhMucNhomHangVanChuyen.dtValid = dtNhomHangVanChuyen;
            //cboIDDanhMucNhomHangVanChuyen.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen));
            //cboIDDanhMucNhomHangVanChuyen.procedureName = DanhMucDoiTuong.listProcedureName;
            //cboIDDanhMucNhomHangVanChuyen.DataSource = dtNhomHangVanChuyen;
            //cboIDDanhMucNhomHangVanChuyen.ValueMember = "ID";
            //cboIDDanhMucNhomHangVanChuyen.DisplayMember = "Ten";
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
            BUS = new ctChotChiPhiVanTaiGuiKeToanBUS();
            dsData = BUS.List(IDDanhMucChungTu, txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucNhomHangVanChuyen.Value, cboIDDanhMucSale.Value);
            ugChungTuChuaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
            ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
            ugChungTuChuaChotDoanhThu.DataSource = dsData.Tables[ctDonHang.tableName];
            ugChungTuDaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
            ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
            ugChungTuDaChotDoanhThu.DataSource = dsData.Tables[ctChotChiPhiVanTaiGuiKeToan.tableName];
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
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoLuongNhienLieu", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoLuongNhienLieu"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoLuongNhienLieu"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoLuongNhienLieu"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoLuongNhienLieu"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoLuongNhienLieu"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienVeCauDuong", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienVeCauDuong"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienVeCauDuong"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienVeCauDuong"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienVeCauDuong"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienVeCauDuong"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienLuatAnCa", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienLuatAnCa"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatAnCa"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatAnCa"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatAnCa"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatAnCa"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienKetHopVeCauDuongLuatAnCa", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienKetHopVeCauDuongLuatAnCa"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienKetHopVeCauDuongLuatAnCa"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienKetHopVeCauDuongLuatAnCa"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienKetHopVeCauDuongLuatAnCa"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienKetHopVeCauDuongLuatAnCa"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienLuuCaKhac", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienLuuCaKhac"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuuCaKhac"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuuCaKhac"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuuCaKhac"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuuCaKhac"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienLuatDuongCam", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienLuatDuongCam"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatDuongCam"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatDuongCam"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatDuongCam"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatDuongCam"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienTongLuuCaKhacLuatDuongCam", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienTongLuuCaKhacLuatDuongCam"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTongLuuCaKhacLuatDuongCam"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTongLuuCaKhacLuatDuongCam"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTongLuuCaKhacLuatDuongCam"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTongLuuCaKhacLuatDuongCam"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienLuongChuyen", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienLuongChuyen"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuyen"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuyen"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuyen"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuyen"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienLuongChuNhat", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienLuongChuNhat"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuNhat"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuNhat"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuNhat"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuNhat"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienCuocThueXeNgoai", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienCuocThueXeNgoai"]);
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuocThueXeNgoai"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuocThueXeNgoai"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuocThueXeNgoai"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuChuaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuocThueXeNgoai"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
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
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoLuongNhienLieu", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoLuongNhienLieu"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoLuongNhienLieu"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoLuongNhienLieu"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoLuongNhienLieu"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoLuongNhienLieu"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienVeCauDuong", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienVeCauDuong"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienVeCauDuong"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienVeCauDuong"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienVeCauDuong"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienVeCauDuong"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienLuatAnCa", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienLuatAnCa"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatAnCa"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatAnCa"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatAnCa"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatAnCa"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienKetHopVeCauDuongLuatAnCa", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienKetHopVeCauDuongLuatAnCa"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienKetHopVeCauDuongLuatAnCa"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienKetHopVeCauDuongLuatAnCa"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienKetHopVeCauDuongLuatAnCa"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienKetHopVeCauDuongLuatAnCa"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienLuuCaKhac", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienLuuCaKhac"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuuCaKhac"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuuCaKhac"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuuCaKhac"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuuCaKhac"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienLuatDuongCam", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienLuatDuongCam"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatDuongCam"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatDuongCam"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatDuongCam"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuatDuongCam"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienTongLuuCaKhacLuatDuongCam", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienTongLuuCaKhacLuatDuongCam"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTongLuuCaKhacLuatDuongCam"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTongLuuCaKhacLuatDuongCam"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTongLuuCaKhacLuatDuongCam"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienTongLuuCaKhacLuatDuongCam"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienLuongChuyen", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienLuongChuyen"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuyen"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuyen"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuyen"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuyen"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienLuongChuNhat", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienLuongChuNhat"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuNhat"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuNhat"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuNhat"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienLuongChuNhat"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries.Add("SoTienCuocThueXeNgoai", Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Columns["SoTienCuocThueXeNgoai"]);
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuocThueXeNgoai"].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuocThueXeNgoai"].SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuocThueXeNgoai"].SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
            ugChungTuDaChotDoanhThu.DisplayLayout.Bands[0].Summaries["SoTienCuocThueXeNgoai"].DisplayFormat = "{0:" + coreCommon.GlobalVariables.FormatInteger + ";(" + coreCommon.GlobalVariables.FormatInteger + ");-;-}";
        }

        private void frm_ctChotChiPhiVanTaiGuiKeToan_Load(object sender, EventArgs e)
        {
            tabDaChot.Height = (this.Height - groupFilter.Height - cmdChot.Height - cmdHuyChot.Height) / 2;
            //tabChuaChot.Height = (this.Height - groupFilter.Height - cmdChot.Height - cmdHuyChot.Height) / 2;
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
            List<ctChotChiPhiVanTaiGuiKeToan> objList = new List<ctChotChiPhiVanTaiGuiKeToan>();
            foreach (DataRow dr in dsData.Tables[ctDonHang.tableName].Rows)
            {
                if (!coreCommon.coreCommon.IsNull(dr["LuaChon"]) && dr["LuaChon"].ToString() == "True")
                {
                    objList.Add(new ctChotChiPhiVanTaiGuiKeToan
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
                if (coreCommon.coreCommon.QuestionMessage("Xác nhận chốt chi phí vận tải những đơn hàng đã chọn?", 0) == DialogResult.Yes)
                {
                    Boolean Saved = BUS.Insert(objList);
                    if (Saved)
                    {
                        BUS = new ctChotChiPhiVanTaiGuiKeToanBUS();
                        dsData = BUS.List(IDDanhMucChungTu, txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucNhomHangVanChuyen.Value, cboIDDanhMucSale.Value);
                        ugChungTuChuaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
                        ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
                        ugChungTuChuaChotDoanhThu.DataSource = dsData.Tables[ctDonHang.tableName];
                        ugChungTuDaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
                        ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
                        ugChungTuDaChotDoanhThu.DataSource = dsData.Tables[ctChotChiPhiVanTaiGuiKeToan.tableName];
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
                coreCommon.coreCommon.ErrorMessageOkOnly("Không có đơn hàng cần chốt chi phí vận tải!");
        }

        private void cmdHuyChot_Click(object sender, EventArgs e)
        {
            //Hủy Chốt doanh thu
            List<ctChotChiPhiVanTaiGuiKeToan> objList = new List<ctChotChiPhiVanTaiGuiKeToan>();
            foreach (DataRow dr in dsData.Tables[ctChotChiPhiVanTaiGuiKeToan.tableName].Rows)
            {
                if (!coreCommon.coreCommon.IsNull(dr["LuaChon"]) && dr["LuaChon"].ToString() == "True")
                {
                    objList.Add(new ctChotChiPhiVanTaiGuiKeToan
                    {
                        IDDanhMucChungTu = IDDanhMucChungTu,
                        ID = dr["IDctChotChiPhiVanTaiGuiKeToan"],
                        IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung
                    }
                    );
                }
            }
            if (objList.Count > 0)
            {
                if (coreCommon.coreCommon.QuestionMessage("Xác nhận hủy chốt chi phí vận tải những đơn hàng đã chọn?", 0) == DialogResult.Yes)
                {
                    Boolean Deleted = BUS.Delete(objList);
                    if (Deleted)
                    {
                        BUS = new ctChotChiPhiVanTaiGuiKeToanBUS();
                        dsData = BUS.List(IDDanhMucChungTu, txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucNhomHangVanChuyen.Value, cboIDDanhMucSale.Value);
                        ugChungTuChuaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
                        ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
                        ugChungTuChuaChotDoanhThu.DataSource = dsData.Tables[ctDonHang.tableName];
                        ugChungTuDaChotDoanhThu.FixedColumnsList = "[LuaChon][So][NgayDongTraHang]";
                        ugChungTuChuaChotDoanhThu.HiddenColumnsList = "[NgayLap]";
                        ugChungTuDaChotDoanhThu.DataSource = dsData.Tables[ctChotChiPhiVanTaiGuiKeToan.tableName];
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
                coreCommon.coreCommon.ErrorMessageOkOnly("Không có đơn hàng cần hủy chốt chi phí vận tải!");
        }
    }
}
