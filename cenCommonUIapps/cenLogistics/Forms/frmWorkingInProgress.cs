using coreBUS;
using coreDTO;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmWorkingInProgress : Form
    {
        public DataTable dt;
        public object LoaiManHinh, ID;

        public frmWorkingInProgress()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ValidDanhMucDonGiaSuaChuaChiTietImport();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(e.UserState)) return;
            ultraProgressBar1.Value = (int)e.UserState;
            ultraProgressBar1.Text = ((int)e.UserState).ToString() + "/" + (dt.Rows.Count - 1).ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmdOK.Enabled = true;
        }

        private void ValidDanhMucDonGiaSuaChuaChiTietImport()
        {
            ////Valid 
            //int iRow = 1;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (!String.IsNullOrEmpty(dr["MaDanhMucBoPhanContainer"].ToString()))
            //    {
            //        DanhMucDoiTuongBUS bus = new DanhMucDoiTuongBUS();
            //        DataTable dtValid = bus.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(null)), dr["MaDanhMucBoPhanContainer"]);
            //        if (dtValid.Rows.Count == 1)
            //        {
            //            dr["IDDanhMucBoPhanContainer"] = dtValid.Rows[0]["ID"];
            //            dr["MaDanhMucBoPhanContainer"] = dtValid.Rows[0]["Ma"];
            //        }
            //        if (coreCommon.coreCommon.IsNull(dr["IDDanhMucBoPhanContainer"]))
            //        {
            //            DataRow dataRow = dtValid.NewRow();
            //            dataRow["Ma"] = dr["MaDanhMucBoPhanContainer"];
            //            dataRow["Ten"] = dr["MaDanhMucBoPhanContainer"];
            //            DanhMucDoiTuong obj = new DanhMucDoiTuong();
            //            obj.IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi;
            //            obj.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(null));
            //            obj.Ma = dr["MaDanhMucBoPhanContainer"];
            //            obj.Ten = dr["MaDanhMucBoPhanContainer"];
            //            obj.IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung;
            //            DanhMucDoiTuongBUS BUS = new DanhMucDoiTuongBUS();
            //            if (BUS.Insert(ref obj))
            //            {
            //                dataRow["ID"] = obj.ID;
            //                dataRow["IDDanhMucLoaiDoiTuong"] = obj.IDDanhMucLoaiDoiTuong;
            //                dataRow["IDDanhMucNguoiSuDungCreate"] = obj.IDDanhMucNguoiSuDungCreate;
            //                dtValid.Rows.Add(dataRow);
            //                dtValid.AcceptChanges();
            //                dr["IDDanhMucBoPhanContainer"] = obj.ID;
            //            }
            //        }
            //    }
            //    if (!String.IsNullOrEmpty(dr["MaDanhMucMaSuaChuaContainer"].ToString()))
            //    {
            //        DanhMucDoiTuongBUS bus = new DanhMucDoiTuongBUS();
            //        DataTable dtValid = bus.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(null)), dr["MaDanhMucMaSuaChuaContainer"]);
            //        if (dtValid.Rows.Count == 1)
            //        {
            //            dr["IDDanhMucMaSuaChuaContainer"] = dtValid.Rows[0]["ID"];
            //            dr["MaDanhMucMaSuaChuaContainer"] = dtValid.Rows[0]["Ma"];
            //        }
            //        if (coreCommon.coreCommon.IsNull(dr["IDDanhMucMaSuaChuaContainer"]))
            //        {
            //            DataRow dataRow = dtValid.NewRow();
            //            dataRow["Ma"] = dr["MaDanhMucMaSuaChuaContainer"];
            //            dataRow["Ten"] = dr["MaDanhMucMaSuaChuaContainer"];
            //            DanhMucDoiTuong obj = new DanhMucDoiTuong();
            //            obj.IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi;
            //            obj.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(null));
            //            obj.Ma = dr["MaDanhMucMaSuaChuaContainer"];
            //            obj.Ten = dr["MaDanhMucMaSuaChuaContainer"];
            //            obj.IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung;
            //            DanhMucDoiTuongBUS BUS = new DanhMucDoiTuongBUS();
            //            if (BUS.Insert(ref obj))
            //            {
            //                dataRow["ID"] = obj.ID;
            //                dataRow["IDDanhMucLoaiDoiTuong"] = obj.IDDanhMucLoaiDoiTuong;
            //                dataRow["IDDanhMucNguoiSuDungCreate"] = obj.IDDanhMucNguoiSuDungCreate;
            //                dtValid.Rows.Add(dataRow);
            //                dtValid.AcceptChanges();
            //                dr["IDDanhMucMaSuaChuaContainer"] = obj.ID;
            //            }
            //        }
            //    }
            //    if (!String.IsNullOrEmpty(dr["MaDanhMucDonViTinh"].ToString()))
            //    {
            //        DanhMucDoiTuongBUS bus = new DanhMucDoiTuongBUS();
            //        DataTable dtValid = bus.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(null)), dr["MaDanhMucDonViTinh"]);
            //        if (dtValid.Rows.Count == 1)
            //        {
            //            dr["IDDanhMucDonViTinh"] = dtValid.Rows[0]["ID"];
            //            dr["MaDanhMucDonViTinh"] = dtValid.Rows[0]["Ma"];
            //        }
            //        if (coreCommon.coreCommon.IsNull(dr["IDDanhMucDonViTinh"]))
            //        {
            //            DataRow dataRow = dtValid.NewRow();
            //            dataRow["Ma"] = dr["MaDanhMucDonViTinh"];
            //            dataRow["Ten"] = dr["MaDanhMucDonViTinh"];
            //            DanhMucDoiTuong obj = new DanhMucDoiTuong();
            //            obj.IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi;
            //            obj.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(null));
            //            obj.Ma = dr["MaDanhMucDonViTinh"];
            //            obj.Ten = dr["MaDanhMucDonViTinh"];
            //            obj.IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung;
            //            DanhMucDoiTuongBUS BUS = new DanhMucDoiTuongBUS();
            //            if (BUS.Insert(ref obj))
            //            {
            //                dataRow["ID"] = obj.ID;
            //                dataRow["IDDanhMucLoaiDoiTuong"] = obj.IDDanhMucLoaiDoiTuong;
            //                dataRow["IDDanhMucNguoiSuDungCreate"] = obj.IDDanhMucNguoiSuDungCreate;
            //                dtValid.Rows.Add(dataRow);
            //                dtValid.AcceptChanges();
            //                dr["IDDanhMucDonViTinh"] = obj.ID;
            //            }
            //        }
            //    }
            //    if (!String.IsNullOrEmpty(dr["MaDanhMucTienTe"].ToString()))
            //    {
            //        DanhMucDoiTuongBUS bus = new DanhMucDoiTuongBUS();
            //        DataTable dtValid = bus.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(null)), dr["MaDanhMucTienTe"]);
            //        if (dtValid.Rows.Count == 1)
            //        {
            //            dr["IDDanhMucTienTe"] = dtValid.Rows[0]["ID"];
            //            dr["MaDanhMucTienTe"] = dtValid.Rows[0]["Ma"];
            //        }
            //        if (coreCommon.coreCommon.IsNull(dr["IDDanhMucTienTe"]))
            //        {
            //            DataRow dataRow = dtValid.NewRow();
            //            dataRow["Ma"] = dr["MaDanhMucTienTe"];
            //            dataRow["Ten"] = dr["MaDanhMucTienTe"];
            //            DanhMucDoiTuong obj = new DanhMucDoiTuong();
            //            obj.IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi;
            //            obj.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(null));
            //            obj.Ma = dr["MaDanhMucTienTe"];
            //            obj.Ten = dr["MaDanhMucTienTe"];
            //            obj.IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung;
            //            DanhMucDoiTuongBUS BUS = new DanhMucDoiTuongBUS();
            //            if (BUS.Insert(ref obj))
            //            {
            //                dataRow["ID"] = obj.ID;
            //                dataRow["IDDanhMucLoaiDoiTuong"] = obj.IDDanhMucLoaiDoiTuong;
            //                dataRow["IDDanhMucNguoiSuDungCreate"] = obj.IDDanhMucNguoiSuDungCreate;
            //                dtValid.Rows.Add(dataRow);
            //                dtValid.AcceptChanges();
            //                dr["IDDanhMucTienTe"] = obj.ID;
            //            }
            //        }
            //    }
            //    if (!String.IsNullOrEmpty(dr["MaDanhMucNhomDonGiaSuaChuaChiTiet"].ToString()))
            //    {
            //        DanhMucDoiTuongBUS bus = new DanhMucDoiTuongBUS();
            //        DataTable dtValid = bus.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(null)), dr["MaDanhMucNhomDonGiaSuaChuaChiTiet"]);
            //        if (dtValid.Rows.Count == 1)
            //        {
            //            dr["IDDanhMucNhomDonGiaSuaChuaChiTiet"] = dtValid.Rows[0]["ID"];
            //            dr["MaDanhMucNhomDonGiaSuaChuaChiTiet"] = dtValid.Rows[0]["Ma"];
            //        }
            //        if (coreCommon.coreCommon.IsNull(dr["IDDanhMucNhomDonGiaSuaChuaChiTiet"]))
            //        {
            //            DataRow dataRow = dtValid.NewRow();
            //            dataRow["Ma"] = dr["MaDanhMucNhomDonGiaSuaChuaChiTiet"];
            //            dataRow["Ten"] = dr["MaDanhMucNhomDonGiaSuaChuaChiTiet"];
            //            DanhMucDoiTuong obj = new DanhMucDoiTuong();
            //            obj.IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi;
            //            obj.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(null));
            //            obj.Ma = dr["MaDanhMucNhomDonGiaSuaChuaChiTiet"];
            //            obj.Ten = dr["MaDanhMucNhomDonGiaSuaChuaChiTiet"];
            //            obj.IDDanhMucNguoiSuDungCreate = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung;
            //            DanhMucDoiTuongBUS BUS = new DanhMucDoiTuongBUS();
            //            if (BUS.Insert(ref obj))
            //            {
            //                dataRow["ID"] = obj.ID;
            //                dataRow["IDDanhMucLoaiDoiTuong"] = obj.IDDanhMucLoaiDoiTuong;
            //                dataRow["IDDanhMucNguoiSuDungCreate"] = obj.IDDanhMucNguoiSuDungCreate;
            //                dtValid.Rows.Add(dataRow);
            //                dtValid.AcceptChanges();
            //                dr["IDDanhMucNhomDonGiaSuaChuaChiTiet"] = obj.ID;
            //            }
            //        }
            //    }
            //    backgroundWorker1.ReportProgress(iRow / (dt.Rows.Count - 1) * 100, iRow - 1);
            //    iRow++;
            //}
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;
            cmdStart.Enabled = false;
            cmdOK.Enabled = false;
            ultraProgressBar1.Minimum = 0;
            ultraProgressBar1.Maximum = dt.Rows.Count - 1;
            backgroundWorker1.RunWorkerAsync();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
