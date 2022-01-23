using cenBUS.cenLogistics;
using coreBUS;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctDieuHanhUpdate : coreBase.BaseForms.frmBaseChungTuSingleUpdate
    {
        public object IDctDonHang = null;
        ctDieuHanh obj = null;
        DataTable dtXe, dtTaiXe, dtDonHangKetHop;
        public frm_ctDieuHanhUpdate()
        {
            InitializeComponent();
        }
        protected override void SaveData(bool AddNew)
        {
            if (Save())
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private bool Save()
        {
            if (!coreCommon.coreCommon.IsNull(ctDonHangBUS.GetIDctChotDoanhThuGuiKeToan(IDctDonHang))) { coreCommon.coreCommon.ErrorMessageOkOnly("Đơn hàng đã chốt doanh thu, không sửa được thông tin điều hành!"); return false; }
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucThauPhu.Value) || !cboIDDanhMucThauPhu.IsItemInList()) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu mã chủ xe!"); cboIDDanhMucThauPhu.Focus(); return false; }
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucXe.Value) || !cboIDDanhMucXe.IsItemInList()) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu số xe"); cboIDDanhMucXe.Focus(); return false; }
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucTaiXe.Value) || !cboIDDanhMucTaiXe.IsItemInList()) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu tên tài xế!"); cboIDDanhMucTaiXe.Focus(); return false; }

            if (UpdateMode == coreCommon.ThaoTacDuLieu.Them || UpdateMode == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.ctDieuHanh
                {
                    ID = dataRow["IDctDieuHanh"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    //
                    IDChungTu = IDctDonHang,
                    IDDanhMucThauPhu = cboIDDanhMucThauPhu.Value,
                    TenDanhMucThauPhu = txtTenDanhMucThauPhu.Value,
                    IDDanhMucXe = cboIDDanhMucXe.Value,
                    BienSo = cboIDDanhMucXe.Text,
                    IDDanhMucTaiXe = cboIDDanhMucTaiXe.Value,
                    TenDanhMucTaiXe = cboIDDanhMucTaiXe.Text,
                    TrangThaiDonHang = cboTrangThaiDonHang.Value,
                    SoDonHangKetHop = txtSoDonHangKetHop.Value,
                    DienThoai = txtDienThoai.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.ctDieuHanh
                {
                    ID = dataRow["IDctDieuHanh"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    //
                    IDChungTu = IDctDonHang,
                    IDDanhMucThauPhu = cboIDDanhMucThauPhu.Value,
                    TenDanhMucThauPhu = txtTenDanhMucThauPhu.Value,
                    IDDanhMucXe = cboIDDanhMucXe.Value,
                    BienSo = cboIDDanhMucXe.Text,
                    IDDanhMucTaiXe = cboIDDanhMucTaiXe.Value,
                    TenDanhMucTaiXe = cboIDDanhMucTaiXe.Text,
                    TrangThaiDonHang = cboTrangThaiDonHang.Value,
                    SoDonHangKetHop = txtSoDonHangKetHop.Value,
                    DienThoai = txtDienThoai.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.ctDieuHanhBUS _BUS = new cenBUS.cenLogistics.ctDieuHanhBUS();
            bool OK = (coreCommon.coreCommon.IsNull(dataRow["IDctDieuHanh"])) ? _BUS.Insert(ref obj) : _BUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                if (dataTable != null)
                {
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        if (prop.Name != "So" && prop.Name != "ID" && dataRow.Table.Columns.Contains(prop.Name))
                            dataRow[prop.Name] = !coreCommon.coreCommon.IsNull(prop.GetValue(obj, null)) ? prop.GetValue(obj, null) : DBNull.Value;
                    }
                }
                ID = obj.ID;
                dataRow["IDctDieuHanh"] = obj.ID;
                //Lưu danh sách đơn hàng kết hợp
                ctDieuHanhChiTietDonHangKetHopBUS ctDieuHanhChiTietDonHangKetHopBUS = new ctDieuHanhChiTietDonHangKetHopBUS();
                foreach (DataRow drDonHangKetHop in dtDonHangKetHop.Rows)
                {
                    if (drDonHangKetHop.RowState == DataRowState.Deleted)
                    {
                        if (!ctDieuHanhChiTietDonHangKetHopBUS.Delete(new ctDieuHanhChiTietDonHangKetHop() { ID = drDonHangKetHop["ID", DataRowVersion.Original] })) return false;
                    }
                    else
                    {
                        ctDieuHanhChiTietDonHangKetHop obj = new ctDieuHanhChiTietDonHangKetHop()
                        {
                            ID = drDonHangKetHop["ID"],
                            IDDanhMucChungTu = IDDanhMucChungTu,
                            IDChungTu = dataRow["ID"],
                            IDChungTuChiTiet = dataRow["IDctDieuHanh"],
                            IDctDonHang = drDonHangKetHop["IDctDonHang"],
                            GhiChu = drDonHangKetHop["GhiChu"]
                        };
                        if (drDonHangKetHop.RowState == DataRowState.Modified)
                        {
                            if (!ctDieuHanhChiTietDonHangKetHopBUS.Update(ref obj)) return false;
                        }
                        if (drDonHangKetHop.RowState == DataRowState.Added)
                        {
                            if (!ctDieuHanhChiTietDonHangKetHopBUS.Insert(ref obj)) return false;
                        }
                    }
                }
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
            ctDieuHanhBUS ctDieuHanhBUS = new ctDieuHanhBUS();
            dataRow = ctDieuHanhBUS.List2(IDDanhMucChungTu, IDctDonHang).Rows[0];

            ctDieuHanhChiTietDonHangKetHopBUS ctDieuHanhChiTietDonHangKetHopBUS = new ctDieuHanhChiTietDonHangKetHopBUS();
            dtDonHangKetHop = ctDieuHanhChiTietDonHangKetHopBUS.List(IDDanhMucChungTu, IDctDonHang);

            ////DanhMucTrangThaiChungTu
            //DanhMucChungTuTrangThaiBUS danhMucChungTuTrangThaiBUS = new DanhMucChungTuTrangThaiBUS();
            //DataTable dtTrangThai = danhMucChungTuTrangThaiBUS.List(null, IDDanhMucChungTu);
            //cboIDDanhMucTrangThaiChungTu.DataSource = dtTrangThai;
            //cboIDDanhMucTrangThaiChungTu.ValueMember = "ID";
            //cboIDDanhMucTrangThaiChungTu.DisplayMember = "Ten";
            //if (cboIDDanhMucTrangThaiChungTu.Items.Count > 0) cboIDDanhMucTrangThaiChungTu.SelectedItem = cboIDDanhMucTrangThaiChungTu.Items[0];
            ////Chủ xe
            //DanhMucThauPhuBUS DanhMucThauPhuBUS = new DanhMucThauPhuBUS();
            //DataTable dtChuXe = DanhMucThauPhuBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongThauPhu)), dataRow["IDDanhMucNhomHangVanChuyen"], null);
            //cboIDDanhMucThauPhu.dtValid = dtChuXe;
            //cboIDDanhMucThauPhu.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongThauPhu));
            //cboIDDanhMucThauPhu.procedureName = DanhMucThauPhu.listProcedureName;
            //cboIDDanhMucThauPhu.DataSource = dtChuXe;
            //cboIDDanhMucThauPhu.ValueMember = "ID";
            //cboIDDanhMucThauPhu.DisplayMember = "Ma";
            //cboIDDanhMucThauPhu.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);

            //cboTrangThaiDonHang.Items.Add("1", "Đơn");
            //cboTrangThaiDonHang.Items.Add("2", "Kết hợp");
            //cboTrangThaiDonHang.Items.Add("3", "Kẹp đôi");
            ////Xe
            //DanhMucXeBUS DanhMucXeBUS = new DanhMucXeBUS();
            //dtXe = DanhMucXeBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongXe)), null, null, null);
            //cboIDDanhMucXe.dtValid = dtXe;
            //cboIDDanhMucXe.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongXe));
            //cboIDDanhMucXe.procedureName = DanhMucXe.listProcedureName;
            //cboIDDanhMucXe.DataSource = dtXe;
            //cboIDDanhMucXe.ValueMember = "ID";
            //cboIDDanhMucXe.DisplayMember = "BienSo";
            //cboIDDanhMucXe.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);
            ////Tài xế
            //DanhMucTaiXeBUS DanhMucTaiXeBUS = new DanhMucTaiXeBUS();
            //dtTaiXe = DanhMucTaiXeBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTaiXe)), null, null);
            //cboIDDanhMucTaiXe.dtValid = dtTaiXe;
            //cboIDDanhMucTaiXe.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTaiXe));
            //cboIDDanhMucTaiXe.procedureName = DanhMucTaiXe.listProcedureName;
            //cboIDDanhMucTaiXe.DataSource = dtTaiXe;
            //cboIDDanhMucTaiXe.ValueMember = "ID";
            //cboIDDanhMucTaiXe.DisplayMember = "Ten";
            //cboIDDanhMucTaiXe.KeyDown += new System.Windows.Forms.KeyEventHandler(cenCommonUIapps.validDanhMuc.cboDanhMuc_KeyDown);
            //

            txtGioDongHang.MaskInput = coreCommon.GlobalVariables.MaskInputTime;
            txtGioTraHang.MaskInput = coreCommon.GlobalVariables.MaskInputTime;
            txtGioCatMang.MaskInput = coreCommon.GlobalVariables.MaskInputTime;
            //
            txtSo.Value = dataRow["So"];
            txtNgayLap.Value = dataRow["NgayLap"];
            cboIDDanhMucTrangThaiChungTu.Value = dataRow["IDDanhMucChungTuTrangThai"];
            txtMaDanhMucKhachHang.Value = dataRow["MaDanhMucKhachHang"];
            txtTenDanhMucKhachHang.Value = dataRow["TenDanhMucKhachHang"];
            txtSoTienCuoc.Value = dataRow["SoTienCuoc"];
            txtDebitNote.Value = dataRow["DebitNote"];
            txtTenLoaiHang.Value = dataRow["TenLoaiHang"];
            txtBillBooking.Value = dataRow["BillBooking"];
            txtMaDanhMucNhomHangVanChuyen.Value = dataRow["MaDanhMucNhomHangVanChuyen"];
            txtMaDanhMucHangHoa.Value = dataRow["MaDanhMucHangHoa"];
            txtKhoiLuong.Value = dataRow["KhoiLuong"];
            txtSoContainer.Value = dataRow["SoContainer"];
            txtTenDanhMucDiaDiemLayContHang.Value = dataRow["TenDanhMucDiaDiemLayContHang"];
            txtTenDanhMucDiaDiemTraContHang.Value = dataRow["TenDanhMucDiaDiemTraContHang"];
            txtNgayDongHang.Value = dataRow["NgayDongHang"];
            txtGioDongHang.Value = dataRow["GioDongHang"];
            txtNgayTraHang.Value = dataRow["NgayTraHang"];
            txtGioTraHang.Value = dataRow["GioTraHang"];
            txtTenDanhMucKhachHangF3DongHang.Value = dataRow["TenDanhMucKhachHangF3DongHang"];
            txtDiaChiDanhMucKhachHangF3DongHang.Value = dataRow["DiaChiDanhMucKhachHangF3DongHang"];
            txtTenDanhMucKhachHangF3TraHang.Value = dataRow["TenDanhMucKhachHangF3TraHang"];
            txtDiaChiDanhMucKhachHangF3TraHang.Value = dataRow["DiaChiDanhMucKhachHangF3TraHang"];
            txtTenDanhMucTuyenVanTai.Value = dataRow["TenDanhMucTuyenVanTai"];
            txtNgayCatMang.Value = dataRow["NgayCatMang"];
            txtGioCatMang.Value = dataRow["GioCatMang"];
            txtNguoiGiaoNhan.Value = dataRow["NguoiGiaoNhan"];
            txtSoDienThoaiGiaoNhan.Value = dataRow["SoDienThoaiGiaoNhan"];
            txtGhiChuCongViec.Value = dataRow["GhiChuCongViec"];
            //
            cboIDDanhMucThauPhu.Value = dataRow["IDDanhMucThauPhu"];
            txtTenDanhMucThauPhu.Value = dataRow["TenDanhMucThauPhu"];
            txtMaSoThueCMND.Value = dataRow["MaSoThueCMNDThauPhu"];
            cboIDDanhMucXe.Value = dataRow["IDDanhMucXe"];
            cboIDDanhMucTaiXe.Value = dataRow["IDDanhMucTaiXe"];
            txtDienThoai.Value = dataRow["DienThoai"];
            txtSoCMND.Value = dataRow["SoCMND"];
            cboTrangThaiDonHang.Value = dataRow["TrangThaiDonHang"];
            if (coreCommon.coreCommon.IsNull(cboTrangThaiDonHang.Value)) cboTrangThaiDonHang.Value = "1";
            foreach (DataRow drDonHangKetHop in dtDonHangKetHop.Rows)
            {
                txtSoDonHangKetHop.Value += drDonHangKetHop["SoDonHang"] + ";";
            }
            txtGhiChu.Value = dataRow["GhiChu"];
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Xem)
            {
                cmdSave.Enabled = false;
                cmdSaveNew.Enabled = false;
            }
        }
        private void cboIDDanhMucTaiXe_ValueChanged(object sender, EventArgs e)
        {
            txtDienThoai.Value = null;
            txtSoCMND.Value = null;
            //
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucTaiXe.Value) || !cboIDDanhMucTaiXe.IsItemInList()) return;
            DanhMucTaiXeBUS DanhMucTaiXeBUS = new DanhMucTaiXeBUS();
            DataTable dt = DanhMucTaiXeBUS.List(cboIDDanhMucTaiXe.Value, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTaiXe)), null, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtDienThoai.Value = dt.Rows[0]["SoDienThoai"];
                txtSoCMND.Value = dt.Rows[0]["SoCMND"];
            }
        }
        private void txtSoDonHangKetHop_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            OpenChiTietDonHangKetHop();
        }
        private void txtSoDonHangKetHop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                OpenChiTietDonHangKetHop();
            }
        }
        private void cboIDDanhMucThauPhu_ValueChanged(object sender, EventArgs e)
        {
            //
            txtTenDanhMucThauPhu.Value = null;
            txtMaSoThueCMND.Value = null;
            cboIDDanhMucXe.Value = null;
            cboIDDanhMucTaiXe.Value = null;
            cboIDDanhMucXe.DataSource = null;
            cboIDDanhMucTaiXe.DataSource = null;
            //
            if (coreCommon.coreCommon.IsNull(cboIDDanhMucThauPhu.Value) || !cboIDDanhMucThauPhu.IsItemInList()) return;
            DanhMucThauPhuBUS DanhMucThauPhuBUS = new DanhMucThauPhuBUS();
            DataTable dt = DanhMucThauPhuBUS.List(cboIDDanhMucThauPhu.Value, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongThauPhu)), null, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtTenDanhMucThauPhu.Value = dt.Rows[0]["Ten"];
                txtMaSoThueCMND.Value = dt.Rows[0]["MaSoThueCMND"];
            }
            ////Xe
            //DanhMucXeBUS DanhMucXeBUS = new DanhMucXeBUS();
            //dtXe = DanhMucXeBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongXe)), cboIDDanhMucThauPhu.Value, dataRow["IDDanhMucNhomHangVanChuyen"], null);
            //cboIDDanhMucXe.dtValid = dtXe;
            //cboIDDanhMucXe.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongXe));
            //cboIDDanhMucXe.procedureName = DanhMucXe.listProcedureName;
            //cboIDDanhMucXe.DataSource = dtXe;
            //cboIDDanhMucXe.ValueMember = "ID";
            //cboIDDanhMucXe.DisplayMember = "BienSo";
            ////Tài xế
            //DanhMucTaiXeBUS DanhMucTaiXeBUS = new DanhMucTaiXeBUS();
            //dtTaiXe = DanhMucTaiXeBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTaiXe)), cboIDDanhMucThauPhu.Value, null);
            //cboIDDanhMucTaiXe.dtValid = dtTaiXe;
            //cboIDDanhMucTaiXe.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongTaiXe));
            //cboIDDanhMucTaiXe.procedureName = DanhMucTaiXe.listProcedureName;
            //cboIDDanhMucTaiXe.DataSource = dtTaiXe;
            //cboIDDanhMucTaiXe.ValueMember = "ID";
            //cboIDDanhMucTaiXe.DisplayMember = "Ten";
        }
        private void OpenChiTietDonHangKetHop()
        {
            //Update số đơn hàng kết hợp của đơn hàng này
            frm_ctDieuHanhChiTietDonHangKetHopUpdate frmUpdate = new frm_ctDieuHanhChiTietDonHangKetHopUpdate()
            {
                IDDanhMucChungTu = IDDanhMucChungTu,
                IDChungTu = dataRow["ID"],
                IDChungTuChiTiet = dataRow["IDctDieuHanh"],
                dt = dtDonHangKetHop.Copy(),
            };
            frmUpdate.ShowDialog();
            if (frmUpdate.Saved)
            {
                txtSoDonHangKetHop.Value = null;
                dtDonHangKetHop = frmUpdate.dt;
                foreach (DataRow drDonHangKetHop in dtDonHangKetHop.Rows)
                {
                    if (drDonHangKetHop.RowState != DataRowState.Deleted)
                        txtSoDonHangKetHop.Value += drDonHangKetHop["SoDonHang"] + ";";
                }
            }
            frmUpdate.Dispose();
        }

    }
}
