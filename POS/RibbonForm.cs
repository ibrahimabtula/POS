using POS.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class MainRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainRibbonForm()
        {
            InitializeComponent();

            AddEvents();
            mdiManager.MdiParent = this;
            ribbonStatusBar2.Ribbon = mainRibbonControl;

            //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            ConnectionBuilder.ConnectionString = ConfigurationManager.ConnectionStrings["POSConnectionString"].ConnectionString;
            SQLiteConnectionBuilder.ConnectionString = ConfigurationManager.ConnectionStrings["POSSQLiteConnectionString"].ConnectionString;

            bbiChangeFont.LoadLayout<int>(this.Name, "EditValue");
            repositoryItemTrackBar1.Maximum = 18;
            repositoryItemTrackBar1.Minimum = 8;
        }

        private void AddEvents()
        {
            Load += MainForm_Load;
            FormClosing += MainRibbonForm_FormClosing;
            trlMenu.MouseDoubleClick += trlMenu_MouseDoubleClick;
            bbiSearch.ItemClick += bbiSearch_ItemClick;
            bbiSave.ItemClick += bbiSave_ItemClick;
            repositoryItemTrackBar1.EditValueChanged += RepositoryItemTrackBar1_EditValueChanged;
        }

        private void RemoveEvents()
        {
            Load -= MainForm_Load;
            FormClosing -= MainRibbonForm_FormClosing;
            trlMenu.MouseDoubleClick -= trlMenu_MouseDoubleClick;
            bbiSearch.ItemClick -= bbiSearch_ItemClick;
            bbiSave.ItemClick -= bbiSave_ItemClick;
            repositoryItemTrackBar1.EditValueChanged -= RepositoryItemTrackBar1_EditValueChanged;
        }

        private void MainRibbonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosing -= MainRibbonForm_FormClosing;
            bbiChangeFont.SaveLayout(this.Name, bbiChangeFont.EditValue);
        }

        private void RepositoryItemTrackBar1_EditValueChanged(object sender, EventArgs e)
        {
            foreach (BaseForm frm in this.MdiChildren)
            {
                var tb = sender as DevExpress.XtraEditors.TrackBarControl;
                frm.ChangeFont(new Font(this.Font.FontFamily, tb.Value));
            }
        }

        void trlMenu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Menu menu = (Menu)trlMenu.GetDataRecordByNode(trlMenu.FocusedNode);
            if (menu != null && menu.FormType != null)
            {
                BaseForm form = (BaseForm)Activator.CreateInstance(menu.FormType);                
                form.Text = menu.Name;
                if (form.TryShow())
                {
                    if(bbiChangeFont.EditValue != null)
                        form.ChangeFont(new Font(this.Font.FontFamily, (int)bbiChangeFont.EditValue));
                    form.FormClosed += Form_FormClosed;
                }
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            (sender as Form).FormClosed -= Form_FormClosed;
            //GC.Collect();
        }

        void MainForm_Load(object sender, EventArgs e)
        {        
            ConfigTreeListMenu();
            trlMenu.ExpandAll();
        }

        private void ConfigTreeListMenu()
        {
            var menuColl = new List<Menu>();
            menuColl.Add(new Menu(1,0,"Меню"));
            menuColl.Add(new Menu(2,1,"Клиенти", typeof(CustomersForm)));
            menuColl.Add(new Menu(3, 1, "Плащания", typeof(PaymentForm)));

            trlMenu.OptionsView.ShowHorzLines = false;
            trlMenu.OptionsView.ShowVertLines = false;
            trlMenu.OptionsView.ShowIndicator = false;
            trlMenu.OptionsView.ShowColumns = false;
            trlMenu.OptionsBehavior.AutoPopulateColumns = true;           
            trlMenu.RootValue = 0;
            trlMenu.KeyFieldName = "ID";
            trlMenu.ParentFieldName = "ParentID";
            trlMenu.DataSource = menuColl;

            trlMenu.Columns.Clear();
            var col = trlMenu.Columns.Add();
            col.FieldName = "Name";
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;  
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
                RemoveEvents();
            }
            base.Dispose(disposing);
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (mdiManager.SelectedPage != null && mdiManager.SelectedPage.MdiChild != null)
            {
                var form = mdiManager.SelectedPage.MdiChild as BaseForm;
                form.Save();
            }
        }

        private void bbiSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (mdiManager.SelectedPage != null && mdiManager.SelectedPage.MdiChild != null)
            {
                var form = mdiManager.SelectedPage.MdiChild as BaseForm;
                form.Search();
            }
        }

        class Menu
        {
            public Menu(int ID, int ParentID, string Name, Type FormType = null)
            {
                this.ID = ID;
                this.ParentID = ParentID;
                this.Name = Name;
                this.FormType = FormType;
            }
            public int ID { get; set; }
            public int ParentID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Type FormType { get; set; }
        }
    }
}
