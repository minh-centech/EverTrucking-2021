using cenBUS.cenLogistics;
using coreBUS;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctThanhToanTamUng : coreBase.BaseForms.frmBaseChungTuSingleList
    {
        public frm_ctThanhToanTamUng()
        {
            InitializeComponent();
            UltraToolbarsManager1.Tools["btThem"].SharedProps.Enabled = false;
            UltraToolbarsManager1.Tools["btThem"].SharedProps.Visible = false;
            UltraToolbarsManager1.Tools["btCopy"].SharedProps.Enabled = false;
            UltraToolbarsManager1.Tools["btCopy"].SharedProps.Visible = false;
            UltraToolbarsManager1.Tools["btSua"].SharedProps.Caption = "Cập nhật thanh toán (CTRL+E)";
            UltraToolbarsManager1.Tools["btXoa"].SharedProps.Enabled = false;
            UltraToolbarsManager1.Tools["btXoa"].SharedProps.Visible = false;
            txtTuNgay.Value = DateTime.Now;
            txtDenNgay.Value = DateTime.Now;
        }
        protected override void List()
        {
            ctThanhToanTamUngBUS bus = new ctThanhToanTamUngBUS();
            dtData = bus.ListDisplay(IDDanhMucChungTu, null, null, txtTuNgay.Value, txtDenNgay.Value);
            bsData = new BindingSource();
            bsData.DataSource = dtData;
            ug.FixedColumnsList = "[NgayDongTraHang][So][DebitNote][BillBooking]";
            ug.DataSource = bsData;
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

            frm_ctThanhToanTamUngUpdate frmUpdate = new frm_ctThanhToanTamUngUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Sua,
                Text = cenCommon.LoaiManHinh.NameThanhToanTamUng,
                IDChungTu = dr["ID"],
                IDChungTuChiTiet = dr["IDctDonHangChiTietTamUng"],
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh
            };
            frmUpdate.ShowDialog();
            if (!coreCommon.coreCommon.IsNull(frmUpdate.IDChungTu))
            {
                ctThanhToanTamUngBUS bus = new ctThanhToanTamUngBUS();
                DataTable dtChungTuUpdate = bus.ListDisplay(IDDanhMucChungTu, frmUpdate.IDChungTu, frmUpdate.IDChungTuChiTiet, null, null);
                dr.ItemArray = dtChungTuUpdate.Rows[0].ItemArray;
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
