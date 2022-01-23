using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
namespace cenBase.Forms
{
    public partial class frmSQLConnectUpdate : Form
    {
        public Boolean OK = false;
        string connectionString = string.Empty;
        public frmSQLConnectUpdate()
        {
            InitializeComponent();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!ValidData()) return;
            DataTable dtConnects = new DataTable("DataConnects");
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
            DataRow dataRow = dtConnects.NewRow();
            dataRow["Name"] = cenCommon.cenCommon.EncryptString(txtMoTa.Text);
            dataRow["ConnectionString"] = cenCommon.cenCommon.EncryptString(connectionString);
            dtConnects.Rows.Add(dataRow);
            dtConnects.WriteXml(cenCommon.GlobalVariables.ConnectionFileName, XmlWriteMode.WriteSchema);
            Close();
        }
        bool ValidData()
        {
            if (txtMoTa.Value == null) { cenCommon.cenCommon.ErrorMessageOkOnly("Mô tả không được để trống!"); return false; }
            if (txtServer.Value == null) { cenCommon.cenCommon.ErrorMessageOkOnly("Tên máy chủ không được để trống!"); return false; }
            if (txtData.Value == null) { cenCommon.cenCommon.ErrorMessageOkOnly("Tên dữ liệu không được để trống!"); return false; }
            if (txtUserName.Value == null) { cenCommon.cenCommon.ErrorMessageOkOnly("Tên người sử dụng không được để trống!"); return false; }
            if (txtPassword.Value == null) { cenCommon.cenCommon.ErrorMessageOkOnly("Password không được để trống!"); return false; }
            connectionString = @"Data Source=" + txtServer.Text.Trim() + @";Initial Catalog=" + txtData.Text.Trim() + @";Persist Security Info=True;User ID=" + txtUserName.Text.Trim() + @";Password=" + txtPassword.Text + ";Connect Timeout=60";
            return true;
        }

        private void cmdTestConnection_Click(object sender, EventArgs e)
        {

            if (!ValidData()) return;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Kết nối không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
