using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Facedetection
{
    class RGBPixel
    {
        // what is a RGB pixel?
        private double _R;
        private double _G;
        private double _B;
        private bool _Detected;
        // struct constructor 
        public RGBPixel(double R, double G, double B, bool Detected)
        {
            this._R = R;
            this._G = G;
            this._B = B;
            this._Detected = Detected;
        }

        // getters
        public double GetR()
        {
            return this._R;
        }
        public double GetG()
        {
            return this._G;
        }
        public double GetB()
        {
            return this._B;
        }
        public bool GetDetected()
        {
            return this._Detected;
        }

        //
        //setters
        public void SetR(double R)
        {
            this._R = R;
        }
        public void SetG(double G)
        {
            this._G = G;
        }
        public void SetB(double B)
        {
            this._B = B;
        }
        public void SetDetected(bool Detected)
        {
            this._Detected = Detected;
        }

    }
}
