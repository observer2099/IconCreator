using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Svg;

namespace IconCreator
{
    public static class SvgFormator
    {
        public static Bitmap SvgToImage(string file)
        {
            var svgDoc = SvgDocument.Open(file);
            svgDoc.Draw();
            return svgDoc.Draw();
        }
    }
}