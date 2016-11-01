using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class POSGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        public POSGridView() : this(null) { }
        public POSGridView(DevExpress.XtraGrid.GridControl grid)
            : base(grid)
        {
            // put your initialization code here
        }
        protected override string ViewName { get { return "POSGridView"; } }

        public void SaveLayout(string name)
        {
            if(Directory.Exists(Environment.CurrentDirectory))
            {
                this.SaveLayoutToXml(Environment.CurrentDirectory + name);
            }
        }

        public void LoadLayout(string name)
        {
            if(File.Exists(Environment.CurrentDirectory + name))
            {
                this.RestoreLayoutFromXml(Environment.CurrentDirectory + name);
            }
        }

        public GridColumn AddColWithLookUp(string field, string caption, object datasource, string valueMember, string displayMember)
        {
            var lookup = new RepositoryItemLookUpEdit();
            lookup.DataSource = datasource;
            lookup.ValueMember = valueMember;
            lookup.DisplayMember = displayMember;
            lookup.NullText = string.Empty;
            lookup.Columns.Clear();
            var lCol = new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember);
            lCol.Visible = true;
            lookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            lookup.Columns.Add(lCol);

            var col = new GridColumn();
            col.ColumnEdit = lookup;
            col.FieldName = field;
            col.Caption = caption;
            col.Name = field;
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Width = 150;
            this.Columns.Add(col);
            return col;
        }

        public GridColumn AddColWithSpin(string field, string caption, string format = "#####.00 лв")
        {
            var spinedit = new RepositoryItemBaseSpinEdit();
            spinedit.Mask.EditMask = format;
            spinedit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            spinedit.Mask.UseMaskAsDisplayFormat = true;

            var col = new GridColumn();
            col.ColumnEdit = spinedit;
            col.FieldName = field;
            col.Caption = caption;
            col.Name = field;
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Width = 150;
            col.DisplayFormat.FormatString = format;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Columns.Add(col);
            return col;
        }

        public GridColumn AddColWithDate(string field, string caption)
        {
            var repitemDate = new RepositoryItemDateEdit();
            repitemDate.NullDate = DateTime.MinValue;
            repitemDate.DisplayFormat.FormatString = "dd:mm:yyyy HH:mm:ss";

            var col = new GridColumn();
            col.ColumnEdit = repitemDate;
            col.FieldName = field;
            col.Caption = caption;
            col.Name = field;
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Width = 150;
            this.Columns.Add(col);
            return col;
        }

        public GridColumn AddColWithTime(string field, string caption)
        {
            var repitemTime = new RepositoryItemTimeEdit();
            repitemTime.NullText = "";
            repitemTime.DisplayFormat.FormatString = "HH:mm:ss";

            var col = new GridColumn();
            col.ColumnEdit = repitemTime;
            col.FieldName = field;
            col.Caption = caption;
            col.Name = field;
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Width = 150;
            this.Columns.Add(col);
            return col;
        }

        public GridColumn AddColWithMemoEx(string field, string caption)
        {
            var repItem = new RepositoryItemMemoExEdit();

            var col = new GridColumn();
            col.ColumnEdit = repItem;
            col.FieldName = field;
            col.Caption = caption;
            col.Name = field;
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Width = 150;
            this.Columns.Add(col);
            return col;
        }

        public GridColumn AddColWithText(string field, string caption)
        {
            var col = new GridColumn();
            col.FieldName = field;
            col.Caption = caption;
            col.Name = field;
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Width = 150;
            this.Columns.Add(col);
            return col;
        }
    }
}
