using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Preprocessing
{
    class GreyScalar
    {
        public static Bitmap GreyscaleThis(Bitmap img)
        {
            Bitmap bmp = img;

            // do some greyscaling
            // go through each pixel and get the average rgb
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;
                    int avg = (r + g + b) / 3;
                  
                    // set pixels to the average 
                    bmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
           
            return bmp;


        }
    }
}
