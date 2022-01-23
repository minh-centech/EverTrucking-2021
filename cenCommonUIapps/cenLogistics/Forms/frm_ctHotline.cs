using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctHotline : coreBase.BaseForms.frmBaseChungTuSingleList
    {
        public frm_ctHotline()
        {
            InitializeComponent();
            UltraToolbarsManager1.Tools["btThem"].SharedProps.Enabled = false;
            UltraToolbarsManager1.Tools["btThem"].SharedProps.Visible = false;
            UltraToolbarsManager1.Tools["btCopy"].SharedProps.Enabled = false;
            UltraToolbarsManager1.Tools["btCopy"].SharedProps.Visible = false;
            UltraToolbarsManager1.Tools["btSua"].SharedProps.Caption = "Cập nhật (CTRL+E)";
            UltraToolbarsManager1.Tools["btXoa"].SharedProps.Caption = "Xóa (CTRL+D)";
            txtTuNgay.Value = DateTime.Now;
            txtDenNgay.Value = DateTime.Now;
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
            ctHotlineBUS bus = new ctHotlineBUS();
            dtData = bus.ListDisplay(IDDanhMucChungTu, null, txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucNhomHangVanChuyen.Value);
            bsData = new BindingSource();
            bsData.DataSource = dtData;
            ug.FixedColumnsList = "[So][DebitNote]";
            ug.DataSource = bsData;
        }

        protected override void InsertDanhMuc()
        {
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

            frm_ctHotlineUpdate frmUpdate = new frm_ctHotlineUpdate
            {
                UpdateMode = (coreCommon.coreCommon.IsNull(dr["IDctHotline"])) ? coreCommon.ThaoTacDuLieu.Them : coreCommon.ThaoTacDuLieu.Sua,
                Text = cenCommon.LoaiManHinh.NameHotline,
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh,
                dataTable = dtData,
                dataRow = dr,
                IDctDonHang = dr["ID"]
            };
            frmUpdate.ShowDialog();
            if (!coreCommon.coreCommon.IsNull(frmUpdate.ID))
            {
                ctHotlineBUS BUS = new ctHotlineBUS();
                DataRow drChungTuUpdate = BUS.ListDisplay(IDDanhMucChungTu, dr["ID"], txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucNhomHangVanChuyen.Value).Rows[0];
                dr.ItemArray = drChungTuUpdate.ItemArray;
            }
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMuc()
        {
            if (ug.ActiveRow == null || ug.ActiveRow.IsFilterRow) return;
            if (bsData.Current == null) return;
            DataRow dr = ((DataRowView)bsData.Current).Row;
            if (coreCommon.coreCommon.IsNull(dr["IDctHotline"])) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu chứng từ này!");
                return;
            }
            if (!coreCommon.coreCommon.IsNull(ctDonHangBUS.GetIDctChotDoanhThuGuiKeToan(dr["ID"]))) { coreCommon.coreCommon.ErrorMessageOkOnly("Đơn hàng đã chốt doanh thu, không xóa thông tin hotline!"); return; }
            base.DeleteDanhMuc();
            if (!bContinue) return;
            ctHotlineBUS BUS = new ctHotlineBUS();
            if (BUS.Delete(new ctHotline() { ID = dr["IDctHotline"] }))
            {
                dr["DienThoai"] = DBNull.Value;
                dr["ThongTinThuTuc"] = DBNull.Value;
                dr["GhiChuHotline"] = DBNull.Value;
                dr["TinhTrangHotline"] = DBNull.Value;
                dr["TrangThaiHotline"] = DBNull.Value;
                dtData.AcceptChanges();
            }
        }
        protected void In()
        {
        }
    }
}
