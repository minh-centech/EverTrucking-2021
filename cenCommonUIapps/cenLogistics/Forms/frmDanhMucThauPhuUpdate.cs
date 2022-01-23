using coreBUS;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucThauPhuUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucThauPhu obj = null;
        public frmDanhMucThauPhuUpdate()
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
                    txtDiaChi.Value = null;
                    txtSoDienThoai.Value = null;
                    txtMaSoThueCMND.Value = null;
                    cboIDDanhMucNhomHangVanChuyen.Value = null;
                    txtKyHieuKeToan.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            //
            if (coreCommon.coreCommon.IsNull(txtMa.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu mã thầu phụ!"); txtMa.Focus(); return false; }
            if (coreCommon.coreCommon.IsNull(txtTen.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu tên thầu phụ!"); txtMa.Focus(); return false; }
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucNhomHangVanChuyen.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu nhóm khách hàng!"); cboIDDanhMucNhomHangVanChuyen.Focus(); return false; }

            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucThauPhu
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    //
                    DiaChi = txtDiaChi.Value,
                    SoDienThoai = txtSoDienThoai.Value,
                    MaSoThueCMND = txtMaSoThueCMND.Value,
                    IDDanhMucNhomHangVanChuyen = cboIDDanhMucNhomHangVanChuyen.Value,
                    KyHieuKeToan = txtKyHieuKeToan.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucThauPhu
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    //
                    DiaChi = txtDiaChi.Value,
                    SoDienThoai = txtSoDienThoai.Value,
                    MaSoThueCMND = txtMaSoThueCMND.Value,
                    IDDanhMucNhomHangVanChuyen = cboIDDanhMucNhomHangVanChuyen.Value,
                    KyHieuKeToan = txtKyHieuKeToan.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucThauPhuBUS _BUS = new cenBUS.cenLogistics.DanhMucThauPhuBUS();
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
            ////DanhMucNhomHangVanChuyen
            //DanhMucDoiTuongBUS DanhMucNhomHangVanChuyenBUS = new DanhMucDoiTuongBUS();
            //DataTable dtNhomHangVanChuyen = DanhMucNhomHangVanChuyenBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen)), null);
            //cboIDDanhMucNhomHangVanChuyen.DataSource = dtNhomHangVanChuyen;
            //cboIDDanhMucNhomHangVanChuyen.ValueMember = "ID";
            //cboIDDanhMucNhomHangVanChuyen.DisplayMember = "Ten";

            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtDiaChi.Value = dataRow["DiaChi"];
                txtSoDienThoai.Value = dataRow["SoDienThoai"];
                txtMaSoThueCMND.Value = dataRow["MaSoThueCMND"];
                cboIDDanhMucNhomHangVanChuyen.Value = dataRow["IDDanhMucNhomHangVanChuyen"];
                txtKyHieuKeToan.Value = dataRow["KyHieuKeToan"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
