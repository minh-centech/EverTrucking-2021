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
    public partial class frmDanhMucTuyenVanTaiDinhMucChiPhiUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public object IDDanhMucTuyenVanTai = null;
        DanhMucTuyenVanTaiDinhMucChiPhi obj = null;
        public frmDanhMucTuyenVanTaiDinhMucChiPhiUpdate()
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
                    cboChieuVanTai.Value = null;
                    txtNgayApDung.Value = null;
                    txtMaDanhMucNhomXe.Value = null;
                    txtMaDanhMucNhomXe.ID = null;
                    txtTenDanhMucNhomXe.Value = null;
                    txtMaDanhMucChiPhiDieuVanThuongXuyen.Value = null;
                    txtMaDanhMucChiPhiDieuVanThuongXuyen.ID = null;
                    txtTenDanhMucChiPhiDieuVanThuongXuyen.Value = null;
                    txtSoLuong.Value = null;
                    txtSoTien.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucTuyenVanTaiDinhMucChiPhi
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    IDDanhMucTuyenVanTai = IDDanhMucTuyenVanTai,
                    //
                    ChieuVanTai = cboChieuVanTai.Value,
                    NgayApDung = txtNgayApDung.Value,
                    IDDanhMucNhomXe = txtMaDanhMucNhomXe.ID,
                    MaDanhMucNhomXe = txtMaDanhMucNhomXe.Value,
                    TenDanhMucNhomXe = txtTenDanhMucNhomXe.Value,
                    IDDanhMucChiPhiDieuVanThuongXuyen = txtMaDanhMucChiPhiDieuVanThuongXuyen.ID,
                    MaDanhMucChiPhiDieuVanThuongXuyen = txtMaDanhMucChiPhiDieuVanThuongXuyen.Value,
                    TenDanhMucChiPhiDieuVanThuongXuyen = txtTenDanhMucChiPhiDieuVanThuongXuyen.Value,
                    SoLuong = txtSoLuong.Value,
                    SoTien = txtSoTien.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucTuyenVanTaiDinhMucChiPhi
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    IDDanhMucTuyenVanTai = IDDanhMucTuyenVanTai,
                    //
                    ChieuVanTai = cboChieuVanTai.Value,
                    NgayApDung = txtNgayApDung.Value,
                    IDDanhMucNhomXe = txtMaDanhMucNhomXe.ID,
                    MaDanhMucNhomXe = txtMaDanhMucNhomXe.Value,
                    TenDanhMucNhomXe = txtTenDanhMucNhomXe.Value,
                    IDDanhMucChiPhiDieuVanThuongXuyen = txtMaDanhMucChiPhiDieuVanThuongXuyen.ID,
                    MaDanhMucChiPhiDieuVanThuongXuyen = txtMaDanhMucChiPhiDieuVanThuongXuyen.Value,
                    TenDanhMucChiPhiDieuVanThuongXuyen = txtTenDanhMucChiPhiDieuVanThuongXuyen.Value,
                    SoLuong = txtSoLuong.Value,
                    SoTien = txtSoTien.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucTuyenVanTaiDinhMucChiPhiBUS _BUS = new cenBUS.cenLogistics.DanhMucTuyenVanTaiDinhMucChiPhiBUS();
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
            //DataTable dtNhomXe = BUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomXe)), null);
            //txtMaDanhMucNhomXe.IsValid = true;
            //txtMaDanhMucNhomXe.dtValid = dtNhomXe;
            //txtMaDanhMucNhomXe.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomXe));
            //saTextBox[] txtMaDanhMucNhomXeExt = new saTextBox[1];
            //txtMaDanhMucNhomXeExt[0] = txtTenDanhMucNhomXe;
            //txtMaDanhMucNhomXe.txtMoRong = txtMaDanhMucNhomXeExt;
            //txtMaDanhMucNhomXe.ValidColumnName = "Ma";
            //txtMaDanhMucNhomXe.ReturnedColumnsList = "Ten";
            //txtMaDanhMucNhomXe.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);

            //BUS = new DanhMucDoiTuongBUS();
            //DataTable dtChiPhi = BUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongChiPhiDieuVanThuongXuyen)), null);
            //txtMaDanhMucChiPhiDieuVanThuongXuyen.IsValid = true;
            //txtMaDanhMucChiPhiDieuVanThuongXuyen.dtValid = dtChiPhi;
            //txtMaDanhMucChiPhiDieuVanThuongXuyen.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongChiPhiDieuVanThuongXuyen));
            //saTextBox[] txtMaDanhMucChiPhiExt = new saTextBox[1];
            //txtMaDanhMucChiPhiExt[0] = txtTenDanhMucChiPhiDieuVanThuongXuyen;
            //txtMaDanhMucChiPhiDieuVanThuongXuyen.txtMoRong = txtMaDanhMucChiPhiExt;
            //txtMaDanhMucChiPhiDieuVanThuongXuyen.ValidColumnName = "Ma";
            //txtMaDanhMucChiPhiDieuVanThuongXuyen.ReturnedColumnsList = "Ten";
            //txtMaDanhMucChiPhiDieuVanThuongXuyen.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);

            cboChieuVanTai.Items.Add("1", "Chiều đi");
            cboChieuVanTai.Items.Add("2", "Chiều về");

            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                cboChieuVanTai.Value = dataRow["ChieuVanTai"];
                txtNgayApDung.Value = dataRow["NgayApDung"];
                txtMaDanhMucNhomXe.Value = dataRow["MaDanhMucNhomXe"];
                txtMaDanhMucNhomXe.ID = dataRow["IDDanhMucNhomXe"];
                txtTenDanhMucNhomXe.Value = dataRow["TenDanhMucNhomXe"];
                txtMaDanhMucChiPhiDieuVanThuongXuyen.Value = dataRow["MaDanhMucChiPhiDieuVanThuongXuyen"];
                txtMaDanhMucChiPhiDieuVanThuongXuyen.ID = dataRow["IDDanhMucChiPhiDieuVanThuongXuyen"];
                txtTenDanhMucChiPhiDieuVanThuongXuyen.Value = dataRow["TenDanhMucChiPhiDieuVanThuongXuyen"];
                txtSoLuong.Value = dataRow["SoLuong"];
                txtSoTien.Value = dataRow["SoTien"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
