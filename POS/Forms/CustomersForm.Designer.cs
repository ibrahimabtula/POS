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
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCustomers
            // 
            this.gcCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCustomers.Location = new System.Drawing.Point(0, 0);
            this.gcCustomers.MainView = this.gvCustomers;
            this.gcCustomers.Name = "gcCustomers";
            this.gcCustomers.Size = new System.Drawing.Size(997, 581);
            this.gcCustomers.TabIndex = 0;
            this.gcCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomers});
            // 
            // gvCustomers
            // 
            this.gvCustomers.GridControl = this.gcCustomers;
            this.gvCustomers.Name = "gvCustomers";
            // 
            // CustomersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 581);
            this.Controls.Add(this.gcCustomers);
            this.Name = "CustomersForm";
            this.Text = "Клиенти";
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private POSGridControl gcCustomers;
        private POSGridView gvCustomers;

    }
}