
namespace LadderEditor.Forms
{
    partial class FormConnect
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
            this.inAddr = new Devinno.Forms.Controls.DvValueInputText();
            this.dvContainer2 = new Devinno.Forms.Containers.DvContainer();
            this.btnOK = new Devinno.Forms.Controls.DvButton();
            this.dvControl1 = new Devinno.Forms.Controls.DvControl();
            this.btnCancel = new Devinno.Forms.Controls.DvButton();
            this.btnSearch = new Devinno.Forms.Controls.DvButton();
            this.dvContainer3 = new Devinno.Forms.Containers.DvContainer();
            this.tree = new Devinno.Forms.Controls.DvTreeView();
            this.dvContainer4 = new Devinno.Forms.Containers.DvContainer();
            this.btnPM = new Devinno.Forms.Controls.DvButtons();
            this.dvLabel1 = new Devinno.Forms.Controls.DvLabel();
            this.dvContainer1.SuspendLayout();
            this.dvContainer2.SuspendLayout();
            this.dvContainer3.SuspendLayout();
            this.dvContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvContainer1
            // 
            this.dvContainer1.Controls.Add(this.inAddr);
            this.dvContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvContainer1.Location = new System.Drawing.Point(3, 40);
            this.dvContainer1.Name = "dvContainer1";
            this.dvContainer1.Padding = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.dvContainer1.ShadowGap = 1;
            this.dvContainer1.Size = new System.Drawing.Size(358, 47);
            this.dvContainer1.TabIndex = 1;
            this.dvContainer1.TabStop = false;
            this.dvContainer1.Text = "dvContainer1";
            // 
            // inAddr
            // 
            this.inAddr.Button = null;
            this.inAddr.ButtonColor = null;
            this.inAddr.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.inAddr.ButtonIconGap = 0;
            this.inAddr.ButtonIconImage = null;
            this.inAddr.ButtonIconSize = 12F;
            this.inAddr.ButtonIconString = "";
            this.inAddr.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            this.inAddr.ButtonWidth = null;
            this.inAddr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inAddr.Location = new System.Drawing.Point(7, 10);
            this.inAddr.Margin = new System.Windows.Forms.Padding(0);
            this.inAddr.Name = "inAddr";
            this.inAddr.Round = null;
            this.inAddr.ShadowGap = 1;
            this.inAddr.Size = new System.Drawing.Size(344, 27);
            this.inAddr.TabIndex = 0;
            this.inAddr.Text = "주소";
            this.inAddr.Title = "주소";
            this.inAddr.TitleColor = null;
            this.inAddr.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.inAddr.TitleIconGap = 0;
            this.inAddr.TitleIconImage = null;
            this.inAddr.TitleIconSize = 60F;
            this.inAddr.TitleIconString = "";
            this.inAddr.TitleTextPadding = new System.Windows.Forms.Padding(0);
            this.inAddr.TitleWidth = 80;
            this.inAddr.Unit = "";
            this.inAddr.UnitWidth = 36;
            this.inAddr.Value = "";
            this.inAddr.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            // 
            // dvContainer2
            // 
            this.dvContainer2.Controls.Add(this.btnOK);
            this.dvContainer2.Controls.Add(this.dvControl1);
            this.dvContainer2.Controls.Add(this.btnCancel);
            this.dvContainer2.Controls.Add(this.btnSearch);
            this.dvContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvContainer2.Location = new System.Drawing.Point(3, 382);
            this.dvContainer2.Name = "dvContainer2";
            this.dvContainer2.Padding = new System.Windows.Forms.Padding(7, 10, 7, 7);
            this.dvContainer2.ShadowGap = 1;
            this.dvContainer2.Size = new System.Drawing.Size(358, 47);
            this.dvContainer2.TabIndex = 2;
            this.dvContainer2.TabStop = false;
            this.dvContainer2.Text = "dvContainer2";
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
            this.btnOK.IconSize = 12F;
            this.btnOK.IconString = null;
            this.btnOK.Location = new System.Drawing.Point(161, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Round = null;
            this.btnOK.ShadowGap = 1;
            this.btnOK.Size = new System.Drawing.Size(90, 30);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "확인";
            this.btnOK.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnOK.UseKey = false;
            // 
            // dvControl1
            // 
            this.dvControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dvControl1.Location = new System.Drawing.Point(251, 10);
            this.dvControl1.Name = "dvControl1";
            this.dvControl1.ShadowGap = 1;
            this.dvControl1.Size = new System.Drawing.Size(10, 30);
            this.dvControl1.TabIndex = 7;
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
            this.btnCancel.IconSize = 12F;
            this.btnCancel.IconString = null;
            this.btnCancel.Location = new System.Drawing.Point(261, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Round = null;
            this.btnCancel.ShadowGap = 1;
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취소";
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancel.UseKey = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundDraw = true;
            this.btnSearch.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnSearch.Clickable = true;
            this.btnSearch.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Gradient = true;
            this.btnSearch.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnSearch.IconGap = 0;
            this.btnSearch.IconImage = null;
            this.btnSearch.IconSize = 12F;
            this.btnSearch.IconString = "fa-magnifying-glass";
            this.btnSearch.Location = new System.Drawing.Point(7, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Round = null;
            this.btnSearch.ShadowGap = 1;
            this.btnSearch.Size = new System.Drawing.Size(40, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = null;
            this.btnSearch.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSearch.UseKey = false;
            // 
            // dvContainer3
            // 
            this.dvContainer3.Controls.Add(this.tree);
            this.dvContainer3.Controls.Add(this.dvContainer4);
            this.dvContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvContainer3.Location = new System.Drawing.Point(3, 87);
            this.dvContainer3.Name = "dvContainer3";
            this.dvContainer3.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.dvContainer3.ShadowGap = 1;
            this.dvContainer3.Size = new System.Drawing.Size(358, 295);
            this.dvContainer3.TabIndex = 3;
            this.dvContainer3.TabStop = false;
            this.dvContainer3.Text = "dvContainer3";
            // 
            // tree
            // 
            this.tree.BackgroundDraw = true;
            this.tree.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.ItemHeight = 36;
            this.tree.Location = new System.Drawing.Point(7, 33);
            this.tree.Name = "tree";
            this.tree.RadioColor = null;
            this.tree.RadioSize = 30;
            this.tree.Round = null;
            this.tree.SelectedColor = null;
            this.tree.SelectionMode = Devinno.Forms.ItemSelectionMode.Single;
            this.tree.ShadowGap = 1;
            this.tree.Size = new System.Drawing.Size(344, 262);
            this.tree.TabIndex = 7;
            this.tree.Text = "dvTreeView1";
            // 
            // dvContainer4
            // 
            this.dvContainer4.Controls.Add(this.btnPM);
            this.dvContainer4.Controls.Add(this.dvLabel1);
            this.dvContainer4.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvContainer4.Location = new System.Drawing.Point(7, 0);
            this.dvContainer4.Name = "dvContainer4";
            this.dvContainer4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.dvContainer4.ShadowGap = 1;
            this.dvContainer4.Size = new System.Drawing.Size(344, 33);
            this.dvContainer4.TabIndex = 4;
            this.dvContainer4.TabStop = false;
            this.dvContainer4.Text = "dvContainer4";
            // 
            // btnPM
            // 
            this.btnPM.BackgroundDraw = true;
            this.btnPM.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnPM.CheckdButtonColor = null;
            this.btnPM.Clickable = true;
            this.btnPM.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnPM.Direction = Devinno.Forms.DvDirectionHV.Horizon;
            this.btnPM.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPM.Gradient = true;
            this.btnPM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPM.Location = new System.Drawing.Point(264, 0);
            this.btnPM.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.btnPM.Name = "btnPM";
            this.btnPM.Round = null;
            this.btnPM.SelectionMode = false;
            this.btnPM.ShadowGap = 1;
            this.btnPM.Size = new System.Drawing.Size(80, 30);
            this.btnPM.TabIndex = 1;
            // 
            // dvLabel1
            // 
            this.dvLabel1.BackgroundDraw = false;
            this.dvLabel1.BorderColor = null;
            this.dvLabel1.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            this.dvLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dvLabel1.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.dvLabel1.IconGap = 3;
            this.dvLabel1.IconImage = null;
            this.dvLabel1.IconSize = 12F;
            this.dvLabel1.IconString = "fa-list-ul";
            this.dvLabel1.LabelColor = null;
            this.dvLabel1.Location = new System.Drawing.Point(0, 0);
            this.dvLabel1.Name = "dvLabel1";
            this.dvLabel1.Round = null;
            this.dvLabel1.ShadowGap = 1;
            this.dvLabel1.Size = new System.Drawing.Size(176, 30);
            this.dvLabel1.Style = Devinno.Forms.Embossing.FlatConvex;
            this.dvLabel1.TabIndex = 0;
            this.dvLabel1.TabStop = false;
            this.dvLabel1.Text = "주소록";
            this.dvLabel1.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.dvLabel1.Unit = "";
            this.dvLabel1.UnitWidth = null;
            // 
            // FormConnect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(364, 432);
            this.Controls.Add(this.dvContainer3);
            this.Controls.Add(this.dvContainer2);
            this.Controls.Add(this.dvContainer1);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnect";
            this.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.Text = "연결";
            this.Title = "연결";
            this.TitleIconString = "fa-link";
            this.dvContainer1.ResumeLayout(false);
            this.dvContainer2.ResumeLayout(false);
            this.dvContainer3.ResumeLayout(false);
            this.dvContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer dvContainer1;
        private Devinno.Forms.Controls.DvValueInputText inAddr;
        private Devinno.Forms.Containers.DvContainer dvContainer2;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Controls.DvButton btnCancel;
        private Devinno.Forms.Controls.DvButton btnSearch;
        private Devinno.Forms.Containers.DvContainer dvContainer3;
        private Devinno.Forms.Controls.DvTreeView tree;
        private Devinno.Forms.Containers.DvContainer dvContainer4;
        private Devinno.Forms.Controls.DvButtons btnPM;
        private Devinno.Forms.Controls.DvLabel dvLabel1;
        private Devinno.Forms.Controls.DvButton btnOK;
    }
}