using Devinno.Forms.Dialogs;
using LadderEditor.Managers;
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
    public partial class FormSetting : DvForm
    {
        #region Constructor
        public FormSetting()
        {
            InitializeComponent();

            btnOK.ButtonClick += (o, s) => DialogResult = DialogResult.OK;
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;

            #region lblPath.ButtonClicked
            lblPath.ButtonClicked += (o, s) =>
            {
                using (var fbd = new FolderBrowserDialog() { })
                {
                    fbd.SelectedPath = Program.DataMgr.ProjectFolder;
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        lblPath.Value = fbd.SelectedPath;
                    }
                }
            };
            #endregion
        }
        #endregion

        #region Method
        #region ShowSetting
        public Set ShowSetting()
        {
            Set ret = null;

            lblPath.Value = Program.DataMgr.ProjectFolder;

            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = new Set
                {
                    ProjectFolder = lblPath.Value,
                };
            }

            return ret;
        }
        #endregion
        #endregion
    }
}
