using coreBase.BaseForms;
using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctChiPhiVanTaiBoSungUpdate : frmBaseChungTuMasterDetail
    {
        public Form mdiParent;
        DataTable dtTrangThai;
        ctChiPhiVanTaiBoSungBUS bus;
        public frm_ctChiPhiVanTaiBoSungUpdate()
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
        }
        protected void loadData()
        {
            bus = new ctChiPhiVanTaiBoSungBUS();
            dsChungTu = bus.List(IDDanhMucChungTu, IDChungTu);
            bsChungTu = new BindingSource();
            bsChungTu.DataSource = dsChungTu;
            bsChungTu.DataMember = ctDonHang.tableName;
            bsChungTuChiTiet = new BindingSource();
            bsChungTuChiTiet.DataSource = bsChungTu;
            bsChungTuChiTiet.DataMember = coreCommon.GlobalVariables.prefix_DataRelation + ctChiPhiVanTaiBoSung.tableName;
            ugChiTiet.HiddenColumnsList = "[SoTienTongLuuCaKhacLuatDuongCam][MaDanhMucNguoiSuDungCreate][CreateDate][MaDanhMucNguoiSuDungEdit][EditDate]";
            ugChiTiet.DataSource = bsChungTuChiTiet;
            ugChiTiet.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.Default;
            tabChiTiet.Tabs["ChiTiet"].Text = coreCommon.coreCommon.TraTuDien(ctChiPhiVanTaiBoSung.tableName) + "-CTRL + INSERT: Thêm dòng; CTRL + DELETE: Xóa dòng";
        }
        protected override void themChungTu()
        {
            bsChungTu.AddNew();

            ugChiTiet.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            ugChiTiet.DisplayLayout.Bands[0].Columns["NgayBoSung"].CellClickAction = CellClickAction.EditAndSelectText;
            ugChiTiet.DisplayLayout.Bands[0].Columns["NgayBoSung"].CellActivation = Activation.AllowEdit;
            ugChiTiet.DisplayLayout.Bands[0].Columns["NgayBoSung"].DefaultCellValue = coreCommon.coreCommon.NgayHachToan();

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
            ugChiTiet.DisplayLayout.Bands[0].Columns["NgayBoSung"].DefaultCellValue = coreCommon.coreCommon.NgayHachToan();
            //
            txtNgayDongTraHang.Focus();
        }
        protected void setCustomsDataBindings()
        {
            txtSoDonHang.SetDataBinding(bsChungTu, "So", false, DataSourceUpdateMode.OnPropertyChanged);
            txtNgayDongTraHang.SetDataBinding(bsChungTu, "NgayDongTraHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDanhMucKhachHang.SetDataBinding(bsChungTu, "TenDanhMucKhachHang", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoXe.SetDataBinding(bsChungTu, "BienSo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDebitNote.SetDataBinding(bsChungTu, "DebitNote", false, DataSourceUpdateMode.OnPropertyChanged);
            txtBillBooking.SetDataBinding(bsChungTu, "BillBooking", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDanhMucNhomHangVanChuyen.SetDataBinding(bsChungTu, "TenDanhMucNhomHangVanChuyen", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDanhMucHangHoa.SetDataBinding(bsChungTu, "TenDanhMucHangHoa", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDanhMucTuyenVanTai.SetDataBinding(bsChungTu, "TenDanhMucTuyenVanTai", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoLuongNhienLieu.SetDataBinding(bsChungTu, "SoLuongNhienLieu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienVeCauDuong.SetDataBinding(bsChungTu, "SoTienVeCauDuong", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienLuatAnCa.SetDataBinding(bsChungTu, "SoTienLuatAnCa", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienKetHopVeCauDuongLuatAnCa.SetDataBinding(bsChungTu, "SoTienKetHopVeCauDuongLuatAnCa", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienLuuCaKhac.SetDataBinding(bsChungTu, "SoTienLuuCaKhac", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienLuatDuongCam.SetDataBinding(bsChungTu, "SoTienLuatDuongCam", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienTongLuuCaKhacLuatDuongCam.SetDataBinding(bsChungTu, "SoTienTongLuuCaKhacLuatDuongCam", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienLuongChuyen.SetDataBinding(bsChungTu, "SoTienLuongChuyen", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienLuongChuNhat.SetDataBinding(bsChungTu, "SoTienLuongChuNhat", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTienCuocThueXeNgoai.SetDataBinding(bsChungTu, "SoTienCuocThueXeNgoai", false, DataSourceUpdateMode.OnPropertyChanged);

        }
        protected override void gridColumnDataProcess(UltraGrid ug, UltraGridCell uCell, out bool GridValidation, bool ShowLookUp)
        {
            GridValidation = true;
            if (uCell.Row.IsFilterRow) return;
        }
        protected override void filter()
        {
        }
        protected override void luuChungTu(bool Exit)
        {
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Xem) return;

            ugChiTiet.UpdateData();

            bsChungTu.EndEdit();
            bsChungTuChiTiet.EndEdit();

            DataRow dataRow = ((DataRowView)bsChungTu.Current).Row;

            List<ctChiPhiVanTaiBoSung> lstObj = new List<ctChiPhiVanTaiBoSung>();

            foreach (DataRow drChiTiet in dsChungTu.Tables[ctChiPhiVanTaiBoSung.tableName].Rows)
            {
                if (drChiTiet.RowState != DataRowState.Deleted)
                {
                    if (!coreCommon.coreCommon.IsNull(drChiTiet["NgayBoSung"]))
                    {
                        if (drChiTiet.RowState == DataRowState.Added)
                        {
                            lstObj.Add(new ctChiPhiVanTaiBoSung()
                            {
                                ID = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? drChiTiet["ID"] : null,
                                IDDanhMucDonVi = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? dataRow["IDDanhMucDonVi"] : coreCommon.GlobalVariables.IDDonVi,
                                IDDanhMucChungTu = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? dataRow["IDDanhMucChungTu"] : IDDanhMucChungTu,
                                IDChungTu = dataRow["ID"],
                                //
                                NgayBoSung = drChiTiet["NgayBoSung"],
                                SoLuongNhienLieu = drChiTiet["SoLuongNhienLieu"],
                                SoTienVeCauDuong = drChiTiet["SoTienVeCauDuong"],
                                SoTienLuatAnCa = drChiTiet["SoTienLuatAnCa"],
                                SoTienKetHopVeCauDuongLuatAnCa = drChiTiet["SoTienKetHopVeCauDuongLuatAnCa"],
                                SoTienLuuCaKhac = drChiTiet["SoTienLuuCaKhac"],
                                SoTienLuatDuongCam = drChiTiet["SoTienLuatDuongCam"],
                                SoTienTongLuuCaKhacLuatDuongCam = drChiTiet["SoTienTongLuuCaKhacLuatDuongCam"],
                                SoTienLuongChuyen = drChiTiet["SoTienLuongChuyen"],
                                SoTienLuongChuNhat = drChiTiet["SoTienLuongChuNhat"],
                                SoTienCuocThueXeNgoai = drChiTiet["SoTienCuocThueXeNgoai"],
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
                            lstObj.Add(new ctChiPhiVanTaiBoSung()
                            {
                                ID = drChiTiet["ID"],
                                IDDanhMucDonVi = dataRow["IDDanhMucDonVi"],
                                IDDanhMucChungTu = dataRow["IDDanhMucChungTu"],
                                IDChungTu = dataRow["ID"],
                                //
                                NgayBoSung = drChiTiet["NgayBoSung"],
                                SoLuongNhienLieu = drChiTiet["SoLuongNhienLieu"],
                                SoTienVeCauDuong = drChiTiet["SoTienVeCauDuong"],
                                SoTienLuatAnCa = drChiTiet["SoTienLuatAnCa"],
                                SoTienKetHopVeCauDuongLuatAnCa = drChiTiet["SoTienKetHopVeCauDuongLuatAnCa"],
                                SoTienLuuCaKhac = drChiTiet["SoTienLuuCaKhac"],
                                SoTienLuatDuongCam = drChiTiet["SoTienLuatDuongCam"],
                                SoTienTongLuuCaKhacLuatDuongCam = drChiTiet["SoTienTongLuuCaKhacLuatDuongCam"],
                                SoTienLuongChuyen = drChiTiet["SoTienLuongChuyen"],
                                SoTienLuongChuNhat = drChiTiet["SoTienLuongChuNhat"],
                                SoTienCuocThueXeNgoai = drChiTiet["SoTienCuocThueXeNgoai"],
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
                    lstObj.Add(new ctChiPhiVanTaiBoSung()
                    {
                        ID = drChiTiet["ID", DataRowVersion.Original],
                        //
                        NgayBoSung = drChiTiet["NgayBoSung", DataRowVersion.Original],
                        SoLuongNhienLieu = drChiTiet["SoLuongNhienLieu", DataRowVersion.Original],
                        SoTienVeCauDuong = drChiTiet["SoTienVeCauDuong", DataRowVersion.Original],
                        SoTienLuatAnCa = drChiTiet["SoTienLuatAnCa", DataRowVersion.Original],
                        SoTienKetHopVeCauDuongLuatAnCa = drChiTiet["SoTienKetHopVeCauDuongLuatAnCa", DataRowVersion.Original],
                        SoTienLuuCaKhac = drChiTiet["SoTienLuuCaKhac", DataRowVersion.Original],
                        SoTienLuatDuongCam = drChiTiet["SoTienLuatDuongCam", DataRowVersion.Original],
                        SoTienTongLuuCaKhacLuatDuongCam = drChiTiet["SoTienTongLuuCaKhacLuatDuongCam", DataRowVersion.Original],
                        SoTienLuongChuyen = drChiTiet["SoTienLuongChuyen", DataRowVersion.Original],
                        SoTienLuongChuNhat = drChiTiet["SoTienLuongChuNhat", DataRowVersion.Original],
                        SoTienCuocThueXeNgoai = drChiTiet["SoTienCuocThueXeNgoai", DataRowVersion.Original],
                        GhiChu = drChiTiet["GhiChu", DataRowVersion.Original],
                        //
                        DataRowState = drChiTiet.RowState
                    }
                    );
                }

            }
            bus = new ctChiPhiVanTaiBoSungBUS();
            Saved = (UpdateMode == coreCommon.ThaoTacDuLieu.Them) ? bus.Insert(lstObj) : bus.Update(lstObj); // bus.Update(ref new ctChiPhiVanTaiBoSung());
            if (Saved)
            {
                int i = -1;
                if (!coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow))
                {
                    i = ugChiTiet.ActiveRow.Index;
                }

                bus = new ctChiPhiVanTaiBoSungBUS();

                dsChungTu = bus.List(IDDanhMucChungTu, IDChungTu);

                bsChungTu = new BindingSource();
                bsChungTu.DataSource = dsChungTu;
                bsChungTu.DataMember = ctDonHang.tableName;
                bsChungTuChiTiet = new BindingSource();
                bsChungTuChiTiet.DataSource = bsChungTu;
                bsChungTuChiTiet.DataMember = coreCommon.GlobalVariables.prefix_DataRelation + ctChiPhiVanTaiBoSung.tableName;
                ugChiTiet.DataSource = bsChungTuChiTiet;
                ugChiTiet.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.Default;

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
            //if (!ctChiPhiVanTaiBoSungBUS.GetSuaXoa(dataRow["ID"]))
            //{
            //    coreCommon.coreCommon.ErrorMessageOkOnly("Không in được chứng từ đã bị hủy!");
            //    return;
            //}
            //String IDChungTu = dataRow["ID"].ToString();
            //String IDDanhMucChungTu = dataRow["IDDanhMucChungTu"].ToString();
            //cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu, IDChungTu, ctChiPhiVanTaiBoSung.tableName, ctChiPhiVanTaiBoSung.tableNameChiTiet, this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"\" + ctChiPhiVanTaiBoSung.reportFileName, ctChiPhiVanTaiBoSung.listProcedureName, TenMayIn, 2, LoaiManHinh, 0);
        }
        protected override void themChungTuChiTiet()
        {
            GridValidation = false;
            bsChungTuChiTiet.AddNew();
            ugChiTiet.Focus();
            ugChiTiet.DisplayLayout.Rows[ugChiTiet.DisplayLayout.Rows.Count - 1].Activate();
            if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value))
            {
                ugChiTiet.ActiveRow.Cells["ID"].Value = coreCommon.coreCommon.MaxTempID(dsChungTu.Tables[ctChiPhiVanTaiBoSung.tableName]);
            }
            ugChiTiet.ActiveCell = ugChiTiet.ActiveRow.Cells["NgayBoSung"];
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
                ugChiTiet.Rows[i].Cells["NgayBoSung"].Activate();
                ugChiTiet.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion Method
        #region FormEvents
        private void frm_ctChiPhiVanTaiBoSung_Load(object sender, EventArgs e)
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
        #endregion FormEvents
    }
}
