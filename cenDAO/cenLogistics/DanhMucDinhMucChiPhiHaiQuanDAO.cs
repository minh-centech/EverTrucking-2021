using coreDAO;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class DanhMucDinhMucChiPhiHaiQuanDAO
    {
        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucDinhMucChiPhiHaiQuan.listProcedureName, DanhMucDinhMucChiPhiHaiQuan.tableName);
            return dt;
        }
        public bool Insert(ref DanhMucDinhMucChiPhiHaiQuan obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucDinhMucChiPhiHaiQuan.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[12];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@NgayApDung", obj.NgayApDung);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", obj.IDDanhMucNhomHangVanChuyen);
                            sqlParameters[5] = new SqlParameter("@IDDanhMucHangHoa", obj.IDDanhMucHangHoa);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                            sqlParameters[7] = new SqlParameter("@IDDanhMucChiPhiHaiQuanKinhDoanh", obj.IDDanhMucChiPhiHaiQuanKinhDoanh);
                            sqlParameters[8] = new SqlParameter("@SoTien", obj.SoTien);
                            sqlParameters[9] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[10] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[11] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Them, coreCommon.coreCommon.TraTuDien(DanhMucDinhMucChiPhiHaiQuan.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref DanhMucDinhMucChiPhiHaiQuan obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucDinhMucChiPhiHaiQuan.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[12];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@NgayApDung", obj.NgayApDung);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", obj.IDDanhMucNhomHangVanChuyen);
                            sqlParameters[5] = new SqlParameter("@IDDanhMucHangHoa", obj.IDDanhMucHangHoa);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                            sqlParameters[7] = new SqlParameter("@IDDanhMucChiPhiHaiQuanKinhDoanh", obj.IDDanhMucChiPhiHaiQuanKinhDoanh);
                            sqlParameters[8] = new SqlParameter("@SoTien", obj.SoTien);
                            sqlParameters[9] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[10] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[11] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Sua, coreCommon.coreCommon.TraTuDien(DanhMucDinhMucChiPhiHaiQuan.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(DanhMucDinhMucChiPhiHaiQuan obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucDinhMucChiPhiHaiQuan.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(coreCommon.coreCommon.AllPropertiesAndValues(obj), obj.ID, null, null, coreCommon.ThaoTacDuLieu.Xoa, coreCommon.coreCommon.TraTuDien(DanhMucDinhMucChiPhiHaiQuan.tableName), sqlConnection, sqlTransaction))
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
