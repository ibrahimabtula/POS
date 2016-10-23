using DevExpress.XtraEditors;

namespace POS
{
    public partial class BaseForm : XtraForm
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public virtual void Save()
        {
        }

        public virtual void Search()
        {
        }

        public virtual bool IsUnique()
        {
            return false;
        }

        public virtual string UniqueID
        {
            get { return ""; }
        }

        public new void Show()
        {
            if (IsUnique())
            {
                foreach (BaseForm frm in POSAppContext.RibbonForm.MdiChildren)
                {
                    if (frm != this && frm.UniqueID == this.UniqueID)
                    {
                        frm.Activate();
                        this.MdiParent = null;
                        break;
                    }
                    else
                    {
                        base.Show();
                    }
                }
            }
            else
            {
                base.Show();
            }
        }
    }
}
