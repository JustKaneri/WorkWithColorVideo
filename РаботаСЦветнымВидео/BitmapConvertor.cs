using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РаботаСЦветнымВидео
{
    /// <summary>
    /// Класс для преобразования Изображения в Текст
    /// </summary>
    class BitmapConvertor
    {
        private readonly Bitmap _bmp;
        private readonly char[] table = { '.', ',', ':', '+', '*', '?', '%', 'S', '#', '@' };

        public BitmapConvertor(Bitmap bmp)
        {
            _bmp = bmp;
        }

        public char[][] Convertor()
        {
            var resul = new char[_bmp.Height][];

            for (int y = 0; y < _bmp.Height; y++)
            {
                resul[y] = new char[_bmp.Width];
                for (int x = 0; x < _bmp.Width; x++)
                {
                    int mapIndex = (int)Map(_bmp.GetPixel(x, y).R, 0, 255, 0, table.Length - 1);
                    resul[y][x] = table[mapIndex];
                }
            }

            return resul;
        }

        private float Map(float valueTopMap,float start1,float stop1,float start2, float stop2)
        {
            return (valueTopMap - start1) / (stop1 - start1) * (stop2 - start2) + start2;
        }
    }
}
