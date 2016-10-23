using DevExpress.XtraBars.Ribbon;
namespace POS
{
    partial class MainRibbonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonStatusBar2 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.dtNow = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSearch = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgCustomer = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpMenu = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.trlMenu = new DevExpress.XtraTreeList.TreeList();
            this.mdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dpMenu.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar2
            // 
            this.ribbonStatusBar2.Location = new System.Drawing.Point(0, 565);
            this.ribbonStatusBar2.Name = "ribbonStatusBar2";
            this.ribbonStatusBar2.Ribbon = null;
            this.ribbonStatusBar2.Size = new System.Drawing.Size(1199, 20);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, -20);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.mainRibbonControl;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(0, 20);
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ApplicationButtonText = null;
            // 
            // 
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.ExpandCollapseItem.Name = "";
            this.mainRibbonControl.ExpandCollapseItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.dtNow,
            this.barButtonItem1,
            this.barButtonItem2,
            this.bbiSearch,
            this.bbiSave});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 14;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.mainRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.mainRibbonControl.SelectedPage = this.ribbonPage1;
            this.mainRibbonControl.Size = new System.Drawing.Size(1199, 144);
            this.mainRibbonControl.StatusBar = this.ribbonStatusBar1;
            // 
            // dtNow
            // 
            this.dtNow.Edit = this.repositoryItemDateEdit1;
            this.dtNow.Id = 3;
            this.dtNow.Name = "dtNow";
            this.dtNow.Width = 100;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 8;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // bbiSearch
            // 
            this.bbiSearch.Caption = "Търси";
            this.bbiSearch.Id = 12;
            this.bbiSearch.LargeGlyph = global::POS.Properties.Resources.search32x32;
            this.bbiSearch.Name = "bbiSearch";
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Запиши";
            this.bbiSave.Id = 13;
            this.bbiSave.LargeGlyph = global::POS.Properties.Resources.save32x32;
            this.bbiSave.Name = "bbiSave";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgCustomer,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // rpgCustomer
            // 
            this.rpgCustomer.ItemLinks.Add(this.bbiSearch, "F");
            this.rpgCustomer.KeyTip = "Q";
            this.rpgCustomer.Name = "rpgCustomer";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroup1.KeyTip = "A";
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpMenu});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dpMenu
            // 
            this.dpMenu.Controls.Add(this.dockPanel1_Container);
            this.dpMenu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpMenu.ID = new System.Guid("e4cfe87e-d150-4afb-8428-8aa4ad5ad203");
            this.dpMenu.Location = new System.Drawing.Point(0, 144);
            this.dpMenu.Name = "dpMenu";
            this.dpMenu.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpMenu.Size = new System.Drawing.Size(200, 421);
            this.dpMenu.Text = "Menu";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.trlMenu);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(194, 393);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // trlMenu
            // 
            this.trlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlMenu.Location = new System.Drawing.Point(0, 0);
            this.trlMenu.Name = "trlMenu";
            this.trlMenu.Size = new System.Drawing.Size(194, 393);
            this.trlMenu.TabIndex = 0;
            // 
            // mdiManager
            // 
            this.mdiManager.MdiParent = this;
            // 
            // MainRibbonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 585);
            this.Controls.Add(this.dpMenu);
            this.Controls.Add(this.ribbonStatusBar2);
            this.Controls.Add(this.mainRibbonControl);
            this.IsMdiContainer = true;
            this.Name = "MainRibbonForm";
            this.Ribbon = this.mainRibbonControl;
            this.StatusBar = this.ribbonStatusBar2;
            this.Text = "POS";
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dpMenu.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RibbonControl ribbonControl1;
        private RibbonStatusBar ribbonStatusBar1;
        private RibbonStatusBar ribbonStatusBar2;
        private RibbonControl mainRibbonControl;
        private RibbonPage ribbonPage1;
        private RibbonPageGroup rpgCustomer;
        private DevExpress.XtraBars.BarEditItem dtNow;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dpMenu;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraTreeList.TreeList trlMenu;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdiManager;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiSearch;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
    }
}

