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
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
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
        }

        private void btnGetFace_Click(object sender, EventArgs e)
        {

        }

        private void btnGreyScalar_Click(object sender, EventArgs e)
        {
            Bitmap greyScaled = GreyScalar.GreyscaleThis(FloodedSkin);
            
            // set size
            Size sz = new Size(500, 500);
            Image img = new Bitmap(greyScaled);
            picBox.Image = new Bitmap(img, sz);
        }
    }
}
