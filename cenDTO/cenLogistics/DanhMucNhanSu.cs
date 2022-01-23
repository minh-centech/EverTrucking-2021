using coreDTO;
namespace cenDTO.cenLogistics
{
    public class DanhMucNhanSu : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object IDDanhMucPhongBan { get; set; }
        public object MaDanhMucPhongBan { get; set; }
        public object TenDanhMucPhongBan { get; set; }
        public object IDDanhMucPhanLoaiChucVu { get; set; }
        public object MaDanhMucPhanLoaiChucVu { get; set; }
        public object TenDanhMucPhanLoaiChucVu { get; set; }
        public object NguyenQuan { get; set; }
        public object DiaChiThuongTru { get; set; }
        public object NgaySinh { get; set; }
        public object SoCMND { get; set; }
        public object NgayCap { get; set; }
        public object NoiCap { get; set; }
        public object SoDienThoai { get; set; }
        public object MaSoThue { get; set; }
        public object SoTaiKhoan { get; set; }
        public object Email { get; set; }
        public object TrinhDo { get; set; }
        public object NgayVaoLam { get; set; }
        public object IDDanhMucTinhTrangLamViec { get; set; }
        public object MaDanhMucTinhTrangLamViec { get; set; }
        public object TenDanhMucTinhTrangLamViec { get; set; }
        public object HinhAnh { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucNhanSu";
        public const string listProcedureName = "List_" + tableName;
        public const string listHinhAnhProcedureName = "List_" + tableName + "_HinhAnh";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucNhanSu()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            Ma = null;
            Ten = null;
            IDDanhMucPhongBan = null;
            MaDanhMucPhongBan = null;
            TenDanhMucPhongBan = null;
            IDDanhMucPhanLoaiChucVu = null;
            MaDanhMucPhanLoaiChucVu = null;
            TenDanhMucPhanLoaiChucVu = null;
            NguyenQuan = null;
            DiaChiThuongTru = null;
            NgaySinh = null;
            SoCMND = null;
            NgayCap = null;
            NoiCap = null;
            SoDienThoai = null;
            MaSoThue = null;
            SoTaiKhoan = null;
            Email = null;
            TrinhDo = null;
            NgayVaoLam = null;
            IDDanhMucTinhTrangLamViec = null;
            MaDanhMucTinhTrangLamViec = null;
            TenDanhMucTinhTrangLamViec = null;
            HinhAnh = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
