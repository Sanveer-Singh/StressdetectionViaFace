using StressdetectionViaFace.utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.LBPvariants
{
    class ADLBP
    {
        // we need a bitmap 
        Bitmap ThisPic;
        // we need a radius 
        int Radius;
        // integer latice 
        List<int> Lattice;
        // an lbp image to show that the lbp works
        public Bitmap LBPImage;
        public Bitmap GetTheLbpImage()
        { LBPADLBPLattice();
            return LBPImage; }
            

        public ADLBP(Bitmap bmp, int Rad = 3)
        {
            ThisPic = bmp;
            Radius = Rad;
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
                    z = z / Radius;
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
                    z = z / Radius;
          
                }

            }
            // return the answer 
         
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
            var query = Lattice.GroupBy(x => x)
              .Where(g => g.Count() >= 1)
              .Select(y => new SanDictionaryItem(y.Key, y.Count()))
              .ToList();


            return query;
        }
        // get ADLBP for a point 
        private int AMLBPthis(int X, int Y)
        {
   
            int total = 0;
            double count = 1;
            // loop through radius distances
            for (int x1 = 1; x1 <= Radius; x1++)
            {
                //average = IntensityAverage(X, Y, x1);
                int nc = ThisPic.GetPixel(X, Y).R;
                total += GetPatternAround(X, Y, x1, nc);
                count += 1;
            }

            return (int)Math.Truncate(total / count);
        }
        // get average of pixels the same distance away from the point
        private double IntensityAverage(int X, int Y, int dist)
        {
            // MAKE AN Answer 
            double total = 0;
            int counter = 0;
            // window around that pixel
            for (int y1 = Y - (dist + 1); y1 <= Y + (dist + 1); y1++)
            {
                for (int x1 = X - (dist + 1); x1 <= X + (dist + 1); x1++)
                {
                    // explicit bounds checks 
                    if ((x1 >= 0) && (y1 >= 0) && (x1 < ThisPic.Width) && (y1 < ThisPic.Height))
                    {
                        // check if its at the right distance 
                        // point A(centre) to B
                        Point A = new Point(X, Y);
                        Point B = new Point(x1, y1);
                        int distanceAtoB = DistanceAtoB(A, B);
                        if (dist == distanceAtoB)
                        {
                            // now add it to the total 
                            total += ThisPic.GetPixel(x1, y1).R;
                            counter += 1;
                        }


                    }

                }
            }

            return total / counter;
        }
        private int GetPatternAround(int X, int Y, int dist, double Average)
        {
            // create binary string
            string Binary = "";
            // loop through one window and set the average 
            // window around that pixel
            int ave = (int)Math.Truncate(Average);
            for (int y1 = Y - (dist + 1); y1 <= Y + (dist + 1); y1++)
            {
                for (int x1 = X - (dist + 1); x1 <= X + (dist + 1); x1++)
                {
                    // explicit bounds checks 
                    if ((x1 >= 0) && (y1 >= 0) && (x1 < ThisPic.Width) && (y1 < ThisPic.Height))
                    {
                        // check distance
                        Point A = new Point(X, Y);
                        Point B = new Point(x1, y1);
                        int distanceAtoB = DistanceAtoB(A, B);
                        if (dist == distanceAtoB)
                        {
                            // this is on the angle
                            if (ThisPic.GetPixel(x1, y1).R < ave)
                            {
                                // it needs to be a zero 
                                Binary += "0";
                            }
                            else
                            {
                                // it need a  1 
                                Binary += "1";
                            }
                        }
                    }

                }
            }
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
