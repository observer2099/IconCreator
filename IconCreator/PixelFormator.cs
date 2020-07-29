using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace System
{
    public class PixelFormator
    {
        public static Bitmap PixelIcon(Bitmap bmp, int pSize, int size)
        {
            var imgImg = new Bitmap(bmp);
            Color GetPrimaryColor(int x, int y)
            {
                var cDic = new Dictionary<Color, int>();
                for (int i = x; i < x + pSize; i++)
                {
                    for (int j = y; j < y + pSize; j++)
                    {
                        Color c = imgImg.GetPixel(i, j);
                        if (cDic.ContainsKey(c))
                            cDic[c]++;
                        else
                            cDic.Add(c, 1);
                    }
                }
                return cDic.OrderByDescending(X => X.Value).First().Key;
            }

            if (pSize != 1)
            {
                using (var g = Graphics.FromImage(imgImg))
                {
                    g.CompositingMode = CompositingMode.SourceCopy;
                    for (int x = 0; x < imgImg.Width; x += pSize)
                    {
                        for (int y = 0; y < imgImg.Height; y += pSize)
                            g.FillRectangle(new SolidBrush(GetPrimaryColor(x, y)), x, y, pSize, pSize);
                    }
                }
            }
            var img = new Bitmap(size, size);
            using (var g = Graphics.FromImage(img))
            {
                g.DrawImage(imgImg, new Point((size - imgImg.Width) / 2, (size - imgImg.Height) / 2));
            }
            return img;
        } 
    }
}