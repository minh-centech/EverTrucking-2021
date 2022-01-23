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
    public partial class frmDanhMucDinhMucChiPhiHaiQuanUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucDinhMucChiPhiHaiQuan obj = null;
        public frmDanhMucDinhMucChiPhiHaiQuanUpdate()
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
                    txtMaDanhMucNhomHangVanChuyen.Value = null;
                    txtMaDanhMucNhomHangVanChuyen.ID = null;
                    txtTenDanhMucNhomHangVanChuyen.Value = null;
                    txtMaDanhMucHangHoa.Value = null;
                    txtMaDanhMucHangHoa.ID = null;
                    txtTenDanhMucHangHoa.Value = null;
                    txtMaDanhMucKhachHang.Value = null;
                    txtMaDanhMucKhachHang.ID = null;
                    txtTenDanhMucKhachHang.Value = null;
                    txtMaDanhMucChiPhiHaiQuanKinhDoanh.Value = null;
                    txtMaDanhMucChiPhiHaiQuanKinhDoanh.ID = null;
                    txtTenDanhMucChiPhiHaiQuanKinhDoanh.Value = null;
                    txtSoTien.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucDinhMucChiPhiHaiQuan
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    //
                    NgayApDung = txtNgayApDung.Value,
                    IDDanhMucNhomHangVanChuyen = txtMaDanhMucNhomHangVanChuyen.ID,
                    MaDanhMucNhomHangVanChuyen = txtMaDanhMucNhomHangVanChuyen.Value,
                    TenDanhMucNhomHangVanChuyen = txtTenDanhMucNhomHangVanChuyen.Value,
                    IDDanhMucHangHoa = txtMaDanhMucHangHoa.ID,
                    MaDanhMucHangHoa = txtMaDanhMucHangHoa.Value,
                    TenDanhMucHangHoa = txtTenDanhMucHangHoa.Value,
                    IDDanhMucKhachHang = txtMaDanhMucKhachHang.ID,
                    MaDanhMucKhachHang = txtMaDanhMucKhachHang.Value,
                    TenDanhMucKhachHang = txtTenDanhMucKhachHang.Value,
                    IDDanhMucChiPhiHaiQuanKinhDoanh = txtMaDanhMucChiPhiHaiQuanKinhDoanh.ID,
                    MaDanhMucChiPhiHaiQuanKinhDoanh = txtMaDanhMucChiPhiHaiQuanKinhDoanh.Value,
                    TenDanhMucChiPhiHaiQuanKinhDoanh = txtTenDanhMucChiPhiHaiQuanKinhDoanh.Value,
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
                obj = new cenDTO.cenLogistics.DanhMucDinhMucChiPhiHaiQuan
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    //
                    NgayApDung = txtNgayApDung.Value,
                    IDDanhMucNhomHangVanChuyen = txtMaDanhMucNhomHangVanChuyen.ID,
                    MaDanhMucNhomHangVanChuyen = txtMaDanhMucNhomHangVanChuyen.Value,
                    TenDanhMucNhomHangVanChuyen = txtTenDanhMucNhomHangVanChuyen.Value,
                    IDDanhMucHangHoa = txtMaDanhMucHangHoa.ID,
                    MaDanhMucHangHoa = txtMaDanhMucHangHoa.Value,
                    TenDanhMucHangHoa = txtTenDanhMucHangHoa.Value,
                    IDDanhMucKhachHang = txtMaDanhMucKhachHang.ID,
                    MaDanhMucKhachHang = txtMaDanhMucKhachHang.Value,
                    TenDanhMucKhachHang = txtTenDanhMucKhachHang.Value,
                    IDDanhMucChiPhiHaiQuanKinhDoanh = txtMaDanhMucChiPhiHaiQuanKinhDoanh.ID,
                    MaDanhMucChiPhiHaiQuanKinhDoanh = txtMaDanhMucChiPhiHaiQuanKinhDoanh.Value,
                    TenDanhMucChiPhiHaiQuanKinhDoanh = txtTenDanhMucChiPhiHaiQuanKinhDoanh.Value,
                    SoTien = txtSoTien.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucDinhMucChiPhiHaiQuanBUS _BUS = new cenBUS.cenLogistics.DanhMucDinhMucChiPhiHaiQuanBUS();
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
            //DataTable dtNhomHangVanChuyen = DanhMucDoiTuongBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen)), null);
            //txtMaDanhMucNhomHangVanChuyen.IsValid = true;
            //txtMaDanhMucNhomHangVanChuyen.dtValid = dtNhomHangVanChuyen;
            //txtMaDanhMucNhomHangVanChuyen.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen));
            //saTextBox[] txtMaDanhMucNhomHangVanChuyenExt = new saTextBox[1];
            //txtMaDanhMucNhomHangVanChuyenExt[0] = txtTenDanhMucNhomHangVanChuyen;
            //txtMaDanhMucNhomHangVanChuyen.txtMoRong = txtMaDanhMucNhomHangVanChuyenExt;
            //txtMaDanhMucNhomHangVanChuyen.ValidColumnName = "Ma";
            //txtMaDanhMucNhomHangVanChuyen.ReturnedColumnsList = "Ten";
            //txtMaDanhMucNhomHangVanChuyen.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);
            ////DanhMucHangHoa
            //DanhMucHangHoaBUS DanhMucHangHoaBUS = new DanhMucHangHoaBUS();
            //DataTable dtHangHoa = DanhMucHangHoaBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangHoa)), null, null);
            //txtMaDanhMucHangHoa.IsValid = true;
            //txtMaDanhMucHangHoa.dtValid = dtHangHoa;
            //txtMaDanhMucHangHoa.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangHoa));
            //saTextBox[] txtMaDanhMucHangHoaExt = new saTextBox[1];
            //txtMaDanhMucHangHoaExt[0] = txtTenDanhMucHangHoa;
            //txtMaDanhMucHangHoa.txtMoRong = txtMaDanhMucHangHoaExt;
            //txtMaDanhMucHangHoa.ValidColumnName = "Ma";
            //txtMaDanhMucHangHoa.ReturnedColumnsList = "Ten";
            //txtMaDanhMucHangHoa.procedureName = DanhMucHangHoa.listProcedureName;
            //txtMaDanhMucHangHoa.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);
            ////DanhMucKhachHang
            //DanhMucKhachHangBUS DanhMucKhachHangBUS = new DanhMucKhachHangBUS();
            //DataTable dtKhachHang = DanhMucKhachHangBUS.Valid(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
            //txtMaDanhMucKhachHang.IsValid = true;
            //txtMaDanhMucKhachHang.dtValid = dtKhachHang;
            //txtMaDanhMucKhachHang.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang));
            //saTextBox[] txtMaDanhMucKhachHangExt = new saTextBox[1];
            //txtMaDanhMucKhachHangExt[0] = txtTenDanhMucKhachHang;
            //txtMaDanhMucKhachHang.txtMoRong = txtMaDanhMucKhachHangExt;
            //txtMaDanhMucKhachHang.ValidColumnName = "Ma";
            //txtMaDanhMucKhachHang.ReturnedColumnsList = "Ten";
            //txtMaDanhMucKhachHang.procedureName = DanhMucKhachHang.listProcedureName;
            //txtMaDanhMucKhachHang.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);
            ////DanhMucChiPhiHaiQuanKinhDoanh
            //BUS = new DanhMucDoiTuongBUS();
            //DataTable dtChiPhiHaiQuanKinhDoanh = BUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongChiPhiHaiQuanKinhDoanh)), null);
            //txtMaDanhMucChiPhiHaiQuanKinhDoanh.IsValid = true;
            //txtMaDanhMucChiPhiHaiQuanKinhDoanh.dtValid = dtChiPhiHaiQuanKinhDoanh;
            //txtMaDanhMucChiPhiHaiQuanKinhDoanh.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongChiPhiHaiQuanKinhDoanh));
            //saTextBox[] txtMaDanhMucChiPhiHaiQuanKinhDoanhExt = new saTextBox[1];
            //txtMaDanhMucChiPhiHaiQuanKinhDoanhExt[0] = txtTenDanhMucChiPhiHaiQuanKinhDoanh;
            //txtMaDanhMucChiPhiHaiQuanKinhDoanh.txtMoRong = txtMaDanhMucChiPhiHaiQuanKinhDoanhExt;
            //txtMaDanhMucChiPhiHaiQuanKinhDoanh.ValidColumnName = "Ma";
            //txtMaDanhMucChiPhiHaiQuanKinhDoanh.ReturnedColumnsList = "Ten";
            //txtMaDanhMucChiPhiHaiQuanKinhDoanh.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);


            txtNgayApDung.MaskInput = coreCommon.GlobalVariables.MaskInputDate;

            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                txtNgayApDung.Value = dataRow["NgayApDung"];
                txtMaDanhMucNhomHangVanChuyen.Value = dataRow["MaDanhMucNhomHangVanChuyen"];
                txtMaDanhMucNhomHangVanChuyen.ID = dataRow["IDDanhMucNhomHangVanChuyen"];
                txtTenDanhMucNhomHangVanChuyen.Value = dataRow["TenDanhMucNhomHangVanChuyen"];
                txtMaDanhMucHangHoa.Value = dataRow["MaDanhMucHangHoa"];
                txtMaDanhMucHangHoa.ID = dataRow["IDDanhMucHangHoa"];
                txtTenDanhMucHangHoa.Value = dataRow["TenDanhMucHangHoa"];
                txtMaDanhMucKhachHang.Value = dataRow["MaDanhMucKhachHang"];
                txtMaDanhMucKhachHang.ID = dataRow["IDDanhMucKhachHang"];
                txtTenDanhMucKhachHang.Value = dataRow["TenDanhMucKhachHang"];
                txtMaDanhMucChiPhiHaiQuanKinhDoanh.Value = dataRow["MaDanhMucChiPhiHaiQuanKinhDoanh"];
                txtMaDanhMucChiPhiHaiQuanKinhDoanh.ID = dataRow["IDDanhMucChiPhiHaiQuanKinhDoanh"];
                txtTenDanhMucChiPhiHaiQuanKinhDoanh.Value = dataRow["TenDanhMucChiPhiHaiQuanKinhDoanh"];
                txtSoTien.Value = dataRow["SoTien"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
