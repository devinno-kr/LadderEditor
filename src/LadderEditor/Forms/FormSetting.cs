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
            #region inLang.ValueChanged
            inLang.ValueChanged += (o, s) =>
            {
                if (inLang.Value) LangSet(Lang.KO);
                else LangSet(Lang.EN);
            };
            #endregion
        }
        #endregion

        #region Method
        #region LangSet
        void LangSet(Lang lang)
        {
            if (lang == Managers.Lang.KO)
            {
                Title = "설정";
                lblTitleAreas.Text = "설정 목록";
                lblPath.Title = "프로젝트 폴더";
                inLang.Title = "언어";
                btnOK.Text = "확인";
                btnCancel.Text = "취소";
            }
            else if (lang == Managers.Lang.EN)
            {
                Title = "Setting";
                lblTitleAreas.Text = "Setting List";
                lblPath.Title = "Project Folder";
                inLang.Title = "Language";
                btnOK.Text = "Ok";
                btnCancel.Text = "Cancel";
            }
        }
        #endregion
        #region ShowSetting
        public Set ShowSetting()
        {
            Set ret = null;

            lblPath.Value = Program.DataMgr.ProjectFolder;
            inLang.Value = Program.DataMgr.Language == Lang.KO;

            LangSet(Program.DataMgr.Language);

            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = new Set
                {
                    ProjectFolder = lblPath.Value,
                    Language = inLang.Value ? Lang.KO : Lang.EN,
                };
            }

            return ret;
        }
        #endregion
        #endregion
    }
}
