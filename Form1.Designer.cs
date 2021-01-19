namespace StressdetectionViaFace
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.GetDetectedFace = new System.Windows.Forms.Button();
            this.FillPatches = new System.Windows.Forms.Button();
            this.btnGreyScalar = new System.Windows.Forms.Button();
            this.btnGetFaceViaLibrary = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnLBP = new System.Windows.Forms.Button();
            this.btnADLBP = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GradientTest = new System.Windows.Forms.Button();
            this.NI_LBP = new System.Windows.Forms.Button();
            this.btnPipeline = new System.Windows.Forms.Button();
            this.btnPipeline2 = new System.Windows.Forms.Button();
            this.btnPipeline3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(202, 135);
            this.picBox.Margin = new System.Windows.Forms.Padding(1);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(832, 439);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // GetDetectedFace
            // 
            this.GetDetectedFace.Location = new System.Drawing.Point(1110, 87);
            this.GetDetectedFace.Margin = new System.Windows.Forms.Padding(1);
            this.GetDetectedFace.Name = "GetDetectedFace";
            this.GetDetectedFace.Size = new System.Drawing.Size(114, 40);
            this.GetDetectedFace.TabIndex = 2;
            this.GetDetectedFace.Text = "Show skin detected";
            this.GetDetectedFace.UseVisualStyleBackColor = true;
            this.GetDetectedFace.Click += new System.EventHandler(this.GetDetectedFace_Click);
            // 
            // FillPatches
            // 
            this.FillPatches.Location = new System.Drawing.Point(1110, 135);
            this.FillPatches.Margin = new System.Windows.Forms.Padding(1);
            this.FillPatches.Name = "FillPatches";
            this.FillPatches.Size = new System.Drawing.Size(114, 41);
            this.FillPatches.TabIndex = 3;
            this.FillPatches.Text = "Fill patches";
            this.FillPatches.UseVisualStyleBackColor = true;
            this.FillPatches.Click += new System.EventHandler(this.FillPatches_Click);
            // 
            // btnGreyScalar
            // 
            this.btnGreyScalar.Location = new System.Drawing.Point(-200, -547);
            this.btnGreyScalar.Margin = new System.Windows.Forms.Padding(1);
            this.btnGreyScalar.Name = "btnGreyScalar";
            this.btnGreyScalar.Size = new System.Drawing.Size(114, 47);
            this.btnGreyScalar.TabIndex = 5;
            this.btnGreyScalar.Text = "Apply greyscaling";
            this.btnGreyScalar.UseVisualStyleBackColor = true;
            this.btnGreyScalar.Visible = false;
            this.btnGreyScalar.Click += new System.EventHandler(this.btnGreyScalar_Click);
            // 
            // btnGetFaceViaLibrary
            // 
            this.btnGetFaceViaLibrary.Location = new System.Drawing.Point(1102, 563);
            this.btnGetFaceViaLibrary.Margin = new System.Windows.Forms.Padding(1);
            this.btnGetFaceViaLibrary.Name = "btnGetFaceViaLibrary";
            this.btnGetFaceViaLibrary.Size = new System.Drawing.Size(114, 49);
            this.btnGetFaceViaLibrary.TabIndex = 6;
            this.btnGetFaceViaLibrary.Text = "Get Face With library";
            this.btnGetFaceViaLibrary.UseVisualStyleBackColor = true;
            this.btnGetFaceViaLibrary.Click += new System.EventHandler(this.btnGetFaceViaLibrary_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(1110, 209);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(1);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(114, 44);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Soften The Image via square mean filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnLBP
            // 
            this.btnLBP.Location = new System.Drawing.Point(1107, 389);
            this.btnLBP.Margin = new System.Windows.Forms.Padding(1);
            this.btnLBP.Name = "btnLBP";
            this.btnLBP.Size = new System.Drawing.Size(114, 32);
            this.btnLBP.TabIndex = 10;
            this.btnLBP.Text = "Get LBP histogram";
            this.btnLBP.UseVisualStyleBackColor = true;
            this.btnLBP.Click += new System.EventHandler(this.btnLBP_Click);
            // 
            // btnADLBP
            // 
            this.btnADLBP.Location = new System.Drawing.Point(1107, 435);
            this.btnADLBP.Margin = new System.Windows.Forms.Padding(1);
            this.btnADLBP.Name = "btnADLBP";
            this.btnADLBP.Size = new System.Drawing.Size(114, 36);
            this.btnADLBP.TabIndex = 11;
            this.btnADLBP.Text = "Get ADLBP histogram";
            this.btnADLBP.UseVisualStyleBackColor = true;
            this.btnADLBP.Click += new System.EventHandler(this.btnADLBP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Localization By Hand:";
            this.label2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 417);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Pre Processing Options:";
            this.label4.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 115);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 468);
            this.textBox1.TabIndex = 19;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // GradientTest
            // 
            this.GradientTest.Location = new System.Drawing.Point(1103, 324);
            this.GradientTest.Name = "GradientTest";
            this.GradientTest.Size = new System.Drawing.Size(118, 39);
            this.GradientTest.TabIndex = 20;
            this.GradientTest.Text = "Gradient";
            this.GradientTest.UseVisualStyleBackColor = true;
            this.GradientTest.Click += new System.EventHandler(this.GradientTest_Click);
            // 
            // NI_LBP
            // 
            this.NI_LBP.Location = new System.Drawing.Point(1102, 494);
            this.NI_LBP.Name = "NI_LBP";
            this.NI_LBP.Size = new System.Drawing.Size(119, 36);
            this.NI_LBP.TabIndex = 21;
            this.NI_LBP.Text = "NI_LBP";
            this.NI_LBP.UseVisualStyleBackColor = true;
            this.NI_LBP.Click += new System.EventHandler(this.NI_LBP_Click);
            // 
            // btnPipeline
            // 
            this.btnPipeline.Location = new System.Drawing.Point(170, 12);
            this.btnPipeline.Name = "btnPipeline";
            this.btnPipeline.Size = new System.Drawing.Size(192, 46);
            this.btnPipeline.TabIndex = 22;
            this.btnPipeline.Text = "Classify with Pipeline1";
            this.btnPipeline.UseVisualStyleBackColor = true;
            this.btnPipeline.Click += new System.EventHandler(this.btnPipeline_Click);
            // 
            // btnPipeline2
            // 
            this.btnPipeline2.Location = new System.Drawing.Point(410, 12);
            this.btnPipeline2.Name = "btnPipeline2";
            this.btnPipeline2.Size = new System.Drawing.Size(192, 46);
            this.btnPipeline2.TabIndex = 23;
            this.btnPipeline2.Text = "Classify with Pipeline2";
            this.btnPipeline2.UseVisualStyleBackColor = true;
            this.btnPipeline2.Click += new System.EventHandler(this.btnPipeline2_Click);
            // 
            // btnPipeline3
            // 
            this.btnPipeline3.Location = new System.Drawing.Point(661, 12);
            this.btnPipeline3.Name = "btnPipeline3";
            this.btnPipeline3.Size = new System.Drawing.Size(192, 46);
            this.btnPipeline3.TabIndex = 24;
            this.btnPipeline3.Text = "Classify with Pipeline3";
            this.btnPipeline3.UseVisualStyleBackColor = true;
            this.btnPipeline3.Click += new System.EventHandler(this.btnPipeline3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Get The image:";
            this.label1.Visible = false;
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Location = new System.Drawing.Point(1110, 19);
            this.btnChooseImage.Margin = new System.Windows.Forms.Padding(1);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(114, 39);
            this.btnChooseImage.TabIndex = 0;
            this.btnChooseImage.Text = "OpenImage";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(901, 12);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(192, 46);
            this.btnTrain.TabIndex = 25;
            this.btnTrain.Text = "Add Point";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1110, 267);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 36);
            this.button2.TabIndex = 16;
            this.button2.Text = "Soften Via Circular Filter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1961, 884);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnPipeline3);
            this.Controls.Add(this.btnPipeline2);
            this.Controls.Add(this.btnPipeline);
            this.Controls.Add(this.NI_LBP);
            this.Controls.Add(this.GradientTest);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnADLBP);
            this.Controls.Add(this.btnLBP);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnGetFaceViaLibrary);
            this.Controls.Add(this.btnGreyScalar);
            this.Controls.Add(this.FillPatches);
            this.Controls.Add(this.GetDetectedFace);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btnChooseImage);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "PreProccessing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button GetDetectedFace;
        private System.Windows.Forms.Button FillPatches;
        private System.Windows.Forms.Button btnGreyScalar;
        private System.Windows.Forms.Button btnGetFaceViaLibrary;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnLBP;
        private System.Windows.Forms.Button btnADLBP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button GradientTest;
        private System.Windows.Forms.Button NI_LBP;
        private System.Windows.Forms.Button btnPipeline;
        private System.Windows.Forms.Button btnPipeline2;
        private System.Windows.Forms.Button btnPipeline3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button button2;
    }
}

