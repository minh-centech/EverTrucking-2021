using coreUI.Forms;
using Infragistics.Win.AppStyling;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace cenBusinessManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StyleManager.Load(Application.StartupPath + "\\Office2007Blue.isl");
            coreCommon.GlobalVariables.SolutionName = "Phần mềm quản lý vận tải everTRUCKING";
            //Khai báo làm tròn
            coreCommon.GlobalVariables.LamTronSoLuong = 2;
            coreCommon.GlobalVariables.LamTronKhoiLuong = 2;
            coreCommon.GlobalVariables.LamTronDonGia = 2;
            coreCommon.GlobalVariables.LamTronDonGiaNgoaiTe = 2;
            coreCommon.GlobalVariables.LamTronDonGiaNgoaiTe = 2;

            frmMain frmMain = new frmMain();
            frmMain.runCustomMenu = new Action(() => { runCustomMenu(frmMain.LoaiChucNang, frmMain.TenChucNang, frmMain.FormCaption, frmMain); });

            frmMain.listLoaiManHinh = new List<string[]>();
            frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDKeHoachVanTai, cenCommon.LoaiManHinh.NameKeHoachVanTai });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDXeRa, cenCommon.LoaiManHinh.NameXeRa });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauKeHoachKhaiThac, cenCommon.LoaiManHinh.NameHangNhapKhauKeHoachKhaiThac });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauContainerVaoKho, cenCommon.LoaiManHinh.NameHangNhapKhauContainerVaoKho });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauKhaiThac, cenCommon.LoaiManHinh.NameHangNhapKhauKhaiThac });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauPalletID, cenCommon.LoaiManHinh.NameHangNhapKhauPalletID });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauPhieuKiemHoa, cenCommon.LoaiManHinh.NameHangNhapKhauPhieuKiemHoa });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauYeuCauGiaoHang, cenCommon.LoaiManHinh.NameHangNhapKhauYeuCauGiaoHang });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauLenhGiaoHang, cenCommon.LoaiManHinh.NameHangNhapKhauLenhGiaoHang });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauPhieuDoanhThu, cenCommon.LoaiManHinh.NameHangNhapKhauPhieuDoanhThu });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauPhieuThuHoDaiLy, cenCommon.LoaiManHinh.NameHangNhapKhauPhieuThuHoDaiLy });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauPhieuXuat, cenCommon.LoaiManHinh.NameHangNhapKhauPhieuXuat });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauContainerRaKho, cenCommon.LoaiManHinh.NameHangNhapKhauContainerRaKho });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauKeHoachKhaiThac, cenCommon.LoaiManHinh.NameHangXuatKhauKeHoachKhaiThac });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauPalletID, cenCommon.LoaiManHinh.NameHangXuatKhauPalletID });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauToKhai, cenCommon.LoaiManHinh.NameHangXuatKhauToKhai });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauKhaiThac, cenCommon.LoaiManHinh.NameHangXuatKhauKhaiThac });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauPhieuDoanhThu, cenCommon.LoaiManHinh.NameHangXuatKhauPhieuDoanhThu });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauKeHoachDongHang, cenCommon.LoaiManHinh.NameHangXuatKhauKeHoachDongHang });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauContainerVaoKho, cenCommon.LoaiManHinh.NameHangXuatKhauContainerVaoKho });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauDongHang, cenCommon.LoaiManHinh.NameHangXuatKhauDongHang });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauXuatKho, cenCommon.LoaiManHinh.NameHangXuatKhauXuatKho });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauContainerRaKho, cenCommon.LoaiManHinh.NameHangXuatKhauContainerRaKho });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToanSoDuDauKy, cenCommon.LoaiManHinh.NameChungTuKeToanSoDuDauKy });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToanPhieuThuTienMat, cenCommon.LoaiManHinh.NameChungTuKeToanPhieuThuTienMat });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToanPhieuThuTienGuiNganHang, cenCommon.LoaiManHinh.NameChungTuKeToanPhieuThuTienGuiNganHang });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToanPhieuChiTienMat, cenCommon.LoaiManHinh.NameChungTuKeToanPhieuChiTienMat });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToanPhieuChiTienGuiNganHang, cenCommon.LoaiManHinh.NameChungTuKeToanPhieuChiTienGuiNganHang });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToanDeNghiThanhToanChiPhiHangNhapKhau, cenCommon.LoaiManHinh.NameChungTuKeToanDeNghiThanhToanChiPhiHangNhapKhau });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToanDeNghiThanhToanChiPhiHangXuatKhau, cenCommon.LoaiManHinh.NameChungTuKeToanDeNghiThanhToanChiPhiHangXuatKhau });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToan, cenCommon.LoaiManHinh.NameChungTuKeToan });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToanPhieuChiPhiHangNhapKhau, cenCommon.LoaiManHinh.NameChungTuKeToanPhieuChiPhiHangNhapKhau });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToanPhieuChiPhiHangXuatKhau, cenCommon.LoaiManHinh.NameChungTuKeToanPhieuChiPhiHangXuatKhau });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDctChungTuKeToanPhanBoChiPhi, cenCommon.LoaiManHinh.NameChungTuKeToanPhanBoChiPhi });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDeimSoDinhDanhHangHoa, cenCommon.LoaiManHinh.NameeimSoDinhDanhHangHoa });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauContainerGetIn, cenCommon.LoaiManHinh.NameHangNhapKhauContainerGetIn });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauContainerRutHang, cenCommon.LoaiManHinh.NameHangNhapKhauContainerRutHang });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauHangKienGetIn, cenCommon.LoaiManHinh.NameHangNhapKhauHangKienGetIn });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauVanDonDuDieuKienQuaKVGS, cenCommon.LoaiManHinh.NameHangNhapKhauVanDonDuDieuKienQuaKVGS });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauHangKienGetOut, cenCommon.LoaiManHinh.NameHangNhapKhauHangKienGetOut });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangNhapKhauContainerGetOut, cenCommon.LoaiManHinh.NameHangNhapKhauContainerGetOut });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDeexHangKienNhapKho, cenCommon.LoaiManHinh.NameeexHangKienNhapKho });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDeexContainerNhapKho, cenCommon.LoaiManHinh.NameeexContainerNhapKho });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDeexContainerDongHang, cenCommon.LoaiManHinh.NameeexContainerDongHang });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDeexContainerXuatKho, cenCommon.LoaiManHinh.NameeexContainerXuatKho });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauHangKienGetOut, cenCommon.LoaiManHinh.NameHangXuatKhauHangKienGetOut });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangXuatKhauContainerGetOut, cenCommon.LoaiManHinh.NameHangXuatKhauContainerGetOut });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDToKhaiGetIn, cenCommon.LoaiManHinh.NameToKhaiGetIn });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDToKhaiDuDieuKienQuaKVGS, cenCommon.LoaiManHinh.NameToKhaiDuDieuKienQuaKVGS });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDToKhaiGetOut, cenCommon.LoaiManHinh.NameToKhaiGetOut });

            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDSuaThongTinGetIn, cenCommon.LoaiManHinh.NameSuaThongTinGetIn });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDContainerHuyThongTinGetIn, cenCommon.LoaiManHinh.NameContainerHuyThongTinGetIn });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDHangKienHuyThongTinGetIn, cenCommon.LoaiManHinh.NameHangKienHuyThongTinGetIn });
            //frmMain.listLoaiManHinh.Add(new string[2] { cenCommon.LoaiManHinh.IDThongTinChuKyDienTu, cenCommon.LoaiManHinh.NameThongTinChuKyDienTu });

            frmDesktop.runCustomMenu = new Action(() => { runCustomMenu(frmDesktop.LoaiChucNang, frmDesktop.TenChucNang, frmDesktop.FormCaption, frmMain); });
            Application.Run(frmMain);
        }
        static void runCustomMenu(string menuKey, string menuName, string FormCaption, Form MDIParent)
        {
            if (menuKey.StartsWith("_DDM_"))
            {
                String IDDanhMucLoaiDoiTuong = menuName.Substring(0, menuName.IndexOf("ID:"));
                cenCommonUIapps.cenCommonUIapps.runDanhMuc(FormCaption, IDDanhMucLoaiDoiTuong, MDIParent);
            }
            else if (menuKey.StartsWith("_SYS_"))
            {
                String IDDanhMucLoaiDoiTuong = menuName.Substring(0);
                cenCommonUIapps.cenCommonUIapps.runDanhMuc(FormCaption, IDDanhMucLoaiDoiTuong, MDIParent);
            }
            else if (menuKey.StartsWith("_DCT_"))
            {
                String IDDanhMucChungTu = menuName.Substring(0, menuName.IndexOf("ID:"));
                String MaDanhMucChungTu = menuName.Substring(menuName.IndexOf("MA:") + "MA:".Length, menuName.IndexOf("LOAIMANHINH:") - menuName.IndexOf("MA:") - "MA:".Length);
                String LoaiManHinh = menuName.Substring(menuName.IndexOf("LOAIMANHINH:") + "LOAIMANHINH:".Length, menuName.Length - menuName.IndexOf("LOAIMANHINH:") - "LOAIMANHINH:".Length);
                cenCommonUIapps.cenCommonUIapps.runChungTu(FormCaption, LoaiManHinh, IDDanhMucChungTu, MDIParent);
            }
            else if (menuKey.StartsWith("_DBC_"))
            {
                String IDDanhMucBaoCao = menuName.Substring(0, menuName.IndexOf("ID:"));
                cenCommonUIapps.cenCommonUIapps.runBaoCao(IDDanhMucBaoCao, MDIParent);
            }
        }
    }
}
