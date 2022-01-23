using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucTuyenVanTai : coreBase.BaseForms.frmBaseDanhMucChiTiet
    {
        DanhMucTuyenVanTaiBUS BUS;
        public object IDDanhMucLoaiDoiTuong = null;
        public string TenDanhMucLoaiDoiTuong = "";
        //
        BindingSource bsDinhMucChiPhi = null;

        public frmDanhMucTuyenVanTai()
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
            BUS = new DanhMucTuyenVanTaiBUS();
            dsData = BUS.List(null, IDDanhMucLoaiDoiTuong, null);
            //
            bsDanhMuc = new BindingSource();
            bsDanhMuc.DataSource = dsData;
            bsDanhMuc.DataMember = DanhMucTuyenVanTai.tableName;
            bsDanhMucChiTiet = new BindingSource();
            bsDanhMucChiTiet.DataSource = bsDanhMuc;
            bsDanhMucChiTiet.DataMember = coreCommon.GlobalVariables.prefix_DataRelation + DanhMucTuyenVanTaiDinhMucNhienLieu.tableName;
            bsDinhMucChiPhi = new BindingSource();
            bsDinhMucChiPhi.DataSource = bsDanhMuc;
            bsDinhMucChiPhi.DataMember = coreCommon.GlobalVariables.prefix_DataRelation + DanhMucTuyenVanTaiDinhMucChiPhi.tableName;
            //
            ug.FixedColumnsList = "[Ma][Ten]";
            ug.DataSource = bsDanhMuc;
            ugChiTiet.HiddenColumnsList = "[MaDanhMucTuyenVanTai][TenDanhMucTuyenVanTai]";
            ugChiTiet.DataSource = bsDanhMucChiTiet;
            ugDinhMucChiPhi.HiddenColumnsList = "[MaDanhMucTuyenVanTai][TenDanhMucTuyenVanTai]";
            ugDinhMucChiPhi.DataSource = bsDinhMucChiPhi;
            //
            tabChiTiet.Tabs["tabChiTiet"].Text = "Chi tiết định mức nhiên liệu";
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
            frmDanhMucTuyenVanTaiUpdate frmUpdate = new frmDanhMucTuyenVanTaiUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dsData.Tables[DanhMucTuyenVanTai.tableName],
                IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        void InsertDanhMucChiTietNhienLieu()
        {
            if (ug.ActiveRow == null || ug.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucNhienLieu)), out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                return;
            }
            base.InsertDanhMucChiTiet();
            if (!bContinue) return;
            frmDanhMucTuyenVanTaiDinhMucNhienLieuUpdate frmUpdate = new frmDanhMucTuyenVanTaiDinhMucNhienLieuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dsData.Tables[DanhMucTuyenVanTaiDinhMucNhienLieu.tableName],
                IDDanhMucTuyenVanTai = ((DataRowView)bsDanhMuc.Current).Row["ID"],
                IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucNhienLieu)),
                TenDanhMucLoaiDoiTuong = "Danh mục định mức nhiên liệu"
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        void InsertDanhMucChiTietChiPhi()
        {
            if (ug.ActiveRow == null || ug.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucChiPhi)), out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                return;
            }
            base.InsertDanhMucChiTiet();
            if (!bContinue) return;
            frmDanhMucTuyenVanTaiDinhMucChiPhiUpdate frmUpdate = new frmDanhMucTuyenVanTaiDinhMucChiPhiUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dsData.Tables[DanhMucTuyenVanTaiDinhMucChiPhi.tableName],
                IDDanhMucTuyenVanTai = ((DataRowView)bsDanhMuc.Current).Row["ID"],
                IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucChiPhi)),
                TenDanhMucLoaiDoiTuong = "Danh mục định mức nhiên liệu"
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
            frmDanhMucTuyenVanTaiUpdate frmUpdate = new frmDanhMucTuyenVanTaiUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                dataTable = dsData.Tables[DanhMucTuyenVanTai.tableName],
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
            frmDanhMucTuyenVanTaiUpdate frmUpdate = new frmDanhMucTuyenVanTaiUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataTable = dsData.Tables[DanhMucTuyenVanTai.tableName],
                dataRow = ((DataRowView)bsDanhMuc.Current).Row,
                IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        void UpdateDanhMucChiTietNhienLieu()
        {
            if (ugChiTiet.ActiveRow == null || ugChiTiet.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucNhienLieu)), out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Sua)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền sửa dữ liệu danh mục này!");
                return;
            }
            bContinue = (bsDanhMucChiTiet != null && bsDanhMucChiTiet.Current != null && ugChiTiet.ActiveRow != null);
            if (!bContinue) return;
            frmDanhMucTuyenVanTaiDinhMucNhienLieuUpdate frmUpdate = new frmDanhMucTuyenVanTaiDinhMucNhienLieuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataTable = dsData.Tables[DanhMucTuyenVanTaiDinhMucNhienLieu.tableName],
                dataRow = ((DataRowView)bsDanhMucChiTiet.Current).Row,
                IDDanhMucTuyenVanTai = ((DataRowView)bsDanhMuc.Current).Row["ID"],
                IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucNhienLieu)),
                TenDanhMucLoaiDoiTuong = "Danh mục định mức nhiên liệu"
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        void UpdateDanhMucChiTietChiPhi()
        {
            if (ugDinhMucChiPhi.ActiveRow == null || ugDinhMucChiPhi.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucChiPhi)), out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Sua)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền sửa dữ liệu danh mục này!");
                return;
            }
            bContinue = (bsDinhMucChiPhi != null && bsDinhMucChiPhi.Current != null && ugDinhMucChiPhi.ActiveRow != null);
            if (!bContinue) return;
            frmDanhMucTuyenVanTaiDinhMucChiPhiUpdate frmUpdate = new frmDanhMucTuyenVanTaiDinhMucChiPhiUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataTable = dsData.Tables[DanhMucTuyenVanTaiDinhMucChiPhi.tableName],
                dataRow = ((DataRowView)bsDinhMucChiPhi.Current).Row,
                IDDanhMucTuyenVanTai = ((DataRowView)bsDanhMuc.Current).Row["ID"],
                IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucChiPhi)),
                TenDanhMucLoaiDoiTuong = "Danh mục định mức chi phí"
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
            DanhMucTuyenVanTai obj = new DanhMucTuyenVanTai()
            {
                ID = dataRow["ID"]
            };
            DanhMucTuyenVanTaiBUS bus = new DanhMucTuyenVanTaiBUS();
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
        void DeleteDanhMucChiTietNhienLieu()
        {
            if (ugChiTiet.ActiveRow == null || ugChiTiet.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucNhienLieu)), out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu danh mục này!");
                return;
            }
            bContinue = (bsDanhMucChiTiet != null && bsDanhMucChiTiet.Current != null && ugChiTiet.ActiveRow != null && coreCommon.coreCommon.QuestionMessage("Bạn có chắc chắn muốn xóa mục dữ liệu này?", 0) != DialogResult.No);
            if (!bContinue) return;
            DataRow dataRow = ((DataRowView)bsDanhMucChiTiet.Current).Row;
            DanhMucTuyenVanTaiDinhMucNhienLieu obj = new DanhMucTuyenVanTaiDinhMucNhienLieu()
            {
                ID = dataRow["ID"]
            };
            DanhMucTuyenVanTaiDinhMucNhienLieuBUS bus = new DanhMucTuyenVanTaiDinhMucNhienLieuBUS();
            if (bus.Delete(obj))
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
        void DeleteDanhMucChiTietChiPhi()
        {
            if (ugDinhMucChiPhi.ActiveRow == null || ugDinhMucChiPhi.ActiveRow.IsFilterRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucChiPhi)), out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu danh mục này!");
                return;
            }
            bContinue = (bsDinhMucChiPhi != null && bsDinhMucChiPhi.Current != null && ugDinhMucChiPhi.ActiveRow != null && coreCommon.coreCommon.QuestionMessage("Bạn có chắc chắn muốn xóa mục dữ liệu này?", 0) != DialogResult.No);
            if (!bContinue) return;
            DataRow dataRow = ((DataRowView)bsDinhMucChiPhi.Current).Row;
            DanhMucTuyenVanTaiDinhMucChiPhi obj = new DanhMucTuyenVanTaiDinhMucChiPhi()
            {
                ID = dataRow["ID"]
            };
            DanhMucTuyenVanTaiDinhMucChiPhiBUS bus = new DanhMucTuyenVanTaiDinhMucChiPhiBUS();
            if (bus.Delete(obj))
            {
                if (ugDinhMucChiPhi.ActiveRow == null) return;
                int i = ugDinhMucChiPhi.ActiveRow.Index;
                bsDinhMucChiPhi.RemoveCurrent();
                if (i > 0) i -= 1;
                if (i <= ugDinhMucChiPhi.Rows.Count - 1)
                {
                    ugDinhMucChiPhi.Focus();
                    ugDinhMucChiPhi.Rows[i].Activate();
                }
            }
        }
        protected override void InsertDanhMucChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    InsertDanhMucChiTietNhienLieu();
                    break;
                case "TABCHITIETDINHMUCCHIPHI":
                    InsertDanhMucChiTietChiPhi();
                    break;
            }
        }
        protected override void UpdateDanhMucChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    UpdateDanhMucChiTietNhienLieu();
                    break;
                case "TABCHITIETDINHMUCCHIPHI":
                    UpdateDanhMucChiTietChiPhi();
                    break;
            }
        }
        protected override void DeleteDanhMucChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    DeleteDanhMucChiTietNhienLieu();
                    break;
                case "TABCHITIETDINHMUCCHIPHI":
                    DeleteDanhMucChiTietChiPhi();
                    break;
            }
        }
    }
}
