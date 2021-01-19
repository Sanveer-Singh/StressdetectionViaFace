using StressdetectionViaFace.Preprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        private RGBImage Greyscaled;
        // we need a constructor 
        public FaceClassifier(Bitmap BMP)
        {
            myRgbImg = new RGBImage(BMP);
            myHVSImg = new HSVimage(BMP);
            myYCbCrImg = new YCBCRImage(BMP);
        }

        // a function that takes an rgbImage and returns it after setting all the detected pixels to true 
        public void SkinScan()
        {
            // goes through them all applies rules then the pixels that pass are marked as detected 
            int x, y;
            bool myTest;
            // loop through the rows 
            for (y = 0; y < myRgbImg.GetHeight(); y++)
            {
                // loop through the cols 
                for (x = 0; x < myRgbImg.GetWidth(); x++)
                {
                    myTest = PixelTest(x, y);

                    if (myTest)
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
            bool answer = false;
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
            if (((P.GetR() > 95) && (P.GetG() > 40) && (P.GetB() > 20) && (delta > 15)
                && (absR_G > 15) && (P.GetR() > P.GetG()) && (P.GetR() > P.GetB()))
                ||
                ((P.GetR() > 220) && (P.GetG() > 210) && (P.GetB() > 170) && (absR_G <= 15)
                && (P.GetR() > P.GetB()) && (P.GetG() > P.GetB())))
            {
                // is skin according to RGB
                answer = true;

            } else
            {
                answer = false;
            }
            // now lets do it for hue 
            // boundaries for hsv are 25 and 230
            // less than 50 or greater than 150
            double hue = Convert.ToInt32(myHVSImg.GetHueAtxy(x, y));
            if ((hue < 25) || (hue > 150))
            {
                // shouldnt set a flag to true that might be false already
            }
            else
            {
                answer = false;
            }
            // lets try via cbcbr
            //double cb = myYCbCrImg.CbAtxy(x, y);
            //double cr = myYCbCrImg.CrAtxy(x, y);
            //if (((cr <= (1.5862 * cb + 20)) && (cr >= (0.3448 * cb + 76.2069))
            //    && (cr >= (-cb + 234.5652)) //
            //    && (cr <= (-1.15 * cb + 301.75)) && (cr <= (-2.2857 * cb + 43285))) && ((cb >= 77) && (cb <= 127) && (cr >= 133) && (cb <= 173)))
            //{
            //    // shouldnt set a false flag to true by mistake 
            //}
            //else
            //{
            //    answer = false;
            //}

            // rule 2 
            // 


            return answer;
        }
        // to get the max 
        private int GetMaxVal(RGBPixel pix)
        {
            int max = 0;
            if ((pix.GetG() >= pix.GetR()) && (pix.GetG() >= pix.GetB()))
            {
                // G is bigger
                max = Convert.ToInt32(pix.GetG());
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

        //  A function to to the bmps .. for display purposes
        public Bitmap ToBmp()
        {
            return myRgbImg.ToBmp();
        }
        public Bitmap DetectedBmp()
        {
            SkinScan();
            return myRgbImg.GetDetectedBmp();
        }

        public RGBImage GetDetectedWithMask()
        {
            SkinScan();
            floodIt();
            return myRgbImg;
        }
        // a function that floods any missed bits
        public void floodIt( double tolerance=2)
        {
            // use a loop to properly do this 
            bool changed = true;
            while (changed )
            {
                changed = false;
                // window through it to get non skin surrounded by skin 

                // goes through them all applies rules then the pixels that pass are marked as detected 
                int x, y;
                // a value to hold skin pixel neighbors 
                int skinNeighbors;
                // loop through the rows 
                for (y = 0; y < myRgbImg.GetHeight(); y++)
                {
                    // loop through the cols 
                    for (x = 0; x < myRgbImg.GetWidth(); x++)
                    {
                        // if the pixel is non skin then window around it
                        RGBPixel P = myRgbImg.GetRGBPixel(x, y);
                        if (!P.GetDetected())
                        {
                            // not detected as skin 
                            skinNeighbors = getSkinneighbors(x, y);
                            // if its surrounded by skin
                            if ((skinNeighbors > (7 - tolerance)))
                            {
                                // make it a skin pixel
                                myRgbImg.SetDetected(x, y, true);
                                changed = true;
                            }
                           
                        }
                        //else 
                        //{
                        //    // skin detected 
                        //    skinNeighbors = getSkinneighbors(x, y);
                        //    // if its surrounded by skin
                        //    if ((skinNeighbors < (6.6 - tolerance)))
                        //    {
                        //        // make it a skin pixel
                        //        myRgbImg.SetDetected(x, y, false);
                        //        changed = true;
                        //    }

                        //}
                    }

                }
            }
            

        }
        // get splot
        // use to find splots 
        public void CleanSplot(int X, int Y)
        {
            int count = 0;
            int Xtolerance =(int) Math.Truncate((myRgbImg.GetWidth()*0.05));
            int ytolerance = (int)Math.Truncate((myRgbImg.GetHeight ()*0.05));
            for (int y1 = Y - ytolerance ; y1 <= Y + ytolerance ; y1++)
            {
                for (int x1 = X - Xtolerance ; x1 <= X + Xtolerance ; x1++)
                {
                    // explicit bounds checks 
                    if ((x1 >= 0) && (y1 >= 0) && (x1 < myRgbImg.GetWidth()) && (y1 < myRgbImg.GetHeight()))
                    {
                        RGBPixel newC = myRgbImg.GetRGBPixel(x1, y1);
                        if (newC.GetDetected())
                        {
                            // total the skinpixels around it 
                            count += 1;
                        }
                    }

                }
            }
         
        }
       

        // a function to get skin neighbors 
        //gets the number of skin pixels around a pixel
        private  int getSkinneighbors(int X, int Y)
        {
            
            int count = 0;
          
            for (int y1 = Y - 1; y1 <= Y + 1; y1++)
            {
                for (int x1 = X - 1; x1 <= X + 1; x1++)
                {
                    // explicit bounds checks 
                    if ((x1 >= 0) && (y1 >= 0) && (x1 < myRgbImg.GetWidth()) && (y1 < myRgbImg.GetHeight()))
                    {
                        RGBPixel  newC = myRgbImg .GetRGBPixel(x1, y1);
                        if (newC.GetDetected())
                        {
                            // total the skinpixels around it 
                            count += 1;
                        }
                    }

                }
            }
            return count;

        }

        // a function that  builds bounding boxes
       public Bitmap GetFaceOnly()
        {
            int mostleft, mostright, mostup, mostdown;
            mostleft = getMostLeftxValue();
            mostright = getMostRighttxValue();
            mostup = getMostUpYvalue();
            mostdown = getMostDownYvalue();
            int newWidth, newHeight;
            newWidth = mostright - mostleft;
            newHeight = mostdown - mostup;
            Bitmap newimg = new Bitmap(newWidth, newHeight);
            Bitmap oldimg = myRgbImg.ToBmp();
            //// copy 
            //int x, y;
        
            //// loop through the rows 
            //for (y = mostup ; y < mostdown  ; y++)
            //{
            //    // loop through the cols 
            //    for (x = mostleft ; x < mostright  ; x++)
            //    {
            //        Color nc = new Color();
            //        nc = oldimg.GetPixel(x, y);
            //        newimg.SetPixel(x - mostleft, y - mostup, nc);
            //    }

            //}

            return newimg;
        }

        private int getMostLeftxValue()
        {
            int myXval = 0;
            int x, y;


            // loop through the cols 
            for (x = 0; x < myRgbImg.GetWidth(); x++)
            {
                // loop through the rows 
                for (y = 0; y < myRgbImg.GetHeight(); y++)
                {
                    
                    RGBPixel P = myRgbImg.GetRGBPixel(x, y);
                    if (P.GetDetected())
                    {
                        myXval = x;
                        return myXval;
                    }

                }
            }
            return myXval;
        }
        private int getMostRighttxValue()
        {
            int myXval = 0;
            int x, y;


            // loop through the cols 
            for (x = myRgbImg.GetWidth()-1; x >0 ; x--)
            {
                // loop through the rows 
                for (y = 0; y < myRgbImg.GetHeight(); y++)
                {
              
                    RGBPixel P = myRgbImg.GetRGBPixel(x, y);
                    if (P.GetDetected())
                    {
                        myXval = x;
                        return myXval;
                    }

                }
            }
            return myXval;
        }

        private int getMostUpYvalue()
        {
            int myXval = 0;
            int x, y;

            
                // loop through the rows 
                for (y = 0; y < myRgbImg.GetHeight(); y++)
                {
                    // loop through the cols 
                    for (x = 0; x < myRgbImg.GetWidth(); x++)
                    {
                        // if the pixel is skin then window around it
                        RGBPixel P = myRgbImg.GetRGBPixel(x, y);
                        if (P.GetDetected())
                        {
                            myXval = y;
                            return myXval;
                        }
                    }

                }
            
            return myXval;
        }
        private int getMostDownYvalue()
        {
            int myXval = 0;
            int x, y;


            // loop through the rows 
            for (y = myRgbImg.GetHeight()-1; y >0; y--)
            {
                // loop through the cols 
                for (x = 0; x < myRgbImg.GetWidth(); x++)
                {
                    // if the pixel is skin then window around it
                    RGBPixel P = myRgbImg.GetRGBPixel(x, y);
                    if (P.GetDetected())
                    {
                        myXval = y;
                        return myXval;
                    }
                }

            }

            return myXval;
        }

        // a function to set the greyscaled option 
        public Bitmap  GetGreyScaled()
        {
            Bitmap grey;
           grey =  GreyScalar.GreyscaleThis(myRgbImg.ToBmp() );
            // lets save the changes 
            // perform pixel by pixel copy 
            // goes through them all applies rules then the pixels that pass are marked as detected 
            int x, y;
            bool myTest;
            // loop through the rows 
            for (y = 0; y < myRgbImg.GetHeight(); y++)
            {
                // loop through the cols 
                for (x = 0; x < myRgbImg.GetWidth(); x++)
                {
                   
                    // we only care about the detected pixels 
                    if (myRgbImg.DetectedAtxy (x,y))
                    {
                        myRgbImg.SetR(x,y,grey.GetPixel(x,y).R );
                        myRgbImg.SetG(x, y, grey.GetPixel(x, y).G);
                        myRgbImg.SetB(x, y, grey.GetPixel(x, y).G);
                    }
                }

            }
            return myRgbImg.GetDetectedBmp();
        }

        // a function that chooses the face one 

    }
}
