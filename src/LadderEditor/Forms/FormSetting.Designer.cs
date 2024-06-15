
namespace LadderEditor.Forms
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            dvContainer1 = new Devinno.Forms.Containers.DvContainer();
            dvTableLayoutPanel1 = new Devinno.Forms.Containers.DvTableLayoutPanel();
            lblTitleAreas = new Devinno.Forms.Controls.DvLabel();
            lblPath = new Controls.DvValueLabelPath();
            inLang = new Devinno.Forms.Controls.DvValueInputBool();
            dvControl1 = new Devinno.Forms.Controls.DvControl();
            dvContainer2 = new Devinno.Forms.Containers.DvContainer();
            btnOK = new Devinno.Forms.Controls.DvButton();
            dvControl2 = new Devinno.Forms.Controls.DvControl();
            btnCancel = new Devinno.Forms.Controls.DvButton();
            inDescView = new Devinno.Forms.Controls.DvValueInputBool();
            dvContainer1.SuspendLayout();
            dvTableLayoutPanel1.SuspendLayout();
            dvContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // dvContainer1
            // 
            dvContainer1.Controls.Add(dvTableLayoutPanel1);
            dvContainer1.Controls.Add(dvControl1);
            dvContainer1.Controls.Add(dvContainer2);
            dvContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            dvContainer1.Location = new System.Drawing.Point(0, 0);
            dvContainer1.Name = "dvContainer1";
            dvContainer1.Padding = new System.Windows.Forms.Padding(10);
            dvContainer1.ShadowGap = 1;
            dvContainer1.Size = new System.Drawing.Size(446, 244);
            dvContainer1.TabIndex = 0;
            dvContainer1.TabStop = false;
            dvContainer1.Text = "dvContainer1";
            // 
            // dvTableLayoutPanel1
            // 
            dvTableLayoutPanel1.ColumnCount = 1;
            dvTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            dvTableLayoutPanel1.Controls.Add(inDescView, 0, 3);
            dvTableLayoutPanel1.Controls.Add(lblTitleAreas, 0, 0);
            dvTableLayoutPanel1.Controls.Add(lblPath, 0, 1);
            dvTableLayoutPanel1.Controls.Add(inLang, 0, 2);
            dvTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            dvTableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            dvTableLayoutPanel1.Name = "dvTableLayoutPanel1";
            dvTableLayoutPanel1.RowCount = 4;
            dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            dvTableLayoutPanel1.Size = new System.Drawing.Size(426, 174);
            dvTableLayoutPanel1.TabIndex = 7;
            // 
            // lblTitleAreas
            // 
            lblTitleAreas.BackgroundDraw = false;
            lblTitleAreas.BorderColor = null;
            lblTitleAreas.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            lblTitleAreas.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitleAreas.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            lblTitleAreas.IconGap = 3;
            lblTitleAreas.IconImage = null;
            lblTitleAreas.IconSize = 12F;
            lblTitleAreas.IconString = "fa-list-ul";
            lblTitleAreas.LabelColor = null;
            lblTitleAreas.Location = new System.Drawing.Point(3, 3);
            lblTitleAreas.Name = "lblTitleAreas";
            lblTitleAreas.Round = null;
            lblTitleAreas.ShadowGap = 1;
            lblTitleAreas.Size = new System.Drawing.Size(420, 30);
            lblTitleAreas.Style = Devinno.Forms.Embossing.FlatConcave;
            lblTitleAreas.TabIndex = 2;
            lblTitleAreas.TabStop = false;
            lblTitleAreas.Text = "설정 내역";
            lblTitleAreas.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            lblTitleAreas.Unit = "";
            lblTitleAreas.UnitWidth = null;
            // 
            // lblPath
            // 
            lblPath.Button = null;
            lblPath.ButtonColor = null;
            lblPath.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            lblPath.ButtonIconGap = 0;
            lblPath.ButtonIconImage = null;
            lblPath.ButtonIconSize = 12F;
            lblPath.ButtonIconString = "fa-ellipsis";
            lblPath.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            lblPath.ButtonWidth = 50;
            lblPath.Dock = System.Windows.Forms.DockStyle.Fill;
            lblPath.Location = new System.Drawing.Point(3, 39);
            lblPath.Name = "lblPath";
            lblPath.Round = null;
            lblPath.ShadowGap = 1;
            lblPath.Size = new System.Drawing.Size(420, 40);
            lblPath.TabIndex = 3;
            lblPath.Text = "프로젝트 폴더";
            lblPath.Title = "프로젝트 폴더";
            lblPath.TitleColor = null;
            lblPath.TitleGradient = false;
            lblPath.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            lblPath.TitleIconGap = 0;
            lblPath.TitleIconImage = null;
            lblPath.TitleIconSize = 12F;
            lblPath.TitleIconString = null;
            lblPath.TitleTextPadding = new System.Windows.Forms.Padding(0);
            lblPath.TitleWidth = 100;
            lblPath.Unit = "";
            lblPath.UnitWidth = null;
            lblPath.Value = "";
            lblPath.ValueColor = null;
            // 
            // inLang
            // 
            inLang.Button = null;
            inLang.ButtonColor = null;
            inLang.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            inLang.ButtonIconGap = 0;
            inLang.ButtonIconImage = null;
            inLang.ButtonIconSize = 12F;
            inLang.ButtonIconString = null;
            inLang.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            inLang.ButtonWidth = null;
            inLang.Dock = System.Windows.Forms.DockStyle.Fill;
            inLang.Location = new System.Drawing.Point(3, 85);
            inLang.Name = "inLang";
            inLang.Off = "ENG";
            inLang.On = "한글";
            inLang.Round = null;
            inLang.ShadowGap = 1;
            inLang.Size = new System.Drawing.Size(420, 40);
            inLang.TabIndex = 4;
            inLang.Text = "언어";
            inLang.Title = "언어";
            inLang.TitleColor = null;
            inLang.TitleGradient = false;
            inLang.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            inLang.TitleIconGap = 0;
            inLang.TitleIconImage = null;
            inLang.TitleIconSize = 12F;
            inLang.TitleIconString = null;
            inLang.TitleTextPadding = new System.Windows.Forms.Padding(0);
            inLang.TitleWidth = 100;
            inLang.Unit = "";
            inLang.UnitWidth = null;
            inLang.Value = false;
            inLang.ValueColor = null;
            // 
            // dvControl1
            // 
            dvControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            dvControl1.Location = new System.Drawing.Point(10, 184);
            dvControl1.Name = "dvControl1";
            dvControl1.ShadowGap = 1;
            dvControl1.Size = new System.Drawing.Size(426, 10);
            dvControl1.TabIndex = 6;
            dvControl1.TabStop = false;
            dvControl1.Text = "dvControl1";
            // 
            // dvContainer2
            // 
            dvContainer2.Controls.Add(btnOK);
            dvContainer2.Controls.Add(dvControl2);
            dvContainer2.Controls.Add(btnCancel);
            dvContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            dvContainer2.Location = new System.Drawing.Point(10, 194);
            dvContainer2.Name = "dvContainer2";
            dvContainer2.Padding = new System.Windows.Forms.Padding(168, 0, 0, 0);
            dvContainer2.ShadowGap = 1;
            dvContainer2.Size = new System.Drawing.Size(426, 40);
            dvContainer2.TabIndex = 5;
            dvContainer2.TabStop = false;
            dvContainer2.Text = "dvContainer2";
            // 
            // btnOK
            // 
            btnOK.BackgroundDraw = true;
            btnOK.ButtonColor = null;
            btnOK.Clickable = true;
            btnOK.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            btnOK.Gradient = true;
            btnOK.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            btnOK.IconGap = 0;
            btnOK.IconImage = null;
            btnOK.IconSize = 12F;
            btnOK.IconString = null;
            btnOK.Location = new System.Drawing.Point(228, 0);
            btnOK.Name = "btnOK";
            btnOK.Round = null;
            btnOK.ShadowGap = 1;
            btnOK.Size = new System.Drawing.Size(94, 40);
            btnOK.TabIndex = 4;
            btnOK.Text = "확인";
            btnOK.TextPadding = new System.Windows.Forms.Padding(0);
            btnOK.UseKey = false;
            // 
            // dvControl2
            // 
            dvControl2.Dock = System.Windows.Forms.DockStyle.Right;
            dvControl2.Location = new System.Drawing.Point(322, 0);
            dvControl2.Name = "dvControl2";
            dvControl2.ShadowGap = 1;
            dvControl2.Size = new System.Drawing.Size(10, 40);
            dvControl2.TabIndex = 3;
            dvControl2.TabStop = false;
            dvControl2.Text = "dvControl2";
            // 
            // btnCancel
            // 
            btnCancel.BackgroundDraw = true;
            btnCancel.ButtonColor = null;
            btnCancel.Clickable = true;
            btnCancel.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            btnCancel.Gradient = true;
            btnCancel.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            btnCancel.IconGap = 0;
            btnCancel.IconImage = null;
            btnCancel.IconSize = 12F;
            btnCancel.IconString = null;
            btnCancel.Location = new System.Drawing.Point(332, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Round = null;
            btnCancel.ShadowGap = 1;
            btnCancel.Size = new System.Drawing.Size(94, 40);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "취소";
            btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            btnCancel.UseKey = false;
            // 
            // inDescView
            // 
            inDescView.Button = null;
            inDescView.ButtonColor = null;
            inDescView.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            inDescView.ButtonIconGap = 0;
            inDescView.ButtonIconImage = null;
            inDescView.ButtonIconSize = 12F;
            inDescView.ButtonIconString = null;
            inDescView.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            inDescView.ButtonWidth = null;
            inDescView.Dock = System.Windows.Forms.DockStyle.Fill;
            inDescView.Location = new System.Drawing.Point(3, 131);
            inDescView.Name = "inDescView";
            inDescView.Off = "축약";
            inDescView.On = "전체";
            inDescView.Round = null;
            inDescView.ShadowGap = 1;
            inDescView.Size = new System.Drawing.Size(420, 40);
            inDescView.TabIndex = 5;
            inDescView.Text = "구문 표시";
            inDescView.Title = "구문 표시";
            inDescView.TitleColor = null;
            inDescView.TitleGradient = false;
            inDescView.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            inDescView.TitleIconGap = 0;
            inDescView.TitleIconImage = null;
            inDescView.TitleIconSize = 12F;
            inDescView.TitleIconString = null;
            inDescView.TitleTextPadding = new System.Windows.Forms.Padding(0);
            inDescView.TitleWidth = 100;
            inDescView.Unit = "";
            inDescView.UnitWidth = null;
            inDescView.Value = false;
            inDescView.ValueColor = null;
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BlankForm = true;
            ClientSize = new System.Drawing.Size(446, 244);
            Controls.Add(dvContainer1);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSetting";
            Padding = new System.Windows.Forms.Padding(0);
            Text = "설정";
            Title = "설정";
            TitleHeight = 0;
            TitleIconString = "fa-gear";
            dvContainer1.ResumeLayout(false);
            dvTableLayoutPanel1.ResumeLayout(false);
            dvContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Devinno.Forms.Containers.DvContainer dvContainer1;
        private Devinno.Forms.Containers.DvContainer dvContainer2;
        private Devinno.Forms.Controls.DvButton btnOK;
        private Devinno.Forms.Controls.DvControl dvControl2;
        private Devinno.Forms.Controls.DvButton btnCancel;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Containers.DvTableLayoutPanel dvTableLayoutPanel1;
        private Controls.DvValueLabelPath lblPath;
        private Devinno.Forms.Controls.DvValueInputBool inLang;
        private Devinno.Forms.Controls.DvLabel lblTitleAreas;
        private Devinno.Forms.Controls.DvValueInputBool inDescView;
    }
}