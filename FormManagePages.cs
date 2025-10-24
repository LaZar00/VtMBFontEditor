using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VtMBFontEditor
{
    public partial class FormManagePages : Form
    {

        FontEditor FE;
        int iNewPage = -1;

        public FormManagePages(FontEditor tmpFE)
        {
            int i;

            InitializeComponent();

            FE = tmpFE;

            // Let's fill some things
            LbPages.Items.Clear();

            for (i = 0; i < FE.loadedFnt.Font.num_pages; i++)
            {
                LbPages.Items.Add("Page " + i.ToString());
            }

            LbPages.SelectedIndex = 0;

        }


        private void lbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbPages.SelectedIndex < iNewPage || iNewPage == -1)
            {
                TxtTGAWidth.Text = FE.loadedFnt.Font.pageinfo[LbPages.SelectedIndex].tgawidth.ToString();
                TxtTGAHeight.Text = FE.loadedFnt.Font.pageinfo[LbPages.SelectedIndex].tgaheight.ToString();
                TxtOffsetName.Text = FE.loadedFnt.Font.pageinfo[LbPages.SelectedIndex].tgaoffsetname.ToString();
            }
            else
            {
                TxtTGAWidth.Text = "256";
                TxtTGAHeight.Text = "256";
                TxtOffsetName.Text = FE.loadedFnt.CalculateOffsetNameAtIndex(iNewPage).ToString();
            }

            BtnDeletePage.Enabled = false;

            if (LbPages.Items.Count > 1)
            {
                if (LbPages.SelectedIndex == LbPages.Items.Count - 1)
                {
                    BtnDeletePage.Enabled = true;
                }
            }

        }

        private void btnAddPage_Click(object sender, EventArgs e)
        {
            int i;

            // Add info into structure
            FE.loadedFnt.Font.num_pages++;

            // We must replicate it with all the pages, less the last one, that we have as new
            FontFile.PageInfo[] tmpPageInfo = new FontFile.PageInfo[FE.loadedFnt.Font.num_pages];

            for (i = 0; i < FE.loadedFnt.Font.num_pages; i++)
            {
                if (i < FE.loadedFnt.Font.num_pages - 1)
                {
                    tmpPageInfo[i] = FE.loadedFnt.Font.pageinfo[i];
                }
                else
                {
                    tmpPageInfo[i].tgawidth = uint.Parse(TxtTGAWidth.Text);
                    tmpPageInfo[i].tgaheight = uint.Parse(TxtTGAHeight.Text);
                    tmpPageInfo[i].tgaoffsetname = uint.Parse(TxtOffsetName.Text);
                    tmpPageInfo[i].tgaxxxxx = 0;
                }
            }

            // Update new values
            FE.loadedFnt.Font.pageinfo = tmpPageInfo;

            // We recalculate previous offsets
            for (i = 0; i < FE.loadedFnt.Font.num_pages; i++)
            {
                FE.loadedFnt.Font.pageinfo[i].tgaoffsetname =
                                (uint)FE.loadedFnt.CalculateOffsetNameAtIndex(i);
            }

            FE.PopulateFontInfoByTop();

            // Update other things
            iNewPage = LbPages.Items.Count;

            LbPages.Items.Add("Page " + LbPages.Items.Count.ToString());
            LbPages.SelectedIndex = iNewPage;

            BtnDeletePage.Enabled = true;

            iNewPage = -1;
        }

        private void btnDeletePage_Click(object sender, EventArgs e)
        {
            int i;

            // We will remove those chars assigned to this page
            if (MessageBox.Show("All the chars assigned to this page will be deleted.\n" +
                                "Are you sure you want to continue?",
                                "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Delete chars
                for (i = 0; i < FE.loadedFnt.Font.chartable.Length; i++)
                {
                    if (FE.loadedFnt.Font.char_info[i].charsettings != null)
                    {
                        if (FE.loadedFnt.Font.char_info[i].charsettings[24] == LbPages.Items.Count - 1)
                        {
                            FE.TxtMaxChars.Text = FE.loadedFnt.DeleteChar(i).ToString();
                        }
                    }
                }

                // Delete TGA image
                FE.loadedFnt.Font.num_pages--;

                // We recalculate previous offsets
                for (i = 0; i < FE.loadedFnt.Font.num_pages; i++)
                {
                    FE.loadedFnt.Font.pageinfo[i].tgaoffsetname =
                                    (uint)FE.loadedFnt.CalculateOffsetNameAtIndex(i);
                }

                // Update other things
                LbPages.SelectedIndex = 0;
                LbPages.Items.RemoveAt(LbPages.Items.Count - 1);

                BtnDeletePage.Enabled = false;

                iNewPage = -1;

                // Refresh Char list
                FE.PopulateFontInfoByTop();
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            if (iNewPage > -1)
            {
                if (MessageBox.Show("You have added a page. Do you want to exit without accepting the new page?",
                                    "Info",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void TxtTGAWidth_Validating(object sender, CancelEventArgs e)
        {
            int iValue;

            if (int.TryParse(TxtTGAWidth.Text, out iValue))
            {
                if (iValue % 128 != 0)
                {
                    MessageBox.Show("The value must be a multiple of 128 (normally 256).", "Info", MessageBoxButtons.OK);

                    TxtTGAWidth.Text = "256";

                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("The value must be an integer.", "Info", MessageBoxButtons.OK);

                TxtTGAWidth.Text = "256";

                e.Cancel = true;
            }
        }

        private void TxtTGAHeight_Validating(object sender, CancelEventArgs e)
        {
            int iValue;

            if (int.TryParse(TxtTGAHeight.Text, out iValue))
            {
                if (iValue % 128 != 0)
                {
                    MessageBox.Show("The value must be a multiple of 128 (normally 256).", "Info", MessageBoxButtons.OK);

                    TxtTGAHeight.Text = "256";

                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("The value must be an integer.", "Info", MessageBoxButtons.OK);

                TxtTGAHeight.Text = "256";

                e.Cancel = true;
            }

        }
    }
}
