using cenBUS.cenLogistics;
using coreBUS;
using coreControls;
using cenDTO.cenLogistics;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static cenCommonUIapps.cenCommonUIapps;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucDinhMucChiPhiUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucDinhMucChiPhi obj = null;
        public frmDanhMucDinhMucChiPhiUpdate()
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
                    txtNgayApDung.Value = null;
                    txtMaDanhMucTuyenVanTai.Value = null;
                    txtMaDanhMucTuyenVanTai.ID = null;
                    txtTenDanhMucTuyenVanTai.Value = null;
                    txtSoTienVeCauDuong.Value = null;
                    txtSoTienLuatAnCa.Value = null;
                    txtSoTienLuuCaKhac.Value = null;
                    txtSoTienLuatDuongCam.Value = null;
                    txtSoTienLuongChuyen.Value = null;
                    txtSoTramLuat.Value = null;
                    txtSoTramVe.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucDinhMucChiPhi
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    //
                    NgayApDung = txtNgayApDung.Value,
                    IDDanhMucTuyenVanTai = txtMaDanhMucTuyenVanTai.ID,
                    MaDanhMucTuyenVanTai = txtMaDanhMucTuyenVanTai.Value,
                    TenDanhMucTuyenVanTai = txtTenDanhMucTuyenVanTai.Value,
                    SoTienVeCauDuong = txtSoTienVeCauDuong.Value,
                    SoTienLuatAnCa = txtSoTienLuatAnCa.Value,
                    SoTienLuuCaKhac = txtSoTienLuuCaKhac.Value,
                    SoTienLuatDuongCam = txtSoTienLuatDuongCam.Value,
                    SoTienLuongChuyen = txtSoTienLuongChuyen.Value,
                    SoTramLuat = txtSoTramLuat.Value,
                    SoTramVe = txtSoTramVe.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucDinhMucChiPhi
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    //
                    NgayApDung = txtNgayApDung.Value,
                    IDDanhMucTuyenVanTai = txtMaDanhMucTuyenVanTai.ID,
                    MaDanhMucTuyenVanTai = txtMaDanhMucTuyenVanTai.Value,
                    TenDanhMucTuyenVanTai = txtTenDanhMucTuyenVanTai.Value,
                    SoTienVeCauDuong = txtSoTienVeCauDuong.Value,
                    SoTienLuatAnCa = txtSoTienLuatAnCa.Value,
                    SoTienLuuCaKhac = txtSoTienLuuCaKhac.Value,
                    SoTienLuatDuongCam = txtSoTienLuatDuongCam.Value,
                    SoTienLuongChuyen = txtSoTienLuongChuyen.Value,
                    SoTramLuat = txtSoTramLuat.Value,
                    SoTramVe = txtSoTramVe.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucDinhMucChiPhiBUS _BUS = new cenBUS.cenLogistics.DanhMucDinhMucChiPhiBUS();
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
            ////DanhMucTuyenVanTai
            //DanhMucTuyenVanTaiBUS BUS = new DanhMucTuyenVanTaiBUS();
            //DataTable dtTuyenVanTai = BUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTai)), null).Tables[DanhMucTuyenVanTai.tableName];
            //txtMaDanhMucTuyenVanTai.IsValid = true;
            //txtMaDanhMucTuyenVanTai.dtValid = dtTuyenVanTai;
            //txtMaDanhMucTuyenVanTai.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTai));
            //saTextBox[] txtMaDanhMucTuyenVanTaiExt = new saTextBox[1];
            //txtMaDanhMucTuyenVanTaiExt[0] = txtTenDanhMucTuyenVanTai;
            //txtMaDanhMucTuyenVanTai.txtMoRong = txtMaDanhMucTuyenVanTaiExt;
            //txtMaDanhMucTuyenVanTai.ValidColumnName = "Ma";
            //txtMaDanhMucTuyenVanTai.ReturnedColumnsList = "Ten";
            //txtMaDanhMucTuyenVanTai.procedureName = DanhMucTuyenVanTai.listProcedureName;
            //txtMaDanhMucTuyenVanTai.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);

            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                txtNgayApDung.Value = dataRow["NgayApDung"];
                txtMaDanhMucTuyenVanTai.Value = dataRow["MaDanhMucTuyenVanTai"];
                txtMaDanhMucTuyenVanTai.ID = dataRow["IDDanhMucTuyenVanTai"];
                txtTenDanhMucTuyenVanTai.Value = dataRow["TenDanhMucTuyenVanTai"];
                txtSoTienVeCauDuong.Value = dataRow["SoTienVeCauDuong"];
                txtSoTienLuatAnCa.Value = dataRow["SoTienLuatAnCa"];
                txtSoTienLuuCaKhac.Value = dataRow["SoTienLuuCaKhac"];
                txtSoTienLuatDuongCam.Value = dataRow["SoTienLuatDuongCam"];
                txtSoTienLuongChuyen.Value = dataRow["SoTienLuongChuyen"];
                txtSoTramLuat.Value = dataRow["SoTramLuat"];
                txtSoTramVe.Value = dataRow["SoTramVe"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
