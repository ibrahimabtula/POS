﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Localization;
using POS.Library;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class PaymentForm : BaseForm
    {
        private BackgroundWorker bw = null;
        private CustomerCollection _customerCollection = CustomerCollection.NewCustomerCollection();
        private string _text = string.Empty;
        private CustomerCollection customers = null;
        public PaymentForm()
        {
            InitializeComponent();

            Load += PaymentForm_Load;
            FormClosing += PaymentForm_FormClosing;
            gvPayment.CustomDrawGroupRow += GvPayment_CustomDrawGroupRow;
            gvPayment.CustomDrawCell += GvPayment_CustomDrawCell;
            tbFontSize.EditValueChanged += TbFontSize_EditValueChanged;
        }

        private void TbFontSize_EditValueChanged(object sender, EventArgs e)
        {
            var tb = sender as TrackBarControl;
            var family = gvPayment.Appearance.HeaderPanel.Font.FontFamily;
            gvPayment.Appearance.HeaderPanel.Font = new Font(family, tb.Value);
            gvPayment.Appearance.FocusedCell.Font = new Font(family, tb.Value);
            gvPayment.Appearance.FocusedRow.Font = new Font(family, tb.Value);
            gvPayment.Appearance.Row.Font = new Font(family, tb.Value);
            gvPayment.Appearance.SelectedRow.Font = new Font(family, tb.Value);
            gvPayment.Appearance.TopNewRow.Font = new Font(family, tb.Value);
            gvPayment.Appearance.GroupFooter.Font = new Font(family, tb.Value);
            gvPayment.Appearance.GroupButton.Font = new Font(family, tb.Value);
            gvPayment.Appearance.GroupPanel.Font = new Font(family, tb.Value);
            gvPayment.Appearance.GroupRow.Font = new Font(family, tb.Value);

        }

        private void GvPayment_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var row = (Payment)gvPayment.GetRow(e.RowHandle);
            if(row != null)
            {
                if (row.Sum < 0)
                    e.Appearance.BackColor = Color.Salmon;
            }
        }

        void PaymentForm_Load(object sender, EventArgs e)
        {            
            AddGridColumns();            
            _text = this.Text;

            gvPayment.LoadLayout(gcPayment.Name);
            AfterLoadLayout();

            tbFontSize.LoadLayout<int>(this.Name, "EditValue");

            Search();
        }

        private void AfterLoadLayout()
        {
            gvPayment.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Sum", gvPayment.Columns["Sum"], "Общо {0:#####.00 лв}");

            deFrom.EditValue = DateTime.MinValue;
            deFrom.Properties.NullDate = DateTime.MinValue;
            deFrom.Properties.NullText = string.Empty;
            deTo.EditValue = DateTime.Now;
            deTo.Properties.NullDate = DateTime.MinValue;
            deTo.Properties.NullText = string.Empty;

            tbFontSize.Properties.Maximum = 18;
            tbFontSize.Properties.Minimum = 8;
            gvPayment.OptionsView.ColumnAutoWidth = false;
            gvPayment.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gvPayment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gvPayment.OptionsView.ShowGroupedColumns = true;
            gvPayment.GroupFormat = "{1}";
            GridLocalizer.Active = new DevExBulgarianLocalizer();
        }

        private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((gvPayment.DataSource as PaymentCollection).IsDirty)
            {
                var res = XtraMessageBox.Show("Записване на промените?", "POS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    Save();
                else if (res == DialogResult.Cancel)
                    e.Cancel = true;
            }

            gvPayment.SaveLayout(gcPayment.Name);
            tbFontSize.SaveLayout(this.Name, tbFontSize.EditValue);
        }

        private void AddGridColumns()
        {            
            customers = CustomerCollection.GetCustomerCollection();
            var col = gvPayment.AddColWithLookUp("CustomerID", "Клиент",customers, "ID", "FullName");
            (col.ColumnEdit as RepositoryItemLookUpEdit).QueryPopUp += PaymentForm_QueryPopUp;

            var colsum = gvPayment.AddColWithSpin("Sum", "Сума");

            gvPayment.AddColWithDate("PaymentDate", "Дата");
            //gvPayment.AddColWithTime("PaymentDate", "Час");            
        }

        private void GvPayment_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
        }

        private void PaymentForm_QueryPopUp(object sender, CancelEventArgs e)
        {
            /*var res = CustomerCollection.GetCustomerCollection();
            customers.Clear();
            for (int i = 0; i < res.Count; i++)
            {
                customers.Add(res[i]);
            }*/
        }

        #region overrides

        public override bool IsUnique()
        {
            return true;
        }

        public override string UniqueID
        {
            get
            {
                return "PaymentForm";
            }
        }

        public override void Save()
        {
            (gvPayment.DataSource as PaymentCollection).Save();
        }
        
        public override void Search()
        {
            if (bw != null && bw.IsBusy) return;

            var crite = new PaymentCollection.Criteria();
            crite.DateFrom = deFrom.DateTime;
            crite.DateTo = deTo.DateTime;

            if(bw == null)
            {
                bw = new BackgroundWorker();
                bw.DoWork += bw_DoWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            }

            bw.RunWorkerAsync(crite);
            Cursor = Cursors.WaitCursor;
            gcPayment.Enabled = false;
        }

        private void PaymentForm_ListChanged(object sender, ListChangedEventArgs e)
        {
            if ((gvPayment.DataSource as PaymentCollection).IsDirty)
                this.Text = _text + "*";
            else
                this.Text = _text;
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if(gvPayment.DataSource != null)
                    (gvPayment.DataSource as PaymentCollection).ListChanged -= PaymentForm_ListChanged;
                gcPayment.DataSource = e.Result;
                (gvPayment.DataSource as PaymentCollection).ListChanged += PaymentForm_ListChanged;
            }
            finally
            {
                gcPayment.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = PaymentCollection.GetPaymentCollection(e.Argument as PaymentCollection.Criteria);
        }

        #endregion
    }
}
