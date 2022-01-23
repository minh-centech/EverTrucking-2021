using coreBase.BaseForms;
using cenBUS.cenLogistics;
using coreBUS;
using coreControls;
using cenDTO.cenLogistics;
using coreDTO;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static cenCommonUIapps.cenCommonUIapps;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctDonHangCoTamUngUpdate : frmBaseChungTuMasterDetail
    {
        public Form mdiParent;
        DataTable dtTrangThai, dtSale, dtKhachHang, dtNhomHangVanChuyen, dtHangHoa, dtHangTau, dtDiaDiemGiaoNhan;
        ctDonHang obj;
        ctDonHangBUS bus;
        public frm_ctDonHangCoTamUngUpdate()
        {
            InitializeComponent();
        }
        #region Methods
        protected void loadValidDataSet()
        {
            //Load danh mục chứng từ trạng thái
            dtTrangThai = DanhMucChungTuTrangThaiBUS.List(null, IDDanhMucChungTu);
            cboIDDanhMucTrangThaiChungTu.DataSource = dtTrangThai;
            cboIDDanhMucTrangThaiChungTu.ValueMember = "ID";
            cboIDDanhMucTrangThaiChungTu.DisplayMember = "Ten";
            ////Sale
            //DanhMucNhanSuBUS DanhMucNhanSuBUS = new DanhMucNhanSuBUS();
            //dtSale = DanhMucNhanSuBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu)), null);
            //cboIDDanhMucSale.dtValid = dtSale;
            //cboIDDanhMucSale.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu));
            //cboIDDanhMucSale.procedureName = DanhMucNhanSu.listProcedureName;
            //cboIDDanhMucSale.DataSource = dtSale;
            //cboIDDanhMucSale.ValueMember = "ID";
            //cboIDDanhMucSale.DisplayMember = "Ten";
            //this.cboIDDanhMucSale.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);
            ////DanhMucKhachHang
            //DanhMucKhachHangBUS KhachHangBUS = new DanhMucKhachHangBUS();
            //dtKhachHang = KhachHangBUS.ValidF1((dsChungTu.Tables[ctDonHang.tableName].Rows.Count > 0) ? dsChungTu.Tables[ctDonHang.tableName].Rows[0]["IDDanhMucKhachHang"] : null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
            //txtMaDanhMucKhachHang.IsValid = true;
            //txtMaDanhMucKhachHang.dtValid = dtKhachHang;
            //txtMaDanhMucKhachHang.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang));
            //saTextBox[] txtMaDanhMucKhachHangExt = new saTextBox[3];
            //txtMaDanhMucKhachHangExt[0] = txtTenDanhMucKhachHang;
            //txtMaDanhMucKhachHangExt[1] = txtIDDanhMucNhanSu;
            //txtMaDanhMucKhachHangExt[2] = txtMaSoThue;
            //txtMaDanhMucKhachHang.txtMoRong = txtMaDanhMucKhachHangExt;
            //txtMaDanhMucKhachHang.ValidColumnName = "Ma";
            //txtMaDanhMucKhachHang.ReturnedColumnsList = "Ten;IDDanhMucNhanSu;MaSoThue";
            //txtMaDanhMucKhachHang.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);

            cboIDDanhMucKhachHangF2.DataSource = null;
            cboIDDanhMucKhachHangF2.ValueMember = "ID";
            cboIDDanhMucKhachHangF2.DisplayMember = "Ten";

            cboIDDanhMucKhachHangF3DongHang.DataSource = null;
            cboIDDanhMucKhachHangF3DongHang.ValueMember = "ID";
            cboIDDanhMucKhachHangF3DongHang.DisplayMember = "Ten";
            cboDiaChiDongHang.DataSource = null;
            cboDiaChiDongHang.ValueMember = "ID";
            cboDiaChiDongHang.DisplayMember = "DiaChi";

            cboIDDanhMucKhachHangF3TraHang.DataSource = null;
            cboIDDanhMucKhachHangF3TraHang.ValueMember = "ID";
            cboIDDanhMucKhachHangF3TraHang.DisplayMember = "Ten";
            cboDiaChiTraHang.DataSource = null;
            cboDiaChiTraHang.ValueMember = "ID";
            cboDiaChiTraHang.DisplayMember = "DiaChi";

            //LoaiHang
            cboLoaiHang.Items.Add("1", "Nhập");
            cboLoaiHang.Items.Add("2", "Xuất");
            cboLoaiHang.Items.Add("3", "Nội địa");
            ////Nhóm hàng vận chuyển
            //DanhMucDoiTuongBUS DanhMucNhomHangVanChuyenBUS = new DanhMucDoiTuongBUS();
            //dtNhomHangVanChuyen = DanhMucNhomHangVanChuyenBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen)), null);
            //cboIDDanhMucNhomHangVanChuyen.dtValid = dtNhomHangVanChuyen;
            //cboIDDanhMucNhomHangVanChuyen.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhomHangVanChuyen));
            //cboIDDanhMucNhomHangVanChuyen.procedureName = DanhMucDoiTuong.listProcedureName;
            //cboIDDanhMucNhomHangVanChuyen.DataSource = dtNhomHangVanChuyen;
            //cboIDDanhMucNhomHangVanChuyen.ValueMember = "ID";
            //cboIDDanhMucNhomHangVanChuyen.DisplayMember = "Ten";
            //this.cboIDDanhMucNhomHangVanChuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);
            ////Hãng Tàu
            //DanhMucDoiTuongBUS DanhMucHangTauBUS = new DanhMucDoiTuongBUS();
            //dtHangTau = DanhMucHangTauBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangTau)), null);
            //cboIDDanhMucHangTau.dtValid = dtHangTau;
            //cboIDDanhMucHangTau.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangTau));
            //cboIDDanhMucHangTau.procedureName = DanhMucDoiTuong.listProcedureName;
            //cboIDDanhMucHangTau.DataSource = dtHangTau;
            //cboIDDanhMucHangTau.ValueMember = "ID";
            //cboIDDanhMucHangTau.DisplayMember = "Ten";
            //this.cboIDDanhMucHangTau.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);
            ////Hàng hóa
            //DanhMucHangHoaBUS DanhMucHangHoaBUS = new DanhMucHangHoaBUS();
            //dtHangHoa = DanhMucHangHoaBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangHoa)), null, null);
            //cboIDDanhMucHangHoa.dtValid = dtHangHoa;
            //cboIDDanhMucHangHoa.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangHoa));
            //cboIDDanhMucHangHoa.procedureName = DanhMucHangHoa.listProcedureName;
            //cboIDDanhMucHangHoa.DataSource = dtHangHoa;
            //cboIDDanhMucHangHoa.ValueMember = "ID";
            //cboIDDanhMucHangHoa.DisplayMember = "Ten";
            //this.cboIDDanhMucHangHoa.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);
            ////Địa điểm lất/trả cont/hàng
            //DanhMucDiaDiemGiaoNhanBUS DanhMucDiaDiemGiaoNhanBUS = new DanhMucDiaDiemGiaoNhanBUS();
            //dtDiaDiemGiaoNhan = DanhMucDiaDiemGiaoNhanBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongCangICD)), null, null);
            //cboIDDanhMucDiaDiemLayContHang.dtValid = dtDiaDiemGiaoNhan;
            //cboIDDanhMucDiaDiemLayContHang.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongCangICD));
            //cboIDDanhMucDiaDiemLayContHang.procedureName = DanhMucDoiTuong.listProcedureName;
            //cboIDDanhMucDiaDiemLayContHang.DataSource = dtDiaDiemGiaoNhan;
            //cboIDDanhMucDiaDiemLayContHang.ValueMember = "ID";
            //cboIDDanhMucDiaDiemLayContHang.DisplayMember = "Ten";
            //this.cboIDDanhMucDiaDiemLayContHang.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);
            //cboIDDanhMucDiaDiemTraContHang.dtValid = dtDiaDiemGiaoNhan;
            //cboIDDanhMucDiaDiemTraContHang.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongCangICD));
            //cboIDDanhMucDiaDiemTraContHang.procedureName = DanhMucDoiTuong.listProcedureName;
            //cboIDDanhMucDiaDiemTraContHang.DataSource = dtDiaDiemGiaoNhan;
            //cboIDDanhMucDiaDiemTraContHang.ValueMember = "ID";
            //cboIDDanhMucDiaDiemTraContHang.DisplayMember = "Ten";
            //this.cboIDDanhMucDiaDiemTraContHang.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);
            ////Tuyến vận tải
            //DanhMucTuyenVanTaiBUS DanhMucTuyenVanTaiBUS = new DanhMucTuyenVanTaiBUS();
            //DataTable dtTuyenVanTai = DanhMucTuyenVanTaiBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTai)), null).Tables[DanhMucTuyenVanTai.tableName];
            //cboIDDanhMucTuyenVanTai.dtValid = dtTuyenVanTai;
            //cboIDDanhMucTuyenVanTai.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTuyenVanTai));
            //cboIDDanhMucTuyenVanTai.procedureName = DanhMucTuyenVanTai.listProcedureName;
            //cboIDDanhMucTuyenVanTai.DataSource = dtTuyenVanTai;
            //cboIDDanhMucTuyenVanTai.ValueMember = "ID";
            //cboIDDanhMucTuyenVanTai.DisplayMember = "Ten";
            //this.cboIDDanhMucTuyenVanTai.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);
        }
        protected void loadData()
        {
            bus = new ctDonHangBUS();
            dsChungTu = bus.List((UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? DBNull.Value : IDDanhMucChungTu, (UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? DBNull.Value : IDChungTu);
            bsChungTu = new BindingSource();
            bsChungTu.DataSource = dsChungTu;
            bsChungTu.DataMember = ctDonHang.tableName;
            bsChungTuChiTiet = new BindingSource();
            bsChungTuChiTiet.DataSource = bsChungTu;
            bsChungTuChiTiet.DataMember = coreCommon.GlobalVariables.prefix_DataRelation + ctDonHang.tableNameChiTiet;
            ugChiTiet.HiddenColumnsList = "[LanTamUng]";
            ugChiTiet.ReadOnlyColumnsList = "[TenDanhMucCanBoTamUng][TenDanhMucHangTau]";
            ugChiTiet.DataSource = bsChungTuChiTiet;
            ugChiTiet.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.Default; //Biểu tượng lọc đặt trên tiêu đề cột
            tabChiTiet.Tabs["ChiTiet"].Text = coreCommon.coreCommon.TraTuDien(ctDonHang.tableNameChiTiet) + "-CTRL + INSERT: Thêm dòng; CTRL + DELETE: Xóa dòng";
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Copy)
            {
                dsChungTu.Tables[ctDonHang.tableName].Rows[0]["So"] = DBNull.Value;
            }
        }
        protected override void themChungTu()
        {
            bsChungTu.AddNew();

            ugChiTiet.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            ugChiTiet.DisplayLayout.Bands[0].Columns["MaDanhMucCanBoTamUng"].CellClickAction = CellClickAction.EditAndSelectText;
            ugChiTiet.DisplayLayout.Bands[0].Columns["MaDanhMucCanBoTamUng"].CellActivation = Activation.AllowEdit;

            txtNgayLap.Value = coreCommon.coreCommon.NgayHachToan();
            txtNgayCatMang.Value = coreCommon.coreCommon.NgayHachToan();
            txtSoLuong.Value = 1;

            if (cboIDDanhMucTrangThaiChungTu.Items.Count > 0)
                cboIDDanhMucTrangThaiChungTu.SelectedItem = cboIDDanhMucTrangThaiChungTu.Items[0];

            UpdateMode = coreCommon.ThaoTacDuLieu.Them;
            enableControl();


            bsChungTuChiTiet.AddNew();
        }
        protected override void suaChungTu()
        {
            base.suaChungTu();
            //
            UpdateMode = 2;
            enableControl();
            //
            txtNgayDongHang.Focus();
            txtMaDanhMucKhachHang.ID = dsChungTu.Tables[ctDonHang.tableName].Rows[0]["IDDanhMucKhachHang"];
        }
        protected void setCustomsDataBindings()
        {
            cboIDDanhMucSale.DataBindings.Clear();
            cboIDDanhMucSale.DataBindings.Add("Value", bsChungTu, "IDDanhMucSale", false, DataSourceUpdateMode.OnPropertyChanged);
            txtMaDanhMucKhachHang.SetDataBinding(bsChungTu, "MaDanhMucKhachHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDanhMucKhachHang.SetDataBinding(bsChungTu, "TenDanhMucKhachHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtMaSoThue.SetDataBinding(bsChungTu, "MaSoThue", false, DataSourceUpdateMode.OnPropertyChanged);
            cboIDDanhMucKhachHangF2.DataBindings.Add("Value", bsChungTu, "IDDanhMucKhachHangF2", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDebitNote.SetDataBinding(bsChungTu, "DebitNote", false, DataSourceUpdateMode.OnPropertyChanged);
            txtBillBooking.SetDataBinding(bsChungTu, "BillBooking", false, DataSourceUpdateMode.OnPropertyChanged);
            cboLoaiHang.DataBindings.Clear();
            cboLoaiHang.DataBindings.Add("Value", bsChungTu, "LoaiHang", false, DataSourceUpdateMode.OnPropertyChanged);
            cboIDDanhMucNhomHangVanChuyen.DataBindings.Clear();
            cboIDDanhMucNhomHangVanChuyen.DataBindings.Add("Value", bsChungTu, "IDDanhMucNhomHangVanChuyen", false, DataSourceUpdateMode.OnPropertyChanged);
            cboIDDanhMucHangHoa.DataBindings.Clear();
            cboIDDanhMucHangHoa.DataBindings.Add("Value", bsChungTu, "IDDanhMucHangHoa", false, DataSourceUpdateMode.OnPropertyChanged);
            cboIDDanhMucHangTau.DataBindings.Clear();
            cboIDDanhMucHangTau.DataBindings.Add("Value", bsChungTu, "IDDanhMucHangTau", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoLuong.SetDataBinding(bsChungTu, "SoLuong", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTrongLuong.SetDataBinding(bsChungTu, "KhoiLuong", false, DataSourceUpdateMode.OnPropertyChanged);
            txtKhoiLuong.SetDataBinding(bsChungTu, "TheTich", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoContainer.SetDataBinding(bsChungTu, "SoContainer", false, DataSourceUpdateMode.OnPropertyChanged);
            cboIDDanhMucDiaDiemLayContHang.DataBindings.Clear();
            cboIDDanhMucDiaDiemLayContHang.DataBindings.Add("Value", bsChungTu, "IDDanhMucDiaDiemLayContHang", false, DataSourceUpdateMode.OnPropertyChanged);
            cboIDDanhMucDiaDiemTraContHang.DataBindings.Clear();
            cboIDDanhMucDiaDiemTraContHang.DataBindings.Add("Value", bsChungTu, "IDDanhMucDiaDiemTraContHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtNgayDongHang.SetDataBinding(bsChungTu, "NgayDongHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtGioDongHang.SetDataBinding(bsChungTu, "GioDongHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtNgayTraHang.SetDataBinding(bsChungTu, "NgayTraHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtGioTraHang.SetDataBinding(bsChungTu, "GioTraHang", false, DataSourceUpdateMode.OnPropertyChanged);
            cboIDDanhMucKhachHangF3DongHang.DataBindings.Clear();
            cboIDDanhMucKhachHangF3DongHang.DataBindings.Add("Value", bsChungTu, "IDDanhMucKhachHangF3DongHang", false, DataSourceUpdateMode.OnPropertyChanged);
            cboDiaChiDongHang.DataBindings.Clear();
            cboDiaChiDongHang.DataBindings.Add("Value", bsChungTu, "IDDanhMucKhachHangF3DongHang", false, DataSourceUpdateMode.OnPropertyChanged);
            cboIDDanhMucKhachHangF3TraHang.DataBindings.Clear();
            cboIDDanhMucKhachHangF3TraHang.DataBindings.Add("Value", bsChungTu, "IDDanhMucKhachHangF3TraHang", false, DataSourceUpdateMode.OnPropertyChanged);
            cboDiaChiTraHang.DataBindings.Clear();
            cboDiaChiTraHang.DataBindings.Add("Value", bsChungTu, "IDDanhMucKhachHangF3TraHang", false, DataSourceUpdateMode.OnPropertyChanged);
            cboIDDanhMucTuyenVanTai.DataBindings.Clear();
            cboIDDanhMucTuyenVanTai.DataBindings.Add("Value", bsChungTu, "IDDanhMucTuyenVanTai", false, DataSourceUpdateMode.OnPropertyChanged);
            txtNgayCatMang.SetDataBinding(bsChungTu, "NgayCatMang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtNgayCatMang.SetDataBinding(bsChungTu, "GioCatMang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtNguoiGiaoNhan.SetDataBinding(bsChungTu, "NguoiGiaoNhan", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoDienThoaiGiaoNhan.SetDataBinding(bsChungTu, "SoDienThoaiGiaoNhan", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienCuoc.SetDataBinding(bsChungTu, "SoTienCuoc", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienThuTuc.SetDataBinding(bsChungTu, "SoTienThuTuc", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienDoanhThuKhac.SetDataBinding(bsChungTu, "SoTienDoanhThuKhac", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienHoaHong.SetDataBinding(bsChungTu, "SoTienHoaHong", false, DataSourceUpdateMode.OnPropertyChanged);
            txtThoiHanThanhToan.SetDataBinding(bsChungTu, "ThoiHanThanhToan", false, DataSourceUpdateMode.OnPropertyChanged);
            txtGhiChu.SetDataBinding(bsChungTu, "GhiChu", false, DataSourceUpdateMode.OnPropertyChanged);
            //
            txtTongSoTienCuocVo.SetDataBinding(bsChungTu, "TongSoTienTamUngCuocVo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTongSoTienHaiQuan.SetDataBinding(bsChungTu, "TongSoTienTamUngHaiQuan", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTongSoTienNangHa.SetDataBinding(bsChungTu, "TongSoTienTamUngNangHa", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTongSoTienChiKhac.SetDataBinding(bsChungTu, "TongSoTienTamUngChiKhac", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected override void gridColumnDataProcess(UltraGrid ug, UltraGridCell uCell, out bool GridValidation, bool ShowLookUp)
        {
            GridValidation = true;
            if (uCell.Row.IsFilterRow) return;
            String columnKey = uCell.Column.Key.ToUpper();
            //if (columnKey == "MADANHMUCHANGTAU")
            //{
            //    GridValidation = false;
            //    //Valid đơn vị tính
            //    DanhMucDoiTuongBUS bus = new DanhMucDoiTuongBUS();
            //    DataTable dt = bus.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangTau)), uCell.Value); ;
            //    if (dt == null) { GridValidation = true; return; }
            //    if (dt.Rows.Count == 1)
            //    {
            //        uCell.Row.Cells["IDDanhMucHangTau"].Value = dt.Rows[0]["ID"].ToString();
            //        uCell.Row.Cells["MaDanhMucHangTau"].Value = dt.Rows[0]["Ma"].ToString();
            //        uCell.Row.Cells["TenDanhMucHangTau"].Value = dt.Rows[0]["Ten"].ToString();
            //        GridValidation = true;
            //        return;
            //    }
            //    else
            //    {
            //        //Show valid form
            //        DatabaseCore.Forms.frmDanhMucDoiTuongValid frmDanhMucDoiTuongValid = new DatabaseCore.Forms.frmDanhMucDoiTuongValid()
            //        {
            //            IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangTau)),
            //            validValue = uCell.Row.Cells["MaDanhMucHangTau"].Value,
            //            dataTable = dt
            //        };
            //        frmDanhMucDoiTuongValid.ShowDialog();
            //        if (frmDanhMucDoiTuongValid.dataRows == null || frmDanhMucDoiTuongValid.dataRows.Count == 0) { GridValidation = true; return; }
            //        if (frmDanhMucDoiTuongValid.dataRows.Count > 0)
            //        {
            //            uCell.Row.Cells["IDDanhMucHangTau"].Value = frmDanhMucDoiTuongValid.dataRows[0]["ID"].ToString();
            //            uCell.Row.Cells["MaDanhMucHangTau"].Value = frmDanhMucDoiTuongValid.dataRows[0]["Ma"].ToString();
            //            uCell.Row.Cells["TenDanhMucHangTau"].Value = frmDanhMucDoiTuongValid.dataRows[0]["Ten"].ToString();
            //        }
            //    }
            //    GridValidation = true;
            //    return;
            //}
            //else if (columnKey == "MADANHMUCCANBOTAMUNG")
            //{
            //    GridValidation = false;
            //    //Valid đơn vị tính
            //    DanhMucDoiTuongBUS bus = new DanhMucDoiTuongBUS();
            //    DataTable dt = bus.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu)), uCell.Value);
            //    if (dt == null) { GridValidation = true; return; }
            //    if (dt.Rows.Count == 1)
            //    {
            //        uCell.Row.Cells["IDDanhMucCanBoTamUng"].Value = dt.Rows[0]["ID"].ToString();
            //        uCell.Row.Cells["MaDanhMucCanBoTamUng"].Value = dt.Rows[0]["Ma"].ToString();
            //        uCell.Row.Cells["TenDanhMucCanBoTamUng"].Value = dt.Rows[0]["Ten"].ToString();
            //        GridValidation = true;
            //        return;
            //    }
            //    else
            //    {
            //        //Show valid form
            //        frmDanhMucNhanSuValid frmDanhMucNhanSuValid = new frmDanhMucNhanSuValid()
            //        {
            //            IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu)),
            //            validValue = uCell.Row.Cells["MaDanhMucCanBoTamUng"].Value,
            //            dataTable = dt
            //        };
            //        frmDanhMucNhanSuValid.ShowDialog();
            //        if (frmDanhMucNhanSuValid.dataRows == null || frmDanhMucNhanSuValid.dataRows.Count == 0) { GridValidation = true; return; }
            //        if (frmDanhMucNhanSuValid.dataRows.Count > 0)
            //        {
            //            uCell.Row.Cells["IDDanhMucCanBoTamUng"].Value = frmDanhMucNhanSuValid.dataRows[0]["ID"].ToString();
            //            uCell.Row.Cells["MaDanhMucCanBoTamUng"].Value = frmDanhMucNhanSuValid.dataRows[0]["Ma"].ToString();
            //            uCell.Row.Cells["TenDanhMucCanBoTamUng"].Value = frmDanhMucNhanSuValid.dataRows[0]["Ten"].ToString();
            //        }
            //    }
            //    GridValidation = true;
            //    return;
            //}
            //else if (columnKey == "SOTIENCUOCVO" || columnKey == "SOTIENHAIQUAN" || columnKey == "SOTIENNANGHA" || columnKey == "SOTIENCHIKHAC")
            //{
            //    float SoTienCuocVo = 0, SoTienHaiQuan = 0, SoTienNangHa = 0, SoTienChiKhac = 0;
            //    foreach (UltraGridRow row in ugChiTiet.Rows)
            //    {
            //        SoTienCuocVo += float.Parse((!coreCommon.coreCommon.IsNull(row.Cells["SoTienCuocVo"].Value)) ? row.Cells["SoTienCuocVo"].Value.ToString() : "0");
            //        SoTienHaiQuan += float.Parse((!coreCommon.coreCommon.IsNull(row.Cells["SoTienHaiQuan"].Value)) ? row.Cells["SoTienHaiQuan"].Value.ToString() : "0");
            //        SoTienNangHa += float.Parse((!coreCommon.coreCommon.IsNull(row.Cells["SoTienNangHa"].Value)) ? row.Cells["SoTienNangHa"].Value.ToString() : "0");
            //        SoTienChiKhac += float.Parse((!coreCommon.coreCommon.IsNull(row.Cells["SoTienChiKhac"].Value)) ? row.Cells["SoTienChiKhac"].Value.ToString() : "0");
            //    }
            //    txtTongSoTienCuocVo.Value = SoTienCuocVo;
            //    txtTongSoTienHaiQuan.Value = SoTienHaiQuan;
            //    txtTongSoTienNangHa.Value = SoTienNangHa;
            //    txtTongSoTienChiKhac.Value = SoTienChiKhac;
            //}
            //else
            //{
            //    cenBase.Classes.ChungTu.gridColumnDataProcess(LoaiManHinh.ToString(), ug, uCell, out GridValidation, ShowLookUp);
            //}
        }
        protected override void filter()
        {
            //DataSet dsChungTuOld = dsChungTu.Copy();

            //cenBase.Classes.ChungTu.filterChungTu(IDDanhMucChungTu.ToString(), DetailLevel, TableName, TableNameDetail, TableNameDetail2, this.Text, out IDChungTu, out dsChungTu);
            //if (dsChungTu == null || dsChungTu.Tables[TableName].Rows.Count == 0) { dsChungTu = dsChungTuOld.Copy(); dsChungTuOld.Dispose(); }
            //setDataBindings();
            //UpdateMode = 0;
            //enableControl();
        }
        protected override void luuChungTu(bool Exit)
        {
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Xem) return;

            IDChungTu = null;
            ugChiTiet.UpdateData();
            //Valid dữ liệu
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucSale.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu tên sale!"); cboIDDanhMucSale.Focus(); return; }
            if (coreCommon.coreCommon.IsNull(txtMaDanhMucKhachHang.ID)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu mã khách hàng!"); txtMaDanhMucKhachHang.Focus(); return; }
            if (coreCommon.coreCommon.IsNull(txtDebitNote.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu số DebitNote!"); txtDebitNote.Focus(); return; }
            if (coreCommon.coreCommon.IsNull(cboLoaiHang.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu loại hàng!"); cboLoaiHang.Focus(); return; }
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucNhomHangVanChuyen.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu nhóm hàng!"); cboIDDanhMucNhomHangVanChuyen.Focus(); return; }

            if (cboLoaiHang.Value.ToString() == "1" && coreCommon.coreCommon.IsNull(txtNgayTraHang.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu ngày trả hàng!"); txtNgayTraHang.Focus(); return; }
            if (cboLoaiHang.Value.ToString() == "2" && coreCommon.coreCommon.IsNull(txtNgayDongHang.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu ngày đóng hàng!"); txtNgayDongHang.Focus(); return; }
            if (cboLoaiHang.Value.ToString() == "3")
            {
                if (coreCommon.coreCommon.IsNull(txtNgayDongHang.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu ngày đóng hàng!"); txtNgayDongHang.Focus(); return; }
                if (coreCommon.coreCommon.IsNull(txtNgayTraHang.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu ngày trả hàng!"); txtNgayDongHang.Focus(); return; }
            }
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucTuyenVanTai.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu tuyến vận tải!"); cboIDDanhMucTuyenVanTai.Focus(); return; }

            foreach (UltraGridRow row in ugChiTiet.Rows)
            {
                if (!coreCommon.coreCommon.IsNull(row.Cells["NgayTamUng"].Value))
                {
                    if (coreCommon.coreCommon.IsNull(row.Cells["IDDanhMucCanBoTamUng"].Value))
                    {
                        coreCommon.coreCommon.ErrorMessageOkOnly("Mã cán bộ tạm ứng ở dòng thứ " + (row.Index + 1).ToString() + " không hợp lệ!");
                        ugChiTiet.Rows[row.Index].Activate();
                        ugChiTiet.Rows[row.Index].Cells["MaDanhMucCanBoTamUng"].Activate();
                        ugChiTiet.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                    if (coreCommon.coreCommon.IsNull(row.Cells["ThoiHanThanhToan"].Value))
                    {
                        coreCommon.coreCommon.ErrorMessageOkOnly("Thời hạn thanh toán ở dòng thứ " + (row.Index + 1).ToString() + " không hợp lệ!");
                        ugChiTiet.Rows[row.Index].Activate();
                        ugChiTiet.Rows[row.Index].Cells["ThoiHanThanhToan"].Activate();
                        ugChiTiet.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                }
            }
            //Lưu chứng từ
            bsChungTuChiTiet.EndEdit();
            bsChungTu.EndEdit();

            DataRow dataRow = ((DataRowView)bsChungTu.Current).Row;
            if (!coreCommon.coreCommon.IsNull(ctDonHangBUS.GetIDctChotDoanhThuGuiKeToan(dataRow["ID"]))) { coreCommon.coreCommon.ErrorMessageOkOnly("Đơn hàng đã chốt doanh thu, không sửa được!"); return; }
            obj = new ctDonHang()
            {
                ID = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? dataRow["ID"] : null,
                IDDanhMucDonVi = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? dataRow["IDDanhMucDonVi"] : coreCommon.GlobalVariables.IDDonVi,
                IDDanhMucChungTu = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? dataRow["IDDanhMucChungTu"] : IDDanhMucChungTu,
                IDDanhMucChungTuTrangThai = cboIDDanhMucTrangThaiChungTu.Value,
                So = txtSo.Value,
                NgayLap = txtNgayLap.DateTime,
                //
                IDDanhMucSale = cboIDDanhMucSale.Value,
                IDDanhMucKhachHang = txtMaDanhMucKhachHang.ID,
                MaDanhMucKhachHang = txtMaDanhMucKhachHang.Value,
                TenDanhMucKhachHang = txtTenDanhMucKhachHang.Value,
                IDDanhMucKhachHangF2 = cboIDDanhMucKhachHangF2.Value,
                DebitNote = txtDebitNote.Value,
                BillBooking = txtBillBooking.Value,
                LoaiHang = cboLoaiHang.Value,
                IDDanhMucNhomHangVanChuyen = cboIDDanhMucNhomHangVanChuyen.Value,
                IDDanhMucHangHoa = cboIDDanhMucHangHoa.Value,
                IDDanhMucHangTau = cboIDDanhMucHangTau.Value,
                SoLuong = txtSoLuong.Value,
                KhoiLuong = txtTrongLuong.Value,
                TheTich = txtKhoiLuong.Value,
                SoContainer = txtSoContainer.Value,
                IDDanhMucDiaDiemLayContHang = cboIDDanhMucDiaDiemLayContHang.Value,
                IDDanhMucDiaDiemTraContHang = cboIDDanhMucDiaDiemTraContHang.Value,
                NgayDongHang = txtNgayDongHang.Value,
                GioDongHang = txtGioDongHang.DateTime.Hour.ToString("0#") + ":" + txtGioDongHang.DateTime.Minute.ToString("0#"),
                NgayTraHang = txtNgayTraHang.Value,
                GioTraHang = txtGioTraHang.DateTime.Hour.ToString("0#") + ":" + txtGioTraHang.DateTime.Minute.ToString("0#"),
                IDDanhMucKhachHangF3DongHang = cboIDDanhMucKhachHangF3DongHang.Value,
                IDDanhMucKhachHangF3TraHang = cboIDDanhMucKhachHangF3TraHang.Value,
                IDDanhMucTuyenVanTai = cboIDDanhMucTuyenVanTai.Value,
                NgayCatMang = txtNgayCatMang.Value,
                GioCatMang = txtGioCatMang.DateTime.Hour.ToString("0#") + ":" + txtGioCatMang.DateTime.Minute.ToString("0#"),
                NguoiGiaoNhan = txtNguoiGiaoNhan.Value,
                SoDienThoaiGiaoNhan = txtSoDienThoaiGiaoNhan.Value,
                SoTienCuoc = txtSoTienCuoc.Value,
                SoTienThuTuc = txtSoTienThuTuc.Value,
                SoTienDoanhThuKhac = txtSoTienDoanhThuKhac.Value,
                SoTienHoaHong = txtSoTienHoaHong.Value,
                ThoiHanThanhToan = txtThoiHanThanhToan.Value,
                GhiChu = txtGhiChu.Value,
                //
                IDDanhMucNguoiSuDungCreate = (UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? coreCommon.GlobalVariables.IDDanhMucNguoiSuDung : (dataRow["IDDanhMucNguoiSuDungCreate"] ?? dataRow["IDDanhMucNguoiSuDungCreate"]),
                MaDanhMucNguoiSuDungCreate = (UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? coreCommon.GlobalVariables.MaDanhMucNguoiSuDung.ToString() : (dataRow["MaDanhMucNguoiSuDungCreate"].ToString() ?? dataRow["MaDanhMucNguoiSuDungCreate"].ToString()),
                IDDanhMucNguoiSuDungEdit = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? coreCommon.GlobalVariables.IDDanhMucNguoiSuDung : ((dataRow != null) ? dataRow["IDDanhMucNguoiSuDungEdit"] : null),
                MaDanhMucNguoiSuDungEdit = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? coreCommon.GlobalVariables.MaDanhMucNguoiSuDung.ToString() : ((dataRow != null) ? dataRow["MaDanhMucNguoiSuDungEdit"].ToString() : null),
                CreateDate = null,
                EditDate = null
            };
            foreach (DataRow drChiTiet in dsChungTu.Tables[ctDonHang.tableNameChiTiet].Rows)
            {

                if (drChiTiet.RowState != DataRowState.Deleted)
                {
                    if (!coreCommon.coreCommon.IsNull(drChiTiet["IDDanhMucCanBoTamUng"]))
                    {
                        obj.listChiTiet.Add(new ctDonHang.ctDonHangChiTietTamUng()
                        {
                            ID = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? drChiTiet["ID"] : null,
                            //
                            NgayTamUng = drChiTiet["NgayTamUng"],
                            IDDanhMucHangTau = drChiTiet["IDDanhMucHangTau"],
                            SoTienCuocVo = drChiTiet["SoTienCuocVo"],
                            SoTienHaiQuan = drChiTiet["SoTienHaiQuan"],
                            SoTienNangHa = drChiTiet["SoTienNangHa"],
                            SoTienChiKhac = drChiTiet["SoTienChiKhac"],
                            IDDanhMucCanBoTamUng = drChiTiet["IDDanhMucCanBoTamUng"],
                            ThoiHanThanhToan = drChiTiet["ThoiHanThanhToan"],
                            //
                            GhiChu = drChiTiet["GhiChu"],
                            DataRowState = drChiTiet.RowState
                        }
                        );
                    }
                }
                else
                {
                    if (!coreCommon.coreCommon.IsNull(drChiTiet["IDDanhMucCanBoTamUng", DataRowVersion.Original]))
                    {
                        obj.listChiTiet.Add(new ctDonHang.ctDonHangChiTietTamUng()
                        {
                            ID = drChiTiet["ID", DataRowVersion.Original],
                            //
                            NgayTamUng = drChiTiet["NgayTamUng", DataRowVersion.Original],
                            IDDanhMucHangTau = drChiTiet["IDDanhMucHangTau", DataRowVersion.Original],
                            SoTienCuocVo = drChiTiet["SoTienCuocVo", DataRowVersion.Original],
                            SoTienHaiQuan = drChiTiet["SoTienHaiQuan", DataRowVersion.Original],
                            SoTienNangHa = drChiTiet["SoTienNangHa", DataRowVersion.Original],
                            SoTienChiKhac = drChiTiet["SoTienChiKhac", DataRowVersion.Original],
                            IDDanhMucCanBoTamUng = drChiTiet["IDDanhMucCanBoTamUng", DataRowVersion.Original],
                            ThoiHanThanhToan = drChiTiet["ThoiHanThanhToan", DataRowVersion.Original],
                            //
                            GhiChu = drChiTiet["GhiChu", DataRowVersion.Original],
                            DataRowState = drChiTiet.RowState
                        }
                        );
                    }
                }

            }
            bus = new ctDonHangBUS();
            Saved = (UpdateMode == coreCommon.ThaoTacDuLieu.Them || UpdateMode == coreCommon.ThaoTacDuLieu.Copy) ? bus.Insert(ref obj) : bus.Update(ref obj, true);
            if (Saved && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {

                int i = -1;
                if (!coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow))
                {
                    i = ugChiTiet.ActiveRow.Index;
                }

                IDChungTu = obj.ID;

                bus = new ctDonHangBUS();
                dsChungTu = bus.List(IDDanhMucChungTu, IDChungTu);
                bsChungTu.DataSource = dsChungTu;
                bsChungTu.DataMember = ctDonHang.tableName;
                bsChungTuChiTiet.DataSource = bsChungTu;
                bsChungTuChiTiet.DataMember = coreCommon.GlobalVariables.prefix_DataRelation + ctDonHang.tableNameChiTiet;

                ugChiTiet.ReadOnlyColumnsList = "[TenDanhMucCanBoTamUng][TenDanhMucHangTau][LanTamUng]";
                ugChiTiet.DataSource = bsChungTuChiTiet;


                UpdateMode = coreCommon.ThaoTacDuLieu.Xem;

                if (i >= 0 && ugChiTiet.Rows.Count >= i + 1)
                {
                    ugChiTiet.Rows[i].Activate();
                    ugChiTiet.Rows[i].Selected = true;
                }

                if (Exit)
                {
                    UpdateMode = coreCommon.ThaoTacDuLieu.Xem;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    UpdateMode = coreCommon.ThaoTacDuLieu.Sua;
                    enableControl();
                }
            }
        }
        protected void InChungTu()
        {
            //if (bsChungTu.Current == null) return;
            //if (UpdateMode != 0) luuChungTu();
            //DataRow dataRow = ((DataRowView)bsChungTu.Current).Row;
            //if (!ctDonHangBUS.GetSuaXoa(dataRow["ID"]))
            //{
            //    coreCommon.coreCommon.ErrorMessageOkOnly("Không in được chứng từ đã bị hủy!");
            //    return;
            //}
            //String IDChungTu = dataRow["ID"].ToString();
            //String IDDanhMucChungTu = dataRow["IDDanhMucChungTu"].ToString();
            //cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu, IDChungTu, ctDonHang.tableName, ctDonHang.tableNameChiTiet, this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"\" + ctDonHang.reportFileName, ctDonHang.listProcedureName, TenMayIn, 2, LoaiManHinh, 0);
        }
        protected override void themChungTuChiTiet()
        {
            GridValidation = false;
            bsChungTuChiTiet.AddNew();
            ugChiTiet.Focus();
            ugChiTiet.DisplayLayout.Rows[ugChiTiet.DisplayLayout.Rows.Count - 1].Activate();
            if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value))
            {
                ugChiTiet.ActiveRow.Cells["ID"].Value = coreCommon.coreCommon.MaxTempID(dsChungTu.Tables[ctDonHang.tableNameChiTiet]);
            }
            ugChiTiet.ActiveCell = ugChiTiet.ActiveRow.Cells["MaDanhMucCanBoTamUng"];
            ugChiTiet.ActiveCell.Activate();
            ugChiTiet.PerformAction(UltraGridAction.EnterEditMode);
            GridValidation = true;
        }
        protected override void xoaChungTuChiTiet()
        {
            if (ugChiTiet.ActiveRow == null) return;
            int i = ugChiTiet.ActiveRow.Index;
            ugChiTiet.ActiveRow.Delete();
            if (i > 0) i -= 1;
            if (i <= ugChiTiet.Rows.Count - 1)
            {
                ugChiTiet.Focus();
                ugChiTiet.Rows[i].Activate();
                ugChiTiet.Rows[i].Cells["MaDanhMucCanBoTamUng"].Activate();
                ugChiTiet.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        private void cboIDDanhMucKhachHangF3DongHang_ValueChanged(object sender, EventArgs e)
        {
            if (!cboIDDanhMucKhachHangF3DongHang.IsItemInList()) return;
            cboDiaChiDongHang.Value = cboIDDanhMucKhachHangF3DongHang.Value;
            if (cboLoaiHang.Value.ToString() == "2")
            {
                DanhMucKhachHangBUS KhachHangBUS = new DanhMucKhachHangBUS();
                dtKhachHang = KhachHangBUS.Valid(cboIDDanhMucKhachHangF3DongHang.Value, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
                if (dtKhachHang.Rows.Count > 0)
                {
                    cboIDDanhMucTuyenVanTai.Value = dtKhachHang.Rows[0]["IDDanhMucTuyenVanTai"];
                    txtNguoiGiaoNhan.Value = dtKhachHang.Rows[0]["NguoiGiaoNhan"];
                    txtSoDienThoaiGiaoNhan.Value = dtKhachHang.Rows[0]["SoDienThoaiGiaoNhan"];
                }
            }
        }
        private void cboDiaChiDongHang_ValueChanged(object sender, EventArgs e)
        {
            if (!cboIDDanhMucKhachHangF3TraHang.IsItemInList()) return;
            cboDiaChiTraHang.Value = cboIDDanhMucKhachHangF3TraHang.Value;
            if (cboLoaiHang.Value.ToString() == "2")
            {
                DanhMucKhachHangBUS KhachHangBUS = new DanhMucKhachHangBUS();
                dtKhachHang = KhachHangBUS.Valid(cboIDDanhMucKhachHangF3TraHang.Value, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
                if (dtKhachHang.Rows.Count > 0)
                {
                    cboIDDanhMucTuyenVanTai.Value = dtKhachHang.Rows[0]["IDDanhMucTuyenVanTai"];
                    txtNguoiGiaoNhan.Value = dtKhachHang.Rows[0]["NguoiGiaoNhan"];
                    txtSoDienThoaiGiaoNhan.Value = dtKhachHang.Rows[0]["SoDienThoaiGiaoNhan"];
                }
            }
        }
        private void cboIDDanhMucKhachHangF3TraHang_ValueChanged(object sender, EventArgs e)
        {
            if (!cboDiaChiDongHang.IsItemInList()) return;
            cboIDDanhMucKhachHangF3DongHang.Value = cboDiaChiDongHang.Value;
            if (cboLoaiHang.Value.ToString() == "1")
            {
                DanhMucKhachHangBUS KhachHangBUS = new DanhMucKhachHangBUS();
                dtKhachHang = KhachHangBUS.Valid(cboDiaChiDongHang.Value, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
                if (dtKhachHang.Rows.Count > 0)
                {
                    cboIDDanhMucTuyenVanTai.Value = dtKhachHang.Rows[0]["IDDanhMucTuyenVanTai"];
                    txtNguoiGiaoNhan.Value = dtKhachHang.Rows[0]["NguoiGiaoNhan"];
                    txtSoDienThoaiGiaoNhan.Value = dtKhachHang.Rows[0]["SoDienThoaiGiaoNhan"];
                }
            }
        }
        private void cboDiaChiTraHang_ValueChanged(object sender, EventArgs e)
        {
            if (!cboDiaChiTraHang.IsItemInList()) return;
            cboIDDanhMucKhachHangF3TraHang.Value = cboDiaChiTraHang.Value;
            if (cboLoaiHang.Value.ToString() == "1")
            {
                DanhMucKhachHangBUS KhachHangBUS = new DanhMucKhachHangBUS();
                dtKhachHang = KhachHangBUS.Valid(cboDiaChiTraHang.Value, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
                if (dtKhachHang.Rows.Count > 0)
                {
                    cboIDDanhMucTuyenVanTai.Value = dtKhachHang.Rows[0]["IDDanhMucTuyenVanTai"];
                    txtNguoiGiaoNhan.Value = dtKhachHang.Rows[0]["NguoiGiaoNhan"];
                    txtSoDienThoaiGiaoNhan.Value = dtKhachHang.Rows[0]["SoDienThoaiGiaoNhan"];
                }
            }
        }
        #endregion Method
        #region FormEvents
        private void frm_ctDonHang_Load(object sender, EventArgs e)
        {
            txtGioDongHang.MaskInput = coreCommon.GlobalVariables.MaskInputTime;
            txtGioTraHang.MaskInput = coreCommon.GlobalVariables.MaskInputTime;
            txtGioCatMang.MaskInput = coreCommon.GlobalVariables.MaskInputTime;
            //
            loadData();
            loadValidDataSet();
            //
            setCustomsDataBindings();
            //
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Them)
                themChungTu();
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Sua)
                suaChungTu();
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Xem)
            {
                enableControl();
                toolBar.Toolbars[0].Tools["btSua"].SharedProps.Enabled = true;
            }
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Copy)
            {
                ugChiTiet.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
                ugChiTiet.DisplayLayout.Bands[0].Columns["MaDanhMucCanBoTamUng"].CellClickAction = CellClickAction.EditAndSelectText;
                ugChiTiet.DisplayLayout.Bands[0].Columns["MaDanhMucCanBoTamUng"].CellActivation = Activation.AllowEdit;
                dsChungTu.Tables[ctDonHang.tableNameChiTiet].Rows.Clear();
                dsChungTu.AcceptChanges();
                bsChungTuChiTiet.AddNew();
                txtNgayDongHang.Focus();
                txtMaDanhMucKhachHang.ID = dsChungTu.Tables[ctDonHang.tableName].Rows[0]["IDDanhMucKhachHang"];
            }

        }
        //In phiếu
        private void toolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                //case "ctYeuCauVanChuyen":
                //    if (UpdateMode != coreCommon.ThaoTacDuLieu.Xem) luuChungTu(false);
                //    if (!coreCommon.coreCommon.IsNull(IDChungTu))
                //        cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu.ToString(), IDChungTu.ToString(), ctDonHang.tableName, ctDonHang.tableNameChiTiet, this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"ctYeuCauVanChuyen.rpt", ctDonHang.listProcedureName, "", 1, LoaiManHinh, 1);
                //    break;
                //case "ctGiayDeNghiTamUng":
                //    if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow)) return;
                //    if (UpdateMode != coreCommon.ThaoTacDuLieu.Xem) luuChungTu(false);
                //    if (!coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value))
                //        cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu.ToString(), ugChiTiet.ActiveRow.Cells["ID"].Value.ToString(), ctDonHang.tableName, "", this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"ctGiayDeNghiTamUng.rpt", ctDonHang.listIDChiTietProcedureName, "", 1, LoaiManHinh, 1);
                //    break;
                //case "ctGiayDeNghiTamUngCK":
                //    if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow)) return;
                //    if (UpdateMode != coreCommon.ThaoTacDuLieu.Xem) luuChungTu(false);
                //    if (!coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value))
                //        cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu.ToString(), ugChiTiet.ActiveRow.Cells["ID"].Value.ToString(), ctDonHang.tableName, "", this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"ctGiayDeNghiTamUngCK.rpt", ctDonHang.listIDChiTietProcedureName, "", 1, LoaiManHinh, 1);
                //    break;
                //case "ctGiayBienNhan":
                //    if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow)) return;
                //    if (UpdateMode != coreCommon.ThaoTacDuLieu.Xem) luuChungTu(false);
                //    if (!coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value))
                //        cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu.ToString(), ugChiTiet.ActiveRow.Cells["ID"].Value.ToString(), ctDonHang.tableName, "", this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"ctGiayBienNhan.rpt", ctDonHang.listIDChiTietProcedureName, "", 1, LoaiManHinh, 1);
                //    break;
                //default:
                //    //In phiếu yêu cầu vận chuyển
                //    break;
            }
        }
        private void cboIDDanhMucNhomHangVanChuyen_ValueChanged(object sender, EventArgs e)
        {
            ////Thay đổi loại hàng cont/lẻ
            //DanhMucHangHoaBUS DanhMucHangHoaBUS = new DanhMucHangHoaBUS();
            //dtHangHoa = DanhMucHangHoaBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangHoa)), cboIDDanhMucNhomHangVanChuyen.Value, null);
            //cboIDDanhMucHangHoa.dtValid = dtHangHoa;
            //cboIDDanhMucHangHoa.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangHoa));
            //cboIDDanhMucHangHoa.procedureName = DanhMucHangHoa.listProcedureName;
            //cboIDDanhMucHangHoa.DataSource = dtHangHoa;
            //cboIDDanhMucHangHoa.ValueMember = "ID";
            //cboIDDanhMucHangHoa.DisplayMember = "Ten";
            ////Lấy danh mục kho, cảng icd
            //DanhMucDiaDiemGiaoNhanBUS DanhMucDiaDiemGiaoNhanBUS = new DanhMucDiaDiemGiaoNhanBUS();
            //dtDiaDiemGiaoNhan = DanhMucDiaDiemGiaoNhanBUS.List(null, null, cboIDDanhMucNhomHangVanChuyen.Value, null);
            //cboIDDanhMucDiaDiemLayContHang.dtValid = dtDiaDiemGiaoNhan;
            //cboIDDanhMucDiaDiemLayContHang.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongCangICD));
            //cboIDDanhMucDiaDiemLayContHang.procedureName = DanhMucDoiTuong.listProcedureName;
            //cboIDDanhMucDiaDiemLayContHang.DataSource = dtDiaDiemGiaoNhan;
            //cboIDDanhMucDiaDiemLayContHang.ValueMember = "ID";
            //cboIDDanhMucDiaDiemLayContHang.DisplayMember = "Ten";
            //cboIDDanhMucDiaDiemTraContHang.dtValid = dtDiaDiemGiaoNhan;
            //cboIDDanhMucDiaDiemTraContHang.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongCangICD));
            //cboIDDanhMucDiaDiemTraContHang.procedureName = DanhMucDoiTuong.listProcedureName;
            //cboIDDanhMucDiaDiemTraContHang.DataSource = dtDiaDiemGiaoNhan;
            //cboIDDanhMucDiaDiemTraContHang.ValueMember = "ID";
            //cboIDDanhMucDiaDiemTraContHang.DisplayMember = "Ten";
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucNhomHangVanChuyen.Value))
            {
                lblNoiLayContHang.Text = "Nơi lấy cont/hàng";
                lblNoiTraContHang.Text = "Nơi trả cont/hàng";
                lblNgayDongContHang.Text = "Ngày đóng cont/hàng";
                lblGioDongContHang.Text = "Giờ đóng cont/hàng";
                lblNgayTraContHang.Text = "Ngày trả cont/hàng";
                lblGioTraContHang.Text = "Giờ trả cont/hàng";
                return;
            }
            if (cboIDDanhMucNhomHangVanChuyen.Value.ToString() == "2006") //Hàng lẻ
            {
                lblNoiLayContHang.Text = "Nơi lấy hàng";
                lblNoiTraContHang.Text = "Nơi trả hàng";
                lblNgayDongContHang.Text = "Ngày đóng hàng";
                lblGioDongContHang.Text = "Giờ đóng hàng";
                lblNgayTraContHang.Text = "Ngày trả hàng";
                lblGioTraContHang.Text = "Giờ trả hàng";
                return;
            }
            if (cboIDDanhMucNhomHangVanChuyen.Value.ToString() == "2007") //Hàng cont
            {
                lblNoiLayContHang.Text = "Nơi lấy cont";
                lblNoiTraContHang.Text = "Nơi trả cont";
                lblNgayDongContHang.Text = "Ngày đóng cont";
                lblGioDongContHang.Text = "Giờ đóng cont";
                lblNgayTraContHang.Text = "Ngày trả cont";
                lblGioTraContHang.Text = "Giờ trả cont";
                return;
            }
        }
        private void cboLoaiHang_ValueChanged(object sender, EventArgs e)
        {
            //Thay đổi loại hàng nhập/xuất/nội địa
            if (coreCommon.coreCommon.IsNull(cboLoaiHang.Value))
            {
                txtNgayTraHang.Enabled = true;
                txtGioTraHang.Enabled = true;
                txtNgayDongHang.Enabled = true;
                txtGioDongHang.Enabled = true;
                cboIDDanhMucKhachHangF3TraHang.Enabled = true;
                cboDiaChiTraHang.Enabled = true;
                cboIDDanhMucKhachHangF3DongHang.Enabled = true;
                cboDiaChiDongHang.Enabled = true;
                return;
            }
            switch (cboLoaiHang.Value.ToString())
            {
                case "1": //Hàng nhập
                    lblSoBillBooking.Text = "Bill";
                    txtNgayDongHang.Value = null;
                    txtGioDongHang.Value = null;
                    txtNgayDongHang.Enabled = false;
                    txtGioDongHang.Enabled = false;
                    txtNgayTraHang.Enabled = true;
                    txtGioTraHang.Enabled = true;
                    cboIDDanhMucKhachHangF3DongHang.Value = null;
                    cboIDDanhMucKhachHangF3DongHang.Enabled = false;
                    cboDiaChiDongHang.Value = null;
                    cboDiaChiDongHang.Enabled = false;
                    cboIDDanhMucKhachHangF3TraHang.Enabled = true;
                    cboDiaChiTraHang.Enabled = true;
                    break;
                case "2": //Hàng xuất
                    lblSoBillBooking.Text = "Booking";
                    txtNgayTraHang.Value = null;
                    txtGioTraHang.Value = null;
                    txtNgayTraHang.Enabled = false;
                    txtGioTraHang.Enabled = false;
                    txtNgayDongHang.Enabled = true;
                    txtGioDongHang.Enabled = true;
                    cboIDDanhMucKhachHangF3TraHang.Value = null;
                    cboIDDanhMucKhachHangF3TraHang.Enabled = false;
                    cboDiaChiTraHang.Value = null;
                    cboDiaChiTraHang.Enabled = false;
                    cboIDDanhMucKhachHangF3DongHang.Enabled = true;
                    cboDiaChiDongHang.Enabled = true;
                    break;
                case "3": //Hàng nội địa
                    lblSoBillBooking.Text = "Bill/Booking";
                    txtNgayTraHang.Enabled = true;
                    txtGioTraHang.Enabled = true;
                    txtNgayDongHang.Enabled = true;
                    txtGioDongHang.Enabled = true;
                    cboIDDanhMucKhachHangF3TraHang.Enabled = true;
                    cboDiaChiTraHang.Enabled = true;
                    cboIDDanhMucKhachHangF3DongHang.Enabled = true;
                    cboDiaChiDongHang.Enabled = true;
                    break;
            }
        }
        private void txtIDDanhMucNhanSu_ValueChanged(object sender, EventArgs e)
        {
            cboIDDanhMucSale.Value = txtIDDanhMucNhanSu.Value;
        }
        private void txtMaDanhMucKhachHang_Validated(object sender, EventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(txtMaDanhMucKhachHang.ID)) { txtMaDanhMucKhachHang.Value = null; return; }
            cboIDDanhMucKhachHangF2.Value = null;
            cboIDDanhMucKhachHangF3DongHang.Value = null;
            cboDiaChiDongHang.Value = null;
            cboIDDanhMucKhachHangF3TraHang.Value = null;
            cboDiaChiTraHang.Value = null;

            DanhMucKhachHangBUS KhachHangF2BUS = new DanhMucKhachHangBUS();
            DataTable dtKhachHangF2 = KhachHangF2BUS.ValidF2((dsChungTu.Tables[ctDonHang.tableName].Rows.Count > 0) ? dsChungTu.Tables[ctDonHang.tableName].Rows[0]["IDDanhMucKhachHangF2"] : null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), txtMaDanhMucKhachHang.ID, null);
            cboIDDanhMucKhachHangF2.DataSource = dtKhachHangF2;
            cboIDDanhMucKhachHangF2.ValueMember = "ID";
            cboIDDanhMucKhachHangF2.DisplayMember = "Ten";

            DanhMucKhachHangBUS KhachHangF3BUS = new DanhMucKhachHangBUS();
            DataTable dtKhachHangF3DongHang = KhachHangF3BUS.ValidF3((dsChungTu.Tables[ctDonHang.tableName].Rows.Count > 0) ? dsChungTu.Tables[ctDonHang.tableName].Rows[0]["IDDanhMucKhachHangF3DongHang"] : null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), txtMaDanhMucKhachHang.ID, cboIDDanhMucKhachHangF2.Value, null);
            cboIDDanhMucKhachHangF3DongHang.DataSource = dtKhachHangF3DongHang;
            cboIDDanhMucKhachHangF3DongHang.ValueMember = "ID";
            cboIDDanhMucKhachHangF3DongHang.DisplayMember = "Ten";
            cboDiaChiDongHang.DataSource = dtKhachHangF3DongHang;
            cboDiaChiDongHang.ValueMember = "ID";
            cboDiaChiDongHang.DisplayMember = "DiaChi";

            DataTable dtKhachHangF3TraHang = KhachHangF3BUS.ValidF3((dsChungTu.Tables[ctDonHang.tableName].Rows.Count > 0) ? dsChungTu.Tables[ctDonHang.tableName].Rows[0]["IDDanhMucKhachHangF3TraHang"] : null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), txtMaDanhMucKhachHang.ID, cboIDDanhMucKhachHangF2.Value, null);
            cboIDDanhMucKhachHangF3TraHang.DataSource = dtKhachHangF3TraHang;
            cboIDDanhMucKhachHangF3TraHang.ValueMember = "ID";
            cboIDDanhMucKhachHangF3TraHang.DisplayMember = "Ten";
            cboDiaChiTraHang.DataSource = dtKhachHangF3TraHang;
            cboDiaChiTraHang.ValueMember = "ID";
            cboDiaChiTraHang.DisplayMember = "DiaChi";
        }
        private void cboIDDanhMucKhachHangF2_ValueChanged(object sender, EventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucKhachHangF2.Value)) { cboIDDanhMucKhachHangF2.Value = null; return; }

            cboIDDanhMucKhachHangF3DongHang.Value = null;
            cboIDDanhMucKhachHangF3TraHang.Value = null;

            DanhMucKhachHangBUS KhachHangF3BUS = new DanhMucKhachHangBUS();
            DataTable dtKhachHangF3DongHang = KhachHangF3BUS.ValidF3((dsChungTu.Tables[ctDonHang.tableName].Rows.Count > 0) ? dsChungTu.Tables[ctDonHang.tableName].Rows[0]["IDDanhMucKhachHangF3DongHang"] : null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), txtMaDanhMucKhachHang.ID, cboIDDanhMucKhachHangF2.Value, null);
            cboIDDanhMucKhachHangF3DongHang.DataSource = dtKhachHangF3DongHang;
            cboIDDanhMucKhachHangF3DongHang.ValueMember = "ID";
            cboIDDanhMucKhachHangF3DongHang.DisplayMember = "Ten";
            cboDiaChiDongHang.DataSource = dtKhachHangF3DongHang;
            cboDiaChiDongHang.ValueMember = "ID";
            cboDiaChiDongHang.DisplayMember = "DiaChi";

            DataTable dtKhachHangF3TraHang = KhachHangF3BUS.ValidF3((dsChungTu.Tables[ctDonHang.tableName].Rows.Count > 0) ? dsChungTu.Tables[ctDonHang.tableName].Rows[0]["IDDanhMucKhachHangF3TraHang"] : null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), txtMaDanhMucKhachHang.ID, cboIDDanhMucKhachHangF2.Value, null);
            cboIDDanhMucKhachHangF3TraHang.DataSource = dtKhachHangF3TraHang;
            cboIDDanhMucKhachHangF3TraHang.ValueMember = "ID";
            cboIDDanhMucKhachHangF3TraHang.DisplayMember = "Ten";
            cboDiaChiTraHang.DataSource = dtKhachHangF3TraHang;
            cboDiaChiTraHang.ValueMember = "ID";
            cboDiaChiTraHang.DisplayMember = "DiaChi";
        }
        #endregion FormEvents


    }



}
