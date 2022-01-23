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
    public partial class frmDanhMucTuyenVanTaiUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucTuyenVanTai obj = null;
        public frmDanhMucTuyenVanTaiUpdate()
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
                    txtDiemDau.Value = null;
                    txtMaDanhMucTinhThanhDau.Value = null;
                    txtMaDanhMucTinhThanhDau.ID = null;
                    txtTenDanhMucTinhThanhDau.Value = null;
                    txtDiemCuoi.Value = null;
                    txtMaDanhMucTinhThanhCuoi.Value = null;
                    txtMaDanhMucTinhThanhCuoi.ID = null;
                    txtTenDanhMucTinhThanhCuoi.Value = null;
                    txtCuLy.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucTuyenVanTai
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    //
                    DiemDau = txtDiemDau.Value,
                    IDDanhMucTinhThanhDau = txtMaDanhMucTinhThanhDau.ID,
                    MaDanhMucTinhThanhDau = txtMaDanhMucTinhThanhDau.Value,
                    TenDanhMucTinhThanhDau = txtTenDanhMucTinhThanhDau.Value,
                    DiemCuoi = txtDiemCuoi.Value,
                    IDDanhMucTinhThanhCuoi = txtMaDanhMucTinhThanhCuoi.ID,
                    MaDanhMucTinhThanhCuoi = txtMaDanhMucTinhThanhCuoi.Value,
                    TenDanhMucTinhThanhCuoi = txtTenDanhMucTinhThanhCuoi.Value,
                    CuLy = txtCuLy.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucTuyenVanTai
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    //
                    DiemDau = txtDiemDau.Value,
                    IDDanhMucTinhThanhDau = txtMaDanhMucTinhThanhDau.ID,
                    MaDanhMucTinhThanhDau = txtMaDanhMucTinhThanhDau.Value,
                    TenDanhMucTinhThanhDau = txtTenDanhMucTinhThanhDau.Value,
                    DiemCuoi = txtDiemCuoi.Value,
                    IDDanhMucTinhThanhCuoi = txtMaDanhMucTinhThanhCuoi.ID,
                    MaDanhMucTinhThanhCuoi = txtMaDanhMucTinhThanhCuoi.Value,
                    TenDanhMucTinhThanhCuoi = txtTenDanhMucTinhThanhCuoi.Value,
                    CuLy = txtCuLy.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucTuyenVanTaiBUS _BUS = new cenBUS.cenLogistics.DanhMucTuyenVanTaiBUS();
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
            ////DanhMucTinhThanh
            //DanhMucDoiTuongBUS BUS = new DanhMucDoiTuongBUS();
            //DataTable dtTinhThanh = BUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTinhThanh)), null);

            //txtMaDanhMucTinhThanhDau.IsValid = true;
            //txtMaDanhMucTinhThanhDau.dtValid = dtTinhThanh;
            //txtMaDanhMucTinhThanhDau.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTinhThanh));
            //saTextBox[] txtMaDanhMucTinhThanhDauExt = new saTextBox[1];
            //txtMaDanhMucTinhThanhDauExt[0] = txtTenDanhMucTinhThanhDau;
            //txtMaDanhMucTinhThanhDau.txtMoRong = txtMaDanhMucTinhThanhDauExt;
            //txtMaDanhMucTinhThanhDau.ValidColumnName = "Ma";
            //txtMaDanhMucTinhThanhDau.ReturnedColumnsList = "Ten";
            //txtMaDanhMucTinhThanhDau.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);

            //txtMaDanhMucTinhThanhCuoi.IsValid = true;
            //txtMaDanhMucTinhThanhCuoi.dtValid = dtTinhThanh;
            //txtMaDanhMucTinhThanhCuoi.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTinhThanh));
            //saTextBox[] txtMaDanhMucTinhThanhCuoiExt = new saTextBox[1];
            //txtMaDanhMucTinhThanhCuoiExt[0] = txtTenDanhMucTinhThanhCuoi;
            //txtMaDanhMucTinhThanhCuoi.txtMoRong = txtMaDanhMucTinhThanhCuoiExt;
            //txtMaDanhMucTinhThanhCuoi.ValidColumnName = "Ma";
            //txtMaDanhMucTinhThanhCuoi.ReturnedColumnsList = "Ten";
            //txtMaDanhMucTinhThanhCuoi.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);

            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtDiemDau.Value = dataRow["DiemDau"];
                txtMaDanhMucTinhThanhDau.Value = dataRow["MaDanhMucTinhThanhDau"];
                txtMaDanhMucTinhThanhDau.ID = dataRow["IDDanhMucTinhThanhDau"];
                txtTenDanhMucTinhThanhDau.Value = dataRow["TenDanhMucTinhThanhDau"];
                txtDiemCuoi.Value = dataRow["DiemCuoi"];
                txtMaDanhMucTinhThanhCuoi.Value = dataRow["MaDanhMucTinhThanhCuoi"];
                txtMaDanhMucTinhThanhCuoi.ID = dataRow["IDDanhMucTinhThanhCuoi"];
                txtTenDanhMucTinhThanhCuoi.Value = dataRow["TenDanhMucTinhThanhCuoi"];
                txtCuLy.Value = dataRow["CuLy"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
