using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace bilvideo.Classes
{
    public class ResizeImage
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public static Image Resize(Image imgToResize, int h, int w)
        {
            Size size = new Size(w, h);
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float WHrate = ((float)imgToResize.Width / (float)imgToResize.Height); //Yüklenen fotonunun boyutlarının (genişliğin yüksekliğe) oranı...

            float newHeight = 0;
            float newWidth = 0;

            if (h != 0)
            {
                newHeight = h;
                newWidth = h * (int)WHrate;
            }
            else if (w != 0)
            {
                newHeight = (float)w / (float)WHrate;
                newWidth = w;
            }

            Bitmap b = new Bitmap((int)newWidth, (int)newHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, newWidth, newHeight);

            System.Drawing.Graphics graf = System.Drawing.Graphics.FromImage((Image)b);
            System.Drawing.SolidBrush firca = new SolidBrush(Color.FromArgb(140, 255, 255, 255));
            //System.Drawing.Font fnt = new Font("calibri", 50);//font tipi ve boyutu
            System.Drawing.Font fnt = new Font("Arial", 22);
            System.Drawing.SizeF size2 = new SizeF(0, 0);
            System.Drawing.PointF coor = new PointF(100, 100);
            System.Drawing.RectangleF kutu = new RectangleF(coor, size2);

            StringFormat sf = new StringFormat();
            //sf.FormatFlags = StringFormatFlags.;
            //sf.Alignment = StringAlignment.Center;
            //sf.LineAlignment = StringAlignment.Center;

            graf.DrawString("KazancLimani.com", fnt, firca, kutu, sf);

            g.Dispose();
            return (Image)b;
        }
    }
}