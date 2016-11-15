using DevExpress.XtraEditors;
using System.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.ComponentModel;

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

        public bool TryShow()
        {
            if (!POSAppContext.RibbonForm.MdiChildren.Any(w => ((BaseForm)w).UniqueID == this.UniqueID))
            {
                this.MdiParent = POSAppContext.RibbonForm;
                base.Show();
                return true;
            } 
            else if (IsUnique())
            {
                foreach (BaseForm frm in POSAppContext.RibbonForm.MdiChildren)
                {
                    if (frm != this && frm.UniqueID == this.UniqueID)
                    {
                        frm.Activate();
                        Visible = false;
                        MdiParent = null;
                        Close();
                        Dispose();                        
                        return false;
                    }
                }
            }
            else
            {
                this.MdiParent = POSAppContext.RibbonForm;
                base.Show();
                return true;
            }

            return false;
        }

        internal void ChangeFont(Font font)
        {
            _changeFont(this, font);
        }

        protected virtual void _changeFont(Control control, Font font)
        {
            if (DesignMode || components == null) return;
            foreach (Control c in control.Controls)
            {
                if (c is POSGridControl)
                {
                    var view = (c as POSGridControl).MainView as POSGridView;
                    view.Appearance.HeaderPanel.Font = font;
                    view.Appearance.FocusedCell.Font = font;
                    view.Appearance.FocusedRow.Font = font;
                    view.Appearance.Row.Font = font;
                    view.Appearance.SelectedRow.Font = font;
                    view.Appearance.TopNewRow.Font = font;
                    view.Appearance.GroupFooter.Font = font;
                    view.Appearance.GroupButton.Font = font;
                    view.Appearance.GroupPanel.Font = font;
                    view.Appearance.GroupRow.Font = font;
                }
                else if(c is LabelControl)
                {
                    (c as LabelControl).Appearance.Font = font;
                }
                else if(c is DateEdit)
                {
                    (c as DateEdit).Font = font;
                }
               /* else if (c is SimpleLabelItem)
                {
                    (c as SimpleLabelItem).AppearanceItemCaption.Font = font;
                }
                else if (c is LayoutControlGroup)
                {
                    (c as LayoutControlGroup).AppearanceGroup.Font = font;
                }*/

                this._changeFont(c, font);
            }
        }

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

            Visible = false;
            MdiParent = null;

            base.Dispose(disposing);
        }
    }
}
