using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Segmentation
{
    class ImageEdge
    {
        //weight - normalize the 255 to 100
        public double Weight;
        // to node 
        ImageNode ToThis;
        // from node 
        ImageNode FromThis;

        public ImageEdge(double _weight,ImageNode FromHere, ImageNode Tohere )
        {
            Weight = _weight;
            ToThis = Tohere;
            FromThis = FromHere;
        }

        public ImageNode Destination()
        {
            return ToThis;
        }
        public ImageNode FromHere()
        {
            return FromThis;
        }
    }
}
