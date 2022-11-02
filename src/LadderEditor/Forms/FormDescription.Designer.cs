
namespace LadderEditor.Forms
{
    partial class FormDescription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dvContainer1 = new Devinno.Forms.Containers.DvContainer();
            this.btnOK = new Devinno.Forms.Controls.DvButton();
            this.dvControl1 = new Devinno.Forms.Controls.DvControl();
            this.btnCancel = new Devinno.Forms.Controls.DvButton();
            this.dvContainer2 = new Devinno.Forms.Containers.DvContainer();
            this.txtDescription = new Devinno.Forms.Controls.DvTextBox();
            this.dvLabel2 = new Devinno.Forms.Controls.DvLabel();
            this.dvControl3 = new Devinno.Forms.Controls.DvControl();
            this.txtVersion = new Devinno.Forms.Controls.DvTextBox();
            this.dvLabel3 = new Devinno.Forms.Controls.DvLabel();
            this.dvControl2 = new Devinno.Forms.Controls.DvControl();
            this.txtTitle = new Devinno.Forms.Controls.DvTextBox();
            this.dvLabel1 = new Devinno.Forms.Controls.DvLabel();
            this.dvContainer1.SuspendLayout();
            this.dvContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvContainer1
            // 
            this.dvContainer1.Controls.Add(this.btnOK);
            this.dvContainer1.Controls.Add(this.dvControl1);
            this.dvContainer1.Controls.Add(this.btnCancel);
            this.dvContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvContainer1.Location = new System.Drawing.Point(3, 450);
            this.dvContainer1.Name = "dvContainer1";
            this.dvContainer1.Padding = new System.Windows.Forms.Padding(7, 10, 7, 7);
            this.dvContainer1.ShadowGap = 1;
            this.dvContainer1.Size = new System.Drawing.Size(394, 47);
            this.dvContainer1.TabIndex = 2;
            this.dvContainer1.TabStop = false;
            this.dvContainer1.Text = "dvContainer1";
            // 
            // btnOK
            // 
            this.btnOK.BackgroundDraw = true;
            this.btnOK.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnOK.Clickable = true;
            this.btnOK.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Gradient = true;
            this.btnOK.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnOK.IconGap = 0;
            this.btnOK.IconImage = null;
            this.btnOK.IconSize = 10F;
            this.btnOK.IconString = null;
            this.btnOK.Location = new System.Drawing.Point(197, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Round = null;
            this.btnOK.ShadowGap = 1;
            this.btnOK.Size = new System.Drawing.Size(90, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "확인";
            this.btnOK.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnOK.UseKey = false;
            // 
            // dvControl1
            // 
            this.dvControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dvControl1.Location = new System.Drawing.Point(287, 10);
            this.dvControl1.Name = "dvControl1";
            this.dvControl1.ShadowGap = 1;
            this.dvControl1.Size = new System.Drawing.Size(10, 30);
            this.dvControl1.TabIndex = 1;
            this.dvControl1.TabStop = false;
            this.dvControl1.Text = "dvControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundDraw = true;
            this.btnCancel.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnCancel.Clickable = true;
            this.btnCancel.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Gradient = true;
            this.btnCancel.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnCancel.IconGap = 0;
            this.btnCancel.IconImage = null;
            this.btnCancel.IconSize = 10F;
            this.btnCancel.IconString = null;
            this.btnCancel.Location = new System.Drawing.Point(297, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Round = null;
            this.btnCancel.ShadowGap = 1;
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취소";
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancel.UseKey = false;
            // 
            // dvContainer2
            // 
            this.dvContainer2.Controls.Add(this.txtDescription);
            this.dvContainer2.Controls.Add(this.dvLabel2);
            this.dvContainer2.Controls.Add(this.dvControl3);
            this.dvContainer2.Controls.Add(this.txtVersion);
            this.dvContainer2.Controls.Add(this.dvLabel3);
            this.dvContainer2.Controls.Add(this.dvControl2);
            this.dvContainer2.Controls.Add(this.txtTitle);
            this.dvContainer2.Controls.Add(this.dvLabel1);
            this.dvContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvContainer2.Location = new System.Drawing.Point(3, 40);
            this.dvContainer2.Name = "dvContainer2";
            this.dvContainer2.Padding = new System.Windows.Forms.Padding(7, 10, 7, 0);
            this.dvContainer2.ShadowGap = 1;
            this.dvContainer2.Size = new System.Drawing.Size(394, 410);
            this.dvContainer2.TabIndex = 3;
            this.dvContainer2.TabStop = false;
            this.dvContainer2.Text = "dvContainer2";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderColor = null;
            this.txtDescription.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.InputType = Devinno.Forms.DvTextBoxType.Text;
            this.txtDescription.Location = new System.Drawing.Point(7, 168);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.MinusInput = false;
            this.txtDescription.MultiLine = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Round = null;
            this.txtDescription.ShadowGap = 1;
            this.txtDescription.Size = new System.Drawing.Size(380, 242);
            this.txtDescription.Style = Devinno.Forms.Embossing.FlatConcave;
            this.txtDescription.TabIndex = 4;
            this.txtDescription.TabStop = false;
            this.txtDescription.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtDescription.TextPadding = new System.Windows.Forms.Padding(5);
            this.txtDescription.Unit = "";
            this.txtDescription.UnitWidth = 36;
            // 
            // dvLabel2
            // 
            this.dvLabel2.BackgroundDraw = false;
            this.dvLabel2.BorderColor = null;
            this.dvLabel2.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            this.dvLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvLabel2.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.dvLabel2.IconGap = 5;
            this.dvLabel2.IconImage = null;
            this.dvLabel2.IconSize = 10F;
            this.dvLabel2.IconString = "fa-angle-right";
            this.dvLabel2.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dvLabel2.Location = new System.Drawing.Point(7, 142);
            this.dvLabel2.Name = "dvLabel2";
            this.dvLabel2.Round = null;
            this.dvLabel2.ShadowGap = 1;
            this.dvLabel2.Size = new System.Drawing.Size(380, 26);
            this.dvLabel2.Style = Devinno.Forms.Embossing.FlatConcave;
            this.dvLabel2.TabIndex = 3;
            this.dvLabel2.TabStop = false;
            this.dvLabel2.Text = "설명";
            this.dvLabel2.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.dvLabel2.Unit = "";
            this.dvLabel2.UnitWidth = 36;
            // 
            // dvControl3
            // 
            this.dvControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvControl3.Location = new System.Drawing.Point(7, 132);
            this.dvControl3.Name = "dvControl3";
            this.dvControl3.ShadowGap = 1;
            this.dvControl3.Size = new System.Drawing.Size(380, 10);
            this.dvControl3.TabIndex = 7;
            this.dvControl3.TabStop = false;
            this.dvControl3.Text = "dvControl3";
            // 
            // txtVersion
            // 
            this.txtVersion.BorderColor = null;
            this.txtVersion.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.txtVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtVersion.InputType = Devinno.Forms.DvTextBoxType.Text;
            this.txtVersion.Location = new System.Drawing.Point(7, 102);
            this.txtVersion.MaxLength = 32767;
            this.txtVersion.MinusInput = false;
            this.txtVersion.MultiLine = false;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Round = null;
            this.txtVersion.ShadowGap = 1;
            this.txtVersion.Size = new System.Drawing.Size(380, 30);
            this.txtVersion.Style = Devinno.Forms.Embossing.FlatConcave;
            this.txtVersion.TabIndex = 6;
            this.txtVersion.TabStop = false;
            this.txtVersion.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtVersion.TextPadding = new System.Windows.Forms.Padding(5);
            this.txtVersion.Unit = "";
            this.txtVersion.UnitWidth = 36;
            // 
            // dvLabel3
            // 
            this.dvLabel3.BackgroundDraw = false;
            this.dvLabel3.BorderColor = null;
            this.dvLabel3.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            this.dvLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvLabel3.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.dvLabel3.IconGap = 5;
            this.dvLabel3.IconImage = null;
            this.dvLabel3.IconSize = 10F;
            this.dvLabel3.IconString = "fa-angle-right";
            this.dvLabel3.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dvLabel3.Location = new System.Drawing.Point(7, 76);
            this.dvLabel3.Name = "dvLabel3";
            this.dvLabel3.Round = null;
            this.dvLabel3.ShadowGap = 1;
            this.dvLabel3.Size = new System.Drawing.Size(380, 26);
            this.dvLabel3.Style = Devinno.Forms.Embossing.FlatConcave;
            this.dvLabel3.TabIndex = 5;
            this.dvLabel3.TabStop = false;
            this.dvLabel3.Text = "버전";
            this.dvLabel3.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.dvLabel3.Unit = "";
            this.dvLabel3.UnitWidth = 36;
            // 
            // dvControl2
            // 
            this.dvControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvControl2.Location = new System.Drawing.Point(7, 66);
            this.dvControl2.Name = "dvControl2";
            this.dvControl2.ShadowGap = 1;
            this.dvControl2.Size = new System.Drawing.Size(380, 10);
            this.dvControl2.TabIndex = 2;
            this.dvControl2.TabStop = false;
            this.dvControl2.Text = "dvControl2";
            // 
            // txtTitle
            // 
            this.txtTitle.BorderColor = null;
            this.txtTitle.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitle.InputType = Devinno.Forms.DvTextBoxType.Text;
            this.txtTitle.Location = new System.Drawing.Point(7, 36);
            this.txtTitle.MaxLength = 32767;
            this.txtTitle.MinusInput = false;
            this.txtTitle.MultiLine = false;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Round = null;
            this.txtTitle.ShadowGap = 1;
            this.txtTitle.Size = new System.Drawing.Size(380, 30);
            this.txtTitle.Style = Devinno.Forms.Embossing.FlatConcave;
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TabStop = false;
            this.txtTitle.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtTitle.TextPadding = new System.Windows.Forms.Padding(5);
            this.txtTitle.Unit = "";
            this.txtTitle.UnitWidth = 36;
            // 
            // dvLabel1
            // 
            this.dvLabel1.BackgroundDraw = false;
            this.dvLabel1.BorderColor = null;
            this.dvLabel1.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            this.dvLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvLabel1.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.dvLabel1.IconGap = 5;
            this.dvLabel1.IconImage = null;
            this.dvLabel1.IconSize = 10F;
            this.dvLabel1.IconString = "fa-angle-right";
            this.dvLabel1.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dvLabel1.Location = new System.Drawing.Point(7, 10);
            this.dvLabel1.Name = "dvLabel1";
            this.dvLabel1.Round = null;
            this.dvLabel1.ShadowGap = 1;
            this.dvLabel1.Size = new System.Drawing.Size(380, 26);
            this.dvLabel1.Style = Devinno.Forms.Embossing.FlatConcave;
            this.dvLabel1.TabIndex = 0;
            this.dvLabel1.TabStop = false;
            this.dvLabel1.Text = "제목";
            this.dvLabel1.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.dvLabel1.Unit = "";
            this.dvLabel1.UnitWidth = 36;
            // 
            // FormDescription
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.dvContainer2);
            this.Controls.Add(this.dvContainer1);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "FormDescription";
            this.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.Text = "프로젝트 정보";
            this.Title = "프로젝트 정보";
            this.TitleIconString = "fa-file-lines";
            this.dvContainer1.ResumeLayout(false);
            this.dvContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer dvContainer1;
        private Devinno.Forms.Controls.DvButton btnOK;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Controls.DvButton btnCancel;
        private Devinno.Forms.Containers.DvContainer dvContainer2;
        private Devinno.Forms.Controls.DvTextBox txtDescription;
        private Devinno.Forms.Controls.DvLabel dvLabel2;
        private Devinno.Forms.Controls.DvControl dvControl3;
        private Devinno.Forms.Controls.DvTextBox txtVersion;
        private Devinno.Forms.Controls.DvLabel dvLabel3;
        private Devinno.Forms.Controls.DvControl dvControl2;
        private Devinno.Forms.Controls.DvTextBox txtTitle;
        private Devinno.Forms.Controls.DvLabel dvLabel1;
    }
}