using cenBUS.cenLogistics;
using coreBUS;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;

namespace cenCommonUIapps.cenLogistics.Forms
{
    public partial class frm_ctDieuHanhChiTietDonHangKetHopUpdate : Form
    {
        public object IDDanhMucChungTu = null, IDChungTu = null, IDChungTuChiTiet = null;
        public Boolean Saved = false, GridValidation = true;
        public DataTable dt;
        BindingSource bs;
        private void frm_ctDieuHanhChiTietDonHangKetHopUpdate_Load(object sender, EventArgs e)
        {
            List();
        }

        private void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key.ToString().ToUpper())
            {
                case "BTOK":
                    UpdateData();
                    this.Close();
                    break;
                case "BTXOADONG":
                    if (ug.ActiveRow == null) return;
                    int i = ug.ActiveRow.Index;
                    ug.ActiveRow.Delete();
                    if (i > 0) i -= 1;
                    if (i <= ug.Rows.Count - 1)
                    {
                        ug.Focus();
                        ug.Rows[i].Activate();
                        ug.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    break;
                case "BTTHEMDONG":
                    GridValidation = false;
                    bs.AddNew();
                    ug.Focus();
                    ug.DisplayLayout.Rows[ug.DisplayLayout.Rows.Count - 1].Activate();
                    foreach (UltraGridColumn ugCol in ug.DisplayLayout.Bands[0].Columns)
                    {
                        if (!ugCol.Hidden)
                        {
                            ug.ActiveCell = ug.ActiveRow.Cells[ugCol.Key];
                            ug.ActiveCell.Activate();
                            break;
                        }
                    }
                    GridValidation = true;
                    break;
            }
        }

        private void frm_ctDieuHanhChiTietDonHangKetHopUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved)
            {
                DialogResult dlg = coreCommon.coreCommon.QuestionMessage("Bạn có muốn lưu lại dữ liệu trước khi thoát?", 1);
                switch (dlg)
                {
                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        Saved = false;
                        dt.RejectChanges();
                        bs.EndEdit();
                        break;
                    case System.Windows.Forms.DialogResult.Yes:
                        bs.EndEdit();
                        UpdateData();
                        if (!Saved) e.Cancel = true;
                        break;
                }
            }
        }

        private void ug_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (!GridValidation) return;
            UltraGridCell uCell = e.Cell;
            if (e.Cell.Column.Key.ToUpper() == "DEBITNOTE")
            {
                GridValidation = false;
                //Valid debit note
                ctDonHangBUS bus = new ctDonHangBUS();
                DataTable dt = bus.ValidDebitNote(DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)), uCell.Value); ;
                if (dt == null) { GridValidation = true; return; }
                if (dt.Rows.Count == 1)
                {
                    uCell.Row.Cells["IDctDonHang"].Value = dt.Rows[0]["ID"].ToString();
                    uCell.Row.Cells["DebitNote"].Value = dt.Rows[0]["DebitNote"].ToString();
                    uCell.Row.Cells["SoDonHang"].Value = dt.Rows[0]["So"].ToString();
                    uCell.Row.Cells["GhiChu"].Value = dt.Rows[0]["GhiChu"].ToString();
                    GridValidation = true;
                    return;
                }
                else
                {
                    //Show valid form
                    frm_ctDonHangValidDebitNote frmctDonHangValid = new frm_ctDonHangValidDebitNote()
                    {
                        IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuDonHang)),
                        validValue = uCell.Row.Cells["DebitNote"].Value,
                        dataTable = dt
                    };
                    frmctDonHangValid.ShowDialog();
                    if (frmctDonHangValid.dataRows == null || frmctDonHangValid.dataRows.Count == 0) { GridValidation = true; return; }
                    if (frmctDonHangValid.dataRows.Count > 0)
                    {
                        uCell.Row.Cells["IDctDonHang"].Value = frmctDonHangValid.dataRows[0]["ID"].ToString();
                        uCell.Row.Cells["DebitNote"].Value = frmctDonHangValid.dataRows[0]["DebitNote"].ToString();
                        uCell.Row.Cells["SoDonHang"].Value = frmctDonHangValid.dataRows[0]["So"].ToString();
                        uCell.Row.Cells["GhiChu"].Value = frmctDonHangValid.dataRows[0]["GhiChu"].ToString();
                    }
                }
                GridValidation = true;
                return;
            }
        }

        public frm_ctDieuHanhChiTietDonHangKetHopUpdate()
        {
            InitializeComponent();
        }
        void List()
        {
            //ctDieuHanhChiTietDonHangKetHopBUS ctDieuHanhChiTietDonHangKetHopBUS = new ctDieuHanhChiTietDonHangKetHopBUS();
            //dt = ctDieuHanhChiTietDonHangKetHopBUS.List(IDDanhMucChungTu, IDChungTu);
            bs = new BindingSource();
            bs.DataSource = dt;
            ug.ReadOnlyColumnsList = "[SoDonHang]";
            ug.DataSource = bs;
            ug.SetEditableState(false);
        }
        void UpdateData()
        {
            ug.UpdateData();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    dr["IDDanhMucChungTu"] = IDDanhMucChungTu;
                    dr["IDChungTu"] = IDChungTu;
                    dr["IDChungTuChiTiet"] = IDChungTuChiTiet;
                }
            }
            Saved = true;
            bs.EndEdit();
        }
    }
}
