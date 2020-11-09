using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Segmentation
{
    class ImageNode
    {

        // coordinates 
        public int Xvalue;
        public int YValue;

        public double gradient;
        public double ThisGradient
        {
            get
            {
                return gradient;
            }
            set
            {
                gradient = value;
            }
        }

        public double isSKin;
        /// <summary>
        ///  gets and sets the is skin value 
        /// </summary>
        public double IsSkin
        {
            get
            {
                return isSKin;
            }
            set
            {
                isSKin = value;
            }
        }

        public ImageEdge leftEdge = null;

        public ImageEdge GetLeftEdge
        {
            get { return leftEdge; }
            set { leftEdge = value; }
        }

        public ImageEdge RightEdge = null;

        public ImageEdge myRightEdge
        {
            get { return RightEdge; }
            set { RightEdge = value; }
        }

        public ImageEdge DownEdge= null;

        public ImageEdge myDownEdge
        {
            get { return DownEdge ; }
            set { DownEdge  = value; }
        }

        public ImageNode(int x, int y)
        {
            Xvalue = x;
            YValue = y;
        }

    }
}
