using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Windows.Forms;
namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucNhanSu : coreBase.BaseForms.frmBaseDanhMuc
    {
        DanhMucNhanSuBUS BUS = new DanhMucNhanSuBUS();
        public frmDanhMucNhanSu()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xem)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xem dữ liệu danh mục này!");
                return;
            }
            BUS = new DanhMucNhanSuBUS();
            dtData = BUS.List(DBNull.Value, IDDanhMucLoaiDoiTuong, null);
            dtData.TableName = DanhMucNhanSu.tableName;
            bsDanhMuc = new BindingSource
            {
                DataSource = dtData
            };
            ug.FixedColumnsList = "[Ma][Ten]";
            ug.HiddenColumnsList = "[MaDanhMucPhongBan][MaDanhMucPhanLoaiChucVu][MaDanhMucTinhTrangLamViec]";
            ug.DataSource = bsDanhMuc;
        }
        protected override void InsertDanhMuc()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                return;
            }
            base.InsertDanhMuc();
            if (!bContinue) return;
            frmDanhMucNhanSuUpdate frmUpdate = new frmDanhMucNhanSuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dtData,
                IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void CopyDanhMuc()
        {
            if (ug.ActiveRow == null || ug.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                return;
            }
            base.CopyDanhMuc();
            if (!bContinue) return;
            frmDanhMucNhanSuUpdate frmUpdate = new frmDanhMucNhanSuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                dataTable = dtData,
                dataRow = ((DataRowView)bsDanhMuc.Current).Row,
                IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void UpdateDanhMuc()
        {
            if (ug.ActiveRow == null || ug.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Sua)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền sửa dữ liệu danh mục này!");
                return;
            }
            base.UpdateDanhMuc();
            if (!bContinue) return;
            frmDanhMucNhanSuUpdate frmUpdate = new frmDanhMucNhanSuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataTable = dtData,
                dataRow = ((DataRowView)bsDanhMuc.Current).Row,
                IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMuc()
        {
            if (ug.ActiveRow == null || ug.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu danh mục này!");
                return;
            }
            base.DeleteDanhMuc();
            if (!bContinue) return;
            DataRow dataRow = ((DataRowView)bsDanhMuc.Current).Row;
            DanhMucNhanSu obj = new DanhMucNhanSu()
            {
                ID = dataRow["ID"]
            };
            if (BUS.Delete(obj))
            {
                if (ug.ActiveRow == null) return;
                int i = ug.ActiveRow.Index;
                bsDanhMuc.RemoveCurrent();
                if (i > 0) i -= 1;
                if (i <= ug.Rows.Count - 1)
                {
                    ug.Focus();
                    ug.Rows[i].Activate();
                }
            }
        }
    }
}
