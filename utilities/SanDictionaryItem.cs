using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace StressdetectionViaFace.utilities
{
    class SanDictionaryItem
    {

        public int key;
        public int count; 

        public SanDictionaryItem(int theKey, int theCount)
        {
            key = theKey;
                count = theCount;
        }
       
       public override string ToString()
        {
            return String.Concat( key.ToString(), count.ToString() , ";");
       
        
        }
    }
}
