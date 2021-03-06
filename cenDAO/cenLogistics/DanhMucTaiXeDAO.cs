using coreDAO;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class DanhMucTaiXeDAO
    {
        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucThauPhu, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@IDDanhMucThauPhu", IDDanhMucThauPhu);
            sqlParameters[4] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucTaiXe.listProcedureName, DanhMucTaiXe.tableName);
            return dt;
        }
        public bool Insert(ref DanhMucTaiXe obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTaiXe.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[13];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[4] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[5] = new SqlParameter("@SoDienThoai", obj.SoDienThoai);
                            sqlParameters[6] = new SqlParameter("@DiaChi", obj.DiaChi);
                            sqlParameters[7] = new SqlParameter("@SoCMND", obj.SoCMND);
                            sqlParameters[8] = new SqlParameter("@SoBangLai", obj.SoBangLai);
                            sqlParameters[9] = new SqlParameter("@IDDanhMucThauPhu", obj.IDDanhMucThauPhu);
                            sqlParameters[10] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[11] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[12] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Them, coreCommon.coreCommon.TraTuDien(DanhMucTaiXe.tableName), sqlConnection, sqlTransaction))
                            {
                                sqlTransaction.Commit();
                                return true;
                            }
                            else
                            {
                                sqlTransaction.Rollback();
                                return false;
                            }
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
        public bool Update(ref DanhMucTaiXe obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTaiXe.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[13];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[4] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[5] = new SqlParameter("@SoDienThoai", obj.SoDienThoai);
                            sqlParameters[6] = new SqlParameter("@DiaChi", obj.DiaChi);
                            sqlParameters[7] = new SqlParameter("@SoCMND", obj.SoCMND);
                            sqlParameters[8] = new SqlParameter("@SoBangLai", obj.SoBangLai);
                            sqlParameters[9] = new SqlParameter("@IDDanhMucThauPhu", obj.IDDanhMucThauPhu);
                            sqlParameters[10] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[11] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[12] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Sua, coreCommon.coreCommon.TraTuDien(DanhMucTaiXe.tableName), sqlConnection, sqlTransaction))
                            {
                                sqlTransaction.Commit();
                                return true;
                            }
                            else
                            {
                                sqlTransaction.Rollback();
                                return false;
                            }
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
        public bool Delete(DanhMucTaiXe obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTaiXe.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Xoa, coreCommon.coreCommon.TraTuDien(DanhMucTaiXe.tableName), sqlConnection, sqlTransaction))
                            {
                                sqlTransaction.Commit();
                                return true;
                            }
                            else
                            {
                                sqlTransaction.Rollback();
                                return false;
                            }
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
