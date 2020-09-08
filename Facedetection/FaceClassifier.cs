using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Facedetection
{
    class FaceClassifier
    {
        // what do we need ? we need a version of each image 
        private RGBImage myRgbImg;
        private YCBCRImage myYCbCrImg;
        private HSVimage myHVSImg; 
        // a function that takes an rgbImage and returns it after setting all the detected pixels to true 
        public void SkinScan()
        {
            // goes through them all applies rules then the pixels that pass are marked as detected 
            int x, y;
            bool myTest;
            // loop through the rows 
            for (y= 0; y< myRgbImg.GetHeight(); y++)
            {
                // loop through the cols 
                for (x = 0; x< myRgbImg.GetHeight(); x++)
                {
                    myTest = PixelTest(x, y);

                    if(myTest)
                    {
                        // this is a skin pixel
                        // flip the detected bit 
                        myRgbImg.SetDetected(x, y, true);
                    }
                }

            }
        }

        private bool PixelTest(int x, int y)
        {
            bool answer= false ;
            //In RGB
            // using rules for rgb from peer et all
            //((R > 95) AND(G > 40) AND(B > 20) AND
            //(max{ R, G, B} − min{ R, G, B} > 15) AND
            //(| R − G | > 15) AND(R > G) AND(R > B)) or 
            //(R > 220) AND (G > 210) AND (B > 170) AND
            // (| R − G | ≤ 15) AND(R > B) AND(G > B)
            RGBPixel P = myRgbImg.GetRGBPixel(x, y);
            int max = GetMaxVal(P);
            int min = GetMinVal(P);
            int delta = max - min;
            double absR_G = Math.Abs(P.GetR() - P.GetG());
            // rgb Set
            if(((P.GetR()>95)&&(P.GetG()>40)&&(P.GetB()>20)&&(delta >15)
                &&(absR_G >15)&&(P.GetR()>P.GetG())&&(P.GetR()>P.GetB()))
                ||
                ((P.GetR()>220)&&(P.GetG()>210)&&(P.GetB()>170)&&(absR_G<=15)
                &&(P.GetR()>P.GetB())&&(P.GetG()>P.GetB()) ))
            {
                // is skin according to RGB
                answer = true;
               
            } else
            {
                answer = false;
            }
            // now lets do it for hue 
            // boundaries for hsv are 25 and 230
            double hue = Convert.ToInt32 (myHVSImg.GetHueAtxy(x, y));
            if((hue < 25)||(hue >230))
            {
               // shouldnt set a flag to true that might be false already
            }
            else
            {
                answer = false;
            }
            // lets try via cbcbr
            double cb = myYCbCrImg.CbAtxy(x, y);
            double cr = myYCbCrImg.CrAtxy(x, y);
            if((cr<=(1.5862*cb+20))&&(cr >= (0.3448 * cb + 76.2069)) 
                &&(cr >= (-4.5652 * cb + 234.5652))
                &&(cr <= (-1.15 * cb + 301.75)) &&(cr <= (-2.2857 * cb + 43285)))
            {
              // shouldnt set a false flag to true by mistake 
            }
            else
            {
                answer = false;
            }


            return answer;
        }
        // to get the max 
        private int GetMaxVal(RGBPixel pix)
        {
            int max = 0;
            if((pix.GetG()>=pix.GetR())&& (pix.GetG() >= pix.GetB()))
            {
                // G is bigger
                max =Convert.ToInt32(pix.GetG());
            }
            if ((pix.GetR() >= pix.GetG()) && (pix.GetR() >= pix.GetB()))
            {
                // R is bigger
                max = Convert.ToInt32(pix.GetR());
            }
            if ((pix.GetB() >= pix.GetR()) && (pix.GetB() >= pix.GetG()))
            {
                // B is bigger
                max = Convert.ToInt32(pix.GetB());
            }
            return max;
        }
        // to get the min

        private int GetMinVal(RGBPixel pix)
        {
            int min = 0;
            if ((pix.GetG() <= pix.GetR()) && (pix.GetG() <= pix.GetB()))
            {
                // G is smallest
                min = Convert.ToInt32(pix.GetG());
            }
            if ((pix.GetR() <= pix.GetG()) && (pix.GetR() <= pix.GetB()))
            {
                // R is smallest
                min = Convert.ToInt32(pix.GetR());
            }
            if ((pix.GetB() <= pix.GetR()) && (pix.GetB() <= pix.GetG()))
            {
                // B is bigger
                min = Convert.ToInt32(pix.GetB());
            }
            return min;
        }
        // a function that floods any missed bits


        // a function that  builds bounding boxes 


        // a function that chooses the face one 

    }
}
