using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace VtMBFontEditor
{

    public partial class FontFile
    {
        // I use this value in header to test a different generation method of the
        // font. Please, don't use this value unless you know what are you doing.
        public const int CHARTABLESIZE_MAX = 0x2BD4;

        public HDR Font;

        public struct HDR
        {
            public uint num_pages;              // Image files like -page0.tth, -page1.tth...
            public uint charinfosize;               // normally 0x21CC, but depends on char_info and
                                                // the file_info is not counted
            public uint version;                // Always 1?
            public uint line_spacing;           // Always 8?
            public uint shift_upper;            // ?
            public uint shift_lower;            // ?
            public uint shift_left;             // ?
            public uint shift_right;            // ?
            public uint offset_charsinfo;       // normally 0x124
            public byte[] chartable;            // normally always 256 (an array of 256 bytes)

            public CharacterInfo[] char_info;   // normally always 190

            public PageInfo[] pageinfo;         // The .fnt file has the same number of fileinfo as the pages.
            public byte[] filename;             // Lastly we have the name of the last page filename ending with 0 (zero).

            //public byte[] buffer;               // In some fonts I found unknown information relative to other fonts.
            //                                    // Not sure if needed, but we will save it also.

            public int loadedchars;             // Here we will write the real number of chars that has data.

            public HDR()
            {
                num_pages = 1;
                charinfosize = 0x21CC;

                version = 1;
                line_spacing = 0;
                shift_upper = 0;
                shift_lower = 0;
                shift_left = 0;
                shift_right = 0;
                offset_charsinfo = 0x124;

                chartable = new byte[FontEditor.MAX_NUM_CHARS];

                char_info = new CharacterInfo[FontEditor.MAX_NUM_CHARS];

                pageinfo = new PageInfo[1];
                filename = new byte[1];
                //buffer = new byte[1];
            }
        }

        public struct CharacterInfo
        {
            public sbyte[] charsettings;         // normally 28 bytes
            public float x_topleft;
            public float y_topleft;
            public float x_bottomright;
            public float y_bottomright;

            public int itemNum;
            public bool enabled;

            public CharacterInfo()
            {
                charsettings = new sbyte[28];

                x_topleft = 0;
                y_topleft = 0;
                x_bottomright = 0;
                y_bottomright = 0;

                enabled = false;
            }
        }

        public struct PageInfo
        {
            public uint tgawidth;                // normally 256
            public uint tgaheight;               // normally 256
            public uint tgaoffsetname;                // normally 16
            public uint tgaxxxxx;                // normally 0

            public PageInfo()
            {
                tgawidth = 256;
                tgaheight = 256;
                tgaoffsetname = 16;
                tgaxxxxx = 0;
            }
        }

        public FontFile()
        {
            Font = new HDR();
        }

        // Let's load the .fnt file
        private int GetFileNameLength(BinaryReader fntReader)
        {
            byte tmpReadByte;
            int counter;
            long oldBaseStreamPosition = fntReader.BaseStream.Position;

            tmpReadByte = fntReader.ReadByte();
            counter = 1;

            while (tmpReadByte != 0)
            {
                tmpReadByte = fntReader.ReadByte();
                counter++;
            }

            fntReader.BaseStream.Position = oldBaseStreamPosition;

            return counter;
        }

        public void LoadFont(string filename)
        {
            byte[] fntArray;

            // We will clear first the memory data of the previous font if any.
            fntArray = File.ReadAllBytes(filename);

            using (var fntMemory = new MemoryStream(fntArray))
            {
                using (var fntReader = new BinaryReader(fntMemory, Encoding.ASCII, false))
                {
                    Font.num_pages = fntReader.ReadUInt32();
                    Font.charinfosize = fntReader.ReadUInt32();

                    Font.version = fntReader.ReadUInt32();
                    Font.line_spacing = fntReader.ReadUInt32();
                    Font.shift_upper = fntReader.ReadUInt32();
                    Font.shift_lower = fntReader.ReadUInt32();
                    Font.shift_left = fntReader.ReadUInt32();
                    Font.shift_right = fntReader.ReadUInt32();
                    Font.offset_charsinfo = fntReader.ReadUInt32();

                    Font.chartable = fntReader.ReadBytes(FontEditor.MAX_NUM_CHARS);

                    // now read each character info
                    int counter = 0;
                    int i, charIdx;

                    for (i = 0x21; i < FontEditor.MAX_NUM_CHARS; i++)
                    {
                        charIdx = Array.IndexOf(Font.chartable, (byte)(i - 0x21), 0x21);
                        
                        //if (Font.chartable[i] != 0xD || (Font.chartable[i] == 0xD && i == 46))
                        if (charIdx > -1)
                        {
                            Font.char_info[charIdx].charsettings = new sbyte[28];

                            for (int j = 0; j < 28; j++)
                            {
                                Font.char_info[charIdx].charsettings[j] = fntReader.ReadSByte();
                            }

                            Font.char_info[charIdx].x_topleft = fntReader.ReadSingle();
                            Font.char_info[charIdx].y_topleft = fntReader.ReadSingle();
                            Font.char_info[charIdx].x_bottomright = fntReader.ReadSingle();
                            Font.char_info[charIdx].y_bottomright = fntReader.ReadSingle();

                            Font.char_info[charIdx].enabled = true;

                            Font.char_info[charIdx].itemNum = counter;

                            counter++;
                        }
                    }

                    //  Let's write the number of loaded chars
                    Font.loadedchars = counter - 1;

                    // finally read fileinfo part for each numpage
                    Font.pageinfo = new PageInfo[Font.num_pages];

                    for (i = 0; i < Font.num_pages; i++)
                    {
                        Font.pageinfo[i].tgawidth = fntReader.ReadUInt32();
                        Font.pageinfo[i].tgaheight = fntReader.ReadUInt32();
                        Font.pageinfo[i].tgaoffsetname = fntReader.ReadUInt32();
                        Font.pageinfo[i].tgaxxxxx = fntReader.ReadUInt32();
                    }

                    // Get the font filename in .fnt file. We will read it as bytes until byte = 0 found.
                    counter = GetFileNameLength(fntReader);
                    Font.filename = new byte[counter];
                    Font.filename = fntReader.ReadBytes(counter);

                    // Get the last bytes of the file in a byte array.
                    //if (fntReader.BaseStream.Length > fntReader.BaseStream.Position)
                    //{
                    //    Font.buffer = new byte[fntReader.BaseStream.Length - fntReader.BaseStream.Position];
                    //    Font.buffer = fntReader.ReadBytes((int)fntReader.BaseStream.Length - (int)fntReader.BaseStream.Position);
                    //}
                }
            }
        }

        
        private void ReOrderCharTable()
        {
            int iMaxValue = 0, i;

            // Here we will make linear the characters in chartable.
            // So, if we have: "0D 70 71 BF 0D 72", we have now: "0D 70 71 72 0D 73".
            // This must match later the individual character info in the font.
            
            // First let's get the maximum value below 0x80.
            for (i = 0; i < 0x80; i++)
            {
                if (iMaxValue < Font.chartable[i]) iMaxValue = Font.chartable[i];
            }

            // Now let's update the values in the chartable above 0x80 (included).
            iMaxValue++;

            for (i = 0x80; i <= 0xFF; i++)
            {
                if (Font.chartable[i] != 0xD) Font.chartable[i] = (byte)iMaxValue++;
            }
        }


        // With this function we calculate the offset of the filename page
        // for a given page index.
        // bNumPagesUpdated means that we can call this from ManagePages Form or SaveFont function.
        // formula = (iFontNameLength * iPageIdx) + (16 * ((int)Font.num_pages - iPageIdx));
        public int CalculateOffsetNameAtIndex(int iPageIdx)
        {
            int tmpIndex = 0, i;
            int iFontNameLength = Font.filename.Length;
            int iNumPages;

            iNumPages = (int)Font.num_pages;

            //if (!bNumPagesUpdated) iNumPages++;

            if (iPageIdx < 10)
            {
                tmpIndex = (iFontNameLength * iPageIdx) + (16 * (iNumPages - iPageIdx));
            }
            else
            {
                tmpIndex = (iFontNameLength * 10) + ((iFontNameLength + 1) * (iPageIdx - 10));
                tmpIndex += (16 * (iNumPages - iPageIdx));
            }

            return tmpIndex;
        }


        // Let's save the .fnt file
        public void SaveFont(string filename)
        {
            int i = 0, j = 0;

            // First, let's write the header
            // Let's prepare the dynamic Memory Writer
            MemoryStream fntArray = new MemoryStream();
            BinaryWriter fntWriter = new BinaryWriter(fntArray);

            // - Put Font HDR in memory Byte Array
            fntWriter.Write(Font.num_pages);
            fntWriter.Write(Font.charinfosize);

            fntWriter.Write(Font.version);
            fntWriter.Write(Font.line_spacing);
            fntWriter.Write(Font.shift_upper);
            fntWriter.Write(Font.shift_lower);
            fntWriter.Write(Font.shift_left);
            fntWriter.Write(Font.shift_right);
            fntWriter.Write(Font.offset_charsinfo);

            // - Write Char Table
            ReOrderCharTable();
            fntWriter.Write(Font.chartable);

            // - Write Character Info Values
            for (i = 0x21; i < FontEditor.MAX_NUM_CHARS; i++)
            {
                if (Font.char_info[i].charsettings != null)
                {
                    for (j = 0; j < 28; j++)
                    {
                        fntWriter.Write(Font.char_info[i].charsettings[j]);
                    }

                    fntWriter.Write(Font.char_info[i].x_topleft);
                    fntWriter.Write(Font.char_info[i].y_topleft);
                    fntWriter.Write(Font.char_info[i].x_bottomright);
                    fntWriter.Write(Font.char_info[i].y_bottomright);
                }
            }

            // - Write File Info for each page
            for (i = 0; i < Font.num_pages; i++)
            {
                fntWriter.Write(Font.pageinfo[i].tgawidth);
                fntWriter.Write(Font.pageinfo[i].tgaheight);

                // We need to recalculate the offsets in case we added new pages
                // We do this even we have not added new pages for fixing fonts if needed                
                Font.pageinfo[i].tgaoffsetname = (uint)CalculateOffsetNameAtIndex(i);
                fntWriter.Write(Font.pageinfo[i].tgaoffsetname);

                fntWriter.Write(Font.pageinfo[i].tgaxxxxx);
            }

            // - Lastly we write the filenames
            byte[] tmpFilename = [];

            for (i = 0; i < Font.num_pages; i++)
            {
                if (i < 10)
                {
                    tmpFilename = new byte[Font.filename.Length];

                    for (j = 0; j < Font.filename.Length - 2; j++)
                    {
                        tmpFilename[j] = Font.filename[j];
                    }

                    tmpFilename[Font.filename.Length - 2] = (byte)(i.ToString("0"))[0];
                    tmpFilename[Font.filename.Length - 1] = 0;
                }
                else
                {
                    tmpFilename = new byte[Font.filename.Length + 1];

                    for (j = 0; j < Font.filename.Length - 2; j++)
                    {
                        tmpFilename[j] = Font.filename[j];
                    }

                    tmpFilename[Font.filename.Length - 3] = (byte)(i.ToString("00"))[0];
                    tmpFilename[Font.filename.Length - 2] = (byte)(i.ToString("00"))[1];
                    tmpFilename[Font.filename.Length - 1] = 0;
                }

                //fntSaveWriter.Write(Font.filename);
                fntWriter.Write(tmpFilename);
            }

            // - Write Font in memory to file.
            File.WriteAllBytes(filename, fntArray.ToArray());

        }

        public int DeleteChar(int iIdxChar)
        {
            Font.chartable[iIdxChar] = 0x0D;
            Font.char_info[iIdxChar].charsettings = null;
            Font.char_info[iIdxChar].enabled = false;

            Font.char_info[iIdxChar].itemNum = 0;
            Font.char_info[iIdxChar].x_topleft = 0;
            Font.char_info[iIdxChar].y_topleft = 0;
            Font.char_info[iIdxChar].x_bottomright = 0;
            Font.char_info[iIdxChar].y_bottomright = 0;

            Font.loadedchars--;

            return Font.loadedchars;
        }


        public int AddChar(int iIdxChar)
        {
            Font.chartable[iIdxChar] = (byte)(Font.loadedchars + 1);

            Font.char_info[iIdxChar].itemNum =Font.chartable[iIdxChar];
            Font.char_info[iIdxChar].x_topleft = 0.0f;
            Font.char_info[iIdxChar].y_topleft = 0.0f;
            Font.char_info[iIdxChar].x_bottomright = 10.0f;
            Font.char_info[iIdxChar].y_bottomright = 10.0f;
            Font.char_info[iIdxChar].enabled = true;
            Font.char_info[iIdxChar].charsettings = new sbyte[28];

            Font.loadedchars++;

            return Font.loadedchars;
        }
    }
}
