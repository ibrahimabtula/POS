namespace POS
{
    partial class CustomersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gcCustomers = new POS.POSGridControl();
            this.gvCustomers = new POS.POSGridView();
            this.pnlSearch = new DevExpress.XtraEditors.PanelControl();
            this.lblFontSize = new DevExpress.XtraEditors.LabelControl();
            this.tbFontSize = new DevExpress.XtraEditors.TrackBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCustomers
            // 
            this.gcCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCustomers.Location = new System.Drawing.Point(0, 55);
            this.gcCustomers.MainView = this.gvCustomers;
            this.gcCustomers.Name = "gcCustomers";
            this.gcCustomers.Size = new System.Drawing.Size(997, 526);
            this.gcCustomers.TabIndex = 0;
            this.gcCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomers});
            // 
            // gvCustomers
            // 
            this.gvCustomers.GridControl = this.gcCustomers;
            this.gvCustomers.Name = "gvCustomers";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblFontSize);
            this.pnlSearch.Controls.Add(this.tbFontSize);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(997, 55);
            this.pnlSearch.TabIndex = 2;
            // 
            // lblFontSize
            // 
            this.lblFontSize.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
            this.lblFontSize.Location = new System.Drawing.Point(17, 12);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(86, 13);
            this.lblFontSize.TabIndex = 3;
            this.lblFontSize.Text = "Размер на текст:";
            // 
            // tbFontSize
            // 
            this.tbFontSize.EditValue = null;
            this.tbFontSize.Location = new System.Drawing.Point(16, 13);
            this.tbFontSize.Name = "tbFontSize";
            this.tbFontSize.Properties.ShowValueToolTip = true;
            this.tbFontSize.Properties.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbFontSize.Size = new System.Drawing.Size(87, 42);
            this.tbFontSize.TabIndex = 2;
            // 
            // CustomersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 581);
            this.Controls.Add(this.gcCustomers);
            this.Controls.Add(this.pnlSearch);
            this.Name = "CustomersForm";
            this.Text = "Клиенти";
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private POSGridControl gcCustomers;
        private POSGridView gvCustomers;
        private DevExpress.XtraEditors.PanelControl pnlSearch;
        private DevExpress.XtraEditors.LabelControl lblFontSize;
        private DevExpress.XtraEditors.TrackBarControl tbFontSize;
    }
}