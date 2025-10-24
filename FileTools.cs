using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VtMBFontEditor
{

    public partial class FileTools
    {
        private const string CFG_FILE_NAME = "VtMBFontEditor.cfg";

        public string strFontPath, strGlobalPath;
        public int iCodepage;

        public Hashtable lstCFGKeys = new Hashtable();

        public void PrepareCFGKeys()
        {
            lstCFGKeys.Add("FONT_FOLDER", "");
            lstCFGKeys.Add("CODEPAGE", "");
        }

        public void SetDefaultValues()
        {
            strFontPath = "";
            iCodepage = 1252;
        }

        public void ReadCFGFile()
        {
            string strCFGFileName = strGlobalPath + CFG_FILE_NAME;
            string[] lines;

            PrepareCFGKeys();

            // If VtMBTranslator.cfg exists, let's read the keysç
            if (File.Exists(strCFGFileName))
            {
                lines = File.ReadAllLines(strCFGFileName);

                foreach (string strLine in lines)
                {
                    if (strLine.Length > 0)
                    {
                        string[] strLineSplit = strLine.Split("=");

                        if (strLineSplit.Length > 1)
                        {
                            lstCFGKeys[strLineSplit[0]] = strLineSplit[1];
                        }
                    }
                }

                strFontPath = lstCFGKeys["FONT_FOLDER"].ToString();

                if (!int.TryParse(lstCFGKeys["CODEPAGE"].ToString(), out iCodepage))
                {
                    iCodepage = 1252;
                }

            }
            else
            {
                SetDefaultValues();
                WriteCFGFile();
            }
        }

        public void WriteCFGFile()
        {
            string strCFGFileName = strGlobalPath + "\\" + CFG_FILE_NAME;
            StringBuilder sbCFGLines = new StringBuilder();

            lstCFGKeys["FONT_FOLDER"] = strFontPath;
            lstCFGKeys["CODEPAGE"] = iCodepage.ToString();

            // Write VtMBTranslator.cfg
            foreach (DictionaryEntry strCFGKey in lstCFGKeys)
            {
                sbCFGLines.AppendLine(strCFGKey.Key + "=" + strCFGKey.Value);
            }

            File.WriteAllText(strCFGFileName, sbCFGLines.ToString());
        }
    }

}
