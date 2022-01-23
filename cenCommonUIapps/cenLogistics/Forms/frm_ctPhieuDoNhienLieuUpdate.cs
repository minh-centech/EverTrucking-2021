using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctPhieuDoNhienLieuUpdate : coreBase.BaseForms.frmBaseChungTuSingleUpdate
    {
        public object IDctDonHang = null;
        ctPhieuDoNhienLieu obj = null;
        public frm_ctPhieuDoNhienLieuUpdate()
        {
            InitializeComponent();
        }
        protected override void SaveData(bool AddNew)
        {
            if (Save())
            {
                if (!AddNew)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    UpdateMode = coreCommon.ThaoTacDuLieu.Them;
                    //Xóa text box
                    txtSo.Value = null;
                    txtNgayLap.Value = DateTime.Now;
                    if (cboIDDanhMucTrangThaiChungTu.Items.Count > 0) cboIDDanhMucTrangThaiChungTu.SelectedItem = cboIDDanhMucTrangThaiChungTu.Items[0];
                    //
                    txtSoDonHang.Value = null;
                    txtDebitNote.Value = null;
                    txtTenDanhMucTuyenVanTai.Value = null;
                    txtTenDanhMucTaiXe.Value = null;
                    txtBienSo.Value = null;
                    txtNgayDoNhienLieu.Value = DateTime.Now;
                    cboIDDanhMucDonViCungCapNhienLieu.Value = null;
                    txtSoLuongNhienLieu.Value = null;
                    txtDonGia.Value = null;
                    txtThanhTien.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (coreCommon.coreCommon.IsNull(IDctDonHang)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu số đơn hàng"); txtSoDonHang.Focus(); return false; }
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucDonViCungCapNhienLieu)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu tên đơn vị cung cấp nhiên liệu!"); cboIDDanhMucDonViCungCapNhienLieu.Focus(); return false; }
            obj = new cenDTO.cenLogistics.ctPhieuDoNhienLieu
            {
                ID = (UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? null : dataRow["ID"],
                IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                IDDanhMucChungTu = IDDanhMucChungTu,
                IDDanhMucChungTuTrangThai = cboIDDanhMucTrangThaiChungTu.Value,
                //
                IDChungTu = IDctDonHang,
                NgayLap = txtNgayLap.Value,
                IDDanhMucDonViCungCapNhienLieu =  cboIDDanhMucDonViCungCapNhienLieu.Value,
                NgayDoNhienLieu = txtNgayDoNhienLieu.Value,
                SoLuongNhienLieu = txtSoLuongNhienLieu.Value,
                DonGia = txtDonGia.Value,
                //
                GhiChu = txtGhiChu.Value,
                IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                CreateDate = null,
                EditDate = null
            };
            cenBUS.cenLogistics.ctPhieuDoNhienLieuBUS _BUS = new cenBUS.cenLogistics.ctPhieuDoNhienLieuBUS();
            bool OK = (UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? _BUS.Insert(ref obj) : _BUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                ID = obj.ID;
                return true;
            }
            else
            {
                ID = null;
                return false;
            }
        }
        private void frmDanhMucChungTuUpdate_Load(object sender, EventArgs e)
        {
            ////DanhMucTrangThaiChungTu
            //DanhMucChungTuTrangThaiBUS danhMucChungTuTrangThaiBUS = new DanhMucChungTuTrangThaiBUS();
            //DataTable dtTrangThai = danhMucChungTuTrangThaiBUS.List(null, IDDanhMucChungTu);
            //cboIDDanhMucTrangThaiChungTu.DataSource = dtTrangThai;
            //cboIDDanhMucTrangThaiChungTu.ValueMember = "ID";
            //cboIDDanhMucTrangThaiChungTu.DisplayMember = "Ten";
            //if (cboIDDanhMucTrangThaiChungTu.Items.Count > 0) cboIDDanhMucTrangThaiChungTu.SelectedItem = cboIDDanhMucTrangThaiChungTu.Items[0];
            ////Sale
            //DanhMucDoiTuongBUS DanhMucDoiTuongBUS = new DanhMucDoiTuongBUS();
            //DataTable dtDonViCungCapNhienLieu = DanhMucDoiTuongBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongDonViCungCapNhienLieu)), null);
            //cboIDDanhMucDonViCungCapNhienLieu.dtValid = dtDonViCungCapNhienLieu;
            //cboIDDanhMucDonViCungCapNhienLieu.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongDonViCungCapNhienLieu));
            //cboIDDanhMucDonViCungCapNhienLieu.procedureName = DanhMucDoiTuong.listProcedureName;
            //cboIDDanhMucDonViCungCapNhienLieu.DataSource = dtDonViCungCapNhienLieu;
            //cboIDDanhMucDonViCungCapNhienLieu.ValueMember = "ID";
            //cboIDDanhMucDonViCungCapNhienLieu.DisplayMember = "Ten";
            //this.cboIDDanhMucDonViCungCapNhienLieu.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);
            //
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Them)
            {
                txtNgayLap.Value = DateTime.Now;
                txtNgayDoNhienLieu.Value = DateTime.Now;
            }
            //
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Sua || UpdateMode == coreCommon.ThaoTacDuLieu.Copy)
            {
                ctPhieuDoNhienLieuBUS ctPhieuDoNhienLieuBUS = new ctPhieuDoNhienLieuBUS();
                dataRow = ctPhieuDoNhienLieuBUS.List(IDDanhMucChungTu, ID).Rows[0];
                //
                ID = dataRow["ID"];
                txtSo.Value = dataRow["So"];
                txtNgayLap.Value = dataRow["NgayLap"];
                cboIDDanhMucTrangThaiChungTu.Value = dataRow["IDDanhMucChungTuTrangThai"];
                txtSoDonHang.Value = dataRow["SoDonHang"];
                IDctDonHang = dataRow["IDChungTu"];
                txtDebitNote.Value = dataRow["DebitNote"];
                txtTenDanhMucTuyenVanTai.Value = dataRow["TenDanhMucTuyenVanTai"];
                txtTenDanhMucTaiXe.Value = dataRow["TenDanhMucTaiXe"];
                txtBienSo.Value = dataRow["BienSo"];
                txtNgayDoNhienLieu.Value = dataRow["NgayDoNhienLieu"];
                cboIDDanhMucDonViCungCapNhienLieu.Value = dataRow["IDDanhMucDonViCungCapNhienLieu"];
                txtSoLuongNhienLieu.Value = dataRow["SoLuongNhienLieu"];
                txtDonGia.Value = dataRow["DonGia"];
                txtThanhTien.Value = dataRow["ThanhTien"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Xem)
            {
                cmdSave.Enabled = false;
                cmdSaveNew.Enabled = false;
            }
        }

        private void txtNhienLieu_ValueChanged(object sender, EventArgs e)
        {
            float SoLuongNhienLieu = float.Parse(!coreCommon.coreCommon.IsNull(txtSoLuongNhienLieu.Value) ? txtSoLuongNhienLieu.Value.ToString() : "0");
            float DonGia = float.Parse(!coreCommon.coreCommon.IsNull(txtDonGia.Value) ? txtDonGia.Value.ToString() : "0");
            txtThanhTien.Value = SoLuongNhienLieu * DonGia;
        }

        private void txtSoDonHang_Validated(object sender, EventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(txtSoDonHang.Value)) { IDctDonHang = null; return;  }

            ctChiPhiVanTaiBUS bus = new ctChiPhiVanTaiBUS();
            DataTable dt = bus.ListValidSoDonHang(txtSoDonHang.Text.Trim());
            if (dt == null) { return; }
            if (dt.Rows.Count == 1)
            {
                IDctDonHang = dt.Rows[0]["ID"];
                txtSoDonHang.Value = dt.Rows[0]["So"];
                txtDebitNote.Value = dt.Rows[0]["DebitNote"];
                txtTenDanhMucTuyenVanTai.Value = dt.Rows[0]["TenDanhMucTuyenVanTai"];
                txtTenDanhMucTaiXe.Value = dt.Rows[0]["TenDanhMucTaiXe"];
                txtBienSo.Value = dt.Rows[0]["BienSo"];
                txtSoLuongNhienLieu.Value = dt.Rows[0]["SoLuongNhienLieu"];
                return;
            }
            else
            {
                //Show valid form
                frm_ctChiPhiVanTaiValidSoDonHang frmValid = new frm_ctChiPhiVanTaiValidSoDonHang()
                {
                    validValue = txtSoDonHang.Text.Trim(),
                    dataTable = dt
                };
                frmValid.ShowDialog();
                if (frmValid.dataRows == null || frmValid.dataRows.Count == 0) { return; }
                if (frmValid.dataRows.Count > 0)
                {
                    IDctDonHang = frmValid.dataRows[0]["ID"];
                    txtSoDonHang.Value = frmValid.dataRows[0]["So"];
                    txtDebitNote.Value = frmValid.dataRows[0]["DebitNote"];
                    txtTenDanhMucTuyenVanTai.Value = frmValid.dataRows[0]["TenDanhMucTuyenVanTai"];
                    txtTenDanhMucTaiXe.Value = frmValid.dataRows[0]["TenDanhMucTaiXe"];
                    txtBienSo.Value = frmValid.dataRows[0]["BienSo"];
                    txtSoLuongNhienLieu.Value = frmValid.dataRows[0]["SoLuongNhienLieu"];
                    return;
                }
            }

        }
    }
}
