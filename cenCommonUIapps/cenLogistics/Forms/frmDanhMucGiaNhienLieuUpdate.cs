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
    public partial class frmDanhMucGiaNhienLieuUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucGiaNhienLieu obj = null;
        public frmDanhMucGiaNhienLieuUpdate()
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
                    txtNgayGioApDung.Value = null;
                    txtMaDanhMucNhienLieu.Value = null;
                    txtMaDanhMucNhienLieu.ID = null;
                    txtTenDanhMucNhienLieu.Value = null;
                    txtDonGiaTruocThue.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucGiaNhienLieu
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    //
                    NgayGioApDung = txtNgayGioApDung.Value,
                    IDDanhMucNhienLieu = txtMaDanhMucNhienLieu.ID,
                    MaDanhMucNhienLieu = txtMaDanhMucNhienLieu.Value,
                    TenDanhMucNhienLieu = txtTenDanhMucNhienLieu.Value,
                    DonGiaTruocThue = txtDonGiaTruocThue.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucGiaNhienLieu
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    //
                    NgayGioApDung = txtNgayGioApDung.Value,
                    IDDanhMucNhienLieu = txtMaDanhMucNhienLieu.ID,
                    MaDanhMucNhienLieu = txtMaDanhMucNhienLieu.Value,
                    TenDanhMucNhienLieu = txtTenDanhMucNhienLieu.Value,
                    DonGiaTruocThue = txtDonGiaTruocThue.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucGiaNhienLieuBUS _BUS = new cenBUS.cenLogistics.DanhMucGiaNhienLieuBUS();
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
            ////DanhMucNhomXe
            //DanhMucDoiTuongBUS BUS = new DanhMucDoiTuongBUS();
            //DataTable dtNhienLieu = BUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhienLieu)), null);
            //txtMaDanhMucNhienLieu.IsValid = true;
            //txtMaDanhMucNhienLieu.dtValid = dtNhienLieu;
            //txtMaDanhMucNhienLieu.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhienLieu));
            //saTextBox[] txtMaDanhMucNhienLieuExt = new saTextBox[1];
            //txtMaDanhMucNhienLieuExt[0] = txtTenDanhMucNhienLieu;
            //txtMaDanhMucNhienLieu.txtMoRong = txtMaDanhMucNhienLieuExt;
            //txtMaDanhMucNhienLieu.ValidColumnName = "Ma";
            //txtMaDanhMucNhienLieu.ReturnedColumnsList = "Ten";
            //txtMaDanhMucNhienLieu.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);

            txtNgayGioApDung.MaskInput = coreCommon.GlobalVariables.MaskInputDateTime;

            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                txtNgayGioApDung.Value = dataRow["NgayGioApDung"];
                txtMaDanhMucNhienLieu.Value = dataRow["MaDanhMucNhienLieu"];
                txtMaDanhMucNhienLieu.ID = dataRow["IDDanhMucNhienLieu"];
                txtTenDanhMucNhienLieu.Value = dataRow["TenDanhMucNhienLieu"];
                txtDonGiaTruocThue.Value = dataRow["DonGiaTruocThue"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
