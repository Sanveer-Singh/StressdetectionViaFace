using StressdetectionViaFace.utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StressdetectionViaFace.LBPvariants
{
    class ADLBP
    {
        // we need a bitmap 
        Bitmap ThisPic;
     
        // integer latice 
        List<int> Lattice;
        // an lbp image to show that the lbp works
        public Bitmap LBPImage;
        public Bitmap GetTheLbpImage()
        { LBPADLBPLattice();
            return LBPImage; }
            

        public ADLBP(Bitmap bmp)
        {
            ThisPic = bmp;
            Lattice = new List<int>();

        }

        // get amlbp


        // get AMLBP pic
        public List<int> LBPADLBPLattice()
        {
            // make up an answer 
            Bitmap Filtered = new Bitmap(ThisPic.Width+1, ThisPic.Height+1);
            // loop through one window and get the average 
            // goes through them all applies rules then the pixels that pass are marked as detected 
            int x, y, z;

            // loop through the rows 
            for (y = 0; y < ThisPic.Height; y++)
            {
                // loop through the cols 
                for (x = 0; x < ThisPic.Width; x++)
                {
                    z = AMLBPthis(x, y);
                    // store in the nice 2d array
              
                   
                  
                    Lattice.Add(z);
                    Color c = Color.FromArgb(z, z, z);
                    Filtered.SetPixel(x, y, c);
                }

            }
            // return the answer 
            LBPImage = Filtered;
            return Lattice;
        }
        public List<int> ADLBPLattice()
        {
            // make up an answer 
            Bitmap Filtered = new Bitmap(ThisPic.Width + 1, ThisPic.Height + 1);
            // loop through one window and get the average 
            // goes through them all applies rules then the pixels that pass are marked as detected 
            int x, y, z;

            // loop through the rows 
            for (y = 0; y < ThisPic.Height; y++)
            {
                // loop through the cols 
                for (x = 0; x < ThisPic.Width; x++)
                {
                    z = AMLBPthis(x, y);
                    // store in the nice 2d array
                    Lattice.Add(z);
                   
                    Color c = Color.FromArgb(z, z, z);
                    Filtered.SetPixel(x, y, c);
                }

            }
            // return the answer 
            LBPImage = Filtered;
            return Lattice;
        }
        // lets eliminate duplicates 
        public Bitmap GetPic()
        {
            return GetTheLbpImage();
        }
        public List<SanDictionaryItem> GetHistogram()
        {
            ADLBPLattice  ();

            List<SanDictionaryItem> items = new List<SanDictionaryItem>();
            List<SanDictionaryItem> Newitems = new List<SanDictionaryItem>();
            var query = Lattice.GroupBy(x => x)
              .Where(g => g.Count() >= 1)
              .Select(y => new SanDictionaryItem(y.Key, y.Count()))
              .ToList();
            for(int x = 0; x<256;x++)
            {
                var q2 = (from dic in query
                         where dic.key == x
                         select dic).FirstOrDefault() ;
                if (q2 is null )
                {
                    // none found
                    SanDictionaryItem newItem = new SanDictionaryItem(x, 0);
                    Newitems.Add(newItem);
                }
                else
                {
                    SanDictionaryItem newItem = new SanDictionaryItem(x, q2.count);
                    Newitems.Add(newItem);
                }
            }

            return Newitems ;
        }
        // get ADLBP for a point 
        private int AMLBPthis(int X, int Y)
        {
   
            int total = 0;
            // loop through radius distances
           
                //average = IntensityAverage(X, Y, x1);
                int nc = ThisPic.GetPixel(X, Y).R;
                total = GetPatternAround(X, Y,  nc);
             
        

            return total;
        }
        // get average of pixels the same distance away from the point
     
        private int GetPixelValue(int X, int Y)
        {
            int value = 0;
            if (((X >= 0) && (Y >= 0)) && ((X < ThisPic.Width) && (Y < ThisPic.Height)))
            {
                // in bounds
                value = ThisPic.GetPixel(X, Y).R;
            }


            return value;
        }
        private int GetPatternAround(int X, int Y, double Centre)
        {
            // create binary string
            // create binary string
            string Binary = "";
            // loop through one window and set the average 
            // window around that pixel
            double ave = Centre;
            if (GetPixelValue(X - 1, Y - 1) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }

            if (GetPixelValue(X - 1, Y) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }

            if (GetPixelValue(X - 1, Y + 1) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }
            if (GetPixelValue(X, Y + 1) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }
            if (GetPixelValue(X + 1, Y + 1) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }
            if (GetPixelValue(X + 1, Y) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }
            if (GetPixelValue(X + 1, Y - 1) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }
            if (GetPixelValue(X, Y - 1) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }
            // loop through one window and set the average 
            // window around that pixel
            //int ave = (int)Math.Truncate(Average);
            //for (int y1 = Y - (dist + 1); y1 <= Y + (dist + 1); y1++)
            //{
            //    for (int x1 = X - (dist + 1); x1 <= X + (dist + 1); x1++)
            //    {
            //        // explicit bounds checks 
            //        if ((x1 >= 0) && (y1 >= 0) && (x1 < ThisPic.Width) && (y1 < ThisPic.Height))
            //        {
            //            // check distance
            //            Point A = new Point(X, Y);
            //            Point B = new Point(x1, y1);
            //            int distanceAtoB = DistanceAtoB(A, B);
            //            if (dist == distanceAtoB)
            //            {
            //                // this is on the angle
            //                if (ThisPic.GetPixel(x1, y1).R < ave)
            //                {
            //                    // it needs to be a zero 
            //                    Binary += "0";
            //                }
            //                else
            //                {
            //                    // it need a  1 
            //                    Binary += "1";
            //                }
            //            }
            //        }

            //    }
            //}
            return GetDecimalFromBinary(Binary);

        }
        // binary string to decimal
        private int GetDecimalFromBinary(string input)
        {
            int output = Convert.ToInt32(input, 2);
            return output;
        }

        // we need to check distance to see if its in the distance (between two points )

        private int DistanceAtoB(Point A, Point B)
        {
            int answer = 0;
            // 1 is B
            // distance = root(((x1-x2)*(x1-x2))+((y1-y2)*(y1-y2)))
            answer = (int)Math.Truncate(Math.Sqrt(((B.X - A.X) * (B.X - A.X)) + ((B.Y - A.Y) * (B.Y - A.Y))));
            return answer;
        }
    }
}
