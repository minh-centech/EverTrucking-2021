using coreDTO;
namespace cenDTO.cenLogistics
{
    public class DanhMucKhachHang : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object IDDanhMucNhanSu { get; set; }
        public object TenDanhMucNhanSu { get; set; }
        public object DiaChi { get; set; }
        public object SoDienThoai { get; set; }
        public object SoFax { get; set; }
        public object Email { get; set; }
        public object MaSoThue { get; set; }
        public object TenNganHang { get; set; }
        public object SoTaiKhoan { get; set; }
        public object NguoiDaiDien { get; set; }
        public object NguoiGiaoNhan { get; set; }
        public object SoDienThoaiGiaoNhan { get; set; }
        public object IDDanhMucTuyenVanTai { get; set; }
        public object TenDanhMucTuyenVanTai { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }
        public const string tableName = "DanhMucKhachHang";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string validProcedureName = "List_" + tableName + "_Valid";
        public const string validF1ProcedureName = "List_" + tableName + "_ValidF1";
        public const string validF2ProcedureName = "List_" + tableName + "_ValidF2";
        public const string validF3ProcedureName = "List_" + tableName + "_ValidF3";
        public DanhMucKhachHang()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            Ma = null;
            Ten = null;
            IDDanhMucNhanSu = null;
            TenDanhMucNhanSu = null;
            DiaChi = null;
            SoDienThoai = null;
            SoFax = null;
            Email = null;
            MaSoThue = null;
            TenNganHang = null;
            SoTaiKhoan = null;
            NguoiDaiDien = null;
            NguoiGiaoNhan = null;
            SoDienThoaiGiaoNhan = null;
            IDDanhMucTuyenVanTai = null;
            TenDanhMucTuyenVanTai = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }

    public class DanhMucKhachHangPhanCap : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object IDDanhMucKhachHang { get; set; }
        public object IDDanhMucKhachHangF2 { get; set; }
        public object MaDanhMucKhachHangF2 { get; set; }
        public object TenDanhMucKhachHangF2 { get; set; }
        public object IDDanhMucKhachHangF1 { get; set; }
        public object MaDanhMucKhachHangF1 { get; set; }
        public object TenDanhMucKhachHangF1 { get; set; }
        public object GhiChu { get; set; }

        public const string tableName = "DanhMucKhachHangPhanCap";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucKhachHangPhanCap()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            IDDanhMucKhachHang = null;
            IDDanhMucKhachHangF2 = null;
            MaDanhMucKhachHangF2 = null;
            TenDanhMucKhachHangF2 = null;
            IDDanhMucKhachHangF1 = null;
            MaDanhMucKhachHangF1 = null;
            TenDanhMucKhachHangF1 = null;
            GhiChu = null;
            CreateDate = null;
            EditDate = null;
        }
    }

}
