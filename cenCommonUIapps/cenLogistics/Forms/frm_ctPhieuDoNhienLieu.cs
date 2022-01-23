using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctPhieuDoNhienLieu : coreBase.BaseForms.frmBaseChungTuSingleList
    {
        public frm_ctPhieuDoNhienLieu()
        {
            InitializeComponent();
            txtTuNgay.Value = DateTime.Now;
            txtDenNgay.Value = DateTime.Now;
        }
        protected override void List()
        {
            //
            ctPhieuDoNhienLieuBUS bus = new ctPhieuDoNhienLieuBUS();
            dtData = bus.ListDisplay(IDDanhMucChungTu, null, txtTuNgay.Value, txtDenNgay.Value);
            bsData = new BindingSource();
            bsData.DataSource = dtData;
            ug.FixedColumnsList = "[So][NgayLap][NgayDoNhienLieu]";
            ug.DataSource = bsData;
        }

        protected override void InsertDanhMuc()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm dữ liệu chứng từ này!");
                return;
            }

            frm_ctPhieuDoNhienLieuUpdate frmUpdate = new frm_ctPhieuDoNhienLieuUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Them,
                Text = cenCommon.LoaiManHinh.NamePhieuDoNhienLieu,
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh
            };
            frmUpdate.ShowDialog();
            if (!coreCommon.coreCommon.IsNull(frmUpdate.ID))
            {
                ctPhieuDoNhienLieuBUS BUS = new ctPhieuDoNhienLieuBUS();
                DataTable dtChungTuUpdate = BUS.ListDisplay(IDDanhMucChungTu, frmUpdate.ID, txtTuNgay.Value, txtDenNgay.Value);
                dtData.Merge(dtChungTuUpdate);
            }
            frmUpdate.Dispose();
        }


        protected override void UpdateDanhMuc()
        {
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Sua)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền sửa dữ liệu chứng từ này!");
                return;
            }
            if (bsData.Current == null) return;

            DataRow dr = ((DataRowView)bsData.Current).Row;

            frm_ctPhieuDoNhienLieuUpdate frmUpdate = new frm_ctPhieuDoNhienLieuUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Sua,
                Text = cenCommon.LoaiManHinh.NameDieuHanh,
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh,
                dataTable = dtData,
                dataRow = dr,
                ID = dr["ID"],
                IDctDonHang = dr["IDChungTu"]
            };
            frmUpdate.ShowDialog();
            if (!coreCommon.coreCommon.IsNull(frmUpdate.ID))
            {
                ctPhieuDoNhienLieuBUS BUS = new ctPhieuDoNhienLieuBUS();
                DataRow drChungTuUpdate = BUS.ListDisplay(IDDanhMucChungTu, frmUpdate.ID, txtTuNgay.Value, txtDenNgay.Value).Rows[0];
                dr.ItemArray = drChungTuUpdate.ItemArray;
            }
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMuc()
        {
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow) return;
            if (bsData.Current == null) return;
            DataRow dr = ((DataRowView)bsData.Current).Row;
            if (coreCommon.coreCommon.IsNull(dr["ID"])) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu chứng từ này!");
                return;
            }
            base.DeleteDanhMuc();
            if (!bContinue) return;
            ctPhieuDoNhienLieuBUS BUS = new ctPhieuDoNhienLieuBUS();
            if (BUS.Delete(new ctPhieuDoNhienLieu() { ID = dr["ID"] }))
            {
                bsData.RemoveCurrent();
            }
        }
        protected void In()
        {
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow) return;
            object IDChungTu = ug.ActiveRow.Cells["ID"].Value;
            //if (!coreCommon.coreCommon.IsNull(IDChungTu))
            //    cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu.ToString(), IDChungTu.ToString(), ctPhieuDoNhienLieu.tableName, null, this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"ctPhieuDoNhienLieu.rpt", ctPhieuDoNhienLieu.listProcedureName, "", 1, LoaiManHinh, 1);
        }
    }
}
