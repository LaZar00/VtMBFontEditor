using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static VtMBFontEditor.FontFile;

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

        public int xtoplpixel, ytoplpixel, xbottomrpixel, ybottomrpixel;

        public FontEditor()
        {
            loadedFnt = new FontFile();
            originalTGA = new Bitmap[1];
            workingImg = new Bitmap(1, 1);
            pathdirectory = "";

            InitializeComponent();
        }


        private int FindCharInCharTable(byte char2find)
        {
            int iValue = 0;
            bool bFound = false;

            while (iValue < MAX_NUM_CHARS && !bFound)
            {
                if (loadedFnt.Font.chartable[iValue] == char2find)
                {
                    bFound = true;
                }
                else iValue++;
            }

            if (!bFound) iValue = 0;

            return iValue;
        }


        private void InitializeList()
        {
            LbChars.BeginUpdate();
            LbChars.Items.Clear();

            for (int i = 0; i < MAX_NUM_CHARS; i++) LbChars.Items.Add(i.ToString("000") + "  " +
                                                                      "-" +
                                                                      "  [0x" + i.ToString("X2") + "]");
            LbChars.EndUpdate();
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
            // We will load the TGA files (if the image exists) and have it in memory
            // Initialize the array of bitmaps
            originalTGA = new Bitmap[loadedFnt.Font.num_pages];

            for (int i = 0; i < loadedFnt.Font.num_pages; i++)
            {
                string fileTGA = pathdirectory + "\\" + CbTGAList.Items[i];

                if (File.Exists(fileTGA))
                {
                    originalTGA[i] = Paloma.TargaImage.LoadTargaImage(fileTGA);
                }
                else
                {
                    originalTGA[i] = new Bitmap(256, 256);

                    RectangleF rectf = new RectangleF(15, 110, 256, 60);

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
            int chartableIndex = 0;

            // General Fnt Info
            TxtPages.Text = loadedFnt.Font.num_pages.ToString();
            TxtLineSpacing.Text = loadedFnt.Font.line_spacing.ToString();

            TxtDistLeft.Text = loadedFnt.Font.shift_left.ToString();
            TxtDistRight.Text = loadedFnt.Font.shift_right.ToString();
            TxtDistUp.Text = loadedFnt.Font.shift_upper.ToString();
            TxtDistBottom.Text = loadedFnt.Font.shift_lower.ToString();

            // Char Info
            InitializeList();

            // Fill the ListBox
            string tmpString;

            for (int i = 0; i < MAX_NUM_CHARS; i++)
            {
                chartableIndex = FindCharInCharTable((byte)i);

                if (i > 0x1F)
                {
                    if (i >= 0x80 && i < 0xA1)
                    {
                        // I need to do this individual chars because the converter does not apply them.
                        tmpString = chartableIndex.ToString("000") + "/" + i.ToString("000") + "  ";

                        switch (i)
                        {
                            case 0x80: tmpString += "€"; break;
                            case 0x81: tmpString += "-"; break;
                            case 0x82: tmpString += "‚"; break;
                            case 0x83: tmpString += "ƒ"; break;
                            case 0x84: tmpString += "„"; break;
                            case 0x85: tmpString += "…"; break;
                            case 0x86: tmpString += "†"; break;
                            case 0x87: tmpString += "‡"; break;
                            case 0x88: tmpString += "ˆ"; break;
                            case 0x89: tmpString += "‰"; break;
                            case 0x8A: tmpString += "Š"; break;
                            case 0x8B: tmpString += "‹"; break;
                            case 0x8C: tmpString += "Œ"; break;
                            case 0x8D: tmpString += "-"; break;
                            case 0x8E: tmpString += "Ž"; break;
                            case 0x8F: tmpString += "-"; break;
                            case 0x90: tmpString += "-"; break;
                            case 0x91: tmpString += "‘"; break;
                            case 0x92: tmpString += "’"; break;
                            case 0x93: tmpString += "“"; break;
                            case 0x94: tmpString += "”"; break;
                            case 0x95: tmpString += "•"; break;
                            case 0x96: tmpString += "–"; break;
                            case 0x97: tmpString += "—"; break;
                            case 0x98: tmpString += "˜"; break;
                            case 0x99: tmpString += "™"; break;
                            case 0x9A: tmpString += "š"; break;
                            case 0x9B: tmpString += "›"; break;
                            case 0x9C: tmpString += "œ"; break;
                            case 0x9D: tmpString += "-"; break;
                            case 0x9E: tmpString += "ž"; break;
                            case 0x9F: tmpString += "Ÿ"; break;
                            case 0xA0: tmpString += " "; break;
                        }

                        tmpString += "  [0x" + i.ToString("X2") + "]";

                    }
                    else
                    {
                        tmpString = chartableIndex.ToString("000") + "/" + i.ToString("000") + "  " +
                                    Convert.ToChar(i) +
                                    "  [0x" + i.ToString("X2") + "]";
                    }

                    LbChars.Items[i] = tmpString;
                }
            }

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
            // Create a Pen class instance
            Pen pen = new Pen(Color.FromKnownColor(KnownColor.Yellow), 1);

            // Draw the rectangle
            g.DrawRectangle(pen, xtoplpixel, ytoplpixel, xbottomrpixel - xtoplpixel, ybottomrpixel - ytoplpixel);
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

            if (PictureBoxFont.Image != null)
            {
                PictureBoxFont.Image.Dispose();
            }

            PictureBoxFont.Image = new Bitmap(PictureBoxFont.Width, PictureBoxFont.Height);

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

                    g.DrawImage(workingImg, new Rectangle(0, 0, workingImg.Width, workingImg.Height),
                                                          0, 0, workingImg.Width, workingImg.Height,
                                                          GraphicsUnit.Pixel);
                }

                workingImg = new Bitmap(tmpAdjustBmp);
            }

            // Finally we assign the working image to the picturebox 512x512 to show the result
            using (Graphics g = Graphics.FromImage(PictureBoxFont.Image))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.PixelOffsetMode = PixelOffsetMode.Half;

                g.DrawImage(workingImg, new Rectangle(0, 0, PictureBoxFont.Width, PictureBoxFont.Height),
                                        0, 0, workingImg.Width, workingImg.Height,
                                        GraphicsUnit.Pixel);
            }

            //PictureBoxFont.Image = new Bitmap(workingImg);
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
            TxtVal25.Text = "0";
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
                TxtVal25.Text = loadedFnt.Font.char_info[charIndex].charsettings[24].ToString();
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


        private void UpdateImageWithMarkedChar()
        {


            using (Graphics g = Graphics.FromImage(workingImg))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.PixelOffsetMode = PixelOffsetMode.Half;

                g.DrawImage(originalTGA[CbTGAList.SelectedIndex], 0, 0, workingImg.Width, workingImg.Height);
            }

            PictureBoxFont.Image = new Bitmap(workingImg);
        }

        private void lbChars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbChars.SelectedIndex != -1)
            {
                if (loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings != null)
                {
                    CbTGAList.SelectedIndex = loadedFnt.Font.char_info[LbChars.SelectedIndex].charsettings[24];

                    PopulateCharInfo(LbChars.SelectedIndex);

                    PublishBitmapPictureBox();
                }
                else
                {
                    PopulateCharInfo(LbChars.SelectedIndex);

                    PublishBitmapPictureBox();
                }
            }
        }

        private void BtnUpdateCoords_Click(object sender, EventArgs e)
        {
            int outXtopL, outYtopL, outXbottomR, outYbottomR;

            // First we will check coordinates values if are correct
            if (Int32.TryParse(TxtXtopL.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out outXtopL) &&
                Int32.TryParse(TxtYtopL.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out outYtopL) &&
                Int32.TryParse(TxtXbottomR.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out outXbottomR) &&
                Int32.TryParse(TxtYbottomR.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out outYbottomR))
            {
                // Update coordinates in table
                loadedFnt.Font.char_info[LbChars.SelectedIndex].x_topleft =
                                        (float)outXtopL / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgawidth;
                loadedFnt.Font.char_info[LbChars.SelectedIndex].y_topleft =
                                        (float)outYtopL / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgaheight;
                loadedFnt.Font.char_info[LbChars.SelectedIndex].x_bottomright =
                                        (float)outXbottomR / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgawidth;
                loadedFnt.Font.char_info[LbChars.SelectedIndex].y_bottomright =
                                        (float)outYbottomR / loadedFnt.Font.pageinfo[CbTGAList.SelectedIndex].tgaheight;

                xtoplpixel = outXtopL;
                ytoplpixel = outYtopL;
                xbottomrpixel = outXbottomR;
                ybottomrpixel = outYbottomR;

                PublishBitmapPictureBox();
            }
            else
            {
                MessageBox.Show("There has been some error trying to parse the texture coordinates into integer.", "Error");
            }
        }


        private void BtnUpdateValues_Click(object sender, EventArgs e)
        {
            sbyte val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13, val14;
            sbyte val15, val16, val17, val18, val19, val20, val21, val22, val23, val24, val25, val26, val27, val28;

            // First we will check coordinates values if are correct
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
                SByte.TryParse(TxtVal25.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val25) &&
                SByte.TryParse(TxtVal26.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val26) &&
                SByte.TryParse(TxtVal27.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val27) &&
                SByte.TryParse(TxtVal28.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out val28))
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
            else
            {
                MessageBox.Show("There has been some error trying to parse the character information into signed byte.", "Error");
            }
        }


        private void BtnLoadFont_Click(object sender, EventArgs e)
        {
            // Set filter options and filter index.
            OpenFileDlg.Title = "Open .fnt File";
            OpenFileDlg.Filter = "Font Files (*.fnt)|*.fnt|All Files (*.*)|*.*";
            OpenFileDlg.FilterIndex = 1;
            OpenFileDlg.FileName = null;

            try
            {
                // Process input if the user clicked OK.
                if (OpenFileDlg.ShowDialog(this) == DialogResult.OK)
                {
                    if (File.Exists(OpenFileDlg.FileName))
                    {
                        loadedFnt.LoadFont(OpenFileDlg.FileName);

                        TxtFontFile.Text = OpenFileDlg.FileName;

                        // Set global directory for find files
                        pathdirectory = Path.GetDirectoryName(TxtFontFile.Text);

                        // Populate Font information
                        PopulateFontInfo();

                        // Enable Buttons
                        BtnRegen.Enabled = true;
                        BtnUpdateCoords.Enabled = true;
                        BtnUpdateValues.Enabled = true;
                        BtnSaveFont.Enabled = true;
                        BtnSaveFontAs.Enabled = true;

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
            int i, j;

            // This is a demo change. What I pretend is to reorganize if possible
            // the table of chars
            FontFile regenFont = new FontFile();

            // Let's work with header
            regenFont.Font.num_pages = loadedFnt.Font.num_pages;
            regenFont.Font.charinfosize = 0;
            regenFont.Font.version = loadedFnt.Font.version;

            regenFont.Font.filename = loadedFnt.Font.filename;

            regenFont.Font.line_spacing = loadedFnt.Font.line_spacing;
            regenFont.Font.shift_upper = loadedFnt.Font.shift_upper;
            regenFont.Font.shift_lower = loadedFnt.Font.shift_lower;
            regenFont.Font.shift_left = loadedFnt.Font.shift_left;
            regenFont.Font.shift_right = loadedFnt.Font.shift_right;
            regenFont.Font.offset_charsinfo = 0x124;

            // Let's regen the chartable from 0 to 256, like normal, assign each value to its suppposed char.
            regenFont.Font.chartable = new byte[MAX_NUM_CHARS];
            for (i = 0; i < MAX_NUM_CHARS; i++)
            {
                regenFont.Font.chartable[i] = Convert.ToByte(i);
            }

            // Copy the pages
            regenFont.Font.pageinfo = new PageInfo[regenFont.Font.num_pages];

            for (i = 0; i < regenFont.Font.num_pages; i++)
            {
                regenFont.Font.pageinfo[i].tgawidth = loadedFnt.Font.pageinfo[i].tgawidth;
                regenFont.Font.pageinfo[i].tgaheight = loadedFnt.Font.pageinfo[i].tgaheight;
                regenFont.Font.pageinfo[i].tgacolor = loadedFnt.Font.pageinfo[i].tgacolor;
                regenFont.Font.pageinfo[i].tgaxxxxx = loadedFnt.Font.pageinfo[i].tgaxxxxx;
            }

            regenFont.Font.filename = new byte[loadedFnt.Font.filename.Length];
            for (j = 0; j < loadedFnt.Font.filename.Length; j++) regenFont.Font.filename[j] = loadedFnt.Font.filename[j];

            regenFont.Font.buffer = new byte[loadedFnt.Font.buffer.Length];
            for (j = 0; j < loadedFnt.Font.buffer.Length; j++) regenFont.Font.buffer[j] = loadedFnt.Font.buffer[j];

            // Copy the char_info
            regenFont.Font.char_info = new FontFile.CharacterInfo[regenFont.Font.char_info.Length];

            for (i = 0; i < regenFont.Font.char_info.Length; i++)
            {
                regenFont.Font.char_info[i].charsettings = new sbyte[28];
                if (loadedFnt.Font.char_info[i].charsettings != null || i == 0x20)
                {
                    if ( i == 0x20) // Special consideration with space
                    {
                        for (j = 0; j < 28; j++) regenFont.Font.char_info[i].charsettings[j] = loadedFnt.Font.char_info[i + 3].charsettings[j];
                        regenFont.Font.char_info[i].charsettings[16] = 0;
                        regenFont.Font.char_info[i].charsettings[17] = (sbyte)regenFont.Font.line_spacing;
                        regenFont.Font.char_info[i].charsettings[18] = 0;
                        regenFont.Font.char_info[i].charsettings[26] = (sbyte)regenFont.Font.line_spacing;

                        regenFont.Font.char_info[i].x_topleft = 0;
                        regenFont.Font.char_info[i].y_topleft = 0;
                        regenFont.Font.char_info[i].x_bottomright = 0;
                        regenFont.Font.char_info[i].y_bottomright = 0;
                    }
                    else
                    {
                        for (j = 0; j < 28; j++) regenFont.Font.char_info[i].charsettings[j] = loadedFnt.Font.char_info[i].charsettings[j];

                        regenFont.Font.char_info[i].x_topleft = loadedFnt.Font.char_info[i].x_topleft;
                        regenFont.Font.char_info[i].y_topleft = loadedFnt.Font.char_info[i].y_topleft;
                        regenFont.Font.char_info[i].x_bottomright = loadedFnt.Font.char_info[i].x_bottomright;
                        regenFont.Font.char_info[i].y_bottomright = loadedFnt.Font.char_info[i].y_bottomright;
                    }                    
                }


            }

            // Calculate the size
            regenFont.Font.charinfosize = (256 * 44) + 0x124;  // Character table plus header

            loadedFnt = regenFont;

            // Update font
            MessageBox.Show("Font regenerated without issues. Populating...", "Information");

            // Populate Info
            PopulateFontInfo();
        }
    }
}
