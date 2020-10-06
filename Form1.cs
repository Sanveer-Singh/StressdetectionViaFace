using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StressdetectionViaFace.Facedetection;
using StressdetectionViaFace.Preprocessing;

namespace StressdetectionViaFace
{
    public partial class Form1 : Form
    {
        // we need the initial bmp 
         public Bitmap original;
        // we need a face detector 
         private FaceDetector detector;
        // we need the skin only bmp
        public Bitmap SkinOnly;
        // save the flooded image 
        public Bitmap FloodedSkin;
        // save the grey scaled version 
        public Bitmap GreyscaledSkin;
        // save the face only
        public Bitmap FaceOnly;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog
            {
                // image filters  
                Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                // set size
                Size sz = new Size(500,500);
                // display image in picture box  
                Bitmap m1 = new Bitmap(open.FileName);
                Image img = new Bitmap(m1);
                original = m1;
                Bitmap bp = new Bitmap(img,sz);
                
                picBox.Image = bp;
                // image file path  
            }
        }

        private void GetDetectedFace_Click(object sender, EventArgs e)
        {
            ColorMeanFilter cmf = new ColorMeanFilter(original);
            original = cmf.MeanFilterThis();
            // repeat for greater effect
            original = cmf.MeanFilterThis();
            detector  = new FaceDetector(original );
            Bitmap detected = detector.GetDetectedBmp();
            // save 
            SkinOnly = detected;
            // set size
            Size sz = new Size(500, 500);
            Image img = new Bitmap(detected);
            picBox.Image = new Bitmap(img, sz);
        }

        private void FillPatches_Click(object sender, EventArgs e)
        {
           Bitmap flooded =  detector.flood();
            // save 
            FloodedSkin  = flooded;
            // set size
            Size sz = new Size(500, 500);
            Image img = new Bitmap(flooded);
            picBox.Image = new Bitmap(img, sz);
            msgBox();
       
        }

        // message box function 
        public void msgBox()
        {
            string message = "Finally done";
            string caption = "its done";
           
             MessageBox.Show(message, caption);
        }

        private void btnGetFace_Click(object sender, EventArgs e)
        {
            detector.GetfaceOnly();
            Bitmap flooded = detector.GetfaceOnly(); 
            // save 
            FloodedSkin = flooded;
            // set size
            Size sz = new Size(flooded.Width , flooded.Height );
            Image img = new Bitmap(flooded);
            picBox.Image = new Bitmap(img, sz);
        }

        private void btnGreyScalar_Click(object sender, EventArgs e)
        {
            Bitmap greyScaled = detector.GetGreyscaled();
            // save 
            GreyscaledSkin = greyScaled;
            // set size
            Size sz = new Size(greyScaled.Width , greyScaled.Height );
            Image img = new Bitmap(greyScaled);
            picBox.Image = new Bitmap(img, sz);
        }

       /// <summary>
       /// Set up so original will now be localized and greyscaled
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>       
       private void btnGetFaceViaLibrary_Click(object sender, EventArgs e)
        {
         
            Bitmap bmp = LibraryBased .faceOnly(original);
            Bitmap GreyScaled1;
            if(!(bmp is null ))
            {
                // got the face  now save 
                // greyscale 
                GreyScaled1 = GreyScalar.GreyscaleThis(bmp);
                original  = GreyScaled1 ;
                Size sz = new Size(GreyScaled1.Width, GreyScaled1.Height);
                Image img = new Bitmap(GreyScaled1);
                picBox.Image = new Bitmap(img, sz);
            }
            
        }

        /// use the grey scaled and localized original
        /// 
        private void btnFilter_Click(object sender, EventArgs e)
        {
            // send original
            MeanFilter mf = new MeanFilter(original);
            // save  this 
            original = mf.MeanFilterThis();
            Size sz = new Size(original .Width, original .Height);
            Image img = new Bitmap(original );
            picBox.Image = new Bitmap(img, sz);

        }
    }
}
