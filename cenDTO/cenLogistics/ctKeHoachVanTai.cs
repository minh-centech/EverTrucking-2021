using coreDTO;
namespace cenDTO.cenLogistics
{
    public class ctKeHoachVanTai : ctDTO
    {
        public object IDDanhMucSale { get; set; }
        public object IDDanhMucKhachHang { get; set; }
        public object LoaiHinh { get; set; }
        public object LoaiHang { get; set; }
        public object IDDanhMucHangTau { get; set; }
        public object IDDanhMucDiaDiemNangCont { get; set; }
        public object NgayNangCont { get; set; }
        public object IDDanhMucDiaDiemHaCont { get; set; }
        public object NgayHaCont { get; set; }
        public object SoLuongCont20 { get; set; }
        public object SoCont20 { get; set; }
        public object SoLuongCont40 { get; set; }
        public object SoCont40 { get; set; }
        public object SoLuongCont45 { get; set; }
        public object SoCont45 { get; set; }
        public object IDDanhMucDiaDiemDongHang { get; set; }
        public object NgayDongHang { get; set; }
        public object IDDanhMucDiaDiemTraHang { get; set; }
        public object NgayTraHang { get; set; }
        public object KhoiLuong { get; set; }
        public object NguoiGiaoNhan { get; set; }
        public object SoDienThoaiGiaoNhan { get; set; }

        public const string tableName = "ctKeHoachVanTai";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public const string listDisplayProcedureName = "List_" + tableName + "_Display";
        //
        public ctKeHoachVanTai()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
             IDDanhMucSale  = null;
             IDDanhMucKhachHang  = null;
             LoaiHinh  = null;
             LoaiHang  = null;
             IDDanhMucHangTau  = null;
             IDDanhMucDiaDiemNangCont  = null;
             NgayNangCont  = null;
             IDDanhMucDiaDiemHaCont  = null;
             NgayHaCont  = null;
             SoLuongCont20  = null;
             SoCont20  = null;
             SoLuongCont40  = null;
             SoCont40  = null;
             SoLuongCont45  = null;
             SoCont45  = null;
             IDDanhMucDiaDiemDongHang  = null;
             NgayDongHang  = null;
             IDDanhMucDiaDiemTraHang  = null;
             NgayTraHang  = null;
             KhoiLuong  = null;
             NguoiGiaoNhan  = null;
             SoDienThoaiGiaoNhan  = null;
            //
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            MaDanhMucNguoiSuDungCreate = null;
            TenDanhMucNguoiSuDungCreate = null;
            CreateDate = null;
            IDDanhMucNguoiSuDungEdit = null;
            MaDanhMucNguoiSuDungEdit = null;
            TenDanhMucNguoiSuDungEdit = null;
            EditDate = null;
        }

    }
}
