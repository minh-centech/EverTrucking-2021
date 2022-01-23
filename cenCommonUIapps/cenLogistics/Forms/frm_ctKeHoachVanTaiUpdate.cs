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
    public partial class frm_ctKeHoachVanTaiUpdate : coreBase.BaseForms.frmBaseChungTuSingleUpdate
    {
        object FileContent;
        ctHopDongVanChuyen obj = null;
        public frm_ctKeHoachVanTaiUpdate()
        {
            InitializeComponent();
            this.groupEditor.Width = 1004;
            this.groupEditor.Height = 562;
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
                    txtSoHopDong.Value = null;
                    txtNgayHopDong.Value = DateTime.Now;
                    txtNgayCoHieuLuc.Value = null;
                    txtNgayHetHieuLuc.Value = null;
                    txtMaDanhMucKhachHang.Value = null;
                    txtMaDanhMucKhachHang.ID = null;
                    txtTenDanhMucKhachHang.Value = null;
                    txtSoTien.Value = null;
                    txtNoiDung.Value = null;
                    cboTrangThaiThucHien.Value = 0;
                    txtFileName.Value = null;
                    FileContent = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Them || UpdateMode == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.ctHopDongVanChuyen
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    IDDanhMucChungTuTrangThai = cboIDDanhMucTrangThaiChungTu.Value,
                    So = txtSo.Value,
                    NgayLap = txtNgayLap.Value,
                    SoHopDong = txtSoHopDong.Value,
                    NgayHopDong = txtNgayHopDong.Value,
                    NgayCoHieuLuc = txtNgayCoHieuLuc.Value,
                    NgayHetHieuLuc = txtNgayHetHieuLuc.Value,
                    IDDanhMucKhachHang = txtMaDanhMucKhachHang.ID,
                    MaDanhMucKhachHang = txtMaDanhMucKhachHang.Value,
                    TenDanhMucKhachHang = txtTenDanhMucKhachHang.Value,
                    NoiDung = txtNoiDung.Value,
                    SoTien = txtSoTien.Value,
                    TrangThaiHopDong = cboTrangThaiThucHien.Value,
                    FileName = txtFileName.Value,
                    FileContent = FileContent,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.ctHopDongVanChuyen
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    IDDanhMucChungTuTrangThai = cboIDDanhMucTrangThaiChungTu.Value,
                    So = txtSo.Value,
                    NgayLap = txtNgayLap.Value,
                    SoHopDong = txtSoHopDong.Value,
                    NgayHopDong = txtNgayHopDong.Value,
                    NgayCoHieuLuc = txtNgayCoHieuLuc.Value,
                    NgayHetHieuLuc = txtNgayHetHieuLuc.Value,
                    IDDanhMucKhachHang = txtMaDanhMucKhachHang.ID,
                    MaDanhMucKhachHang = txtMaDanhMucKhachHang.Value,
                    TenDanhMucKhachHang = txtTenDanhMucKhachHang.Value,
                    NoiDung = txtNoiDung.Value,
                    SoTien = txtSoTien.Value,
                    TrangThaiHopDong = cboTrangThaiThucHien.Value,
                    FileName = txtFileName.Value,
                    FileContent = !coreCommon.coreCommon.IsNull(FileContent) ? FileContent : null,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.ctHopDongVanChuyenBUS _BUS = new cenBUS.cenLogistics.ctHopDongVanChuyenBUS();
            bool OK = (UpdateMode == 1 || UpdateMode == 3) ? _BUS.Insert(ref obj) : _BUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = ctKeHoachVanTaiBUS.ListDisplay(IDDanhMucChungTu, TuNgay, DenNgay, obj.ID);
                if (UpdateMode == coreCommon.ThaoTacDuLieu.Them)
                {
                    InsertToList();
                }
                else
                {
                    UpdateToList();
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
            coreUI.coreUI.validData.SetValidComboEditor(cboIDDanhMucTrangThaiChungTu, new Func<DataTable>(() => coreBUS.DanhMucChungTuTrangThaiBUS.List(null, IDDanhMucChungTu)), null, "Ten", "ID");
            //
            if (cboIDDanhMucTrangThaiChungTu.Items.Count > 0) cboIDDanhMucTrangThaiChungTu.SelectedItem = cboIDDanhMucTrangThaiChungTu.Items[0];
            txtNgayLap.Value = DateTime.Now;
            txtNgayHopDong.Value = DateTime.Now;
            cboTrangThaiThucHien.Value = 0;
            txtFileName.Value = null;
            FileContent = null;
            if (UpdateMode >= coreCommon.ThaoTacDuLieu.Sua)
            {

                txtSo.Value = dataRow["So"];
                txtNgayLap.Value = dataRow["NgayLap"];
                cboIDDanhMucTrangThaiChungTu.Value = dataRow["IDDanhMucChungTuTrangThai"];
                txtMaDanhMucKhachHang.Value = dataRow["MaDanhMucKhachHang"];
                txtMaDanhMucKhachHang.ID = dataRow["IDDanhMucKhachHang"];
                txtTenDanhMucKhachHang.Value = dataRow["TenDanhMucKhachHang"];
                txtNoiDung.Value = dataRow["NoiDung"];
                txtSoTien.Value = dataRow["SoTien"];
                cboTrangThaiThucHien.Value = dataRow["TrangThaiHopDong"];
                txtFileName.Value = dataRow["FileName"];
                txtGhiChu.Value = dataRow["GhiChu"];
                //Load hình ảnh
                ctHopDongVanChuyenBUS ctHopDongVanChuyenBUS = new ctHopDongVanChuyenBUS();
                DataTable dtFileContent = ctHopDongVanChuyenBUS.ListFileContent(dataRow["ID"]);
                if (dtFileContent.Rows.Count > 0)
                {
                    FileContent = dtFileContent.Rows[0]["FileContent"];
                }
            }
        }
    }
}
