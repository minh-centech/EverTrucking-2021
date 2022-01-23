using cenDAO;
using System.Data;
using System.Data.SqlClient;
using coreDAO;
namespace cenCommonUIapps
{
    public class Reports
    {
        public static DataTable rep_BC_DOANHTHU_KD(object dTuNgay, object dDenNgay, object IDDanhMucKhachHang, object IDDanhMucSale)
        {
            ConnectionDAO connectionDAO = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@TuNgay", dTuNgay);
            sqlParameters[2] = new SqlParameter("@DenNgay", dDenNgay);
            sqlParameters[3] = new SqlParameter("@IDDanhMucKhachHang", IDDanhMucKhachHang);
            sqlParameters[4] = new SqlParameter("@IDDanhMucSale", IDDanhMucSale);
            return connectionDAO.tableList(sqlParameters, cenCommon.LoaiBaoCao.BC_DOANHTHU_KD, cenCommon.LoaiBaoCao.BC_DOANHTHU_KD);
        }
        public static DataTable rep_BC_DOANHTHU_KD_CNKH(object dTuNgay, object dDenNgay, object IDDanhMucKhachHang, object IDDanhMucSale)
        {
            ConnectionDAO connectionDAO = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@TuNgay", dTuNgay);
            sqlParameters[2] = new SqlParameter("@DenNgay", dDenNgay);
            sqlParameters[3] = new SqlParameter("@IDDanhMucKhachHang", IDDanhMucKhachHang);
            sqlParameters[4] = new SqlParameter("@IDDanhMucSale", IDDanhMucSale);
            return connectionDAO.tableList(sqlParameters, cenCommon.LoaiBaoCao.BC_DOANHTHU_KD_CNKH, cenCommon.LoaiBaoCao.BC_DOANHTHU_KD_CNKH);
        }
        public static DataTable rep_BC_CHI_PHI_VAN_TAI(object dTuNgay, object dDenNgay, object IDDanhMucNhomHangVanChuyen, object IDDanhMucSale)
        {
            ConnectionDAO connectionDAO = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@TuNgay", dTuNgay);
            sqlParameters[2] = new SqlParameter("@DenNgay", dDenNgay);
            sqlParameters[3] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", IDDanhMucNhomHangVanChuyen);
            sqlParameters[4] = new SqlParameter("@IDDanhMucSale", IDDanhMucSale);
            return connectionDAO.tableList(sqlParameters, cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI, cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI);
        }
        public static DataTable rep_BC_CHI_PHI_VAN_TAI_BO_SUNG(object dTuNgay, object dDenNgay, object IDDanhMucNhomHangVanChuyen, object IDDanhMucSale)
        {
            ConnectionDAO connectionDAO = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@TuNgay", dTuNgay);
            sqlParameters[2] = new SqlParameter("@DenNgay", dDenNgay);
            sqlParameters[3] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", IDDanhMucNhomHangVanChuyen);
            sqlParameters[4] = new SqlParameter("@IDDanhMucSale", IDDanhMucSale);
            return connectionDAO.tableList(sqlParameters, cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI_BO_SUNG, cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI_BO_SUNG);
        }
        public static DataTable rep_BC_DOANHTHU_KT(object dTuNgay, object dDenNgay, object IDDanhMucKhachHang, object IDDanhMucSale)
        {
            ConnectionDAO connectionDAO = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@TuNgay", dTuNgay);
            sqlParameters[2] = new SqlParameter("@DenNgay", dDenNgay);
            sqlParameters[3] = new SqlParameter("@IDDanhMucKhachHang", IDDanhMucKhachHang);
            sqlParameters[4] = new SqlParameter("@IDDanhMucSale", IDDanhMucSale);
            return connectionDAO.tableList(sqlParameters, cenCommon.LoaiBaoCao.BC_DOANHTHU_KT, cenCommon.LoaiBaoCao.BC_DOANHTHU_KT);
        }
        public static DataSet rep_BC_LOINHUAN_KD(object dTuNgay, object dDenNgay, object IDDanhMucKhachHang, object IDDanhMucSale)
        {
            ConnectionDAO connectionDAO = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@TuNgay", dTuNgay);
            sqlParameters[2] = new SqlParameter("@DenNgay", dDenNgay);
            sqlParameters[3] = new SqlParameter("@IDDanhMucKhachHang", IDDanhMucKhachHang);
            sqlParameters[4] = new SqlParameter("@IDDanhMucSale", IDDanhMucSale);
            return connectionDAO.dsList(sqlParameters, cenCommon.LoaiBaoCao.BC_LOINHUAN_KD);
        }
        public static DataTable rep_BC_SUACHUA(object dTuNgay, object dDenNgay, object IDDanhMucXe)
        {
            ConnectionDAO connectionDAO = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@TuNgay", dTuNgay);
            sqlParameters[2] = new SqlParameter("@DenNgay", dDenNgay);
            sqlParameters[3] = new SqlParameter("@IDDanhMucXe", IDDanhMucXe);
            return connectionDAO.tableList(sqlParameters, cenCommon.LoaiBaoCao.BC_SUACHUA, cenCommon.LoaiBaoCao.BC_SUACHUA);
        }
        public static DataTable rep_BC_TU_QT(object dTuNgay, object dDenNgay, object IDDanhMucKhachHang)
        {
            ConnectionDAO connectionDAO = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@TuNgay", dTuNgay);
            sqlParameters[2] = new SqlParameter("@DenNgay", dDenNgay);
            sqlParameters[3] = new SqlParameter("@IDDanhMucKhachHang", IDDanhMucKhachHang);
            return connectionDAO.tableList(sqlParameters, cenCommon.LoaiBaoCao.BC_TU_QT, cenCommon.LoaiBaoCao.BC_TU_QT);
        }
        public static DataTable rep_BC_TU_TIENDUONG(object dTuNgay, object dDenNgay, object IDDanhMucChuXe)
        {
            ConnectionDAO connectionDAO = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@TuNgay", dTuNgay);
            sqlParameters[2] = new SqlParameter("@DenNgay", dDenNgay);
            sqlParameters[3] = new SqlParameter("@IDDanhMucChuXe", IDDanhMucChuXe);
            return connectionDAO.tableList(sqlParameters, cenCommon.LoaiBaoCao.BC_TU_TIENDUONG, cenCommon.LoaiBaoCao.BC_TU_TIENDUONG);
        }
    }
}
