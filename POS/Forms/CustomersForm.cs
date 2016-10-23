using POS.Library;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace POS
{
    public partial class CustomersForm : BaseForm
    {
        private BackgroundWorker bwSearch = null;
        private BackgroundWorker bwSave = null;
        private string _title = string.Empty;
        private CustomerCollection _customerCollection = CustomerCollection.NewCustomerCollection();
        private SynchronizationContext _mainSC = null;
        public CustomersForm()
        {
            InitializeComponent();

            Load += CustomersForm_Load;
            _mainSC = SynchronizationContext.Current;
        }

        void CustomersForm_Load(object sender, EventArgs e)
        {
            _title = this.Text;
            AddGridColumns();
            Search();
        }

        private void AddGridColumns()
        {
            gvCustomers.OptionsView.ColumnAutoWidth = false;
            gvCustomers.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gvCustomers.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

            gvCustomers.AddColWithText("FirstName", "Име");
            gvCustomers.AddColWithText("LastName", "Фамилия");
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
                return "CustomersForm";
            }
        }

        public override void Save()
        {
            if (bwSave != null && bwSave.IsBusy) return;
            if(bwSave == null)
            {
                bwSave = new BackgroundWorker();
                bwSave.DoWork += BwSave_DoWork;
                bwSave.RunWorkerCompleted += BwSave_RunWorkerCompleted;
            }

            Cursor = Cursors.WaitCursor;
            bwSave.RunWorkerAsync();            
        }

        private void BwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void BwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            (gvCustomers.DataSource as CustomerCollection).Save();
        }

        public override void Search()
        {
            if (bwSearch != null && bwSearch.IsBusy) return;

            var crite = new CustomerCollection.Criteria();

            if (bwSearch == null)
            {
                bwSearch = new BackgroundWorker();

                bwSearch.DoWork += bw_DoWork;
                bwSearch.RunWorkerCompleted += bw_RunWorkerCompleted;
            }

            Cursor = Cursors.WaitCursor;
            bwSearch.RunWorkerAsync(crite);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (gvCustomers.DataSource != null)
                    (gvCustomers.DataSource as CustomerCollection).ListChanged -= CustomersForm_ListChanged;
                gcCustomers.DataSource = e.Result;
                (gvCustomers.DataSource as CustomerCollection).ListChanged += CustomersForm_ListChanged;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CustomerCollection.GetCustomerCollection(e.Argument as CustomerCollection.Criteria);            
        }

        private void CustomersForm_ListChanged(object sender, ListChangedEventArgs e)
        {
            _mainSC.Post(callback =>
            {
                if ((gvCustomers.DataSource as CustomerCollection).IsDirty)
                    this.Text = _title + "*";
                else
                    this.Text = _title;
            }, 0);
        }

        #endregion
    }
}
