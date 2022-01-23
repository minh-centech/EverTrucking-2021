using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucKhachHangUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucKhachHang obj = null;
        public frmDanhMucKhachHangUpdate()
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
                    CapNhat = coreCommon.ThaoTacDuLieu.Them;
                    //Xóa text box
                    txtMa.Value = null;
                    txtTen.Value = null;
                    cboIDDanhMucNhanSu.Value = null;
                    txtDiaChi.Value = null;
                    txtSoDienThoai.Value = null;
                    txtSoFax.Value = null;
                    txtEmail.Value = null;
                    txtMaSoThue.Value = null;
                    txtTenNganHang.Value = null;
                    txtSoTaiKhoan.Value = null;
                    txtNguoiDaiDien.Value = null;
                    txtNguoiGiaoNhan.Value = null;
                    txtSoDienThoaiGiaoNhan.Value = null;
                    cboIDDanhMucTuyenVanTai.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            //
            if (coreCommon.coreCommon.IsNull(txtMa.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu mã khách hàng!"); txtMa.Focus(); return false; }
            if (coreCommon.coreCommon.IsNull(txtTen.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu tên khách hàng!"); txtMa.Focus(); return false; }
            //if (coreCommon.coreCommon.IsNull(cboIDDanhMucNhanSu.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu mã sale!"); cboIDDanhMucNhanSu.Focus(); return false; }
            //if (coreCommon.coreCommon.IsNull(txtDiaChi.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu địa chỉ!"); txtDiaChi.Focus(); return false; }



            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucKhachHang
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    //
                    IDDanhMucNhanSu = cboIDDanhMucNhanSu.Value,
                    TenDanhMucNhanSu = cboIDDanhMucNhanSu.Text,
                    DiaChi = txtDiaChi.Value,
                    SoDienThoai = txtSoDienThoai.Value,
                    SoFax = txtSoFax.Value,
                    Email = txtEmail.Value,
                    MaSoThue = txtMaSoThue.Value,
                    TenNganHang = txtTenNganHang.Value,
                    SoTaiKhoan = txtSoTaiKhoan.Value,
                    NguoiDaiDien = txtNguoiDaiDien.Value,
                    NguoiGiaoNhan = txtNguoiGiaoNhan.Value,
                    SoDienThoaiGiaoNhan = txtSoDienThoaiGiaoNhan.Value,
                    IDDanhMucTuyenVanTai = cboIDDanhMucTuyenVanTai.Value,
                    TenDanhMucTuyenVanTai = cboIDDanhMucTuyenVanTai.Text,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucKhachHang
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    //
                    IDDanhMucNhanSu = cboIDDanhMucNhanSu.Value,
                    TenDanhMucNhanSu = cboIDDanhMucNhanSu.Text,
                    DiaChi = txtDiaChi.Value,
                    SoDienThoai = txtSoDienThoai.Value,
                    SoFax = txtSoFax.Value,
                    Email = txtEmail.Value,
                    MaSoThue = txtMaSoThue.Value,
                    TenNganHang = txtTenNganHang.Value,
                    SoTaiKhoan = txtSoTaiKhoan.Value,
                    NguoiDaiDien = txtNguoiDaiDien.Value,
                    NguoiGiaoNhan = txtNguoiGiaoNhan.Value,
                    SoDienThoaiGiaoNhan = txtSoDienThoaiGiaoNhan.Value,
                    IDDanhMucTuyenVanTai = cboIDDanhMucTuyenVanTai.Value,
                    TenDanhMucTuyenVanTai = cboIDDanhMucTuyenVanTai.Text,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucKhachHangBUS _BUS = new cenBUS.cenLogistics.DanhMucKhachHangBUS();
            bool OK = (CapNhat == 1 || CapNhat == 3) ? _BUS.Insert(ref obj) : _BUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                if (dataTable != null)
                {
                    if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
                    {
                        DataRow dr = dataTable.NewRow();
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            if (dataTable.Columns.Contains(prop.Name))
                                dr[prop.Name] = !coreCommon.coreCommon.IsNull(prop.GetValue(obj, null)) ? prop.GetValue(obj, null) : DBNull.Value;
                        }
                        dataTable.Rows.Add(dr);
                        dataTable.AcceptChanges();
                    }
                    else
                    {
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            if (dataTable.Columns.Contains(prop.Name))
                                dataRow[prop.Name] = !coreCommon.coreCommon.IsNull(prop.GetValue(obj, null)) ? prop.GetValue(obj, null) : DBNull.Value;
                        }
                    }
                }
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
            //DanhMucNhanSu
            DanhMucNhanSuBUS DanhMucNhanSuBUS = new DanhMucNhanSuBUS();
            DataTable dtNhanSu = DanhMucNhanSuBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu)), null);
            cboIDDanhMucNhanSu.DataSource = dtNhanSu;
            cboIDDanhMucNhanSu.ValueMember = "ID";
            cboIDDanhMucNhanSu.DisplayMember = "Ten";
            //DanhMucTuyenVanTai
            DanhMucTuyenVanTaiBUS DanhMucTuyenVanTaiBUS = new DanhMucTuyenVanTaiBUS();
            DataTable dtTuyenVanTai = DanhMucTuyenVanTaiBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTai)), null).Tables[0];
            cboIDDanhMucTuyenVanTai.DataSource = dtTuyenVanTai;
            cboIDDanhMucTuyenVanTai.ValueMember = "ID";
            cboIDDanhMucTuyenVanTai.DisplayMember = "Ten";
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                cboIDDanhMucNhanSu.Value = dataRow["IDDanhMucNhanSu"];
                txtDiaChi.Value = dataRow["DiaChi"];
                txtSoDienThoai.Value = dataRow["SoDienThoai"];
                txtSoFax.Value = dataRow["SoFax"];
                txtEmail.Value = dataRow["Email"];
                txtMaSoThue.Value = dataRow["MaSoThue"];
                txtTenNganHang.Value = dataRow["TenNganHang"];
                txtSoTaiKhoan.Value = dataRow["SoTaiKhoan"];
                txtNguoiDaiDien.Value = dataRow["NguoiDaiDien"];
                txtNguoiGiaoNhan.Value = dataRow["NguoiGiaoNhan"];
                txtSoDienThoaiGiaoNhan.Value = dataRow["SoDienThoaiGiaoNhan"];
                cboIDDanhMucTuyenVanTai.Value = dataRow["IDDanhMucTuyenVanTai"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
