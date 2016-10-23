namespace POS
{
    partial class PaymentForm
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
            this.gcPayment = new POS.POSGridControl();
            this.gvPayment = new POS.POSGridView();
            this.pnlSearch = new DevExpress.XtraEditors.PanelControl();
            this.deTo = new DevExpress.XtraEditors.DateEdit();
            this.deFrom = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPayment
            // 
            this.gcPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPayment.Location = new System.Drawing.Point(0, 94);
            this.gcPayment.MainView = this.gvPayment;
            this.gcPayment.Name = "gcPayment";
            this.gcPayment.Size = new System.Drawing.Size(997, 487);
            this.gcPayment.TabIndex = 0;
            this.gcPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPayment});
            // 
            // gvPayment
            // 
            this.gvPayment.GridControl = this.gcPayment;
            this.gvPayment.Name = "gvPayment";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.deTo);
            this.pnlSearch.Controls.Add(this.deFrom);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(997, 94);
            this.pnlSearch.TabIndex = 1;
            // 
            // deTo
            // 
            this.deTo.EditValue = null;
            this.deTo.Location = new System.Drawing.Point(60, 38);
            this.deTo.Name = "deTo";
            this.deTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTo.Size = new System.Drawing.Size(100, 20);
            this.deTo.TabIndex = 1;
            // 
            // deFrom
            // 
            this.deFrom.EditValue = null;
            this.deFrom.Location = new System.Drawing.Point(60, 12);
            this.deFrom.Name = "deFrom";
            this.deFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFrom.Size = new System.Drawing.Size(100, 20);
            this.deFrom.TabIndex = 0;
            this.deFrom.EditValueChanged += new System.EventHandler(this.deFrom_EditValueChanged);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 581);
            this.Controls.Add(this.gcPayment);
            this.Controls.Add(this.pnlSearch);
            this.Name = "PaymentForm";
            this.Text = "Плащания";
            ((System.ComponentModel.ISupportInitialize)(this.gcPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private POSGridControl gcPayment;
        private POSGridView gvPayment;
        private DevExpress.XtraEditors.PanelControl pnlSearch;
        private DevExpress.XtraEditors.DateEdit deTo;
        private DevExpress.XtraEditors.DateEdit deFrom;
    }
}