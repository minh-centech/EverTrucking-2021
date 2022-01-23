using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using cenBase.Forms;
using System.Windows.Forms;
using System.ComponentModel;
using cenBUS;
using cenDTO;
using cenDAO;
using cenControls;
using cenCommon;
namespace cenBase.Classes
{
    public class DanhMuc
    {
        public static void txtBox_Validating(object sender, CancelEventArgs e)
        {
            saTextBox txtID = (saTextBox)sender;
            txtID.Text = txtID.Text.Trim();
            if (txtID.dtValid != null) //Nếu có loại danh mục thì mới valid
            {
                //Xoá textbox chứa thông tin trả về nếu ko có dữ liệu
                if (txtID.Text == "")
                {
                    txtID.ID = null;
                    //Tìm textbox chứa tên
                    if (txtID.txtMoRong != null && txtID.txtMoRong.Count() > 0)
                    {
                        foreach (saTextBox txtMoRong in txtID.txtMoRong)
                        {
                            txtMoRong.Text = "";
                        }
                    }
                }
                if ((txtID.IsModified || txtID.ID == null) && !txtID.ReadOnly && txtID.IsValid && ((!txtID.IsNullable & txtID.ID == null) | (txtID.IsNullable & txtID.Text != "")))
                {
                    if (!txtID.IsNullable | txtID.Text != "")
                    {
                        String  ID = "",
                                Ma = "";
                        
                        String[] ThongTinMoRong = txtID.ReturnedColumnsList.Split(';');

                        Int32 iThongTinMoRong = 0;
                        if (txtID.txtMoRong != null && iThongTinMoRong < ThongTinMoRong.Count()) iThongTinMoRong = ThongTinMoRong.Count();

                        List<DataRow> drDoiTuong = ValidDoiTuong(txtID.dtValid, txtID.Text.Trim(), txtID.LoaiDanhMuc, txtID.IsMultiSelect, txtID.showLookUp, txtID.ValidColumnName);

                        if (drDoiTuong == null || drDoiTuong.Count == 0)
                        {
                            txtID.ID = null;
                            if (txtID.txtMoRong != null && txtID.txtMoRong.Count() > 0)
                            {
                                foreach (saTextBox txtMoRong in txtID.txtMoRong)
                                {
                                    txtMoRong.Text = "";
                                }
                            }
                            return;
                        }

                        if (txtID.txtMoRong != null && txtID.txtMoRong.Count() > 0)
                        {
                            foreach (saTextBox txtMoRong in txtID.txtMoRong)
                            {
                                txtMoRong.Text = "";
                            }
                        }
                        foreach (DataRow iDoiTuong in drDoiTuong)
                        {
                            Ma = Ma + iDoiTuong[txtID.ValidColumnName].ToString() + ";";
                            ID = ID + iDoiTuong["ID"].ToString() + ";";
                            if (txtID.txtMoRong != null)
                            {
                                for (Int32 i = 0; i < iThongTinMoRong; i++)
                                {
                                    if (txtID.dtValid.Columns.Contains(ThongTinMoRong[i]) && iDoiTuong[ThongTinMoRong[i]] != DBNull.Value)
                                    {
                                        txtID.txtMoRong[i].Text = txtID.txtMoRong[i].Text + iDoiTuong[ThongTinMoRong[i]].ToString() + ";";
                                    }
                                }
                            }
                        }
                        txtID.Text = Ma.Substring(0, Ma.Length - 1);
                        txtID.ID = ID.Substring(0, ID.Length - 1);
                        if (txtID.txtMoRong != null)
                        {
                            for (Int32 i = 0; i < iThongTinMoRong; i++)
                            {
                                if (txtID.txtMoRong[i].Text.Length > 1)
                                    txtID.txtMoRong[i].Text = txtID.txtMoRong[i].Text.Substring(0, txtID.txtMoRong[i].Text.Length - 1);
                            }
                        }
                    }
                }
            }
        }
        public static List<DataRow> ValidDoiTuong(DataTable dtValid, String MaDoiTuong, String LoaiDanhMuc, Boolean MultiSelect, bool ShowLookUp = true, string ValidColumnName = "Ma")
        {
            //Danh sách dòng dữ liệu trả về
            List<DataRow> listDoiTuong = new List<DataRow>();
            //Có cần phải mở form look-up hay không?
            Boolean isShowLookUp = false;
            //Valid có trả về dòng dữ liệu hay không
            ValidDataRow(listDoiTuong, dtValid, MaDoiTuong, ValidColumnName, out bool isExist, out bool isOK, ref isShowLookUp);
            if (ShowLookUp && listDoiTuong.Count != 1) //Nếu user yêu cầu mở form look-up và cần phải mở
            {
                frmDanhMucValid frmLookUp = new frmDanhMucValid
                {
                    LoaiDanhMuc = LoaiDanhMuc,
                    //IDDanhMucLoaiDoiTuong = BUS.GetIDLoaiDoiTuong(LoaiDanhMuc),
                    MultiSelect = MultiSelect,
                    Ma = MaDoiTuong,
                    DanhSachMa = MaDoiTuong,
                    dtValid = dtValid
                };
                frmLookUp.ShowDialog();
                if (frmLookUp.listDoiTuong != null)
                {
                    listDoiTuong = new List<DataRow>();
                    listDoiTuong = frmLookUp.listDoiTuong;
                }
                dtValid = frmLookUp.dtValid;
                frmLookUp.Dispose();
            }
            return listDoiTuong;
        }
        public static void ValidDataRow(List<DataRow> listDoiTuong, DataTable dtDoiTuong, String Value, String ColumnName, out Boolean isExist, out Boolean isOK, ref Boolean isShowLookUp)
        {
            isExist = false;
            isOK = false;
            String sSelect = ColumnName + "=\'" + Value + "\'";
            DataRow[] drs = dtDoiTuong.Select(sSelect);
            //Nếu không có dòng dữ liệu trả về
            if (drs == null || drs.Length == 0)
            {
                isShowLookUp = true;
                listDoiTuong = null;
                return;
            }
            //Nếu chỉ có 1 dòng dữ liệu trả về
            if (dtDoiTuong.Rows.Count == 1)
            {
                isExist = true;
                //Nếu có thì chỉ add vào danh sách đúng dòng này
                listDoiTuong.Add(drs[0]);
                return;
            }
            //Nếu có hơn 1 dòng dữ liệu trả về
            if (dtDoiTuong.Rows.Count > 1)
            {
                isExist = true;
                //Kiểm tra xem có mã nào chính xác bằng mã này hay không?
                isOK = (dtDoiTuong.Select(sSelect).Length > 0);
                //Nếu không có dòng chứa mã này
                if (!isOK)
                {
                    //Nếu không thì add toàn bộ dòng trả về
                    //foreach (DataRow drDoiTuong in dtDoiTuong.Rows)
                    //    listDoiTuong.Add(drDoiTuong);
                    //Show Look-up
                    isShowLookUp = true;
                    listDoiTuong = null;
                    return;
                }
                if (isOK)
                {
                    //Nếu có thì chỉ add vào danh sách đúng dòng này
                    listDoiTuong.Add(dtDoiTuong.Select(sSelect)[0]);
                    return;
                }
            }
        }
        public static Boolean CheckFormDanhMucOpened(String IDDanhMucLoaiDoiTuong)
        {
            Boolean frmOpened = false;
            //foreach (Form frm in Application.OpenForms)
            //{
            //    if (frm.Name.ToUpper() == "FRMDANHMUC" && ((frmDanhMuc)frm).IDDanhMucLoaiDoiTuong != null && ((frmDanhMuc)frm).IDDanhMucLoaiDoiTuong.ToString() == IDDanhMucLoaiDoiTuong)
            //    {
            //        frmOpened = true;
            //        frm.Focus();
            //        break;
            //    }
            //}
            return frmOpened;
        }
    }
}
