using cenBUS.cenLogistics;
using cenDTO.cenLogistics;
using coreBUS;
using coreCommon;
using System.Data;
using System.Windows.Forms;
namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucKhachHang : coreBase.BaseForms.frmBaseDanhMucChiTiet
    {
        DanhMucKhachHangBUS BUS = new DanhMucKhachHangBUS();
        DanhMucKhachHangPhanCapBUS BUSPhanCap = new DanhMucKhachHangPhanCapBUS();
        public frmDanhMucKhachHang()
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
            BUS = new DanhMucKhachHangBUS();
            dsData = BUS.List(null, IDDanhMucLoaiDoiTuong, 0, null);

            bsDanhMuc = new BindingSource
            {
                DataSource = dsData,
                DataMember = DanhMucKhachHang.tableName
            };
            ug.FixedColumnsList = "[Ma][Ten]";
            ug.DataSource = bsDanhMuc;

            bsDanhMucChiTiet = new BindingSource
            {
                DataSource = bsDanhMuc,
                DataMember = coreCommon.GlobalVariables.prefix_DataRelation + DanhMucKhachHangPhanCap.tableName
            };
            ugChiTiet.HiddenColumnsList = "[MaDanhMucKhachHang][TenDanhMucKhachHang][DiaChiDanhMucKhachHang]";
            ugChiTiet.DataSource = bsDanhMucChiTiet;
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
            frmDanhMucKhachHangUpdate frmUpdate = new frmDanhMucKhachHangUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dsData.Tables[DanhMucKhachHang.tableName],
                IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong,
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
            frmDanhMucKhachHangUpdate frmUpdate = new frmDanhMucKhachHangUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                dataTable = dsData.Tables[DanhMucKhachHang.tableName],
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
            frmDanhMucKhachHangUpdate frmUpdate = new frmDanhMucKhachHangUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataTable = dsData.Tables[DanhMucKhachHang.tableName],
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
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu danh mục này!");
                return;
            }
            base.DeleteDanhMuc();
            if (!bContinue) return;
            DataRow dataRow = ((DataRowView)bsDanhMuc.Current).Row;
            DanhMucKhachHang obj = new DanhMucKhachHang()
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
        protected override void InsertDanhMucChiTiet()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHangPhanCap)), out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                return;
            }
            base.InsertDanhMucChiTiet();
            if (!bContinue) return;
            DataRow drKhachHang = ((DataRowView)bsDanhMuc.Current).Row;
            frmDanhMucKhachHangPhanCapUpdate frmUpdate = new frmDanhMucKhachHangPhanCapUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dsData.Tables[DanhMucKhachHangPhanCap.tableName],
                IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHangPhanCap)),
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong,
                IDDanhMucKhachHang = drKhachHang["ID"],
                MaDanhMucKhachHang = drKhachHang["Ma"],
                TenDanhMucKhachHang = drKhachHang["Ten"],
                DiaChiDanhMucKhachHang = drKhachHang["DiaChi"],
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void UpdateDanhMucChiTiet()
        {
            if (ugChiTiet.ActiveRow == null || ugChiTiet.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHangPhanCap)), out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Sua)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền sửa dữ liệu danh mục này!");
                return;
            }
            base.UpdateDanhMucChiTiet();
            if (!bContinue) return;
            DataRow drKhachHang = ((DataRowView)bsDanhMuc.Current).Row;
            frmDanhMucKhachHangPhanCapUpdate frmUpdate = new frmDanhMucKhachHangPhanCapUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataTable = dsData.Tables[DanhMucKhachHangPhanCap.tableName],
                dataRow = ((DataRowView)bsDanhMucChiTiet.Current).Row,
                IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHangPhanCap)),
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong,
                IDDanhMucKhachHang = drKhachHang["ID"],
                MaDanhMucKhachHang = drKhachHang["Ma"],
                TenDanhMucKhachHang = drKhachHang["Ten"],
                DiaChiDanhMucKhachHang = drKhachHang["DiaChi"],
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMucChiTiet()
        {
            if (ugChiTiet.ActiveRow == null || ugChiTiet.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHangPhanCap)), out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu danh mục này!");
                return;
            }
            base.DeleteDanhMucChiTiet();
            if (!bContinue) return;
            DataRow dataRow = ((DataRowView)bsDanhMucChiTiet.Current).Row;
            DanhMucKhachHangPhanCap obj = new DanhMucKhachHangPhanCap()
            {
                ID = dataRow["ID"]
            };
            if (BUSPhanCap.Delete(obj))
            {
                if (ugChiTiet.ActiveRow == null) return;
                int i = ugChiTiet.ActiveRow.Index;
                bsDanhMucChiTiet.RemoveCurrent();
                if (i > 0) i -= 1;
                if (i <= ugChiTiet.Rows.Count - 1)
                {
                    ugChiTiet.Focus();
                    ugChiTiet.Rows[i].Activate();
                }
            }
        }

    }
}
