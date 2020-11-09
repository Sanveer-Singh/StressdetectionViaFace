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
        // ADLBP classifier with radius of 1 
        ADLBP descriptor; 

        public LBP(Bitmap bmp)
        {
            descriptor = new ADLBP(bmp, 1);
        }

      public Bitmap  GetPic()
        {
            return descriptor.GetTheLbpImage();
        }
        public List<SanDictionaryItem > Histogram ()
        {
            return  descriptor.GetHistogram();
        }
    }
}
