using System;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.Handler;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Registrator;

namespace POS
{
    public class POSGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName { get { return "POSGridView"; } }
        public override BaseView CreateView(GridControl grid) { return new POSGridView(grid as GridControl); }
        public override BaseViewInfo CreateViewInfo(BaseView view) { return new POSGridViewInfo(view as POSGridView); }
        public override BaseViewHandler CreateHandler(BaseView view) { return new POSGridHandler(view as POSGridView); }
    }
}
