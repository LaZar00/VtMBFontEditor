using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace VtMBFontEditor
{

    public partial class FontEditor : Form
    {
        public const int MAX_NUM_CHARS = 256;
        public const int INITIAL_CHAR = 0x21;  // We will select '!' when loading new .fnt

        public FontFile loadedFnt;
        public Bitmap[] originalTGA;
        public Bitmap workingImg;
        public string pathdirectory;
        public FileTools FT = new FileTools();

        public int xtoplpixel, ytoplpixel, xbottomrpixel, ybottomrpixel;
        public int iZoomFactor;
        public bool bFontLoaded;

        // Some pbFont widget variables
        Bitmap bmpCoordInfo = new Bitmap(88, 40);
        Rectangle rectCoordInfo;
        bool bCoordInfoMouseMove;

        public FontEditor()
        {
            loadedFnt = new FontFile();
            pathdirectory = "";
            iZoomFactor = 2;

            InitializeComponent();

            FT.strGlobalPath = Application.StartupPath;
            FT.ReadCFGFile();

            CbCodepage.SelectedIndex = CbCodepage.Items.IndexOf(FT.iCodepage.ToString());
        }


        private void InitializeList()
        {
            LbChars.Items.Clear();

            for (int i = 0; i < MAX_NUM_CHARS; i++)
                LbChars.Items.Add("[" + i.ToString("000") + "/" +
                                  "0x" + i.ToString("X2") + "] (LOCKED)");
        }


        private void PreparePages()
        {
            string strPageName;

            CbTGAList.Items.Clear();
            strPageName = Encoding.ASCII.GetString(loadedFnt.Font.filename);
            strPageName = strPageName.Substring(0, strPageName.Length - 2);

            for (int i = 0; i < loadedFnt.Font.num_pages; i++)
            {
                CbTGAList.Items.Add(strPageName + i.ToString() + ".tga");
            }
        }


        private void LoadTGAFiles()
        {
            TGA T;

            // We will load the TGA files (if the image exists) and have it in memory
            // Initialize the array of bitmaps
            originalTGA = new Bitmap[loadedFnt.Font.num_pages];

            for (int i = 0; i < loadedFnt.Font.num_pages; i++)
            {
                string fileTGA = pathdirectory + "\\" + CbTGAList.Items[i];

                if (File.Exists(fileTGA))
                {

                    T = new TGA(fileTGA);
                    originalTGA[i] = T.ToBitmap(true);

                }
                else
                {
                    originalTGA[i] = new Bitmap(256, 256);

                    RectangleF rectf = new RectangleF(32, 110, 256, 60);

                    using (Graphics g = Graphics.FromImage(originalTGA[i]))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.DrawString("NO .TGA FILE FOUND", new Font("Tahoma", 14), Brushes.White, rectf);
                    }
                }
            }
        }

        private void PopulateFontInfo()
        {

            // General Fnt Info
            TxtPages.Text = loadedFnt.Font.num_pages.ToString();
            TxtLineSpacing.Text = loadedFnt.Font.line_spacing.ToString();

            TxtDistLeft.Text = loadedFnt.Font.shift_left.ToString();
            TxtDistRight.Text = loadedFnt.Font.shift_right.ToString();
            TxtDistUp.Text = loadedFnt.Font.shift_upper.ToString();
            TxtDistBottom.Text = loadedFnt.Font.shift_lower.ToString();

            //
            LbChars.BeginUpdate();

            // Char Info
            InitializeList();

            // Fill the ListBox
            string tmpString;

            for (int i = 0x21; i < MAX_NUM_CHARS; i++)
            {
                if (loadedFnt.Font.chartable[i] != 0x0D ||
                    i == 0x21 + 0x0D)
                {
                    tmpString = loadedFnt.Font.chartable[i].ToString("000") + "   " +
                                Encoding.GetEncoding(int.Parse(CbCodepage.SelectedItem.ToString())).
                                                                        GetString(new byte[] { (byte)i }) +
                                "  [" + i.ToString("000") + "/0x" + i.ToString("X2") + "]";
                }
                else
                {
                    tmpString = "FREE  " +
                                Encoding.GetEncoding(int.Parse(CbCodepage.SelectedItem.ToString())).
                                                                        GetString(new byte[] { (byte)i }) +
                                "  [" + i.ToString("000") + "/0x" + i.ToString("X2") + "]";
                }

                LbChars.Items[i] = tmpString;
            }

            //
            LbChars.EndUpdate();

            // Fill the Combobox with the pages of the font
            PreparePages();

            // Load pages TGA files
            LoadTGAFiles();

            // Select one Char
            LbChars.SelectedIndex = INITIAL_CHAR + (LbChars.Height / LbChars.ItemHeight);
            LbChars.SelectedIndex = INITIAL_CHAR;

        }


        private void MarkCharInBitmap(Graphics g)
        {
            // Draw the rectangle
            g.DrawRectangle(new Pen(Color.GreenYellow) { Alignment = PenAlignment.Inset },
                            xtoplpixel, ytoplpixel, 
                            xbottomrpixel - xtoplpixel, ybottomrpixel - ytoplpixel);

            SolidBrush b = new SolidBrush(Color.GreenYellow);

            g.FillRectangle(b, xtoplpixel - 1, ytoplpixel - 1, 1, 1);

        }


        private void PublishBitmapPictureBox()
        {

            if (workingImg != null)
            {
                workingImg.Dispose();
            }

            workingImg = new Bitmap(originalTGA[CbTGAList.SelectedIndex].Width,
                                    originalTGA[CbTGAList.SelectedIndex].Height,
                                    originalTGA[CbTGAList.SelectedIndex].PixelFormat);

            // We put here the image in workingImg for process
            using (Graphics g = Graphics.FromImage(workingImg))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.PixelOffsetMode = PixelOffsetMode.Half;

                g.DrawImage(originalTGA[CbTGAList.SelectedIndex],
                            0, 0, originalTGA[CbTGAList.SelectedIndex].Width, originalTGA[CbTGAList.SelectedIndex].Height);

                // We can do here the rest of processing, like mark the character selected in listbox on the image
                if (loadedFnt != null && LbChars.Items.Count > 0 && LbChars.SelectedIndex > -1)
                {
                    MarkCharInBitmap(g);
                }
            }

            // We will adjust a non compliant 256x256 texture into one compliant
            if (originalTGA[CbTGAList.SelectedIndex].Width < 256 || originalTGA[CbTGAList.SelectedIndex].Height < 256)
            {
                Bitmap tmpAdjustBmp = new Bitmap(256, 256);

                using (Graphics g = Graphics.FromImage(tmpAdjustBmp))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.CompositingMode = CompositingMode.SourceCopy;
                    g.PixelOffsetMode = PixelOffsetMode.Half;

                    g.DrawImage(workingImg,
                                0, 0, originalTGA[CbTGAList.SelectedIndex].Width, originalTGA[CbTGAList.SelectedIndex].Height);

                }

                workingImg = new Bitmap(tmpAdjustBmp);
            }

            // Finally we assign the working image to the picturebox 512x512 to show the result
            if (pbFont.Image != null)
            {
                pbFont.Image.Dispose();
            }

            // Let's bypass iZoomFactor = 1
            if (iZoomFactor == 1)
            {
                pbFont.Image = new Bitmap(512, 512);

                using (Graphics g = Graphics.FromImage(pbFont.Image))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.CompositingMode = CompositingMode.SourceCopy;
                    g.PixelOffsetMode = PixelOffsetMode.Half;

                    g.DrawImage(workingImg,
                                0, 0, workingImg.Width, workingImg.Height);

                }
            }
            else
            {
                pbFont.Image = new Bitmap(workingImg.Width * iZoomFactor, workingImg.Height * iZoomFactor);

                using (Graphics g = Graphics.FromImage(pbFont.Image))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.CompositingMode = CompositingMode.SourceCopy;
                    g.PixelOffsetMode = PixelOffsetMode.Half;

                    g.DrawImage(workingImg,
                                0, 0, workingImg.Width * iZoomFactor, workingImg.Height * iZoomFactor);

                }
            }
        }


        private void ClearTextVal()
        {
            TxtVal1.Text = "0";
            TxtVal2.Text = "0";
            TxtVal3.Text = "0";
            TxtVal4.Text = "0";
            TxtVal5.Text = "0";
            TxtVal6.Text = "0";
            TxtVal7.Text = "0";
            TxtVal8.Text = "0";
            TxtVal9.Text = "0";
            TxtVal10.Text = "0";
            TxtVal11.Text = "0";
            TxtVal12.Text = "0";
            TxtVal13.Text = "0";
            TxtVal14.Text = "0";
            TxtVal15.Text = "0";
            TxtVal16.Text = "0";
            TxtVal17.Text = "0";
            TxtVal18.Text = "0";
            TxtVal19.Text = "0";
            TxtVal20.Text = "0";
            TxtVal21.Text = "0";
            TxtVal22.Text = "0";
            TxtVal23.Text = "0";
            TxtVal24.Text = "0";
            TxtPage.Text = "0";
            TxtVal26.Text = "0";
            TxtVal27.Text = "0";
            TxtVal28.Text = "0";
        }

        private void PopulateCharInfo(int charIndex)
        {

            if (loadedFnt.Font.char_info[charIndex].charsettings != null)
            {
                TxtVal1.Text = loadedFnt.Font.char_info[charIndex].charsettings[0].ToString();
                TxtVal2.Text = loadedFnt.Font.char_info[charIndex].charsettings[1].ToString();
                TxtVal3.Text = loadedFnt.Font.char_info[charIndex].charsettings[2].ToString();
                TxtVal4.Text = loadedFnt.Font.char_info[charIndex].charsettings[3].ToString();
                TxtVal5.Text = loadedFnt.Font.char_info[charIndex].charsettings[4].ToString();
                TxtVal6.Text = loadedFnt.Font.char_info[charIndex].charsettings[5].ToString();
                TxtVal7.Text = loadedFnt.Font.char_info[charIndex].charsettings[6].ToString();
                TxtVal8.Text = loadedFnt.Font.char_info[charIndex].charsettings[7].ToString();
                TxtVal9.Text = loadedFnt.Font.char_info[charIndex].charsettings[8].ToString();
                TxtVal10.Text = loadedFnt.Font.char_info[charIndex].charsettings[9].ToString();
                TxtVal11.Text = loadedFnt.Font.char_info[charIndex].charsettings[10].ToString();
                TxtVal12.Text = loadedFnt.Font.char_info[charIndex].charsettings[11].ToString();
                TxtVal13.Text = loadedFnt.Font.char_info[charIndex].charsettings[12].ToString();
                TxtVal14.Text = loadedFnt.Font.char_info[charIndex].charsettings[13].ToString();
                TxtVal15.Text = loadedFnt.Font.char_info[charIndex].charsettings[14].ToString();
                TxtVal16.Text = loadedFnt.Font.char_info[charIndex].charsettings[15].ToString();
                TxtVal17.Text = loadedFnt.Font.char_info[charIndex].charsettings[16].ToString();
                TxtVal18.Text = loadedFnt.Font.char_info[charIndex].charsettings[17].ToString();
                TxtVal19.Text = loadedFnt.Font.char_info[charIndex].charsettings[18].ToString();
                TxtVal20.Text = loadedFnt.Font.char_info[charIndex].charsettings[19].ToString();
                TxtVal21.Text = loadedFnt.Font.char_info[charIndex].charsettings[20].ToString();
                TxtVal22.Text = loadedFnt.Font.char_info[charIndex].charsettings[21].ToString();
                TxtVal23.Text = loadedFnt.Font.char_info[charIndex].charsettings[22].ToString();
                TxtVal24.Text = loadedFnt.Font.char_info[charIndex].charsettings[23].ToString();
                TxtPage.Text = loadedFnt.Font.char_info[charIndex].charsettings[24].ToString();
                TxtVal26.Text = loadedFnt.Font.char_info[charIndex].charsettings[25].ToString();
                TxtVal27.Text = loadedFnt.Font.char_info[charIndex].charsettings[26].ToString();
                TxtVal28.Text = loadedFnt.Font.char_info[charIndex].charsettings[27].ToString();
            }
            else ClearTextVal();

            xtoplpixel = (int)(loadedFnt.Font.char_info[charIndex].x_topleft *
                               loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgawidth);
            ytoplpixel = (int)(loadedFnt.Font.char_info[charIndex].y_topleft *
                               loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgaheight);
            xbottomrpixel = (int)(loadedFnt.Font.char_info[charIndex].x_bottomright *
                                  loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgawidth);
            ybottomrpixel = (int)(loadedFnt.Font.char_info[charIndex].y_bottomright *
                                  loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgaheight);

            TxtCharInfoIndex.Text = loadedFnt.Font.char_info[charIndex].itemNum.ToString();

            TxtXtopL.Text = xtoplpixel.ToString();
            TxtYtopL.Text = ytoplpixel.ToString();
            TxtXbottomR.Text = xbottomrpixel.ToString();
            TxtYbottomR.Text = ybottomrpixel.ToString();
        }



        private void lbChars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbChars.SelectedIndex != -1)
            {
                _showtopleftpixel = false;

                if (loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings != null)
                {
                    CbTGAList.SelectedIndex = loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[24];

                    PopulateCharInfo(LbChars.SelectedIndex);

                    PublishBitmapPictureBox();

                    ChkEnabled.Checked = true;

                    txtWidth.Text = originalTGA[CbTGAList.SelectedIndex].Width.ToString();
                    txtHeight.Text = originalTGA[CbTGAList.SelectedIndex].Height.ToString();
                }
                else
                {
                    PopulateCharInfo(LbChars.SelectedIndex);

                    PublishBitmapPictureBox();

                    ChkEnabled.Checked = false;

                    txtWidth.Text = "0";
                    txtHeight.Text = "0";
                }
            }
        }

        public bool CheckCharCoords()
        {
            bool bResult = true;

            if (xbottomrpixel - xtoplpixel > 127 || xbottomrpixel - xtoplpixel < -128 ||
                ybottomrpixel - ytoplpixel > 127 || ybottomrpixel - ytoplpixel < -128)
            {
                if (xbottomrpixel - xtoplpixel > 127 || xbottomrpixel - xtoplpixel < -128)
                    MessageBox.Show("The size set for the width of the character symbol is lower than -128 " +
                                    "or greater than 127. Please, adjust the X coordinates to update " +
                                    "the char width.", "Warning", MessageBoxButtons.OK);
                else
                    if (ybottomrpixel - ytoplpixel > 127 || ybottomrpixel - ytoplpixel < -128)
                    MessageBox.Show("The size set for the height of the character symbol is lower than -128 " +
                                    "or greater than 127. Please, adjust the Y coordinates to update " +
                                    "the char height.", "Warning", MessageBoxButtons.OK);

                bResult = false;
            }

            return bResult;
        }

        public bool UpdateCoords(bool bDirect)
        {
            int outXtopL, outYtopL, outXbottomR, outYbottomR;
            bool bResult = false;

            if (bDirect)
            {
                // First we will check coordinates values if are correct
                if (Int32.TryParse(TxtXtopL.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out outXtopL) &&
                    Int32.TryParse(TxtYtopL.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out outYtopL) &&
                    Int32.TryParse(TxtXbottomR.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out outXbottomR) &&
                    Int32.TryParse(TxtYbottomR.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out outYbottomR))
                {
                    xtoplpixel = outXtopL;
                    ytoplpixel = outYtopL;
                    xbottomrpixel = outXbottomR;
                    ybottomrpixel = outYbottomR;

                    // Update coordinates in table
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].x_topleft =
                                            (float)xtoplpixel / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgawidth;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].y_topleft =
                                            (float)ytoplpixel / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgaheight;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].x_bottomright =
                                            (float)xbottomrpixel / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgawidth;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].y_bottomright =
                                            (float)ybottomrpixel / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgaheight;

                    bResult = true;

                    PublishBitmapPictureBox();
                }
                else
                {
                    MessageBox.Show("There has been some error trying to parse the texture coordinates into integer.", "Error");
                    bCoordInfoMouseMove = false;
                }
            }
            else
            {
                // Update coordinates in table
                loadedFnt.Font.char_info[LbChars.SelectedIndex].x_topleft =
                                        (float)xtoplpixel / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgawidth;
                loadedFnt.Font.char_info[LbChars.SelectedIndex].y_topleft =
                                        (float)ytoplpixel / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgaheight;
                loadedFnt.Font.char_info[LbChars.SelectedIndex].x_bottomright =
                                        (float)xbottomrpixel / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgawidth;
                loadedFnt.Font.char_info[LbChars.SelectedIndex].y_bottomright =
                                        (float)ybottomrpixel / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgaheight;

                bResult = true;

                PublishBitmapPictureBox();
            }

            return bResult;
        }


        private void UpdateCharValuesWhenCoordinatesChange()
        {
            int iXtopL, iYtopL, iXbottomR, iYbottomR;

            iXtopL = Int32.Parse(TxtXtopL.Text);
            iYtopL = Int32.Parse(TxtYtopL.Text);
            iXbottomR = Int32.Parse(TxtXbottomR.Text);
            iYbottomR = Int32.Parse(TxtYbottomR.Text);

            // Values to update explained.
            // The "By default value" is set after looking at different values in different fonts.

            // Val 17 (L.Spacing): By default 0.
            TxtVal17.Text = "0";

            // Val 18 & 27 (Tex. W): By default Bottom X Coord - Top X Coord
            TxtVal18.Text = (iXbottomR - iXtopL).ToString();
            TxtVal27.Text = TxtVal18.Text;

            // Val 19 (R. Spacing): By default 1.
            TxtVal19.Text = "1";

            // Val 20: By default 0.
            TxtVal20.Text = "0";

            // Val 21 (Top Spacing): By default Bottom Y Coord - Top Y Coord
            TxtVal21.Text = ((iYbottomR - iYtopL) * -1).ToString();

            // Val 22 (Top Scaling): By default -1
            TxtVal22.Text = "-1";
        }


        private void BtnUpdateCoordsCharVals_Click(object sender, EventArgs e)
        {
            // We only will do this when the coordinate values are inside the expected
            // range no matter which coordinates the user clicks.
            if (CheckCharCoords())
            {
                // We will update some character values when coordinates change
                if (UpdateCoords(false))
                {
                    // Then we will update the Char Values with this new coordinates and
                    // the own new Char Values.
                    UpdateCharValuesWhenCoordinatesChange();
                    BtnUpdateValues_Click(sender, e);
                }
            }
        }


        private void BtnUpdateCoords_Click(object sender, EventArgs e)
        {
            if (CheckCharCoords())
            {
                UpdateCoords(true);
            }
        }


        private void BtnUpdateValues_Click(object sender, EventArgs e)
        {
            sbyte val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13, val14;
            sbyte val15, val16, val17, val18, val19, val20, val21, val22, val23, val24, val25, val26, val27, val28;

            // First we will check if character values are correct
            if (SByte.TryParse(TxtVal1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val1) &&
                SByte.TryParse(TxtVal2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val2) &&
                SByte.TryParse(TxtVal3.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val3) &&
                SByte.TryParse(TxtVal4.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val4) &&
                SByte.TryParse(TxtVal5.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val5) &&
                SByte.TryParse(TxtVal6.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val6) &&
                SByte.TryParse(TxtVal7.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val7) &&
                SByte.TryParse(TxtVal8.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val8) &&
                SByte.TryParse(TxtVal9.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val9) &&
                SByte.TryParse(TxtVal10.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val10) &&
                SByte.TryParse(TxtVal11.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val11) &&
                SByte.TryParse(TxtVal12.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val12) &&
                SByte.TryParse(TxtVal13.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val13) &&
                SByte.TryParse(TxtVal14.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val14) &&
                SByte.TryParse(TxtVal15.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val15) &&
                SByte.TryParse(TxtVal16.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val16) &&
                SByte.TryParse(TxtVal17.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val17) &&
                SByte.TryParse(TxtVal18.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val18) &&
                SByte.TryParse(TxtVal19.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val19) &&
                SByte.TryParse(TxtVal20.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val20) &&
                SByte.TryParse(TxtVal21.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val21) &&
                SByte.TryParse(TxtVal22.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val22) &&
                SByte.TryParse(TxtVal23.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val23) &&
                SByte.TryParse(TxtVal24.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val24) &&
                SByte.TryParse(TxtPage.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val25) &&
                SByte.TryParse(TxtVal26.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val26) &&
                SByte.TryParse(TxtVal27.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val27) &&
                SByte.TryParse(TxtVal28.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val28))
            {
                // Let's assign memory to the byte array if it is null  (FREE)
                if (loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings == null)
                {
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings = new sbyte[28];

                    // Now we set the character as usable
                    loadedFnt.Font.chartable[LbChars.SelectedIndex] = (byte)(loadedFnt.Font.loadedchars + 1);
                    loadedFnt.Font.loadedchars++;
                }
                else
                {
                    // Update coordinates in table
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[0] = val1;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[1] = val2;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[2] = val3;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[3] = val4;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[4] = val5;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[5] = val6;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[6] = val7;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[7] = val8;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[8] = val9;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[9] = val10;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[10] = val11;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[11] = val12;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[12] = val13;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[13] = val14;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[14] = val15;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[15] = val16;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[16] = val17;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[17] = val18;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[18] = val19;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[19] = val20;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[20] = val21;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[21] = val22;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[22] = val23;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[23] = val24;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[24] = val25;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[25] = val26;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[26] = val27;
                    loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[27] = val28;
                }
            }
            else
            {
                MessageBox.Show("There has been some error trying to parse the Char Values.\n" +
                                "The only accepted values are between -128 to 127.", "Error");
                bCoordInfoMouseMove = false;
            }


            // First we will check if global font values are correct
            uint uilinespc, uidistleft, uidistright, uidistup, uidistbottom;
            if (uint.TryParse(TxtLineSpacing.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out uilinespc) &&
                uint.TryParse(TxtDistLeft.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out uidistleft) &&
                uint.TryParse(TxtDistRight.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out uidistright) &&
                uint.TryParse(TxtDistUp.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out uidistup) &&
                uint.TryParse(TxtDistBottom.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out uidistbottom))
            {
                loadedFnt.Font.line_spacing = uilinespc;
                loadedFnt.Font.shift_left = uidistleft;
                loadedFnt.Font.shift_right = uidistright;
                loadedFnt.Font.shift_upper = uidistup;
                loadedFnt.Font.shift_lower = uidistbottom;
            }
            else
            {
                MessageBox.Show("There has been some error trying to parse the Global Font values.", "Error");
            }
        }


        private void BtnLoadFont_Click(object sender, EventArgs e)
        {
            // Set filter options and filter index.
            OpenFileDlg.Title = "Open .fnt File";
            OpenFileDlg.Filter = "Font Files (*.fnt)|*.fnt|All Files (*.*)|*.*";
            OpenFileDlg.FilterIndex = 1;
            OpenFileDlg.FileName = null;
            OpenFileDlg.InitialDirectory = FT.strFontPath;

            try
            {
                // Process input if the user clicked OK.
                if (OpenFileDlg.ShowDialog(this) == DialogResult.OK)
                {
                    if (File.Exists(OpenFileDlg.FileName))
                    {
                        bFontLoaded = false;

                        loadedFnt.LoadFont(OpenFileDlg.FileName);

                        TxtFontFile.Text = OpenFileDlg.FileName;

                        // Set global directory for find files
                        pathdirectory = Path.GetDirectoryName(TxtFontFile.Text);

                        // Populate Font information
                        PopulateFontInfo();

                        // Enable Buttons
                        //BtnRegen.Enabled = true;
                        BtnUpdateCoords.Enabled = true;
                        BtnUpdateCoordsCharVals.Enabled = true;
                        BtnUpdateValues.Enabled = true;
                        BtnSaveFont.Enabled = true;
                        BtnSaveFontAs.Enabled = true;


                        GbGlobalFontValues.Enabled = true;
                        GbCharInfoValues.Enabled = true;
                        GbCharCoord.Enabled = true;
                        GbZoom.Enabled = true;

                        ChkEnabled.Enabled = true;

                        TxtMaxChars.Text = loadedFnt.Font.loadedchars.ToString();

                        bFontLoaded = true;

                        _showtopleftpixel = false;

                        // Write new path for font folder
                        FT.strFontPath = pathdirectory;
                        FT.WriteCFGFile();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to load the .fnt file.\nException: " + ex.Message, "Error");
            }

        }

        private void BtnSaveFontAs_Click(object sender, EventArgs e)
        {
            // Set filter options and filter index.
            SaveFileDlg.Title = "Save .fnt File";
            SaveFileDlg.Filter = "Font Files (*.fnt)|*.fnt|All Files (*.*)|*.*";
            SaveFileDlg.FilterIndex = 1;
            SaveFileDlg.FileName = TxtFontFile.Text;

            try
            {
                // Process input if the user clicked OK.
                if (SaveFileDlg.ShowDialog(this) == DialogResult.OK)
                {
                    loadedFnt.SaveFont(SaveFileDlg.FileName);

                    PopulateFontInfoByTop();

                    MessageBox.Show("Font file saved as:\n" + OpenFileDlg.FileName, "Information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to save as... the .fnt file.\nException: " + ex.Message, "Error");
            }
        }

        private void BtnSaveFont_Click(object sender, EventArgs e)
        {
            try
            {
                // Save directly the font
                loadedFnt.SaveFont(TxtFontFile.Text);

                PopulateFontInfoByTop();

                MessageBox.Show("Font file saved.", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to save the .fnt file.\nException: " + ex.Message, "Error");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnRegen_Click(object sender, EventArgs e)
        {
            //int i, j;

            //// This is a demo change. What I pretend is to reorganize if possible
            //// the table of chars
            //FontFile regenFont = new FontFile();

            //// Let's work with header
            //regenFont.Font.num_pages = loadedFnt.Font.num_pages;
            //regenFont.Font.charinfosize = 0;
            //regenFont.Font.version = loadedFnt.Font.version;

            //regenFont.Font.filename = loadedFnt.Font.filename;

            //regenFont.Font.line_spacing = loadedFnt.Font.line_spacing;
            //regenFont.Font.shift_upper = loadedFnt.Font.shift_upper;
            //regenFont.Font.shift_lower = loadedFnt.Font.shift_lower;
            //regenFont.Font.shift_left = loadedFnt.Font.shift_left;
            //regenFont.Font.shift_right = loadedFnt.Font.shift_right;
            //regenFont.Font.offset_charsinfo = 0x124;

            //// Let's regen the chartable from 0 to 256, like normal, assign each value to its suppposed char.
            //regenFont.Font.chartable = new byte[MAX_NUM_CHARS];
            //for (i = 0; i < MAX_NUM_CHARS; i++)
            //{
            //    regenFont.Font.chartable[i] = Convert.ToByte(i);
            //}

            //// Copy the pages
            //regenFont.Font.pageinfo = new PageInfo[regenFont.Font.num_pages];

            //for (i = 0; i < regenFont.Font.num_pages; i++)
            //{
            //    regenFont.Font.pageinfo[i].tgawidth = loadedFnt.Font.pageinfo[i].tgawidth;
            //    regenFont.Font.pageinfo[i].tgaheight = loadedFnt.Font.pageinfo[i].tgaheight;
            //    regenFont.Font.pageinfo[i].tgaoffsetname = loadedFnt.Font.pageinfo[i].tgaoffsetname;
            //    regenFont.Font.pageinfo[i].tgaxxxxx = loadedFnt.Font.pageinfo[i].tgaxxxxx;
            //}

            //regenFont.Font.filename = new byte[loadedFnt.Font.filename.Length];
            //for (j = 0; j < loadedFnt.Font.filename.Length; j++) regenFont.Font.filename[j] = loadedFnt.Font.filename[j];

            //regenFont.Font.buffer = new byte[loadedFnt.Font.buffer.Length];
            //for (j = 0; j < loadedFnt.Font.buffer.Length; j++) regenFont.Font.buffer[j] = loadedFnt.Font.buffer[j];

            //// Copy the char_info
            //regenFont.Font.char_info = new FontFile.CharacterInfo[regenFont.Font.char_info.Length];

            //for (i = 0; i < regenFont.Font.char_info.Length; i++)
            //{
            //    regenFont.Font.char_info[i].charsettings = new sbyte[28];
            //    if (loadedFnt.Font.char_info[i].charsettings != null || i == 0x20)
            //    {
            //        if (i == 0x20) // Special consideration with space
            //        {
            //            for (j = 0; j < 28; j++) regenFont.Font.char_info[i].charsettings[j] = loadedFnt.Font.char_info[i + 3].charsettings[j];
            //            regenFont.Font.char_info[i].charsettings[16] = 0;
            //            regenFont.Font.char_info[i].charsettings[17] = (sbyte)regenFont.Font.line_spacing;
            //            regenFont.Font.char_info[i].charsettings[18] = 0;
            //            regenFont.Font.char_info[i].charsettings[26] = (sbyte)regenFont.Font.line_spacing;

            //            regenFont.Font.char_info[i].x_topleft = 0;
            //            regenFont.Font.char_info[i].y_topleft = 0;
            //            regenFont.Font.char_info[i].x_bottomright = 0;
            //            regenFont.Font.char_info[i].y_bottomright = 0;
            //        }
            //        else
            //        {
            //            for (j = 0; j < 28; j++) regenFont.Font.char_info[i].charsettings[j] = loadedFnt.Font.char_info[i].charsettings[j];

            //            regenFont.Font.char_info[i].x_topleft = loadedFnt.Font.char_info[i].x_topleft;
            //            regenFont.Font.char_info[i].y_topleft = loadedFnt.Font.char_info[i].y_topleft;
            //            regenFont.Font.char_info[i].x_bottomright = loadedFnt.Font.char_info[i].x_bottomright;
            //            regenFont.Font.char_info[i].y_bottomright = loadedFnt.Font.char_info[i].y_bottomright;
            //        }
            //    }


            //}

            //// Calculate the size
            //regenFont.Font.charinfosize = (256 * 44) + 0x124;  // Character table plus header

            //loadedFnt = regenFont;

            //// Update font
            //MessageBox.Show("Font regenerated without issues. Populating...", "Information");

            //// Populate Info
            //PopulateFontInfo();
        }


        public void PopulateFontInfoByTop()
        {
            int tmpIdx = LbChars.TopIndex;
            int tmpIdxSelected = LbChars.SelectedIndex;

            PopulateFontInfo();

            LbChars.SelectedIndex = tmpIdxSelected;
            LbChars.TopIndex = tmpIdx;
        }


        private void cbCodepage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFontLoaded)
            {
                PopulateFontInfoByTop();

                FT.iCodepage = int.Parse(CbCodepage.Items[CbCodepage.SelectedIndex].ToString());
                FT.WriteCFGFile();
            }
        }

        private void LbChars_Leave(object sender, EventArgs e)
        {
            // This avoids flickering the listbox (LbChars) when selecting
            // the ComboBox (cbCodepage)
            LbChars.Update();
        }

        private void TxtXtopL_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int iValue;

            if (int.TryParse(TxtXtopL.Text, out iValue))
            {

                if (iValue < 1 || iValue > loadedFnt.Font.pageinfo[int.Parse(TxtPage.Text)].tgawidth)
                {
                    MessageBox.Show("The value must be between 1 and " +
                                    (loadedFnt.Font.pageinfo[int.Parse(TxtPage.Text)].tgawidth).ToString() +
                                    ".", "Info", MessageBoxButtons.OK);

                    TxtXtopL.Text = xtoplpixel.ToString();

                    e.Cancel = true;
                }
                else
                {
                    xtoplpixel = iValue;
                    _showtopleftpixel = false;
                    PublishBitmapPictureBox();
                }
            }
            else
            {
                MessageBox.Show("The value must be an integer.", "Info", MessageBoxButtons.OK);

                TxtXtopL.Text = xtoplpixel.ToString();

                e.Cancel = true;
            }
        }

        private void TxtYtopL_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int iValue;

            if (int.TryParse(TxtYtopL.Text, out iValue))
            {
                if (iValue < 1 || iValue > loadedFnt.Font.pageinfo[int.Parse(TxtPage.Text)].tgaheight)
                {
                    MessageBox.Show("The value must be between 1 and " +
                                    (loadedFnt.Font.pageinfo[int.Parse(TxtPage.Text)].tgaheight).ToString() +
                                    ".", "Info", MessageBoxButtons.OK);

                    TxtYtopL.Text = ytoplpixel.ToString();

                    e.Cancel = true;
                }
                else
                {
                    ytoplpixel = iValue;
                    _showtopleftpixel = false;
                    PublishBitmapPictureBox();
                }
            }
            else
            {
                MessageBox.Show("The value must be an integer.", "Info", MessageBoxButtons.OK);

                TxtYtopL.Text = ytoplpixel.ToString();

                e.Cancel = true;
            }
        }

        private void TxtXbottomR_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int iValue;

            if (int.TryParse(TxtXbottomR.Text, out iValue))
            {
                if (iValue < 1 || iValue > loadedFnt.Font.pageinfo[int.Parse(TxtPage.Text)].tgawidth)
                {
                    MessageBox.Show("The value must be between 1 and " +
                                    (loadedFnt.Font.pageinfo[int.Parse(TxtPage.Text)].tgawidth).ToString() +
                                    ".", "Info", MessageBoxButtons.OK);

                    TxtXbottomR.Text = xbottomrpixel.ToString();

                    e.Cancel = true;
                }
                else
                {
                    xbottomrpixel = iValue;
                    PublishBitmapPictureBox();
                }
            }
            else
            {
                MessageBox.Show("The value must be an integer.", "Info", MessageBoxButtons.OK);

                TxtXbottomR.Text = xbottomrpixel.ToString();

                e.Cancel = true;
            }
        }

        private void TxtYbottomR_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int iValue;

            if (int.TryParse(TxtYbottomR.Text, out iValue))
            {
                if (iValue < 1 || iValue > loadedFnt.Font.pageinfo[int.Parse(TxtPage.Text)].tgaheight)
                {
                    MessageBox.Show("The value must be between 1 and " +
                                    (loadedFnt.Font.pageinfo[int.Parse(TxtPage.Text)].tgaheight).ToString() +
                                    ".", "Info", MessageBoxButtons.OK);

                    TxtYbottomR.Text = ybottomrpixel.ToString();

                    e.Cancel = true;
                }
                else
                {
                    ybottomrpixel = iValue;
                    PublishBitmapPictureBox();
                }
            }
            else
            {
                MessageBox.Show("The value must be an integer.", "Info", MessageBoxButtons.OK);

                TxtYbottomR.Text = ybottomrpixel.ToString();

                e.Cancel = true;
            }
        }


        private void chkEnabled_Click(object sender, EventArgs e)
        {
            if (bFontLoaded)
            {
                if (ChkEnabled.Checked)
                {
                    if (LbChars.SelectedIndex < 0x7F)
                    {
                        MessageBox.Show("You can only disable characters over 128/0x80 value for safety.",
                                        "Info",
                                        MessageBoxButtons.OK);

                        ChkEnabled.Checked = true;
                    }
                    else
                    {
                        if (MessageBox.Show("Disabling this character means that you will loose all the data.\n" +
                                            "Are you sure about removing this character?",
                                            "Warning",
                                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            // Remove char info for this character
                            TxtMaxChars.Text = loadedFnt.DeleteChar(LbChars.SelectedIndex).ToString();

                            PopulateFontInfoByTop();

                            ChkEnabled.Checked = false;
                        }
                        else
                        {
                            ChkEnabled.Checked = true;
                        }

                    }
                }
                else
                {
                    // Add char info for this character
                    TxtMaxChars.Text = loadedFnt.AddChar(LbChars.SelectedIndex).ToString();

                    PopulateFontInfoByTop();

                    ChkEnabled.Checked = true;
                }
            }
        }


        private void tbZoom_ValueChanged(object sender, EventArgs e)
        {
            if (bFontLoaded)
            {
                iZoomFactor = TbZoom.Value;

                PublishBitmapPictureBox();

                TxtZoom.Text = iZoomFactor.ToString();

            }
        }

        private void btnManagePages_Click(object sender, EventArgs e)
        {
            FormManagePages frmManagePages = new FormManagePages(this);

            frmManagePages.Show();
        }

        private void TxtPage_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int iValue;
            sbyte iOriValue = 0;

            if (loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings != null)
                iOriValue = loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[24];

            if (int.TryParse(TxtPage.Text, out iValue))
            {

                if (iValue >= loadedFnt.Font.num_pages || iValue < 0)
                {
                    MessageBox.Show("The value of the Page must be one number between 0 and " +
                                    (loadedFnt.Font.num_pages - 1).ToString() +
                                    ".", "Info", MessageBoxButtons.OK);

                    TxtPage.Text = iOriValue.ToString();

                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("The value of the Page must be an integer.", "Info", MessageBoxButtons.OK);

                TxtPage.Text = iOriValue.ToString();

                e.Cancel = true;
            }
        }


        //**********************************************************************************************
        //
        // Here we have the basics of the picturebox and the events related to it.
        //
        //**********************************************************************************************

        public static int _xPos;
        public static int _yPos;
        public static int _xPosMouse;
        public static int _yPosMouse;
        public static int _iXOffset;
        public static int _iYOffset;
        public static int _xPosTopLeft;
        public static int _yPosTopLeft;
        private bool _dragging;
        private bool _keycontrol;
        private bool _insidepicturebox;
        private bool _showguides;
        private bool _showtopleftpixel;

        private void pbFont_Paint(object sender, PaintEventArgs e)
        {
            if (!bFontLoaded) return;

            if (bCoordInfoMouseMove)
            {
                e.Graphics.DrawImage(bmpCoordInfo, rectCoordInfo);
            }

            if (_showguides)
            {
                Pen p = new Pen(Color.Gold, 1 * TbZoom.Value);

                e.Graphics.DrawLine(p, new PointF(_xPosMouse - pbFont.Width, _yPosMouse),
                                       new PointF(_yPosMouse + pbFont.Width, _yPosMouse));
                e.Graphics.DrawLine(p, new PointF(_xPosMouse, _yPosMouse - pbFont.Width), new
                                           PointF(_xPosMouse, _yPosMouse + pbFont.Width));
            }

            if (_showtopleftpixel)
            {
                SolidBrush b = new SolidBrush(Color.Gold);

                e.Graphics.FillRectangle(b, ((_xPosTopLeft - 1) * TbZoom.Value), ((_yPosTopLeft - 1) * TbZoom.Value), 
                                            1 * TbZoom.Value, 1 * TbZoom.Value);
            }
        }

        private void pbFont_MouseLeave(object sender, EventArgs e)
        {
            if (!bFontLoaded) return;

            _insidepicturebox = false;
            _showguides = false;

            bCoordInfoMouseMove = false;
            PrepareCoordsInfo();
            pbFont.Refresh();
        }

        private void pbFont_MouseEnter(object sender, EventArgs e)
        {
            if (!bFontLoaded) return;

            _insidepicturebox = true;
            _showguides = true;

            pbFont.Refresh();
        }

        private void pbFont_MouseClick(object sender, MouseEventArgs e)
        {

            if (sender == null || !bFontLoaded || !_keycontrol) return;

            if (e.Button == MouseButtons.Left)
            {
                TxtXtopL.Text = ((e.X / iZoomFactor) + 1).ToString();
                TxtYtopL.Text = ((e.Y / iZoomFactor) + 1).ToString();

                xtoplpixel = ((e.X / iZoomFactor) + 1);
                ytoplpixel = ((e.Y / iZoomFactor) + 1);

                _xPosTopLeft = xtoplpixel;
                _yPosTopLeft = ytoplpixel;

                _showtopleftpixel = true;

                PublishBitmapPictureBox();
            }

            if (e.Button == MouseButtons.Right)
            {
                TxtXbottomR.Text = ((e.X / iZoomFactor) + 1).ToString();
                TxtYbottomR.Text = ((e.Y / iZoomFactor) + 1).ToString();

                xbottomrpixel = ((e.X / iZoomFactor) + 1);
                ybottomrpixel = ((e.Y / iZoomFactor) + 1);

                _showtopleftpixel = false;

                PublishBitmapPictureBox();
            }

        }

        private void PrepareCoordsInfo()
        {
            int xCursor, yCursor;

            xCursor = (_xPosMouse / iZoomFactor) + 1;
            yCursor = (_yPosMouse / iZoomFactor) + 1;

            using (Graphics g = Graphics.FromImage(bmpCoordInfo))
            {
                //if (_xPosMouse > ((256 * iZoomFactor) / 2))
                if (_xPosMouse > Math.Abs(pbFont.Left) + 256)
                {
                    xCursor = _xPosMouse - (bmpCoordInfo.Width + 10);
                }
                else
                {
                    xCursor = _xPosMouse + 10;
                }

                //if (_yPosMouse > ((256 * iZoomFactor) / 2))
                if (_yPosMouse > Math.Abs(pbFont.Top) + 256)
                {
                    yCursor = _yPosMouse - (bmpCoordInfo.Height + 10);
                }
                else
                {
                    yCursor = _yPosMouse + 10;
                }

                using (var br = new SolidBrush(Color.Lavender))
                {
                    ImageTools.FillRoundedRectangle(g,
                                                    new Rectangle(0, 0, bmpCoordInfo.Width - 1,
                                                                        bmpCoordInfo.Height - 1),
                                                    7, br);
                }

                using (var p = new Pen(Color.DarkSlateBlue, 1))
                {
                    ImageTools.DrawRoundedRectangle(g,
                                                    new Rectangle(0, 0, bmpCoordInfo.Width - 1,
                                                                        bmpCoordInfo.Height - 1),
                                                    7, p);
                }

                g.DrawString(" X: " + ((_xPosMouse / iZoomFactor) + 1).ToString("0000") +
                             "\n\r Y: " + ((_yPosMouse / iZoomFactor) + 1).ToString("0000"),
                             new Font("Tahoma", 10, FontStyle.Bold),
                             new SolidBrush(Color.DarkBlue), 4, 0);
            }

            // Define Rectangle Part
            rectCoordInfo = new Rectangle(xCursor, yCursor, bmpCoordInfo.Width, bmpCoordInfo.Height);
            bmpCoordInfo = ImageTools.ChangeOpacity(bmpCoordInfo, 0.8f);
        }



        private void pbFont_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_insidepicturebox) return;

            _xPosMouse = e.X;
            _yPosMouse = e.Y;

            if (_dragging)
            {
                PanelPbFont.AutoScrollPosition =
                        new Point(-(PanelPbFont.AutoScrollPosition.X + e.X - _xPos),
                                  -(PanelPbFont.AutoScrollPosition.Y + e.Y - _yPos));
                pbFont.Refresh();

                return;
            }

            if (_keycontrol)
            {
                PrepareCoordsInfo();
                bCoordInfoMouseMove = true;
                pbFont.Refresh();

                return;
            }

            pbFont.Invalidate();

        }


        private void FontEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (!bFontLoaded) return;

            if (e.KeyCode == Keys.ControlKey && _insidepicturebox)
            {
                _keycontrol = true;
                bCoordInfoMouseMove = true;
                PrepareCoordsInfo();
                pbFont.Refresh();
            }
        }

        private void FontEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (!bFontLoaded) return;

            if (e.KeyCode == Keys.ControlKey)
            {
                _keycontrol = false;
                bCoordInfoMouseMove = false;
                pbFont.Refresh();
            }
        }


        private void pbFont_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

            if (_keycontrol && !_insidepicturebox) return;

            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;
                _xPos = e.X;
                _yPos = e.Y;
            }
        }

        private void pbFont_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender == null) return;
            _dragging = false;
        }


        private void PbFont_MouseWheel(object sender, MouseEventArgs e)
        {
            int iX, iY;

            if (!bFontLoaded || _keycontrol) return;

            iX = e.X / TbZoom.Value;
            iY = e.Y / TbZoom.Value;

            if (e.Delta != 0)
            {
                if (e.Delta > 0 && TbZoom.Value != TbZoom.Maximum)
                {
                    if (TbZoom.Value < TbZoom.Maximum) TbZoom.Value += 1;

                    _iXOffset = (iX * TbZoom.Value) - 256;
                    _iYOffset = (iY * TbZoom.Value) - 256;
                }

                if (e.Delta < 0 && TbZoom.Value != TbZoom.Minimum)
                {
                    if (TbZoom.Value > TbZoom.Minimum) TbZoom.Value -= 1;

                    _iXOffset = (iX * TbZoom.Value) - 256;
                    _iYOffset = (iY * TbZoom.Value) - 256;
                }

                PanelPbFont.AutoScrollPosition = new Point(_iXOffset, _iYOffset);
            }
        }
    }



    // Let's leave that MouseWheel events for the Panel don't touch the Scrollbars
    public class WheelessPanel : Panel
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            // base.OnMouseWheel(e);
        }
    }

}
