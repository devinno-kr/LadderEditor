
namespace LadderEditor.Forms
{
    partial class FormLibrary
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
            this.pnlButtons = new Devinno.Forms.Containers.DvContainer();
            this.btnOK = new Devinno.Forms.Controls.DvButton();
            this.dvControl1 = new Devinno.Forms.Controls.DvControl();
            this.btnCancel = new Devinno.Forms.Controls.DvButton();
            this.tpnl = new Devinno.Forms.Containers.DvTableLayoutPanel();
            this.dvTableLayoutPanel2 = new Devinno.Forms.Containers.DvTableLayoutPanel();
            this.btnReg = new Devinno.Forms.Controls.DvButton();
            this.btnUnreg = new Devinno.Forms.Controls.DvButton();
            this.dvContainer3 = new Devinno.Forms.Containers.DvContainer();
            this.dvLabel2 = new Devinno.Forms.Controls.DvLabel();
            this.dvContainer2 = new Devinno.Forms.Containers.DvContainer();
            this.dvLabel1 = new Devinno.Forms.Controls.DvLabel();
            this.dgLibrary = new Devinno.Forms.Controls.DvDataGrid();
            this.dragDLL = new Devinno.Forms.Controls.DvLabel();
            this.dgReference = new Devinno.Forms.Controls.DvDataGrid();
            this.pnlButtons.SuspendLayout();
            this.tpnl.SuspendLayout();
            this.dvTableLayoutPanel2.SuspendLayout();
            this.dvContainer3.SuspendLayout();
            this.dvContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Controls.Add(this.dvControl1);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(3, 550);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(7, 10, 7, 7);
            this.pnlButtons.ShadowGap = 1;
            this.pnlButtons.Size = new System.Drawing.Size(794, 47);
            this.pnlButtons.TabIndex = 3;
            this.pnlButtons.TabStop = false;
            this.pnlButtons.Text = "dvContainer1";
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
            this.btnOK.Location = new System.Drawing.Point(597, 10);
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
            this.dvControl1.Location = new System.Drawing.Point(687, 10);
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
            this.btnCancel.Location = new System.Drawing.Point(697, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Round = null;
            this.btnCancel.ShadowGap = 1;
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취소";
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancel.UseKey = false;
            // 
            // tpnl
            // 
            this.tpnl.ColumnCount = 3;
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnl.Controls.Add(this.dvTableLayoutPanel2, 1, 1);
            this.tpnl.Controls.Add(this.dvContainer3, 2, 0);
            this.tpnl.Controls.Add(this.dvContainer2, 0, 0);
            this.tpnl.Controls.Add(this.dgLibrary, 0, 1);
            this.tpnl.Controls.Add(this.dragDLL, 0, 2);
            this.tpnl.Controls.Add(this.dgReference, 2, 1);
            this.tpnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnl.Location = new System.Drawing.Point(3, 40);
            this.tpnl.Name = "tpnl";
            this.tpnl.RowCount = 3;
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tpnl.Size = new System.Drawing.Size(794, 510);
            this.tpnl.TabIndex = 4;
            // 
            // dvTableLayoutPanel2
            // 
            this.dvTableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dvTableLayoutPanel2.ColumnCount = 1;
            this.dvTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dvTableLayoutPanel2.Controls.Add(this.btnReg, 0, 0);
            this.dvTableLayoutPanel2.Controls.Add(this.btnUnreg, 0, 2);
            this.dvTableLayoutPanel2.Location = new System.Drawing.Point(260, 198);
            this.dvTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.dvTableLayoutPanel2.Name = "dvTableLayoutPanel2";
            this.dvTableLayoutPanel2.RowCount = 3;
            this.dvTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.dvTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.dvTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.dvTableLayoutPanel2.Size = new System.Drawing.Size(30, 70);
            this.dvTableLayoutPanel2.TabIndex = 3;
            // 
            // btnReg
            // 
            this.btnReg.BackgroundDraw = true;
            this.btnReg.ButtonColor = null;
            this.btnReg.Clickable = true;
            this.btnReg.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReg.Gradient = true;
            this.btnReg.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnReg.IconGap = 0;
            this.btnReg.IconImage = null;
            this.btnReg.IconSize = 12F;
            this.btnReg.IconString = "fa-plus";
            this.btnReg.Location = new System.Drawing.Point(0, 0);
            this.btnReg.Margin = new System.Windows.Forms.Padding(0);
            this.btnReg.Name = "btnReg";
            this.btnReg.Round = null;
            this.btnReg.ShadowGap = 1;
            this.btnReg.Size = new System.Drawing.Size(30, 30);
            this.btnReg.TabIndex = 0;
            this.btnReg.Text = null;
            this.btnReg.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnReg.UseKey = false;
            // 
            // btnUnreg
            // 
            this.btnUnreg.BackgroundDraw = true;
            this.btnUnreg.ButtonColor = null;
            this.btnUnreg.Clickable = true;
            this.btnUnreg.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnUnreg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnreg.Gradient = true;
            this.btnUnreg.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnUnreg.IconGap = 0;
            this.btnUnreg.IconImage = null;
            this.btnUnreg.IconSize = 12F;
            this.btnUnreg.IconString = "fa-minus";
            this.btnUnreg.Location = new System.Drawing.Point(0, 40);
            this.btnUnreg.Margin = new System.Windows.Forms.Padding(0);
            this.btnUnreg.Name = "btnUnreg";
            this.btnUnreg.Round = null;
            this.btnUnreg.ShadowGap = 1;
            this.btnUnreg.Size = new System.Drawing.Size(30, 30);
            this.btnUnreg.TabIndex = 1;
            this.btnUnreg.Text = null;
            this.btnUnreg.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnUnreg.UseKey = false;
            // 
            // dvContainer3
            // 
            this.dvContainer3.Controls.Add(this.dvLabel2);
            this.dvContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvContainer3.Location = new System.Drawing.Point(300, 10);
            this.dvContainer3.Margin = new System.Windows.Forms.Padding(0, 10, 7, 0);
            this.dvContainer3.Name = "dvContainer3";
            this.dvContainer3.ShadowGap = 1;
            this.dvContainer3.Size = new System.Drawing.Size(487, 27);
            this.dvContainer3.TabIndex = 1;
            this.dvContainer3.TabStop = false;
            this.dvContainer3.Text = "dvContainer3";
            // 
            // dvLabel2
            // 
            this.dvLabel2.BackgroundDraw = false;
            this.dvLabel2.BorderColor = null;
            this.dvLabel2.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            this.dvLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dvLabel2.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.dvLabel2.IconGap = 3;
            this.dvLabel2.IconImage = null;
            this.dvLabel2.IconSize = 12F;
            this.dvLabel2.IconString = "fa-bookmark";
            this.dvLabel2.LabelColor = null;
            this.dvLabel2.Location = new System.Drawing.Point(0, 0);
            this.dvLabel2.Name = "dvLabel2";
            this.dvLabel2.Round = null;
            this.dvLabel2.ShadowGap = 1;
            this.dvLabel2.Size = new System.Drawing.Size(150, 27);
            this.dvLabel2.Style = Devinno.Forms.Embossing.FlatConcave;
            this.dvLabel2.TabIndex = 1;
            this.dvLabel2.TabStop = false;
            this.dvLabel2.Text = "라이브러리 참조";
            this.dvLabel2.TextPadding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.dvLabel2.Unit = "";
            this.dvLabel2.UnitWidth = null;
            // 
            // dvContainer2
            // 
            this.dvContainer2.Controls.Add(this.dvLabel1);
            this.dvContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvContainer2.Location = new System.Drawing.Point(7, 10);
            this.dvContainer2.Margin = new System.Windows.Forms.Padding(7, 10, 0, 0);
            this.dvContainer2.Name = "dvContainer2";
            this.dvContainer2.ShadowGap = 1;
            this.dvContainer2.Size = new System.Drawing.Size(243, 27);
            this.dvContainer2.TabIndex = 0;
            this.dvContainer2.TabStop = false;
            this.dvContainer2.Text = "dvContainer2";
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
            this.dvLabel1.IconString = "fa-book";
            this.dvLabel1.LabelColor = null;
            this.dvLabel1.Location = new System.Drawing.Point(0, 0);
            this.dvLabel1.Name = "dvLabel1";
            this.dvLabel1.Round = null;
            this.dvLabel1.ShadowGap = 1;
            this.dvLabel1.Size = new System.Drawing.Size(150, 27);
            this.dvLabel1.Style = Devinno.Forms.Embossing.FlatConcave;
            this.dvLabel1.TabIndex = 0;
            this.dvLabel1.TabStop = false;
            this.dvLabel1.Text = "라이브러리 목록";
            this.dvLabel1.TextPadding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.dvLabel1.Unit = "";
            this.dvLabel1.UnitWidth = null;
            // 
            // dgLibrary
            // 
            this.dgLibrary.Bevel = true;
            this.dgLibrary.BoxColor = null;
            this.dgLibrary.ColumnColor = null;
            this.dgLibrary.ColumnHeight = 30;
            this.dgLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgLibrary.HScrollPosition = 0D;
            this.dgLibrary.InputColor = null;
            this.dgLibrary.Location = new System.Drawing.Point(7, 37);
            this.dgLibrary.Margin = new System.Windows.Forms.Padding(7, 0, 0, 3);
            this.dgLibrary.Name = "dgLibrary";
            this.dgLibrary.RowColor = null;
            this.dgLibrary.RowHeight = 30;
            this.dgLibrary.ScrollMode = Devinno.Forms.Utils.ScrollMode.Vertical;
            this.dgLibrary.SelectedRowColor = null;
            this.dgLibrary.SelectionMode = Devinno.Forms.Controls.DvDataGridSelectionMode.Single;
            this.dgLibrary.ShadowGap = 1;
            this.dgLibrary.Size = new System.Drawing.Size(243, 390);
            this.dgLibrary.SummaryRowColor = null;
            this.dgLibrary.TabIndex = 2;
            this.dgLibrary.Text = "dvDataGrid1";
            this.dgLibrary.VScrollPosition = 0D;
            // 
            // dragDLL
            // 
            this.dragDLL.BackgroundDraw = true;
            this.dragDLL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.dragDLL.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.dragDLL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dragDLL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.dragDLL.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.dragDLL.IconGap = 3;
            this.dragDLL.IconImage = null;
            this.dragDLL.IconSize = 14F;
            this.dragDLL.IconString = "far fa-square-plus";
            this.dragDLL.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dragDLL.Location = new System.Drawing.Point(7, 433);
            this.dragDLL.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.dragDLL.Name = "dragDLL";
            this.dragDLL.Round = null;
            this.dragDLL.ShadowGap = 1;
            this.dragDLL.Size = new System.Drawing.Size(240, 74);
            this.dragDLL.Style = Devinno.Forms.Embossing.Flat;
            this.dragDLL.TabIndex = 3;
            this.dragDLL.TabStop = false;
            this.dragDLL.Text = "Drag & Drop";
            this.dragDLL.TextPadding = new System.Windows.Forms.Padding(0);
            this.dragDLL.Unit = "";
            this.dragDLL.UnitWidth = null;
            // 
            // dgReference
            // 
            this.dgReference.Bevel = true;
            this.dgReference.BoxColor = null;
            this.dgReference.ColumnColor = null;
            this.dgReference.ColumnHeight = 30;
            this.dgReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgReference.HScrollPosition = 0D;
            this.dgReference.InputColor = null;
            this.dgReference.Location = new System.Drawing.Point(303, 40);
            this.dgReference.Name = "dgReference";
            this.dgReference.RowColor = null;
            this.dgReference.RowHeight = 30;
            this.tpnl.SetRowSpan(this.dgReference, 2);
            this.dgReference.ScrollMode = Devinno.Forms.Utils.ScrollMode.Vertical;
            this.dgReference.SelectedRowColor = null;
            this.dgReference.SelectionMode = Devinno.Forms.Controls.DvDataGridSelectionMode.Single;
            this.dgReference.ShadowGap = 1;
            this.dgReference.Size = new System.Drawing.Size(488, 467);
            this.dgReference.SummaryRowColor = null;
            this.dgReference.TabIndex = 4;
            this.dgReference.Text = "dvDataGrid1";
            this.dgReference.VScrollPosition = 0D;
            // 
            // FormLibrary
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tpnl);
            this.Controls.Add(this.pnlButtons);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormLibrary";
            this.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.Text = "라이브러리";
            this.Title = "라이브러리";
            this.TitleIconSize = 14F;
            this.TitleIconString = "fa-book-open";
            this.pnlButtons.ResumeLayout(false);
            this.tpnl.ResumeLayout(false);
            this.dvTableLayoutPanel2.ResumeLayout(false);
            this.dvContainer3.ResumeLayout(false);
            this.dvContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer pnlButtons;
        private Devinno.Forms.Controls.DvButton btnOK;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Controls.DvButton btnCancel;
        private Devinno.Forms.Containers.DvTableLayoutPanel tpnl;
        private Devinno.Forms.Containers.DvContainer dvContainer3;
        private Devinno.Forms.Containers.DvContainer dvContainer2;
        private Devinno.Forms.Controls.DvLabel dvLabel1;
        private Devinno.Forms.Controls.DvLabel dvLabel2;
        private Devinno.Forms.Controls.DvDataGrid dgLibrary;
        private Devinno.Forms.Controls.DvLabel dragDLL;
        private Devinno.Forms.Controls.DvDataGrid dgReference;
        private Devinno.Forms.Containers.DvTableLayoutPanel dvTableLayoutPanel2;
        private Devinno.Forms.Controls.DvButton btnReg;
        private Devinno.Forms.Controls.DvButton btnUnreg;
    }
}