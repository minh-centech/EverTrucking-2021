using coreBUS;
using cenCommonUIapps.cenLogistics.Forms;
using coreControls;
using cenDAO;
using cenDTO.cenLogistics;
using coreDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using coreUI.Forms;
using cenBUS.cenLogistics;
namespace cenCommonUIapps
{
    public class cenCommonUIapps
    {
        public static void runDanhMuc(string formCaption, object IDDanhMucLoaiDoiTuong, Form mdiParent)
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xem)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền truy cập danh mục này");
                return;
            }
            string TenBangDuLieu = DanhMucLoaiDoiTuongBUS.GetTenBangDuLieu(IDDanhMucLoaiDoiTuong);
            switch (TenBangDuLieu)
            {
                case DanhMucXeDinhMucNhienLieu.tableName:
                    frmDanhMucXeDinhMucNhienLieu frmDanhMucXeDinhMucNhienLieu = new frmDanhMucXeDinhMucNhienLieu()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucXeDinhMucNhienLieu.Show();
                    break;
                case DanhMucDinhMucChiPhi.tableName:
                    frmDanhMucDinhMucChiPhi frmDanhMucDinhMucChiPhi = new frmDanhMucDinhMucChiPhi()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucDinhMucChiPhi.Show();
                    break;
                case DanhMucDinhMucChiPhiHaiQuan.tableName:
                    frmDanhMucDinhMucChiPhiHaiQuan frmDanhMucDinhMucChiPhiHaiQuan = new frmDanhMucDinhMucChiPhiHaiQuan()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucDinhMucChiPhiHaiQuan.Show();
                    break;
                case DanhMucHangHoa.tableName:
                    frmDanhMucHangHoa frmDanhMucHangHoa = new frmDanhMucHangHoa()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucHangHoa.Show();
                    break;
                case DanhMucGiaNhienLieu.tableName:
                    frmDanhMucGiaNhienLieu frmDanhMucGiaNhienLieu = new frmDanhMucGiaNhienLieu()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucGiaNhienLieu.Show();
                    break;
                case DanhMucTuyenVanTai.tableName:
                    frmDanhMucTuyenVanTai frmDanhMucTuyenVanTai = new frmDanhMucTuyenVanTai()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucTuyenVanTai.Show();
                    break;
                case DanhMucTaiXe.tableName:
                    frmDanhMucTaiXe frmDanhMucTaiXe = new frmDanhMucTaiXe()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucTaiXe.Show();
                    break;
                case DanhMucMooc.tableName:
                    frmDanhMucMooc frmDanhMucMooc = new frmDanhMucMooc()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucMooc.Show();
                    break;
                case DanhMucXe.tableName:
                    frmDanhMucXe frmDanhMucXe = new frmDanhMucXe()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucXe.Show();
                    break;
                case DanhMucNhanSu.tableName:
                    frmDanhMucNhanSu frmDanhMucNhanSu = new frmDanhMucNhanSu()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucNhanSu.Show();
                    break;
                case DanhMucKhachHang.tableName:
                    frmDanhMucKhachHang frmDanhMucKhachHang = new frmDanhMucKhachHang()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucKhachHang.Show();
                    break;
                case DanhMucThauPhu.tableName:
                    frmDanhMucThauPhu frmDanhMucThauPhu = new frmDanhMucThauPhu()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucThauPhu.Show();
                    break;
                case DanhMucDiaDiemGiaoNhan.tableName:
                    frmDanhMucDiaDiemGiaoNhan frmDanhMucDiaDiemGiaoNhan = new frmDanhMucDiaDiemGiaoNhan()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucDiaDiemGiaoNhan.Show();
                    break;
                case DanhMucDoiTuong.tableName:
                    frmDanhMucDoiTuong frmDanhMucDoiTuong = new frmDanhMucDoiTuong()
                    {
                        Text = formCaption,
                        IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                        TenDanhMucLoaiDoiTuong = formCaption,
                        MdiParent = mdiParent,
                    };
                    frmDanhMucDoiTuong.Show();
                    break;
            }

        }
        public static void runChungTu(string formCaption, object LoaiManHinh, object IDDanhMucChungTu, Form mdiParent)
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xem)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền truy cập danh mục này");
                return;
            }
            frm_ctList frm_ctList;
            switch (LoaiManHinh)
            {
                case cenCommon.LoaiManHinh.IDKeHoachVanTai:
                    frm_ctList = new frm_ctList()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = IDDanhMucChungTu,
                        FixedColumnsList = "[So][NgayLap]",
                        MdiParent = mdiParent
                    };
                    frm_ctList.fList = new Func<DataTable>(() => ctKeHoachVanTaiBUS.ListDisplay(IDDanhMucChungTu, frm_ctList.txtTuNgay.Value, frm_ctList.txtDenNgay.Value, null));
                    frm_ctList.fInsert = new Action(() => clsKeHoachVanTai.Insert(LoaiManHinh, IDDanhMucChungTu, frm_ctList.txtTuNgay.Value, frm_ctList.txtDenNgay.Value, formCaption, new Action(() => frm_ctList.InsertToList(frm_ctKeHoachVanTaiUpdate.dtUpdate))));
                    frm_ctList.fUpdate = new Action(() => clsKeHoachVanTai.Update(LoaiManHinh, IDDanhMucChungTu, frm_ctList.txtTuNgay.Value, frm_ctList.txtDenNgay.Value, frm_ctList.ug.ActiveRow.Cells["ID"].Value, formCaption, new Action(() => frm_ctList.UpdateToList(frm_ctKeHoachVanTaiUpdate.dtUpdate))));
                    frm_ctList.fDelete = new Func<bool>(() => ctKeHoachVanTaiBUS.Delete(frm_ctList.ug.ActiveRow.Cells["ID"].Value.ToString()));
                    frm_ctList.fDeleteChiTiet = null;
                    frm_ctList.Show();
                    break;
                case cenCommon.LoaiManHinh.IDDonHang:
                    frm_ctDonHang frm_ctDonHang = new frm_ctDonHang()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = IDDanhMucChungTu,
                        MdiParent = mdiParent,

                    };
                    frm_ctDonHang.Show();
                    break;
                case cenCommon.LoaiManHinh.IDTamUng:
                    frm_ctTamUng frm_ctTamUng = new frm_ctTamUng()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        MdiParent = mdiParent,
                    };
                    frm_ctTamUng.Show();
                    break;
                case cenCommon.LoaiManHinh.IDThanhToanTamUng:
                    frm_ctThanhToanTamUng frm_ctThanhToanTamUng = new frm_ctThanhToanTamUng()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        MdiParent = mdiParent
                    };
                    frm_ctThanhToanTamUng.Show();
                    break;
                case cenCommon.LoaiManHinh.IDChotDoanhThuGuiKeToan:
                    frm_ctChotDoanhThuGuiKeToan frm_ctChotDoanhThuGuiKeToan = new frm_ctChotDoanhThuGuiKeToan()
                    {
                        Text = formCaption,
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        MdiParent = mdiParent
                    };
                    frm_ctChotDoanhThuGuiKeToan.Show();
                    break;
                case cenCommon.LoaiManHinh.IDChiPhiVanTai:
                    frm_ctChiPhiVanTai frm_ctChiPhiVanTai = new frm_ctChiPhiVanTai()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        MdiParent = mdiParent
                    };
                    frm_ctChiPhiVanTai.Show();
                    break;
                case cenCommon.LoaiManHinh.IDChotChiPhiVanTaiGuiKeToan:
                    frm_ctChotChiPhiVanTaiGuiKeToan frm_ctChotChiPhiVanTaiGuiKeToan = new frm_ctChotChiPhiVanTaiGuiKeToan()
                    {
                        Text = formCaption,
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        MdiParent = mdiParent
                    };
                    frm_ctChotChiPhiVanTaiGuiKeToan.Show();
                    break;
                case cenCommon.LoaiManHinh.IDChiPhiVanTaiBoSung:
                    frm_ctChiPhiVanTaiBoSung frm_ctChiPhiVanTaiBoSung = new frm_ctChiPhiVanTaiBoSung()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        MdiParent = mdiParent
                    };
                    frm_ctChiPhiVanTaiBoSung.Show();
                    break;
                case cenCommon.LoaiManHinh.IDChotChiPhiVanTaiBoSungGuiKeToan:
                    frm_ctChotChiPhiVanTaiBoSungGuiKeToan frm_ctChotChiPhiVanTaiBoSungGuiKeToan = new frm_ctChotChiPhiVanTaiBoSungGuiKeToan()
                    {
                        Text = formCaption,
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        MdiParent = mdiParent
                    };
                    frm_ctChotChiPhiVanTaiBoSungGuiKeToan.Show();
                    break;
                case cenCommon.LoaiManHinh.IDSuaChua:
                    frm_ctSuaChua frm_ctSuaChua = new frm_ctSuaChua()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = IDDanhMucChungTu,
                        MdiParent = mdiParent
                    };
                    frm_ctSuaChua.Show();
                    break;
                case cenCommon.LoaiManHinh.IDDieuHanh:
                    frm_ctDieuHanh frm_ctDieuHanh = new frm_ctDieuHanh()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        MdiParent = mdiParent
                    };
                    frm_ctDieuHanh.Show();
                    break;
                case cenCommon.LoaiManHinh.IDHotline:
                    frm_ctHotline frm_ctHotline = new frm_ctHotline()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        MdiParent = mdiParent
                    };
                    frm_ctHotline.Show();
                    break;
                case cenCommon.LoaiManHinh.IDInGiayVanTai:
                    frm_ctInGiayVanTai frm_ctInGiayVanTai = new frm_ctInGiayVanTai()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        MdiParent = mdiParent
                    };
                    frm_ctInGiayVanTai.Show();
                    break;
                case cenCommon.LoaiManHinh.IDPhieuDoNhienLieu:
                    frm_ctPhieuDoNhienLieu frm_ctPhieuDoNhienLieu = new frm_ctPhieuDoNhienLieu()
                    {
                        Text = formCaption,
                        LoaiManHinh = LoaiManHinh,
                        IDDanhMucChungTu = IDDanhMucChungTu,
                        MdiParent = mdiParent
                    };
                    frm_ctPhieuDoNhienLieu.Show();
                    break;
            }

        }
        public static void runBaoCao(String IDDanhMucBaoCao, Form MDIParent)
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenBaoCao(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucBaoCao, out bool Xem);
            if (!Xem)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xem báo cáo này!");
                return;
            }
            DanhMucBaoCaoBUS BUS = new DanhMucBaoCaoBUS();
            //string MaDanhMucBaoCao = BUS.GetMaByID(IDDanhMucBaoCao);
            ////Lấy tên procedure
            //ConnectionDAO connectionDAO = new ConnectionDAO();
            //SqlParameter[] sqlParameters = new SqlParameter[1];
            //sqlParameters[0] = new SqlParameter("@ID", IDDanhMucBaoCao);
            //DataSet dsBaoCao = connectionDAO.dsList(sqlParameters, "List_DanhMucBaoCao");
            //sqlParameters = new SqlParameter[1];
            //sqlParameters[0] = new SqlParameter("@IDDanhMucBaoCao", IDDanhMucBaoCao);
            //DataTable dtBaoCaoCot = connectionDAO.tableList(sqlParameters, "List_DanhMucBaoCaoCot", "DanhMucBaoCaoCot");
            //switch (MaDanhMucBaoCao)
            //{
            //    case cenCommon.LoaiBaoCao.BC_DOANHTHU_KD:
            //        frmReportParameters_KhachHang_Sale frmReportParameters_KhachHang_Sale = new frmReportParameters_KhachHang_Sale();
            //        frmReportParameters_KhachHang_Sale.ShowDialog();
            //        if (frmReportParameters_KhachHang_Sale.OK)
            //        {
            //            DataTable dt = Reports.rep_BC_DOANHTHU_KD(frmReportParameters_KhachHang_Sale.dTuNgay, frmReportParameters_KhachHang_Sale.dDenNgay, frmReportParameters_KhachHang_Sale.IDDanhMucKhachHang, frmReportParameters_KhachHang_Sale.IDDanhMucSale);
            //            frmReportViewer frmReportViewer = new frmReportViewer();
            //            frmReportViewer.MaDanhMucBaoCao = MaDanhMucBaoCao;
            //            frmReportViewer.MDIParent = MDIParent;
            //            frmReportViewer.dtData = dt;
            //            frmReportViewer.dtCauTrucCot = dtBaoCaoCot;
            //            frmReportViewer.TenFileExcel = dsBaoCao.Tables[0].Rows[0]["FileExcelMau"].ToString();
            //            frmReportViewer.TenSheetExcel = dsBaoCao.Tables[0].Rows[0]["SheetExcelMau"].ToString();
            //            frmReportViewer.SoDongBatDau = (coreCommon.coreCommon.IsNull(dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"])) ? 1 : (int)dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"];
            //            frmReportViewer.Text = MaDanhMucBaoCao;
            //            frmReportViewer.dTuNgay = frmReportParameters_KhachHang_Sale.dTuNgay;
            //            frmReportViewer.dDenNgay = frmReportParameters_KhachHang_Sale.dDenNgay;
            //            frmReportViewer.IDDanhMucKhachHang = frmReportParameters_KhachHang_Sale.IDDanhMucKhachHang;
            //            frmReportViewer.IDDanhMucSale = frmReportParameters_KhachHang_Sale.IDDanhMucSale;
            //            frmReportViewer.ChuoiThamSoHienThiGrid = frmReportParameters_KhachHang_Sale.ChuoiThamSoHienThiGrid;
            //            frmReportViewer.Show();
            //        }
            //        break;
            //    case cenCommon.LoaiBaoCao.BC_DOANHTHU_KD_CNKH:
            //        frmReportParameters_KhachHang_Sale frmReportParameters_KhachHang_Sale1 = new frmReportParameters_KhachHang_Sale();
            //        frmReportParameters_KhachHang_Sale1.ShowDialog();
            //        if (frmReportParameters_KhachHang_Sale1.OK)
            //        {
            //            DataTable dt = Reports.rep_BC_DOANHTHU_KD_CNKH(frmReportParameters_KhachHang_Sale1.dTuNgay, frmReportParameters_KhachHang_Sale1.dDenNgay, frmReportParameters_KhachHang_Sale1.IDDanhMucKhachHang, frmReportParameters_KhachHang_Sale1.IDDanhMucSale);
            //            frmReportViewer frmReportViewer = new frmReportViewer();
            //            frmReportViewer.MaDanhMucBaoCao = MaDanhMucBaoCao;
            //            frmReportViewer.MDIParent = MDIParent;
            //            frmReportViewer.dtData = dt;
            //            frmReportViewer.dtCauTrucCot = dtBaoCaoCot;
            //            frmReportViewer.TenFileExcel = dsBaoCao.Tables[0].Rows[0]["FileExcelMau"].ToString();
            //            frmReportViewer.TenSheetExcel = dsBaoCao.Tables[0].Rows[0]["SheetExcelMau"].ToString();
            //            frmReportViewer.SoDongBatDau = (coreCommon.coreCommon.IsNull(dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"])) ? 1 : (int)dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"];
            //            frmReportViewer.Text = MaDanhMucBaoCao;
            //            frmReportViewer.dTuNgay = frmReportParameters_KhachHang_Sale1.dTuNgay;
            //            frmReportViewer.dDenNgay = frmReportParameters_KhachHang_Sale1.dDenNgay;
            //            frmReportViewer.IDDanhMucKhachHang = frmReportParameters_KhachHang_Sale1.IDDanhMucKhachHang;
            //            frmReportViewer.IDDanhMucSale = frmReportParameters_KhachHang_Sale1.IDDanhMucSale;
            //            frmReportViewer.ChuoiThamSoHienThiGrid = frmReportParameters_KhachHang_Sale1.ChuoiThamSoHienThiGrid;
            //            frmReportViewer.Show();
            //        }
            //        break;
            //    case cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI:
            //        frmReportParameters_NhomHang_Sale frmReportParameters_NhomHang_Sale = new frmReportParameters_NhomHang_Sale();
            //        frmReportParameters_NhomHang_Sale.ShowDialog();
            //        if (frmReportParameters_NhomHang_Sale.OK)
            //        {
            //            DataTable dt = Reports.rep_BC_CHI_PHI_VAN_TAI(frmReportParameters_NhomHang_Sale.dTuNgay, frmReportParameters_NhomHang_Sale.dDenNgay, frmReportParameters_NhomHang_Sale.IDDanhMucNhomHangVanChuyen, frmReportParameters_NhomHang_Sale.IDDanhMucSale);
            //            frmReportViewer frmReportViewer = new frmReportViewer();
            //            frmReportViewer.MaDanhMucBaoCao = MaDanhMucBaoCao;
            //            frmReportViewer.MDIParent = MDIParent;
            //            frmReportViewer.dtData = dt;
            //            frmReportViewer.dtCauTrucCot = dtBaoCaoCot;
            //            frmReportViewer.TenFileExcel = dsBaoCao.Tables[0].Rows[0]["FileExcelMau"].ToString();
            //            frmReportViewer.TenSheetExcel = dsBaoCao.Tables[0].Rows[0]["SheetExcelMau"].ToString();
            //            frmReportViewer.SoDongBatDau = (coreCommon.coreCommon.IsNull(dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"])) ? 1 : (int)dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"];
            //            frmReportViewer.Text = MaDanhMucBaoCao;
            //            frmReportViewer.dTuNgay = frmReportParameters_NhomHang_Sale.dTuNgay;
            //            frmReportViewer.dDenNgay = frmReportParameters_NhomHang_Sale.dDenNgay;
            //            frmReportViewer.IDDanhMucNhomHangVanChuyen = frmReportParameters_NhomHang_Sale.IDDanhMucNhomHangVanChuyen;
            //            frmReportViewer.IDDanhMucSale = frmReportParameters_NhomHang_Sale.IDDanhMucSale;
            //            frmReportViewer.ChuoiThamSoHienThiGrid = frmReportParameters_NhomHang_Sale.ChuoiThamSoHienThiGrid;
            //            frmReportViewer.Show();
            //        }
            //        break;
            //    case cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI_BO_SUNG:
            //        frmReportParameters_NhomHang_Sale frmReportParameters_NhomHang_Sale1 = new frmReportParameters_NhomHang_Sale();
            //        frmReportParameters_NhomHang_Sale1.ShowDialog();
            //        if (frmReportParameters_NhomHang_Sale1.OK)
            //        {
            //            DataTable dt = Reports.rep_BC_CHI_PHI_VAN_TAI_BO_SUNG(frmReportParameters_NhomHang_Sale1.dTuNgay, frmReportParameters_NhomHang_Sale1.dDenNgay, frmReportParameters_NhomHang_Sale1.IDDanhMucNhomHangVanChuyen, frmReportParameters_NhomHang_Sale1.IDDanhMucSale);
            //            frmReportViewer frmReportViewer = new frmReportViewer();
            //            frmReportViewer.MaDanhMucBaoCao = MaDanhMucBaoCao;
            //            frmReportViewer.MDIParent = MDIParent;
            //            frmReportViewer.dtData = dt;
            //            frmReportViewer.dtCauTrucCot = dtBaoCaoCot;
            //            frmReportViewer.TenFileExcel = dsBaoCao.Tables[0].Rows[0]["FileExcelMau"].ToString();
            //            frmReportViewer.TenSheetExcel = dsBaoCao.Tables[0].Rows[0]["SheetExcelMau"].ToString();
            //            frmReportViewer.SoDongBatDau = (coreCommon.coreCommon.IsNull(dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"])) ? 1 : (int)dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"];
            //            frmReportViewer.Text = MaDanhMucBaoCao;
            //            frmReportViewer.dTuNgay = frmReportParameters_NhomHang_Sale1.dTuNgay;
            //            frmReportViewer.dDenNgay = frmReportParameters_NhomHang_Sale1.dDenNgay;
            //            frmReportViewer.IDDanhMucNhomHangVanChuyen = frmReportParameters_NhomHang_Sale1.IDDanhMucNhomHangVanChuyen;
            //            frmReportViewer.IDDanhMucSale = frmReportParameters_NhomHang_Sale1.IDDanhMucSale;
            //            frmReportViewer.ChuoiThamSoHienThiGrid = frmReportParameters_NhomHang_Sale1.ChuoiThamSoHienThiGrid;
            //            frmReportViewer.Show();
            //        }
            //        break;
            //    case cenCommon.LoaiBaoCao.BC_DOANHTHU_KT:
            //        frmReportParameters_KhachHang_Sale frmReportParameters_KhachHang_Sale2 = new frmReportParameters_KhachHang_Sale();
            //        frmReportParameters_KhachHang_Sale2.ShowDialog();
            //        if (frmReportParameters_KhachHang_Sale2.OK)
            //        {
            //            DataTable dt = Reports.rep_BC_DOANHTHU_KT(frmReportParameters_KhachHang_Sale2.dTuNgay, frmReportParameters_KhachHang_Sale2.dDenNgay, frmReportParameters_KhachHang_Sale2.IDDanhMucKhachHang, frmReportParameters_KhachHang_Sale2.IDDanhMucSale);
            //            frmReportViewer frmReportViewer = new frmReportViewer();
            //            frmReportViewer.MaDanhMucBaoCao = MaDanhMucBaoCao;
            //            frmReportViewer.MDIParent = MDIParent;
            //            frmReportViewer.dtData = dt;
            //            frmReportViewer.dtCauTrucCot = dtBaoCaoCot;
            //            frmReportViewer.TenFileExcel = dsBaoCao.Tables[0].Rows[0]["FileExcelMau"].ToString();
            //            frmReportViewer.TenSheetExcel = dsBaoCao.Tables[0].Rows[0]["SheetExcelMau"].ToString();
            //            frmReportViewer.SoDongBatDau = (coreCommon.coreCommon.IsNull(dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"])) ? 1 : (int)dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"];
            //            frmReportViewer.Text = MaDanhMucBaoCao;
            //            frmReportViewer.dTuNgay = frmReportParameters_KhachHang_Sale2.dTuNgay;
            //            frmReportViewer.dDenNgay = frmReportParameters_KhachHang_Sale2.dDenNgay;
            //            frmReportViewer.IDDanhMucKhachHang = frmReportParameters_KhachHang_Sale2.IDDanhMucKhachHang;
            //            frmReportViewer.IDDanhMucSale = frmReportParameters_KhachHang_Sale2.IDDanhMucSale;
            //            frmReportViewer.ChuoiThamSoHienThiGrid = frmReportParameters_KhachHang_Sale2.ChuoiThamSoHienThiGrid;
            //            frmReportViewer.Show();
            //        }
            //        break;
            //    case cenCommon.LoaiBaoCao.BC_LOINHUAN_KD:
            //        frmReportParameters_KhachHang_Sale frmReportParameters_KhachHang_Sale3 = new frmReportParameters_KhachHang_Sale();
            //        frmReportParameters_KhachHang_Sale3.ShowDialog();
            //        if (frmReportParameters_KhachHang_Sale3.OK)
            //        {
            //            DataSet ds = Reports.rep_BC_LOINHUAN_KD(frmReportParameters_KhachHang_Sale3.dTuNgay, frmReportParameters_KhachHang_Sale3.dDenNgay, frmReportParameters_KhachHang_Sale3.IDDanhMucKhachHang, frmReportParameters_KhachHang_Sale3.IDDanhMucSale);
            //            frmReportViewer frmReportViewer = new frmReportViewer();
            //            frmReportViewer.MaDanhMucBaoCao = MaDanhMucBaoCao;
            //            frmReportViewer.MDIParent = MDIParent;
            //            frmReportViewer.dtData = ds.Tables[0];
            //            frmReportViewer.dsData = ds;
            //            frmReportViewer.dtCauTrucCot = dtBaoCaoCot;
            //            frmReportViewer.TenFileExcel = dsBaoCao.Tables[0].Rows[0]["FileExcelMau"].ToString();
            //            frmReportViewer.TenSheetExcel = dsBaoCao.Tables[0].Rows[0]["SheetExcelMau"].ToString();
            //            frmReportViewer.SoDongBatDau = (coreCommon.coreCommon.IsNull(dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"])) ? 1 : (int)dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"];
            //            frmReportViewer.Text = MaDanhMucBaoCao;
            //            frmReportViewer.dTuNgay = frmReportParameters_KhachHang_Sale3.dTuNgay;
            //            frmReportViewer.dDenNgay = frmReportParameters_KhachHang_Sale3.dDenNgay;
            //            frmReportViewer.IDDanhMucKhachHang = frmReportParameters_KhachHang_Sale3.IDDanhMucKhachHang;
            //            frmReportViewer.IDDanhMucSale = frmReportParameters_KhachHang_Sale3.IDDanhMucSale;
            //            frmReportViewer.ChuoiThamSoHienThiGrid = frmReportParameters_KhachHang_Sale3.ChuoiThamSoHienThiGrid;
            //            frmReportViewer.Show();
            //        }
            //        break;
            //    case cenCommon.LoaiBaoCao.BC_SUACHUA:
            //        frmReportParameters_Xe frmReportParameters_Xe = new frmReportParameters_Xe();
            //        frmReportParameters_Xe.ShowDialog();
            //        if (frmReportParameters_Xe.OK)
            //        {
            //            DataTable dt = Reports.rep_BC_SUACHUA(frmReportParameters_Xe.dTuNgay, frmReportParameters_Xe.dDenNgay, frmReportParameters_Xe.IDDanhMucXe);
            //            frmReportViewer frmReportViewer = new frmReportViewer();
            //            frmReportViewer.MaDanhMucBaoCao = MaDanhMucBaoCao;
            //            frmReportViewer.MDIParent = MDIParent;
            //            frmReportViewer.dtData = dt;
            //            frmReportViewer.dtCauTrucCot = dtBaoCaoCot;
            //            frmReportViewer.TenFileExcel = dsBaoCao.Tables[0].Rows[0]["FileExcelMau"].ToString();
            //            frmReportViewer.TenSheetExcel = dsBaoCao.Tables[0].Rows[0]["SheetExcelMau"].ToString();
            //            frmReportViewer.SoDongBatDau = (coreCommon.coreCommon.IsNull(dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"])) ? 1 : (int)dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"];
            //            frmReportViewer.Text = MaDanhMucBaoCao;
            //            frmReportViewer.dTuNgay = frmReportParameters_Xe.dTuNgay;
            //            frmReportViewer.dDenNgay = frmReportParameters_Xe.dDenNgay;
            //            frmReportViewer.IDDanhMucXe = frmReportParameters_Xe.IDDanhMucXe;
            //            frmReportViewer.ChuoiThamSoHienThiGrid = frmReportParameters_Xe.ChuoiThamSoHienThiGrid;
            //            frmReportViewer.Show();
            //        }
            //        break;
            //    case cenCommon.LoaiBaoCao.BC_TU_QT:
            //        frmReportParameters_KhachHang frmReportParameters_KhachHang = new frmReportParameters_KhachHang();
            //        frmReportParameters_KhachHang.ShowDialog();
            //        if (frmReportParameters_KhachHang.OK)
            //        {
            //            DataTable dt = Reports.rep_BC_TU_QT(frmReportParameters_KhachHang.dTuNgay, frmReportParameters_KhachHang.dDenNgay, frmReportParameters_KhachHang.IDDanhMucKhachHang);
            //            frmReportViewer frmReportViewer = new frmReportViewer();
            //            frmReportViewer.MaDanhMucBaoCao = MaDanhMucBaoCao;
            //            frmReportViewer.MDIParent = MDIParent;
            //            frmReportViewer.dtData = dt;
            //            frmReportViewer.dtCauTrucCot = dtBaoCaoCot;
            //            frmReportViewer.TenFileExcel = dsBaoCao.Tables[0].Rows[0]["FileExcelMau"].ToString();
            //            frmReportViewer.TenSheetExcel = dsBaoCao.Tables[0].Rows[0]["SheetExcelMau"].ToString();
            //            frmReportViewer.SoDongBatDau = (coreCommon.coreCommon.IsNull(dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"])) ? 1 : (int)dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"];
            //            frmReportViewer.Text = MaDanhMucBaoCao;
            //            frmReportViewer.dTuNgay = frmReportParameters_KhachHang.dTuNgay;
            //            frmReportViewer.dDenNgay = frmReportParameters_KhachHang.dDenNgay;
            //            frmReportViewer.IDDanhMucKhachHang = frmReportParameters_KhachHang.IDDanhMucKhachHang;
            //            frmReportViewer.ChuoiThamSoHienThiGrid = frmReportParameters_KhachHang.ChuoiThamSoHienThiGrid;
            //            frmReportViewer.Show();
            //        }
            //        break;
            //    case cenCommon.LoaiBaoCao.BC_TU_TIENDUONG:
            //        frmReportParameters_ChuXe frmReportParameters_ChuXe = new frmReportParameters_ChuXe();
            //        frmReportParameters_ChuXe.ShowDialog();
            //        if (frmReportParameters_ChuXe.OK)
            //        {
            //            DataTable dt = Reports.rep_BC_TU_TIENDUONG(frmReportParameters_ChuXe.dTuNgay, frmReportParameters_ChuXe.dDenNgay, frmReportParameters_ChuXe.IDDanhMucChuXe);
            //            frmReportViewer frmReportViewer = new frmReportViewer();
            //            frmReportViewer.MaDanhMucBaoCao = MaDanhMucBaoCao;
            //            frmReportViewer.MDIParent = MDIParent;
            //            frmReportViewer.dtData = dt;
            //            frmReportViewer.dtCauTrucCot = dtBaoCaoCot;
            //            frmReportViewer.TenFileExcel = dsBaoCao.Tables[0].Rows[0]["FileExcelMau"].ToString();
            //            frmReportViewer.TenSheetExcel = dsBaoCao.Tables[0].Rows[0]["SheetExcelMau"].ToString();
            //            frmReportViewer.SoDongBatDau = (coreCommon.coreCommon.IsNull(dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"])) ? 1 : (int)dsBaoCao.Tables[0].Rows[0]["SoDongBatDau"];
            //            frmReportViewer.Text = MaDanhMucBaoCao;
            //            frmReportViewer.dTuNgay = frmReportParameters_ChuXe.dTuNgay;
            //            frmReportViewer.dDenNgay = frmReportParameters_ChuXe.dDenNgay;
            //            frmReportViewer.IDDanhMucChuXe = frmReportParameters_ChuXe.IDDanhMucChuXe;
            //            frmReportViewer.ChuoiThamSoHienThiGrid = frmReportParameters_ChuXe.ChuoiThamSoHienThiGrid;
            //            frmReportViewer.Show();
            //        }
            //        break;
            //}
        }
    }
}
