using cenBUS.DatabaseCore;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace cenBase.Forms
{
    public partial class frmLogin : Form
    {
        public Boolean OK = false;
        public Boolean QuanTri = false;
        public DataTable dtDonVi;
        DataTable dtConnects;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult msgboxResult = cenCommon.cenCommon.QuestionMessage("Bạn chắc chắn muốn thoát?", 0);
            if (msgboxResult == DialogResult.Yes)
            {
                OK = false;
                //Xóa thư mục Temp
                if (Directory.Exists(cenCommon.GlobalVariables.TempDir))
                    Directory.Delete(cenCommon.GlobalVariables.TempDir, true);
                Close();
                Application.Exit();
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (dtConnects.Rows.Count == 0) { cenCommon.cenCommon.ErrorMessageOkOnly("Không tìm thấy thông tin kết nối!"); return; }

            bool ConnectionFound = false;
            foreach (DataRow dr in dtConnects.Rows)
            {
                if (dr["ID"].ToString() == cboConnect.SelectedItem.DataValue.ToString())
                {
                    cenCommon.GlobalVariables.ConnectionString = cenCommon.cenCommon.DecryptString(dr["ConnectionString"].ToString());
                    ConnectionFound = true;
                    break;
                }
            }
            if (!ConnectionFound) { cenCommon.cenCommon.ErrorMessageOkOnly("Không tìm thấy thông tin kết nối!"); return; }

            cenCommon.GlobalVariables.IDDanhMucNguoiSuDung = DanhMucNguoiSuDungBUS.GetID(txtUserName.Value, cenCommon.cenCommon.EncryptString(txtPassword.Text), out cenCommon.GlobalVariables.IDDanhMucPhanQuyen, out cenCommon.GlobalVariables.isAdmin);
            OK = cenCommon.GlobalVariables.IDDanhMucNguoiSuDung != null;
            if (OK)
            {
                cenCommon.GlobalVariables.MaDanhMucNguoiSuDung = txtUserName.Text;
                cenCommon.GlobalVariables.Password = cenCommon.cenCommon.EncryptString(txtPassword.Text);
                if (cenCommon.GlobalVariables.IDDanhMucPhanQuyen == null)
                {
                    cenCommon.cenCommon.ErrorMessageOkOnly("Người sử dụng chưa được cấp quyền!");
                    OK = false;
                }
                else
                {
                    DanhMucPhanQuyenDonViBUS donviBUS = new DanhMucPhanQuyenDonViBUS();
                    dtDonVi = donviBUS.List(null, cenCommon.GlobalVariables.IDDanhMucPhanQuyen);
                    if (dtDonVi == null || dtDonVi.Rows.Count == 0)
                    {
                        cenCommon.cenCommon.ErrorMessageOkOnly("Người sử dụng chưa được khai báo đơn vị!");
                        OK = false;
                        cenCommon.GlobalVariables.Logged = false;
                    }
                    else
                    {
                        Close();
                        OK = true;
                        cenCommon.GlobalVariables.Logged = true;
                        frmLoginExtended frmLoginExtended = new frmLoginExtended
                        {
                            dtDonVi = dtDonVi
                        };
                        frmLoginExtended.ShowDialog();
                        cenCommon.GlobalVariables.TenDuLieu = cboConnect.Text;
                    }
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ!", "ChuY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void cmdSQLConnect_Click(object sender, EventArgs e)
        {
            frmSQLConnect frmSQLConnectUpdate = new frmSQLConnect();
            frmSQLConnectUpdate.ShowDialog();
            LoadData();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadData();
            if (dtConnects.Rows.Count == 0)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly("Không tìm thấy kết nối dữ liệu, bạn hãy khai báo ít nhất 1 kết nối!");
            }
            else
            {
                cboConnect.SelectedItem = cboConnect.Items[0];
            }
        }
        private void LoadData()
        {
            cboConnect.Items.Clear();
            dtConnects = new DataTable("DataConnects");
            dtConnects.Columns.Add(new DataColumn("ID", typeof(long)));
            dtConnects.Columns["ID"].AutoIncrement = true;
            dtConnects.Columns["ID"].AutoIncrementStep = 1;
            dtConnects.Columns.Add(new DataColumn("Name", typeof(String)));
            dtConnects.Columns.Add(new DataColumn("ConnectionString", typeof(String)));
            if (!File.Exists(Application.StartupPath + @"\DataConnects.xml"))
            {
                dtConnects.WriteXml(cenCommon.GlobalVariables.ConnectionFileName, XmlWriteMode.WriteSchema);
            }
            if (File.Exists(Application.StartupPath + @"\DataConnects.xml"))
            {
                dtConnects.ReadXml(cenCommon.GlobalVariables.ConnectionFileName);
            }
            foreach (DataRow dr in dtConnects.Rows)
            {
                cboConnect.Items.Add(dr["ID"], cenCommon.cenCommon.DecryptString(dr["Name"].ToString()));
            }
        }
    }
}
