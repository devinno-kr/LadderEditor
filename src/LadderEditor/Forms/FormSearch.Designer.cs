
namespace LadderEditor.Forms
{
    partial class FormSearch
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
            this.btnSearch = new Devinno.Forms.Controls.DvButton();
            this.dvControl1 = new Devinno.Forms.Controls.DvControl();
            this.btnClose = new Devinno.Forms.Controls.DvButton();
            this.dvContainer2 = new Devinno.Forms.Containers.DvContainer();
            this.inSearch = new Devinno.Forms.Controls.DvValueInputText();
            this.dvContainer1.SuspendLayout();
            this.dvContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvContainer1
            // 
            this.dvContainer1.Controls.Add(this.btnSearch);
            this.dvContainer1.Controls.Add(this.dvControl1);
            this.dvContainer1.Controls.Add(this.btnClose);
            this.dvContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvContainer1.Location = new System.Drawing.Point(3, 90);
            this.dvContainer1.Name = "dvContainer1";
            this.dvContainer1.Padding = new System.Windows.Forms.Padding(7, 10, 7, 7);
            this.dvContainer1.ShadowGap = 1;
            this.dvContainer1.Size = new System.Drawing.Size(342, 57);
            this.dvContainer1.TabIndex = 3;
            this.dvContainer1.TabStop = false;
            this.dvContainer1.Text = "dvContainer1";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundDraw = true;
            this.btnSearch.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnSearch.Clickable = true;
            this.btnSearch.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Gradient = true;
            this.btnSearch.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnSearch.IconGap = 0;
            this.btnSearch.IconImage = null;
            this.btnSearch.IconSize = 10F;
            this.btnSearch.IconString = null;
            this.btnSearch.Location = new System.Drawing.Point(145, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Round = null;
            this.btnSearch.ShadowGap = 1;
            this.btnSearch.Size = new System.Drawing.Size(90, 40);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "찾기";
            this.btnSearch.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSearch.UseKey = false;
            // 
            // dvControl1
            // 
            this.dvControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dvControl1.Location = new System.Drawing.Point(235, 10);
            this.dvControl1.Name = "dvControl1";
            this.dvControl1.ShadowGap = 1;
            this.dvControl1.Size = new System.Drawing.Size(10, 40);
            this.dvControl1.TabIndex = 1;
            this.dvControl1.TabStop = false;
            this.dvControl1.Text = "dvControl1";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundDraw = true;
            this.btnClose.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnClose.Clickable = true;
            this.btnClose.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Gradient = true;
            this.btnClose.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnClose.IconGap = 0;
            this.btnClose.IconImage = null;
            this.btnClose.IconSize = 10F;
            this.btnClose.IconString = null;
            this.btnClose.Location = new System.Drawing.Point(245, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Round = null;
            this.btnClose.ShadowGap = 1;
            this.btnClose.Size = new System.Drawing.Size(90, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "닫기";
            this.btnClose.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnClose.UseKey = false;
            // 
            // dvContainer2
            // 
            this.dvContainer2.Controls.Add(this.inSearch);
            this.dvContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvContainer2.Location = new System.Drawing.Point(3, 40);
            this.dvContainer2.Name = "dvContainer2";
            this.dvContainer2.Padding = new System.Windows.Forms.Padding(7, 10, 7, 0);
            this.dvContainer2.ShadowGap = 1;
            this.dvContainer2.Size = new System.Drawing.Size(342, 50);
            this.dvContainer2.TabIndex = 4;
            this.dvContainer2.TabStop = false;
            this.dvContainer2.Text = "dvContainer2";
            // 
            // inSearch
            // 
            this.inSearch.Button = null;
            this.inSearch.ButtonColor = null;
            this.inSearch.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.inSearch.ButtonIconGap = 0;
            this.inSearch.ButtonIconImage = null;
            this.inSearch.ButtonIconSize = 12F;
            this.inSearch.ButtonIconString = null;
            this.inSearch.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            this.inSearch.ButtonWidth = null;
            this.inSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inSearch.Location = new System.Drawing.Point(7, 10);
            this.inSearch.Name = "inSearch";
            this.inSearch.Round = null;
            this.inSearch.ShadowGap = 1;
            this.inSearch.Size = new System.Drawing.Size(328, 40);
            this.inSearch.TabIndex = 0;
            this.inSearch.Text = "검색어";
            this.inSearch.Title = "검색어";
            this.inSearch.TitleColor = null;
            this.inSearch.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.inSearch.TitleIconGap = 0;
            this.inSearch.TitleIconImage = null;
            this.inSearch.TitleIconSize = 12F;
            this.inSearch.TitleIconString = null;
            this.inSearch.TitleTextPadding = new System.Windows.Forms.Padding(0);
            this.inSearch.TitleWidth = 60;
            this.inSearch.Unit = "";
            this.inSearch.UnitWidth = 36;
            this.inSearch.Value = "";
            this.inSearch.ValueColor = null;
            // 
            // FormSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(348, 150);
            this.Controls.Add(this.dvContainer2);
            this.Controls.Add(this.dvContainer1);
            this.Fixed = true;
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearch";
            this.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.Text = "찾기";
            this.Title = "찾기";
            this.TitleIconString = "fa-magnifying-glass";
            this.dvContainer1.ResumeLayout(false);
            this.dvContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer dvContainer1;
        private Devinno.Forms.Controls.DvButton btnSearch;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Controls.DvButton btnClose;
        private Devinno.Forms.Containers.DvContainer dvContainer2;
        private Devinno.Forms.Controls.DvValueInputText inSearch;
    }
}