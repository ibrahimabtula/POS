
using System.Globalization;
using System.Windows.Forms;

namespace POS
{
    public class POSAppContext : ApplicationContext
    {
        private static MainRibbonForm _mainRibbonForm = null;
        public POSAppContext(MainRibbonForm frm)
        {
             MainForm = frm;
            _mainRibbonForm = frm;
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("bg-BG");
        }
        public static MainRibbonForm RibbonForm
        {
            get { return _mainRibbonForm; }
        }
    }
}
