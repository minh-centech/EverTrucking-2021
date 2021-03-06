using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
using coreDAO;
namespace cenDAO.cenLogistics
{
    public class ctKeHoachVanTaiDAO
    {
        public DataTable List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ConnectionDAO dao = new ConnectionDAO();
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
                sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
                sqlParameters[2] = new SqlParameter("@ID", ID);
                DataTable dt = dao.tableList(sqlParameters, ctKeHoachVanTai.listProcedureName, ctKeHoachVanTai.listProcedureName);
                return dt;
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return null;
            }
        }
        public DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object ID)
        {
            try
            {
                ConnectionDAO dao = new ConnectionDAO();
                SqlParameter[] sqlParameters = new SqlParameter[5];
                sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
                sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
                sqlParameters[2] = new SqlParameter("@TuNgay", TuNgay);
                sqlParameters[3] = new SqlParameter("@DenNgay", DenNgay);
                sqlParameters[4] = new SqlParameter("@ID", ID);
                DataTable dt = dao.tableList(sqlParameters, ctKeHoachVanTai.listDisplayProcedureName, ctKeHoachVanTai.tableName);
                return dt;
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return null;
            }
        }
        public bool Insert(ctKeHoachVanTai obj)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand(ctKeHoachVanTai.insertProcedureName, connection, transaction);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[31];
                sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                {
                    Direction = ParameterDirection.Output,
                    Size = sizeof(Int64)
                };
                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                sqlParameters[3] = new SqlParameter("@IDDanhMucChungTuTrangThai", obj.IDDanhMucChungTuTrangThai);
                sqlParameters[4] = new SqlParameter("@So", obj.So)
                {
                    Direction = ParameterDirection.Output,
                    Size = 35
                };
                sqlParameters[5] = new SqlParameter("@NgayLap", obj.NgayLap);
                //
                sqlParameters[6] = new SqlParameter("@IDDanhMucSale", obj.IDDanhMucSale);
                sqlParameters[7] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                sqlParameters[8] = new SqlParameter("@LoaiHinh", obj.LoaiHinh);
                sqlParameters[9] = new SqlParameter("@LoaiHang", obj.LoaiHang);
                sqlParameters[10] = new SqlParameter("@IDDanhMucHangTau", obj.IDDanhMucHangTau);
                sqlParameters[11] = new SqlParameter("@IDDanhMucDiaDiemNangCont", obj.IDDanhMucDiaDiemNangCont);
                sqlParameters[12] = new SqlParameter("@NgayNangCont", obj.NgayNangCont);
                sqlParameters[13] = new SqlParameter("@IDDanhMucDiaDiemHaCont", obj.IDDanhMucDiaDiemHaCont);
                sqlParameters[14] = new SqlParameter("@NgayHaCont", obj.NgayHaCont);
                sqlParameters[15] = new SqlParameter("@SoLuongCont20", obj.SoLuongCont20);
                sqlParameters[16] = new SqlParameter("@SoCont20", obj.SoCont20);
                sqlParameters[17] = new SqlParameter("@SoLuongCont40", obj.SoLuongCont40);
                sqlParameters[18] = new SqlParameter("@SoCont40", obj.SoCont40);
                sqlParameters[19] = new SqlParameter("@SoLuongCont45", obj.SoLuongCont45);
                sqlParameters[20] = new SqlParameter("@SoCont45", obj.SoCont45);
                sqlParameters[21] = new SqlParameter("@IDDanhMucDiaDiemDongHang", obj.IDDanhMucDiaDiemDongHang);
                sqlParameters[22] = new SqlParameter("@NgayDongHang", obj.NgayDongHang);
                sqlParameters[23] = new SqlParameter("@IDDanhMucDiaDiemTraHang", obj.IDDanhMucDiaDiemTraHang);
                sqlParameters[24] = new SqlParameter("@NgayTraHang", obj.NgayTraHang);
                sqlParameters[25] = new SqlParameter("@KhoiLuong", obj.KhoiLuong);
                sqlParameters[26] = new SqlParameter("@GioTraHang", obj.KhoiLuong);
                sqlParameters[27] = new SqlParameter("@NguoiGiaoNhan", obj.NguoiGiaoNhan);
                sqlParameters[28] = new SqlParameter("@SoDienThoaiGiaoNhan", obj.SoDienThoaiGiaoNhan);
                //
                sqlParameters[29] = new SqlParameter("@GhiChu", obj.GhiChu);
                sqlParameters[30] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", coreCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParameters);
                int rowAffected = command.ExecuteNonQuery();
                obj.ID = coreCommon.coreCommon.longParse(sqlParameters[0].Value);
                obj.So = coreCommon.coreCommon.stringParse(sqlParameters[4].Value);
                transaction.Commit();
                return true;

            }
            catch (Exception ex)
            {
                if (transaction != null) transaction.Rollback();
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
            finally
            {
                command.Dispose();
                transaction.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        public bool Update(ctKeHoachVanTai obj)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlCommand command = null;
            SqlParameter[] sqlParameters = null;
            try
            {
                connection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString);
                connection.Open();
                transaction = connection.BeginTransaction();

                command = new SqlCommand(ctKeHoachVanTai.updateProcedureName, connection, transaction);
                command.CommandType = CommandType.StoredProcedure;
                sqlParameters = new SqlParameter[31];
                sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                sqlParameters[3] = new SqlParameter("@IDDanhMucChungTuTrangThai", obj.IDDanhMucChungTuTrangThai);
                sqlParameters[4] = new SqlParameter("@So", obj.So);
                sqlParameters[5] = new SqlParameter("@NgayLap", obj.NgayLap);
                //
                sqlParameters[6] = new SqlParameter("@IDDanhMucSale", obj.IDDanhMucSale);
                sqlParameters[7] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                sqlParameters[8] = new SqlParameter("@LoaiHinh", obj.LoaiHinh);
                sqlParameters[9] = new SqlParameter("@LoaiHang", obj.LoaiHang);
                sqlParameters[10] = new SqlParameter("@IDDanhMucHangTau", obj.IDDanhMucHangTau);
                sqlParameters[11] = new SqlParameter("@IDDanhMucDiaDiemNangCont", obj.IDDanhMucDiaDiemNangCont);
                sqlParameters[12] = new SqlParameter("@NgayNangCont", obj.NgayNangCont);
                sqlParameters[13] = new SqlParameter("@IDDanhMucDiaDiemHaCont", obj.IDDanhMucDiaDiemHaCont);
                sqlParameters[14] = new SqlParameter("@NgayHaCont", obj.NgayHaCont);
                sqlParameters[15] = new SqlParameter("@SoLuongCont20", obj.SoLuongCont20);
                sqlParameters[16] = new SqlParameter("@SoCont20", obj.SoCont20);
                sqlParameters[17] = new SqlParameter("@SoLuongCont40", obj.SoLuongCont40);
                sqlParameters[18] = new SqlParameter("@SoCont40", obj.SoCont40);
                sqlParameters[19] = new SqlParameter("@SoLuongCont45", obj.SoLuongCont45);
                sqlParameters[20] = new SqlParameter("@SoCont45", obj.SoCont45);
                sqlParameters[21] = new SqlParameter("@IDDanhMucDiaDiemDongHang", obj.IDDanhMucDiaDiemDongHang);
                sqlParameters[22] = new SqlParameter("@NgayDongHang", obj.NgayDongHang);
                sqlParameters[23] = new SqlParameter("@IDDanhMucDiaDiemTraHang", obj.IDDanhMucDiaDiemTraHang);
                sqlParameters[24] = new SqlParameter("@NgayTraHang", obj.NgayTraHang);
                sqlParameters[25] = new SqlParameter("@KhoiLuong", obj.KhoiLuong);
                sqlParameters[26] = new SqlParameter("@GioTraHang", obj.KhoiLuong);
                sqlParameters[27] = new SqlParameter("@NguoiGiaoNhan", obj.NguoiGiaoNhan);
                sqlParameters[28] = new SqlParameter("@SoDienThoaiGiaoNhan", obj.SoDienThoaiGiaoNhan);
                //
                sqlParameters[29] = new SqlParameter("@GhiChu", obj.GhiChu);
                sqlParameters[30] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParameters);
                int rowAffected = command.ExecuteNonQuery();
                    
                //}
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null) transaction.Rollback();
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                transaction.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        public bool Delete(object ID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctKeHoachVanTai.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[2];
                            sqlParameters[0] = new SqlParameter("@ID", ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucNguoiSuDungDelete", coreCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
    }
}
