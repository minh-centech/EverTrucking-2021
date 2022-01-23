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
    public partial class frmDanhMucHangHoaUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucHangHoa obj = null;
        public frmDanhMucHangHoaUpdate()
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
                    txtMaDanhMucNhomHangVanChuyen.Value = null;
                    txtMaDanhMucNhomHangVanChuyen.ID = null;
                    txtTenDanhMucNhomHangVanChuyen.Value = null;
                    txtKichThuoc.Value = null;
                    txtDonViTinh.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucHangHoa
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    //
                    IDDanhMucNhomHangVanChuyen = txtMaDanhMucNhomHangVanChuyen.ID,
                    MaDanhMucNhomHangVanChuyen = txtMaDanhMucNhomHangVanChuyen.Value,
                    TenDanhMucNhomHangVanChuyen = txtTenDanhMucNhomHangVanChuyen.Value,
                    KichThuoc = txtKichThuoc.Value,
                    DonViTinh = txtDonViTinh.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucHangHoa
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    //
                    IDDanhMucNhomHangVanChuyen = txtMaDanhMucNhomHangVanChuyen.ID,
                    MaDanhMucNhomHangVanChuyen = txtMaDanhMucNhomHangVanChuyen.Value,
                    TenDanhMucNhomHangVanChuyen = txtTenDanhMucNhomHangVanChuyen.Value,
                    KichThuoc = txtKichThuoc.Value,
                    DonViTinh = txtDonViTinh.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucHangHoaBUS _BUS = new cenBUS.cenLogistics.DanhMucHangHoaBUS();
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
            //DanhMucDoiTuongBUS BUS = new DanhMucDoiTuongBUS();
            //DataTable dtNhomHangVanChuyen = BUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen)), null);
            //txtMaDanhMucNhomHangVanChuyen.IsValid = true;
            //txtMaDanhMucNhomHangVanChuyen.dtValid = dtNhomHangVanChuyen;
            //txtMaDanhMucNhomHangVanChuyen.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen));
            //saTextBox[] txtMaDanhMucNhomHangVanChuyenExt = new saTextBox[1];
            //txtMaDanhMucNhomHangVanChuyenExt[0] = txtTenDanhMucNhomHangVanChuyen;
            //txtMaDanhMucNhomHangVanChuyen.txtMoRong = txtMaDanhMucNhomHangVanChuyenExt;
            //txtMaDanhMucNhomHangVanChuyen.ValidColumnName = "Ma";
            //txtMaDanhMucNhomHangVanChuyen.ReturnedColumnsList = "Ten";
            //txtMaDanhMucNhomHangVanChuyen.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);

            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtMaDanhMucNhomHangVanChuyen.Value = dataRow["MaDanhMucNhomHangVanChuyen"];
                txtMaDanhMucNhomHangVanChuyen.ID = dataRow["IDDanhMucNhomHangVanChuyen"];
                txtTenDanhMucNhomHangVanChuyen.Value = dataRow["TenDanhMucNhomHangVanChuyen"];
                txtKichThuoc.Value = dataRow["KichThuoc"];
                txtDonViTinh.Value = dataRow["DonViTinh"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
