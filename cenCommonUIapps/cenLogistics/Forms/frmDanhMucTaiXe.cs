using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucTaiXe : coreBase.BaseForms.frmBaseDanhMuc
    {
        DanhMucTaiXeBUS BUS;
        public frmDanhMucTaiXe()
        {
            InitializeComponent();
        }

        private void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key.ToString().ToUpper())
            {
                case "BTXOA":
                    DeleteDanhMuc();
                    break;
                case "BTTHEM":
                    InsertDanhMuc();
                    break;
                case "BTCOPY":
                    CopyDanhMuc();
                    break;
                case "BTSUA":
                    UpdateDanhMuc();
                    break;
                case "BTTAILAI":
                    List();
                    break;
                case "BTIN":
                    In();
                    break;
                case "BTEXCEL":
                    coreCommon.coreCommon.ExportGrid2Excel(ug);
                    break;
            }
        }


        protected override void List()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xem)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xem dữ liệu danh mục này!");
                return;
            }
            BUS = new DanhMucTaiXeBUS();
            dtData = BUS.List(null, IDDanhMucLoaiDoiTuong, null, null);
            bsDanhMuc = new BindingSource();
            bsDanhMuc.DataSource = dtData;
            ug.FixedColumnsList = "[Ma][Ten]";
            ug.DataSource = bsDanhMuc;
        }
        protected virtual void In()
        {
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
            frmDanhMucTaiXeUpdate frmUpdate = new frmDanhMucTaiXeUpdate
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
            frmDanhMucTaiXeUpdate frmUpdate = new frmDanhMucTaiXeUpdate
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
            frmDanhMucTaiXeUpdate frmUpdate = new frmDanhMucTaiXeUpdate
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
            bContinue = (bsDanhMuc != null && bsDanhMuc.Current != null && ug.ActiveRow != null && coreCommon.coreCommon.QuestionMessage("Bạn có chắc chắn muốn xóa mục dữ liệu này?", 0) != DialogResult.No);
            if (!bContinue) return;
            DataRow dataRow = ((DataRowView)bsDanhMuc.Current).Row;
            DanhMucTaiXe obj = new DanhMucTaiXe()
            {
                ID = dataRow["ID"]
            };
            DanhMucTaiXeBUS bus = new DanhMucTaiXeBUS();
            if (bus.Delete(obj))
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
