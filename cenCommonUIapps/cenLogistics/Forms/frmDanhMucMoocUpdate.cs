using cenBUS.cenLogistics;
using coreBUS;
using coreControls;
using cenDTO.cenLogistics;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static cenCommonUIapps.cenCommonUIapps;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucMoocUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucMooc obj = null;
        public frmDanhMucMoocUpdate()
        {
            InitializeComponent();
        }
        protected override void SaveData(bool AddNew)
        {
            if (Save())
            {
                if (!AddNew)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them;
                    //Xóa text box
                    txtBienSo.Value = null;
                    txtMaDanhMucChuMooc.Value = null;
                    txtMaDanhMucChuMooc.ID = null;
                    txtTenDanhMucChuMooc.Value = null;
                    txtTaiTrong.Value = null;
                    txtGhiChu.Value = null;
                    picHinhAnhMatTruoc.Image = null;
                    picHinhAnhNgang.Image = null;
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucMooc
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    BienSo = txtBienSo.Value,
                    IDDanhMucChuMooc = txtMaDanhMucChuMooc.ID,
                    MaDanhMucChuMooc = txtMaDanhMucChuMooc.Value,
                    TenDanhMucChuMooc = txtTenDanhMucChuMooc.Value,
                    TaiTrong = txtTaiTrong.Value,
                    HinhAnhMatTruoc = (!coreCommon.coreCommon.IsNull(picHinhAnhMatTruoc.Image)) ? coreCommon.coreCommon.imageToByteArray((Image)picHinhAnhMatTruoc.Image) : null,
                    HinhAnhNgang = (!coreCommon.coreCommon.IsNull(picHinhAnhNgang.Image)) ? coreCommon.coreCommon.imageToByteArray((Image)picHinhAnhNgang.Image) : null,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucMooc
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    BienSo = txtBienSo.Value,
                    IDDanhMucChuMooc = txtMaDanhMucChuMooc.ID,
                    MaDanhMucChuMooc = txtMaDanhMucChuMooc.Value,
                    TenDanhMucChuMooc = txtTenDanhMucChuMooc.Value,
                    TaiTrong = txtTaiTrong.Value,
                    HinhAnhMatTruoc = (!coreCommon.coreCommon.IsNull(picHinhAnhMatTruoc.Image)) ? coreCommon.coreCommon.imageToByteArray((Image)picHinhAnhMatTruoc.Image) : null,
                    HinhAnhNgang = (!coreCommon.coreCommon.IsNull(picHinhAnhNgang.Image)) ? coreCommon.coreCommon.imageToByteArray((Image)picHinhAnhNgang.Image) : null,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucMoocBUS _BUS = new cenBUS.cenLogistics.DanhMucMoocBUS();
            bool OK = (CapNhat == 1 || CapNhat == 3) ? _BUS.Insert(ref obj) : _BUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                if (dataTable != null)
                {
                    if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
                    {
                        DataRow dr = dataTable.NewRow();
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            if (dataTable.Columns.Contains(prop.Name))
                                dr[prop.Name] = !coreCommon.coreCommon.IsNull(prop.GetValue(obj, null)) ? prop.GetValue(obj, null) : DBNull.Value;
                        }
                        dataTable.Rows.Add(dr);
                        dataTable.AcceptChanges();
                    }
                    else
                    {
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            if (dataTable.Columns.Contains(prop.Name))
                                dataRow[prop.Name] = !coreCommon.coreCommon.IsNull(prop.GetValue(obj, null)) ? prop.GetValue(obj, null) : DBNull.Value;
                        }
                    }
                }
                ID = obj.ID;
                return true;
            }
            else
            {
                ID = null;
                return false;
            }
        }
        private void frmDanhMucChungTuUpdate_Load(object sender, EventArgs e)
        {
            ////DanhMucKhachHang
            //DanhMucKhachHangBUS DanhMucKhachHangBUS = new DanhMucKhachHangBUS();
            //DataTable dtChuMooc = DanhMucKhachHangBUS.Valid(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
            //txtMaDanhMucChuMooc.IsValid = true;
            //txtMaDanhMucChuMooc.dtValid = dtChuMooc;
            //txtMaDanhMucChuMooc.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang));
            //saTextBox[] txtMaDanhMucChuMoocExt = new saTextBox[1];
            //txtMaDanhMucChuMoocExt[0] = txtTenDanhMucChuMooc;
            //txtMaDanhMucChuMooc.txtMoRong = txtMaDanhMucChuMoocExt;
            //txtMaDanhMucChuMooc.procedureName = DanhMucKhachHang.listProcedureName;
            //txtMaDanhMucChuMooc.ValidColumnName = "Ma";
            //txtMaDanhMucChuMooc.ReturnedColumnsList = "Ten";
            //txtMaDanhMucChuMooc.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);

            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                txtBienSo.Value = dataRow["BienSo"];
                txtMaDanhMucChuMooc.Value = dataRow["MaDanhMucChuMooc"];
                txtMaDanhMucChuMooc.ID = dataRow["IDDanhMucChuMooc"];
                txtTenDanhMucChuMooc.Value = dataRow["TenDanhMucChuMooc"];
                txtTaiTrong.Value = dataRow["TaiTrong"];
                txtGhiChu.Value = dataRow["GhiChu"];
                //Load hình ảnh
                DanhMucMoocBUS DanhMucMoocBUS = new DanhMucMoocBUS();
                DataTable dtHinhAnh = DanhMucMoocBUS.ListHinhAnh(dataRow["ID"]);
                if (dtHinhAnh.Rows.Count > 0)
                {
                    if (!coreCommon.coreCommon.IsNull(dtHinhAnh.Rows[0]["HinhAnhMatTruoc"]))
                    {
                        Byte[] bHinhAnhMatTruoc = (Byte[])(dtHinhAnh.Rows[0]["HinhAnhMatTruoc"]);
                        picHinhAnhMatTruoc.Image = coreCommon.coreCommon.byteArrayToImage(bHinhAnhMatTruoc);
                    }
                    if (!coreCommon.coreCommon.IsNull(dtHinhAnh.Rows[0]["HinhAnhNgang"]))
                    {
                        Byte[] bHinhAnhNgang = (Byte[])(dtHinhAnh.Rows[0]["HinhAnhNgang"]);
                        picHinhAnhNgang.Image = coreCommon.coreCommon.byteArrayToImage(bHinhAnhNgang);
                    }
                }
            }
        }
    }
}
