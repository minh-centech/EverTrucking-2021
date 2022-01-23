using coreDAO;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class DanhMucKhachHangDAO
    {
        public DataSet List(object ID, object IDDanhMucLoaiDoiTuong, object Level, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@Level", Level);
            sqlParameters[4] = new SqlParameter("@SearchStr", SearchStr);
            DataSet ds = dao.dsList(sqlParameters, DanhMucKhachHang.listProcedureName);
            if (ds != null)
            {
                ds.Tables[0].TableName = DanhMucKhachHang.tableName;
                ds.Tables[1].TableName = DanhMucKhachHangPhanCap.tableName;
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucKhachHangPhanCap.tableName, ds.Tables[DanhMucKhachHang.tableName].Columns["ID"], ds.Tables[DanhMucKhachHangPhanCap.tableName].Columns["IDDanhMucKhachHang"]);

            }
            return ds;
        }
        public DataTable Valid(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucKhachHang.validProcedureName, DanhMucKhachHang.tableName);
            return dt;
        }
        public DataTable ValidF1(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucKhachHang.validF1ProcedureName, DanhMucKhachHang.tableName);
            return dt;
        }
        public DataTable ValidF2(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucKhachHangF1, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@IDDanhMucKhachHangF1", IDDanhMucKhachHangF1);
            sqlParameters[4] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucKhachHang.validF2ProcedureName, DanhMucKhachHang.tableName);
            return dt;
        }
        public DataTable ValidF3(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucKhachHangF1, object IDDanhMucKhachHangF2, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@IDDanhMucKhachHangF1", IDDanhMucKhachHangF1);
            sqlParameters[4] = new SqlParameter("@IDDanhMucKhachHangF2", IDDanhMucKhachHangF2);
            sqlParameters[5] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucKhachHang.validF3ProcedureName, DanhMucKhachHang.tableName);
            return dt;
        }
        public bool Insert(ref DanhMucKhachHang obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucKhachHang.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[20];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[4] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[5] = new SqlParameter("@IDDanhMucNhanSu", obj.IDDanhMucNhanSu);
                            sqlParameters[6] = new SqlParameter("@DiaChi", obj.DiaChi);
                            sqlParameters[7] = new SqlParameter("@SoDienThoai", obj.SoDienThoai);
                            sqlParameters[8] = new SqlParameter("@SoFax", obj.SoFax);
                            sqlParameters[9] = new SqlParameter("@Email", obj.Email);
                            sqlParameters[10] = new SqlParameter("@MaSoThue", obj.MaSoThue);
                            sqlParameters[11] = new SqlParameter("@TenNganHang", obj.TenNganHang);
                            sqlParameters[12] = new SqlParameter("@SoTaiKhoan", obj.SoTaiKhoan);
                            sqlParameters[13] = new SqlParameter("@NguoiDaiDien", obj.NguoiDaiDien);
                            sqlParameters[14] = new SqlParameter("@NguoiGiaoNhan", obj.NguoiGiaoNhan);
                            sqlParameters[15] = new SqlParameter("@SoDienThoaiGiaoNhan", obj.SoDienThoaiGiaoNhan);
                            sqlParameters[16] = new SqlParameter("@IDDanhMucTuyenVanTai", obj.IDDanhMucTuyenVanTai);
                            sqlParameters[17] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[18] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[19] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Them, coreCommon.coreCommon.TraTuDien(DanhMucKhachHang.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref DanhMucKhachHang obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucKhachHang.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[20];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[4] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[5] = new SqlParameter("@IDDanhMucNhanSu", obj.IDDanhMucNhanSu);
                            sqlParameters[6] = new SqlParameter("@DiaChi", obj.DiaChi);
                            sqlParameters[7] = new SqlParameter("@SoDienThoai", obj.SoDienThoai);
                            sqlParameters[8] = new SqlParameter("@SoFax", obj.SoFax);
                            sqlParameters[9] = new SqlParameter("@Email", obj.Email);
                            sqlParameters[10] = new SqlParameter("@MaSoThue", obj.MaSoThue);
                            sqlParameters[11] = new SqlParameter("@TenNganHang", obj.TenNganHang);
                            sqlParameters[12] = new SqlParameter("@SoTaiKhoan", obj.SoTaiKhoan);
                            sqlParameters[13] = new SqlParameter("@NguoiDaiDien", obj.NguoiDaiDien);
                            sqlParameters[14] = new SqlParameter("@NguoiGiaoNhan", obj.NguoiGiaoNhan);
                            sqlParameters[15] = new SqlParameter("@SoDienThoaiGiaoNhan", obj.SoDienThoaiGiaoNhan);
                            sqlParameters[16] = new SqlParameter("@IDDanhMucTuyenVanTai", obj.IDDanhMucTuyenVanTai);
                            sqlParameters[17] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[18] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[19] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Sua, coreCommon.coreCommon.TraTuDien(DanhMucKhachHang.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(DanhMucKhachHang obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucKhachHang.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Xoa, coreCommon.coreCommon.TraTuDien(DanhMucKhachHang.tableName), sqlConnection, sqlTransaction))
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
    public class DanhMucKhachHangPhanCapDAO
    {
        public bool Insert(ref DanhMucKhachHangPhanCap obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucKhachHangPhanCap.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[9];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucKhachHangF2", obj.IDDanhMucKhachHangF2);
                            sqlParameters[5] = new SqlParameter("@IDDanhMucKhachHangF1", obj.IDDanhMucKhachHangF1);
                            sqlParameters[6] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[7] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", coreCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                            sqlParameters[8] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Them, coreCommon.coreCommon.TraTuDien(DanhMucKhachHangPhanCap.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref DanhMucKhachHangPhanCap obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucKhachHangPhanCap.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[9];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucKhachHangF2", obj.IDDanhMucKhachHangF2);
                            sqlParameters[5] = new SqlParameter("@IDDanhMucKhachHangF1", obj.IDDanhMucKhachHangF1);
                            sqlParameters[6] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[7] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", coreCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                            sqlParameters[8] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Sua, coreCommon.coreCommon.TraTuDien(DanhMucKhachHangPhanCap.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(DanhMucKhachHangPhanCap obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucKhachHangPhanCap.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Xoa, coreCommon.coreCommon.TraTuDien(DanhMucKhachHangPhanCap.tableName), sqlConnection, sqlTransaction))
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
