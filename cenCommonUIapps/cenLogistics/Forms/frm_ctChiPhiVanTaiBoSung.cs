using cenBUS.cenLogistics;
using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctChiPhiVanTaiBoSung : coreBase.BaseForms.frmBaseChungTuSingleList
    {
        public frm_ctChiPhiVanTaiBoSung()
        {
            InitializeComponent();
            UltraToolbarsManager1.Tools["btThem"].SharedProps.Enabled = false;
            UltraToolbarsManager1.Tools["btThem"].SharedProps.Visible = false;
            UltraToolbarsManager1.Tools["btCopy"].SharedProps.Enabled = false;
            UltraToolbarsManager1.Tools["btCopy"].SharedProps.Visible = false;
            UltraToolbarsManager1.Tools["btSua"].SharedProps.Caption = "Cập nhật chi phí bổ sung (CTRL+E)";
            UltraToolbarsManager1.Tools["btXoa"].SharedProps.Enabled = false;
            UltraToolbarsManager1.Tools["btXoa"].SharedProps.Visible = false;
            txtDenNgay.DateTime = DateTime.Now;
            txtTuNgay.DateTime = DateTime.Now;
        }
        protected override void List()
        {
            ////NhomHangVanChuyen
            //DanhMucDoiTuongBUS NhomHangVanChuyenBUS = new DanhMucDoiTuongBUS();
            //DataTable dtNhomHangVanChuyen = NhomHangVanChuyenBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen)), null);
            //cboIDDanhMucNhomHangVanChuyen.dtValid = dtNhomHangVanChuyen;
            //cboIDDanhMucNhomHangVanChuyen.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen));
            //cboIDDanhMucNhomHangVanChuyen.procedureName = DanhMucDoiTuong.listProcedureName;
            //cboIDDanhMucNhomHangVanChuyen.DataSource = dtNhomHangVanChuyen;
            //cboIDDanhMucNhomHangVanChuyen.ValueMember = "ID";
            //cboIDDanhMucNhomHangVanChuyen.DisplayMember = "Ten";
            //
            ctChiPhiVanTaiBoSungBUS bus = new ctChiPhiVanTaiBoSungBUS();
            dtData = bus.ListDisplay(IDDanhMucChungTu, txtTuNgay.Value, txtDenNgay.Value, null, cboIDDanhMucNhomHangVanChuyen.Value);
            bsData = new BindingSource();
            bsData.DataSource = dtData;
            ug.HiddenColumnsList = "[NgayLap]";
            ug.FixedColumnsList = "[So][NgayDongTraHang][DebitNote]";
            ug.DataSource = bsData;
        }
        protected override void UpdateDanhMuc()
        {
            if (ug.ActiveRow == null || ug.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Sua)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền sửa dữ liệu chứng từ này!");
                return;
            }
            if (bsData.Current == null) return;

            DataRow dr = ((DataRowView)bsData.Current).Row;

            frm_ctChiPhiVanTaiBoSungUpdate frmUpdate = new frm_ctChiPhiVanTaiBoSungUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Sua,
                Text = cenCommon.LoaiManHinh.NameChiPhiVanTaiBoSung,
                IDChungTu = dr["ID"],
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh
            };
            frmUpdate.ShowDialog();
            if (!coreCommon.coreCommon.IsNull(frmUpdate.IDChungTu))
            {
                ctChiPhiVanTaiBoSungBUS bus = new ctChiPhiVanTaiBoSungBUS();
                DataTable dtChungTuUpdate = bus.ListDisplay(IDDanhMucChungTu, null, null, frmUpdate.IDChungTu, null);
                dr.ItemArray = dtChungTuUpdate.Rows[0].ItemArray;
            }
            frmUpdate.Dispose();
        }

        private void ug_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if (!coreCommon.coreCommon.IsNull(e.Row.Cells["MaDanhMucChuXe"].Value) && e.Row.Cells["MaDanhMucChuXe"].Value.ToString().ToUpper().StartsWith("PLJ") && e.Row.Cells["TrangThaiDonHang"].Value.ToString() == "Đơn")
            {
                e.Row.Appearance.BackColor = System.Drawing.Color.FromArgb(206, 231, 255);
            }
            if (!coreCommon.coreCommon.IsNull(e.Row.Cells["MaDanhMucChuXe"].Value) && e.Row.Cells["MaDanhMucChuXe"].Value.ToString().ToUpper().StartsWith("PLJ") && e.Row.Cells["TrangThaiDonHang"].Value.ToString() == "Kết hợp")
            {
                e.Row.Appearance.BackColor = System.Drawing.Color.FromArgb(131, 192, 255);
            }
            if (!coreCommon.coreCommon.IsNull(e.Row.Cells["MaDanhMucChuXe"].Value) && !e.Row.Cells["MaDanhMucChuXe"].Value.ToString().ToUpper().StartsWith("PLJ") && e.Row.Cells["TrangThaiDonHang"].Value.ToString() == "Kết hợp")
            {
                e.Row.Appearance.BackColor = System.Drawing.Color.FromArgb(202, 237, 97);
            }
        }
    }
}
