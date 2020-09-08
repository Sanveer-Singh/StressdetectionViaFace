using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Facedetection
{
    class YCbCrPixel
    {
        // what is a YcbCr pixel?
        private double _Y;
        private double _Cb;
        private double _Cr;
        // struct constructor 
        public YCbCrPixel(double Y, double CB, double Cr)
        {
            this._Y = Y;
            this._Cb = CB;
            this._Cr = CB;
        }

        // getters
        public double GetY()
        {
            return this._Y;
        }
        public double GetCb()
        {
            return this._Cb;
        }
        public double GetCr()
        {
            return this._Cr;
        }

        //
        //setters
        public void SetY(double y)
        {
            this._Y = y;
        }
        public void SetCb(double Cb)
        {
            this._Cb = Cb;
        }
        public void SetCr(double Cr)
        {
            this._Cr = Cr;
        }
    }
}
