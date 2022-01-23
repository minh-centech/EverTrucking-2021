using cenControls;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using System;
using System.Data;
using System.Windows.Forms;
namespace cenBase.BaseForms
{
    public partial class frmBaseChungTuMasterDetail : Form
    {
        public short UpdateMode = 0; //Chế độ cập nhật: 0: Chỉ đọc, 1: Thêm mới, 2: Sửa chứng từ
        //Loại chứng từ
        public Object IDDanhMucChungTu;
        public Object MaDanhMucChungTu;
        public Object LoaiManHinh;
        public Int16 MaxDetailRow = 0;
        public DataSet dsChungTuLienQuan; //Table 0 chứa chứng từ in, Table 1 chứa chứng từ liên quan

        protected String ReportFileName = "", TenMayIn = "", spName = "";
        protected Int16 SoLien = 1;

        //
        public Boolean CallFromMain = true; //Gọi từ mainForm
        public Object GiaTriChuyenChungTuSau = null; //Giá trị truyển tới chứng từ tiếp theo
        //ID chứng từ tham chiếu
        public Object IDChungTuThamChieu = null;
        public Object IDChungTuThamChieuChiTiet = null;
        //DataSet
        public DataSet dsChungTu = new DataSet(); //Chứa chứng từ
        //DataTable lưu dữ liệu tạm
        protected DataRow drChungTu;
        public Boolean LoadEmpty = true; //Nạp chứng từ trắng
        //BindingSource
        public BindingSource bsChungTu = null; //Header chứng từ
        public BindingSource bsChungTuChiTiet = null; //Chi tiết chứng từ
        //Chứng từ
        public object IDChungTu = null;

