using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Facedetection
{


    class HSVimage
    {
        // these are the things that make up an HSV image
        // arrays are in x,y format
        public HSVPixel[,] Pixels;
        public int width;
        public int height; 

        public double GetHueAtxy(int x, int y)
        {
            double copy1 = Pixels[x, y].GetH();
            return copy1;
        }
        public double GetSaturationAtxy(int x, int y)
        {
            double copy1 = Pixels[x, y].GetS();
            return copy1;
        }
        public double GetLightnessAtxy(int x, int y)
        {
            double copy1 = Pixels[x, y].GetL();
            return copy1;
        }

        public HSVimage(Bitmap bmp)
        {
            // get the width and height 
            width = bmp.Width;
            height = bmp.Height;

            //  set up the array
            Pixels = new HSVPixel[width, height];
           
            int x,y ;
            // loop verticaly 
            for(y= 0; y< height; y++)
            {
                // loop horizontaly 
                for (x = 0; x < width; x++)
                {
                    Color cl1,cl2 = new Color();
                    cl2 = bmp.GetPixel(x, y);
                    cl1 = Color.FromArgb(cl2.R,cl2.G,cl2.B);
                    //  fil hue array
                    Pixels[x, y] = RGBToHSVPixel(cl1);
                }
            }
        }
        // for use if I need it again
        public HSVPixel RGBToHSVPixel(Color thiscolor)
        {
            HSVPixel pixel = new HSVPixel(thiscolor.GetHue(), thiscolor.GetSaturation(), thiscolor.GetBrightness());
            return pixel;
        }
        public int GetWidth()
        {
            return width;
        }
        public int GetHeight()
        {
            return height;
        }

    }
}
