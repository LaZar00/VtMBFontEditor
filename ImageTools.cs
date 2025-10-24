using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtMBFontEditor
{
    public class ImageTools
    {
        public static void DrawRoundedRectangle(Graphics g, Rectangle r, int radius, Pen p)
        {
            GraphicsPath gPath = RoundedRectangle(r, radius);

            using (gPath)
                g.DrawPath(p, gPath);
        }

        public static void FillRoundedRectangle(Graphics g, Rectangle r, int radius, Brush br)
        {
            GraphicsPath gPath = RoundedRectangle(r, radius);

            using (gPath)
                g.FillPath(br, gPath);
        }

        public static GraphicsPath RoundedRectangle(Rectangle r, int radius)
        {
            GraphicsPath gPath = new GraphicsPath();
            int d = radius * 2;

            gPath.AddLine(r.Left + d, r.Top, r.Right - d, r.Top);
            gPath.AddArc(Rectangle.FromLTRB(r.Right - d, r.Top, r.Right, r.Top + d), -90, 90);
            gPath.AddLine(r.Right, r.Top + d, r.Right, r.Bottom - d);
            gPath.AddArc(Rectangle.FromLTRB(r.Right - d, r.Bottom - d, r.Right, r.Bottom), 0, 90);
            gPath.AddLine(r.Right - d, r.Bottom, r.Left + d, r.Bottom);
            gPath.AddArc(Rectangle.FromLTRB(r.Left, r.Bottom - d, r.Left + d, r.Bottom), 90, 90);
            gPath.AddLine(r.Left, r.Bottom - d, r.Left, r.Top + d);
            gPath.AddArc(Rectangle.FromLTRB(r.Left, r.Top, r.Left + d, r.Top + d), 180, 90);
            gPath.CloseFigure();

            return gPath;
        }

        public static Bitmap ChangeOpacity(Image imgInput, float sOpacityValue)
        {
            var bmp = new Bitmap(imgInput.Width, imgInput.Height);
            var cmColorMatrix = new ColorMatrix();
            var imgAttribute = new ImageAttributes();

            cmColorMatrix.Matrix33 = sOpacityValue;

            imgAttribute.SetColorMatrix(cmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(imgInput,
                            new Rectangle(0, 0, bmp.Width, bmp.Height),
                            0, 0, imgInput.Width, imgInput.Height,
                            GraphicsUnit.Pixel, imgAttribute);
            }

            return bmp;
        }
    }
}
