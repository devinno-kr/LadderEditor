using Devinno.Forms.Dialogs;
using Devinno.PLC.Ladder;
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
    public partial class FormDescription : DvForm
    {
        #region class : Reulst
        public class Result
        {
            public string Title { get; set; }
            public string Version { get; set; }
            public string Description { get; set; }
        }
        #endregion

        #region Constructor
        public FormDescription()
        {
            InitializeComponent();
            btnOK.ButtonClick += (o, s) => DialogResult = DialogResult.OK;
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;

            #region Form Props
            StartPosition = FormStartPosition.CenterParent;
            this.Icon = Tools.IconTool.GetIcon(new Devinno.Forms.Icons.DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion
        }
        #endregion

        #region Method
        #region LangSet
        void LangSet()
        {
            if (Program.DataMgr.Language == Managers.Lang.KO)
            {
                Title = "프로젝트 정보";
                dvLabel1.Text = "제목";
                dvLabel3.Text = "버전";
                dvLabel2.Text = "설명";
                btnOK.Text = "확인";
                btnCancel.Text = "취소";
            }
            else if (Program.DataMgr.Language == Managers.Lang.EN)
            {
                Title = "Project Information";
                dvLabel1.Text = "Title";
                dvLabel3.Text = "Version";
                dvLabel2.Text = "Description";
                btnOK.Text = "Ok";
                btnCancel.Text = "Cancel";
            }
        }
        #endregion
        #region ShowDescription
        public Result ShowDescription(LadderDocument doc)
        {
            Result ret = null;
            #region Set
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtVersion.Text = "";
            if (doc != null)
            {
                txtTitle.Text = doc.Title;
                txtDescription.Text = doc.Description;
                txtVersion.Text = doc.Version;
            }
            #endregion

            LangSet();
            
            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = new Result()
                {
                    Title = txtTitle.Text,
                    Version = txtVersion.Text,
                    Description = txtDescription.Text,
                };
            }

            return ret;
        }
        #endregion
        #endregion
    }
}
