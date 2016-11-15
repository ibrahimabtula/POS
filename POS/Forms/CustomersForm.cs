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
        private SynchronizationContext _syncContextUI = null;
        public CustomersForm()
        {
            InitializeComponent();

            Load += CustomersForm_Load;
            gvCustomers.CustomUnboundColumnData += GvCustomers_CustomUnboundColumnData;
            _syncContextUI = SynchronizationContext.Current;
        }

        private void GvCustomers_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            /*
               if(e.Column.FieldName == "Image" && e.IsGetData) {

       GridView view = sender as GridView;



       string colorName = (string)view.GetRowCellValue(e.RowHandle, "Color");

       string fileName = GetFileName(colorName).ToLower();

       if(!Images.ContainsKey(fileName)) {

           Image img = null;

           try {

               string filePath = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, ImageDir + fileName, false);

               img = Image.FromFile(filePath);

           }

           catch {

           }

           Images.Add(fileName, img);

       }

       e.Value = Images[fileName];

   }
            */
        }

        void CustomersForm_Load(object sender, EventArgs e)
        {
            _title = this.Text;
            AddGridColumns();
            Search();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            gvCustomers.OptionsView.ColumnAutoWidth = false;
            gvCustomers.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gvCustomers.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gvCustomers.OptionsView.ShowAutoFilterRow = true;
        }

        private void AddGridColumns()
        {
            gvCustomers.AddCol("FirstName", "Име");
            gvCustomers.AddCol("LastName", "Фамилия");
            gvCustomers.AddColWithMemoEx("Note", "Бележки");
            gvCustomers.AddColWithImage("Image", "Бележки");

            var col = gvCustomers.AddCol("Imageadsa", "");
            col.UnboundType = DevExpress.Data.UnboundColumnType.Object;
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

            var coll = gvCustomers.DataSource as CustomerCollection;
            gcCustomers.DataSource = null;
            Cursor = Cursors.WaitCursor;
            bwSave.RunWorkerAsync(coll);            
        }

        private void BwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            gcCustomers.DataSource = e.Result;
        }

        private void BwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            var coll = (e.Argument as CustomerCollection);            
            coll.ApplyEdit();
            coll.Save();
            e.Result = coll;         
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

        #endregion//Overrides

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
            //e.Result = CustomerCollection.GetCustomerCollectionDapper();           
        }

        private void CustomersForm_ListChanged(object sender, ListChangedEventArgs e)
        {
            _syncContextUI.Post(callback =>
            {
                if ((gvCustomers.DataSource as CustomerCollection).IsDirty)
                    this.Text = _title + "*";
                else
                    this.Text = _title;
            }, 0);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            Load -= CustomersForm_Load;

            if(bwSearch !=null)
            {
                bwSearch.DoWork -= bw_DoWork;
                bwSearch.RunWorkerCompleted -= bw_RunWorkerCompleted;
            }

            if(bwSave != null)
            {
                bwSave.DoWork -= BwSave_DoWork;
                bwSave.RunWorkerCompleted -= BwSave_RunWorkerCompleted;
            }

            gcCustomers.DataSource = null;

            base.Dispose(disposing);
        }        
    }
}
