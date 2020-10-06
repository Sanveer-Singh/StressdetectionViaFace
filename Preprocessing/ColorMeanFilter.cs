using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Preprocessing
{
    class ColorMeanFilter
    {
        Bitmap GreyScaled;

        /// <summary>
        /// Takes a greyscaled image and smoothes out the noise
        /// </summary>
        /// <param name="myGreyScaled"></param>
        public ColorMeanFilter(Bitmap myGreyScaled)
        {
            GreyScaled = myGreyScaled;
        }


        /// <summary>
        /// why so mean huh?
        /// </summary>
        /// <param name="myBmp"></param>
        /// <returns></returns>
        public Bitmap MeanFilterThis()
        {
            // make up an answer 
            Bitmap Filtered = new Bitmap(GreyScaled.Width, GreyScaled.Height);
            // loop through one window and get the average 
            // goes through them all applies rules then the pixels that pass are marked as detected 
            int x, y;
            Color Average;
            // loop through the rows 
            for (y = 0; y < GreyScaled.Height; y++)
            {
                // loop through the cols 
                for (x = 0; x < GreyScaled.Width; x++)
                {
                    Average  = IntensityAverage(x, y);
                    SetIntensitiesAround(x, y, Average);
                }

            }
            // return the answer 
            return GreyScaled;
        }

        private Color IntensityAverage (int x, int y)
        {
            int r = (int)Math.Truncate(RedIntensityAverage(x, y));
            int g = (int)Math.Truncate(GreenIntensityAverage(x, y));
            int b = (int)Math.Truncate(BlueIntensityAverage(x, y));
            Color nc = Color.FromArgb(r, g, b);
            return nc;
        }

        private double RedIntensityAverage(int X, int Y)
        {
            // MAKE AN Answer 
            double total = 0;
            // window around that pixel
            for (int y1 = Y - 1; y1 <= Y + 1; y1++)
            {
                for (int x1 = X - 1; x1 <= X + 1; x1++)
                {
                    // explicit bounds checks 
                    if ((x1 >= 0) && (y1 >= 0) && (x1 < GreyScaled.Width) && (y1 < GreyScaled.Height))
                    {
                        // now add it to the total 
                        total += GreyScaled.GetPixel(x1, y1).R;
                    }

                }
            }

            return total / 9;
        }
        private double GreenIntensityAverage(int X, int Y)
        {
            // MAKE AN Answer 
            double total = 0;
            // window around that pixel
            for (int y1 = Y - 1; y1 <= Y + 1; y1++)
            {
                for (int x1 = X - 1; x1 <= X + 1; x1++)
                {
                    // explicit bounds checks 
                    if ((x1 >= 0) && (y1 >= 0) && (x1 < GreyScaled.Width) && (y1 < GreyScaled.Height))
                    {
                        // now add it to the total 
                        total += GreyScaled.GetPixel(x1, y1).G;
                    }

                }
            }

            return total / 9;
        }
        private double BlueIntensityAverage(int X, int Y)
        {
            // MAKE AN Answer 
            double total = 0;
            // window around that pixel
            for (int y1 = Y - 1; y1 <= Y + 1; y1++)
            {
                for (int x1 = X - 1; x1 <= X + 1; x1++)
                {
                    // explicit bounds checks 
                    if ((x1 >= 0) && (y1 >= 0) && (x1 < GreyScaled.Width) && (y1 < GreyScaled.Height))
                    {
                        // now add it to the total 
                        total += GreyScaled.GetPixel(x1, y1).B;
                    }

                }
            }

            return total / 9;
        }

        private void SetIntensitiesAround(int X, int Y, Color Average)
        {

            // loop through one window and set the average 
            // window around that pixel
         
            for (int y1 = Y - 1; y1 <= Y + 1; y1++)
            {
                for (int x1 = X - 1; x1 <= X + 1; x1++)
                {
                    // explicit bounds checks 
                    if ((x1 >= 0) && (y1 >= 0) && (x1 < GreyScaled.Width) && (y1 < GreyScaled.Height))
                    {

                       
                        GreyScaled.SetPixel(x1, y1, Average);
                    }

                }
            }

        }
    }
}
