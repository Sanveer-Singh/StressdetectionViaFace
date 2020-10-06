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
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.GetDetectedFace = new System.Windows.Forms.Button();
            this.FillPatches = new System.Windows.Forms.Button();
            this.btnGetFace = new System.Windows.Forms.Button();
            this.btnGreyScalar = new System.Windows.Forms.Button();
            this.btnGetFaceViaLibrary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
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
            this.FillPatches.Location = new System.Drawing.Point(82, 494);
            this.FillPatches.Name = "FillPatches";
            this.FillPatches.Size = new System.Drawing.Size(305, 98);
            this.FillPatches.TabIndex = 3;
            this.FillPatches.Text = "Fill patches";
            this.FillPatches.UseVisualStyleBackColor = true;
            this.FillPatches.Click += new System.EventHandler(this.FillPatches_Click);
            // 
            // btnGetFace
            // 
            this.btnGetFace.Location = new System.Drawing.Point(82, 852);
            this.btnGetFace.Name = "btnGetFace";
            this.btnGetFace.Size = new System.Drawing.Size(305, 112);
            this.btnGetFace.TabIndex = 4;
            this.btnGetFace.Text = "Display face only";
            this.btnGetFace.UseVisualStyleBackColor = true;
            this.btnGetFace.Click += new System.EventHandler(this.btnGetFace_Click);
            // 
            // btnGreyScalar
            // 
            this.btnGreyScalar.Location = new System.Drawing.Point(82, 649);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2918, 1327);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button GetDetectedFace;
        private System.Windows.Forms.Button FillPatches;
        private System.Windows.Forms.Button btnGetFace;
        private System.Windows.Forms.Button btnGreyScalar;
        private System.Windows.Forms.Button btnGetFaceViaLibrary;
    }
}

