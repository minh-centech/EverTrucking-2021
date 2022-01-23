using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctSuaChua : coreBase.BaseForms.frmBaseChungTuSingleList
    {
        public frm_ctSuaChua()
        {
            InitializeComponent();
            txtTuNgay.DateTime = DateTime.Now;
            txtDenNgay.DateTime = DateTime.Now;
        }
        protected override void List()
        {
            ctSuaChuaBUS bus = new ctSuaChuaBUS();
            dtData = bus.List(DBNull.Value, IDDanhMucChungTu, txtTuNgay.Value, txtDenNgay.Value, null);
            bsData = new BindingSource();
            bsData.DataSource = dtData;
            ug.FixedColumnsList = "[So][NgayLap][BienSo][NgaySuaChua]";
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
            frm_ctSuaChuaUpdate frmUpdate = new frm_ctSuaChuaUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Them,
                Text = cenCommon.LoaiManHinh.NameSuaChua,
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh,
                dataTable = dtData
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
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

            frm_ctSuaChuaUpdate frmUpdate = new frm_ctSuaChuaUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Sua,
                Text = cenCommon.LoaiManHinh.NameSuaChua,
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh,
                dataTable = dtData,
                dataRow = dr,
                ID = dr["ID"]
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMuc()
        {
            if (ug.ActiveRow == null || ug.ActiveRow.IsFilterRow) return;
            if (bsData.Current == null) return;
            DataRow dr = ((DataRowView)bsData.Current).Row;

            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu chứng từ này!");
                return;
            }
            base.DeleteDanhMuc();
            if (!bContinue) return;
            ctSuaChuaBUS BUS = new ctSuaChuaBUS();
            if (BUS.Delete(new ctSuaChua() { ID = dr["ID"] }))
            {
                if (ug.ActiveRow == null) return;
                int i = ug.ActiveRow.Index;
                bsData.RemoveCurrent();
                if (i > 0) i -= 1;
                if (i <= ug.Rows.Count - 1)
                {
                    ug.Focus();
                    ug.Rows[i].Activate();
                }
            }
        }

        protected void In()
        {
        }
    }
}
