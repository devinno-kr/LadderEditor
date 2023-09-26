using Devinno.Forms.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LadderEditor.Forms
{
    public partial class FormMDDev : DvForm
    {
        public FormMDDev()
        {
            InitializeComponent();

            btnOK.ButtonClick += (o, s) => DialogResult = DialogResult.OK;
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;
        }

        public string? ShowDevInput()
        {
            string? ret = null;
            if(this.ShowDialog() == DialogResult.OK)
            {
                ret = txt.Text;
            }
            return ret;
        }
    }
}
