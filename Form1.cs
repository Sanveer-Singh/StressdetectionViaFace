﻿using System;
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
using StressdetectionViaFace.LBPvariants;
using StressdetectionViaFace.utilities;
using StressdetectionViaFace.Segmentation;
using Microsoft.VisualBasic;

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
        public Bitmap MyGradientImage;
        // save the face only
        public Bitmap FaceOnly;
        public string FileName1;
        public string FileLocation1;

     


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //HYPKNNDataContext db = new HYPKNNDataContext();
            //Pipeline p = new Pipeline();
            //p.CONCATpattern = "test1";
            //p.CONCATpredicted = "test1";
            //p.LABEL = "test";
            //p.lOCATION = "test";
            //p.NAME = "test";
            //db.Pipelines.InsertOnSubmit(p);
            //db.SubmitChanges();
            //Pipeline x = new Pipeline();
            //var test = (from u in db.Pipelines
            //           where u.CONCATpattern == "test1"
            //           select u).FirstOrDefault();

            //x = (Pipeline)test;
       
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
                // image file path  
                FileLocation1 = open.FileName;
                FileName1 = Interaction.InputBox("Please enter file name ");
                 Bitmap m1 = new Bitmap(FileLocation1);
                Image img = new Bitmap(m1);
                original = m1;
                Bitmap bp = new Bitmap(img,sz);
                
                picBox.Image = bp;
             
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
        public void msgBox( string Input= "its finaly done")
        {
            string message = Input;
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
         
            Bitmap bmp = LibraryBased.faceOnly(original);
            Bitmap GreyScaled1;
            if (!(bmp is null))
            {
                // got the face  now save 
                // greyscale 
                GreyScaled1 = GreyScalar.GreyscaleThis(bmp);
                original = GreyScaled1;
                Size sz = new Size(GreyScaled1.Width, GreyScaled1.Height);
                Image img = new Bitmap(GreyScaled1);
                picBox.Image = new Bitmap(img, sz);
            }
        }

        private void btnGreyScalar_Click(object sender, EventArgs e)
        {
            Bitmap greyScaled = detector.GetGreyscaled();
            original = greyScaled;
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
            // resize 
            Size sz = new Size(original.Width , original.Height );
            Image img = new Bitmap(original );
            picBox.Image = new Bitmap(img, sz);
            original = (Bitmap )picBox.Image;

        }

       

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLBP_Click(object sender, EventArgs e)
        {
            LBP();

        }

        private string LBP()
        {
            string temp = "";
            LBP lbp = new LBP(original);
            List<SanDictionaryItem> histogram = lbp.GetHistogram();
          
            foreach (SanDictionaryItem i in histogram)
            {
                temp += i.ToString();
            }
            textBox1.Text = temp;
            //MessageBox.Show(temp, "histogram");
            Size sz = new Size(original.Width, original.Height);
            Image img = new Bitmap(lbp.GetPic());
            picBox.Image = new Bitmap(img, sz);
            return temp;

        }

        private void btnADLBP_Click(object sender, EventArgs e)
        {
            ADLBP lbp = new ADLBP(original);
            List<SanDictionaryItem> histogram = lbp.GetHistogram();
            string temp = "";
            foreach (SanDictionaryItem i in histogram)
            {
                temp += i.ToString();
            }
            textBox1.Text = temp;
            MessageBox.Show(temp, "histogram");
            Size sz = new Size(original.Width, original.Height);
            Image img = new Bitmap(lbp.GetPic ());
            picBox.Image = new Bitmap(img, sz);
        }

        private void button2_Click(object sender, EventArgs e)
        {// send original
            CircularMeanFilter cmf = new CircularMeanFilter (original);
            // save  this 
            original = cmf.GetFiltered ();
            // resize 
            Size sz = new Size(original.Width, original.Height);
            Image img = new Bitmap(original);
            picBox.Image = new Bitmap(img, sz);
            original = (Bitmap)picBox.Image;

        }

        private void btnGradientImage_Click(object sender, EventArgs e)
        {
            GradientImage gi = new GradientImage();
            MyGradientImage = gi.GetTotalEdgeImage(GreyscaledSkin);
            Size sz = new Size(GreyscaledSkin.Width, GreyscaledSkin.Height);
            Image img = new Bitmap(MyGradientImage );
            picBox2.Image = new Bitmap(img, sz);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btnGradientImage_Click(sender,e);
        }

        private void GradientTest_Click(object sender, EventArgs e)
        {
            GradientImage gi = new GradientImage();
            MyGradientImage = gi.GetTotalEdgeImage(original);
            Size sz = new Size(original.Width, original.Height);
            Image img = new Bitmap(MyGradientImage);
            picBox2.Image = new Bitmap(img, sz);

        }

        private void NI_LBP_Click(object sender, EventArgs e)
        {
            NI_LBP lbp = new NI_LBP(original);
            List<SanDictionaryItem> histogram = lbp.GetHistogram();
            string temp = "";
            foreach (SanDictionaryItem i in histogram)
            {
                temp += i.ToString();
            }
            textBox1.Text = temp;
            MessageBox.Show(temp, "histogram");
            Size sz = new Size(original.Width, original.Height);
            Image img = new Bitmap(lbp.GetPic());
            picBox.Image = new Bitmap(img, sz);
        }

        private string nilbp()
        {
            NI_LBP lbp = new NI_LBP(original);
            List<SanDictionaryItem> histogram = lbp.GetHistogram();
            string temp = "";
            foreach (SanDictionaryItem i in histogram)
            {
                temp += i.ToString();
            }
            textBox1.Text = temp;
            //MessageBox.Show(temp, "histogram");
            Size sz = new Size(original.Width, original.Height);
            Image img = new Bitmap(lbp.GetPic());
            picBox.Image = new Bitmap(img, sz);
            return temp;
        }

        private void btnPipeline_Click(object sender, EventArgs e)
        {
            btnChooseImage_Click(sender, e);
            // step 1
            string input = Interaction.InputBox("Please enter the true label");
            GetDetectedFace_Click(sender, e);
           // step 2
            FillPatches_Click(sender, e);
            // step 3
            btnGreyScalar_Click(sender, e);
            btnFilter_Click(sender, e);
            // step 4
            string hist = LBP();
        


        }

        private void btnPipeline2_Click(object sender, EventArgs e)
        {
            btnChooseImage_Click(sender, e);
            // step 1
            string input = Interaction.InputBox("Please enter the true label");
            // step 2
            btnGetFaceViaLibrary_Click(sender, e);
            
            // step 3

            btnFilter_Click(sender, e);
            // step 4
            string hist = nilbp();
        }

        private void btnPipeline3_Click(object sender, EventArgs e)
        {
            btnChooseImage_Click(sender, e);
            // step 1
            string input = Interaction.InputBox("Please enter the true label");
            // step 2
            btnGetFaceViaLibrary_Click(sender, e);

            // step 3

            btnFilter_Click(sender, e);
            // step 4
            string hist1 = nilbp();
            Bitmap m1 = new Bitmap(FileLocation1);
            Image img = new Bitmap(m1);
            btnGetFaceViaLibrary_Click(sender, e);
            btnFilter_Click(sender, e);
            string hist2 = LBP();
            string hist = hist1 + hist2;

        }


    }
}
