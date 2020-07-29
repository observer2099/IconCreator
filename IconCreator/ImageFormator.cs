using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace IconCreator
{
    public static class ImageFormator
    {
        public static Bitmap GetPictureImage(string file)
        {
            string ext = Path.GetExtension(file).ToLower();
            Bitmap img = null;
            switch (ext)
            {
                case ".jpg":
                case ".png":
                case ".bmp":
                    img = new Bitmap(file);
                    break;
                case ".svg":
                    img = SvgFormator.SvgToImage(file);
                    break;
                case ".webp":
                    img = WebpFormator.WebpToImage(file);
                    break;
            }
            return img;
        }


        public static Bitmap ThumbnailImage(Bitmap bmp, int w, int h)
        {
            var img = new Bitmap(w, h);
            int imgX = 0, imgY = 0;
            int imgW = w, imgH = h;
            if (bmp.Width * h > bmp.Height * w)
            {
                imgH = w * bmp.Height / bmp.Width;
                imgY = (h - imgH) / 2;
            }
            else
            {
                imgW = h * bmp.Width / bmp.Height;
                imgX = (w - imgW) / 2;
            }
            using (var g = Graphics.FromImage(img))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;

                var attri = new ImageAttributes();
                ColorMap[] rTable = { new ColorMap() { OldColor = Color.FromArgb(255, 0, 255, 0), NewColor = Color.FromArgb(0, 0, 0, 0) } };
                attri.SetRemapTable(rTable, ColorAdjustType.Bitmap);
                float[][] cArray = { new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 0.5f, 0},
                    new float[] {0, 0, 0, 0, 1} };
                attri.SetColorMatrix(new ColorMatrix(cArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                g.DrawImage(bmp, new Rectangle(imgX, imgY, imgW, imgH), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attri);
            }
            return img;
        }

        public static Bitmap PreviewImage(Bitmap bmp, int w, int h, bool isScale)
        {
            var img = new Bitmap(w, h);
            int imgX = 0, imgY = 0;
            int imgW = w, imgH = h;
            if (isScale)
            {
                if (bmp.Width * h > bmp.Height * w)
                {
                    imgH = w * bmp.Height / bmp.Width;
                    imgY = (h - imgH) / 2;
                }
                else
                {
                    imgW = h * bmp.Width / bmp.Height;
                    imgX = (w - imgW) / 2;
                }
            }
            else
            {
                imgX = (w - bmp.Width) / 2;
                imgY = (h - bmp.Height) / 2;
                imgW = bmp.Width;
                imgH = bmp.Height;
            }
            using (var g = Graphics.FromImage(img))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(bmp, new Rectangle(imgX, imgY, imgW, imgH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
            }
            return img;
        }

        public static Bitmap GetIconImage(string file, int index)
        {
            Icon icon;
            try
            {
                if (Path.GetExtension(file).ToLower() == ".ico")
                    icon = new Icon(file);
                else
                    icon = IconFormator.LoadIcon(file)[index];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return IconFormator.SplitIcon(icon).Last().ToBitmap();
        }

        public static Bitmap BackgroundImage(int size, int count)
        {
            Bitmap img = new Bitmap(size, size);
            int t = size / count;
            using (var g = Graphics.FromImage(img))
            {
                for (int x = 0; x < count; x++)
                {
                    for (int y = 0; y < count; y++)
                    {
                        if ((x + y) % 2 == 0)
                            g.FillRectangle(Brushes.LightGray, x * t, y * t, t, t);
                    }
                }
            }
            return img;
        }
    }
}