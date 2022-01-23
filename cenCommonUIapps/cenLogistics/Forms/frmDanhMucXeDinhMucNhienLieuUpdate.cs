using cenBUS.cenLogistics;
using coreBUS;
using coreControls;
using cenDTO.cenLogistics;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static cenCommonUIapps.cenCommonUIapps;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmDanhMucXeDinhMucNhienLieuUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        DanhMucXeDinhMucNhienLieu obj = null;
        public frmDanhMucXeDinhMucNhienLieuUpdate()
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
                    txtNgayApDung.Value = null;
                    txtMaDanhMucXe.Value = null;
                    txtMaDanhMucXe.ID = null;
                    txtTenDanhMucXe.Value = null;
                    txtDinhMucNhienLieuHangNheVo.Value = null;
                    txtDinhMucNhienLieuHangNhe.Value = null;
                    txtDinhMucNhienLieuHangNangVo.Value = null;
                    txtDinhMucNhienLieuHangNang.Value = null;
                    txtGhiChu.Value = null;
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new cenDTO.cenLogistics.DanhMucXeDinhMucNhienLieu
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    //
                    NgayApDung = txtNgayApDung.Value,
                    IDDanhMucXe = txtMaDanhMucXe.ID,
                    BienSo = txtMaDanhMucXe.Value,
                    DinhMucNhienLieuHangNheVo = txtDinhMucNhienLieuHangNheVo.Value,
                    DinhMucNhienLieuHangNhe = txtDinhMucNhienLieuHangNhe.Value,
                    DinhMucNhienLieuHangNangVo = txtDinhMucNhienLieuHangNangVo.Value,
                    DinhMucNhienLieuHangNang = txtDinhMucNhienLieuHangNang.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new cenDTO.cenLogistics.DanhMucXeDinhMucNhienLieu
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    //
                    NgayApDung = txtNgayApDung.Value,
                    IDDanhMucXe = txtMaDanhMucXe.ID,
                    BienSo = txtMaDanhMucXe.Value,
                    DinhMucNhienLieuHangNheVo = txtDinhMucNhienLieuHangNheVo.Value,
                    DinhMucNhienLieuHangNhe = txtDinhMucNhienLieuHangNhe.Value,
                    DinhMucNhienLieuHangNangVo = txtDinhMucNhienLieuHangNangVo.Value,
                    DinhMucNhienLieuHangNang = txtDinhMucNhienLieuHangNang.Value,
                    GhiChu = txtGhiChu.Value,
                    //
                    IDDanhMucNguoiSuDungEdit = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    CreateDate = null,
                    EditDate = null
                };
            }
            cenBUS.cenLogistics.DanhMucXeDinhMucNhienLieuBUS _BUS = new cenBUS.cenLogistics.DanhMucXeDinhMucNhienLieuBUS();
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
            ////DanhMucXe
            //DanhMucXeBUS BUS = new DanhMucXeBUS();
            //DataTable dtXe = BUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongXe)), null, null, null);
            //txtMaDanhMucXe.IsValid = true;
            //txtMaDanhMucXe.dtValid = dtXe;
            //txtMaDanhMucXe.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongXe));
            //saTextBox[] txtMaDanhMucXeExt = new saTextBox[1];
            //txtMaDanhMucXeExt[0] = txtTenDanhMucXe;
            //txtMaDanhMucXe.txtMoRong = txtMaDanhMucXeExt;
            //txtMaDanhMucXe.ValidColumnName = "BienSo";
            //txtMaDanhMucXe.ReturnedColumnsList = "BienSo";
            //txtMaDanhMucXe.procedureName = DanhMucXe.listProcedureName;
            //txtMaDanhMucXe.Validating += new CancelEventHandler(validDanhMuc.txtBox_Validating);

            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                txtNgayApDung.Value = dataRow["NgayApDung"];
                txtMaDanhMucXe.Value = dataRow["BienSo"];
                txtMaDanhMucXe.ID = dataRow["IDDanhMucXe"];
                txtTenDanhMucXe.Value = dataRow["BienSo"];
                txtDinhMucNhienLieuHangNheVo.Value = dataRow["DinhMucNhienLieuHangNheVo"];
                txtDinhMucNhienLieuHangNhe.Value = dataRow["DinhMucNhienLieuHangNhe"];
                txtDinhMucNhienLieuHangNangVo.Value = dataRow["DinhMucNhienLieuHangNangVo"];
                txtDinhMucNhienLieuHangNang.Value = dataRow["DinhMucNhienLieuHangNang"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
