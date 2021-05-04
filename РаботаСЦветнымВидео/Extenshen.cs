using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РаботаСЦветнымВидео
{
    public static class Extenshen
    {
        public static void ConvetToGray(this Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    var pixel = bmp.GetPixel(j,i);
                    var agv = (pixel.R + pixel.G + pixel.B) / 3;
                    bmp.SetPixel(j, i, Color.FromArgb(pixel.A, agv, agv, agv));
                }
            }
        }
    }
}
