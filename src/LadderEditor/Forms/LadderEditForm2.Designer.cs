
namespace LadderEditor.Forms
{
    partial class LadderEditForm2
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
            this.pnl = new Devinno.Forms.Containers.DvContainer();
            this.inPanel = new LadderEditor.Controls.InputPanel();
            this.txt = new System.Windows.Forms.TextBox();
            this.dvContainer1 = new Devinno.Forms.Containers.DvContainer();
            this.btnOK = new Devinno.Forms.Controls.DvButton();
            this.dvControl1 = new Devinno.Forms.Controls.DvControl();
            this.btnCancel = new Devinno.Forms.Controls.DvButton();
            this.pnlContent = new Devinno.Forms.Containers.DvContainer();
            this.lblDesc = new Devinno.Forms.Controls.DvLabel();
            this.dvLabel1 = new Devinno.Forms.Controls.DvLabel();
            this.pnl.SuspendLayout();
            this.inPanel.SuspendLayout();
            this.dvContainer1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.inPanel);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl.Location = new System.Drawing.Point(3, 40);
            this.pnl.Name = "pnl";
            this.pnl.Padding = new System.Windows.Forms.Padding(7, 10, 7, 7);
            this.pnl.ShadowGap = 1;
            this.pnl.Size = new System.Drawing.Size(424, 50);
            this.pnl.TabIndex = 1;
            this.pnl.TabStop = false;
            this.pnl.Text = "dvContainer1";
            // 
            // inPanel
            // 
            this.inPanel.Controls.Add(this.txt);
            this.inPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inPanel.Location = new System.Drawing.Point(7, 10);
            this.inPanel.Name = "inPanel";
            this.inPanel.Padding = new System.Windows.Forms.Padding(7, 9, 7, 7);
            this.inPanel.ShadowGap = 1;
            this.inPanel.Size = new System.Drawing.Size(410, 33);
            this.inPanel.TabIndex = 0;
            this.inPanel.TabStop = false;
            this.inPanel.Text = "inputPanel1";
            // 
            // txt
            // 
            this.txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.ForeColor = System.Drawing.Color.White;
            this.txt.Location = new System.Drawing.Point(7, 9);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(396, 14);
            this.txt.TabIndex = 0;
            // 
            // dvContainer1
            // 
            this.dvContainer1.Controls.Add(this.btnOK);
            this.dvContainer1.Controls.Add(this.dvControl1);
            this.dvContainer1.Controls.Add(this.btnCancel);
            this.dvContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvContainer1.Location = new System.Drawing.Point(3, 347);
            this.dvContainer1.Name = "dvContainer1";
            this.dvContainer1.Padding = new System.Windows.Forms.Padding(7, 10, 7, 7);
            this.dvContainer1.ShadowGap = 1;
            this.dvContainer1.Size = new System.Drawing.Size(424, 50);
            this.dvContainer1.TabIndex = 3;
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
            this.btnOK.Location = new System.Drawing.Point(229, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Round = null;
            this.btnOK.ShadowGap = 1;
            this.btnOK.Size = new System.Drawing.Size(90, 33);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "확인";
            this.btnOK.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnOK.UseKey = false;
            // 
            // dvControl1
            // 
            this.dvControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dvControl1.Location = new System.Drawing.Point(319, 10);
            this.dvControl1.Name = "dvControl1";
            this.dvControl1.ShadowGap = 1;
            this.dvControl1.Size = new System.Drawing.Size(8, 33);
            this.dvControl1.TabIndex = 2;
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
            this.btnCancel.Location = new System.Drawing.Point(327, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Round = null;
            this.btnCancel.ShadowGap = 1;
            this.btnCancel.Size = new System.Drawing.Size(90, 33);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취소";
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancel.UseKey = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.lblDesc);
            this.pnlContent.Controls.Add(this.dvLabel1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(3, 90);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.pnlContent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlContent.ShadowGap = 1;
            this.pnlContent.Size = new System.Drawing.Size(424, 257);
            this.pnlContent.TabIndex = 4;
            this.pnlContent.TabStop = false;
            this.pnlContent.Text = "dvContainer1";
            // 
            // lblDesc
            // 
            this.lblDesc.BackgroundDraw = true;
            this.lblDesc.BorderColor = null;
            this.lblDesc.ContentAlignment = Devinno.Forms.DvContentAlignment.TopLeft;
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblDesc.IconGap = 0;
            this.lblDesc.IconImage = null;
            this.lblDesc.IconSize = 10F;
            this.lblDesc.IconString = null;
            this.lblDesc.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblDesc.Location = new System.Drawing.Point(7, 30);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Round = null;
            this.lblDesc.ShadowGap = 1;
            this.lblDesc.Size = new System.Drawing.Size(410, 227);
            this.lblDesc.Style = Devinno.Forms.Embossing.FlatConcave;
            this.lblDesc.TabIndex = 3;
            this.lblDesc.TabStop = false;
            this.lblDesc.Text = null;
            this.lblDesc.TextPadding = new System.Windows.Forms.Padding(10);
            this.lblDesc.Unit = "";
            this.lblDesc.UnitWidth = null;
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
            this.dvLabel1.IconSize = 12F;
            this.dvLabel1.IconString = "fa-align-left";
            this.dvLabel1.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dvLabel1.Location = new System.Drawing.Point(7, 0);
            this.dvLabel1.Name = "dvLabel1";
            this.dvLabel1.Round = null;
            this.dvLabel1.ShadowGap = 1;
            this.dvLabel1.Size = new System.Drawing.Size(410, 30);
            this.dvLabel1.Style = Devinno.Forms.Embossing.FlatConcave;
            this.dvLabel1.TabIndex = 2;
            this.dvLabel1.TabStop = false;
            this.dvLabel1.Text = "설명";
            this.dvLabel1.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.dvLabel1.Unit = "";
            this.dvLabel1.UnitWidth = 36;
            // 
            // LadderEditForm2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(430, 400);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.dvContainer1);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LadderEditForm2";
            this.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.Text = "편집";
            this.Title = "편집";
            this.TitleIconSize = 14F;
            this.TitleIconString = "fa-pen-to-square";
            this.pnl.ResumeLayout(false);
            this.inPanel.ResumeLayout(false);
            this.inPanel.PerformLayout();
            this.dvContainer1.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer pnl;
        private Devinno.Forms.Containers.DvContainer dvContainer1;
        private Devinno.Forms.Controls.DvButton btnOK;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Controls.DvButton btnCancel;
        private Devinno.Forms.Containers.DvContainer pnlContent;
        private Devinno.Forms.Controls.DvLabel lblDesc;
        private Devinno.Forms.Controls.DvLabel dvLabel1;
        private Controls.InputPanel inPanel;
        private System.Windows.Forms.TextBox txt;
    }
}