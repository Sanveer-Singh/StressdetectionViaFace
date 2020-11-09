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
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.GetDetectedFace = new System.Windows.Forms.Button();
            this.FillPatches = new System.Windows.Forms.Button();
            this.btnGetFace = new System.Windows.Forms.Button();
            this.btnGreyScalar = new System.Windows.Forms.Button();
            this.btnGetFaceViaLibrary = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnAMLBP = new System.Windows.Forms.Button();
            this.btnLBP = new System.Windows.Forms.Button();
            this.btnADLBP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Location = new System.Drawing.Point(82, 168);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(305, 93);
            this.btnChooseImage.TabIndex = 0;
            this.btnChooseImage.Text = "OpenImage";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(690, 168);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(1683, 1114);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // GetDetectedFace
            // 
            this.GetDetectedFace.Location = new System.Drawing.Point(82, 328);
            this.GetDetectedFace.Name = "GetDetectedFace";
            this.GetDetectedFace.Size = new System.Drawing.Size(305, 95);
            this.GetDetectedFace.TabIndex = 2;
            this.GetDetectedFace.Text = "Show skin detected";
            this.GetDetectedFace.UseVisualStyleBackColor = true;
            this.GetDetectedFace.Click += new System.EventHandler(this.GetDetectedFace_Click);
            // 
            // FillPatches
            // 
            this.FillPatches.Location = new System.Drawing.Point(82, 443);
            this.FillPatches.Name = "FillPatches";
            this.FillPatches.Size = new System.Drawing.Size(305, 98);
            this.FillPatches.TabIndex = 3;
            this.FillPatches.Text = "Fill patches";
            this.FillPatches.UseVisualStyleBackColor = true;
            this.FillPatches.Click += new System.EventHandler(this.FillPatches_Click);
            // 
            // btnGetFace
            // 
            this.btnGetFace.Location = new System.Drawing.Point(82, 810);
            this.btnGetFace.Name = "btnGetFace";
            this.btnGetFace.Size = new System.Drawing.Size(305, 112);
            this.btnGetFace.TabIndex = 4;
            this.btnGetFace.Text = "Display face only*";
            this.btnGetFace.UseVisualStyleBackColor = true;
            this.btnGetFace.Click += new System.EventHandler(this.btnGetFace_Click);
            // 
            // btnGreyScalar
            // 
            this.btnGreyScalar.Location = new System.Drawing.Point(82, 575);
            this.btnGreyScalar.Name = "btnGreyScalar";
            this.btnGreyScalar.Size = new System.Drawing.Size(305, 111);
            this.btnGreyScalar.TabIndex = 5;
            this.btnGreyScalar.Text = "Apply greyscaling";
            this.btnGreyScalar.UseVisualStyleBackColor = true;
            this.btnGreyScalar.Click += new System.EventHandler(this.btnGreyScalar_Click);
            // 
            // btnGetFaceViaLibrary
            // 
            this.btnGetFaceViaLibrary.Location = new System.Drawing.Point(2456, 168);
            this.btnGetFaceViaLibrary.Name = "btnGetFaceViaLibrary";
            this.btnGetFaceViaLibrary.Size = new System.Drawing.Size(303, 117);
            this.btnGetFaceViaLibrary.TabIndex = 6;
            this.btnGetFaceViaLibrary.Text = "Get Face With library";
            this.btnGetFaceViaLibrary.UseVisualStyleBackColor = true;
            this.btnGetFaceViaLibrary.Click += new System.EventHandler(this.btnGetFaceViaLibrary_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(82, 1047);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(305, 106);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Soften The Image via square mean filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnAMLBP
            // 
            this.btnAMLBP.Location = new System.Drawing.Point(75, 1322);
            this.btnAMLBP.Name = "btnAMLBP";
            this.btnAMLBP.Size = new System.Drawing.Size(305, 94);
            this.btnAMLBP.TabIndex = 8;
            this.btnAMLBP.Text = "Get AMLBP histogram";
            this.btnAMLBP.UseVisualStyleBackColor = true;
            this.btnAMLBP.Click += new System.EventHandler(this.btnAMLBP_Click);
            // 
            // btnLBP
            // 
            this.btnLBP.Location = new System.Drawing.Point(75, 1475);
            this.btnLBP.Name = "btnLBP";
            this.btnLBP.Size = new System.Drawing.Size(305, 77);
            this.btnLBP.TabIndex = 10;
            this.btnLBP.Text = "Get LBP histogram";
            this.btnLBP.UseVisualStyleBackColor = true;
            this.btnLBP.Click += new System.EventHandler(this.btnLBP_Click);
            // 
            // btnADLBP
            // 
            this.btnADLBP.Location = new System.Drawing.Point(75, 1586);
            this.btnADLBP.Name = "btnADLBP";
            this.btnADLBP.Size = new System.Drawing.Size(305, 86);
            this.btnADLBP.TabIndex = 11;
            this.btnADLBP.Text = "Get ADLBP histogram";
            this.btnADLBP.UseVisualStyleBackColor = true;
            this.btnADLBP.Click += new System.EventHandler(this.btnADLBP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Get The image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "Localization By Hand:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2434, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 32);
            this.label3.TabIndex = 14;
            this.label3.Text = "Localization Via library";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 995);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(321, 32);
            this.label4.TabIndex = 15;
            this.label4.Text = "Pre Processing Options:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(82, 1185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(302, 86);
            this.button2.TabIndex = 16;
            this.button2.Text = "Soften Via Circular Filter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // picBox2
            // 
            this.picBox2.Location = new System.Drawing.Point(2543, 401);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(721, 483);
            this.picBox2.TabIndex = 18;
            this.picBox2.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 1699);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(900, 375);
            this.textBox1.TabIndex = 19;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(2991, 1165);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 934);
            this.vScrollBar1.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 1596);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 76);
            this.button1.TabIndex = 22;
            this.button1.Text = "Classify";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3271, 2108);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.picBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnADLBP);
            this.Controls.Add(this.btnLBP);
            this.Controls.Add(this.btnAMLBP);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnGetFaceViaLibrary);
            this.Controls.Add(this.btnGreyScalar);
            this.Controls.Add(this.btnGetFace);
            this.Controls.Add(this.FillPatches);
            this.Controls.Add(this.GetDetectedFace);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btnChooseImage);
            this.Name = "Form1";
            this.Text = "PreProccessing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button GetDetectedFace;
        private System.Windows.Forms.Button FillPatches;
        private System.Windows.Forms.Button btnGetFace;
        private System.Windows.Forms.Button btnGreyScalar;
        private System.Windows.Forms.Button btnGetFaceViaLibrary;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnAMLBP;
        private System.Windows.Forms.Button btnLBP;
        private System.Windows.Forms.Button btnADLBP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button button1;
    }
}

