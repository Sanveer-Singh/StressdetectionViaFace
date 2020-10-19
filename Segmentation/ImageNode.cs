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


        public ImageNode(int x, int y)
        {
            Xvalue = x;
            YValue = y;
        }

    }
}
