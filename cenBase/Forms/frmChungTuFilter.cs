using cenControls;
using Infragistics.Win.UltraWinEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace cenBase.Forms
{
    public partial class frmChungTufilter : Form
    {
        public String IDDanhMucChungTu = "";
        public String TableName;
        public DataTable dtThamSo;
        DataSet dsValid;
        //Thông tin trả về
        public Boolean OK = false;//Ok hay Cancel
        public frmChungTufilter()
        {
            InitializeComponent();
        }

        private void frm_donvi_capnhat_Load(object sender, EventArgs e)
        {
            InitInputControl();
            this.Text = "Tìm kiếm";
            this.CenterToScreen();
        }
        /// <summary>
        /// Button OK-click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            OK = true;
            SaveParameterValue();
            Close();
        }
        //Tạo dataset cho ProcName
        private Boolean SaveParameterValue()
        {
            Boolean isCreated = false;
            try
            {
                //Lưu tham số vào dt
                dtThamSo.AcceptChanges();
                foreach (DataRow drThamSo in dtThamSo.Rows)
                {
                    String KieuThamSo = drThamSo["Kieu"].ToString();
                    String TenThamSo = drThamSo["Ten"].ToString();
                    switch (KieuThamSo)
                    {
                        case "BOOLEAN": //Bit
                            foreach (System.Windows.Forms.Control e in this.groupEditors.Controls)
                            {
                                if (e is saCheckBox && ((saCheckBox)e).Name == TenThamSo)
                                {
                                    saCheckBox chk = (saCheckBox)e;
                                    if (chk != null)
                                    {
                                        drThamSo["GiaTri"] = chk.Checked;
                                        break;
                                    }
                                }
                            }
                            break;
                        case "BYTE":
                        case "INT16": //Number
                        case "INT32": //Number
                        case "INT64": //Number
                        case "DECIMAL": //Number
                        case "DOUBLE": //Number
                        case "SINGLE": //Number
                            foreach (System.Windows.Forms.Control e in this.groupEditors.Controls)
                            {
                                if (e is saNumericBox && ((saNumericBox)e).Name == TenThamSo)
                                {
                                    saNumericBox nmr = (saNumericBox)e;
                                    if (nmr != null && nmr.Value.ToString() != "")
                                    {
                                        drThamSo["GiaTri"] = nmr.Value;
                                        break;
                                    }
                                }
                                if (e is saTextBox && ((saTextBox)e).Name == TenThamSo)
                                {
                                    saTextBox nmr = (saTextBox)e;
                                    if (nmr != null)
                                    {
                                        if (TenThamSo.StartsWith("@ID") && nmr.ID != "")
                                        {
                                            drThamSo["GiaTri"] = nmr.ID;
                                            drThamSo["GiaTriMoTa"] = nmr.Text;
                                            //Tìm control chứa tên để lấy tên
                                            if (Controls.Find("Ten" + TenThamSo, true).FirstOrDefault() is saTextBox txtTen)
                                                drThamSo["GiaTriTen"] = txtTen.Text;
                                            break;
                                        }
                                        else
                                        {
                                            if (nmr.Text != "")
                                            {
                                                drThamSo["GiaTri"] = nmr.Text;
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                if (e is saComboDanhMuc && ((saComboDanhMuc)e).Name == TenThamSo)
                                {
                                    saComboDanhMuc nmr = (saComboDanhMuc)e;
                                    if (nmr != null)
                                    {
                                        if ((TenThamSo.StartsWith("@ID") | TenThamSo.StartsWith("@Tk")) && nmr.Value != null)
                                        {
                                            drThamSo["GiaTri"] = nmr.Value;
                                            drThamSo["GiaTriMoTa"] = nmr.Text;
                                            drThamSo["GiaTriTen"] = nmr.Text;
                                            break;
                                        }
                                        else
                                        {
                                            if (nmr.Text != "")
                                            {
                                                drThamSo["GiaTri"] = nmr.Text;
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                            break;
                        case "STRING": //Text
                            foreach (System.Windows.Forms.Control e in this.groupEditors.Controls)
                            {
                                if (e is saTextBox && ((saTextBox)e).Name == TenThamSo)
                                {
                                    saTextBox nmr = (saTextBox)e;
                                    if (nmr != null)
                                    {
                                        if (TenThamSo.StartsWith("@ID") && nmr.ID != "")
                                        {
                                            drThamSo["GiaTri"] = nmr.ID;
                                            drThamSo["GiaTriMoTa"] = nmr.Text;
                                            //Tìm control chứa tên để lấy tên
                                            if (this.Controls.Find("Ten" + TenThamSo, true).FirstOrDefault() is saTextBox txtTen)
                                                drThamSo["GiaTriTen"] = txtTen.Text;
                                            break;
                                        }
                                        else
                                        {
                                            if (nmr.Text != "")
                                            {
                                                drThamSo["GiaTri"] = nmr.Text;
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                if (e is saComboDanhMuc && ((saComboDanhMuc)e).Name == TenThamSo)
                                {
                                    saComboDanhMuc nmr = (saComboDanhMuc)e;
                                    if (nmr != null)
                                    {
                                        if ((TenThamSo.StartsWith("@ID") | TenThamSo.StartsWith("@Tk")) && nmr.Value != null)
                                        {
                                            drThamSo["GiaTri"] = nmr.Value;
                                            drThamSo["GiaTriMoTa"] = nmr.Text;
                                            drThamSo["GiaTriTen"] = nmr.Text;
                                            break;
                                        }
                                        else
                                        {
                                            if (nmr.Text != "")
                                            {
                                                drThamSo["GiaTri"] = nmr.Text;
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                            break;
                        case "DATE":
                        case "DATETIME":
                            foreach (System.Windows.Forms.Control e in this.groupEditors.Controls)
                            {
                                if (e is saDateTimeBox && ((saDateTimeBox)e).Name == TenThamSo)
                                {
                                    saDateTimeBox dtm = (saDateTimeBox)e;
                                    if (dtm != null && dtm.Value != null)
                                    {
                                        drThamSo["GiaTri"] = dtm.DateTime.Year.ToString() + "/" + dtm.DateTime.Month.ToString() + "/" + dtm.DateTime.Day.ToString();
                                        break;
                                    }
                                }
                            }
                            break;
                    }
                    //MessageBox.Show(drThamSo["Ten"].ToString() + "-" + drThamSo["GiaTri"].ToString());
                    if (drThamSo["GiaTri"].ToString() == "")
                        drThamSo["GiaTri"] = DBNull.Value;
                }
                dtThamSo.AcceptChanges();

                isCreated = true;
                return isCreated;
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Tạo các textbox input dữ liệu
        /// </summary>
        protected void InitInputControl()
        {
            Int32 LeftAlignLabel1 = 12, LeftAlignLabel2 = 350, LeftAlignInputBox1 = 170, LeftAlignInputBox2 = 500;

            //Khai báo các biến control
            saTextBox txtBox = new saTextBox();
            saLabel lblBox = new saLabel();
            saCheckBox chkBox = new saCheckBox();
            saNumericBox numBox = new saNumericBox();
            saDateTimeBox dateBox = new saDateTimeBox();
            saComboDanhMuc cboDanhMuc = new saComboDanhMuc();
            //Đọc cấu trúc bảng
            int TopPos = 1;
            foreach (DataRow drThamSo in dtThamSo.Rows)
            {
                if (drThamSo["Ten"].ToString() != "@ID"
                    & drThamSo["Ten"].ToString() != "@IDDONVI"
                    & drThamSo["Ten"].ToString() != "@IDDANHMUCCHUNGTU"
                    & drThamSo["Ten"].ToString() != "@NAMLAMVIEC"
                    )
                {
                    String TenThamSo = drThamSo["Ten"].ToString();
                    String KieuThamSo = drThamSo["Kieu"].ToString();
                    if (cenCommon.GlobalVariables.TenCotDropdown.ToUpper().IndexOf("(" + TenThamSo.Substring(1) + ")") < 0) //Nếu không phải cột dropdown thì đặt textbox
                    {
                        if (TenThamSo.StartsWith("@ID"))
                        {
                            //Đặt textbox hoặc combobox dựa theo miền giá trị
                            lblBox = new saLabel
                            {
                                Left = !TenThamSo.EndsWith("END") ? LeftAlignLabel1 : LeftAlignLabel2,
                                Top = 12 + (29 * (TopPos - 1)),
                                Name = TenThamSo,
                                Tag = TenThamSo,
                                Text = cenCommon.cenCommon.TraTuDien(TenThamSo.Substring(1)),
                                Visible = true,
                                AutoSize = true
                            };
                            this.groupEditors.Controls.Add(lblBox);
                            //Đặt textbox
                            txtBox = new saTextBox
                            {
                                Left = LeftAlignInputBox1,
                                Top = 12 + (29 * (TopPos - 1))
                            };
                            ;
                            txtBox.Name = TenThamSo;
                            txtBox.Tag = TenThamSo;
                            //Thiết lập độ rộng và vị trí control
                            txtBox.Width = 150;
                            txtBox.IsNullable = true;
                            txtBox.Visible = true;
                            this.groupEditors.Controls.Add(txtBox);
                            txtBox.Editor.ExitEditMode(true, true);
                            txtBox.IsValid = true;
                            //Xác định loại đối tượng valid
                            String LoaiDoiTuong = TenThamSo.Substring(3);
                            if (LoaiDoiTuong == "DANHMUCCHUHANG" || LoaiDoiTuong == "DANHMUCCHUVO")
                                LoaiDoiTuong = "DanhMucHangTau";
                            LoaddsValid(LoaiDoiTuong);
                            if (LoaiDoiTuong.StartsWith("DANHMUCDONVITINH") || LoaiDoiTuong.StartsWith("DANHMUCKHO"))
                                LoaiDoiTuong = "DANHMUCDOITUONG";
                            if (dsValid.Tables.Contains(LoaiDoiTuong))
                                txtBox.dtValid = dsValid.Tables[LoaiDoiTuong];
                            //Đặt thêm 01 textbox chứa tên
                            string TenTxtMa = txtBox.Name;
                            saTextBox txtName = new saTextBox
                            {
                                Left = txtBox.Left + txtBox.Width + 6,
                                Top = txtBox.Top,
                                Name = "Ten" + txtBox.Name,
                                Tag = "Ten" + txtBox.Name,
                                Width = 344,
                                MaxLength = 512,
                                Visible = true,
                                IsValid = false,
                                IsNullable = true
                            };
                            //Tìm cột chứa tên
                            String CotTen = (LoaiDoiTuong.StartsWith("MA") ? LoaiDoiTuong.Substring(2) : LoaiDoiTuong);
                            txtName.Enabled = false;
                            this.groupEditors.Controls.Add(txtName);
                            txtName.Editor.ExitEditMode(true, true);
                            //
                            txtBox.txtMoRong = new saTextBox[1];
                            txtBox.txtMoRong[0] = txtName;
                            txtBox.ReturnedColumnsList = "Ten";
                            //
                            //txtBox.Validating += new System.ComponentModel.CancelEventHandler(cenBase.Classes.DanhMuc.txtBox_Validating);

                        }
                        else
                        {
                            if (KieuThamSo != "BOOLEAN")
                            {
                                switch (KieuThamSo)
                                {
                                    //Dữ liệu kiểu chuỗi hoặc kiểu tham chiếu
                                    case "STRING":
                                        //Đặt textbox hoặc combobox dựa theo miền giá trị
                                        lblBox = new saLabel
                                        {
                                            Left = !TenThamSo.EndsWith("END") ? LeftAlignLabel1 : LeftAlignLabel2,
                                            Top = 12 + (29 * (TopPos - 1)),
                                            Name = TenThamSo,
                                            Tag = TenThamSo,
                                            Text = cenCommon.cenCommon.TraTuDien(TenThamSo.Substring(1)),
                                            Visible = true,
                                            AutoSize = true
                                        };
                                        this.groupEditors.Controls.Add(lblBox);
                                        txtBox = new saTextBox
                                        {
                                            Left = !TenThamSo.EndsWith("END") ? LeftAlignInputBox1 : LeftAlignInputBox2,
                                            Top = 12 + (29 * (TopPos - 1)),
                                            Name = TenThamSo,
                                            Tag = TenThamSo,
                                            //Thiết lập độ rộng và vị trí control
                                            Width = (!TenThamSo.EndsWith("START") && !TenThamSo.EndsWith("END")) ? 500 : 150,
                                            //Thiết lập độ dài chuỗi được phép nhập vào control
                                            Visible = true
                                        };
                                        this.groupEditors.Controls.Add(txtBox);
                                        break;
                                    case "BYTE":
                                    case "INT16": //Số
                                    case "INT32": //Số
                                        //Đặt label
                                        lblBox = new saLabel
                                        {
                                            Left = !TenThamSo.EndsWith("END") ? LeftAlignLabel1 : LeftAlignLabel2,
                                            Top = 12 + (29 * (TopPos - 1)),
                                            Name = TenThamSo,
                                            Tag = TenThamSo,
                                            Text = cenCommon.cenCommon.TraTuDien(TenThamSo.Substring(1)),
                                            Visible = true,
                                            AutoSize = true
                                        };
                                        this.groupEditors.Controls.Add(lblBox);
                                        //Đặt numeric box
                                        numBox = new saNumericBox
                                        {
                                            NumericType = NumericType.Integer,
                                            Left = !TenThamSo.EndsWith("END") ? LeftAlignInputBox1 : LeftAlignInputBox2,
                                            Top = 12 + (29 * (TopPos - 1)),
                                            Name = TenThamSo,
                                            Tag = TenThamSo,
                                            Width = 150,
                                            Visible = true,
                                            FormatProvider = cenCommon.GlobalVariables.ci,
                                            Nullable = true
                                        };
                                        this.groupEditors.Controls.Add(numBox);
                                        break;
                                    case "DECIMAL": //Số
                                    case "DOUBLE": //Số
                                    case "SINGLE": //Số
                                        //Đặt label
                                        lblBox = new saLabel
                                        {
                                            Left = !TenThamSo.EndsWith("END") ? LeftAlignLabel1 : LeftAlignLabel2,
                                            Top = 12 + (29 * (TopPos - 1)),
                                            Name = TenThamSo,
                                            Tag = TenThamSo,
                                            Text = cenCommon.cenCommon.TraTuDien(TenThamSo.Substring(1)),
                                            Visible = true,
                                            AutoSize = true
                                        };
                                        this.groupEditors.Controls.Add(lblBox);
                                        //Đặt numeric box
                                        numBox = new saNumericBox
                                        {
                                            NumericType = NumericType.Double,
                                            Left = !TenThamSo.EndsWith("END") ? LeftAlignInputBox1 : LeftAlignInputBox2,
                                            Top = 12 + (29 * (TopPos - 1)),
                                            Name = TenThamSo,
                                            Tag = TenThamSo,
                                            Width = 150,
                                            Visible = true,
                                            FormatProvider = cenCommon.GlobalVariables.ci,
                                            Nullable = true
                                        };
                                        this.groupEditors.Controls.Add(numBox);
                                        break;
                                    case "DATE": //Ngày tháng
                                    case "DATETIME": //Ngày tháng
                                        //Đặt label
                                        lblBox = new saLabel
                                        {
                                            Left = !TenThamSo.EndsWith("END") ? LeftAlignLabel1 : LeftAlignLabel2,
                                            Top = 12 + (29 * (TopPos - 1)),
                                            Name = TenThamSo,
                                            Tag = TenThamSo,
                                            Text = cenCommon.cenCommon.TraTuDien(TenThamSo.Substring(1)),
                                            Visible = true,
                                            AutoSize = true
                                        };
                                        this.groupEditors.Controls.Add(lblBox);
                                        dateBox = new saDateTimeBox
                                        {
                                            //txtBox.Multiline = true;
                                            Left = !TenThamSo.EndsWith("END") ? LeftAlignInputBox1 : LeftAlignInputBox2,
                                            Top = 12 + (29 * (TopPos - 1)),
                                            Name = TenThamSo,
                                            Tag = TenThamSo,
                                            Width = 150,
                                            //dateBox.Value = clsCommon.NgayHachToan();
                                            Visible = true,
                                            //dateBox.Appearance.BackColor = cenCommon.GlobalVariables.ColorEditBox;
                                            Nullable = true,
                                            FormatProvider = cenCommon.GlobalVariables.ci
                                        };
                                        //dateBox.DateTime = cenCommon.cenCommon.NgayHachToan();
                                        this.groupEditors.Controls.Add(dateBox);
                                        break;
                                }

                            }
                        }
                        if (!TenThamSo.EndsWith("START"))
                            TopPos += 1;
                    }
                    else
                    {
                        //Đặt combo box
                        //Đặt textbox hoặc combobox dựa theo miền giá trị
                        lblBox = new saLabel
                        {
                            Left = 12,
                            Top = 12 + (29 * (TopPos - 1)),
                            Name = TenThamSo,
                            Tag = TenThamSo,
                            Text = cenCommon.cenCommon.TraTuDien(TenThamSo.Substring(1)),
                            Visible = true,
                            AutoSize = true
                        };
                        this.groupEditors.Controls.Add(lblBox);
                        cboDanhMuc = new saComboDanhMuc
                        {
                            Left = LeftAlignInputBox1,
                            Top = 12 + (29 * (TopPos - 1)),
                            Name = TenThamSo,
                            Tag = TenThamSo,
                            //Thiết lập độ rộng và vị trí control
                            Width = 150,
                            //Thiết lập độ dài chuỗi được phép nhập vào control
                            Visible = true,
                            IsNullable = true
                        };
                        this.groupEditors.Controls.Add(cboDanhMuc);
                        cboDanhMuc.Width = 500;
                        cboDanhMuc.IsNullable = false;
                        cboDanhMuc.Validating += new System.ComponentModel.CancelEventHandler(this.cboDanhMuc_Validating);


                        cboDanhMuc.IsModified = false;
                        TopPos += 1;
                    }
                }
            }
            //Đặt những mục nhập dạng check box xuống cuối cùng
            foreach (DataRow drThamSo in dtThamSo.Rows)
            {
                String TenThamSo = drThamSo["Ten"].ToString();
                String KieuThamSo = drThamSo["Kieu"].ToString();
                if (KieuThamSo == "Boolean")
                {
                    //Đặt label
                    lblBox = new saLabel
                    {
                        Left = LeftAlignLabel1,
                        Top = 12 + (29 * (TopPos - 1)),
                        Name = TenThamSo,
                        Tag = TenThamSo,
                        Text = "",
                        Visible = true,
                        AutoSize = true
                    };
                    this.groupEditors.Controls.Add(lblBox);
                    //Đặt check box
                    chkBox = new saCheckBox
                    {
                        Left = LeftAlignInputBox1,
                        Top = 12 + (29 * (TopPos - 1)),
                        Name = TenThamSo,
                        Tag = TenThamSo,
                        Text = cenCommon.cenCommon.TraTuDien(TenThamSo.Substring(1)),
                        AutoSize = true,
                        Visible = true
                    };
                    this.groupEditors.Controls.Add(chkBox);
                    TopPos += 1;
                }
                //Đặt chiều cao, độ rộng form
                this.Height = (29 * (TopPos + 1)) + 18;
                this.Width = 696;
            }
        }
        /// <summary>
        /// Ngừng cập nhật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        /// <summary>
        /// Ngừng
        /// </summary>
        private void Cancel()
        {
            OK = false;
            Close();
        }

        /// <summary>
        /// Gán loại danh mục khi chọn combo loại đối tượng 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDanhMuc_Validating(object sender, CancelEventArgs e)
        {
            saComboDanhMuc cboLoaiDoiTuong = (saComboDanhMuc)sender;
            if (cboLoaiDoiTuong.Value != null && cboLoaiDoiTuong.Value != DBNull.Value)
            {
                //Tìm textbox chứa tên
                foreach (Control ctl in this.groupEditors.Controls)
                {
                    if (ctl is saTextBox && ctl.Name == "@IDDOITUONG")
                    {
                        saTextBox txtID = (saTextBox)ctl;
                        Int64.TryParse(cboLoaiDoiTuong.Value.ToString(), out Int64 IDLoaiDoiTuong);
                        break;
                    }
                }
            }
        }
        private void frmfilterParameters_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    OK = true;
                    SaveParameterValue();
                    Close();
                    break;
                case Keys.Escape:
                    Cancel();
                    break;
            }
        }
        //Load danh mục valid
        private void LoaddsValid(String LoaiDanhMuc)
        {
            //if (dsValid == null) dsValid = new DataSet();
            //if (dsValid.Tables.Contains(LoaiDanhMuc)) dsValid.Tables.Remove(LoaiDanhMuc);
            //DanhMucBUS _BUS = new DanhMucBUS();
            //String IDDanhMucLoaiDoiTuongValid = _BUS.GetIDLoaiDoiTuong(LoaiDanhMuc);
            //DataTable dt = null;
            //if (!_BUS.List(ref dt, LoaiDanhMuc))
            //{
            //    cenCommon.cenCommon.ErrorMessageOkOnly("Lỗi tải danh mục " + LoaiDanhMuc);
            //    return;
            //}
            //dsValid.Tables.Add(dt);
        }
    }
}
