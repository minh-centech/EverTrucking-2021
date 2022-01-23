using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucNhanSuBUS
    {
        public DanhMucNhanSuBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucNhanSuDAO dao = new DanhMucNhanSuDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListHinhAnh(object ID)
        {
            try
            {
                DanhMucNhanSuDAO dao = new DanhMucNhanSuDAO();
                return dao.ListHinhAnh(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucNhanSu obj)
        {
            try
            {
                DanhMucNhanSuDAO dao = new DanhMucNhanSuDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucNhanSu obj)
        {
            try
            {
                DanhMucNhanSuDAO dao = new DanhMucNhanSuDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucNhanSu obj)
        {
            try
            {
                DanhMucNhanSuDAO dao = new DanhMucNhanSuDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
