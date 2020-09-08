using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.utilities
{
    class point
    {
        // points are just an x and y value 
        private  int _X;
        private  int _Y;

       // constructor 
       public point(int x, int y)
        {
            _X = x;
            _Y = y;
        }

        // getters and setters 

        public int GetX()
        {
            return _X;
        }
        public  int GetY()
        {
            return _Y;
        }
        public void  SetX( int X)
        {
          _X = X  ;
        }
        public void SetY(int Y)
        {
            _Y = Y;
        }
        // distance calculator (euclidian)
        public double GetEuclidDistAtoB(point A, point B)
        {
            double dist = 0;
            dist = Math.Sqrt(Math.Pow((B.GetX() - A.GetX()), 2) + Math.Pow((B.GetY() - A.GetY()), 2));
            return dist;
        }

    }
}
