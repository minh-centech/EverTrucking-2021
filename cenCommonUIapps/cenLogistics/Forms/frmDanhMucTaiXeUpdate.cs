using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucTaiXeUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucTaiXe obj = null;
        public frmDanhMucTaiXeUpdate()
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
                    txtSoDienThoai.Value = null;
                    txtDiaChi.Value = null;
                    txtSoCMND.Value = null;
                    txtSoBangLai.Value = null;
                    cboIDDanhMucThauPhu.Value = null;
                    txtSoDienThoai.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucTaiXe
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    //
                    SoDienThoai = txtSoDienThoai.Value,
                    DiaChi = txtDiaChi.Value,
                    SoCMND = txtSoCMND.Value,
                    SoBangLai = txtSoBangLai.Value,
                    IDDanhMucThauPhu = cboIDDanhMucThauPhu.Value,
                    TenDanhMucThauPhu = txtTenDanhMucThauPhu.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucTaiXe
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    //
                    SoDienThoai = txtSoDienThoai.Value,
                    DiaChi = txtDiaChi.Value,
                    SoCMND = txtSoCMND.Value,
                    SoBangLai = txtSoBangLai.Value,
                    IDDanhMucThauPhu = cboIDDanhMucThauPhu.Value,
                    TenDanhMucThauPhu = txtTenDanhMucThauPhu.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucTaiXeBUS _BUS = new cenBUS.cenLogistics.DanhMucTaiXeBUS();
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
            //DanhMucThauPhu
            DanhMucThauPhuBUS DanhMucThauPhuBUS = new DanhMucThauPhuBUS();
            DataTable dtThauPhu = DanhMucThauPhuBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongThauPhu)), null, null);
            cboIDDanhMucThauPhu.DataSource = dtThauPhu;
            cboIDDanhMucThauPhu.ValueMember = "ID";
            cboIDDanhMucThauPhu.DisplayMember = "Ma";
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtSoDienThoai.Value = dataRow["SoDienThoai"];
                txtDiaChi.Value = dataRow["DiaChi"];
                txtSoCMND.Value = dataRow["SoCMND"];
                txtSoBangLai.Value = dataRow["SoBangLai"];
                cboIDDanhMucThauPhu.Value = dataRow["IDDanhMucThauPhu"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }

        }

        private void cboIDDanhMucThauPhu_ValueChanged(object sender, EventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucThauPhu.Value) || !cboIDDanhMucThauPhu.IsItemInList()) return;
            DanhMucThauPhuBUS DanhMucThauPhuBUS = new DanhMucThauPhuBUS();
            DataTable dt = DanhMucThauPhuBUS.List(cboIDDanhMucThauPhu.Value, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongThauPhu)), null, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtTenDanhMucThauPhu.Value = dt.Rows[0]["Ten"];
            }
        }
    }
}
