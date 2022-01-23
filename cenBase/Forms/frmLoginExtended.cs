using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace cenBase.Forms
{
    public partial class frmLoginExtended : Form
    {
        public Boolean OK = false;
        public Boolean QuanTri = false;
        public DataTable dtDonVi;
        public frmLoginExtended()
        {
            InitializeComponent();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult msgboxResult = cenCommon.cenCommon.QuestionMessage("Bạn chắc chắn muốn thoát?", 0);
            if (msgboxResult == DialogResult.Yes)
            {
                OK = false;
                cenCommon.GlobalVariables.Logged = false;
                //Xóa thư mục Temp
                if (Directory.Exists(cenCommon.GlobalVariables.TempDir))
                    Directory.Delete(cenCommon.GlobalVariables.TempDir, true);
                Application.Exit();
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (this.cboDonVi.SelectedItem != null)
            {
                OK = true;

                cenBUS.DatabaseCore.DanhMucPhanQuyenBUS.GetPhanQuyenDonVi(cenCommon.GlobalVariables.IDDanhMucPhanQuyen, cboDonVi.Value, out bool Xem);
                if (!Xem)
                {
                    cenCommon.cenCommon.ErrorMessageOkOnly("Bạn không có quyền truy cập số liệu của đơn vị này!");
                    return;
                }
                cenCommon.GlobalVariables.IDDonVi = this.cboDonVi.Value.ToString();
                cenCommon.GlobalVariables.TenDonVi = this.cboDonVi.Text;
                //Tạo thư mục Temp
                if (!Directory.Exists(cenCommon.GlobalVariables.TempDir))
                    Directory.CreateDirectory(cenCommon.GlobalVariables.TempDir);
                Close();
            }
            else
                cenCommon.cenCommon.ErrorMessageOkOnly("Bạn chưa chọn đơn vị sử dụng!");
            cenCommon.GlobalVariables.Logged = OK;

        }

        private void frmLoginExtended_Load(object sender, EventArgs e)
        {

            this.cboDonVi.DataSource = dtDonVi;
            this.cboDonVi.ValueMember = "IDDanhMucDonVi";
            this.cboDonVi.DisplayMember = "TenDanhMucDonVi";
            if (this.cboDonVi.Items.Count > 0)
            {
                this.cboDonVi.SelectedItem = this.cboDonVi.Items[0];
                this.cboDonVi.Enabled = (this.cboDonVi.Items.Count > 1);
            }
        }
    }
}
