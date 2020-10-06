using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Facedetection
{
    class LibraryBased
    {

        static readonly CascadeClassifier classifier = new CascadeClassifier("Data/haarcascade_frontalface_default.xml");

        // constructor 
      

        public static  Bitmap faceOnly(Bitmap wholepic)
        {
            Bitmap answer = null;
            // create a 3 dimensional array
            Image<Bgr, byte> Emguimage = new Image<Bgr ,byte>(wholepic );
            Rectangle[] rectangles = classifier.DetectMultiScale(Emguimage);
            if (rectangles.Length == 0)
            {
                // this means no faces present
            }
            else
            {
                int width = rectangles[0].Width;
                int height = rectangles[0].Height ;
                int right = rectangles[0].Right;
                int Left = rectangles[0].Left;
                int Top = rectangles[0].Top;
                int Bottom = rectangles[0].Bottom ;
                Bitmap bmp = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(bmp)) g.Clear(Color.White);
                for (int y = Top ; y < Bottom ; y++)
                {
                    for (int x = Left; x < right; x++)
                    {
                        Color nc = new Color();
                        nc = Color.FromArgb(Convert.ToInt32(wholepic.GetPixel(x, y).R), Convert.ToInt32(wholepic.GetPixel(x, y).G), Convert.ToInt32(wholepic.GetPixel(x, y).B));
                        bmp.SetPixel(x - Left, y - Top, nc);
                    }
                }
                answer = bmp;

           
            }
            // returns null if nothing found 
            return answer;

        }
    }
}
