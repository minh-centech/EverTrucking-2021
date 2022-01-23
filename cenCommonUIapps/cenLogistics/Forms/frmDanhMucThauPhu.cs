using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System.Data;
using System.Windows.Forms;
namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucThauPhu : coreBase.BaseForms.frmBaseDanhMuc
    {
        DanhMucThauPhuBUS BUS = new DanhMucThauPhuBUS();
        long countID = 0;
        public frmDanhMucThauPhu()
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
            BUS = new DanhMucThauPhuBUS();
            dtData = BUS.List(null, IDDanhMucLoaiDoiTuong, null, null);

            //dtData = BUS.ListPaging(IDDanhMucLoaiDoiTuong, 0);

            dtData.TableName = DanhMucThauPhu.tableName;
            bsDanhMuc = new BindingSource
            {
                DataSource = dtData
            };
            ug.FixedColumnsList = "[Ma][Ten]";
            ug.HiddenColumnsList = "[MaDanhMucPhongBan][MaDanhMucPhanLoaiChucVu][MaDanhMucTinhTrangLamViec]";
            ug.DataSource = bsDanhMuc;


            //Loaded = false;
            //ug.DisplayLayout.PerformAutoResizeColumns(false, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.IncludeCells);
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
            frmDanhMucThauPhuUpdate frmUpdate = new frmDanhMucThauPhuUpdate
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
            frmDanhMucThauPhuUpdate frmUpdate = new frmDanhMucThauPhuUpdate
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
            frmDanhMucThauPhuUpdate frmUpdate = new frmDanhMucThauPhuUpdate
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
            DanhMucThauPhu obj = new DanhMucThauPhu()
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

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    for (long i = 0; i <= countID / coreCommon.GlobalVariables.RecordPerPage + 1; i++)
        //    //for (long i = 1; i <= 1; i++)
        //    {
        //        DanhMucThauPhuBUS BUS1 = new DanhMucThauPhuBUS();
        //        DataTable dtData = BUS1.ListPaging(IDDanhMucLoaiDoiTuong, i);
        //        dtData.TableName = DanhMucThauPhu.tableName;
        //        backgroundWorker1.ReportProgress((int)(i / countID * 100), dtData);
        //    }
        //}

        //private void frmDanhMucThauPhu_Load(object sender, EventArgs e)
        //{
        //    //backgroundWorker1.RunWorkerAsync();
        //}

        //private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    dtData.Merge((DataTable)e.UserState);
        //}

        //private void frmDanhMucThauPhu_Activated(object sender, EventArgs e)
        //{
        //    if (!Loaded)
        //    {
        //        backgroundWorker1.RunWorkerAsync();
        //        Loaded = true;
        //    }    
        //}
    }
}
