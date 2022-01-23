using cenBUS.cenLogistics;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctKeHoachVanTai : coreBase.BaseForms.frmBaseChungTuSingleList
    {
        DataSet dsKeHoachVanTai;
        BindingSource bsTotal;
        public frm_ctKeHoachVanTai()
        {
            InitializeComponent();
            txtTuNgay.DateTime = DateTime.Now;
            txtDenNgay.DateTime = DateTime.Now;
        }
        protected override void List()
        {
            ctKeHoachVanTaiBUS bus = new ctKeHoachVanTaiBUS();
            dsKeHoachVanTai = bus.List(txtTuNgay.Value, txtTuNgay.Value);
            bsData = new BindingSource();
            bsData.DataSource = dsKeHoachVanTai;
            bsData.DataMember = "Detail";

            bsTotal = new BindingSource();
            bsTotal.DataSource = dsKeHoachVanTai;
            bsTotal.DataMember = "Total";

            ug.DisplayLayout.Override.FilterUIType = FilterUIType.Default;
            ug.DataSource = bsData;

            txtTotal.SetDataBinding(bsTotal, "Total", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCont.SetDataBinding(bsTotal, "Cont", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTruck.SetDataBinding(bsTotal, "Truck", true, DataSourceUpdateMode.OnPropertyChanged);

            txtTotal.MaskInput = "-nnnn";
            txtCont.MaskInput = "-nnnn";
            txtTruck.MaskInput = "-nnnn";

            ug.DisplayLayout.Bands[0].Columns["DebitNote"].Width = 150;
            ug.DisplayLayout.Bands[0].Columns["ChuXe"].Width = 80;
            ug.DisplayLayout.Bands[0].Columns["SoXe"].Width = 80;
            ug.DisplayLayout.Bands[0].Columns["HangHoa"].Width = 50;
            ug.DisplayLayout.Bands[0].Columns["Tuyen"].Width = 150;
            ug.DisplayLayout.Bands[0].Columns["TenDanhMucDiaDiemLayContHang"].Width = 150;
            ug.DisplayLayout.Bands[0].Columns["TenDanhMucDiaDiemTraContHang"].Width = 150;
            ug.DisplayLayout.Bands[0].Columns["TenDanhMucHangTau"].Width = 100;
            ug.DisplayLayout.Bands[0].Columns["TrangThaiDonHang"].Width = 60;
            ug.DisplayLayout.Bands[0].Columns["GioDongTraHang"].Width = 50;
            ug.DisplayLayout.Bands[0].Columns["GioThucHien"].Width = 50;
            ug.DisplayLayout.Bands[0].Columns["TenDanhMucHangTau"].Width = 100;

        }
        private void ug_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (!coreCommon.coreCommon.IsNull(e.Row.Cells["ChuXe"].Value) && e.Row.Cells["ChuXe"].Value.ToString().ToUpper().StartsWith("PLJ") && e.Row.Cells["TrangThaiDonHang"].Value.ToString() == "Đơn")
            {
                e.Row.Appearance.BackColor = Color.FromArgb(206, 231, 255);
            }
            if (!coreCommon.coreCommon.IsNull(e.Row.Cells["ChuXe"].Value) && e.Row.Cells["ChuXe"].Value.ToString().ToUpper().StartsWith("PLJ") && e.Row.Cells["TrangThaiDonHang"].Value.ToString() == "Kết hợp")
            {
                e.Row.Appearance.BackColor = Color.FromArgb(131, 192, 255);
            }
            if (!coreCommon.coreCommon.IsNull(e.Row.Cells["ChuXe"].Value) && !e.Row.Cells["ChuXe"].Value.ToString().ToUpper().StartsWith("PLJ") && e.Row.Cells["TrangThaiDonHang"].Value.ToString() == "Kết hợp")
            {
                e.Row.Appearance.BackColor = Color.FromArgb(202, 237, 97);
            }
        }
    }
}
