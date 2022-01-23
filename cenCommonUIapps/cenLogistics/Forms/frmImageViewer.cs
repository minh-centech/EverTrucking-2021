using Infragistics.Win.UltraWinListView;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frmImageViewer : Form
    {
        public DataTable dtHinhAnh;
        public object IDChungTuChiTiet;
        public string imgKey;
        public frmImageViewer()
        {
            InitializeComponent();
        }

        private void frmImageViewer_Load(object sender, EventArgs e)
        {
            //Load hình ảnh
            foreach (DataRow drHinhAnh in dtHinhAnh.Rows)
            {
                if (drHinhAnh.RowState != DataRowState.Deleted && drHinhAnh["IDChungTuChiTiet"].ToString() == IDChungTuChiTiet.ToString())
                {
                    Infragistics.Win.UltraWinListView.UltraListViewItem item = new Infragistics.Win.UltraWinListView.UltraListViewItem();
                    Byte[] bHinhAnh = (Byte[])(drHinhAnh["HinhAnh"]);
                    item.Appearance.Image = coreCommon.coreCommon.byteArrayToImage(bHinhAnh);
                    item.Value = drHinhAnh["FileName"].ToString();
                    item.Key = "img" + drHinhAnh["ID"].ToString();
                    ultraListView2.Items.Add(item);
                }
            }
            //Chọn hình ảnh hiện tại
            ultraListView2.Items[imgKey].Activate();
            ultraListView2.PerformAction(UltraListViewAction.SelectItem);
        }

        private void ultraListView2_ItemActivated(object sender, Infragistics.Win.UltraWinListView.ItemActivatedEventArgs e)
        {
            if (e.Item != null)
                ultraPictureBox1.Image = e.Item.Appearance.Image;
        }
    }
}
