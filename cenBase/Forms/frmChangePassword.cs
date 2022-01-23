using cenBUS.DatabaseCore;
using cenDTO.DatabaseCore;
using System;
using System.Windows.Forms;
namespace cenBase.Forms
{
    public partial class frmChangePassword : Form
    {
        public Boolean PasswordChanged = false;
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOldPassword.Value == null) txtOldPassword.Text = "";
                if (txtNewPassword1.Value == null) txtNewPassword1.Text = "";
                if (txtNewPassword2.Value == null) txtNewPassword2.Text = "";
                //Kiểm tra password cũ
                if (cenCommon.cenCommon.EncryptString(txtOldPassword.Text) != cenCommon.GlobalVariables.Password)
                {
                    cenCommon.cenCommon.ErrorMessageOkOnly("Password cũ không hợp lệ!");
                }
                //Nếu mật khẩu mới khớp
                if (txtNewPassword1.Text == txtNewPassword2.Text)
                {
                    DanhMucNguoiSuDung obj = new DanhMucNguoiSuDung
                    {
                        ID = cenCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                        IDDanhMucPhanQuyen = cenCommon.GlobalVariables.IDDanhMucPhanQuyen,
                        Ma = cenCommon.GlobalVariables.MaDanhMucNguoiSuDung,
                        Ten = cenCommon.GlobalVariables.TenDanhMucNguoiSuDung,
                        Password = cenCommon.cenCommon.EncryptString(txtNewPassword1.Text)
                    };
                    if (DanhMucNguoiSuDungBUS.UpdatePassword(cenCommon.GlobalVariables.IDDanhMucNguoiSuDung, cenCommon.cenCommon.EncryptString(txtNewPassword1.Text)))
                    {
                        cenCommon.GlobalVariables.Password = cenCommon.cenCommon.EncryptString(obj.Password.ToString());
                        cenCommon.cenCommon.InfoMessage("Thay đổi password thành công!");
                        Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới nhập không khớp nhau!\nXin hãy thử lại!", "ChuY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "ChuY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            //LoadDisplayLanguage
            //clsCommon.SetDisplayLanguage(this);
        }

    }
}
