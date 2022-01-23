using System;
using System.Data;
using System.Windows.Forms;
namespace cenBase.BaseForms
{
    public partial class frmBaseChungTuSingleUpdate : Form
    {

        //Trạng thái cập nhật 1: Thêm mới, 2: Sửa
        public int CapNhat = 0;
        public object ID = null, IDDanhMucChungTu = null, LoaiManHinh = null;
        public string TenDanhMucChungTu = string.Empty;
        public DataRow dataRow = null;
        public DataTable dataTable = null;
        public frmBaseChungTuSingleUpdate()
        {
            InitializeComponent();
        }
        private void frm_donvi_capnhat_Load(object sender, EventArgs e)
        {
            Text = (CapNhat == cenCommon.ThaoTacDuLieu.Sua) ? cenCommon.ThaoTacDuLieu.DienGiaiSua : cenCommon.ThaoTacDuLieu.DienGiaiThem + " " + TenDanhMucChungTu;
            this.CenterToScreen();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveData(false);
        }
        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        protected virtual void SaveData(Boolean AddNew)
        {
        }
        /// <summary>
        /// Phím chức năng F6: Lưu dữ liệu, ESC: Thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (CapNhat == cenCommon.ThaoTacDuLieu.Xem) return;
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    SaveData(false);
                }
                if (e.KeyCode == Keys.N)
                {
                    if (LoaiManHinh.ToString() != cenCommon.LoaiManHinh.IDChiPhiVanTai && LoaiManHinh.ToString() != cenCommon.LoaiManHinh.IDChiPhiVanTaiBoSung)
                        SaveData(true);
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            return base.ProcessDialogKey(keyData);
        }
        private void cmdSaveAdd_Click(object sender, EventArgs e)
        {
            SaveData(true);
        }
    }
}
