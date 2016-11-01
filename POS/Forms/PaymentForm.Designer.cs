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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblFontSize = new DevExpress.XtraEditors.LabelControl();
            this.tbFontSize = new DevExpress.XtraEditors.TrackBarControl();
            this.deTo = new DevExpress.XtraEditors.DateEdit();
            this.deFrom = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize.Properties)).BeginInit();
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
            this.gvPayment.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvPayment.Appearance.FocusedCell.Options.UseFont = true;
            this.gvPayment.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvPayment.Appearance.FocusedRow.Options.UseFont = true;
            this.gvPayment.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvPayment.Appearance.FooterPanel.Options.UseFont = true;
            this.gvPayment.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvPayment.Appearance.GroupButton.Options.UseFont = true;
            this.gvPayment.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvPayment.Appearance.GroupFooter.Options.UseFont = true;
            this.gvPayment.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvPayment.Appearance.GroupPanel.Options.UseFont = true;
            this.gvPayment.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvPayment.Appearance.GroupRow.Options.UseFont = true;
            this.gvPayment.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvPayment.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPayment.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvPayment.Appearance.Row.Options.UseFont = true;
            this.gvPayment.GridControl = this.gcPayment;
            this.gvPayment.Name = "gvPayment";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.labelControl2);
            this.pnlSearch.Controls.Add(this.labelControl1);
            this.pnlSearch.Controls.Add(this.lblFontSize);
            this.pnlSearch.Controls.Add(this.tbFontSize);
            this.pnlSearch.Controls.Add(this.deTo);
            this.pnlSearch.Controls.Add(this.deFrom);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(997, 94);
            this.pnlSearch.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
            this.labelControl2.Location = new System.Drawing.Point(240, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "До дата";
            // 
            // labelControl1
            // 
            this.labelControl1.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(119, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "От дата:";
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
            this.tbFontSize.Location = new System.Drawing.Point(12, 22);
            this.tbFontSize.Name = "tbFontSize";
            this.tbFontSize.Properties.ShowValueToolTip = true;
            this.tbFontSize.Properties.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbFontSize.Size = new System.Drawing.Size(87, 42);
            this.tbFontSize.TabIndex = 2;
            // 
            // deTo
            // 
            this.deTo.EditValue = null;
            this.deTo.Location = new System.Drawing.Point(240, 31);
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
            this.deFrom.Location = new System.Drawing.Point(119, 31);
            this.deFrom.Name = "deFrom";
            this.deFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFrom.Size = new System.Drawing.Size(100, 20);
            this.deFrom.TabIndex = 0;
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
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).EndInit();
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
        private DevExpress.XtraEditors.TrackBarControl tbFontSize;
        private DevExpress.XtraEditors.LabelControl lblFontSize;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}