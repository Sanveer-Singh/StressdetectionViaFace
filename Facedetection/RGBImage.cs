using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Facedetection
{
    class RGBImage
    {
        // what makes up a YCBCR image ? 
        private RGBPixel[,] myArray;
        private int width;
        private int height;

        // constructor 
        public RGBImage(Bitmap bmp)
        {
            // get width and height 
            width = bmp.Width;
            height = bmp.Height;
            // set up arrays 
            myArray = new RGBPixel[width, height];
            // now lets fill the array 
            int xx, yy;
            // loop horizontally
            for (yy = 0; yy < height; yy++)
            {
                // loop verticaly now 
                for (xx = 0; xx < width; xx++)
                {
                    // get the color 
                    Color mycol = bmp.GetPixel(xx, yy);
                    // fill the array 
                    myArray[xx, yy] = bmpToRGB(mycol);
                }
            }

        }

        // convert pixel at a time 
        public static RGBPixel bmpToRGB(Color pixel)
        {
           
            return new RGBPixel (pixel.R ,pixel.G ,pixel.B ,false);
        }

        // getters
        public int GetWidth()
        {
            return width;
        }
        public  int GetHeight()
        {
            return height;
        }
        public RGBPixel GetRGBPixel(int x, int y)
        {
            return myArray[x, y];
        }

        public double RAtxy(int x, int y)
        {
            double R;

            R = myArray[x, y].GetR();
            return R;

        }
        public double GAtxy(int x, int y)
        {
            double G;

            G = myArray[x, y].GetG();
            return G;

        }
        public double BAtxy(int x, int y)
        {
            double B;

            B = myArray[x, y].GetB();
            return B;

        }

        public bool DetectedAtxy(int x, int y)
        {
            bool answer = false;

            answer = myArray[x, y].GetDetected();
            return answer;
        }

        // setters 
        public void SetDetected(int x, int y,bool Detected)
        {
            myArray[x, y].SetDetected( Detected);
        }
        public void SetR(int x, int y, double R)
        {
            myArray[x, y].SetR(R);
        }

        public void SetG(int x, int y, double G)
        {
            myArray[x, y].SetG(G);
        }
        public void SetB(int x, int y, double B)
        {
            myArray[x, y].SetB(B);
        }
        public Bitmap ToBmp()
        {
            Bitmap bmp = new Bitmap(width ,height);
            using (Graphics g = Graphics.FromImage(bmp)) g.Clear(Color.White);
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color nc = new Color();
                    nc = Color.FromArgb(Convert.ToInt32(myArray[x, y].GetR()), Convert.ToInt32(myArray[x, y].GetG()), Convert.ToInt32(myArray[x, y].GetB()));
                    bmp.SetPixel(x, y, nc);
                }

            return (Bitmap)bmp;
        }
        // so we can visually show the detected areas 
        public Bitmap GetDetectedBmp()
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp)) g.Clear(Color.White);
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color nc = new Color();
                    Color ndC = new Color();
 
                    if(myArray[x,y].GetDetected()== true)
                    {
                        // color of detected areas 
                        nc = Color.FromArgb(Convert.ToInt32(myArray[x, y].GetR()), Convert.ToInt32(myArray[x, y].GetG()), Convert.ToInt32(myArray[x, y].GetB()));

                    }
                    else
                    {
                        // color of non detected areas 
                        ndC = Color.FromArgb(0, 0, 0);
                    }

                    bmp.SetPixel(x, y, nc);
                }

            return (Bitmap)bmp;
        }

    }
}
