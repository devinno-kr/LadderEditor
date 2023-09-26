
namespace LadderEditor.Forms
{
    partial class FormMultiDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMultiDownload));
            this.dvContainer1 = new Devinno.Forms.Containers.DvContainer();
            this.dg = new Devinno.Forms.Controls.DvDataGrid();
            this.dvControl2 = new Devinno.Forms.Controls.DvControl();
            this.dvContainer2 = new Devinno.Forms.Containers.DvContainer();
            this.btnDevInput = new Devinno.Forms.Controls.DvButton();
            this.dvControl1 = new Devinno.Forms.Controls.DvControl();
            this.btnDownload = new Devinno.Forms.Controls.DvButton();
            this.dvLabel1 = new Devinno.Forms.Controls.DvLabel();
            this.dvContainer1.SuspendLayout();
            this.dvContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvContainer1
            // 
            this.dvContainer1.Controls.Add(this.dg);
            this.dvContainer1.Controls.Add(this.dvControl2);
            this.dvContainer1.Controls.Add(this.dvContainer2);
            this.dvContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvContainer1.Location = new System.Drawing.Point(0, 0);
            this.dvContainer1.Name = "dvContainer1";
            this.dvContainer1.Padding = new System.Windows.Forms.Padding(10);
            this.dvContainer1.ShadowGap = 1;
            this.dvContainer1.Size = new System.Drawing.Size(800, 800);
            this.dvContainer1.TabIndex = 0;
            this.dvContainer1.TabStop = false;
            this.dvContainer1.Text = "dvContainer1";
            // 
            // dg
            // 
            this.dg.Bevel = true;
            this.dg.BoxColor = null;
            this.dg.ColumnColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dg.ColumnHeight = 30;
            this.dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg.HScrollPosition = 0D;
            this.dg.InputColor = null;
            this.dg.Location = new System.Drawing.Point(10, 60);
            this.dg.Name = "dg";
            this.dg.RowColor = null;
            this.dg.RowHeight = 30;
            this.dg.ScrollMode = Devinno.Forms.Utils.ScrollMode.Vertical;
            this.dg.SelectedRowColor = null;
            this.dg.SelectionMode = Devinno.Forms.Controls.DvDataGridSelectionMode.Single;
            this.dg.ShadowGap = 1;
            this.dg.Size = new System.Drawing.Size(780, 730);
            this.dg.SummaryRowColor = null;
            this.dg.TabIndex = 2;
            this.dg.Text = "dvDataGrid1";
            this.dg.VScrollPosition = 0D;
            // 
            // dvControl2
            // 
            this.dvControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvControl2.Location = new System.Drawing.Point(10, 50);
            this.dvControl2.Name = "dvControl2";
            this.dvControl2.ShadowGap = 1;
            this.dvControl2.Size = new System.Drawing.Size(780, 10);
            this.dvControl2.TabIndex = 1;
            this.dvControl2.TabStop = false;
            this.dvControl2.Text = "dvControl2";
            // 
            // dvContainer2
            // 
            this.dvContainer2.Controls.Add(this.btnDevInput);
            this.dvContainer2.Controls.Add(this.dvControl1);
            this.dvContainer2.Controls.Add(this.btnDownload);
            this.dvContainer2.Controls.Add(this.dvLabel1);
            this.dvContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvContainer2.Location = new System.Drawing.Point(10, 10);
            this.dvContainer2.Name = "dvContainer2";
            this.dvContainer2.ShadowGap = 1;
            this.dvContainer2.Size = new System.Drawing.Size(780, 40);
            this.dvContainer2.TabIndex = 0;
            this.dvContainer2.TabStop = false;
            this.dvContainer2.Text = "dvContainer2";
            // 
            // btnDevInput
            // 
            this.btnDevInput.BackgroundDraw = true;
            this.btnDevInput.ButtonColor = null;
            this.btnDevInput.Clickable = true;
            this.btnDevInput.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnDevInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDevInput.Gradient = true;
            this.btnDevInput.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnDevInput.IconGap = 0;
            this.btnDevInput.IconImage = null;
            this.btnDevInput.IconSize = 12F;
            this.btnDevInput.IconString = null;
            this.btnDevInput.Location = new System.Drawing.Point(586, 0);
            this.btnDevInput.Name = "btnDevInput";
            this.btnDevInput.Round = null;
            this.btnDevInput.ShadowGap = 1;
            this.btnDevInput.Size = new System.Drawing.Size(92, 40);
            this.btnDevInput.TabIndex = 3;
            this.btnDevInput.Text = "장치 설정";
            this.btnDevInput.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDevInput.UseKey = false;
            // 
            // dvControl1
            // 
            this.dvControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dvControl1.Location = new System.Drawing.Point(678, 0);
            this.dvControl1.Name = "dvControl1";
            this.dvControl1.ShadowGap = 1;
            this.dvControl1.Size = new System.Drawing.Size(10, 40);
            this.dvControl1.TabIndex = 2;
            this.dvControl1.TabStop = false;
            this.dvControl1.Text = "dvControl1";
            // 
            // btnDownload
            // 
            this.btnDownload.BackgroundDraw = true;
            this.btnDownload.ButtonColor = null;
            this.btnDownload.Clickable = true;
            this.btnDownload.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnDownload.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDownload.Gradient = true;
            this.btnDownload.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnDownload.IconGap = 0;
            this.btnDownload.IconImage = null;
            this.btnDownload.IconSize = 12F;
            this.btnDownload.IconString = null;
            this.btnDownload.Location = new System.Drawing.Point(688, 0);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Round = null;
            this.btnDownload.ShadowGap = 1;
            this.btnDownload.Size = new System.Drawing.Size(92, 40);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "다운로드";
            this.btnDownload.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDownload.UseKey = false;
            // 
            // dvLabel1
            // 
            this.dvLabel1.BackgroundDraw = false;
            this.dvLabel1.BorderColor = null;
            this.dvLabel1.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            this.dvLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dvLabel1.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.dvLabel1.IconGap = 5;
            this.dvLabel1.IconImage = null;
            this.dvLabel1.IconSize = 12F;
            this.dvLabel1.IconString = "fa-list-ul";
            this.dvLabel1.LabelColor = null;
            this.dvLabel1.Location = new System.Drawing.Point(0, 0);
            this.dvLabel1.Name = "dvLabel1";
            this.dvLabel1.Round = null;
            this.dvLabel1.ShadowGap = 1;
            this.dvLabel1.Size = new System.Drawing.Size(150, 40);
            this.dvLabel1.Style = Devinno.Forms.Embossing.FlatConcave;
            this.dvLabel1.TabIndex = 0;
            this.dvLabel1.TabStop = false;
            this.dvLabel1.Text = "장치 리스트";
            this.dvLabel1.TextPadding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dvLabel1.Unit = "";
            this.dvLabel1.UnitWidth = null;
            // 
            // FormMultiDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BlankForm = true;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.dvContainer1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "FormMultiDownload";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Text = "멀티 다운로드";
            this.Title = "멀티 다운로드";
            this.TitleHeight = 0;
            this.TitleIconString = "fa-download";
            this.dvContainer1.ResumeLayout(false);
            this.dvContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer dvContainer1;
        private Devinno.Forms.Containers.DvContainer dvContainer2;
        private Devinno.Forms.Controls.DvButton btnDevInput;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Controls.DvButton btnDownload;
        private Devinno.Forms.Controls.DvLabel dvLabel1;
        private Devinno.Forms.Controls.DvDataGrid dg;
        private Devinno.Forms.Controls.DvControl dvControl2;
    }
}