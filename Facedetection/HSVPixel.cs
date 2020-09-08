using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Facedetection
{
    class HSVPixel
    {// what is a YcbCr pixel?
        private double _H;
        private double _S;
        private double _L;
        // struct constructor 
        public HSVPixel(double H, double S, double L)
        {
            this._H = H;
            this._S = S;
            this._L = L;
        }

        // getters
        public double GetH()
        {
            return this._H;
        }
        public double GetS()
        {
            return this._S;
        }
        public double GetL()
        {
            return this._L;
        }

        //
        //setters
        public void SetH(double H)
        {
            this._H = H;
        }
        public void SetL(double L)
        {
            this._L = L;
        }
        public void SetS(double S)
        {
            this._S = S;
        }
    }
}
