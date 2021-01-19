using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Segmentation
{
    class GradientImage
    {
        int height;
        int width;
        Bitmap greyscaled;
        // get a gradient bitmap from a normal greyscaled bitmap 
        /// <summary>
        ///  used to get a TotalEdgeImage
        /// </summary>
        /// <param name="Grey"></param>
        /// <returns></returns>
      public Bitmap GetTotalEdgeImage(Bitmap Grey)
        {
            greyscaled  = Grey;
            height = Grey .Height;
            width = Grey.Width;
            // do some greyscaling
            // go through each pixel and get the average rgb
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x <width; x++)
                {
                  



                    double grad = TotalEdgePixel(x,y) ;
                    int truncedgrad = (int)(Math.Truncate(grad));
                    // set pixels to the average
                    //// set a hard cap
                    if (truncedgrad > 255)
                    {
                        truncedgrad = 255;
                    }
                    if (truncedgrad < 0)
                    {
                        truncedgrad = 0;
                    }
                    Color current = greyscaled.GetPixel(x, y);
                   
                    greyscaled .SetPixel(x, y, Color.FromArgb(truncedgrad, truncedgrad, truncedgrad));
                }
            }

            return greyscaled ;

        }




       /// <summary>
       /// Sobel style total edge pixel
       /// </summary>
       /// <param name="x"></param>
       /// <param name="y"></param>
       /// <returns></returns>
        public double TotalEdgePixel(int x, int y)
        {
            double ygradient = 0;//yGradient(x, y);
            double xgradient = XGradient(x, y);
            double x2 = (xgradient * xgradient);
            double y2 = (ygradient * ygradient);
            double tot = x2 + y2;
            return Math.Sqrt( tot);
        }

        /// <summary>
        /// sobel style gradient for X getting 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double XGradient(int x, int y)
        {
            //List<double> values = new List<double>();
            //for (int y1 = y - 1; y1 <= y + 1; y1++)
            //{
            //    for (int x1 = x - 1; x1 <= x + 1; x1++)
            //    {
            //        values.Add(getValueAt(x, y));
            //    }
            //}
            ////
            ////
            ////
            //values[0] = values[0] * 1;
            //values[1] = values[1] * 0;
            //values[2] = values[2] * -1;
            //values[3] = values[3] * +2;
            //values[4] = values[4] * 0;
            //values[5] = values[5] * -2;
            //values[6] = values[6] * 1;
            //values[7] = values[7] * 0;
            //values[8] = values[8] * -1;

            //double total = 0;
            double total = 0;
            //for(int i =0; i<8;i++)
            //{
            //    total += values[i];
            //}
            double Left = getValueAt(x-1, y);
            double Right = getValueAt(x+1, y);
            total = Left - Right;
            return total;
        }

        /// <summary>
        /// sobel style gradient getting 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double yGradient(int x,int y)
        {
            //List<double> values = new List<double>();
            // for(int y1 = y-1; y1<=y+1;y1++)
            //{
            //     for(int x1 = x-1;x1<=x+1;x1++)
            //    {
            //        values.Add(getValueAt(x, y));
            //    }
            //}
            // //

            ////values[0] = values[0] * -1;
            ////values[1] = values[1] * 0;
            ////values[1] = values[1] * -1;
            ////values[2] = values[2] * -2;
            ////values[3] = values[3] * 0;
            ////values[4] = values[4] * 2;
            ////values[5] = values[5] * -1;
            ////values[6] = values[6] * 0;
            ////values[7] = values[7] * 1;
            //values[0] = values[0] * 1;
            //values[1] = values[1] * 2;
            //values[1] = values[1] * 1 ;
            //values[2] = values[2] * 0;
            //values[3] = values[3] * 0;
            //values[4] = values[4] * 0;
            //values[5] = values[5] * -1;
            //values[6] = values[6] * -2;
            //values[7] = values[7] * -1;

            double total=0;
            //for(int i =0; i<8;i++)
            //{
            //    total += values[i];
            //}
            double  top = getValueAt(x, y - 1);
            double bottom = getValueAt(x, y + 1);
            total = top - bottom;
            return total;
        }
         
        public double getValueAt(int x, int y)
        {
            double val = 0;
            if(InXBounds(x)&& InYBounds(y))
            {
               val= greyscaled.GetPixel(x, y).R ;
            }
            return val;
        }

        //
        /// <summary>
        /// gets if an x value is in the bounds 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool InXBounds(int x)
        {
            bool answer = false;
            if ((x>=0)&& (x<width))
            {
                answer = true;
            }
            return answer;
        }
        /// <summary>
        /// checks if Y value is in bounds 
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool InYBounds(int y)
        {
            bool answer = false;
            if ((y >=0) && (y < height))
            {
                answer = true;
            }
            return answer;
        }

        // get angle of a pixel 
        public double GetAngleat(int x, int y)
        {
            return Math.Atan(yGradient(x, y) / XGradient(x, y));
        }

    }
}
