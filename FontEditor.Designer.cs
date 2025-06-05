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
            PanelPictureBox = new Panel();
            PictureBoxFont = new PictureBox();
            LblFontFile = new Label();
            TxtFontFile = new TextBox();
            BtnLoadFont = new Button();
            OpenFileDlg = new OpenFileDialog();
            GbGlobalFontValues = new GroupBox();
            TxtDistBottom = new TextBox();
            LblDistBottom = new Label();
            TxtDistUp = new TextBox();
            LblDistUp = new Label();
            TxtDistRight = new TextBox();
            LblDistRight = new Label();
            TxtDistLeft = new TextBox();
            LblDistLeft = new Label();
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
            TxtVal25 = new TextBox();
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
            LbVal27TexW = new Label();
            LbVal26 = new Label();
            LbVal25Page = new Label();
            LbVal24 = new Label();
            LbVal23 = new Label();
            LbVal22 = new Label();
            LbVal21 = new Label();
            LbVal20 = new Label();
            LbVal19RSpacing = new Label();
            LbVal18TexW = new Label();
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
            groupBox1 = new GroupBox();
            BtnSaveFont = new Button();
            BtnSaveFontAs = new Button();
            btnClose = new Button();
            BtnUpdateValues = new Button();
            SaveFileDlg = new SaveFileDialog();
            CbTGAList = new ComboBox();
            LblTGAFile = new Label();
            BtnRegen = new Button();
            PanelPictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxFont).BeginInit();
            GbGlobalFontValues.SuspendLayout();
            GbCharInfoValues.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // PanelPictureBox
            // 
            PanelPictureBox.BorderStyle = BorderStyle.Fixed3D;
            PanelPictureBox.Controls.Add(PictureBoxFont);
            PanelPictureBox.Location = new Point(12, 12);
            PanelPictureBox.Name = "PanelPictureBox";
            PanelPictureBox.Size = new Size(518, 518);
            PanelPictureBox.TabIndex = 0;
            // 
            // PictureBoxFont
            // 
            PictureBoxFont.BackColor = Color.Black;
            PictureBoxFont.Location = new Point(1, 1);
            PictureBoxFont.Name = "PictureBoxFont";
            PictureBoxFont.Size = new Size(512, 512);
            PictureBoxFont.TabIndex = 0;
            PictureBoxFont.TabStop = false;
            // 
            // LblFontFile
            // 
            LblFontFile.AutoSize = true;
            LblFontFile.Location = new Point(545, 15);
            LblFontFile.Name = "LblFontFile";
            LblFontFile.Size = new Size(68, 20);
            LblFontFile.TabIndex = 1;
            LblFontFile.Text = "Font File:";
            // 
            // TxtFontFile
            // 
            TxtFontFile.Location = new Point(616, 12);
            TxtFontFile.Name = "TxtFontFile";
            TxtFontFile.ReadOnly = true;
            TxtFontFile.Size = new Size(570, 27);
            TxtFontFile.TabIndex = 2;
            // 
            // BtnLoadFont
            // 
            BtnLoadFont.Location = new Point(1192, 12);
            BtnLoadFont.Name = "BtnLoadFont";
            BtnLoadFont.Size = new Size(122, 27);
            BtnLoadFont.TabIndex = 3;
            BtnLoadFont.Text = "Load .fnt";
            BtnLoadFont.UseVisualStyleBackColor = true;
            BtnLoadFont.Click += BtnLoadFont_Click;
            // 
            // GbGlobalFontValues
            // 
            GbGlobalFontValues.Controls.Add(TxtDistBottom);
            GbGlobalFontValues.Controls.Add(LblDistBottom);
            GbGlobalFontValues.Controls.Add(TxtDistUp);
            GbGlobalFontValues.Controls.Add(LblDistUp);
            GbGlobalFontValues.Controls.Add(TxtDistRight);
            GbGlobalFontValues.Controls.Add(LblDistRight);
            GbGlobalFontValues.Controls.Add(TxtDistLeft);
            GbGlobalFontValues.Controls.Add(LblDistLeft);
            GbGlobalFontValues.Controls.Add(TxtLineSpacing);
            GbGlobalFontValues.Controls.Add(LblLineSpacing);
            GbGlobalFontValues.Controls.Add(TxtPages);
            GbGlobalFontValues.Controls.Add(LblPages);
            GbGlobalFontValues.Location = new Point(547, 78);
            GbGlobalFontValues.Name = "GbGlobalFontValues";
            GbGlobalFontValues.Size = new Size(757, 67);
            GbGlobalFontValues.TabIndex = 7;
            GbGlobalFontValues.TabStop = false;
            GbGlobalFontValues.Text = "Global Font Values";
            // 
            // TxtDistBottom
            // 
            TxtDistBottom.Location = new Point(705, 28);
            TxtDistBottom.Name = "TxtDistBottom";
            TxtDistBottom.Size = new Size(42, 27);
            TxtDistBottom.TabIndex = 11;
            // 
            // LblDistBottom
            // 
            LblDistBottom.AutoSize = true;
            LblDistBottom.Location = new Point(612, 31);
            LblDistBottom.Name = "LblDistBottom";
            LblDistBottom.Size = new Size(92, 20);
            LblDistBottom.TabIndex = 10;
            LblDistBottom.Text = "Dist Bottom:";
            // 
            // TxtDistUp
            // 
            TxtDistUp.Location = new Point(566, 28);
            TxtDistUp.Name = "TxtDistUp";
            TxtDistUp.Size = new Size(42, 27);
            TxtDistUp.TabIndex = 9;
            // 
            // LblDistUp
            // 
            LblDistUp.AutoSize = true;
            LblDistUp.Location = new Point(504, 31);
            LblDistUp.Name = "LblDistUp";
            LblDistUp.Size = new Size(61, 20);
            LblDistUp.TabIndex = 8;
            LblDistUp.Text = "Dist Up:";
            // 
            // TxtDistRight
            // 
            TxtDistRight.Location = new Point(458, 28);
            TxtDistRight.Name = "TxtDistRight";
            TxtDistRight.Size = new Size(42, 27);
            TxtDistRight.TabIndex = 7;
            // 
            // LblDistRight
            // 
            LblDistRight.AutoSize = true;
            LblDistRight.Location = new Point(379, 31);
            LblDistRight.Name = "LblDistRight";
            LblDistRight.Size = new Size(77, 20);
            LblDistRight.TabIndex = 6;
            LblDistRight.Text = "Dist Right:";
            // 
            // TxtDistLeft
            // 
            TxtDistLeft.Location = new Point(334, 28);
            TxtDistLeft.Name = "TxtDistLeft";
            TxtDistLeft.Size = new Size(42, 27);
            TxtDistLeft.TabIndex = 5;
            // 
            // LblDistLeft
            // 
            LblDistLeft.AutoSize = true;
            LblDistLeft.Location = new Point(266, 31);
            LblDistLeft.Name = "LblDistLeft";
            LblDistLeft.Size = new Size(67, 20);
            LblDistLeft.TabIndex = 4;
            LblDistLeft.Text = "Dist Left:";
            // 
            // TxtLineSpacing
            // 
            TxtLineSpacing.Location = new Point(201, 28);
            TxtLineSpacing.Name = "TxtLineSpacing";
            TxtLineSpacing.Size = new Size(42, 27);
            TxtLineSpacing.TabIndex = 3;
            // 
            // LblLineSpacing
            // 
            LblLineSpacing.AutoSize = true;
            LblLineSpacing.Location = new Point(105, 31);
            LblLineSpacing.Name = "LblLineSpacing";
            LblLineSpacing.Size = new Size(96, 20);
            LblLineSpacing.TabIndex = 2;
            LblLineSpacing.Text = "Line Spacing:";
            // 
            // TxtPages
            // 
            TxtPages.Location = new Point(56, 28);
            TxtPages.Name = "TxtPages";
            TxtPages.Size = new Size(43, 27);
            TxtPages.TabIndex = 1;
            // 
            // LblPages
            // 
            LblPages.AutoSize = true;
            LblPages.Location = new Point(5, 31);
            LblPages.Name = "LblPages";
            LblPages.Size = new Size(50, 20);
            LblPages.TabIndex = 0;
            LblPages.Text = "Pages:";
            // 
            // LbChars
            // 
            LbChars.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbChars.FormattingEnabled = true;
            LbChars.ItemHeight = 18;
            LbChars.Location = new Point(547, 180);
            LbChars.Name = "LbChars";
            LbChars.ScrollAlwaysVisible = true;
            LbChars.Size = new Size(180, 346);
            LbChars.TabIndex = 8;
            LbChars.SelectedIndexChanged += lbChars_SelectedIndexChanged;
            // 
            // LblXtopL
            // 
            LblXtopL.AutoSize = true;
            LblXtopL.Location = new Point(54, 35);
            LblXtopL.Name = "LblXtopL";
            LblXtopL.Size = new Size(64, 20);
            LblXtopL.TabIndex = 9;
            LblXtopL.Text = "X Top L.:";
            // 
            // LblYTopL
            // 
            LblYTopL.AutoSize = true;
            LblYTopL.Location = new Point(55, 67);
            LblYTopL.Name = "LblYTopL";
            LblYTopL.Size = new Size(63, 20);
            LblYTopL.TabIndex = 10;
            LblYTopL.Text = "Y Top L.:";
            // 
            // LblXBottomR
            // 
            LblXBottomR.AutoSize = true;
            LblXBottomR.Location = new Point(27, 99);
            LblXBottomR.Name = "LblXBottomR";
            LblXBottomR.Size = new Size(91, 20);
            LblXBottomR.TabIndex = 11;
            LblXBottomR.Text = "X Bottom R.:";
            // 
            // LblYBottom
            // 
            LblYBottom.AutoSize = true;
            LblYBottom.Location = new Point(28, 131);
            LblYBottom.Name = "LblYBottom";
            LblYBottom.Size = new Size(90, 20);
            LblYBottom.TabIndex = 12;
            LblYBottom.Text = "Y Bottom R.:";
            // 
            // TxtXtopL
            // 
            TxtXtopL.Location = new Point(124, 32);
            TxtXtopL.Name = "TxtXtopL";
            TxtXtopL.Size = new Size(52, 27);
            TxtXtopL.TabIndex = 13;
            // 
            // TxtYtopL
            // 
            TxtYtopL.Location = new Point(124, 64);
            TxtYtopL.Name = "TxtYtopL";
            TxtYtopL.Size = new Size(52, 27);
            TxtYtopL.TabIndex = 14;
            // 
            // TxtXbottomR
            // 
            TxtXbottomR.Location = new Point(124, 96);
            TxtXbottomR.Name = "TxtXbottomR";
            TxtXbottomR.Size = new Size(52, 27);
            TxtXbottomR.TabIndex = 15;
            // 
            // TxtYbottomR
            // 
            TxtYbottomR.Location = new Point(124, 128);
            TxtYbottomR.Name = "TxtYbottomR";
            TxtYbottomR.Size = new Size(52, 27);
            TxtYbottomR.TabIndex = 16;
            // 
            // LblInternalCharTable
            // 
            LblInternalCharTable.AutoSize = true;
            LblInternalCharTable.Location = new Point(544, 150);
            LblInternalCharTable.Name = "LblInternalCharTable";
            LblInternalCharTable.Size = new Size(183, 20);
            LblInternalCharTable.TabIndex = 17;
            LblInternalCharTable.Text = "InternalTable (Index/Char):";
            // 
            // TxtCharInfoIndex
            // 
            TxtCharInfoIndex.Location = new Point(1215, 157);
            TxtCharInfoIndex.Name = "TxtCharInfoIndex";
            TxtCharInfoIndex.ReadOnly = true;
            TxtCharInfoIndex.Size = new Size(45, 27);
            TxtCharInfoIndex.TabIndex = 18;
            // 
            // LblCharInfoTableIndex
            // 
            LblCharInfoTableIndex.AutoSize = true;
            LblCharInfoTableIndex.Location = new Point(1131, 160);
            LblCharInfoTableIndex.Name = "LblCharInfoTableIndex";
            LblCharInfoTableIndex.Size = new Size(82, 20);
            LblCharInfoTableIndex.TabIndex = 19;
            LblCharInfoTableIndex.Text = "Char Index:";
            // 
            // BtnUpdateCoords
            // 
            BtnUpdateCoords.Enabled = false;
            BtnUpdateCoords.Location = new Point(1087, 365);
            BtnUpdateCoords.Name = "BtnUpdateCoords";
            BtnUpdateCoords.Size = new Size(217, 35);
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
            GbCharInfoValues.Controls.Add(TxtVal25);
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
            GbCharInfoValues.Controls.Add(LbVal27TexW);
            GbCharInfoValues.Controls.Add(LbVal26);
            GbCharInfoValues.Controls.Add(LbVal25Page);
            GbCharInfoValues.Controls.Add(LbVal24);
            GbCharInfoValues.Controls.Add(LbVal23);
            GbCharInfoValues.Controls.Add(LbVal22);
            GbCharInfoValues.Controls.Add(LbVal21);
            GbCharInfoValues.Controls.Add(LbVal20);
            GbCharInfoValues.Controls.Add(LbVal19RSpacing);
            GbCharInfoValues.Controls.Add(LbVal18TexW);
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
            GbCharInfoValues.Location = new Point(733, 151);
            GbCharInfoValues.Name = "GbCharInfoValues";
            GbCharInfoValues.Size = new Size(348, 377);
            GbCharInfoValues.TabIndex = 21;
            GbCharInfoValues.TabStop = false;
            GbCharInfoValues.Text = "Char Values";
            // 
            // TxtVal28
            // 
            TxtVal28.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal28.Location = new Point(269, 347);
            TxtVal28.Name = "TxtVal28";
            TxtVal28.Size = new Size(71, 22);
            TxtVal28.TabIndex = 56;
            TxtVal28.WordWrap = false;
            // 
            // TxtVal27
            // 
            TxtVal27.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal27.Location = new Point(269, 323);
            TxtVal27.Name = "TxtVal27";
            TxtVal27.Size = new Size(71, 22);
            TxtVal27.TabIndex = 55;
            TxtVal27.WordWrap = false;
            // 
            // TxtVal26
            // 
            TxtVal26.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal26.Location = new Point(269, 299);
            TxtVal26.Name = "TxtVal26";
            TxtVal26.Size = new Size(71, 22);
            TxtVal26.TabIndex = 54;
            TxtVal26.WordWrap = false;
            // 
            // TxtVal25
            // 
            TxtVal25.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal25.Location = new Point(269, 275);
            TxtVal25.Name = "TxtVal25";
            TxtVal25.Size = new Size(71, 22);
            TxtVal25.TabIndex = 53;
            TxtVal25.WordWrap = false;
            // 
            // TxtVal24
            // 
            TxtVal24.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal24.Location = new Point(269, 251);
            TxtVal24.Name = "TxtVal24";
            TxtVal24.Size = new Size(71, 22);
            TxtVal24.TabIndex = 52;
            TxtVal24.WordWrap = false;
            // 
            // TxtVal23
            // 
            TxtVal23.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal23.Location = new Point(269, 227);
            TxtVal23.Name = "TxtVal23";
            TxtVal23.Size = new Size(71, 22);
            TxtVal23.TabIndex = 51;
            TxtVal23.WordWrap = false;
            // 
            // TxtVal22
            // 
            TxtVal22.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal22.Location = new Point(269, 203);
            TxtVal22.Name = "TxtVal22";
            TxtVal22.Size = new Size(71, 22);
            TxtVal22.TabIndex = 50;
            TxtVal22.WordWrap = false;
            // 
            // TxtVal21
            // 
            TxtVal21.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal21.Location = new Point(269, 179);
            TxtVal21.Name = "TxtVal21";
            TxtVal21.Size = new Size(71, 22);
            TxtVal21.TabIndex = 49;
            TxtVal21.WordWrap = false;
            // 
            // TxtVal20
            // 
            TxtVal20.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal20.Location = new Point(269, 155);
            TxtVal20.Name = "TxtVal20";
            TxtVal20.Size = new Size(71, 22);
            TxtVal20.TabIndex = 48;
            TxtVal20.WordWrap = false;
            // 
            // TxtVal19
            // 
            TxtVal19.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal19.Location = new Point(269, 131);
            TxtVal19.Name = "TxtVal19";
            TxtVal19.Size = new Size(71, 22);
            TxtVal19.TabIndex = 47;
            TxtVal19.WordWrap = false;
            // 
            // TxtVal18
            // 
            TxtVal18.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal18.Location = new Point(269, 107);
            TxtVal18.Name = "TxtVal18";
            TxtVal18.Size = new Size(71, 22);
            TxtVal18.TabIndex = 46;
            TxtVal18.WordWrap = false;
            // 
            // TxtVal17
            // 
            TxtVal17.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal17.Location = new Point(269, 83);
            TxtVal17.Name = "TxtVal17";
            TxtVal17.Size = new Size(71, 22);
            TxtVal17.TabIndex = 45;
            TxtVal17.WordWrap = false;
            // 
            // TxtVal16
            // 
            TxtVal16.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal16.Location = new Point(269, 59);
            TxtVal16.Name = "TxtVal16";
            TxtVal16.Size = new Size(71, 22);
            TxtVal16.TabIndex = 44;
            TxtVal16.WordWrap = false;
            // 
            // TxtVal15
            // 
            TxtVal15.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal15.Location = new Point(269, 35);
            TxtVal15.Name = "TxtVal15";
            TxtVal15.Size = new Size(71, 22);
            TxtVal15.TabIndex = 43;
            TxtVal15.WordWrap = false;
            // 
            // LbVal28
            // 
            LbVal28.AutoSize = true;
            LbVal28.Location = new Point(215, 348);
            LbVal28.Name = "LbVal28";
            LbVal28.Size = new Size(48, 20);
            LbVal28.TabIndex = 42;
            LbVal28.Text = "Val28:";
            // 
            // LbVal27TexW
            // 
            LbVal27TexW.AutoSize = true;
            LbVal27TexW.Location = new Point(205, 324);
            LbVal27TexW.Name = "LbVal27TexW";
            LbVal27TexW.Size = new Size(58, 20);
            LbVal27TexW.TabIndex = 41;
            LbVal27TexW.Text = "Tex. W.:";
            // 
            // LbVal26
            // 
            LbVal26.AutoSize = true;
            LbVal26.Location = new Point(215, 300);
            LbVal26.Name = "LbVal26";
            LbVal26.Size = new Size(48, 20);
            LbVal26.TabIndex = 40;
            LbVal26.Text = "Val26:";
            // 
            // LbVal25Page
            // 
            LbVal25Page.AutoSize = true;
            LbVal25Page.Location = new Point(219, 276);
            LbVal25Page.Name = "LbVal25Page";
            LbVal25Page.Size = new Size(44, 20);
            LbVal25Page.TabIndex = 39;
            LbVal25Page.Text = "Page:";
            // 
            // LbVal24
            // 
            LbVal24.AutoSize = true;
            LbVal24.Location = new Point(173, 252);
            LbVal24.Name = "LbVal24";
            LbVal24.Size = new Size(90, 20);
            LbVal24.TabIndex = 38;
            LbVal24.Text = "Bot. Scaling:";
            // 
            // LbVal23
            // 
            LbVal23.AutoSize = true;
            LbVal23.Location = new Point(168, 228);
            LbVal23.Name = "LbVal23";
            LbVal23.Size = new Size(95, 20);
            LbVal23.TabIndex = 37;
            LbVal23.Text = "Bot. Spacing:";
            // 
            // LbVal22
            // 
            LbVal22.AutoSize = true;
            LbVal22.Location = new Point(174, 204);
            LbVal22.Name = "LbVal22";
            LbVal22.Size = new Size(89, 20);
            LbVal22.TabIndex = 36;
            LbVal22.Text = "Top Scaling:";
            // 
            // LbVal21
            // 
            LbVal21.AutoSize = true;
            LbVal21.Location = new Point(169, 180);
            LbVal21.Name = "LbVal21";
            LbVal21.Size = new Size(94, 20);
            LbVal21.TabIndex = 35;
            LbVal21.Text = "Top Spacing:";
            // 
            // LbVal20
            // 
            LbVal20.AutoSize = true;
            LbVal20.Location = new Point(215, 156);
            LbVal20.Name = "LbVal20";
            LbVal20.Size = new Size(48, 20);
            LbVal20.TabIndex = 34;
            LbVal20.Text = "Val20:";
            // 
            // LbVal19RSpacing
            // 
            LbVal19RSpacing.AutoSize = true;
            LbVal19RSpacing.Location = new Point(182, 132);
            LbVal19RSpacing.Name = "LbVal19RSpacing";
            LbVal19RSpacing.Size = new Size(81, 20);
            LbVal19RSpacing.TabIndex = 33;
            LbVal19RSpacing.Text = "R. Spacing:";
            // 
            // LbVal18TexW
            // 
            LbVal18TexW.AutoSize = true;
            LbVal18TexW.Location = new Point(205, 108);
            LbVal18TexW.Name = "LbVal18TexW";
            LbVal18TexW.Size = new Size(58, 20);
            LbVal18TexW.TabIndex = 32;
            LbVal18TexW.Text = "Tex. W.:";
            // 
            // LbVal17LSpacing
            // 
            LbVal17LSpacing.AutoSize = true;
            LbVal17LSpacing.Location = new Point(184, 84);
            LbVal17LSpacing.Name = "LbVal17LSpacing";
            LbVal17LSpacing.Size = new Size(79, 20);
            LbVal17LSpacing.TabIndex = 31;
            LbVal17LSpacing.Text = "L. Spacing:";
            // 
            // LbVal16
            // 
            LbVal16.AutoSize = true;
            LbVal16.Location = new Point(215, 60);
            LbVal16.Name = "LbVal16";
            LbVal16.Size = new Size(48, 20);
            LbVal16.TabIndex = 30;
            LbVal16.Text = "Val16:";
            // 
            // LbVal15
            // 
            LbVal15.AutoSize = true;
            LbVal15.Location = new Point(215, 36);
            LbVal15.Name = "LbVal15";
            LbVal15.Size = new Size(48, 20);
            LbVal15.TabIndex = 29;
            LbVal15.Text = "Val15:";
            // 
            // TxtVal14
            // 
            TxtVal14.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal14.Location = new Point(69, 346);
            TxtVal14.Name = "TxtVal14";
            TxtVal14.Size = new Size(71, 22);
            TxtVal14.TabIndex = 28;
            TxtVal14.WordWrap = false;
            // 
            // TxtVal13
            // 
            TxtVal13.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal13.Location = new Point(69, 322);
            TxtVal13.Name = "TxtVal13";
            TxtVal13.Size = new Size(71, 22);
            TxtVal13.TabIndex = 27;
            TxtVal13.WordWrap = false;
            // 
            // TxtVal12
            // 
            TxtVal12.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal12.Location = new Point(69, 298);
            TxtVal12.Name = "TxtVal12";
            TxtVal12.Size = new Size(71, 22);
            TxtVal12.TabIndex = 26;
            TxtVal12.WordWrap = false;
            // 
            // TxtVal11
            // 
            TxtVal11.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal11.Location = new Point(69, 274);
            TxtVal11.Name = "TxtVal11";
            TxtVal11.Size = new Size(71, 22);
            TxtVal11.TabIndex = 25;
            TxtVal11.WordWrap = false;
            // 
            // TxtVal10
            // 
            TxtVal10.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal10.Location = new Point(69, 250);
            TxtVal10.Name = "TxtVal10";
            TxtVal10.Size = new Size(71, 22);
            TxtVal10.TabIndex = 24;
            TxtVal10.WordWrap = false;
            // 
            // TxtVal9
            // 
            TxtVal9.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal9.Location = new Point(69, 226);
            TxtVal9.Name = "TxtVal9";
            TxtVal9.Size = new Size(71, 22);
            TxtVal9.TabIndex = 23;
            TxtVal9.WordWrap = false;
            // 
            // TxtVal8
            // 
            TxtVal8.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal8.Location = new Point(69, 202);
            TxtVal8.Name = "TxtVal8";
            TxtVal8.Size = new Size(71, 22);
            TxtVal8.TabIndex = 22;
            TxtVal8.WordWrap = false;
            // 
            // TxtVal7
            // 
            TxtVal7.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal7.Location = new Point(69, 178);
            TxtVal7.Name = "TxtVal7";
            TxtVal7.Size = new Size(71, 22);
            TxtVal7.TabIndex = 21;
            TxtVal7.WordWrap = false;
            // 
            // TxtVal6
            // 
            TxtVal6.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal6.Location = new Point(69, 154);
            TxtVal6.Name = "TxtVal6";
            TxtVal6.Size = new Size(71, 22);
            TxtVal6.TabIndex = 20;
            TxtVal6.WordWrap = false;
            // 
            // TxtVal5
            // 
            TxtVal5.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal5.Location = new Point(69, 130);
            TxtVal5.Name = "TxtVal5";
            TxtVal5.Size = new Size(71, 22);
            TxtVal5.TabIndex = 19;
            TxtVal5.WordWrap = false;
            // 
            // TxtVal4
            // 
            TxtVal4.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal4.Location = new Point(69, 106);
            TxtVal4.Name = "TxtVal4";
            TxtVal4.Size = new Size(71, 22);
            TxtVal4.TabIndex = 18;
            TxtVal4.WordWrap = false;
            // 
            // TxtVal3
            // 
            TxtVal3.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal3.Location = new Point(69, 82);
            TxtVal3.Name = "TxtVal3";
            TxtVal3.Size = new Size(71, 22);
            TxtVal3.TabIndex = 17;
            TxtVal3.WordWrap = false;
            // 
            // TxtVal2
            // 
            TxtVal2.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal2.Location = new Point(69, 58);
            TxtVal2.Name = "TxtVal2";
            TxtVal2.Size = new Size(71, 22);
            TxtVal2.TabIndex = 16;
            TxtVal2.WordWrap = false;
            // 
            // TxtVal1
            // 
            TxtVal1.Font = new Font("Microsoft Sans Serif", 7.8F);
            TxtVal1.Location = new Point(69, 34);
            TxtVal1.Name = "TxtVal1";
            TxtVal1.Size = new Size(71, 22);
            TxtVal1.TabIndex = 15;
            TxtVal1.WordWrap = false;
            // 
            // LbVal14
            // 
            LbVal14.AutoSize = true;
            LbVal14.Location = new Point(15, 347);
            LbVal14.Name = "LbVal14";
            LbVal14.Size = new Size(48, 20);
            LbVal14.TabIndex = 14;
            LbVal14.Text = "Val14:";
            // 
            // LbVal13
            // 
            LbVal13.AutoSize = true;
            LbVal13.Location = new Point(15, 323);
            LbVal13.Name = "LbVal13";
            LbVal13.Size = new Size(48, 20);
            LbVal13.TabIndex = 13;
            LbVal13.Text = "Val13:";
            // 
            // LbVal12
            // 
            LbVal12.AutoSize = true;
            LbVal12.Location = new Point(15, 299);
            LbVal12.Name = "LbVal12";
            LbVal12.Size = new Size(48, 20);
            LbVal12.TabIndex = 12;
            LbVal12.Text = "Val12:";
            // 
            // LbVal11
            // 
            LbVal11.AutoSize = true;
            LbVal11.Location = new Point(15, 275);
            LbVal11.Name = "LbVal11";
            LbVal11.Size = new Size(48, 20);
            LbVal11.TabIndex = 11;
            LbVal11.Text = "Val11:";
            // 
            // LbVal10
            // 
            LbVal10.AutoSize = true;
            LbVal10.Location = new Point(15, 251);
            LbVal10.Name = "LbVal10";
            LbVal10.Size = new Size(48, 20);
            LbVal10.TabIndex = 10;
            LbVal10.Text = "Val10:";
            // 
            // LbVal9
            // 
            LbVal9.AutoSize = true;
            LbVal9.Location = new Point(23, 227);
            LbVal9.Name = "LbVal9";
            LbVal9.Size = new Size(40, 20);
            LbVal9.TabIndex = 9;
            LbVal9.Text = "Val9:";
            // 
            // LbVal8
            // 
            LbVal8.AutoSize = true;
            LbVal8.Location = new Point(23, 203);
            LbVal8.Name = "LbVal8";
            LbVal8.Size = new Size(40, 20);
            LbVal8.TabIndex = 8;
            LbVal8.Text = "Val8:";
            // 
            // LbVal7
            // 
            LbVal7.AutoSize = true;
            LbVal7.Location = new Point(23, 179);
            LbVal7.Name = "LbVal7";
            LbVal7.Size = new Size(40, 20);
            LbVal7.TabIndex = 7;
            LbVal7.Text = "Val7:";
            // 
            // LbVal6
            // 
            LbVal6.AutoSize = true;
            LbVal6.Location = new Point(23, 155);
            LbVal6.Name = "LbVal6";
            LbVal6.Size = new Size(40, 20);
            LbVal6.TabIndex = 6;
            LbVal6.Text = "Val6:";
            // 
            // LbVal5
            // 
            LbVal5.AutoSize = true;
            LbVal5.Location = new Point(23, 131);
            LbVal5.Name = "LbVal5";
            LbVal5.Size = new Size(40, 20);
            LbVal5.TabIndex = 5;
            LbVal5.Text = "Val5:";
            // 
            // LbVal4
            // 
            LbVal4.AutoSize = true;
            LbVal4.Location = new Point(23, 107);
            LbVal4.Name = "LbVal4";
            LbVal4.Size = new Size(40, 20);
            LbVal4.TabIndex = 4;
            LbVal4.Text = "Val4:";
            // 
            // LbVal3
            // 
            LbVal3.AutoSize = true;
            LbVal3.Location = new Point(23, 83);
            LbVal3.Name = "LbVal3";
            LbVal3.Size = new Size(40, 20);
            LbVal3.TabIndex = 3;
            LbVal3.Text = "Val3:";
            // 
            // LbVal2
            // 
            LbVal2.AutoSize = true;
            LbVal2.Location = new Point(23, 59);
            LbVal2.Name = "LbVal2";
            LbVal2.Size = new Size(40, 20);
            LbVal2.TabIndex = 2;
            LbVal2.Text = "Val2:";
            // 
            // LbVal1
            // 
            LbVal1.AutoSize = true;
            LbVal1.Location = new Point(23, 35);
            LbVal1.Name = "LbVal1";
            LbVal1.Size = new Size(40, 20);
            LbVal1.TabIndex = 1;
            LbVal1.Text = "Val1:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LblXtopL);
            groupBox1.Controls.Add(LblYTopL);
            groupBox1.Controls.Add(LblXBottomR);
            groupBox1.Controls.Add(LblYBottom);
            groupBox1.Controls.Add(TxtXtopL);
            groupBox1.Controls.Add(TxtYbottomR);
            groupBox1.Controls.Add(TxtYtopL);
            groupBox1.Controls.Add(TxtXbottomR);
            groupBox1.Location = new Point(1087, 190);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(217, 169);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Char Coordinates";
            // 
            // BtnSaveFont
            // 
            BtnSaveFont.Enabled = false;
            BtnSaveFont.Location = new Point(1087, 447);
            BtnSaveFont.Name = "BtnSaveFont";
            BtnSaveFont.Size = new Size(99, 36);
            BtnSaveFont.TabIndex = 23;
            BtnSaveFont.Text = "Save .fnt";
            BtnSaveFont.UseVisualStyleBackColor = true;
            BtnSaveFont.Click += BtnSaveFont_Click;
            // 
            // BtnSaveFontAs
            // 
            BtnSaveFontAs.Enabled = false;
            BtnSaveFontAs.Location = new Point(1192, 447);
            BtnSaveFontAs.Name = "BtnSaveFontAs";
            BtnSaveFontAs.Size = new Size(112, 36);
            BtnSaveFontAs.TabIndex = 24;
            BtnSaveFontAs.Text = "Save .fnt As...";
            BtnSaveFontAs.UseVisualStyleBackColor = true;
            BtnSaveFontAs.Click += BtnSaveFontAs_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(1087, 490);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(218, 36);
            btnClose.TabIndex = 25;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // BtnUpdateValues
            // 
            BtnUpdateValues.Enabled = false;
            BtnUpdateValues.Location = new Point(1087, 406);
            BtnUpdateValues.Name = "BtnUpdateValues";
            BtnUpdateValues.Size = new Size(217, 35);
            BtnUpdateValues.TabIndex = 26;
            BtnUpdateValues.Text = "Update Values";
            BtnUpdateValues.UseVisualStyleBackColor = true;
            BtnUpdateValues.Click += BtnUpdateValues_Click;
            // 
            // CbTGAList
            // 
            CbTGAList.Enabled = false;
            CbTGAList.FlatStyle = FlatStyle.Popup;
            CbTGAList.FormattingEnabled = true;
            CbTGAList.Location = new Point(616, 45);
            CbTGAList.Name = "CbTGAList";
            CbTGAList.Size = new Size(570, 28);
            CbTGAList.TabIndex = 29;
            // 
            // LblTGAFile
            // 
            LblTGAFile.AutoSize = true;
            LblTGAFile.Location = new Point(547, 48);
            LblTGAFile.Name = "LblTGAFile";
            LblTGAFile.Size = new Size(66, 20);
            LblTGAFile.TabIndex = 30;
            LblTGAFile.Text = "TGA File:";
            // 
            // BtnRegen
            // 
            BtnRegen.Enabled = false;
            BtnRegen.Location = new Point(1192, 45);
            BtnRegen.Name = "BtnRegen";
            BtnRegen.Size = new Size(122, 29);
            BtnRegen.TabIndex = 31;
            BtnRegen.Text = "Regen (TEST)";
            BtnRegen.UseVisualStyleBackColor = true;
            BtnRegen.Click += BtnRegen_Click;
            // 
            // FontEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            CancelButton = btnClose;
            ClientSize = new Size(1318, 540);
            Controls.Add(BtnRegen);
            Controls.Add(LblTGAFile);
            Controls.Add(CbTGAList);
            Controls.Add(BtnUpdateValues);
            Controls.Add(btnClose);
            Controls.Add(BtnSaveFontAs);
            Controls.Add(BtnSaveFont);
            Controls.Add(LblCharInfoTableIndex);
            Controls.Add(groupBox1);
            Controls.Add(GbCharInfoValues);
            Controls.Add(BtnUpdateCoords);
            Controls.Add(TxtCharInfoIndex);
            Controls.Add(LblInternalCharTable);
            Controls.Add(LbChars);
            Controls.Add(GbGlobalFontValues);
            Controls.Add(BtnLoadFont);
            Controls.Add(TxtFontFile);
            Controls.Add(LblFontFile);
            Controls.Add(PanelPictureBox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FontEditor";
            Text = "VtMB Font Editor";
            PanelPictureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBoxFont).EndInit();
            GbGlobalFontValues.ResumeLayout(false);
            GbGlobalFontValues.PerformLayout();
            GbCharInfoValues.ResumeLayout(false);
            GbCharInfoValues.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelPictureBox;
        private PictureBox PictureBoxFont;
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
        private TextBox TxtVal25;
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
        private Label LbVal27TexW;
        private Label LbVal26;
        private Label LbVal25Page;
        private Label LbVal24;
        private Label LbVal23;
        private Label LbVal22;
        private Label LbVal21;
        private Label LbVal20;
        private Label LbVal19RSpacing;
        private Label LbVal18TexW;
        private Label LbVal17LSpacing;
        private Label LbVal16;
        private Label LbVal15;
        private GroupBox groupBox1;
        private Button BtnSaveFont;
        private Button BtnSaveFontAs;
        private Button btnClose;
        private Button BtnUpdateValues;
        private SaveFileDialog SaveFileDlg;
        private ComboBox CbTGAList;
        private Label LblTGAFile;
        private Button BtnRegen;
    }
}
