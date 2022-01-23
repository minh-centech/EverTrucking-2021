using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucDiaDiemGiaoNhanBUS
    {
        public DanhMucDiaDiemGiaoNhanBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucNhomHangVanChuyen, object SearchStr)
        {
            try
            {
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, IDDanhMucNhomHangVanChuyen, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucDiaDiemGiaoNhan obj)
        {
            try
            {
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucDiaDiemGiaoNhan obj)
        {
            try
            {
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucDiaDiemGiaoNhan obj)
        {
            try
            {
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
