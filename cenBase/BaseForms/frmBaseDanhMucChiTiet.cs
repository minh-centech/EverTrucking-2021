using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
namespace cenBase.BaseForms
{
    public partial class frmBaseDanhMucChiTiet : Form
    {
        public object IDDanhMucLoaiDoiTuong;
        public string TenDanhMucLoaiDoiTuong;

        public DataSet dsData = null;
        public BindingSource bsDanhMuc = null;
        protected BindingSource bsDanhMucChiTiet = null;
        protected String tableNameDanhMucChiTiet = String.Empty;
        protected Boolean bContinue = true;
        public frmBaseDanhMucChiTiet()
        {
            InitializeComponent();
        }
        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            UltraToolbarsManager1.Tools["btTimKiem"].SharedProps.Visible = false;
            List();
        }

        private void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key.ToString().ToUpper())
            {
                case "BTXOA":
                    DeleteDanhMuc();
                    break;
                case "BTTHEM":
                    InsertDanhMuc();
                    break;
                case "BTCOPY":
                    CopyDanhMuc();
                    break;
                case "BTSUA":
                    UpdateDanhMuc();
                    break;
                case "BTTAILAI":
                    List();
                    break;
                case "BTIN":
                    In();
                    break;
                case "BTEXCEL":
                    cenCommon.cenCommon.ExportGrid2Excel(ug);
                    break;
            }
        }

        protected virtual void List()
        {
        }
        protected virtual void In()
        {
        }
        protected virtual void InsertDanhMuc()
        {
            bContinue = (bsDanhMuc != null);
        }
        protected virtual void CopyDanhMuc()
        {
            bContinue = (bsDanhMuc != null && bsDanhMuc.Current != null && ug.ActiveRow != null);
        }
        protected virtual void UpdateDanhMuc()
        {
            bContinue = (bsDanhMuc != null && bsDanhMuc.Current != null && ug.ActiveRow != null);
        }
        protected virtual void DeleteDanhMuc()
        {
            bContinue = (bsDanhMuc != null && bsDanhMuc.Current != null && ug.ActiveRow != null && cenCommon.cenCommon.QuestionMessage("Bạn có chắc chắn muốn xóa mục dữ liệu này?", 0) != DialogResult.No);
        }
        protected virtual void InsertDanhMucChiTiet()
        {
            bContinue = (bsDanhMuc != null && bsDanhMuc.Current != null && ug.ActiveRow != null);
        }
        protected virtual void UpdateDanhMucChiTiet()
        {
            bContinue = (bsDanhMucChiTiet != null && bsDanhMucChiTiet.Current != null && ugChiTiet != null && ugChiTiet.ActiveRow != null);
        }
        protected virtual void DeleteDanhMucChiTiet()
        {
            bContinue = (bsDanhMucChiTiet != null && bsDanhMucChiTiet.Current != null && ugChiTiet != null && ugChiTiet.ActiveRow != null && cenCommon.cenCommon.QuestionMessage("Bạn có chắc chắn muốn xóa mục dữ liệu này?", 0) != DialogResult.No);
        }
        private void frmBaseDanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            //Chi tiết danh mục
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        InsertDanhMucChiTiet();
                        break;
                    case Keys.Enter:
                        UpdateDanhMucChiTiet();
                        break;
                    case Keys.Delete:
                        DeleteDanhMucChiTiet();
                        break;
                }
            }
        }

        private void ug_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UpdateDanhMuc();
        }

        private void txtChiTietfilterBox_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            switch (e.Button.Key.ToUpper())
            {
                case "BTTHEMCHITIET":
                    InsertDanhMucChiTiet();
                    break;
                case "BTSUACHITIET":
                    UpdateDanhMucChiTiet();
                    break;
                case "BTXOACHITIET":
                    DeleteDanhMucChiTiet();
                    break;
            }
        }

        private void ugChiTiet_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UpdateDanhMucChiTiet();
        }
    }
}
