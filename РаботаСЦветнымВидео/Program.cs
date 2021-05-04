using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace РаботаСЦветнымВидео
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            Thread th = new Thread(Video);
            th.Start();

            Console.ReadKey();
        }
        
        /// <summary>
        /// Вывод видео.
        /// </summary>
        private static void Video()
        {
            for (int z = 1; z <= 5160; z+=2)
            {
                string fileName = z.ToString();

                if (fileName.Length == 1)
                    fileName = "scene0000" + fileName;
                if (fileName.Length == 2)
                    fileName = "scene000" + fileName;
                if (fileName.Length == 3)
                    fileName = "scene00" + fileName;
                if (fileName.Length == 4)
                    fileName = "scene0" + fileName;

                var bmp = (Bitmap)Bitmap.FromFile("Video\\" + fileName+".png");

                bmp = BitmapCompress(bmp);
                bmp.ConvetToGray();

                BitmapConvertor con = new BitmapConvertor(bmp);
                var st = con.Convertor();


                Console.SetCursorPosition(0, 0);
                foreach (var item in st)
                {
                    Console.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// Resize Bitmap
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Bitmap BitmapCompress(Bitmap value)
        {
            var maxWidh = 240;
            var newHeigh = value.Height / 1.5 * maxWidh / value.Width;
            if (value.Width > maxWidh || value.Height > newHeigh)
                value = new Bitmap(value, new Size(maxWidh, (int)newHeigh));

            return value;
        }
    }
}
