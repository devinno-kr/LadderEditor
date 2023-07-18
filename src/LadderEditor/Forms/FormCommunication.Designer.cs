
namespace LadderEditor.Forms
{
    partial class FormCommunication
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
            this.dvContainer2 = new Devinno.Forms.Containers.DvContainer();
            this.dg = new Devinno.Forms.Controls.DvDataGrid();
            this.pnlTitleAreas = new Devinno.Forms.Containers.DvContainer();
            this.btnPM = new Devinno.Forms.Controls.DvButtons();
            this.lblTitleAreas = new Devinno.Forms.Controls.DvLabel();
            this.dvContainer1 = new Devinno.Forms.Containers.DvContainer();
            this.btnOK = new Devinno.Forms.Controls.DvButton();
            this.dvControl1 = new Devinno.Forms.Controls.DvControl();
            this.btnCancel = new Devinno.Forms.Controls.DvButton();
            this.dvContainer2.SuspendLayout();
            this.pnlTitleAreas.SuspendLayout();
            this.dvContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvContainer2
            // 
            this.dvContainer2.Controls.Add(this.dg);
            this.dvContainer2.Controls.Add(this.pnlTitleAreas);
            this.dvContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvContainer2.Location = new System.Drawing.Point(3, 40);
            this.dvContainer2.Name = "dvContainer2";
            this.dvContainer2.Padding = new System.Windows.Forms.Padding(7, 10, 7, 0);
            this.dvContainer2.ShadowGap = 1;
            this.dvContainer2.Size = new System.Drawing.Size(634, 390);
            this.dvContainer2.TabIndex = 4;
            this.dvContainer2.TabStop = false;
            this.dvContainer2.Text = "dvContainer2";
            // 
            // dg
            // 
            this.dg.Bevel = true;
            this.dg.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dg.ColumnColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.dg.ColumnHeight = 30;
            this.dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg.HScrollPosition = 0D;
            this.dg.InputColor = null;
            this.dg.Location = new System.Drawing.Point(7, 43);
            this.dg.Name = "dg";
            this.dg.RowColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.dg.RowHeight = 30;
            this.dg.ScrollMode = Devinno.Forms.Utils.ScrollMode.Vertical;
            this.dg.SelectedRowColor = System.Drawing.Color.DarkRed;
            this.dg.SelectionMode = Devinno.Forms.Controls.DvDataGridSelectionMode.Single;
            this.dg.ShadowGap = 1;
            this.dg.Size = new System.Drawing.Size(620, 347);
            this.dg.SummaryRowColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dg.TabIndex = 11;
            this.dg.Text = "dvDataGrid1";
            this.dg.VScrollPosition = 0D;
            // 
            // pnlTitleAreas
            // 
            this.pnlTitleAreas.Controls.Add(this.btnPM);
            this.pnlTitleAreas.Controls.Add(this.lblTitleAreas);
            this.pnlTitleAreas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleAreas.Location = new System.Drawing.Point(7, 10);
            this.pnlTitleAreas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlTitleAreas.Name = "pnlTitleAreas";
            this.pnlTitleAreas.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlTitleAreas.ShadowGap = 1;
            this.pnlTitleAreas.Size = new System.Drawing.Size(620, 33);
            this.pnlTitleAreas.TabIndex = 10;
            this.pnlTitleAreas.TabStop = false;
            this.pnlTitleAreas.Text = "dvContainer4";
            // 
            // btnPM
            // 
            this.btnPM.BackgroundDraw = true;
            this.btnPM.ButtonColor = null;
            this.btnPM.CheckdButtonColor = null;
            this.btnPM.Clickable = true;
            this.btnPM.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnPM.Direction = Devinno.Forms.DvDirectionHV.Horizon;
            this.btnPM.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPM.Gradient = true;
            this.btnPM.Location = new System.Drawing.Point(540, 0);
            this.btnPM.Name = "btnPM";
            this.btnPM.Round = null;
            this.btnPM.SelectionMode = false;
            this.btnPM.ShadowGap = 1;
            this.btnPM.Size = new System.Drawing.Size(80, 30);
            this.btnPM.TabIndex = 13;
            // 
            // lblTitleAreas
            // 
            this.lblTitleAreas.BackgroundDraw = false;
            this.lblTitleAreas.BorderColor = null;
            this.lblTitleAreas.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            this.lblTitleAreas.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitleAreas.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblTitleAreas.IconGap = 5;
            this.lblTitleAreas.IconImage = null;
            this.lblTitleAreas.IconSize = 12F;
            this.lblTitleAreas.IconString = "fa-list-ul";
            this.lblTitleAreas.LabelColor = null;
            this.lblTitleAreas.Location = new System.Drawing.Point(0, 0);
            this.lblTitleAreas.Name = "lblTitleAreas";
            this.lblTitleAreas.Round = null;
            this.lblTitleAreas.ShadowGap = 1;
            this.lblTitleAreas.Size = new System.Drawing.Size(224, 30);
            this.lblTitleAreas.Style = Devinno.Forms.Embossing.FlatConcave;
            this.lblTitleAreas.TabIndex = 1;
            this.lblTitleAreas.TabStop = false;
            this.lblTitleAreas.Text = "통신 내역";
            this.lblTitleAreas.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblTitleAreas.Unit = "";
            this.lblTitleAreas.UnitWidth = 36;
            // 
            // dvContainer1
            // 
            this.dvContainer1.Controls.Add(this.btnOK);
            this.dvContainer1.Controls.Add(this.dvControl1);
            this.dvContainer1.Controls.Add(this.btnCancel);
            this.dvContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvContainer1.Location = new System.Drawing.Point(3, 430);
            this.dvContainer1.Name = "dvContainer1";
            this.dvContainer1.Padding = new System.Windows.Forms.Padding(7, 10, 7, 7);
            this.dvContainer1.ShadowGap = 1;
            this.dvContainer1.Size = new System.Drawing.Size(634, 47);
            this.dvContainer1.TabIndex = 13;
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
            this.btnOK.Location = new System.Drawing.Point(437, 10);
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
            this.dvControl1.Location = new System.Drawing.Point(527, 10);
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
            this.btnCancel.Location = new System.Drawing.Point(537, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Round = null;
            this.btnCancel.ShadowGap = 1;
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취소";
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancel.UseKey = false;
            // 
            // FormCommunication
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.dvContainer2);
            this.Controls.Add(this.dvContainer1);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FormCommunication";
            this.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.Text = "통신 설정";
            this.Title = "통신 설정";
            this.TitleIconString = "fa-wifi";
            this.WindowStateButtonColor = System.Drawing.Color.White;
            this.dvContainer2.ResumeLayout(false);
            this.pnlTitleAreas.ResumeLayout(false);
            this.dvContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer dvContainer2;
        private Devinno.Forms.Controls.DvDataGrid dg;
        private Devinno.Forms.Containers.DvContainer pnlTitleAreas;
        private Devinno.Forms.Controls.DvButtons btnPM;
        private Devinno.Forms.Controls.DvLabel lblTitleAreas;
        private Devinno.Forms.Containers.DvContainer dvContainer1;
        private Devinno.Forms.Controls.DvButton btnOK;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Controls.DvButton btnCancel;
    }
}