using coreBUS;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctInGiayVanTaiUpdate : coreBase.BaseForms.frmBaseChungTuSingleUpdate
    {
        public object IDctDonHang = null;
        ctInGiayVanTai obj = null;
        public frm_ctInGiayVanTaiUpdate()
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
                    UpdateMode = coreCommon.ThaoTacDuLieu.Them;
                    //Xóa text box
                    txtSo.Value = null;
                    txtNgayLap.Value = DateTime.Now;
                    if (cboIDDanhMucTrangThaiChungTu.Items.Count > 0) cboIDDanhMucTrangThaiChungTu.SelectedItem = cboIDDanhMucTrangThaiChungTu.Items[0];
                    //
                    txtSoDonHang.Value = null;
                    txtNgayDongTraHang.Value = null;
                    txtNgayNhanHang.Value = null;
                    txtGioNhanHang.Value = null;
                    txtDebitNote.Value = null;
                    txtBillBooking.Value = null;
                    txtTenDanhMucTuyenVanTai.Value = null;
                    txtTenDanhMucHangHoa.Value = null;
                    txtBienSo.Value = null;
                    txtTenDanhMucChuXe.Value = null;
                    txtThongTinThuTuc.Value = null;
                    cboLoaiDonChuyen.Value = null;
                    txtCuLy.Value = null;
                    txtSoKmHangNhe.Value = null;
                    txtSoKmVoHangNhe.Value = null;
                    txtSoKmHangNang.Value = null;
                    txtSoKmVoHangNang.Value = null;
                    txtSoLuongNhienLieuDinhMuc.Value = null;
                    txtSoLuongNhienLieuCapThem.Value = null;
                    txtSoLuongNhienLieu.Value = null;
                    txtSoTienVeCauDuong.Value = null;
                    txtSoTienLuatAnCa.Value = null;
                    txtSoTienTamUng.Value = null;
                    txtGhiChu.Value = null;

                }
            }
        }
        private bool Save()
        {
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Them || UpdateMode == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.ctInGiayVanTai
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    //
                    IDChungTu = IDctDonHang,
                    LoaiDonChuyen = cboLoaiDonChuyen.Value,
                    SoKmVoHangNhe = txtSoKmVoHangNhe.Value,
                    SoKmHangNhe = txtSoKmHangNhe.Value,
                    SoKmVoHangNang = txtSoKmVoHangNang.Value,
                    SoKmHangNang = txtSoKmHangNang.Value,
                    SoLuongNhienLieuDinhMuc = txtSoLuongNhienLieuDinhMuc.Value,
                    SoLuongNhienLieuCapThem = txtSoLuongNhienLieuCapThem.Value,
                    LyDoCapThem = txtLyDoCapThem.Value,
                    SoTienVeCauDuong = txtSoTienVeCauDuong.Value,
                    SoTienLuatAnCa = txtSoTienLuatAnCa.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.ctInGiayVanTai
                {
                    ID = dataRow["IDctInGiayVanTai"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    //
                    IDChungTu = IDctDonHang,
                    LoaiDonChuyen = cboLoaiDonChuyen.Value,
                    SoKmVoHangNhe = txtSoKmVoHangNhe.Value,
                    SoKmHangNhe = txtSoKmHangNhe.Value,
                    SoKmVoHangNang = txtSoKmVoHangNang.Value,
                    SoKmHangNang = txtSoKmHangNang.Value,
                    SoLuongNhienLieuDinhMuc = txtSoLuongNhienLieuDinhMuc.Value,
                    SoLuongNhienLieuCapThem = txtSoLuongNhienLieuCapThem.Value,
                    LyDoCapThem = txtLyDoCapThem.Value,
                    SoTienVeCauDuong = txtSoTienVeCauDuong.Value,
                    SoTienLuatAnCa = txtSoTienLuatAnCa.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.ctInGiayVanTaiBUS _BUS = new cenBUS.cenLogistics.ctInGiayVanTaiBUS();
            bool OK = (UpdateMode == 1 || UpdateMode == 3) ? _BUS.Insert(ref obj) : _BUS.Update(ref obj);
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
                dataRow["IDctInGiayVanTai"] = (!coreCommon.coreCommon.IsNull(obj.ID)) ? obj.ID : DBNull.Value;
                return true;
            }
            else
            {
                dataRow["IDctInGiayVanTai"] = (!coreCommon.coreCommon.IsNull(obj.ID)) ? obj.ID : DBNull.Value;
                return false;
            }
        }
        private void frmDanhMucChungTuUpdate_Load(object sender, EventArgs e)
        {
            ////DanhMucTrangThaiChungTu
            //DanhMucChungTuTrangThaiBUS danhMucChungTuTrangThaiBUS = new DanhMucChungTuTrangThaiBUS();
            //DataTable dtTrangThai = danhMucChungTuTrangThaiBUS.List(null, IDDanhMucChungTu);
            //cboIDDanhMucTrangThaiChungTu.DataSource = dtTrangThai;
            //cboIDDanhMucTrangThaiChungTu.ValueMember = "ID";
            //cboIDDanhMucTrangThaiChungTu.DisplayMember = "Ten";
            //if (cboIDDanhMucTrangThaiChungTu.Items.Count > 0) cboIDDanhMucTrangThaiChungTu.SelectedItem = cboIDDanhMucTrangThaiChungTu.Items[0];
            //Loại hàng
            cboLoaiDonChuyen.Items.Add(1, "Đơn chuyển, hàng nhẹ");
            cboLoaiDonChuyen.Items.Add(2, "Đơn chuyển, hàng nặng");

            //
            txtSo.Value = dataRow["So"];
            txtNgayLap.Value = dataRow["NgayLap"];
            cboIDDanhMucTrangThaiChungTu.Value = dataRow["IDDanhMucChungTuTrangThai"];
            txtSoDonHang.Value = dataRow["So"];
            txtNgayDongTraHang.Value = dataRow["NgayDongTraHang"];
            txtNgayNhanHang.Value = dataRow["NgayDongTraHang"];
            txtGioNhanHang.Value = dataRow["NgayDongTraHang"];
            txtGioNhanHang.MaskInput = coreCommon.GlobalVariables.MaskInputTime;
            txtDebitNote.Value = dataRow["DebitNote"];
            txtBillBooking.Value = dataRow["BillBooking"];
            txtTenDanhMucTuyenVanTai.Value = dataRow["TenDanhMucTuyenVanTai"];
            txtTenDanhMucHangHoa.Value = dataRow["TenDanhMucHangHoa"];
            txtBienSo.Value = dataRow["BienSo"];
            txtTenDanhMucChuXe.Value = dataRow["TenDanhMucChuXe"];
            //txtThongTinThuTuc.Value = dataRow["ThongTinThuTuc"];
            cboLoaiDonChuyen.Value = dataRow["LoaiDonChuyen"];
            txtCuLy.Value = dataRow["CuLy"];
            txtSoKmHangNhe.Value = dataRow["SoKmHangNhe"];
            txtSoKmVoHangNhe.Value = dataRow["SoKmVoHangNhe"];
            txtSoKmHangNang.Value = dataRow["SoKmHangNang"];
            txtSoKmVoHangNang.Value = dataRow["SoKmVoHangNang"];
            txtSoLuongNhienLieuDinhMuc.Value = dataRow["SoLuongNhienLieuDinhMuc"];
            txtSoLuongNhienLieuCapThem.Value = dataRow["SoLuongNhienLieuCapThem"];
            txtSoLuongNhienLieu.Value = dataRow["SoLuongNhienLieu"];
            txtSoTienVeCauDuong.Value = dataRow["SoTienVeCauDuong"];
            txtSoTienLuatAnCa.Value = dataRow["SoTienLuatAnCa"];
            txtSoTienTamUng.Value = dataRow["SoTienTamUng"];
            txtGhiChu.Value = dataRow["GhiChu"];

            if (UpdateMode == coreCommon.ThaoTacDuLieu.Xem)
            {
                cmdSave.Enabled = false;
                cmdSaveNew.Enabled = false;
            }
        }

        private void txtSoLuongNhienLieu_ValueChanged(object sender, EventArgs e)
        {
            txtSoLuongNhienLieu.Value = (!coreCommon.coreCommon.IsNull(txtSoLuongNhienLieuDinhMuc.Value) ? float.Parse(txtSoLuongNhienLieuDinhMuc.Value.ToString()) : 0) + (!coreCommon.coreCommon.IsNull(txtSoLuongNhienLieuCapThem.Value) ? float.Parse(txtSoLuongNhienLieuCapThem.Value.ToString()) : 0);
        }

        private void txtSoTienVeCauDuong_ValueChanged(object sender, EventArgs e)
        {
            txtSoTienTamUng.Value = (!coreCommon.coreCommon.IsNull(txtSoTienVeCauDuong.Value) ? float.Parse(txtSoTienVeCauDuong.Value.ToString()) : 0) + (!coreCommon.coreCommon.IsNull(txtSoTienLuatAnCa.Value) ? float.Parse(txtSoTienLuatAnCa.Value.ToString()) : 0);
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            ////In giấy vận tải
            //Save();
            //if (!coreCommon.coreCommon.IsNull(dataRow["IDctInGiayVanTai"]))
            //    cenBase.Classes.ChungTu.inChungTu(IDDanhMucChungTu.ToString(), dataRow["ID"].ToString(), ctDonHang.tableName, "", this.MdiParent, false, coreCommon.GlobalVariables.reportPath + @"ctInGiayVanTai.rpt", ctInGiayVanTai.listProcedureName, "", 1, LoaiManHinh, 1);



            //IWorkbook wbMau;
            //IRow ro;
            //ISheet sh;
            //string FullExcelTemplateFileName = coreCommon.GlobalVariables.ExcelTemplateDir + @"GIAY_VAN_TAI.xlsx";

            ////1. Mở file mẫu
            //if (string.IsNullOrEmpty(FullExcelTemplateFileName) || string.IsNullOrWhiteSpace(FullExcelTemplateFileName))
            //{
            //    FullExcelTemplateFileName = coreCommon.coreCommon.OpenFileDialog("Chọn file mẫu", "", "Excel file (*.xlsx)|*.xlsx");
            //}

            //if (!File.Exists(FullExcelTemplateFileName)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không tìm thấy file mẫu " + FullExcelTemplateFileName + "!"); return; }

            ////2.Tạo file kết quả
            //string fName = coreCommon.GlobalVariables.OutputDir + @"\GIAY_VAN_TAI_" + dataRow["So"].ToString() + @".xlsx"  ;
            //String FileName = coreCommon.coreCommon.OpenSaveFileDialog("Chọn file lưu kết quả export", fName, "Excel file (*.xlsx)|*.xlsx");
            //if (FileName == "") return;
            //if (File.Exists(FileName)) File.Delete(FileName);
            //using (FileStream fsMau = new FileStream(FullExcelTemplateFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            //{
            //    wbMau = new XSSFWorkbook(fsMau);
            //    if (wbMau == null) throw new Exception($"Không mở được file Excel: {FullExcelTemplateFileName}");
            //    fsMau.Close();
            //}

            //sh = wbMau.GetSheet("Sheet1");
            ////3. Điền dữ liệu
            //sh.GetRow(2).GetCell(12).SetCellValue("Số: " + (coreCommon.coreCommon.IsNull(dataRow["So"].ToString()) ? "" : dataRow["So"].ToString()));
            //sh.GetRow(4).GetCell(1).SetCellValue("Biển kiểm soát xe: " + (coreCommon.coreCommon.IsNull(dataRow["BienSo"].ToString()) ? "" : dataRow["BienSo"].ToString()));
            //sh.GetRow(7).GetCell(8).SetCellValue("Họ và tên lái xe: " + (coreCommon.coreCommon.IsNull(dataRow["TenDanhMucTaiXe"].ToString()) ? "" : dataRow["TenDanhMucTaiXe"].ToString()));
            //sh.GetRow(9).GetCell(8).SetCellValue("Số điện thoại liên hệ: " + (coreCommon.coreCommon.IsNull(dataRow["DienThoai"].ToString()) ? "" : dataRow["DienThoai"].ToString())); //
            //sh.GetRow(11).GetCell(0).SetCellValue("Tên người thuê vận chuyển: " + (coreCommon.coreCommon.IsNull(dataRow["TenDanhMucKhachHang"].ToString()) ? "" : dataRow["TenDanhMucKhachHang"].ToString())); //
            //sh.GetRow(12).GetCell(0).SetCellValue("Địa chỉ: " + (coreCommon.coreCommon.IsNull(dataRow["DiaChiDanhMucKhachHang"].ToString()) ? "" : dataRow["DiaChiDanhMucKhachHang"].ToString())); //
            //sh.GetRow(11).GetCell(8).SetCellValue("Số hợp đồng/debit: " + (coreCommon.coreCommon.IsNull(dataRow["DebitNote"].ToString()) ? "" : dataRow["DebitNote"].ToString())); //
            //sh.GetRow(12).GetCell(8).SetCellValue("Ngày " + (coreCommon.coreCommon.IsNull(dataRow["NgayDongTraHang"].ToString()) ? "........" : ((DateTime)dataRow["NgayDongTraHang"]).Day.ToString("0#")) + " tháng " + (coreCommon.coreCommon.IsNull(dataRow["NgayDongTraHang"].ToString()) ? "........" : ((DateTime)dataRow["NgayDongTraHang"]).Month.ToString("0#")) + " năm " + (coreCommon.coreCommon.IsNull(dataRow["NgayDongTraHang"].ToString()) ? "........" : ((DateTime)dataRow["NgayDongTraHang"]).Year.ToString("000#"))); //
            //sh.GetRow(14).GetCell(0).SetCellValue("Tuyến vận chuyển: " + (coreCommon.coreCommon.IsNull(dataRow["TenDanhMucTuyenVanTai"].ToString()) ? "" : dataRow["TenDanhMucTuyenVanTai"].ToString())); //
            //sh.GetRow(15).GetCell(0).SetCellValue("Địa điểm xếp hàng: " + (coreCommon.coreCommon.IsNull(dataRow["NoiDongHang"].ToString()) ? "" : dataRow["NoiDongHang"].ToString())); //
            //sh.GetRow(16).GetCell(0).SetCellValue("Địa điểm giao hàng: " + (coreCommon.coreCommon.IsNull(dataRow["NoiTraHang"].ToString()) ? "" : dataRow["NoiTraHang"].ToString())); //
            //sh.GetRow(14).GetCell(8).SetCellValue("Tên hàng hóa/Số cont: " + (coreCommon.coreCommon.IsNull(dataRow["TenDanhMucHangHoa"].ToString()) ? "" : dataRow["TenDanhMucHangHoa"].ToString()) + (coreCommon.coreCommon.IsNull(dataRow["SoContainer"].ToString()) ? "" : "/" + dataRow["SoContainer"].ToString())); //
            //sh.GetRow(15).GetCell(8).SetCellValue("Khối lượng hàng hóa: " + (coreCommon.coreCommon.IsNull(dataRow["TrongLuong"].ToString()) ? "" : dataRow["TrongLuong"].ToString())); //
            //sh.GetRow(15).GetCell(8).SetCellValue("Khối lượng hàng hóa: " + (coreCommon.coreCommon.IsNull(dataRow["TrongLuong"].ToString()) ? "" : dataRow["TrongLuong"].ToString())); //
            //sh.GetRow(17).GetCell(8).SetCellValue("Định mức dầu: " + (coreCommon.coreCommon.IsNull(dataRow["SoLuongNhienLieu"].ToString()) ? "0" : dataRow["SoLuongNhienLieu"].ToString()) + " (lít)"); //
            //sh.GetRow(18).GetCell(8).SetCellValue("Tạm ứng tiền đường: " + (coreCommon.coreCommon.IsNull(dataRow["SoTienTamUng"].ToString()) ? "0" : String.Format("{0:N0}", float.Parse(dataRow["SoTienTamUng"].ToString()))) + " (vnđ)"); //
            //sh.GetRow(19).GetCell(8).SetCellValue("Ghi chú, giải trình: " + (coreCommon.coreCommon.IsNull(dataRow["GhiChu"].ToString()) ? "0" : dataRow["GhiChu"].ToString())); //

            ////4. Save            
            //using (var fskq = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
            //{
            //    wbMau.Write(fskq);
            //}
            //wbMau.Close();
            ////
            //if (coreCommon.coreCommon.QuestionMessage("Đã kết xuất báo cáo, bạn có muốn mở file ra không?", 0) == DialogResult.Yes)
            //{
            //    System.Diagnostics.Process.Start(FileName);
            //}
        }
    }
}
