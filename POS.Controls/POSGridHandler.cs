using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace POS
{
    public class POSGridHandler : DevExpress.XtraGrid.Views.Grid.Handler.GridHandler
    {
        public POSGridHandler(GridView gridView) : base(gridView) { }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyData == Keys.Delete && View.State == GridState.Normal)
                View.DeleteRow(View.FocusedRowHandle);
        }
    }
}
