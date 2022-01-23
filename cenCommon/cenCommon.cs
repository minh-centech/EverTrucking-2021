using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace cenCommon
{
    public static class LoaiManHinh
    {
        //Kinh doanh
        public const string IDKeHoachVanTai = "101";
        public const string NameKeHoachVanTai = "Kế hoạch vận tải";

        public const string IDDonHang = "102";
        public const string NameDonHang = "Đơn hàng";
        public const string IDThanhToanTamUng = "103";
        public const string NameThanhToanTamUng = "Theo dõi thanh toán tạm ứng";
        public const string IDChotDoanhThuGuiKeToan = "104";
        public const string NameChotDoanhThuGuiKeToan = "Chốt doanh thu gửi kế toán";
        //Điều vận
        public const string IDTrangThaiXe = "201";
        public const string NameTrangThaiXe = "Trạng thái xe";
        public const string IDQuanLyDau = "202";
        public const string NameQuanLyDau = "Quản lý dầu";
        public const string IDPhieuDoNhienLieu = "203";
        public const string NamePhieuDoNhienLieu = "Phiếu đổ nhiên liệu";
        public const string IDSuaChua = "204";
        public const string NameSuaChua = "Sửa chữa";
        public const string IDChiPhiVanTai = "205";
        public const string NameChiPhiVanTai = "Chi phí vận tải";
        public const string IDChotChiPhiVanTaiGuiKeToan = "206";
        public const string NameChotChiPhiVanTaiGuiKeToan = "Chốt chi phí vận tải gửi kế toán";
        public const string IDChiPhiVanTaiBoSung = "207";
        public const string NameChiPhiVanTaiBoSung = "Chi phí vận tải bổ sung";
        public const string IDChotChiPhiVanTaiBoSungGuiKeToan = "208";
        public const string NameChotChiPhiVanTaiBoSungGuiKeToan = "Chốt chi phí vận tải bổ sung gửi kế toán";
        public const string IDTamUng = "209";
        public const string NameTamUng = "Tạm ứng";
        public const string IDDieuHanh = "210";
        public const string NameDieuHanh = "Điều hành";
        public const string IDHotline = "211";
        public const string NameHotline = "Hotline";
        public const string IDInGiayVanTai = "212";
        public const string NameInGiayVanTai = "In giấy vận tải";
        //Kế toán
        public const string IDDuyetTamUngHoanUngKinhDoanh = "301";
        public const string NameDuyetTamUngHoanUngKinhDoanh = "Duyệt tạm ứng, hoàn ứng kinh doanh";
        public const string IDDuyetDeNghiThanhToanKinhDoanh = "302";
        public const string NameDuyetDeNghiThanhToanKinhDoanh = "Duyệt đề nghị thanh toán kinh doanh";
        public const string IDDuyetDoanhThuKinhDoanh = "303";
        public const string NameDuyetDoanhThuKinhDoanh = "Duyệt doanh thu kinh doanh";
        public const string IDDuyetTamUngChuyenDieuVan = "304";
        public const string NameDuyetTamUngChuyenDieuVan = "Duyệt tạm ứng chuyển điều vận";
        public const string IDDuyetDeNghiThanhToanChuyenDieuVan = "305";
        public const string NameDuyetDeNghiThanhToanChuyenDieuVan = "Duyệt đề nghị thanh toán chuyển điều vận";
        public const string IDDuyetChiPhiDieuVan = "306";
        public const string NameDuyetChiPhiDieuVan = "Duyệt chi phí điều vận";
        public const string IDDuyetChiPhiDieuVanBoSung = "307";
        public const string NameDuyetChiPhiDieuVanBoSung = "Duyệt chi phí điều vận bổ sung";
        public const string IDDuyetTamUngDieuVan = "308";
        public const string NameDuyetTamUngDieuVan = "Duyệt tạm ứng điều vận";
    }
    public static class LoaiBaoCao
    {
        //Tham số danh mục báo cáo
        public const String BC_DOANHTHU_KD = "rep_BC_DOANHTHU_KD";
        public const String BC_DOANHTHU_KD_CNKH = "rep_BC_DOANHTHU_KD_CNKH";
        public const String BC_CHI_PHI_VAN_TAI = "rep_BC_CHI_PHI_VAN_TAI";
        public const String BC_CHI_PHI_VAN_TAI_BO_SUNG = "rep_BC_CHI_PHI_VAN_TAI_BO_SUNG";
        public const String BC_DOANHTHU_KT = "rep_BC_DOANHTHU_KT";
        public const String BC_LOINHUAN_KD = "rep_BC_LOINHUAN_KD";
        public const String BC_SUACHUA = "rep_BC_SUACHUA";
        public const String BC_TU_QT = "rep_BC_TU_QT";
        public const String BC_TU_TIENDUONG = "rep_BC_TU_TIENDUONG";
    }
    public static class ThamSoHeThong
    {
        //Tham số danh mục loại đối tượng
        public const String MaThamSoLoaiDoiTuongTinhThanh = "MaLoaiDoiTuong_TinhThanh";
        public const String MaThamSoLoaiDoiTuongNhienLieu = "MaLoaiDoiTuong_NhienLieu";
        public const String MaThamSoLoaiDoiTuongNhomXe = "MaLoaiDoiTuong_NhomXe";
        public const String MaThamSoLoaiDoiTuongChiPhiDieuVanThuongXuyen = "MaLoaiDoiTuong_ChiPhiDieuVanThuongXuyen";
        public const String MaThamSoLoaiDoiTuongNhomHangVanChuyen = "MaLoaiDoiTuong_NhomHangVanChuyen";
        public const String MaThamSoLoaiDoiTuongSuaChuaThayTheDoDau = "MaLoaiDoiTuong_SuaChuaThayTheDoDau";
        public const String MaThamSoLoaiDoiTuongTrangThaiXe = "MaLoaiDoiTuong_TrangThaiXe";
        public const String MaThamSoLoaiDoiTuongChiPhiHaiQuanKinhDoanh = "MaLoaiDoiTuong_ChiPhiHaiQuanKinhDoanh";
        public const String MaThamSoLoaiDoiTuongHangTau = "MaLoaiDoiTuong_HangTau";
        public const String MaThamSoLoaiDoiTuongNhaCungCapTrich1PhanTram = "MaLoaiDoiTuong_NhaCungCapTrich1%";
        public const String MaThamSoLoaiDoiTuongTinhTrangLamViec = "MaLoaiDoiTuong_TinhTrangLamViec";
        public const String MaThamSoLoaiDoiTuongPhanLoaiDoiTuong = "MaLoaiDoiTuong_PhanLoaiDoiTuong";
        public const String MaThamSoLoaiDoiTuongPhongBan = "MaLoaiDoiTuong_PhongBan";
        public const String MaThamSoLoaiDoiTuongPhanLoaiChucVu = "MaLoaiDoiTuong_PhanLoaiChucVu";
        public const String MaThamSoLoaiDoiTuongXe = "MaLoaiDoiTuong_Xe";
        public const String MaThamSoLoaiDoiTuongMooc = "MaLoaiDoiTuong_Mooc";
        public const String MaThamSoLoaiDoiTuongTaiXe = "MaLoaiDoiTuong_TaiXe";
        public const String MaThamSoLoaiDoiTuongKhachHang = "MaLoaiDoiTuong_KhachHang";
        public const String MaThamSoLoaiDoiTuongKhachHangPhanCap = "MaLoaiDoiTuong_KhachHangPhanCap";
        public const String MaThamSoLoaiDoiTuongTuyenVanTai = "MaLoaiDoiTuong_TuyenVanTai";
        public const String MaThamSoLoaiDoiTuongGiaNhienLieu = "MaLoaiDoiTuong_GiaNhienLieu";
        public const String MaThamSoLoaiDoiTuongHangHoa = "MaLoaiDoiTuong_HangHoa";
        public const String MaThamSoLoaiDoiTuongDinhMucChiPhiHaiQuan = "MaLoaiDoiTuong_DinhMucChiPhiHaiQuan";
        public const String MaThamSoLoaiDoiTuongDinhMucChiPhi = "MaLoaiDoiTuong_DinhMucChiPhi";
        public const String MaThamSoLoaiDoiTuongXeDinhMucNhienLieu = "MaLoaiDoiTuong_XeDinhMucNhienLieu";
        public const String MaThamSoLoaiDoiTuongNhanSu = "MaLoaiDoiTuong_NhanSu";
        public const String MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucNhienLieu = "MaLoaiDoiTuong_TuyenVanTaiDinhMucNhienLieu";
        public const String MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucChiPhi = "MaLoaiDoiTuong_TuyenVanTaiDinhMucChiPhi";
        public const String MaThamSoLoaiDoiTuongCangICD = "MaLoaiDoiTuong_CangICD";
        public const String MaThamSoLoaiDoiTuongKho = "MaLoaiDoiTuong_Kho";
        public const String MaThamSoLoaiDoiTuongThauPhu = "MaLoaiDoiTuong_ThauPhu";
        public const String MaThamSoLoaiDoiTuongDonViCungCapNhienLieu = "MaLoaiDoiTuong_DonViCungCapNhienLieu";
        //Tham số danh mục chứng từ
        public const string MaThamSoChungTuKeHoachVanTai = "MaChungTu_KeHoachVanTai";
        public const string MaThamSoChungTuDonHang = "MaChungTu_DonHang";
        public const string MaThamSoChungTuThanhToanTamUng = "MaChungTu_ThanhToanTamUng";
        public const string MaThamSoChungTuChotDoanhThuGuiKeToan = "MaChungTu_ChotDoanhThuGuiKeToan";
        //
        public const string MaThamSoChungTuTrangThaiXe = "MaChungTu_TrangThaiXe";
        public const string MaThamSoChungTuQuanLyDau = "MaChungTu_QuanLyDau";
        public const string MaThamSoChungTuPhieuDoNhienLieu = "MaChungTu_PhieuDoNhienLieu";
        public const string MaThamSoChungTuSuaChua = "MaChungTu_SuaChua";
        public const string MaThamSoChungTuChiPhiVanTai = "MaChungTu_ChiPhiVanTai";
        public const string MaThamSoChungTuChotChiPhiVanTai = "MaChungTu_ChotChiPhiVanTai";
        public const string MaThamSoChungTuChiPhiVanTaiBoSung = "MaChungTu_ChiPhiVanTaiBoSung";
        public const string MaThamSoChungTuChotChiPhiVanTaiBoSung = "MaChungTu_ChotChiPhiVanTaiBoSung";
        public const string MaThamSoChungTuTamUng = "MaChungTu_TamUng";
        public const string MaThamSoChungTuDieuHanh = "MaChungTu_DieuHanh";
        public const string MaThamSoChungTuHotline = "MaChungTu_Hotline";
        public const string MaThamSoChungTuInGiayVanTai = "MaChungTu_InGiayVanTai";
        //
        public const string MaThamSoChungTuDuyetTamUngHoanUngKinhDoanh = "MaChungTu_DuyetTamUngHoanUngKinhDoanh";
        public const string MaThamSoChungTuDuyetDeNghiThanhToanKinhDoanh = "MaChungTu_DuyetDeNghiThanhToanKinhDoanh";
        public const string MaThamSoChungTuDuyetDoanhThuKinhDoanh = "MaChungTu_DuyetDoanhThuKinhDoanh";
        public const string MaThamSoChungTuDuyetTamUngChuyenDieuVan = "MaChungTu_DuyetTamUngChuyenDieuVan";
        public const string MaThamSoChungTuDuyetDeNghiThanhToanChuyenDieuVan = "MaChungTu_DuyetDeNghiThanhToanChuyenDieuVan";
        public const string MaThamSoChungTuDuyetChiPhMaThamSoChungTuieuVan = "MaChungTu_DuyetChiPhiDieuVan";
        public const string MaThamSoChungTuDuyetChiPhMaThamSoChungTuieuVanBoSung = "MaChungTu_DuyetChiPhiDieuVanBoSung";
        public const string MaThamSoChungTuDuyetTamUngDieuVan = "MaChungTu_DuyetTamUngDieuVan";

    }
    public static class ThamSoNguoiSuDung
    {
        public const string ctDonHang_TuNgay = "ctDonHang_TuNgay";
        public const string ctDonHang_DenNgay = "ctDonHang_DenNgay";

        public const string ctHopDongVanChuyen_TuNgay = "ctHopDongVanChuyen_TuNgay";
        public const string ctHopDongVanChuyen_DenNgay = "ctHopDongVanChuyen_DenNgay";

        public const string ctSuaChua_TuNgay = "ctSuaChua_TuNgay";
        public const string ctSuaChua_DenNgay = "ctSuaChua_DenNgay";
    }
    public static class GlobalVariables
    {
        public const byte LoaiHinhHangNhap = 1;
        public const string TenLoaiHinhHangNhap = "Nhập";
        public const byte LoaiHinhHangXuat = 2;
        public const string TenLoaiHinhHangXuat = "Xuất";
        public const byte LoaiHinhHangNoiDia = 3;
        public const string TenLoaiHinhHangNoiDia = "Nội địa";

        public const byte LoaiHangFCL = 1;
        public const string TenLoaiHangFCL = "FCL";
        public const byte LoaiHangLCL = 1;
        public const string TenLoaiHangLCL = "LCL";
    }

}
