namespace VtMBFontEditor
{
    partial class FontEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontEditor));
            PanelPbFont = new WheelessPanel();
            pbFont = new PictureBox();
            LblFontFile = new Label();
            TxtFontFile = new TextBox();
            BtnLoadFont = new Button();
            OpenFileDlg = new OpenFileDialog();
            GbGlobalFontValues = new GroupBox();
            btnManagePages = new Button();
            GBDistances = new GroupBox();
            TxtDistBottom = new TextBox();
            LblDistLeft = new Label();
            LblDistBottom = new Label();
            TxtDistLeft = new TextBox();
            TxtDistUp = new TextBox();
            LblDistRight = new Label();
            LblDistUp = new Label();
            TxtDistRight = new TextBox();
            TxtLineSpacing = new TextBox();
            LblLineSpacing = new Label();
            TxtPages = new TextBox();
            LblPages = new Label();
            LbChars = new ListBox();
            LblXtopL = new Label();
            LblYTopL = new Label();
            LblXBottomR = new Label();
            LblYBottom = new Label();
            TxtXtopL = new TextBox();
            TxtYtopL = new TextBox();
            TxtXbottomR = new TextBox();
            TxtYbottomR = new TextBox();
            LblInternalCharTable = new Label();
            TxtCharInfoIndex = new TextBox();
            LblCharInfoTableIndex = new Label();
            BtnUpdateCoords = new Button();
            GbCharInfoValues = new GroupBox();
            TxtVal28 = new TextBox();
            TxtVal27 = new TextBox();
            TxtVal26 = new TextBox();
            TxtPage = new TextBox();
            TxtVal24 = new TextBox();
            TxtVal23 = new TextBox();
            TxtVal22 = new TextBox();
            TxtVal21 = new TextBox();
            TxtVal20 = new TextBox();
            TxtVal19 = new TextBox();
            TxtVal18 = new TextBox();
            TxtVal17 = new TextBox();
            TxtVal16 = new TextBox();
            TxtVal15 = new TextBox();
            LbVal28 = new Label();
            LbVal27CharW = new Label();
            LbVal26 = new Label();
            LbVal25Page = new Label();
            LbVal24 = new Label();
            LbVal23 = new Label();
            LbVal22 = new Label();
            LbVal21 = new Label();
            LbVal20 = new Label();
            LbVal19RSpacing = new Label();
            LbVal18CharW = new Label();
            LbVal17LSpacing = new Label();
            LbVal16 = new Label();
            LbVal15 = new Label();
            TxtVal14 = new TextBox();
            TxtVal13 = new TextBox();
            TxtVal12 = new TextBox();
            TxtVal11 = new TextBox();
            TxtVal10 = new TextBox();
            TxtVal9 = new TextBox();
            TxtVal8 = new TextBox();
            TxtVal7 = new TextBox();
            TxtVal6 = new TextBox();
            TxtVal5 = new TextBox();
            TxtVal4 = new TextBox();
            TxtVal3 = new TextBox();
            TxtVal2 = new TextBox();
            TxtVal1 = new TextBox();
            LbVal14 = new Label();
            LbVal13 = new Label();
            LbVal12 = new Label();
            LbVal11 = new Label();
            LbVal10 = new Label();
            LbVal9 = new Label();
            LbVal8 = new Label();
            LbVal7 = new Label();
            LbVal6 = new Label();
            LbVal5 = new Label();
            LbVal4 = new Label();
            LbVal3 = new Label();
            LbVal2 = new Label();
            LbVal1 = new Label();
            GbCharCoord = new GroupBox();
            BtnSaveFont = new Button();
            BtnSaveFontAs = new Button();
            btnClose = new Button();
            BtnUpdateValues = new Button();
            SaveFileDlg = new SaveFileDialog();
            CbTGAList = new ComboBox();
            LblTGAFile = new Label();
            BtnRegen = new Button();
            lblCodepage = new Label();
            CbCodepage = new ComboBox();
            TxtMaxChars = new TextBox();
            lblMaxChars = new Label();
            ChkEnabled = new CheckBox();
            TbZoom = new TrackBar();
            TxtZoom = new TextBox();
            GbZoom = new GroupBox();
            txtWidth = new TextBox();
            txtHeight = new TextBox();
            lblW = new Label();
            lblH = new Label();
            BtnUpdateCoordsCharVals = new Button();
            PanelPbFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFont).BeginInit();
            GbGlobalFontValues.SuspendLayout();
            GBDistances.SuspendLayout();
            GbCharInfoValues.SuspendLayout();
            GbCharCoord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TbZoom).BeginInit();
            GbZoom.SuspendLayout();
            SuspendLayout();
            // 
            // PanelPbFont
            // 
            PanelPbFont.AutoScroll = true;
            PanelPbFont.BackColor = SystemColors.WindowText;
            PanelPbFont.BorderStyle = BorderStyle.Fixed3D;
            PanelPbFont.Controls.Add(pbFont);
            PanelPbFont.Location = new Point(9, 61);
            PanelPbFont.Name = "PanelPbFont";
            PanelPbFont.Size = new Size(518, 518);
            PanelPbFont.TabIndex = 0;
            // 
            // pbFont
            // 
            pbFont.BackColor = Color.Black;
            pbFont.Location = new Point(1, 1);
            pbFont.Name = "pbFont";
            pbFont.Size = new Size(512, 512);
            pbFont.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFont.TabIndex = 0;
            pbFont.TabStop = false;
            pbFont.Paint += pbFont_Paint;
            pbFont.MouseClick += pbFont_MouseClick;
            pbFont.MouseDown += pbFont_MouseDown;
            pbFont.MouseEnter += pbFont_MouseEnter;
            pbFont.MouseLeave += pbFont_MouseLeave;
            pbFont.MouseMove += pbFont_MouseMove;
            pbFont.MouseUp += pbFont_MouseUp;
            pbFont.MouseWheel += PbFont_MouseWheel;
            // 
            // LblFontFile
            // 
            LblFontFile.AutoSize = true;
            LblFontFile.Font = new Font("Segoe UI", 9F);
            LblFontFile.Location = new Point(4, 9);
            LblFontFile.Name = "LblFontFile";
            LblFontFile.Size = new Size(55, 15);
            LblFontFile.TabIndex = 1;
            LblFontFile.Text = "Font File:";
            // 
            // TxtFontFile
            // 
            TxtFontFile.Font = new Font("Segoe UI", 9F);
            TxtFontFile.Location = new Point(63, 5);
            TxtFontFile.Name = "TxtFontFile";
            TxtFontFile.ReadOnly = true;
            TxtFontFile.Size = new Size(588, 23);
            TxtFontFile.TabIndex = 2;
            // 
            // BtnLoadFont
            // 
            BtnLoadFont.Font = new Font("Segoe UI", 9F);
            BtnLoadFont.Location = new Point(658, 3);
            BtnLoadFont.Name = "BtnLoadFont";
            BtnLoadFont.Size = new Size(414, 27);
            BtnLoadFont.TabIndex = 3;
            BtnLoadFont.Text = "Load .fnt";
            BtnLoadFont.UseVisualStyleBackColor = true;
            BtnLoadFont.Click += BtnLoadFont_Click;
            // 
            // GbGlobalFontValues
            // 
            GbGlobalFontValues.Controls.Add(btnManagePages);
            GbGlobalFontValues.Controls.Add(GBDistances);
            GbGlobalFontValues.Controls.Add(TxtLineSpacing);
            GbGlobalFontValues.Controls.Add(LblLineSpacing);
            GbGlobalFontValues.Controls.Add(TxtPages);
            GbGlobalFontValues.Controls.Add(LblPages);
            GbGlobalFontValues.Enabled = false;
            GbGlobalFontValues.Font = new Font("Segoe UI", 9F);
            GbGlobalFontValues.Location = new Point(699, 61);
            GbGlobalFontValues.Name = "GbGlobalFontValues";
            GbGlobalFontValues.Size = new Size(373, 117);
            GbGlobalFontValues.TabIndex = 7;
            GbGlobalFontValues.TabStop = false;
            GbGlobalFontValues.Text = "Global Font Values";
            // 
            // btnManagePages
            // 
            btnManagePages.Font = new Font("Segoe UI", 9F);
            btnManagePages.Location = new Point(103, 22);
            btnManagePages.Name = "btnManagePages";
            btnManagePages.Size = new Size(78, 24);
            btnManagePages.TabIndex = 13;
            btnManagePages.Text = "Manage";
            btnManagePages.UseVisualStyleBackColor = true;
            btnManagePages.Click += btnManagePages_Click;
            // 
            // GBDistances
            // 
            GBDistances.Controls.Add(TxtDistBottom);
            GBDistances.Controls.Add(LblDistLeft);
            GBDistances.Controls.Add(LblDistBottom);
            GBDistances.Controls.Add(TxtDistLeft);
            GBDistances.Controls.Add(TxtDistUp);
            GBDistances.Controls.Add(LblDistRight);
            GBDistances.Controls.Add(LblDistUp);
            GBDistances.Controls.Add(TxtDistRight);
            GBDistances.Font = new Font("Segoe UI", 9F);
            GBDistances.Location = new Point(8, 52);
            GBDistances.Name = "GBDistances";
            GBDistances.Size = new Size(355, 55);
            GBDistances.TabIndex = 12;
            GBDistances.TabStop = false;
            GBDistances.Text = "Distances (?)";
            // 
            // TxtDistBottom
            // 
            TxtDistBottom.Font = new Font("Segoe UI", 9F);
            TxtDistBottom.Location = new Point(307, 19);
            TxtDistBottom.Name = "TxtDistBottom";
            TxtDistBottom.Size = new Size(37, 23);
            TxtDistBottom.TabIndex = 11;
            // 
            // LblDistLeft
            // 
            LblDistLeft.AutoSize = true;
            LblDistLeft.Font = new Font("Segoe UI", 9F);
            LblDistLeft.Location = new Point(6, 23);
            LblDistLeft.Name = "LblDistLeft";
            LblDistLeft.Size = new Size(30, 15);
            LblDistLeft.TabIndex = 4;
            LblDistLeft.Text = "Left:";
            // 
            // LblDistBottom
            // 
            LblDistBottom.AutoSize = true;
            LblDistBottom.Font = new Font("Segoe UI", 9F);
            LblDistBottom.Location = new Point(255, 22);
            LblDistBottom.Name = "LblDistBottom";
            LblDistBottom.Size = new Size(50, 15);
            LblDistBottom.TabIndex = 10;
            LblDistBottom.Text = "Bottom:";
            // 
            // TxtDistLeft
            // 
            TxtDistLeft.Font = new Font("Segoe UI", 9F);
            TxtDistLeft.Location = new Point(38, 20);
            TxtDistLeft.Name = "TxtDistLeft";
            TxtDistLeft.Size = new Size(37, 23);
            TxtDistLeft.TabIndex = 5;
            // 
            // TxtDistUp
            // 
            TxtDistUp.Font = new Font("Segoe UI", 9F);
            TxtDistUp.Location = new Point(206, 19);
            TxtDistUp.Name = "TxtDistUp";
            TxtDistUp.Size = new Size(37, 23);
            TxtDistUp.TabIndex = 9;
            // 
            // LblDistRight
            // 
            LblDistRight.AutoSize = true;
            LblDistRight.Font = new Font("Segoe UI", 9F);
            LblDistRight.Location = new Point(89, 23);
            LblDistRight.Name = "LblDistRight";
            LblDistRight.Size = new Size(38, 15);
            LblDistRight.TabIndex = 6;
            LblDistRight.Text = "Right:";
            // 
            // LblDistUp
            // 
            LblDistUp.AutoSize = true;
            LblDistUp.Font = new Font("Segoe UI", 9F);
            LblDistUp.Location = new Point(179, 22);
            LblDistUp.Name = "LblDistUp";
            LblDistUp.Size = new Size(25, 15);
            LblDistUp.TabIndex = 8;
            LblDistUp.Text = "Up:";
            // 
            // TxtDistRight
            // 
            TxtDistRight.Font = new Font("Segoe UI", 9F);
            TxtDistRight.Location = new Point(129, 19);
            TxtDistRight.Name = "TxtDistRight";
            TxtDistRight.Size = new Size(37, 23);
            TxtDistRight.TabIndex = 7;
            // 
            // TxtLineSpacing
            // 
            TxtLineSpacing.Font = new Font("Segoe UI", 9F);
            TxtLineSpacing.Location = new Point(308, 23);
            TxtLineSpacing.Name = "TxtLineSpacing";
            TxtLineSpacing.Size = new Size(43, 23);
            TxtLineSpacing.TabIndex = 3;
            // 
            // LblLineSpacing
            // 
            LblLineSpacing.AutoSize = true;
            LblLineSpacing.Font = new Font("Segoe UI", 9F);
            LblLineSpacing.Location = new Point(228, 26);
            LblLineSpacing.Name = "LblLineSpacing";
            LblLineSpacing.Size = new Size(77, 15);
            LblLineSpacing.TabIndex = 2;
            LblLineSpacing.Text = "Line Spacing:";
            // 
            // TxtPages
            // 
            TxtPages.Font = new Font("Segoe UI", 9F);
            TxtPages.Location = new Point(59, 23);
            TxtPages.Name = "TxtPages";
            TxtPages.ReadOnly = true;
            TxtPages.Size = new Size(43, 23);
            TxtPages.TabIndex = 1;
            // 
            // LblPages
            // 
            LblPages.AutoSize = true;
            LblPages.Font = new Font("Segoe UI", 9F);
            LblPages.Location = new Point(14, 26);
            LblPages.Name = "LblPages";
            LblPages.Size = new Size(41, 15);
            LblPages.TabIndex = 0;
            LblPages.Text = "Pages:";
            // 
            // LbChars
            // 
            LbChars.Font = new Font("Lucida Console", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbChars.FormattingEnabled = true;
            LbChars.ItemHeight = 14;
            LbChars.Location = new Point(535, 197);
            LbChars.Name = "LbChars";
            LbChars.ScrollAlwaysVisible = true;
            LbChars.Size = new Size(180, 382);
            LbChars.TabIndex = 8;
            LbChars.SelectedIndexChanged += lbChars_SelectedIndexChanged;
            LbChars.Leave += LbChars_Leave;
            // 
            // LblXtopL
            // 
            LblXtopL.AutoSize = true;
            LblXtopL.Font = new Font("Segoe UI", 9F);
            LblXtopL.Location = new Point(36, 22);
            LblXtopL.Name = "LblXtopL";
            LblXtopL.Size = new Size(75, 15);
            LblXtopL.TabIndex = 9;
            LblXtopL.Text = "X/Y Top Left:";
            // 
            // LblYTopL
            // 
            LblYTopL.AutoSize = true;
            LblYTopL.Font = new Font("Segoe UI", 9F);
            LblYTopL.Location = new Point(168, 22);
            LblYTopL.Name = "LblYTopL";
            LblYTopL.Size = new Size(12, 15);
            LblYTopL.TabIndex = 10;
            LblYTopL.Text = "/";
            // 
            // LblXBottomR
            // 
            LblXBottomR.AutoSize = true;
            LblXBottomR.Font = new Font("Segoe UI", 9F);
            LblXBottomR.Location = new Point(8, 47);
            LblXBottomR.Name = "LblXBottomR";
            LblXBottomR.Size = new Size(103, 15);
            LblXBottomR.TabIndex = 11;
            LblXBottomR.Text = "X/Y Bottom Right:";
            // 
            // LblYBottom
            // 
            LblYBottom.AutoSize = true;
            LblYBottom.Font = new Font("Segoe UI", 9F);
            LblYBottom.Location = new Point(168, 47);
            LblYBottom.Name = "LblYBottom";
            LblYBottom.Size = new Size(12, 15);
            LblYBottom.TabIndex = 12;
            LblYBottom.Text = "/";
            // 
            // TxtXtopL
            // 
            TxtXtopL.Font = new Font("Segoe UI", 9F);
            TxtXtopL.Location = new Point(121, 19);
            TxtXtopL.Name = "TxtXtopL";
            TxtXtopL.Size = new Size(41, 23);
            TxtXtopL.TabIndex = 13;
            TxtXtopL.Validating += TxtXtopL_Validating;
            // 
            // TxtYtopL
            // 
            TxtYtopL.Font = new Font("Segoe UI", 9F);
            TxtYtopL.Location = new Point(183, 19);
            TxtYtopL.Name = "TxtYtopL";
            TxtYtopL.Size = new Size(41, 23);
            TxtYtopL.TabIndex = 14;
            TxtYtopL.Validating += TxtYtopL_Validating;
            // 
            // TxtXbottomR
            // 
            TxtXbottomR.Font = new Font("Segoe UI", 9F);
            TxtXbottomR.Location = new Point(121, 44);
            TxtXbottomR.Name = "TxtXbottomR";
            TxtXbottomR.Size = new Size(41, 23);
            TxtXbottomR.TabIndex = 15;
            TxtXbottomR.Validating += TxtXbottomR_Validating;
            // 
            // TxtYbottomR
            // 
            TxtYbottomR.Font = new Font("Segoe UI", 9F);
            TxtYbottomR.Location = new Point(183, 44);
            TxtYbottomR.Name = "TxtYbottomR";
            TxtYbottomR.Size = new Size(41, 23);
            TxtYbottomR.TabIndex = 16;
            TxtYbottomR.Validating += TxtYbottomR_Validating;
            // 
            // LblInternalCharTable
            // 
            LblInternalCharTable.AutoSize = true;
            LblInternalCharTable.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblInternalCharTable.Location = new Point(535, 180);
            LblInternalCharTable.Name = "LblInternalCharTable";
            LblInternalCharTable.Size = new Size(147, 15);
            LblInternalCharTable.TabIndex = 17;
            LblInternalCharTable.Text = "InternalTable (Index/Char):";
            // 
            // TxtCharInfoIndex
            // 
            TxtCharInfoIndex.Font = new Font("Segoe UI", 9F);
            TxtCharInfoIndex.Location = new Point(628, 81);
            TxtCharInfoIndex.MaxLength = 4;
            TxtCharInfoIndex.Name = "TxtCharInfoIndex";
            TxtCharInfoIndex.ReadOnly = true;
            TxtCharInfoIndex.ShortcutsEnabled = false;
            TxtCharInfoIndex.Size = new Size(40, 23);
            TxtCharInfoIndex.TabIndex = 18;
            TxtCharInfoIndex.WordWrap = false;
            // 
            // LblCharInfoTableIndex
            // 
            LblCharInfoTableIndex.AutoSize = true;
            LblCharInfoTableIndex.Font = new Font("Segoe UI", 9F);
            LblCharInfoTableIndex.Location = new Point(556, 84);
            LblCharInfoTableIndex.Name = "LblCharInfoTableIndex";
            LblCharInfoTableIndex.Size = new Size(66, 15);
            LblCharInfoTableIndex.TabIndex = 19;
            LblCharInfoTableIndex.Text = "Char Index:";
            // 
            // BtnUpdateCoords
            // 
            BtnUpdateCoords.Enabled = false;
            BtnUpdateCoords.Font = new Font("Segoe UI", 9F);
            BtnUpdateCoords.Location = new Point(535, 594);
            BtnUpdateCoords.Name = "BtnUpdateCoords";
            BtnUpdateCoords.Size = new Size(169, 27);
            BtnUpdateCoords.TabIndex = 20;
            BtnUpdateCoords.Text = "Update Coordinates";
            BtnUpdateCoords.UseVisualStyleBackColor = true;
            BtnUpdateCoords.Click += BtnUpdateCoords_Click;
            // 
            // GbCharInfoValues
            // 
            GbCharInfoValues.Controls.Add(TxtVal28);
            GbCharInfoValues.Controls.Add(TxtVal27);
            GbCharInfoValues.Controls.Add(TxtVal26);
            GbCharInfoValues.Controls.Add(TxtPage);
            GbCharInfoValues.Controls.Add(TxtVal24);
            GbCharInfoValues.Controls.Add(TxtVal23);
            GbCharInfoValues.Controls.Add(TxtVal22);
            GbCharInfoValues.Controls.Add(TxtVal21);
            GbCharInfoValues.Controls.Add(TxtVal20);
            GbCharInfoValues.Controls.Add(TxtVal19);
            GbCharInfoValues.Controls.Add(TxtVal18);
            GbCharInfoValues.Controls.Add(TxtVal17);
            GbCharInfoValues.Controls.Add(TxtVal16);
            GbCharInfoValues.Controls.Add(TxtVal15);
            GbCharInfoValues.Controls.Add(LbVal28);
            GbCharInfoValues.Controls.Add(LbVal27CharW);
            GbCharInfoValues.Controls.Add(LbVal26);
            GbCharInfoValues.Controls.Add(LbVal25Page);
            GbCharInfoValues.Controls.Add(LbVal24);
            GbCharInfoValues.Controls.Add(LbVal23);
            GbCharInfoValues.Controls.Add(LbVal22);
            GbCharInfoValues.Controls.Add(LbVal21);
            GbCharInfoValues.Controls.Add(LbVal20);
            GbCharInfoValues.Controls.Add(LbVal19RSpacing);
            GbCharInfoValues.Controls.Add(LbVal18CharW);
            GbCharInfoValues.Controls.Add(LbVal17LSpacing);
            GbCharInfoValues.Controls.Add(LbVal16);
            GbCharInfoValues.Controls.Add(LbVal15);
            GbCharInfoValues.Controls.Add(TxtVal14);
            GbCharInfoValues.Controls.Add(TxtVal13);
            GbCharInfoValues.Controls.Add(TxtVal12);
            GbCharInfoValues.Controls.Add(TxtVal11);
            GbCharInfoValues.Controls.Add(TxtVal10);
            GbCharInfoValues.Controls.Add(TxtVal9);
            GbCharInfoValues.Controls.Add(TxtVal8);
            GbCharInfoValues.Controls.Add(TxtVal7);
            GbCharInfoValues.Controls.Add(TxtVal6);
            GbCharInfoValues.Controls.Add(TxtVal5);
            GbCharInfoValues.Controls.Add(TxtVal4);
            GbCharInfoValues.Controls.Add(TxtVal3);
            GbCharInfoValues.Controls.Add(TxtVal2);
            GbCharInfoValues.Controls.Add(TxtVal1);
            GbCharInfoValues.Controls.Add(LbVal14);
            GbCharInfoValues.Controls.Add(LbVal13);
            GbCharInfoValues.Controls.Add(LbVal12);
            GbCharInfoValues.Controls.Add(LbVal11);
            GbCharInfoValues.Controls.Add(LbVal10);
            GbCharInfoValues.Controls.Add(LbVal9);
            GbCharInfoValues.Controls.Add(LbVal8);
            GbCharInfoValues.Controls.Add(LbVal7);
            GbCharInfoValues.Controls.Add(LbVal6);
            GbCharInfoValues.Controls.Add(LbVal5);
            GbCharInfoValues.Controls.Add(LbVal4);
            GbCharInfoValues.Controls.Add(LbVal3);
            GbCharInfoValues.Controls.Add(LbVal2);
            GbCharInfoValues.Controls.Add(LbVal1);
            GbCharInfoValues.Enabled = false;
            GbCharInfoValues.Font = new Font("Segoe UI", 9F);
            GbCharInfoValues.Location = new Point(724, 183);
            GbCharInfoValues.Name = "GbCharInfoValues";
            GbCharInfoValues.Size = new Size(348, 397);
            GbCharInfoValues.TabIndex = 21;
            GbCharInfoValues.TabStop = false;
            GbCharInfoValues.Text = "Char Values";
            // 
            // TxtVal28
            // 
            TxtVal28.Font = new Font("Segoe UI", 9F);
            TxtVal28.Location = new Point(269, 363);
            TxtVal28.Name = "TxtVal28";
            TxtVal28.Size = new Size(71, 23);
            TxtVal28.TabIndex = 56;
            TxtVal28.WordWrap = false;
            // 
            // TxtVal27
            // 
            TxtVal27.Font = new Font("Segoe UI", 9F);
            TxtVal27.Location = new Point(269, 337);
            TxtVal27.Name = "TxtVal27";
            TxtVal27.Size = new Size(71, 23);
            TxtVal27.TabIndex = 55;
            TxtVal27.WordWrap = false;
            // 
            // TxtVal26
            // 
            TxtVal26.Font = new Font("Segoe UI", 9F);
            TxtVal26.Location = new Point(269, 311);
            TxtVal26.Name = "TxtVal26";
            TxtVal26.Size = new Size(71, 23);
            TxtVal26.TabIndex = 54;
            TxtVal26.WordWrap = false;
            // 
            // TxtPage
            // 
            TxtPage.Font = new Font("Segoe UI", 9F);
            TxtPage.Location = new Point(269, 285);
            TxtPage.Name = "TxtPage";
            TxtPage.Size = new Size(71, 23);
            TxtPage.TabIndex = 53;
            TxtPage.WordWrap = false;
            TxtPage.Validating += TxtPage_Validating;
            // 
            // TxtVal24
            // 
            TxtVal24.Font = new Font("Segoe UI", 9F);
            TxtVal24.Location = new Point(269, 259);
            TxtVal24.Name = "TxtVal24";
            TxtVal24.Size = new Size(71, 23);
            TxtVal24.TabIndex = 52;
            TxtVal24.WordWrap = false;
            // 
            // TxtVal23
            // 
            TxtVal23.Font = new Font("Segoe UI", 9F);
            TxtVal23.Location = new Point(269, 233);
            TxtVal23.Name = "TxtVal23";
            TxtVal23.Size = new Size(71, 23);
            TxtVal23.TabIndex = 51;
            TxtVal23.WordWrap = false;
            // 
            // TxtVal22
            // 
            TxtVal22.Font = new Font("Segoe UI", 9F);
            TxtVal22.Location = new Point(269, 207);
            TxtVal22.Name = "TxtVal22";
            TxtVal22.Size = new Size(71, 23);
            TxtVal22.TabIndex = 50;
            TxtVal22.WordWrap = false;
            // 
            // TxtVal21
            // 
            TxtVal21.Font = new Font("Segoe UI", 9F);
            TxtVal21.Location = new Point(269, 181);
            TxtVal21.Name = "TxtVal21";
            TxtVal21.Size = new Size(71, 23);
            TxtVal21.TabIndex = 49;
            TxtVal21.WordWrap = false;
            // 
            // TxtVal20
            // 
            TxtVal20.Font = new Font("Segoe UI", 9F);
            TxtVal20.Location = new Point(269, 155);
            TxtVal20.Name = "TxtVal20";
            TxtVal20.Size = new Size(71, 23);
            TxtVal20.TabIndex = 48;
            TxtVal20.WordWrap = false;
            // 
            // TxtVal19
            // 
            TxtVal19.Font = new Font("Segoe UI", 9F);
            TxtVal19.Location = new Point(269, 129);
            TxtVal19.Name = "TxtVal19";
            TxtVal19.Size = new Size(71, 23);
            TxtVal19.TabIndex = 47;
            TxtVal19.WordWrap = false;
            // 
            // TxtVal18
            // 
            TxtVal18.Font = new Font("Segoe UI", 9F);
            TxtVal18.Location = new Point(269, 103);
            TxtVal18.Name = "TxtVal18";
            TxtVal18.Size = new Size(71, 23);
            TxtVal18.TabIndex = 46;
            TxtVal18.WordWrap = false;
            // 
            // TxtVal17
            // 
            TxtVal17.Font = new Font("Segoe UI", 9F);
            TxtVal17.Location = new Point(269, 77);
            TxtVal17.Name = "TxtVal17";
            TxtVal17.Size = new Size(71, 23);
            TxtVal17.TabIndex = 45;
            TxtVal17.WordWrap = false;
            // 
            // TxtVal16
            // 
            TxtVal16.Font = new Font("Segoe UI", 9F);
            TxtVal16.Location = new Point(269, 51);
            TxtVal16.Name = "TxtVal16";
            TxtVal16.Size = new Size(71, 23);
            TxtVal16.TabIndex = 44;
            TxtVal16.WordWrap = false;
            // 
            // TxtVal15
            // 
            TxtVal15.Font = new Font("Segoe UI", 9F);
            TxtVal15.Location = new Point(269, 25);
            TxtVal15.Name = "TxtVal15";
            TxtVal15.Size = new Size(71, 23);
            TxtVal15.TabIndex = 43;
            TxtVal15.WordWrap = false;
            // 
            // LbVal28
            // 
            LbVal28.AutoSize = true;
            LbVal28.Font = new Font("Segoe UI", 9F);
            LbVal28.Location = new Point(223, 366);
            LbVal28.Name = "LbVal28";
            LbVal28.Size = new Size(37, 15);
            LbVal28.TabIndex = 42;
            LbVal28.Text = "Val28:";
            // 
            // LbVal27CharW
            // 
            LbVal27CharW.AutoSize = true;
            LbVal27CharW.Font = new Font("Segoe UI", 9F);
            LbVal27CharW.Location = new Point(213, 340);
            LbVal27CharW.Name = "LbVal27CharW";
            LbVal27CharW.Size = new Size(55, 15);
            LbVal27CharW.TabIndex = 41;
            LbVal27CharW.Text = "Char. W.:";
            // 
            // LbVal26
            // 
            LbVal26.AutoSize = true;
            LbVal26.Font = new Font("Segoe UI", 9F);
            LbVal26.Location = new Point(223, 314);
            LbVal26.Name = "LbVal26";
            LbVal26.Size = new Size(37, 15);
            LbVal26.TabIndex = 40;
            LbVal26.Text = "Val26:";
            // 
            // LbVal25Page
            // 
            LbVal25Page.AutoSize = true;
            LbVal25Page.Font = new Font("Segoe UI", 9F);
            LbVal25Page.Location = new Point(224, 288);
            LbVal25Page.Name = "LbVal25Page";
            LbVal25Page.Size = new Size(36, 15);
            LbVal25Page.TabIndex = 39;
            LbVal25Page.Text = "Page:";
            // 
            // LbVal24
            // 
            LbVal24.AutoSize = true;
            LbVal24.Font = new Font("Segoe UI", 9F);
            LbVal24.Location = new Point(188, 262);
            LbVal24.Name = "LbVal24";
            LbVal24.Size = new Size(72, 15);
            LbVal24.TabIndex = 38;
            LbVal24.Text = "Bot. Scaling:";
            // 
            // LbVal23
            // 
            LbVal23.AutoSize = true;
            LbVal23.Font = new Font("Segoe UI", 9F);
            LbVal23.Location = new Point(184, 236);
            LbVal23.Name = "LbVal23";
            LbVal23.Size = new Size(76, 15);
            LbVal23.TabIndex = 37;
            LbVal23.Text = "Bot. Spacing:";
            // 
            // LbVal22
            // 
            LbVal22.AutoSize = true;
            LbVal22.Font = new Font("Segoe UI", 9F);
            LbVal22.Location = new Point(189, 210);
            LbVal22.Name = "LbVal22";
            LbVal22.Size = new Size(71, 15);
            LbVal22.TabIndex = 36;
            LbVal22.Text = "Top Scaling:";
            // 
            // LbVal21
            // 
            LbVal21.AutoSize = true;
            LbVal21.Font = new Font("Segoe UI", 9F);
            LbVal21.Location = new Point(185, 184);
            LbVal21.Name = "LbVal21";
            LbVal21.Size = new Size(75, 15);
            LbVal21.TabIndex = 35;
            LbVal21.Text = "Top Spacing:";
            // 
            // LbVal20
            // 
            LbVal20.AutoSize = true;
            LbVal20.Font = new Font("Segoe UI", 9F);
            LbVal20.Location = new Point(223, 158);
            LbVal20.Name = "LbVal20";
            LbVal20.Size = new Size(37, 15);
            LbVal20.TabIndex = 34;
            LbVal20.Text = "Val20:";
            // 
            // LbVal19RSpacing
            // 
            LbVal19RSpacing.AutoSize = true;
            LbVal19RSpacing.Font = new Font("Segoe UI", 9F);
            LbVal19RSpacing.Location = new Point(195, 132);
            LbVal19RSpacing.Name = "LbVal19RSpacing";
            LbVal19RSpacing.Size = new Size(65, 15);
            LbVal19RSpacing.TabIndex = 33;
            LbVal19RSpacing.Text = "R. Spacing:";
            // 
            // LbVal18CharW
            // 
            LbVal18CharW.AutoSize = true;
            LbVal18CharW.Font = new Font("Segoe UI", 9F);
            LbVal18CharW.Location = new Point(213, 106);
            LbVal18CharW.Name = "LbVal18CharW";
            LbVal18CharW.Size = new Size(55, 15);
            LbVal18CharW.TabIndex = 32;
            LbVal18CharW.Text = "Char. W.:";
            // 
            // LbVal17LSpacing
            // 
            LbVal17LSpacing.AutoSize = true;
            LbVal17LSpacing.Font = new Font("Segoe UI", 9F);
            LbVal17LSpacing.Location = new Point(196, 80);
            LbVal17LSpacing.Name = "LbVal17LSpacing";
            LbVal17LSpacing.Size = new Size(64, 15);
            LbVal17LSpacing.TabIndex = 31;
            LbVal17LSpacing.Text = "L. Spacing:";
            // 
            // LbVal16
            // 
            LbVal16.AutoSize = true;
            LbVal16.Font = new Font("Segoe UI", 9F);
            LbVal16.Location = new Point(223, 54);
            LbVal16.Name = "LbVal16";
            LbVal16.Size = new Size(37, 15);
            LbVal16.TabIndex = 30;
            LbVal16.Text = "Val16:";
            // 
            // LbVal15
            // 
            LbVal15.AutoSize = true;
            LbVal15.Font = new Font("Segoe UI", 9F);
            LbVal15.Location = new Point(223, 28);
            LbVal15.Name = "LbVal15";
            LbVal15.Size = new Size(37, 15);
            LbVal15.TabIndex = 29;
            LbVal15.Text = "Val15:";
            // 
            // TxtVal14
            // 
            TxtVal14.Font = new Font("Segoe UI", 9F);
            TxtVal14.Location = new Point(69, 363);
            TxtVal14.Name = "TxtVal14";
            TxtVal14.Size = new Size(71, 23);
            TxtVal14.TabIndex = 28;
            TxtVal14.WordWrap = false;
            // 
            // TxtVal13
            // 
            TxtVal13.Font = new Font("Segoe UI", 9F);
            TxtVal13.Location = new Point(69, 337);
            TxtVal13.Name = "TxtVal13";
            TxtVal13.Size = new Size(71, 23);
            TxtVal13.TabIndex = 27;
            TxtVal13.WordWrap = false;
            // 
            // TxtVal12
            // 
            TxtVal12.Font = new Font("Segoe UI", 9F);
            TxtVal12.Location = new Point(69, 311);
            TxtVal12.Name = "TxtVal12";
            TxtVal12.Size = new Size(71, 23);
            TxtVal12.TabIndex = 26;
            TxtVal12.WordWrap = false;
            // 
            // TxtVal11
            // 
            TxtVal11.Font = new Font("Segoe UI", 9F);
            TxtVal11.Location = new Point(69, 285);
            TxtVal11.Name = "TxtVal11";
            TxtVal11.Size = new Size(71, 23);
            TxtVal11.TabIndex = 25;
            TxtVal11.WordWrap = false;
            // 
            // TxtVal10
            // 
            TxtVal10.Font = new Font("Segoe UI", 9F);
            TxtVal10.Location = new Point(69, 259);
            TxtVal10.Name = "TxtVal10";
            TxtVal10.Size = new Size(71, 23);
            TxtVal10.TabIndex = 24;
            TxtVal10.WordWrap = false;
            // 
            // TxtVal9
            // 
            TxtVal9.Font = new Font("Segoe UI", 9F);
            TxtVal9.Location = new Point(69, 233);
            TxtVal9.Name = "TxtVal9";
            TxtVal9.Size = new Size(71, 23);
            TxtVal9.TabIndex = 23;
            TxtVal9.WordWrap = false;
            // 
            // TxtVal8
            // 
            TxtVal8.Font = new Font("Segoe UI", 9F);
            TxtVal8.Location = new Point(69, 207);
            TxtVal8.Name = "TxtVal8";
            TxtVal8.Size = new Size(71, 23);
            TxtVal8.TabIndex = 22;
            TxtVal8.WordWrap = false;
            // 
            // TxtVal7
            // 
            TxtVal7.Font = new Font("Segoe UI", 9F);
            TxtVal7.Location = new Point(69, 181);
            TxtVal7.Name = "TxtVal7";
            TxtVal7.Size = new Size(71, 23);
            TxtVal7.TabIndex = 21;
            TxtVal7.WordWrap = false;
            // 
            // TxtVal6
            // 
            TxtVal6.Font = new Font("Segoe UI", 9F);
            TxtVal6.Location = new Point(69, 155);
            TxtVal6.Name = "TxtVal6";
            TxtVal6.Size = new Size(71, 23);
            TxtVal6.TabIndex = 20;
            TxtVal6.WordWrap = false;
            // 
            // TxtVal5
            // 
            TxtVal5.Font = new Font("Segoe UI", 9F);
            TxtVal5.Location = new Point(69, 129);
            TxtVal5.Name = "TxtVal5";
            TxtVal5.Size = new Size(71, 23);
            TxtVal5.TabIndex = 19;
            TxtVal5.WordWrap = false;
            // 
            // TxtVal4
            // 
            TxtVal4.Font = new Font("Segoe UI", 9F);
            TxtVal4.Location = new Point(69, 103);
            TxtVal4.Name = "TxtVal4";
            TxtVal4.Size = new Size(71, 23);
            TxtVal4.TabIndex = 18;
            TxtVal4.WordWrap = false;
            // 
            // TxtVal3
            // 
            TxtVal3.Font = new Font("Segoe UI", 9F);
            TxtVal3.Location = new Point(69, 77);
            TxtVal3.Name = "TxtVal3";
            TxtVal3.Size = new Size(71, 23);
            TxtVal3.TabIndex = 17;
            TxtVal3.WordWrap = false;
            // 
            // TxtVal2
            // 
            TxtVal2.Font = new Font("Segoe UI", 9F);
            TxtVal2.Location = new Point(69, 51);
            TxtVal2.Name = "TxtVal2";
            TxtVal2.Size = new Size(71, 23);
            TxtVal2.TabIndex = 16;
            TxtVal2.WordWrap = false;
            // 
            // TxtVal1
            // 
            TxtVal1.Font = new Font("Segoe UI", 9F);
            TxtVal1.Location = new Point(69, 25);
            TxtVal1.Name = "TxtVal1";
            TxtVal1.Size = new Size(71, 23);
            TxtVal1.TabIndex = 15;
            TxtVal1.WordWrap = false;
            // 
            // LbVal14
            // 
            LbVal14.AutoSize = true;
            LbVal14.Font = new Font("Segoe UI", 9F);
            LbVal14.Location = new Point(22, 366);
            LbVal14.Name = "LbVal14";
            LbVal14.Size = new Size(37, 15);
            LbVal14.TabIndex = 14;
            LbVal14.Text = "Val14:";
            // 
            // LbVal13
            // 
            LbVal13.AutoSize = true;
            LbVal13.Font = new Font("Segoe UI", 9F);
            LbVal13.Location = new Point(22, 340);
            LbVal13.Name = "LbVal13";
            LbVal13.Size = new Size(37, 15);
            LbVal13.TabIndex = 13;
            LbVal13.Text = "Val13:";
            // 
            // LbVal12
            // 
            LbVal12.AutoSize = true;
            LbVal12.Font = new Font("Segoe UI", 9F);
            LbVal12.Location = new Point(22, 314);
            LbVal12.Name = "LbVal12";
            LbVal12.Size = new Size(37, 15);
            LbVal12.TabIndex = 12;
            LbVal12.Text = "Val12:";
            // 
            // LbVal11
            // 
            LbVal11.AutoSize = true;
            LbVal11.Font = new Font("Segoe UI", 9F);
            LbVal11.Location = new Point(22, 288);
            LbVal11.Name = "LbVal11";
            LbVal11.Size = new Size(37, 15);
            LbVal11.TabIndex = 11;
            LbVal11.Text = "Val11:";
            // 
            // LbVal10
            // 
            LbVal10.AutoSize = true;
            LbVal10.Font = new Font("Segoe UI", 9F);
            LbVal10.Location = new Point(22, 262);
            LbVal10.Name = "LbVal10";
            LbVal10.Size = new Size(37, 15);
            LbVal10.TabIndex = 10;
            LbVal10.Text = "Val10:";
            // 
            // LbVal9
            // 
            LbVal9.AutoSize = true;
            LbVal9.Font = new Font("Segoe UI", 9F);
            LbVal9.Location = new Point(28, 236);
            LbVal9.Name = "LbVal9";
            LbVal9.Size = new Size(31, 15);
            LbVal9.TabIndex = 9;
            LbVal9.Text = "Val9:";
            // 
            // LbVal8
            // 
            LbVal8.AutoSize = true;
            LbVal8.Font = new Font("Segoe UI", 9F);
            LbVal8.Location = new Point(28, 210);
            LbVal8.Name = "LbVal8";
            LbVal8.Size = new Size(31, 15);
            LbVal8.TabIndex = 8;
            LbVal8.Text = "Val8:";
            // 
            // LbVal7
            // 
            LbVal7.AutoSize = true;
            LbVal7.Font = new Font("Segoe UI", 9F);
            LbVal7.Location = new Point(28, 184);
            LbVal7.Name = "LbVal7";
            LbVal7.Size = new Size(31, 15);
            LbVal7.TabIndex = 7;
            LbVal7.Text = "Val7:";
            // 
            // LbVal6
            // 
            LbVal6.AutoSize = true;
            LbVal6.Font = new Font("Segoe UI", 9F);
            LbVal6.Location = new Point(28, 158);
            LbVal6.Name = "LbVal6";
            LbVal6.Size = new Size(31, 15);
            LbVal6.TabIndex = 6;
            LbVal6.Text = "Val6:";
            // 
            // LbVal5
            // 
            LbVal5.AutoSize = true;
            LbVal5.Font = new Font("Segoe UI", 9F);
            LbVal5.Location = new Point(28, 132);
            LbVal5.Name = "LbVal5";
            LbVal5.Size = new Size(31, 15);
            LbVal5.TabIndex = 5;
            LbVal5.Text = "Val5:";
            // 
            // LbVal4
            // 
            LbVal4.AutoSize = true;
            LbVal4.Font = new Font("Segoe UI", 9F);
            LbVal4.Location = new Point(28, 106);
            LbVal4.Name = "LbVal4";
            LbVal4.Size = new Size(31, 15);
            LbVal4.TabIndex = 4;
            LbVal4.Text = "Val4:";
            // 
            // LbVal3
            // 
            LbVal3.AutoSize = true;
            LbVal3.Font = new Font("Segoe UI", 9F);
            LbVal3.Location = new Point(28, 80);
            LbVal3.Name = "LbVal3";
            LbVal3.Size = new Size(31, 15);
            LbVal3.TabIndex = 3;
            LbVal3.Text = "Val3:";
            // 
            // LbVal2
            // 
            LbVal2.AutoSize = true;
            LbVal2.Font = new Font("Segoe UI", 9F);
            LbVal2.Location = new Point(28, 54);
            LbVal2.Name = "LbVal2";
            LbVal2.Size = new Size(31, 15);
            LbVal2.TabIndex = 2;
            LbVal2.Text = "Val2:";
            // 
            // LbVal1
            // 
            LbVal1.AutoSize = true;
            LbVal1.Font = new Font("Segoe UI", 9F);
            LbVal1.Location = new Point(28, 28);
            LbVal1.Name = "LbVal1";
            LbVal1.Size = new Size(31, 15);
            LbVal1.TabIndex = 1;
            LbVal1.Text = "Val1:";
            // 
            // GbCharCoord
            // 
            GbCharCoord.Controls.Add(LblXtopL);
            GbCharCoord.Controls.Add(LblYTopL);
            GbCharCoord.Controls.Add(LblXBottomR);
            GbCharCoord.Controls.Add(LblYBottom);
            GbCharCoord.Controls.Add(TxtXtopL);
            GbCharCoord.Controls.Add(TxtYbottomR);
            GbCharCoord.Controls.Add(TxtYtopL);
            GbCharCoord.Controls.Add(TxtXbottomR);
            GbCharCoord.Enabled = false;
            GbCharCoord.Font = new Font("Segoe UI", 9F);
            GbCharCoord.Location = new Point(278, 583);
            GbCharCoord.Name = "GbCharCoord";
            GbCharCoord.Size = new Size(246, 74);
            GbCharCoord.TabIndex = 22;
            GbCharCoord.TabStop = false;
            GbCharCoord.Text = "Char Coordinates";
            // 
            // BtnSaveFont
            // 
            BtnSaveFont.Enabled = false;
            BtnSaveFont.Font = new Font("Segoe UI", 9F);
            BtnSaveFont.Location = new Point(879, 594);
            BtnSaveFont.Name = "BtnSaveFont";
            BtnSaveFont.Size = new Size(96, 27);
            BtnSaveFont.TabIndex = 23;
            BtnSaveFont.Text = "Save .fnt";
            BtnSaveFont.UseVisualStyleBackColor = true;
            BtnSaveFont.Click += BtnSaveFont_Click;
            // 
            // BtnSaveFontAs
            // 
            BtnSaveFontAs.Enabled = false;
            BtnSaveFontAs.Font = new Font("Segoe UI", 9F);
            BtnSaveFontAs.Location = new Point(976, 594);
            BtnSaveFontAs.Name = "BtnSaveFontAs";
            BtnSaveFontAs.Size = new Size(96, 27);
            BtnSaveFontAs.TabIndex = 24;
            BtnSaveFontAs.Text = "Save .fnt As...";
            BtnSaveFontAs.UseVisualStyleBackColor = true;
            BtnSaveFontAs.Click += BtnSaveFontAs_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.Location = new Point(879, 625);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(193, 27);
            btnClose.TabIndex = 25;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // BtnUpdateValues
            // 
            BtnUpdateValues.Enabled = false;
            BtnUpdateValues.Font = new Font("Segoe UI", 9F);
            BtnUpdateValues.Location = new Point(705, 594);
            BtnUpdateValues.Name = "BtnUpdateValues";
            BtnUpdateValues.Size = new Size(168, 27);
            BtnUpdateValues.TabIndex = 26;
            BtnUpdateValues.Text = "Update Global/Char Values";
            BtnUpdateValues.UseVisualStyleBackColor = true;
            BtnUpdateValues.Click += BtnUpdateValues_Click;
            // 
            // CbTGAList
            // 
            CbTGAList.Enabled = false;
            CbTGAList.FlatStyle = FlatStyle.Popup;
            CbTGAList.Font = new Font("Segoe UI", 9F);
            CbTGAList.FormattingEnabled = true;
            CbTGAList.Location = new Point(63, 31);
            CbTGAList.Name = "CbTGAList";
            CbTGAList.Size = new Size(588, 23);
            CbTGAList.TabIndex = 29;
            // 
            // LblTGAFile
            // 
            LblTGAFile.AutoSize = true;
            LblTGAFile.Font = new Font("Segoe UI", 9F);
            LblTGAFile.Location = new Point(6, 35);
            LblTGAFile.Name = "LblTGAFile";
            LblTGAFile.Size = new Size(53, 15);
            LblTGAFile.TabIndex = 30;
            LblTGAFile.Text = "TGA File:";
            // 
            // BtnRegen
            // 
            BtnRegen.Enabled = false;
            BtnRegen.Font = new Font("Segoe UI", 9F);
            BtnRegen.Location = new Point(1049, 159);
            BtnRegen.Name = "BtnRegen";
            BtnRegen.Size = new Size(140, 24);
            BtnRegen.TabIndex = 31;
            BtnRegen.Text = "Regen (TEST)";
            BtnRegen.UseVisualStyleBackColor = true;
            BtnRegen.Visible = false;
            BtnRegen.Click += BtnRegen_Click;
            // 
            // lblCodepage
            // 
            lblCodepage.AutoSize = true;
            lblCodepage.Font = new Font("Segoe UI", 9F);
            lblCodepage.Location = new Point(934, 37);
            lblCodepage.Name = "lblCodepage";
            lblCodepage.Size = new Size(64, 15);
            lblCodepage.TabIndex = 32;
            lblCodepage.Text = "Codepage:";
            // 
            // CbCodepage
            // 
            CbCodepage.CausesValidation = false;
            CbCodepage.DropDownStyle = ComboBoxStyle.DropDownList;
            CbCodepage.FlatStyle = FlatStyle.Popup;
            CbCodepage.Font = new Font("Segoe UI", 9F);
            CbCodepage.FormattingEnabled = true;
            CbCodepage.Items.AddRange(new object[] { "1250", "1251", "1252", "1253", "1254", "1255", "1256", "1257", "1258" });
            CbCodepage.Location = new Point(1002, 32);
            CbCodepage.Name = "CbCodepage";
            CbCodepage.Size = new Size(68, 23);
            CbCodepage.TabIndex = 33;
            CbCodepage.SelectedIndexChanged += cbCodepage_SelectedIndexChanged;
            // 
            // TxtMaxChars
            // 
            TxtMaxChars.Font = new Font("Segoe UI", 9F);
            TxtMaxChars.Location = new Point(628, 107);
            TxtMaxChars.Name = "TxtMaxChars";
            TxtMaxChars.ReadOnly = true;
            TxtMaxChars.Size = new Size(40, 23);
            TxtMaxChars.TabIndex = 34;
            // 
            // lblMaxChars
            // 
            lblMaxChars.AutoSize = true;
            lblMaxChars.Font = new Font("Segoe UI", 9F);
            lblMaxChars.Location = new Point(557, 110);
            lblMaxChars.Name = "lblMaxChars";
            lblMaxChars.Size = new Size(65, 15);
            lblMaxChars.TabIndex = 35;
            lblMaxChars.Text = "Max Chars:";
            // 
            // ChkEnabled
            // 
            ChkEnabled.AutoCheck = false;
            ChkEnabled.AutoSize = true;
            ChkEnabled.Enabled = false;
            ChkEnabled.Font = new Font("Segoe UI", 9F);
            ChkEnabled.Location = new Point(578, 145);
            ChkEnabled.Name = "ChkEnabled";
            ChkEnabled.Size = new Size(68, 19);
            ChkEnabled.TabIndex = 36;
            ChkEnabled.Text = "Enabled";
            ChkEnabled.UseVisualStyleBackColor = true;
            ChkEnabled.Click += chkEnabled_Click;
            // 
            // TbZoom
            // 
            TbZoom.AutoSize = false;
            TbZoom.LargeChange = 3;
            TbZoom.Location = new Point(6, 24);
            TbZoom.Maximum = 12;
            TbZoom.Minimum = 1;
            TbZoom.Name = "TbZoom";
            TbZoom.Size = new Size(192, 36);
            TbZoom.TabIndex = 37;
            TbZoom.Value = 2;
            TbZoom.ValueChanged += tbZoom_ValueChanged;
            // 
            // TxtZoom
            // 
            TxtZoom.Font = new Font("Segoe UI", 9F);
            TxtZoom.Location = new Point(204, 24);
            TxtZoom.Name = "TxtZoom";
            TxtZoom.ReadOnly = true;
            TxtZoom.Size = new Size(32, 23);
            TxtZoom.TabIndex = 38;
            TxtZoom.Text = "2";
            // 
            // GbZoom
            // 
            GbZoom.Controls.Add(TbZoom);
            GbZoom.Controls.Add(TxtZoom);
            GbZoom.Enabled = false;
            GbZoom.Font = new Font("Segoe UI", 9F);
            GbZoom.Location = new Point(9, 583);
            GbZoom.Name = "GbZoom";
            GbZoom.Size = new Size(246, 74);
            GbZoom.TabIndex = 39;
            GbZoom.TabStop = false;
            GbZoom.Text = "Zoom";
            // 
            // txtWidth
            // 
            txtWidth.Font = new Font("Segoe UI", 9F);
            txtWidth.Location = new Point(680, 32);
            txtWidth.Name = "txtWidth";
            txtWidth.ReadOnly = true;
            txtWidth.Size = new Size(46, 23);
            txtWidth.TabIndex = 40;
            // 
            // txtHeight
            // 
            txtHeight.Font = new Font("Segoe UI", 9F);
            txtHeight.Location = new Point(752, 32);
            txtHeight.Name = "txtHeight";
            txtHeight.ReadOnly = true;
            txtHeight.Size = new Size(46, 23);
            txtHeight.TabIndex = 41;
            // 
            // lblW
            // 
            lblW.AutoSize = true;
            lblW.Font = new Font("Segoe UI", 9F);
            lblW.Location = new Point(659, 35);
            lblW.Name = "lblW";
            lblW.Size = new Size(21, 15);
            lblW.TabIndex = 42;
            lblW.Text = "W:";
            // 
            // lblH
            // 
            lblH.AutoSize = true;
            lblH.Font = new Font("Segoe UI", 9F);
            lblH.Location = new Point(733, 35);
            lblH.Name = "lblH";
            lblH.Size = new Size(19, 15);
            lblH.TabIndex = 43;
            lblH.Text = "H:";
            // 
            // BtnUpdateCoordsCharVals
            // 
            BtnUpdateCoordsCharVals.Enabled = false;
            BtnUpdateCoordsCharVals.Font = new Font("Segoe UI", 9F);
            BtnUpdateCoordsCharVals.Location = new Point(535, 625);
            BtnUpdateCoordsCharVals.Name = "BtnUpdateCoordsCharVals";
            BtnUpdateCoordsCharVals.Size = new Size(338, 27);
            BtnUpdateCoordsCharVals.TabIndex = 44;
            BtnUpdateCoordsCharVals.Text = "Update Coordinates && Global/Char Values";
            BtnUpdateCoordsCharVals.UseVisualStyleBackColor = true;
            BtnUpdateCoordsCharVals.Click += BtnUpdateCoordsCharVals_Click;
            // 
            // FontEditor
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1080, 664);
            Controls.Add(BtnUpdateCoordsCharVals);
            Controls.Add(lblH);
            Controls.Add(GbCharCoord);
            Controls.Add(lblW);
            Controls.Add(txtHeight);
            Controls.Add(txtWidth);
            Controls.Add(GbZoom);
            Controls.Add(ChkEnabled);
            Controls.Add(BtnRegen);
            Controls.Add(lblMaxChars);
            Controls.Add(TxtMaxChars);
            Controls.Add(CbCodepage);
            Controls.Add(lblCodepage);
            Controls.Add(LblTGAFile);
            Controls.Add(CbTGAList);
            Controls.Add(BtnUpdateValues);
            Controls.Add(btnClose);
            Controls.Add(BtnSaveFontAs);
            Controls.Add(BtnSaveFont);
            Controls.Add(LblCharInfoTableIndex);
            Controls.Add(GbCharInfoValues);
            Controls.Add(BtnUpdateCoords);
            Controls.Add(TxtCharInfoIndex);
            Controls.Add(LblInternalCharTable);
            Controls.Add(LbChars);
            Controls.Add(GbGlobalFontValues);
            Controls.Add(BtnLoadFont);
            Controls.Add(TxtFontFile);
            Controls.Add(LblFontFile);
            Controls.Add(PanelPbFont);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FontEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VtMB Font Editor";
            KeyDown += FontEditor_KeyDown;
            KeyUp += FontEditor_KeyUp;
            PanelPbFont.ResumeLayout(false);
            PanelPbFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFont).EndInit();
            GbGlobalFontValues.ResumeLayout(false);
            GbGlobalFontValues.PerformLayout();
            GBDistances.ResumeLayout(false);
            GBDistances.PerformLayout();
            GbCharInfoValues.ResumeLayout(false);
            GbCharInfoValues.PerformLayout();
            GbCharCoord.ResumeLayout(false);
            GbCharCoord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TbZoom).EndInit();
            GbZoom.ResumeLayout(false);
            GbZoom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private WheelessPanel PanelPbFont;
        private PictureBox pbFont;
        private Label LblFontFile;
        private TextBox TxtFontFile;
        private Button BtnLoadFont;
        private OpenFileDialog OpenFileDlg;
        private GroupBox GbGlobalFontValues;
        private Label LblPages;
        private TextBox TxtPages;
        private TextBox TxtLineSpacing;
        private Label LblLineSpacing;
        private TextBox TxtDistUp;
        private Label LblDistUp;
        private TextBox TxtDistRight;
        private Label LblDistRight;
        private TextBox TxtDistLeft;
        private Label LblDistLeft;
        private TextBox TxtDistBottom;
        private Label LblDistBottom;
        private Label LblXtopL;
        private Label LblYTopL;
        private Label LblXBottomR;
        private Label LblYBottom;
        private TextBox TxtXtopL;
        private TextBox TxtYtopL;
        private TextBox TxtXbottomR;
        private TextBox TxtYbottomR;
        public ListBox LbChars;
        private Label LblInternalCharTable;
        private TextBox TxtCharInfoIndex;
        private Label LblCharInfoTableIndex;
        private Button BtnUpdateCoords;
        private GroupBox GbCharInfoValues;
        private Label LbVal14;
        private Label LbVal13;
        private Label LbVal12;
        private Label LbVal11;
        private Label LbVal10;
        private Label LbVal9;
        private Label LbVal8;
        private Label LbVal7;
        private Label LbVal6;
        private Label LbVal5;
        private Label LbVal4;
        private Label LbVal3;
        private Label LbVal2;
        private Label LbVal1;
        private TextBox TxtVal14;
        private TextBox TxtVal13;
        private TextBox TxtVal12;
        private TextBox TxtVal11;
        private TextBox TxtVal10;
        private TextBox TxtVal9;
        private TextBox TxtVal8;
        private TextBox TxtVal7;
        private TextBox TxtVal6;
        private TextBox TxtVal5;
        private TextBox TxtVal4;
        private TextBox TxtVal3;
        private TextBox TxtVal2;
        private TextBox TxtVal1;
        private TextBox TxtVal28;
        private TextBox TxtVal27;
        private TextBox TxtVal26;
        private TextBox TxtPage;
        private TextBox TxtVal24;
        private TextBox TxtVal23;
        private TextBox TxtVal22;
        private TextBox TxtVal21;
        private TextBox TxtVal20;
        private TextBox TxtVal19;
        private TextBox TxtVal18;
        private TextBox TxtVal17;
        private TextBox TxtVal16;
        private TextBox TxtVal15;
        private Label LbVal28;
        private Label LbVal27CharW;
        private Label LbVal26;
        private Label LbVal25Page;
        private Label LbVal24;
        private Label LbVal23;
        private Label LbVal22;
        private Label LbVal21;
        private Label LbVal20;
        private Label LbVal19RSpacing;
        private Label LbVal18CharW;
        private Label LbVal17LSpacing;
        private Label LbVal16;
        private Label LbVal15;
        private GroupBox GbCharCoord;
        private Button BtnSaveFont;
        private Button BtnSaveFontAs;
        private Button btnClose;
        private Button BtnUpdateValues;
        private SaveFileDialog SaveFileDlg;
        private ComboBox CbTGAList;
        private Label LblTGAFile;
        private Button BtnRegen;
        private Label lblCodepage;
        private ComboBox CbCodepage;
        private Label lblMaxChars;
        private CheckBox ChkEnabled;
        private TrackBar TbZoom;
        private TextBox TxtZoom;
        private GroupBox GbZoom;
        private GroupBox GBDistances;
        private Button btnManagePages;
        private TextBox txtWidth;
        private TextBox txtHeight;
        private Label lblW;
        private Label lblH;
        public TextBox TxtMaxChars;
        private Button BtnUpdateCoordsCharVals;
    }
}
