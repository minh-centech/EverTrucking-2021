using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctSuaChuaUpdate : coreBase.BaseForms.frmBaseChungTuSingleUpdate
    {
        ctSuaChua obj = null;
        public frm_ctSuaChuaUpdate()
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
                    cboIDDanhMucXe.Value = null;
                    txtNgaySuaChua.Value = null;
                    txtNoiDungSuaChua.Value = null;
                    txtNoiSuaChua.Value = null;
                    txtSoKmDongHo.Value = null;
                    txtDonViTinh.Value = null;
                    txtSoLuong.Value = null;
                    txtDonGiaNhanCong.Value = null;
                    txtSoTienNhanCong.Value = null;
                    txtDonGiaVatTu.Value = null;
                    txtSoTienVatTu.Value = null;
                    txtSoTien.Value = null;
                    txtThoiGianBaoHanh.Value = null;
                    txtNguoiSuaChua.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Them || UpdateMode == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.ctSuaChua
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    IDDanhMucChungTuTrangThai = cboIDDanhMucTrangThaiChungTu.Value,
                    So = txtSo.Value,
                    NgayLap = txtNgayLap.Value,
                    IDDanhMucXe = cboIDDanhMucXe.Value,
                    BienSo = cboIDDanhMucXe.Text,
                    NgaySuaChua = txtNgaySuaChua.Value,
                    NoiDungSuaChua = txtNoiDungSuaChua.Value,
                    NoiSuaChua = txtNoiSuaChua.Value,
                    SoKmDongHo = txtSoKmDongHo.Value,
                    DonViTinh = txtDonViTinh.Value,
                    SoLuong = txtSoLuong.Value,
                    DonGiaNhanCong = txtDonGiaNhanCong.Value,
                    SoTienNhanCong = txtSoTienNhanCong.Value,
                    DonGiaVatTu = txtDonGiaVatTu.Value,
                    SoTienVatTu = txtSoTienVatTu.Value,
                    SoTien = txtSoTien.Value,
                    ThoiGianBaoHanh = txtThoiGianBaoHanh.Value,
                    NguoiSuaChua = txtNguoiSuaChua.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.ctSuaChua
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    IDDanhMucChungTuTrangThai = cboIDDanhMucTrangThaiChungTu.Value,
                    So = txtSo.Value,
                    NgayLap = txtNgayLap.Value,
                    IDDanhMucXe = cboIDDanhMucXe.Value,
                    BienSo = cboIDDanhMucXe.Text,
                    NgaySuaChua = txtNgaySuaChua.Value,
                    NoiDungSuaChua = txtNoiDungSuaChua.Value,
                    NoiSuaChua = txtNoiSuaChua.Value,
                    SoKmDongHo = txtSoKmDongHo.Value,
                    DonViTinh = txtDonViTinh.Value,
                    SoLuong = txtSoLuong.Value,
                    DonGiaNhanCong = txtDonGiaNhanCong.Value,
                    SoTienNhanCong = txtSoTienNhanCong.Value,
                    DonGiaVatTu = txtDonGiaVatTu.Value,
                    SoTienVatTu = txtSoTienVatTu.Value,
                    SoTien = txtSoTien.Value,
                    ThoiGianBaoHanh = txtThoiGianBaoHanh.Value,
                    NguoiSuaChua = txtNguoiSuaChua.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.ctSuaChuaBUS _BUS = new cenBUS.cenLogistics.ctSuaChuaBUS();
            bool OK = (UpdateMode == 1 || UpdateMode == 3) ? _BUS.Insert(ref obj) : _BUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                if (dataTable != null)
                {
                    if (UpdateMode == coreCommon.ThaoTacDuLieu.Them || UpdateMode == coreCommon.ThaoTacDuLieu.Copy)
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
                //dataRow["ID"] = obj.ID;
                //dataRow["So"] = obj.So;
                //dataRow["IDDanhMucDonVi"] = obj.IDDanhMucDonVi;
                //dataRow["IDDanhMucChungTu"] = obj.IDDanhMucChungTu;
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
            ////DanhMucXe
            //DanhMucXeBUS BUS = new DanhMucXeBUS();
            //DataTable dtXe = BUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongXe)), null, null, null);
            //cboIDDanhMucXe.dtValid = dtXe;
            //cboIDDanhMucXe.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongXe));
            //cboIDDanhMucXe.procedureName = DanhMucXe.listProcedureName;
            //cboIDDanhMucXe.DataSource = dtXe;
            //cboIDDanhMucXe.ValueMember = "ID";
            //cboIDDanhMucXe.DisplayMember = "BienSo";
            //
            if (cboIDDanhMucTrangThaiChungTu.Items.Count > 0) cboIDDanhMucTrangThaiChungTu.SelectedItem = cboIDDanhMucTrangThaiChungTu.Items[0];
            txtNgayLap.Value = DateTime.Now;
            txtNgaySuaChua.Value = DateTime.Now;
            //
            if (UpdateMode >= coreCommon.ThaoTacDuLieu.Sua)
            {

                txtSo.Value = dataRow["So"];
                txtNgayLap.Value = dataRow["NgayLap"];
                cboIDDanhMucTrangThaiChungTu.Value = dataRow["IDDanhMucChungTuTrangThai"];
                cboIDDanhMucXe.Value = dataRow["IDDanhMucXe"];
                txtNgaySuaChua.Value = dataRow["NgaySuaChua"];
                txtNoiDungSuaChua.Value = dataRow["NoiDungSuaChua"];
                txtNoiSuaChua.Value = dataRow["NoiSuaChua"];
                txtSoKmDongHo.Value = dataRow["SoKmDongHo"];
                txtDonViTinh.Value = dataRow["DonViTinh"];
                txtSoLuong.Value = dataRow["SoLuong"];
                txtDonGiaNhanCong.Value = dataRow["DonGiaNhanCong"];
                txtSoTienNhanCong.Value = dataRow["SoTienNhanCong"];
                txtDonGiaVatTu.Value = dataRow["DonGiaVatTu"];
                txtSoTienVatTu.Value = dataRow["SoTienVatTu"];
                txtSoTien.Value = dataRow["SoTien"];
                txtThoiGianBaoHanh.Value = dataRow["ThoiGianBaoHanh"];
                txtNguoiSuaChua.Value = dataRow["NguoiSuaChua"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }

        private void txtSoLuong_ValueChanged(object sender, EventArgs e)
        {
            txtSoTienNhanCong.Value = (!coreCommon.coreCommon.IsNull(txtSoLuong.Value) ? (int)txtSoLuong.Value : 1) * (!coreCommon.coreCommon.IsNull(txtDonGiaNhanCong.Value) ? (int)txtDonGiaNhanCong.Value : 0);
            txtSoTienVatTu.Value = (!coreCommon.coreCommon.IsNull(txtSoLuong.Value) ? (int)txtSoLuong.Value : 1) * (!coreCommon.coreCommon.IsNull(txtDonGiaVatTu.Value) ? (int)txtDonGiaVatTu.Value : 0);
            txtSoTien.Value = (!coreCommon.coreCommon.IsNull(txtSoTienNhanCong.Value) ? (int)txtSoTienNhanCong.Value : 0) + (!coreCommon.coreCommon.IsNull(txtSoTienVatTu.Value) ? (int)txtSoTienVatTu.Value : 0);
        }
    }
}
