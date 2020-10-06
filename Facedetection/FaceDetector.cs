using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Facedetection
{
    class FaceDetector
    {
        // handles pipelines 
        private FaceClassifier classifier;

        public FaceDetector( Bitmap bmp)
        {
           
                classifier = new FaceClassifier(bmp);
          
        }

        public Bitmap GetDetectedBmp()
        {
            return classifier.DetectedBmp();
        }
        // flood control
        public Bitmap flood()
        {
            classifier.floodIt();
            return classifier.DetectedBmp();
        }
        // get face only
        public Bitmap GetfaceOnly()
        {
            return classifier.GetFaceOnly();
        }
        // grey scale control 
        public Bitmap GetGreyscaled()
        {
            return classifier.GetGreyScaled();
           
        }
    }
}
