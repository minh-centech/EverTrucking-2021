using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctTamUng : coreBase.BaseForms.frmBaseChungTuSingleList
    {
        public frm_ctTamUng()
        {
            InitializeComponent();
            txtTuNgay.DateTime = DateTime.Now;
            txtDenNgay.Value = DateTime.Now;
        }
        protected override void List()
        {
            ctDonHangBUS bus = new ctDonHangBUS();
            dtData = bus.ListDisplay(IDDanhMucChungTu, null, txtTuNgay.Value, txtDenNgay.Value);
            bsData = new BindingSource();
            bsData.DataSource = dtData;
            ug.HiddenColumnsList = "[NgayDongTraHang]";
            ug.DataSource = bsData;
            //
            DataTable dtNhomHangVanChuyen = bus.ListNhomHangVanChuyen(IDDanhMucChungTu, txtTuNgay.Value, txtDenNgay.Value, null);
            BindingSource bsTotal = new BindingSource();
            bsTotal.DataSource = dtNhomHangVanChuyen;

            txtTotal.MaskInput = "-nnnn";
            txtCont.MaskInput = "-nnnn";
            txtTruck.MaskInput = "-nnnn";

            txtTotal.SetDataBinding(bsTotal, "Total", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCont.SetDataBinding(bsTotal, "Cont", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTruck.SetDataBinding(bsTotal, "Truck", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected override void InsertDanhMuc()
        {
            return;
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm dữ liệu chứng từ này!");
                return;
            }
            frm_ctTamUngUpdate frmUpdate = new frm_ctTamUngUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Them,
                Text = cenCommon.LoaiManHinh.NameDonHang,
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh
            };
            frmUpdate.ShowDialog();
            if (!coreCommon.coreCommon.IsNull(frmUpdate.IDChungTu))
            {
                ctDonHangBUS bus = new ctDonHangBUS();
                DataTable dtChungTuInsert = bus.ListDisplay(IDDanhMucChungTu, frmUpdate.IDChungTu, null, null);
                dtData.Merge(dtChungTuInsert);
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

            if (coreCommon.coreCommon.IsNull(ctDonHangBUS.GetIDctChotDoanhThuGuiKeToan(dr["ID"])))
            {

                frm_ctTamUngUpdate frmUpdate = new frm_ctTamUngUpdate
                {
                    UpdateMode = coreCommon.ThaoTacDuLieu.Sua,
                    Text = cenCommon.LoaiManHinh.NameTamUng,
                    IDChungTu = dr["ID"],
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    LoaiManHinh = LoaiManHinh
                };
                frmUpdate.ShowDialog();
                if (!coreCommon.coreCommon.IsNull(frmUpdate.IDChungTu))
                {
                    ctDonHangBUS bus = new ctDonHangBUS();
                    DataTable dtChungTuUpdate = bus.ListDisplay(IDDanhMucChungTu, frmUpdate.IDChungTu, null, null);
                    dr.ItemArray = dtChungTuUpdate.Rows[0].ItemArray;
                }
                frmUpdate.Dispose();
            }
            else
                ViewDanhMuc();
        }
        protected override void DeleteDanhMuc()
        {
            return;
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow) return;
            if (bsData.Current == null) return;
            DataRow dr = ((DataRowView)bsData.Current).Row;
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu chứng từ này!");
                return;
            }
            if (!coreCommon.coreCommon.IsNull(ctDonHangBUS.GetIDctChotDoanhThuGuiKeToan(dr["ID"]))) { coreCommon.coreCommon.ErrorMessageOkOnly("Đơn hàng đã chốt doanh thu, không xóa được!"); return; }
            if (!coreCommon.coreCommon.IsNull(ctDonHangBUS.GetIDctChotChiPhiVanTaiGuiKeToan(dr["ID"]))) { coreCommon.coreCommon.ErrorMessageOkOnly("Đơn hàng đã chốt chi phí, không xóa được!"); return; }
            if (!coreCommon.coreCommon.IsNull(ctDonHangBUS.GetIDctChotChiPhiVanTaiBoSungGuiKeToan(dr["ID"]))) { coreCommon.coreCommon.ErrorMessageOkOnly("Đơn hàng đã chốt chi phí bổ sung, không xóa được!"); return; }
            base.DeleteDanhMuc();
            if (!bContinue) return;
            ctDonHangBUS BUS = new ctDonHangBUS();
            ctDonHang obj = new ctDonHang()
            {
                ID = dr["ID"]
            };
            if (BUS.Delete(obj))
            {
                if (ug.ActiveRow == null) return;
                int i = ug.ActiveRow.Index;
                bsData.RemoveCurrent();
                if (i > 0) i += 1;
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
        protected override void ViewDanhMuc()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xem)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xem dữ liệu chứng từ này!");
                return;
            }
            if (bsData.Current == null) return;

            DataRow dr = ((DataRowView)bsData.Current).Row;

            frm_ctTamUngUpdate frmUpdate = new frm_ctTamUngUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Xem,
                Text = cenCommon.LoaiManHinh.NameDonHang,
                IDChungTu = dr["ID"],
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh
            };
            frmUpdate.ShowDialog();
            if (!coreCommon.coreCommon.IsNull(frmUpdate.IDChungTu))
            {
                ctDonHangBUS bus = new ctDonHangBUS();
                DataTable dtChungTuUpdate = bus.ListDisplay(IDDanhMucChungTu, frmUpdate.IDChungTu, null, null);
                dr.ItemArray = dtChungTuUpdate.Rows[0].ItemArray;
            }
            frmUpdate.Dispose();
        }
        protected override void CopyDanhMuc()
        {
            return;
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm dữ liệu chứng từ này!");
                return;
            }
            if (bsData.Current == null) return;

            DataRow dr = ((DataRowView)bsData.Current).Row;

            frm_ctTamUngUpdate frmUpdate = new frm_ctTamUngUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Copy,
                Text = cenCommon.LoaiManHinh.NameDonHang,
                IDChungTu = dr["ID"],
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh
            };
            frmUpdate.ShowDialog();
            if (!coreCommon.coreCommon.IsNull(frmUpdate.IDChungTu))
            {
                ctDonHangBUS bus = new ctDonHangBUS();
                DataTable dtChungTuInsert = bus.ListDisplay(IDDanhMucChungTu, frmUpdate.IDChungTu, null, null);
                dtData.Merge(dtChungTuInsert);
            }
            frmUpdate.Dispose();
        }

        private void ug_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if (!coreCommon.coreCommon.IsNull(e.Row.Cells["MaDanhMucThauPhu"].Value) && e.Row.Cells["MaDanhMucThauPhu"].Value.ToString().ToUpper().StartsWith("PLJ") && e.Row.Cells["TrangThaiDonHang"].Value.ToString() == "Đơn")
            {
                e.Row.Appearance.BackColor = System.Drawing.Color.FromArgb(206, 231, 255);
            }
            if (!coreCommon.coreCommon.IsNull(e.Row.Cells["MaDanhMucThauPhu"].Value) && e.Row.Cells["MaDanhMucThauPhu"].Value.ToString().ToUpper().StartsWith("PLJ") && e.Row.Cells["TrangThaiDonHang"].Value.ToString() == "Kết hợp")
            {
                e.Row.Appearance.BackColor = System.Drawing.Color.FromArgb(131, 192, 255);
            }
            if (!coreCommon.coreCommon.IsNull(e.Row.Cells["MaDanhMucThauPhu"].Value) && !e.Row.Cells["MaDanhMucThauPhu"].Value.ToString().ToUpper().StartsWith("PLJ") && e.Row.Cells["TrangThaiDonHang"].Value.ToString() == "Kết hợp")
            {
                e.Row.Appearance.BackColor = System.Drawing.Color.FromArgb(202, 237, 97);
            }
        }
    }
}
