using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VtMBFontEditor
{
    public class FontFile
    {
        public const int CHARTABLESIZE_DEFAULT = 0x21CC;

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

            public byte[] buffer;               // In some fonts I found unknown information relative to other fonts.
                                                // Not sure if needed, but we will save it also.

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
                buffer = new byte[1];
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

            public CharacterInfo()
            {
                charsettings = new sbyte[28];

                x_topleft = 0;
                y_topleft = 0;
                x_bottomright = 0;
                y_bottomright = 0;
            }
        }

        public struct PageInfo
        {
            public uint tgawidth;                // normally 256
            public uint tgaheight;               // normally 256
            public uint tgacolor;                // normally 16
            public uint tgaxxxxx;                // normally 0

            public PageInfo()
            {
                tgawidth = 256;
                tgaheight = 256;
                tgacolor = 16;
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
                    int i;

                    for (i = 0; i < FontEditor.MAX_NUM_CHARS; i++)
                    {
                        if (Font.charinfosize == CHARTABLESIZE_DEFAULT)
                        {
                            if (Font.chartable[i] != 0xD || (Font.chartable[i] == 0xD && i == 46))
                            {
                                Font.char_info[i].charsettings = new sbyte[28];

                                for (int j = 0; j < 28; j++)
                                {
                                    Font.char_info[i].charsettings[j] = fntReader.ReadSByte();
                                }

                                Font.char_info[i].x_topleft = fntReader.ReadSingle();
                                Font.char_info[i].y_topleft = fntReader.ReadSingle();
                                Font.char_info[i].x_bottomright = fntReader.ReadSingle();
                                Font.char_info[i].y_bottomright = fntReader.ReadSingle();

                                Font.char_info[i].itemNum = counter;
                                counter++;
                            }
                        }
                        else
                        {
                            Font.char_info[i].charsettings = new sbyte[28];

                            for (int j = 0; j < 28; j++)
                            {
                                Font.char_info[i].charsettings[j] = fntReader.ReadSByte();
                            }

                            Font.char_info[i].x_topleft = fntReader.ReadSingle();
                            Font.char_info[i].y_topleft = fntReader.ReadSingle();
                            Font.char_info[i].x_bottomright = fntReader.ReadSingle();
                            Font.char_info[i].y_bottomright = fntReader.ReadSingle();

                            Font.char_info[i].itemNum = counter;
                            counter++;
                        }
                    }

                    // finally read fileinfo part for each numpage
                    Font.pageinfo = new PageInfo[Font.num_pages];

                    for (i = 0; i < Font.num_pages; i++)
                    {
                        Font.pageinfo[i].tgawidth = fntReader.ReadUInt32();
                        Font.pageinfo[i].tgaheight = fntReader.ReadUInt32();
                        Font.pageinfo[i].tgacolor = fntReader.ReadUInt32();
                        Font.pageinfo[i].tgaxxxxx = fntReader.ReadUInt32();
                    }

                    // Get the font filename in .fnt file. We will read it as bytes until byte = 0 found.
                    counter = GetFileNameLength(fntReader);
                    Font.filename = new byte[counter];
                    Font.filename = fntReader.ReadBytes(counter);

                    // Get the last bytes of the file in a byte array.
                    if (fntReader.BaseStream.Length > fntReader.BaseStream.Position)
                    {
                        Font.buffer = new byte[fntReader.BaseStream.Length - fntReader.BaseStream.Position];
                        Font.buffer = fntReader.ReadBytes((int)fntReader.BaseStream.Length - (int)fntReader.BaseStream.Position);
                    }
                }
            }
        }

        public int CalculateFileSize()
        {
            int size = 0, i = 0;

            // Size of the font file:   36 header +
            //                          256 charset tale +
            //                          190 chars * 44 bytes +     >> In this case we will check the chars used
            //                          16 bytes fileinfo * num_pages +           in case we want to do something more
            //                          size of last page filename
            //                          buffer

            size = 36 + 256;

            // Add Char Table
            for (i = 0; i < FontEditor.MAX_NUM_CHARS; i++)
            {
                if (Font.char_info[i].charsettings != null) size += 44;
            }

            // Add fileinfo page size
            size += 16 * (int)Font.num_pages;

            // Add filename length
            size += Font.filename.Length;

            // Add buffer length if needed
            if (Font.buffer.Length > 1) size += Font.buffer.Length;

            return size;
        }


        // Let's save the .fnt file
        public void SaveFont(string filename)
        {
            int filesize = 0;
            int i = 0;

            //string filenameonly = Path.GetFileNameWithoutExtension(Font.filename);

            filesize = CalculateFileSize();

            byte[] fntArray = new byte[filesize];
            //byte[] strFontName = Encoding.ASCII.GetBytes(filenameonly);

            // First, let's write the header
            // Let's prepare the Memory Writer
            using (var fntSaveMemory = new MemoryStream(fntArray))
            {
                using (var fntSaveWriter = new BinaryWriter(fntSaveMemory))
                {

                    // - Put Font HDR in memory Byte Array
                    fntSaveWriter.Write(Font.num_pages);
                    fntSaveWriter.Write(Font.charinfosize);

                    fntSaveWriter.Write(Font.version);
                    fntSaveWriter.Write(Font.line_spacing);
                    fntSaveWriter.Write(Font.shift_upper);
                    fntSaveWriter.Write(Font.shift_lower);
                    fntSaveWriter.Write(Font.shift_left);
                    fntSaveWriter.Write(Font.shift_right);
                    fntSaveWriter.Write(Font.offset_charsinfo);

                    // - Write Char Table
                    fntSaveWriter.Write(Font.chartable);

                    // - Write Character Info Values
                    for (i = 0; i < FontEditor.MAX_NUM_CHARS; i++)
                    {

                        if (Font.char_info[i].charsettings != null)
                        {
                            for (int j = 0; j < 28; j++)
                            {
                                fntSaveWriter.Write(Font.char_info[i].charsettings[j]);
                            }

                            fntSaveWriter.Write(Font.char_info[i].x_topleft);
                            fntSaveWriter.Write(Font.char_info[i].y_topleft);
                            fntSaveWriter.Write(Font.char_info[i].x_bottomright);
                            fntSaveWriter.Write(Font.char_info[i].y_bottomright);
                        }
                    }

                    // - Write File Info for each page
                    for (i = 0; i < Font.num_pages; i++)
                    {
                        fntSaveWriter.Write(Font.pageinfo[i].tgawidth);
                        fntSaveWriter.Write(Font.pageinfo[i].tgaheight);
                        fntSaveWriter.Write(Font.pageinfo[i].tgacolor);
                        fntSaveWriter.Write(Font.pageinfo[i].tgaxxxxx);
                    }

                    // - Lastly we write the filename
                    fntSaveWriter.Write(Font.filename);

                    // - In case we have any buffer, we will write it
                    if (Font.buffer.Length > 1)
                    {
                        fntSaveWriter.Write(Font.buffer);
                    }
                }
            }


            // - Write Field in memory to file.
            using (var fntSaveWriter = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
               fntSaveWriter.Write(fntArray);
            }
        }


    }
}
