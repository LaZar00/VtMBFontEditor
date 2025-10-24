namespace VtMBFontEditor
{
    partial class FormManagePages
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
            LbPages = new ListBox();
            lblPages = new Label();
            lblTGAWidth = new Label();
            lblHeight = new Label();
            lblTGAOffsetName = new Label();
            TxtTGAWidth = new TextBox();
            TxtTGAHeight = new TextBox();
            TxtOffsetName = new TextBox();
            BtnAddPage = new Button();
            BtnDeletePage = new Button();
            BtnClose = new Button();
            SuspendLayout();
            // 
            // LbPages
            // 
            LbPages.Font = new Font("Segoe UI", 10.2F);
            LbPages.FormattingEnabled = true;
            LbPages.ItemHeight = 19;
            LbPages.Location = new Point(12, 28);
            LbPages.Name = "LbPages";
            LbPages.Size = new Size(115, 175);
            LbPages.TabIndex = 0;
            LbPages.SelectedIndexChanged += lbPages_SelectedIndexChanged;
            // 
            // lblPages
            // 
            lblPages.AutoSize = true;
            lblPages.Font = new Font("Segoe UI", 10.2F);
            lblPages.Location = new Point(12, 6);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(48, 19);
            lblPages.TabIndex = 1;
            lblPages.Text = "Pages:";
            // 
            // lblTGAWidth
            // 
            lblTGAWidth.AutoSize = true;
            lblTGAWidth.Font = new Font("Segoe UI", 10.2F);
            lblTGAWidth.Location = new Point(138, 24);
            lblTGAWidth.Name = "lblTGAWidth";
            lblTGAWidth.Size = new Size(78, 19);
            lblTGAWidth.TabIndex = 2;
            lblTGAWidth.Text = "TGA Width:";
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Font = new Font("Segoe UI", 10.2F);
            lblHeight.Location = new Point(138, 89);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(82, 19);
            lblHeight.TabIndex = 3;
            lblHeight.Text = "TGA Height:";
            // 
            // lblTGAOffsetName
            // 
            lblTGAOffsetName.AutoSize = true;
            lblTGAOffsetName.Font = new Font("Segoe UI", 10.2F);
            lblTGAOffsetName.Location = new Point(138, 154);
            lblTGAOffsetName.Name = "lblTGAOffsetName";
            lblTGAOffsetName.Size = new Size(118, 19);
            lblTGAOffsetName.TabIndex = 4;
            lblTGAOffsetName.Text = "TGA Offset Name:";
            // 
            // TxtTGAWidth
            // 
            TxtTGAWidth.Font = new Font("Segoe UI", 10.2F);
            TxtTGAWidth.Location = new Point(141, 46);
            TxtTGAWidth.Name = "TxtTGAWidth";
            TxtTGAWidth.Size = new Size(83, 26);
            TxtTGAWidth.TabIndex = 5;
            TxtTGAWidth.Text = "256";
            TxtTGAWidth.Validating += TxtTGAWidth_Validating;
            // 
            // TxtTGAHeight
            // 
            TxtTGAHeight.Font = new Font("Segoe UI", 10.2F);
            TxtTGAHeight.Location = new Point(141, 111);
            TxtTGAHeight.Name = "TxtTGAHeight";
            TxtTGAHeight.Size = new Size(83, 26);
            TxtTGAHeight.TabIndex = 6;
            TxtTGAHeight.Text = "256";
            TxtTGAHeight.Validating += TxtTGAHeight_Validating;
            // 
            // TxtOffsetName
            // 
            TxtOffsetName.Font = new Font("Segoe UI", 10.2F);
            TxtOffsetName.Location = new Point(141, 176);
            TxtOffsetName.Name = "TxtOffsetName";
            TxtOffsetName.ReadOnly = true;
            TxtOffsetName.Size = new Size(83, 26);
            TxtOffsetName.TabIndex = 7;
            TxtOffsetName.Text = "32";
            // 
            // BtnAddPage
            // 
            BtnAddPage.Font = new Font("Segoe UI", 10.2F);
            BtnAddPage.Location = new Point(12, 218);
            BtnAddPage.Name = "BtnAddPage";
            BtnAddPage.Size = new Size(125, 29);
            BtnAddPage.TabIndex = 8;
            BtnAddPage.Text = "Add Page";
            BtnAddPage.UseVisualStyleBackColor = true;
            BtnAddPage.Click += btnAddPage_Click;
            // 
            // BtnDeletePage
            // 
            BtnDeletePage.Enabled = false;
            BtnDeletePage.Font = new Font("Segoe UI", 10.2F);
            BtnDeletePage.Location = new Point(143, 218);
            BtnDeletePage.Name = "BtnDeletePage";
            BtnDeletePage.Size = new Size(122, 29);
            BtnDeletePage.TabIndex = 9;
            BtnDeletePage.Text = "Delete Page";
            BtnDeletePage.UseVisualStyleBackColor = true;
            BtnDeletePage.Click += btnDeletePage_Click;
            // 
            // BtnClose
            // 
            BtnClose.Font = new Font("Segoe UI", 10.2F);
            BtnClose.Location = new Point(12, 253);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(253, 29);
            BtnClose.TabIndex = 11;
            BtnClose.Text = "Close";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += btnClose_Click;
            // 
            // FormManagePages
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaption;
            CancelButton = BtnClose;
            ClientSize = new Size(277, 294);
            Controls.Add(BtnClose);
            Controls.Add(BtnDeletePage);
            Controls.Add(BtnAddPage);
            Controls.Add(TxtOffsetName);
            Controls.Add(TxtTGAHeight);
            Controls.Add(TxtTGAWidth);
            Controls.Add(lblTGAOffsetName);
            Controls.Add(lblHeight);
            Controls.Add(lblTGAWidth);
            Controls.Add(lblPages);
            Controls.Add(LbPages);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormManagePages";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Pages";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox LbPages;
        private Label lblPages;
        private Label lblTGAWidth;
        private Label lblHeight;
        private Label lblTGAOffsetName;
        private TextBox TxtTGAWidth;
        private TextBox TxtTGAHeight;
        private TextBox TxtOffsetName;
        private Button BtnAddPage;
        private Button BtnDeletePage;
        private Button BtnClose;
    }
}