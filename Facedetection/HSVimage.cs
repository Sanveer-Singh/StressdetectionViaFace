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
        public double[,] hue;
        public double[,] saturation;
        public double[,] lightness;// used for convenience
        public int width;
        public int height; 

        public double GetHueAtxy(int x, int y)
        {
            double copy1 = hue[x, y];
            return copy1;
        }
        public double GetSaturationAtxy(int x, int y)
        {
            double copy1 = saturation[x, y];
            return copy1;
        }
        public double GetLightnessAtxy(int x, int y)
        {
            double copy1 = lightness[x, y];
            return copy1;
        }

        public HSVimage(Bitmap bmp)
        {
            // get the width and height 
            width = bmp.Width;
            height = bmp.Height;

            //  set up the arrays 
            hue = new double[width, height];
            lightness  = new double[width, height];
            saturation  = new double[width, height];
            int x,y ;
            // loop verticaly 
            for(y= 0; y<= height; y++)
            {
                // loop horizontaly 
                for (x = 0; x <= width; x++)
                {
                    //  fil hue array
                    hue[x, y] = (Color.FromArgb(bmp.GetPixel(x, y).R, bmp.GetPixel(x, y).G, bmp.GetPixel(x, y).B)).GetHue();

                    // fill lightness array 
                    lightness [x,y] = (Color.FromArgb(bmp.GetPixel(x, y).R, bmp.GetPixel(x, y).G, bmp.GetPixel(x, y).B)).GetBrightness();
                    // fill saturation array
                    saturation [x,y] = (Color.FromArgb(bmp.GetPixel(x, y).R, bmp.GetPixel(x, y).G, bmp.GetPixel(x, y).B)).GetBrightness();


                }
            }
           

        }

    }
}
