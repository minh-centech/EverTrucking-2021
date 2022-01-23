using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctDieuHanh : coreBase.BaseForms.frmBaseChungTuSingleList
    {
        public frm_ctDieuHanh()
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
            ctDieuHanhBUS bus = new ctDieuHanhBUS();
            dtData = bus.ListDisplay(IDDanhMucChungTu, null, txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucNhomHangVanChuyen.Value);
            bsData = new BindingSource();
            bsData.DataSource = dtData;
            ug.HiddenColumnsList = "[LoaiHang][NgayLap]";
            ug.FixedColumnsList = "[So][DebitNote]";
            ug.DataSource = bsData;
            //
            ctDonHangBUS ctDonHangBUS = new ctDonHangBUS();
            DataTable dtTotalNhomHangVanChuyen = ctDonHangBUS.ListNhomHangVanChuyen(IDDanhMucChungTu, txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucNhomHangVanChuyen.Value);
            BindingSource bsTotal = new BindingSource();
            bsTotal.DataSource = dtTotalNhomHangVanChuyen;

            txtTotal.MaskInput = "";
            txtCont.MaskInput = "";
            txtTruck.MaskInput = "";

            txtTotal.SetDataBinding(bsTotal, "Total", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCont.SetDataBinding(bsTotal, "Cont", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTruck.SetDataBinding(bsTotal, "Truck", true, DataSourceUpdateMode.OnPropertyChanged);
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

            frm_ctDieuHanhUpdate frmUpdate = new frm_ctDieuHanhUpdate
            {
                UpdateMode = (coreCommon.coreCommon.IsNull(dr["IDctDieuHanh"])) ? coreCommon.ThaoTacDuLieu.Them : coreCommon.ThaoTacDuLieu.Sua,
                Text = cenCommon.LoaiManHinh.NameDieuHanh,
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh,
                dataTable = dtData,
                dataRow = dr,
                IDctDonHang = dr["ID"]
            };
            frmUpdate.ShowDialog();
            if (!coreCommon.coreCommon.IsNull(frmUpdate.ID))
            {
                ctDieuHanhBUS BUS = new ctDieuHanhBUS();
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
            if (coreCommon.coreCommon.IsNull(dr["IDctDieuHanh"])) return;
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu chứng từ này!");
                return;
            }
            if (!coreCommon.coreCommon.IsNull(ctDonHangBUS.GetIDctChotDoanhThuGuiKeToan(dr["ID"]))) { coreCommon.coreCommon.ErrorMessageOkOnly("Đơn hàng đã chốt doanh thu, không xóa thông tin điều hành!"); return; }
            base.DeleteDanhMuc();
            if (!bContinue) return;
            ctDieuHanhBUS BUS = new ctDieuHanhBUS();
            if (BUS.Delete(new ctDieuHanh() { ID = dr["IDctDieuHanh"] }))
            {
                DataRow drChungTuUpdate = BUS.ListDisplay(IDDanhMucChungTu, dr["ID"], txtTuNgay.Value, txtDenNgay.Value, cboIDDanhMucNhomHangVanChuyen.Value).Rows[0];
                dr.ItemArray = drChungTuUpdate.ItemArray;
                dtData.AcceptChanges();
            }
        }
        protected void In()
        {
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
