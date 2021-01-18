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
    class LBP
    {


        // we need a bitmap 
        Bitmap ThisPic;
   
        // integer latice 
        List<int> Lattice;
        // an lbp image to show that the lbp works
        public Bitmap LBPImage;
        public Bitmap GetTheLbpImage()
        {
            LBPPic();
            return LBPImage;
        }

        public LBP(Bitmap bmp)
        {
            ThisPic = bmp;
       
            Lattice = new List<int>();

        }

        // get amlbp
        public Bitmap GetPic()
        {
            return GetTheLbpImage();
        }

        // get LBP pic
        public List<int> LBPPic()
        {
            // make up an answer 
            Bitmap Filtered = new Bitmap(ThisPic.Width, ThisPic.Height);
            // loop through one window and get the average 
            // goes through them all applies rules then the pixels that pass are marked as detected 
            int x, y, z;

            // loop through the rows 
            for (y = 0; y < ThisPic.Height; y++)
            {
                // loop through the cols 
                for (x = 0; x < ThisPic.Width; x++)
                {
                    // this is the decimal number returned 
                    z = LBPthis(x, y);
                

                    // store in the nice 2d array
                    Lattice.Add(z);
                    Color c = Color.FromArgb(z, z, z);
                    Filtered.SetPixel(x, y, c);
                }

            }
            //return the answer
            LBPImage = Filtered;
            return Lattice;
        }
        // lets eliminate duplicates 

        public List<SanDictionaryItem> GetHistogram()
        {
            LBPPic();


            List<SanDictionaryItem> items = new List<SanDictionaryItem>();
            List<SanDictionaryItem> Newitems = new List<SanDictionaryItem>();
            var query = Lattice.GroupBy(x => x)
              .Where(g => g.Count() >= 1)
              .Select(y => new SanDictionaryItem(y.Key, y.Count()))
              .ToList();
            for (int x = 0; x < 256; x++)
            {
                var q2 = (from dic in query
                          where dic.key == x
                          select dic).FirstOrDefault();
                if (q2 is null)
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

            return Newitems;
        }
        // get LBP for a point 
        private int LBPthis(int X, int Y)
        {
            double average = 0;
            int total = 0;
            double count = 1;
          
                average = IntensityAverage(X, Y);
                total = GetPatternAround(X, Y, average);
               
        

            return total;
        }
        // get average of pixels the same distance away from the point
        private double IntensityAverage(int X, int Y)
        {
            // MAKE AN Answer 
            double total = 0;
            int counter = 0;
            // window around that pixel
            for (int y1 = Y - 1; y1 <= Y + 1; y1++)
            {
                for (int x1 = X - 1; x1 <= X + 1; x1++)
                {
                    // explicit bounds checks 
                    if (((x1 >= 0) && (y1 >= 0)) && ((x1 < ThisPic.Width) && (y1 < ThisPic.Height)))
                    {
                        //, also dont add the centre
                        if (((x1 != X) && (y1 != Y)))
                        {
                            // now add it to the total 
                            total += ThisPic.GetPixel(x1, y1).R;
                            counter += 1;
                        }
                        else
                        {
                            //skip
                        }
                            


                    }else
                    {
                        total += 0;
                        counter += 1;
                    }
                   

                }
            }

            return total / counter;
        }
        // custom get wrapper
        private int GetPixelValue(int X,int Y)
        {
            int value = 0;
            if (((X >= 0) && (Y >= 0)) && ((X < ThisPic.Width) && (Y < ThisPic.Height)))
            {
                // in bounds
                value = ThisPic.GetPixel(X, Y).R;
            }
         

                return value;
        }

        private int GetPatternAround(int X, int Y, double Average)
        {
            // create binary string
            string Binary = "";
            // loop through one window and set the average 
            // window around that pixel
            double ave = Average;
            if (GetPixelValue(X-1, Y-1)< ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }

            if (GetPixelValue(X - 1, Y )< ave)
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
            if (GetPixelValue(X , Y + 1) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }
            if (GetPixelValue(X +1, Y +1) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }
            if (GetPixelValue(X + 1, Y ) < ave)
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
            if (GetPixelValue(X , Y - 1) < ave)
            {
                Binary += "0";
            }
            else
            {
                Binary += "1";
            }


            //for (int y1 = Y -1; y1 <= Y + 1; y1++)
            //{
            //    for (int x1 = X - 1; x1 <= X + 1; x1++)
            //    {
            //        // explicit bounds checks 
            //        // explicit bounds checks 
            //        if (((x1 >= 0) && (y1 >= 0)) && ((x1 < ThisPic.Width) && (y1 < ThisPic.Height)))
            //        {

            //            //, also dont add the centre
            //            if (((x1 != X) && (y1 != Y)))
            //            {
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
            //            else
            //            {
            //                //skip
            //            }

            //            // this is on the angle


            //        }
            //        else
            //        {
            //            Binary += "0";
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