        //protected Boolean drChungTuAdded = false;
        //protected Boolean drChungTuDeleted = false;
        //
        protected Boolean GridValidation = true;//Có valid trên lưới chi tiết chứng từ hay không
        public bool Saved = false;
        public frmBaseChungTuMasterDetail()
        {
            InitializeComponent();
            ugChiTiet.ConfirmDelete = false;
            toolBar.Toolbars[0].Tools["btThem"].SharedProps.Visible = false;
            toolBar.Toolbars[0].Tools["btXoa"].SharedProps.Visible = false;
            toolBar.Toolbars[0].Tools["btThemDong"].SharedProps.Visible = false;
            toolBar.Toolbars[0].Tools["btXoaDong"].SharedProps.Visible = false;
        }
        #region Methods
        //Lấy dữ liệu danh mục valid
        protected virtual void loadValidDataSet()
        {
        }
        //Lấy dữ liệu vào dataset
        protected virtual void loadData()
        {
        }
        //Kết nối dataset với control
        protected virtual void setDataBindings()
        {
        }
        //Thêm chứng từ
        protected virtual void themChungTu()
        {
        }
        //Thêm chứng từ chi tiết
        protected virtual void themChungTuChiTiet()
        {
        }
        //Sửa chứng từ
        protected virtual void suaChungTu()
        {
        }
        //Xóa chứng từ
        protected virtual void xoaChungTu()
        {
        }
        protected virtual void xoaChungTuChiTiet()
        {
            if (UpdateMode == 0) return;
            if (bsChungTuChiTiet.Current == null) return;
            bsChungTuChiTiet.RemoveCurrent();
        }
        //Lưu chứng từ
        protected virtual void luuChungTu(bool Exit)
        {
        }
        //In chứng từ
        protected virtual void inChungTu()
        {
        }
        //Ngừng cập nhật dữ liệu
        protected void ngungCapNhat(bool Exit)
        {
            if (UpdateMode != 0)
            {
                DialogResult dlr = cenCommon.cenCommon.QuestionMessage("Bạn chắc chắn muốn ngừng cập nhật dữ liệu?", 0);
                if (dlr == DialogResult.Yes)
                {
                    IDChungTu = null;
                    dsChungTu.RejectChanges();
                    bsChungTuChiTiet.CancelEdit();
                    bsChungTu.CancelEdit();
                    UpdateMode = 0;
                    Saved = false;
                    enableControl();
                    if (Exit)
                        DialogResult = DialogResult.Cancel;
                }
            }
        }
        //Tìm kiếm chứng từ
        protected virtual void filter()
        {

        }
        //Ẩn lưới danh sách chứng từ nếu ở chế độ cập nhật hoặc không có chứng từ nào
        //Kết nối dataset với control mở rộng
        protected virtual void setCustomsDataBindings()
        {
        }
        //Cho phép tương tác với controls
        protected virtual void enableControl()
        {
            Boolean ReadOnly = (UpdateMode == cenCommon.ThaoTacDuLieu.Xem);
            //Toolbar
            toolBar.Toolbars[0].Tools["btThem"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btSua"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btXoa"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btImport"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btThemDong"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btXoaDong"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btLuu"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btNgung"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btQuyTrinh"].SharedProps.Enabled = ReadOnly;
            toolBar.Toolbars[0].Tools["btTimKiem"].SharedProps.Enabled = ReadOnly;
            //Header
            foreach (Control ctl in groupHeader.Controls)
            {

                if (ctl is saTextBox && (ctl.Name.ToUpper() != "TXTSO" || ctl.Name.ToUpper() != "TXTKYHIEU"))
                {
                    saTextBox txtBox = (saTextBox)ctl;
                    txtBox.ReadOnly = ReadOnly;
                }
                if (ctl is saNumericBox)
                {
                    saNumericBox txtBox = (saNumericBox)ctl;
                    txtBox.ReadOnly = ReadOnly;
                }
                if (ctl is saDateTimeBox)
                {
                    saDateTimeBox txtBox = (saDateTimeBox)ctl;
                    txtBox.ReadOnly = ReadOnly;
                }
                if (ctl is saComboDanhMuc)
                {
                    saComboDanhMuc txtBox = (saComboDanhMuc)ctl;
                    txtBox.ReadOnly = ReadOnly;
                }
                if (ctl is saCheckBox)
                {
                    saCheckBox txtBox = (saCheckBox)ctl;
                    txtBox.Enabled = !ReadOnly;
                }

            }
            //Grid
            ugChiTiet.SetEditableState(ReadOnly);
        }
        //Lưu những thông tin mở rộng của chứng từ
        protected virtual void saveCustomsData()
        {
        }
        protected virtual void updateCustomsData()
        {
        }
        //Nhập dữ liệu từ Excel
        protected virtual void import()
        {
        }
        //Mở chứng từ ở bước tiếp theo của quy trình
        protected virtual void runNext(String IDDanhMucChungTu, String MaDanhMucChungTu, String LoaiManHinh, String FormCaption)
        {
        }
        //Mở form chi tiết chứng từ 2
        protected virtual void openChiTietChungTu2()
        {
        }
        #endregion Methods
        #region FormEvents
        private void frmBaseChungTu_Load(object sender, EventArgs e)
        {
            //
            if (dsChungTuLienQuan != null)
            {
                //Add các button là mẫu in chứng từ
                foreach (DataRow drChungTu in dsChungTuLienQuan.Tables[0].Rows)
                {
                    ButtonTool btChungTuIn = new ButtonTool("_rpt_" + drChungTu["FileMauIn"].ToString() + "ID:" + drChungTu["ID"].ToString() + "PRINTER:" + drChungTu["TenMayIn"].ToString() + "SOLIEN:" + drChungTu["SoLien"].ToString() + "SPNAME:" + drChungTu["spName"].ToString());
                    btChungTuIn.SharedProps.Caption = drChungTu["TenMauIn"].ToString();
                    toolBar.Tools.Add(btChungTuIn);
                    ((PopupMenuTool)toolBar.Toolbars[0].Tools["btIn"]).Tools.AddTool(btChungTuIn.Key);
                    btChungTuIn.SharedProps.Visible = true;
                }
                //Add các button là chứng từ liên quan
                foreach (DataRow drChungTu in dsChungTuLienQuan.Tables[1].Rows)
                {
                    ButtonTool btChungTuLienQuan = new ButtonTool("_dct_" + drChungTu["IDDanhMucChungTuLienQuan"].ToString() + "ID:" + drChungTu["ID"].ToString() + "MA:" + drChungTu["MaDanhMucChungTuLienQuan"].ToString() + "LOAIMANHINH:" + drChungTu["LoaiManHinh"].ToString());
                    btChungTuLienQuan.SharedProps.Caption = drChungTu["TenDanhMucChungTuLienQuan"].ToString();
                    toolBar.Tools.Add(btChungTuLienQuan);
                    ((PopupMenuTool)toolBar.Toolbars[0].Tools["btQuyTrinh"]).Tools.AddTool(btChungTuLienQuan.Key);
                    btChungTuLienQuan.SharedProps.Visible = true;
                }
            }
            //
            //LoadValidDataSet();
            //LoadData();
            ////
            //setDataBindings();
            //
            ugChiTiet.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(ugChiTiet_AfterCellUpdate);
            ugChiTiet.AfterRowInsert += new Infragistics.Win.UltraWinGrid.RowEventHandler(ugChiTiet_AfterRowInsert);

            //
        }
        private void frmBaseChungTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }
        private void frmBaseChungTu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UpdateMode != cenCommon.ThaoTacDuLieu.Xem)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly("Bạn phải kết thúc cập nhật chứng từ trước khi đóng cửa sổ!");
                e.Cancel = true;
            }
            else
            {
                if (!Saved) IDChungTu = null;
            }
        }
        #endregion FormEvents
        private void toolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            String buttonKey = e.Tool.Key.ToUpper();
            switch (buttonKey)
            {
                case "BTTHEM":
                    themChungTu();
                    break;
                case "BTSUA":
                    suaChungTu();
                    break;
                case "BTLUU":
                    luuChungTu(true);
                    break;
                case "BTXOA":
                    xoaChungTu();
                    break;
                case "BTNGUNG":
                    ngungCapNhat(true);
                    break;
                case "BTTIMKIEM":
                    filter();
                    break;
                case "BTXOADONG":
                    xoaChungTuChiTiet();
                    break;
                case "BTTHEMDONG":
                    themChungTuChiTiet();
                    break;
                case "BTIMPORT":
                    import();
                    break;
                case "BTIN":
                    inChungTu();
                    break;
                default:
                    String LoaiChucNang = e.Tool.Key.Substring(0, 5).ToUpper(),
                            TenChucNang = e.Tool.Key.Substring(5).ToUpper();
                    if (LoaiChucNang != "_DCT_" && LoaiChucNang != "_RPT_") return;
                    if (LoaiChucNang == "_DCT_")
                    {
                        String IDDanhMucChungTuLienQuan = e.Tool.Key.Substring(5, TenChucNang.IndexOf("ID:"));
                        String MaDanhMucChungTuLienQuan = TenChucNang.Substring(TenChucNang.IndexOf("MA:") + "MA:".Length, TenChucNang.IndexOf("LOAIMANHINH:") - TenChucNang.IndexOf("MA:") - "MA:".Length);
                        String LoaiManHinhLienQuan = TenChucNang.Substring(TenChucNang.IndexOf("LOAIMANHINH:") + "LOAIMANHINH:".Length, TenChucNang.Length - TenChucNang.IndexOf("LOAIMANHINH:") - "LOAIMANHINH:".Length);
                        runNext(IDDanhMucChungTuLienQuan, MaDanhMucChungTuLienQuan, LoaiManHinhLienQuan, e.Tool.SharedProps.Caption);
                    }
                    if (LoaiChucNang == "_RPT_")
                    {
                        ReportFileName = e.Tool.Key.Substring(5, TenChucNang.IndexOf("ID:"));
                        TenMayIn = e.Tool.Key.Substring(TenChucNang.IndexOf("PRINTER:") + 13, TenChucNang.IndexOf("SOLIEN:") - TenChucNang.IndexOf("PRINTER:") - 8);
                        SoLien = Convert.ToInt16(e.Tool.Key.Substring(TenChucNang.IndexOf("SOLIEN:") + 12, TenChucNang.IndexOf("SPNAME:") - TenChucNang.IndexOf("SOLIEN:") - 7));
                        spName = e.Tool.Key.Substring(TenChucNang.IndexOf("SPNAME:") + 12, e.Tool.Key.Length - TenChucNang.IndexOf("SPNAME:") - 12);
                        //"_rpt_" + drChungTu["FileMauIn"].ToString() + "ID:" + drChungTu["ID"].ToString() + "PRINTER:" + drChungTu["TenMayIn"].ToString() + "SOLIEN:" + drChungTu["SoLien"].ToString() + "SPNAME:" + drChungTu["spName"].ToString()
                        inChungTu();
                    }
                    break;
            }
        }
        #region gridDetail
        private void ugChiTiet_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (UpdateMode == 0 || !GridValidation) return;
            if (e.Cell == null) return;
            gridColumnDataProcess((saUpdateGrid)sender, e.Cell, out GridValidation, true);
        }
        private void ugChiTiet_AfterRowInsert(object sender, RowEventArgs e)
        {
            //e.Row.Cells["ID"].Value = cenBase.Classes.ChungTu.MaxTempID(dsChungTuUpdate.Tables[TableNameDetail]);
        }
        private void ugChiTiet_BeforeRowInsert(object sender, BeforeRowInsertEventArgs e)
        {
            ugChiTiet.UpdateData();
            //if (MaxDetailRow != 0 && dsChungTuUpdate.Tables[TableNameDetail].Rows.Count == MaxDetailRow)
            //{
            //    cenCommon.cenCommon.ErrorMessageOkOnly("Không được phép nhập quá " + MaxDetailRow.ToString() + " dòng chi tiết!");
            //    e.Cancel = true;
            //}
        }
        #endregion gridDetail
        //Valid các ô nhập dữ liệu trên lưới
        protected virtual void gridColumnDataProcess(UltraGrid ug, UltraGridCell uCell, out Boolean GridValidation, Boolean ShowLookUp)
        {
            GridValidation = true;
        }
    }
}
