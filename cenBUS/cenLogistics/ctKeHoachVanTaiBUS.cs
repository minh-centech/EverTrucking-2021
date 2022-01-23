using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctKeHoachVanTaiBUS
    {
        public static DataTable List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
                return dao.List(IDDanhMucChungTu, ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object ID)
        {
            try
            {
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
                return dao.ListDisplay(IDDanhMucChungTu, TuNgay, DenNgay, ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(ctKeHoachVanTai obj)
        {
            try
            {
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ctKeHoachVanTai obj)
        {
            try
            {
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
                return dao.Update(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(object ID)
        {
            try
            {
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
