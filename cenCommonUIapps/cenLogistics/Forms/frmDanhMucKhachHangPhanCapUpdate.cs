using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucKhachHangPhanCapUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucKhachHangPhanCap obj = null;
        public object IDDanhMucKhachHang, MaDanhMucKhachHang, TenDanhMucKhachHang, DiaChiDanhMucKhachHang;
        public frmDanhMucKhachHangPhanCapUpdate()
        {
            InitializeComponent();
        }
        private void cboIDDanhMucKhachHangF1_Validated(object sender, EventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucKhachHangF1.Value) || !cboIDDanhMucKhachHangF1.IsItemInList()) { txtTenDanhMucKhachHangF1.Value = null; return; }
            DanhMucKhachHangBUS DanhMucKhachHangBUS = new DanhMucKhachHangBUS();
            DataTable dt = DanhMucKhachHangBUS.Valid(cboIDDanhMucKhachHangF1.Value, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtTenDanhMucKhachHangF1.Value = dt.Rows[0]["Ten"];
            }
        }

        private void cboIDDanhMucKhachHangF2_Validated(object sender, EventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucKhachHangF2.Value) || !cboIDDanhMucKhachHangF2.IsItemInList()) { txtTenDanhMucKhachHangF2.Value = null; return; }
            DanhMucKhachHangBUS DanhMucKhachHangBUS = new DanhMucKhachHangBUS();
            DataTable dt = DanhMucKhachHangBUS.Valid(cboIDDanhMucKhachHangF2.Value, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtTenDanhMucKhachHangF2.Value = dt.Rows[0]["Ten"];
            }
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
                    DanhMucKhachHangBUS DanhMucKhachHangBUS = new DanhMucKhachHangBUS();
                    DataTable dtKhachHang = DanhMucKhachHangBUS.Valid(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
                    cboIDDanhMucKhachHangF2.DataSource = dtKhachHang;
                    cboIDDanhMucKhachHangF2.ValueMember = "ID";
                    cboIDDanhMucKhachHangF2.DisplayMember = "Ten";
                    cboIDDanhMucKhachHangF1.DataSource = dtKhachHang;
                    cboIDDanhMucKhachHangF1.ValueMember = "ID";
                    cboIDDanhMucKhachHangF1.DisplayMember = "Ten";
                    CapNhat = coreCommon.ThaoTacDuLieu.Them;
                    //Xóa text box
                    txtMa.Value = null;
                    txtTen.Value = null;
                    txtDiaChi.Value = null;
                    cboIDDanhMucKhachHangF2.Value = null;
                    txtTenDanhMucKhachHangF2.Value = null;
                    cboIDDanhMucKhachHangF1.Value = null;
                    txtTenDanhMucKhachHangF1.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucKhachHangPhanCap
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    IDDanhMucKhachHang = IDDanhMucKhachHang,
                    IDDanhMucKhachHangF1 = cboIDDanhMucKhachHangF1.Value,
                    MaDanhMucKhachHangF1 = cboIDDanhMucKhachHangF1.Text,
                    TenDanhMucKhachHangF1 = txtTenDanhMucKhachHangF1.Value,
                    IDDanhMucKhachHangF2 = cboIDDanhMucKhachHangF2.Value,
                    MaDanhMucKhachHangF2 = cboIDDanhMucKhachHangF2.Text,
                    TenDanhMucKhachHangF2 = txtTenDanhMucKhachHangF2.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucKhachHangPhanCap
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    IDDanhMucKhachHang = IDDanhMucKhachHang,
                    IDDanhMucKhachHangF1 = cboIDDanhMucKhachHangF1.Value,
                    MaDanhMucKhachHangF1 = cboIDDanhMucKhachHangF1.Text,
                    TenDanhMucKhachHangF1 = txtTenDanhMucKhachHangF1.Value,
                    IDDanhMucKhachHangF2 = cboIDDanhMucKhachHangF2.Value,
                    MaDanhMucKhachHangF2 = cboIDDanhMucKhachHangF2.Text,
                    TenDanhMucKhachHangF2 = txtTenDanhMucKhachHangF2.Value,
                    GhiChu = txtGhiChu.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucKhachHangPhanCapBUS _BUS = new cenBUS.cenLogistics.DanhMucKhachHangPhanCapBUS();
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
            //DanhMucKhachHangF
            DanhMucKhachHangBUS DanhMucKhachHangBUS = new DanhMucKhachHangBUS();
            DataTable dtKhachHang = DanhMucKhachHangBUS.Valid(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
            cboIDDanhMucKhachHangF2.DataSource = dtKhachHang;
            cboIDDanhMucKhachHangF2.ValueMember = "ID";
            cboIDDanhMucKhachHangF2.DisplayMember = "Ma";
            cboIDDanhMucKhachHangF1.DataSource = dtKhachHang;
            cboIDDanhMucKhachHangF1.ValueMember = "ID";
            cboIDDanhMucKhachHangF1.DisplayMember = "Ma";
            //
            txtMa.Value = MaDanhMucKhachHang;
            txtTen.Value = TenDanhMucKhachHang;
            txtDiaChi.Value = DiaChiDanhMucKhachHang;
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {

                cboIDDanhMucKhachHangF1.Value = dataRow["IDDanhMucKhachHangF1"];
                txtTenDanhMucKhachHangF1.Value = dataRow["TenDanhMucKhachHangF1"];
                cboIDDanhMucKhachHangF2.Value = dataRow["IDDanhMucKhachHangF2"];
                txtTenDanhMucKhachHangF2.Value = dataRow["TenDanhMucKhachHangF2"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
