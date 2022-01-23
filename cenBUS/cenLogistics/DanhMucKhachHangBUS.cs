using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucKhachHangBUS
    {
        public DanhMucKhachHangBUS()
        {
        }

        public DataSet List(object ID, object IDDanhMucLoaiDoiTuong, object Level, object SearchStr)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, Level, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable Valid(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.Valid(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ValidF1(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.ValidF1(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ValidF2(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucKhachHangF1, object SearchStr)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.ValidF2(ID, IDDanhMucLoaiDoiTuong, IDDanhMucKhachHangF1, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ValidF3(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucKhachHangF1, object IDDanhMucKhachHangF2, object SearchStr)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.ValidF3(ID, IDDanhMucLoaiDoiTuong, IDDanhMucKhachHangF1, IDDanhMucKhachHangF2, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucKhachHang obj)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucKhachHang obj)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucKhachHang obj)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    public class DanhMucKhachHangPhanCapBUS
    {
        public DanhMucKhachHangPhanCapBUS()
        {
        }


        public bool Insert(ref DanhMucKhachHangPhanCap obj)
        {
            try
            {
                DanhMucKhachHangPhanCapDAO dao = new DanhMucKhachHangPhanCapDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucKhachHangPhanCap obj)
        {
            try
            {
                DanhMucKhachHangPhanCapDAO dao = new DanhMucKhachHangPhanCapDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucKhachHangPhanCap obj)
        {
            try
            {
                DanhMucKhachHangPhanCapDAO dao = new DanhMucKhachHangPhanCapDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
