using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Preprocessing
{
    class MeanFilter
    {

        Bitmap GreyScaled;

        /// <summary>
        /// Takes a greyscaled image and smoothes out the noise
        /// </summary>
        /// <param name="myGreyScaled"></param>
        public  MeanFilter(Bitmap myGreyScaled)
        {
            GreyScaled = myGreyScaled;
        }


        /// <summary>
        /// why so mean huh?
        /// </summary>
        /// <param name="myBmp"></param>
        /// <returns></returns>
        public  Bitmap MeanFilterThis()
        {
            // make up an answer 
            Bitmap Filtered = new Bitmap(GreyScaled.Width, GreyScaled.Height);
            // loop through one window and get the average 
            // goes through them all applies rules then the pixels that pass are marked as detected 
            int x, y;
            double  Average;
            // loop through the rows 
            for (y = 0; y < GreyScaled.Height ; y++)
            {
                // loop through the cols 
                for (x = 0; x < GreyScaled .Width ; x++)
                {
                    Average =IntensityAverage(x,y);
                    SetIntensitiesAround(x, y, Average);
                }

            }
            // return the answer 
            return GreyScaled ;
        }

        private  double IntensityAverage(int X, int Y)
        {
            // MAKE AN Answer 
            double total = 0;
            // window around that pixel
            for (int y1 = Y - 1; y1 <= Y + 1; y1++)
            {
                for (int x1 = X - 1; x1 <= X + 1; x1++)
                {
                    // explicit bounds checks 
                    if ((x1 >= 0) && (y1 >= 0) && (x1 < GreyScaled.Width ) && (y1 < GreyScaled.Height ))
                    {
                        // now add it to the total 
                        total += GreyScaled.GetPixel(x1, y1).R;
                    }

                }
            }
            
            return total / 9;
        }

        private  void SetIntensitiesAround(int X, int Y, double Average)
        {
           
            // loop through one window and set the average 
            // window around that pixel
            int ave = (int)Math.Truncate(Average);
            for (int y1 = Y - 1; y1 <= Y + 1; y1++)
            {
                for (int x1 = X - 1; x1 <= X + 1; x1++)
                {
                    // explicit bounds checks 
                    if ((x1 >= 0) && (y1 >= 0) && (x1 < GreyScaled.Width) && (y1 < GreyScaled.Height))
                    {

                        Color nc = Color.FromArgb(ave ,ave ,ave );
                        GreyScaled .SetPixel(x1, y1,nc);
                    }

                }
            }

        }
    }
}
