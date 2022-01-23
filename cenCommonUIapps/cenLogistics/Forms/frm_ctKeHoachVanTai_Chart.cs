using cenBUS.cenLogistics;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctKeHoachVanTai_Chart : Form
    {
        DataSet dsKeHoachVanTai;
        BindingSource bsTotal, bsData;
        static double dCont = 0, dTruck = 0;
        public frm_ctKeHoachVanTai_Chart()
        {
            InitializeComponent();
            txtTuNgay.DateTime = DateTime.Now;
            txtDenNgay.DateTime = DateTime.Now;
        }
        private void List()
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

            dCont = double.Parse(dsKeHoachVanTai.Tables["Total"].Rows[0]["Cont"].ToString());
            dTruck = double.Parse(dsKeHoachVanTai.Tables["Total"].Rows[0]["Truck"].ToString());

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

            //ultraPieChart1.SetDataBinding(dsKeHoachVanTai, "Total");
            ultraPieChart1.LabelMemberPath = "Label";
            ultraPieChart1.ValueMemberPath = "Value";
            ultraPieChart1.DataSource = new Data();
        }

        public class DataItem
        {
            public string Label { get; set; }
            public double Value { get; set; }
        }
        public class Data : ObservableCollection<DataItem>
        {
            public Data()
            {
                Add(new DataItem { Label = "Cont", Value = dCont });
                Add(new DataItem { Label = "Truck", Value = dTruck });
            }
        }

        private void frm_ctKeHoachVanTai_Chart_Load(object sender, EventArgs e)
        {
            List();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            List();
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
