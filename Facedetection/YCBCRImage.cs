using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Facedetection
{
    class YCBCRImage
    {// what makes up a YCBCR image ? 
        private YCbCrPixel[,] myArray;
        private int width;
        private int height;
        
        // constructor 
        public YCBCRImage(Bitmap bmp)
        {
            // get width and height 
            width = bmp.Width;
            height = bmp.Height;
            // set up arrays 
            myArray = new YCbCrPixel[width,height];
            // now lets fill the array 
            int xx, yy;
            // loop horizontally
            for(yy=0;yy<height;yy++)
            {
                // loop verticaly now 
                for (xx=0;xx<width;xx++)
                {
                    // get the color 
                    Color mycol = bmp.GetPixel(xx, yy);
                    // fill the array 
                    myArray[xx, yy] = RGBToYCbCr(mycol.R, mycol.B, mycol.G);
                }
            }

        }
        
        // convert pixel at a time 
        public  static YCbCrPixel RGBToYCbCr( double Red, double Blue, double Green)
        {
            double fr = Red  / 255;
            double fg = Green / 255;
            double fb = Blue / 255;
            //from wikipedia 
            double Y = (double)(0.2989 * fr + 0.5866 * fg + 0.1145 * fb);
            double Cb = (double)(-0.1687 * fr - 0.3313 * fg + 0.5000 * fb);
            double Cr = (double)(0.5000 * fr - 0.4184 * fg - 0.0816 * fb);

            return new YCbCrPixel(Y, Cb, Cr);
        }

        // getters
        public double CbAtxy(int x , int y )
        {
            double cb;

            cb = myArray[x, y].GetCb();
            return cb;

        }
        public double CrAtxy(int x, int y)
        {
            double cr;

            cr = myArray[x, y].GetCr();
            return cr;

        }
        public double YAtxy(int x, int y)
        {
            double Y;

            Y = myArray[x, y].GetY();
            return Y;

        }

    }
}
