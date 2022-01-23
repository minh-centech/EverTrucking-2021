using coreBase.BaseForms;
using cenBUS.cenLogistics;
using coreBUS;
using coreControls;
using cenDTO.cenLogistics;
using Infragistics.Win.UltraWinGrid;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctThanhToanTamUngUpdate : frmBaseChungTuMasterDetail
    {
        public object IDChungTuChiTiet;
        public Form mdiParent;
        DataTable dtTrangThai;
        ctThanhToanTamUngBUS bus;
        saComboDanhMuc cboLoaiThanhToanTamUng;
        public frm_ctThanhToanTamUngUpdate()
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
            //
            cboLoaiThanhToanTamUng = new saComboDanhMuc();
            cboLoaiThanhToanTamUng.Items.Add(1, "Hoàn tạm ứng");
            cboLoaiThanhToanTamUng.Items.Add(2, "Đề nghị thanh toán");
            cboLoaiThanhToanTamUng.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
        }
        protected void loadData()
        {
            bus = new ctThanhToanTamUngBUS();
            dsChungTu = bus.List((UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? DBNull.Value : IDDanhMucChungTu, (UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? DBNull.Value : IDChungTu, (UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? DBNull.Value : IDChungTuChiTiet);
            bsChungTu = new BindingSource();
            bsChungTu.DataSource = dsChungTu;
            bsChungTu.DataMember = ctDonHang.tableName;
            bsChungTuChiTiet = new BindingSource();
            bsChungTuChiTiet.DataSource = bsChungTu;
            bsChungTuChiTiet.DataMember = coreCommon.GlobalVariables.prefix_DataRelation + ctThanhToanTamUng.tableName;
            ugChiTiet.ReadOnlyColumnsList = "[TenDanhMucCanBoThanhToanTamUng][TenDanhMucChiPhiHaiQuanKinhDoanh]";
            ugChiTiet.HiddenColumnsList = "[LanThanhToanTamUng]";
            ugChiTiet.DataSource = bsChungTuChiTiet;
            ugChiTiet.DisplayLayout.Bands[0].Columns["LoaiThanhToanTamUng"].EditorComponent = cboLoaiThanhToanTamUng;
            ugChiTiet.DisplayLayout.Bands[0].Columns["LoaiThanhToanTamUng"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ugChiTiet.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.Default;
            tabChiTiet.Tabs["ChiTiet"].Text = coreCommon.coreCommon.TraTuDien(ctThanhToanTamUng.tableName) + "-CTRL + INSERT: Thêm dòng; CTRL + DELETE: Xóa dòng";
        }
        protected override void themChungTu()
        {
            bsChungTu.AddNew();

            ugChiTiet.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            ugChiTiet.DisplayLayout.Bands[0].Columns["LoaiThanhToanTamUng"].CellClickAction = CellClickAction.EditAndSelectText;
            ugChiTiet.DisplayLayout.Bands[0].Columns["LoaiThanhToanTamUng"].CellActivation = Activation.AllowEdit;

            txtNgayLap.Value = coreCommon.coreCommon.NgayHachToan();
            txtNgayDongTraHang.Value = coreCommon.coreCommon.NgayHachToan();

            if (cboIDDanhMucTrangThaiChungTu.Items.Count > 0)
                cboIDDanhMucTrangThaiChungTu.SelectedItem = cboIDDanhMucTrangThaiChungTu.Items[0];

            UpdateMode = 1;
            enableControl();

            ugChiTiet.Focus();
        }
        protected override void suaChungTu()
        {
            base.suaChungTu();
            //
            UpdateMode = 2;
            enableControl();
            //
            txtNgayDongTraHang.Focus();
        }
        protected void setCustomsDataBindings()
        {
            txtSoDonHang.SetDataBinding(bsChungTu, "So", false, DataSourceUpdateMode.OnPropertyChanged);
            txtNgayDongTraHang.SetDataBinding(bsChungTu, "NgayDongTraHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDanhMucKhachHang.SetDataBinding(bsChungTu, "MaDanhMucKhachHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDebitNote.SetDataBinding(bsChungTu, "DebitNote", false, DataSourceUpdateMode.OnPropertyChanged);
            txtBillBooking.SetDataBinding(bsChungTu, "BillBooking", false, DataSourceUpdateMode.OnPropertyChanged);
            txtLoaiHang.SetDataBinding(bsChungTu, "TenLoaiHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDanhMucNhomHangVanChuyen.SetDataBinding(bsChungTu, "MaDanhMucNhomHangVanChuyen", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDanhMucHangHoa.SetDataBinding(bsChungTu, "MaDanhMucHangHoa", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTrongLuong.SetDataBinding(bsChungTu, "KhoiLuong", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDanhMucTuyenVanTai.SetDataBinding(bsChungTu, "MaDanhMucTuyenVanTai", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDanhMucCanBoTamUng.SetDataBinding(bsChungTu, "MaDanhMucCanBoTamUng", false, DataSourceUpdateMode.OnPropertyChanged);
            txtGhiChu.SetDataBinding(bsChungTu, "GhiChu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienTamUng.SetDataBinding(bsChungTu, "SoTienTamUng", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienHoanTamUng.SetDataBinding(bsChungTu, "SoTienHoanTamUng", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienThanhToan.SetDataBinding(bsChungTu, "SoTienThanhToan", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienTon.SetDataBinding(bsChungTu, "SoTienTon", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected override void gridColumnDataProcess(UltraGrid ug, UltraGridCell uCell, out bool GridValidation, bool ShowLookUp)
        {
            GridValidation = true;
            if (uCell.Row.IsFilterRow) return;
            String columnKey = uCell.Column.Key.ToUpper();
            //if (columnKey == "MADANHMUCCANBOTHANHTOANTAMUNG")
            //{
            //    GridValidation = false;
            //    //Valid đơn vị tính
            //    DanhMucNhanSuBUS bus = new DanhMucNhanSuBUS();
            //    DataTable dt = bus.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu)), uCell.Value);
            //    if (dt == null) { GridValidation = true; return; }
            //    if (dt.Rows.Count == 1)
            //    {
            //        uCell.Row.Cells["IDDanhMucCanBoThanhToanTamUng"].Value = dt.Rows[0]["ID"].ToString();
            //        uCell.Row.Cells["MaDanhMucCanBoThanhToanTamUng"].Value = dt.Rows[0]["Ma"].ToString();
            //        uCell.Row.Cells["TenDanhMucCanBoThanhToanTamUng"].Value = dt.Rows[0]["Ten"].ToString();

            //        ugChiTiet.DisplayLayout.Bands[0].Columns["IDDanhMucCanBoThanhToanTamUng"].DefaultCellValue = uCell.Row.Cells["IDDanhMucCanBoThanhToanTamUng"].Value;
            //        ugChiTiet.DisplayLayout.Bands[0].Columns["MaDanhMucCanBoThanhToanTamUng"].DefaultCellValue = uCell.Row.Cells["MaDanhMucCanBoThanhToanTamUng"].Value;
            //        ugChiTiet.DisplayLayout.Bands[0].Columns["TenDanhMucCanBoThanhToanTamUng"].DefaultCellValue = uCell.Row.Cells["TenDanhMucCanBoThanhToanTamUng"].Value;

            //        GridValidation = true;
            //        return;
            //    }
            //    else
            //    {
            //        //Show valid form
            //        frmDanhMucNhanSuValid frmDanhMucNhanSuValid = new frmDanhMucNhanSuValid()
            //        {
            //            IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu)),
            //            validValue = uCell.Row.Cells["MaDanhMucCanBoThanhToanTamUng"].Value,
            //            dataTable = dt
            //        };
            //        frmDanhMucNhanSuValid.ShowDialog();
            //        if (frmDanhMucNhanSuValid.dataRows == null || frmDanhMucNhanSuValid.dataRows.Count == 0) { GridValidation = true; return; }
            //        if (frmDanhMucNhanSuValid.dataRows.Count > 0)
            //        {
            //            uCell.Row.Cells["IDDanhMucCanBoThanhToanTamUng"].Value = frmDanhMucNhanSuValid.dataRows[0]["ID"].ToString();
            //            uCell.Row.Cells["MaDanhMucCanBoThanhToanTamUng"].Value = frmDanhMucNhanSuValid.dataRows[0]["Ma"].ToString();
            //            uCell.Row.Cells["TenDanhMucCanBoThanhToanTamUng"].Value = frmDanhMucNhanSuValid.dataRows[0]["Ten"].ToString();
            //        }
            //    }

            //    ugChiTiet.DisplayLayout.Bands[0].Columns["IDDanhMucCanBoThanhToanTamUng"].DefaultCellValue = uCell.Row.Cells["IDDanhMucCanBoThanhToanTamUng"].Value;
            //    ugChiTiet.DisplayLayout.Bands[0].Columns["MaDanhMucCanBoThanhToanTamUng"].DefaultCellValue = uCell.Row.Cells["MaDanhMucCanBoThanhToanTamUng"].Value;
            //    ugChiTiet.DisplayLayout.Bands[0].Columns["TenDanhMucCanBoThanhToanTamUng"].DefaultCellValue = uCell.Row.Cells["TenDanhMucCanBoThanhToanTamUng"].Value;

            //    GridValidation = true;
            //    return;
            //}
            //else if (columnKey == "LOAITHANHTOANTAMUNG" || columnKey == "NGAYTHANHTOANTAMUNG")
            //{
            //    ugChiTiet.DisplayLayout.Bands[0].Columns[columnKey].DefaultCellValue = uCell.Row.Cells[columnKey].Value;
            //}
            //else if (columnKey == "MADANHMUCCHIPHIHAIQUANKINHDOANH")
            //{
            //    GridValidation = false;
            //    //Valid đơn vị tính
            //    DanhMucDoiTuongBUS bus = new DanhMucDoiTuongBUS();
            //    DataTable dt = bus.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongChiPhiHaiQuanKinhDoanh)), uCell.Value);
            //    if (dt == null) { GridValidation = true; return; }
            //    if (dt.Rows.Count == 1)
            //    {
            //        uCell.Row.Cells["IDDanhMucChiPhiHaiQuanKinhDoanh"].Value = dt.Rows[0]["ID"].ToString();
            //        uCell.Row.Cells["MaDanhMucChiPhiHaiQuanKinhDoanh"].Value = dt.Rows[0]["Ma"].ToString();
            //        uCell.Row.Cells["TenDanhMucChiPhiHaiQuanKinhDoanh"].Value = dt.Rows[0]["Ten"].ToString();
            //        GridValidation = true;
            //        return;
            //    }
            //    else
            //    {
            //        //Show valid form
            //        frmDanhMucDoiTuongValid frmDanhMucDoiTuongValid = new frmDanhMucDoiTuongValid()
            //        {
            //            IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongChiPhiHaiQuanKinhDoanh)),
            //            validValue = uCell.Row.Cells["MaDanhMucChiPhiHaiQuanKinhDoanh"].Value,
            //            dataTable = dt
            //        };
            //        frmDanhMucDoiTuongValid.ShowDialog();
            //        if (frmDanhMucDoiTuongValid.dataRows == null || frmDanhMucDoiTuongValid.dataRows.Count == 0) { GridValidation = true; return; }
            //        if (frmDanhMucDoiTuongValid.dataRows.Count > 0)
            //        {
            //            uCell.Row.Cells["IDDanhMucChiPhiHaiQuanKinhDoanh"].Value = frmDanhMucDoiTuongValid.dataRows[0]["ID"].ToString();
            //            uCell.Row.Cells["MaDanhMucChiPhiHaiQuanKinhDoanh"].Value = frmDanhMucDoiTuongValid.dataRows[0]["Ma"].ToString();
            //            uCell.Row.Cells["TenDanhMucChiPhiHaiQuanKinhDoanh"].Value = frmDanhMucDoiTuongValid.dataRows[0]["Ten"].ToString();
            //        }
            //    }
            //    GridValidation = true;
            //    return;
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

            ugChiTiet.UpdateData();


            foreach (UltraGridRow row in ugChiTiet.Rows)
            {
                if (!coreCommon.coreCommon.IsNull(row.Cells["LoaiThanhToanTamUng"].Value))
                {
                    if (coreCommon.coreCommon.IsNull(row.Cells["IDDanhMucCanBoThanhToanTamUng"].Value))
                    {
                        coreCommon.coreCommon.ErrorMessageOkOnly("Mã cán bộ thanh toán tạm ứng ở dòng thứ " + (row.Index + 1).ToString() + " không hợp lệ!");
                        ugChiTiet.Rows[row.Index].Activate();
                        ugChiTiet.Rows[row.Index].Cells["MaDanhMucCanBoThanhToanTamUng"].Activate();
                        ugChiTiet.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                    if (coreCommon.coreCommon.IsNull(row.Cells["NgayThanhToanTamUng"].Value))
                    {
                        coreCommon.coreCommon.ErrorMessageOkOnly("Ngày thanh toán tạm ứng ở dòng thứ " + (row.Index + 1).ToString() + " không hợp lệ!");
                        ugChiTiet.Rows[row.Index].Activate();
                        ugChiTiet.Rows[row.Index].Cells["NgayThanhToanTamUng"].Activate();
                        ugChiTiet.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                }
            }


            bsChungTu.EndEdit();
            bsChungTuChiTiet.EndEdit();

            DataRow dataRow = ((DataRowView)bsChungTu.Current).Row;

            List<ctThanhToanTamUng> lstObj = new List<ctThanhToanTamUng>();

            foreach (DataRow drChiTiet in dsChungTu.Tables[ctThanhToanTamUng.tableName].Rows)
            {
                if (drChiTiet.RowState != DataRowState.Deleted)
                {
                    if (!coreCommon.coreCommon.IsNull(drChiTiet["LoaiThanhToanTamUng"]))
                    {
                        if (drChiTiet.RowState == DataRowState.Added)
                        {
                            lstObj.Add(new ctThanhToanTamUng()
                            {
                                ID = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? drChiTiet["ID"] : null,
                                IDDanhMucDonVi = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? dataRow["IDDanhMucDonVi"] : coreCommon.GlobalVariables.IDDonVi,
                                IDDanhMucChungTu = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? dataRow["IDDanhMucChungTu"] : IDDanhMucChungTu,
                                IDChungTu = dataRow["ID"],
                                IDChungTuChiTiet = dataRow["IDctDonHangChiTietTamUng"],
                                //
                                LoaiThanhToanTamUng = drChiTiet["LoaiThanhToanTamUng"],
                                IDDanhMucCanBoThanhToanTamUng = drChiTiet["IDDanhMucCanBoThanhToanTamUng"],
                                MaDanhMucCanBoThanhToanTamUng = drChiTiet["MaDanhMucCanBoThanhToanTamUng"],
                                TenDanhMucCanBoThanhToanTamUng = drChiTiet["TenDanhMucCanBoThanhToanTamUng"],
                                NgayThanhToanTamUng = drChiTiet["NgayThanhToanTamUng"],
                                SoTienHoanTamUng = drChiTiet["SoTienHoanTamUng"],
                                IDDanhMucChiPhiHaiQuanKinhDoanh = drChiTiet["IDDanhMucChiPhiHaiQuanKinhDoanh"],
                                MaDanhMucChiPhiHaiQuanKinhDoanh = drChiTiet["MaDanhMucChiPhiHaiQuanKinhDoanh"],
                                TenDanhMucChiPhiHaiQuanKinhDoanh = drChiTiet["TenDanhMucChiPhiHaiQuanKinhDoanh"],
                                SoTienChiThuTuc = drChiTiet["SoTienChiThuTuc"],
                                SoTienChiTraHoCoHoaDon = drChiTiet["SoTienChiTraHoCoHoaDon"],
                                SoTienChiCuocVo = drChiTiet["SoTienChiCuocVo"],
                                SoHoaDon = drChiTiet["SoHoaDon"],
                                GhiChu = drChiTiet["GhiChu"],
                                //
                                IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                                CreateDate = null,
                                DataRowState = DataRowState.Added
                            }
                            );
                        }
                        if (drChiTiet.RowState == DataRowState.Modified)
                        {
                            lstObj.Add(new ctThanhToanTamUng()
                            {
                                ID = drChiTiet["ID"],
                                IDDanhMucDonVi = dataRow["IDDanhMucDonVi"],
                                IDDanhMucChungTu = dataRow["IDDanhMucChungTu"],
                                IDChungTu = dataRow["ID"],
                                IDChungTuChiTiet = dataRow["IDctDonHangChiTietTamUng"],
                                //
                                LoaiThanhToanTamUng = drChiTiet["LoaiThanhToanTamUng"],
                                IDDanhMucCanBoThanhToanTamUng = drChiTiet["IDDanhMucCanBoThanhToanTamUng"],
                                MaDanhMucCanBoThanhToanTamUng = drChiTiet["MaDanhMucCanBoThanhToanTamUng"],
                                TenDanhMucCanBoThanhToanTamUng = drChiTiet["TenDanhMucCanBoThanhToanTamUng"],
                                NgayThanhToanTamUng = drChiTiet["NgayThanhToanTamUng"],
                                SoTienHoanTamUng = drChiTiet["SoTienHoanTamUng"],
                                IDDanhMucChiPhiHaiQuanKinhDoanh = drChiTiet["IDDanhMucChiPhiHaiQuanKinhDoanh"],
                                MaDanhMucChiPhiHaiQuanKinhDoanh = drChiTiet["MaDanhMucChiPhiHaiQuanKinhDoanh"],
                                TenDanhMucChiPhiHaiQuanKinhDoanh = drChiTiet["TenDanhMucChiPhiHaiQuanKinhDoanh"],
                                SoTienChiThuTuc = drChiTiet["SoTienChiThuTuc"],
                                SoTienChiTraHoCoHoaDon = drChiTiet["SoTienChiTraHoCoHoaDon"],
                                SoTienChiCuocVo = drChiTiet["SoTienChiCuocVo"],
                                SoHoaDon = drChiTiet["SoHoaDon"],
                                GhiChu = drChiTiet["GhiChu"],
                                //
                                IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                                IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                                CreateDate = null,
                                DataRowState = (coreCommon.coreCommon.IsNull(drChiTiet["ID"])) ? DataRowState.Added : DataRowState.Modified
                            }
                            );
                        }
                    }
                }
                else
                {
                    if (!coreCommon.coreCommon.IsNull(drChiTiet["LoaiThanhToanTamUng", DataRowVersion.Original]))
                    {
                        lstObj.Add(new ctThanhToanTamUng()
                        {
                            ID = drChiTiet["ID", DataRowVersion.Original],
                            //
                            LoaiThanhToanTamUng = drChiTiet["LoaiThanhToanTamUng", DataRowVersion.Original],
                            IDDanhMucCanBoThanhToanTamUng = drChiTiet["IDDanhMucCanBoThanhToanTamUng", DataRowVersion.Original],
                            MaDanhMucCanBoThanhToanTamUng = drChiTiet["MaDanhMucCanBoThanhToanTamUng", DataRowVersion.Original],
                            TenDanhMucCanBoThanhToanTamUng = drChiTiet["TenDanhMucCanBoThanhToanTamUng", DataRowVersion.Original],
                            NgayThanhToanTamUng = drChiTiet["NgayThanhToanTamUng", DataRowVersion.Original],
                            SoTienHoanTamUng = drChiTiet["SoTienHoanTamUng", DataRowVersion.Original],
                            IDDanhMucChiPhiHaiQuanKinhDoanh = drChiTiet["IDDanhMucChiPhiHaiQuanKinhDoanh", DataRowVersion.Original],
                            MaDanhMucChiPhiHaiQuanKinhDoanh = drChiTiet["MaDanhMucChiPhiHaiQuanKinhDoanh", DataRowVersion.Original],
                            TenDanhMucChiPhiHaiQuanKinhDoanh = drChiTiet["TenDanhMucChiPhiHaiQuanKinhDoanh", DataRowVersion.Original],
                            SoTienChiThuTuc = drChiTiet["SoTienChiThuTuc", DataRowVersion.Original],
                            SoTienChiTraHoCoHoaDon = drChiTiet["SoTienChiTraHoCoHoaDon", DataRowVersion.Original],
                            SoTienChiCuocVo = drChiTiet["SoTienChiCuocVo", DataRowVersion.Original],
                            SoHoaDon = drChiTiet["SoHoaDon", DataRowVersion.Original],
                            //
                            GhiChu = drChiTiet["GhiChu", DataRowVersion.Original],
                            DataRowState = drChiTiet.RowState
                        }
                        );
                    }
                }

            }
            bus = new ctThanhToanTamUngBUS();
            Saved = (UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? bus.Insert(lstObj) : bus.Update(lstObj); // bus.Update(ref new ctThanhToanTamUng());
            if (Saved)
            {
                int i = -1;
                if (!coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow))
                {
                    i = ugChiTiet.ActiveRow.Index;
                }

                bus = new ctThanhToanTamUngBUS();

                dsChungTu = bus.List(IDDanhMucChungTu, IDChungTu, IDChungTuChiTiet);

                bsChungTu = new BindingSource();
                bsChungTu.DataSource = dsChungTu;
                bsChungTu.DataMember = ctDonHang.tableName;
                bsChungTuChiTiet = new BindingSource();
                bsChungTuChiTiet.DataSource = bsChungTu;
                bsChungTuChiTiet.DataMember = coreCommon.GlobalVariables.prefix_DataRelation + ctThanhToanTamUng.tableName;

                ugChiTiet.ReadOnlyColumnsList = "[TenDanhMucCanBoThanhToanTamUng][TenDanhMucChiPhiHaiQuanKinhDoanh]";
                ugChiTiet.DataSource = bsChungTuChiTiet;
                ugChiTiet.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.Default;
                ugChiTiet.DisplayLayout.Bands[0].Columns["LoaiThanhToanTamUng"].EditorComponent = cboLoaiThanhToanTamUng;
                ugChiTiet.DisplayLayout.Bands[0].Columns["LoaiThanhToanTamUng"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

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
            //if (!ctThanhToanTamUngBUS.GetSuaXoa(dataRow["ID"]))
            //{
            //    coreCommon.coreCommon.ErrorMessageOkOnly("Không in được chứng từ đã bị hủy!");
            //    return;
            //}
            //String IDChungTu = dataRow["ID"].ToString();
            //String IDDanhMucChungTu = dataRow["IDDanhMucChungTu"].ToString();
            //cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu, IDChungTu, ctThanhToanTamUng.tableName, ctThanhToanTamUng.tableNameChiTiet, this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"\" + ctThanhToanTamUng.reportFileName, ctThanhToanTamUng.listProcedureName, TenMayIn, 2, LoaiManHinh, 0);
        }
        protected override void themChungTuChiTiet()
        {
            GridValidation = false;
            bsChungTuChiTiet.AddNew();
            ugChiTiet.Focus();
            ugChiTiet.DisplayLayout.Rows[ugChiTiet.DisplayLayout.Rows.Count - 1].Activate();
            if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value))
            {
                ugChiTiet.ActiveRow.Cells["ID"].Value = coreCommon.coreCommon.MaxTempID(dsChungTu.Tables[ctThanhToanTamUng.tableName]);
            }
            ugChiTiet.ActiveCell = ugChiTiet.ActiveRow.Cells["LoaiThanhToanTamUng"];
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
                ugChiTiet.Rows[i].Cells["LoaiThanhToanTamUng"].Activate();
                ugChiTiet.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion Method
        #region FormEvents
        private void frm_ctThanhToanTamUng_Load(object sender, EventArgs e)
        {
            txtNgayDongTraHang.MaskInput = coreCommon.GlobalVariables.MaskInputDate;
            //
            loadValidDataSet();
            loadData();
            //
            setCustomsDataBindings();
            //
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Them)
                themChungTu();
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Sua)
                suaChungTu();
            //
        }
        private void toolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            //switch (e.Tool.Key)
            //{
            //    case "ctDeNghiThanhToanHoanUng":
            //        if (UpdateMode != coreCommon.ThaoTacDuLieu.Xem) luuChungTu(false);
            //        if (!coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value))
            //            cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu.ToString(), ugChiTiet.ActiveRow.Cells["ID"].Value.ToString(), ctDonHang.tableName, "", this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"ctDeNghiThanhToanHoanUng.rpt", ctThanhToanTamUng.listDeNghiThanhToanHoanUngProcedureName, "", 1, LoaiManHinh, 1);
            //        break;
            //    case "ctDeNghiThanhToan":
            //        if (UpdateMode != coreCommon.ThaoTacDuLieu.Xem) luuChungTu(false);
            //        if (!coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["IDChungTu"].Value))
            //            cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu.ToString(), ugChiTiet.ActiveRow.Cells["IDChungTu"].Value.ToString(), ctDonHang.tableName, ctThanhToanTamUng.tableName, this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"ctDeNghiThanhToanTamUng.rpt", ctThanhToanTamUng.listDeNghiThanhToanProcedureName, "", 1, LoaiManHinh, 1);
            //        break;
            //    case "ctDeNghiThanhToanGuiKhachHang":
            //        if (UpdateMode != coreCommon.ThaoTacDuLieu.Xem) luuChungTu(false);
            //        if (!coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["IDChungTu"].Value))
            //            cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu.ToString(), ugChiTiet.ActiveRow.Cells["IDChungTu"].Value.ToString(), ctDonHang.tableName, ctThanhToanTamUng.tableName, this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"ctDeNghiThanhToanTamUngGuiKH.rpt", ctThanhToanTamUng.listDeNghiThanhToanGuiKhachHangProcedureName, "", 1, LoaiManHinh, 1);
            //        break;
            //    case "ctDeNghiThanhToanGuiKhachHangEXCEL":

            //        IWorkbook wbMau;
            //        IRow ro;
            //        ISheet sh;
            //        //1. Mở file mẫu
            //        string FullExcelTemplateFileName = coreCommon.GlobalVariables.ExcelTemplateDir + @"DE_NGHI_THANH_TOAN_TAM_UNG_GUI_KH.xlsx";

            //        if (string.IsNullOrEmpty(FullExcelTemplateFileName) || string.IsNullOrWhiteSpace(FullExcelTemplateFileName))
            //        {
            //            FullExcelTemplateFileName = coreCommon.coreCommon.OpenFileDialog("Chọn file mẫu", "", "Excel file (*.xlsx)|*.xlsx");
            //        }
            //        if (!File.Exists(FullExcelTemplateFileName)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không tìm thấy file mẫu " + FullExcelTemplateFileName + "!"); return; }
            //        //2.Tạo file kết quả
            //        ctDonHangBUS ctDonHangBUS = new ctDonHangBUS();
            //        DataSet dsDonHang = ctDonHangBUS.List(IDDanhMucChungTu, IDChungTu);
            //        if (dsDonHang == null || dsDonHang.Tables[ctDonHang.tableName].Rows.Count == 0) return;
            //        DataRow dataRow = dsDonHang.Tables[ctDonHang.tableName].Rows[0];

            //        string fName = coreCommon.GlobalVariables.OutputDir + @"\DE_NGHI_THANH_TOAN_TAM_UNG_GUI_KH_" + dataRow["So"].ToString() + @".xlsx";
            //        String FileName = coreCommon.coreCommon.OpenSaveFileDialog("Chọn file lưu kết quả export", fName, "Excel file (*.xlsx)|*.xlsx");
            //        if (FileName == "") return;
            //        if (File.Exists(FileName)) File.Delete(FileName);
            //        using (FileStream fsMau = new FileStream(FullExcelTemplateFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            //        {
            //            wbMau = new XSSFWorkbook(fsMau);
            //            if (wbMau == null) throw new Exception($"Không mở được file Excel: {FullExcelTemplateFileName}");
            //            fsMau.Close();
            //        }

            //        sh = wbMau.GetSheet("Sheet1");
            //        //3. Điền dữ liệu
            //        sh.GetRow(1).GetCell(0).SetCellValue("Hải Phòng, ngày " + DateTime.Now.Day.ToString("0#") + " tháng " + DateTime.Now.Month.ToString("0#") + " năm " + DateTime.Now.Year.ToString("000#"));
            //        sh.GetRow(3).GetCell(0).SetCellValue("(Debit note " + dataRow["DebitNote"].ToString() + ")");
            //        sh.GetRow(4).GetCell(0).SetCellValue("Kính gửi: " + dataRow["TenDanhMucKhachHang"].ToString());
            //        sh.GetRow(6).GetCell(1).SetCellValue("-Hồ sơ số: " + dataRow["DebitNote"].ToString());
            //        sh.GetRow(7).GetCell(4).SetCellValue("-Số bill/booking: " + dataRow["BillBooking"].ToString());
            //        sh.GetRow(8).GetCell(1).SetCellValue("-Trọng lượng: " + dataRow["KhoiLuong"].ToString());
            //        sh.GetRow(9).GetCell(1).SetCellValue("-Số container: " + dataRow["SoContainer"].ToString());

            //        int SoDongBatDau = 13;
            //        DataTable dtDeNghiThanhToanGuiKhachHang = bus.ListDeNghiThanhToanTamUngGuiKhachHang(IDDanhMucChungTu, IDChungTu);
            //        foreach (DataRow drDeNghiThanhToanGuiKhachHang in dtDeNghiThanhToanGuiKhachHang.Rows)
            //        {
            //            sh.GetRow(SoDongBatDau).GetCell(0).SetCellValue(SoDongBatDau - 12);
            //            sh.GetRow(SoDongBatDau).GetCell(1).SetCellValue(drDeNghiThanhToanGuiKhachHang["TenDanhMucChiPhiHaiQuanKinhDoanh"].ToString());
            //            sh.GetRow(SoDongBatDau).GetCell(2).SetCellValue(drDeNghiThanhToanGuiKhachHang["SoTienChiThuTuc"].ToString());
            //            sh.GetRow(SoDongBatDau).GetCell(3).SetCellValue(drDeNghiThanhToanGuiKhachHang["SoTienChiTraHoCoHoaDon"].ToString());
            //            sh.GetRow(SoDongBatDau).GetCell(4).SetCellValue(drDeNghiThanhToanGuiKhachHang["SoTienChiCuocVo"].ToString());
            //            SoDongBatDau += 1;
            //        }

            //        if (dtDeNghiThanhToanGuiKhachHang.Rows.Count > 0)
            //        {
            //            sh.GetRow(26).GetCell(2).SetCellValue(dtDeNghiThanhToanGuiKhachHang.Rows[0]["TongSoTienChiThuTuc"].ToString());
            //            sh.GetRow(26).GetCell(3).SetCellValue(dtDeNghiThanhToanGuiKhachHang.Rows[0]["TongSoTienChiTraHoCoHoaDon"].ToString());
            //            sh.GetRow(26).GetCell(4).SetCellValue(dtDeNghiThanhToanGuiKhachHang.Rows[0]["TongSoTienChiCuocVo"].ToString());
            //            sh.GetRow(27).GetCell(2).SetCellValue(dtDeNghiThanhToanGuiKhachHang.Rows[0]["SoTienVATChiThuTuc"].ToString());
            //            sh.GetRow(28).GetCell(2).SetCellValue(dtDeNghiThanhToanGuiKhachHang.Rows[0]["TongSoTienChiThuTucTotal"].ToString());
            //            sh.GetRow(28).GetCell(3).SetCellValue(dtDeNghiThanhToanGuiKhachHang.Rows[0]["TongSoTienChiTraHoCoHoaDon"].ToString());
            //            sh.GetRow(28).GetCell(4).SetCellValue(dtDeNghiThanhToanGuiKhachHang.Rows[0]["TongSoTienChiCuocVo"].ToString());
            //            sh.GetRow(29).GetCell(2).SetCellValue(dtDeNghiThanhToanGuiKhachHang.Rows[0]["TongSoTienThanhToan"].ToString());
            //            sh.GetRow(30).GetCell(0).SetCellValue("Số tiền bằng chữ: " + cenCommon.cenCommon.SoTienBangChu(Math.Round(Double.Parse(dtDeNghiThanhToanGuiKhachHang.Rows[0]["TongSoTienThanhToan"].ToString()), 0).ToString()) + " đồng.");
            //        }
            //        //4. Save            
            //        using (var fskq = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
            //        {
            //            wbMau.Write(fskq);
            //        }
            //        wbMau.Close();
            //        //
            //        if (coreCommon.coreCommon.QuestionMessage("Đã kết xuất báo cáo, bạn có muốn mở file ra không?", 0) == DialogResult.Yes)
            //        {
            //            System.Diagnostics.Process.Start(FileName);
            //        }
            //        break;
            //    default:
            //        //In phiếu yêu cầu vận chuyển
            //        break;
            //}
        }
        private void ugChiTiet_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(e.Cell.Row.Cells["LoaiThanhToanTamUng"].Value))
            {
                e.Cell.Row.Cells["MaDanhMucCanBoThanhToanTamUng"].Column.CellActivation = Activation.NoEdit;
                e.Cell.Row.Cells["MaDanhMucCanBoThanhToanTamUng"].Column.CellClickAction = CellClickAction.CellSelect;
                e.Cell.Row.Cells["NgayThanhToanTamUng"].Column.CellActivation = Activation.NoEdit;
                e.Cell.Row.Cells["NgayThanhToanTamUng"].Column.CellClickAction = CellClickAction.CellSelect;
                e.Cell.Row.Cells["SoTienHoanTamUng"].Column.CellActivation = Activation.NoEdit;
                e.Cell.Row.Cells["SoTienHoanTamUng"].Column.CellClickAction = CellClickAction.CellSelect;
                e.Cell.Row.Cells["MaDanhMucChiPhiHaiQuanKinhDoanh"].Column.CellActivation = Activation.NoEdit;
                e.Cell.Row.Cells["MaDanhMucChiPhiHaiQuanKinhDoanh"].Column.CellClickAction = CellClickAction.CellSelect;
                e.Cell.Row.Cells["SoTienChiThuTuc"].Column.CellActivation = Activation.NoEdit;
                e.Cell.Row.Cells["SoTienChiThuTuc"].Column.CellClickAction = CellClickAction.CellSelect;
                e.Cell.Row.Cells["SoTienChiTraHoCoHoaDon"].Column.CellActivation = Activation.NoEdit;
                e.Cell.Row.Cells["SoTienChiTraHoCoHoaDon"].Column.CellClickAction = CellClickAction.CellSelect;
                e.Cell.Row.Cells["SoTienChiCuocVo"].Column.CellActivation = Activation.NoEdit;
                e.Cell.Row.Cells["SoTienChiCuocVo"].Column.CellClickAction = CellClickAction.CellSelect;
                e.Cell.Row.Cells["SoHoaDon"].Column.CellActivation = Activation.NoEdit;
                e.Cell.Row.Cells["SoHoaDon"].Column.CellClickAction = CellClickAction.CellSelect;
                e.Cell.Row.Cells["GhiChu"].Column.CellActivation = Activation.NoEdit;
                e.Cell.Row.Cells["GhiChu"].Column.CellClickAction = CellClickAction.CellSelect;
                return;
            }
            e.Cell.Row.Cells["MaDanhMucCanBoThanhToanTamUng"].Column.CellActivation = Activation.AllowEdit;
            e.Cell.Row.Cells["MaDanhMucCanBoThanhToanTamUng"].Column.CellClickAction = CellClickAction.EditAndSelectText;
            e.Cell.Row.Cells["NgayThanhToanTamUng"].Column.CellActivation = Activation.AllowEdit;
            e.Cell.Row.Cells["NgayThanhToanTamUng"].Column.CellClickAction = CellClickAction.EditAndSelectText;
            e.Cell.Row.Cells["GhiChu"].Column.CellActivation = Activation.AllowEdit;
            e.Cell.Row.Cells["GhiChu"].Column.CellClickAction = CellClickAction.EditAndSelectText;
            if (e.Cell.Column.Key == "SoTienHoanTamUng" || e.Cell.Column.Key == "MaDanhMucChiPhiHaiQuanKinhDoanh" || e.Cell.Column.Key == "SoTienChiThuTuc" || e.Cell.Column.Key == "SoTienChiTraHoCoHoaDon" || e.Cell.Column.Key == "SoTienChiCuoc")
            {
                switch (e.Cell.Row.Cells["LoaiThanhToanTamUng"].Value.ToString())
                {
                    case "1": //Hoàn tạm ứng
                        e.Cell.Row.Cells["SoTienHoanTamUng"].Column.CellActivation = Activation.AllowEdit;
                        e.Cell.Row.Cells["SoTienHoanTamUng"].Column.CellClickAction = CellClickAction.EditAndSelectText;
                        e.Cell.Row.Cells["MaDanhMucChiPhiHaiQuanKinhDoanh"].Column.CellActivation = Activation.NoEdit;
                        e.Cell.Row.Cells["MaDanhMucChiPhiHaiQuanKinhDoanh"].Column.CellClickAction = CellClickAction.CellSelect;
                        e.Cell.Row.Cells["SoTienChiThuTuc"].Column.CellActivation = Activation.NoEdit;
                        e.Cell.Row.Cells["SoTienChiThuTuc"].Column.CellClickAction = CellClickAction.CellSelect;
                        e.Cell.Row.Cells["SoTienChiTraHoCoHoaDon"].Column.CellActivation = Activation.NoEdit;
                        e.Cell.Row.Cells["SoTienChiTraHoCoHoaDon"].Column.CellClickAction = CellClickAction.CellSelect;
                        e.Cell.Row.Cells["SoTienChiCuocVo"].Column.CellActivation = Activation.NoEdit;
                        e.Cell.Row.Cells["SoTienChiCuocVo"].Column.CellClickAction = CellClickAction.CellSelect;
                        e.Cell.Row.Cells["SoHoaDon"].Column.CellActivation = Activation.NoEdit;
                        e.Cell.Row.Cells["SoHoaDon"].Column.CellClickAction = CellClickAction.CellSelect;
                        break;
                    case "2": //Đề nghị thanh toán
                        e.Cell.Row.Cells["SoTienHoanTamUng"].Column.CellActivation = Activation.NoEdit;
                        e.Cell.Row.Cells["SoTienHoanTamUng"].Column.CellClickAction = CellClickAction.CellSelect;
                        e.Cell.Row.Cells["MaDanhMucChiPhiHaiQuanKinhDoanh"].Column.CellActivation = Activation.AllowEdit;
                        e.Cell.Row.Cells["MaDanhMucChiPhiHaiQuanKinhDoanh"].Column.CellClickAction = CellClickAction.EditAndSelectText;
                        e.Cell.Row.Cells["SoTienChiThuTuc"].Column.CellActivation = Activation.AllowEdit;
                        e.Cell.Row.Cells["SoTienChiThuTuc"].Column.CellClickAction = CellClickAction.EditAndSelectText;
                        e.Cell.Row.Cells["SoTienChiTraHoCoHoaDon"].Column.CellActivation = Activation.AllowEdit;
                        e.Cell.Row.Cells["SoTienChiTraHoCoHoaDon"].Column.CellClickAction = CellClickAction.EditAndSelectText;
                        e.Cell.Row.Cells["SoTienChiCuocVo"].Column.CellActivation = Activation.AllowEdit;
                        e.Cell.Row.Cells["SoTienChiCuocVo"].Column.CellClickAction = CellClickAction.EditAndSelectText;
                        e.Cell.Row.Cells["SoHoaDon"].Column.CellActivation = Activation.AllowEdit;
                        e.Cell.Row.Cells["SoHoaDon"].Column.CellClickAction = CellClickAction.EditAndSelectText;
                        break;
                }
            }
        }
        #endregion FormEvents
    }



}
