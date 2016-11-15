using DevExpress.XtraEditors;
using POS.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var appContext = new POSAppContext(new MainRibbonForm());
                Application.Run(appContext);
            }
            catch (POSNoConnectionException)
            {
                XtraMessageBox.Show("Няма връзка с базата данни", "POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception e)
            {
                XtraMessageBox.Show(e.Message);
            }
        }
    }
}
