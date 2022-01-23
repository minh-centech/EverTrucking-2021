using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cenCommonUIapps.cenLogistics.Forms;
namespace cenCommonUIapps
{
    class clsChungTu
    {
    }
    public class clsKeHoachVanTai
    {
        public static void Insert(object LoaiManHinh, object IDDanhMucChungTu, object TuNgay, object DenNgay, string FormCaption, Action InsertToList)
        {
            frm_ctKeHoachVanTaiUpdate frmUpdate = new frm_ctKeHoachVanTaiUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Them,
                Text = "Thêm mới" + " " + FormCaption,
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh,
                TuNgay = TuNgay,
                DenNgay = DenNgay,
                InsertToList = InsertToList
            };
            frmUpdate.Show();
        }
        public static void Update(object LoaiManHinh, object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDChungTu, string FormCaption, Action UpdateToList)
        {
            frm_ctKeHoachVanTaiUpdate frmUpdate = new frm_ctKeHoachVanTaiUpdate
            {
                UpdateMode = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa" + " " + FormCaption,
                ID = IDChungTu,
                IDDanhMucChungTu = IDDanhMucChungTu,
                LoaiManHinh = LoaiManHinh,
                TuNgay = TuNgay,
                DenNgay = DenNgay,
                UpdateToList = UpdateToList
            };
            frmUpdate.Show();
        }
    }
}
