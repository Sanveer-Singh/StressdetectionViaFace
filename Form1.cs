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
using StressdetectionViaFace.LBPvariants;
using StressdetectionViaFace.utilities;
using StressdetectionViaFace.Segmentation;

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

        // histograms
        string histogram1a = null;
        string histogram1b = "0:0;1:5452;2:9880;3:10321;4:62480;5:1020;6:1780;7:873;8:391;9:275;10:1264;11:1645;12:173;13:2455;14:86;15:125;16:77;17:621;18:218;19:60;20:50;21:75;22:1577;23:465;24:82;25:193;26:130;27:15;28:14;29:6;30:13;31:11;32:83;33:83;34:119;35:24;36:11;37:6;38:34;39:18;40:14;41:37;42:28;43:41;44:13;45:1012;46:40;47:53;48:40;49:1981;50:78;51:61;52:21;53:20;54:2499;55:349;56:33;57:234;58:81;59:24;60:8;61:9;62:21;63:26;64:161;65:102;66:58;67:20;68:26;69:55;70:595;71:244;72:29;73:39;74:133;75:17;76:11;77:8;78:104;79:94;80:26;81:53;82:123;83:52;84:19;85:72;86:133;87:42;88:40;89:21;90:25;91:22;92:26;93:41;94:47;95:123;96:1036;97:103;98:3;99:49;100:5;101:6;102:10;103:58;104:12;105:15;106:50;107:22;108:8;109:106;110:27;111:37;112:11;113:2090;114:38;115:37;116:10;117:17;118:12;119:23;120:19;121:922;122:37;123:36;124:8;125:31;126:8;127:44;128:57;129:55;130:4;131:36;132:2;133:48;134:0;135:55;136:6;137:68;138:24;139:11;140:4;141:4;142:8;143:31;144:21;145:0;146:0;147:0;148:0;149:5;150:0;151:6;152:0;153:0;154:1;155:3;156:0;157:5;158:5;159:26;160:10;161:243;162:3;163:59;164:1;165:53;166:4;167:199;168:5;169:13;170:40;171:6;172:4;173:1;174:0;175:11;176:8;177:0;178:0;179:1;180:2;181:7;182:2;183:12;184:3;185:9;186:3;187:6;188:1;189:18;190:6;191:29;192:61;193:3;194:0;195:44;196:8;197:21;198:3;199:80;200:0;201:0;202:0;203:0;204:2;205:0;206:1;207:1;208:0;209:0;210:1;211:8;212:5;213:2;214:3;215:1;216:0;217:6;218:0;219:10;220:0;221:4;222:1;223:13;224:7;225:8;226:8;227:67;228:2;229:35;230:5;231:52;232:1;233:4;234:6;235:4;236:3;237:12;238:7;239:10;240:6;241:326;242:34;243:77;244:3;245:1;246:10;247:35;248:11;249:2358;250:44;251:26;252:4;253:6;254:14;255:17;";
        string histogram2a = null;
        string histogram3a = null;
        string histogram2b ="0:26;1:27;2:28;3:148;4:617;5:1046;6:68;7:6550;8:483;9:7;10:360;11:7052;12:1196;13:196;14:258;15:8452;16:0;17:0;18:1;19:0;20:1230;21:4057;22:0;23:2789;24:2;25:0;26:0;27:2;28:139;29:55;30:9;31:485;32:23;33:5;34:0;35:4;36:0;37:0;38:0;39:1;40:3;41:0;42:1;43:5;44:0;45:0;46:0;47:1;48:13;49:1;50:0;51:1;52:3824;53:2980;54:0;55:1420;56:4;57:0;58:0;59:5;60:240;61:102;62:4;63:477;64:0;65:0;66:0;67:0;68:0;69:0;70:0;71:7;72:324;73:0;74:897;75:6755;76:142;77:5;78:82;79:893;80:0;81:0;82:0;83:0;84:0;85:0;86:0;87:0;88:0;89:0;90:0;91:0;92:4;93:2;94:0;95:8;96:17;97:3;98:0;99:1;100:1;101:0;102:0;103:5;104:953;105:1;106:2778;107:4428;108:179;109:10;110:99;111:902;112:40;113:0;114:0;115:2;116:6370;117:1382;118:1;119:1036;120:7089;121:2;122:2521;123:2630;124:9211;125:674;126:775;127:26478;128:0;129:0;130:0;131:0;132:0;133:0;134:0;135:0;136:0;137:0;138:0;139:0;140:0;141:0;142:0;143:0;144:0;145:0;146:0;147:0;148:0;149:0;150:0;151:0;152:0;153:0;154:0;155:0;156:0;157:0;158:0;159:0;160:0;161:0;162:0;163:0;164:0;165:0;166:0;167:0;168:0;169:0;170:0;171:0;172:0;173:0;174:0;175:0;176:0;177:0;178:0;179:0;180:0;181:0;182:0;183:0;184:0;185:0;186:0;187:0;188:0;189:0;190:0;191:0;192:0;193:0;194:0;195:0;196:0;197:0;198:0;199:0;200:0;201:0;202:0;203:0;204:0;205:0;206:0;207:0;208:0;209:0;210:0;211:0;212:0;213:0;214:0;215:0;216:0;217:0;218:0;219:0;220:0;221:0;222:0;223:0;224:0;225:0;226:0;227:0;228:0;229:0;230:0;231:0;232:0;233:0;234:0;235:0;236:0;237:0;238:0;239:0;240:0;241:0;242:0;243:0;244:0;245:0;246:0;247:0;248:0;249:0;250:0;251:0;252:0;253:0;254:0;255:0;";
        string histogram3b = "0:3;1:8572;2:14830;3:9130;4:60230;5:1678;6:2267;7:724;8:104;9:117;10:1512;11:1490;12:62;13:2339;14:77;15:52;16:8;17:290;18:60;19:38;20:36;21:43;22:1913;23:242;24:42;25:135;26:36;27:18;28:10;29:14;30:10;31:3;32:24;33:5;34:9;35:3;36:1;37:2;38:5;39:3;40:2;41:35;42:12;43:18;44:8;45:718;46:18;47:15;48:28;49:1683;50:16;51:15;52:6;53:7;54:2056;55:311;56:11;57:97;58:36;59:12;60:3;61:7;62:4;63:2;64:11;65:10;66:6;67:4;68:1;69:1;70:317;71:90;72:9;73:32;74:40;75:7;76:3;77:3;78:97;79:40;80:35;81:16;82:62;83:30;84:44;85:68;86:28;87:36;88:28;89:10;90:5;91:9;92:17;93:26;94:44;95:172;96:1142;97:4;98:2;99:6;100:2;101:2;102:0;103:12;104:0;105:3;106:2;107:4;108:2;109:28;110:3;111:9;112:7;113:1851;114:12;115:11;116:2;117:3;118:1;119:1;120:4;121:989;122:16;123:4;124:5;125:0;126:1;127:0;128:14;129:0;130:0;131:6;132:0;133:4;134:1;135:3;136:0;137:25;138:13;139:12;140:5;141:1;142:2;143:1;144:8;145:0;146:0;147:0;148:0;149:0;150:0;151:1;152:0;153:0;154:0;155:0;156:0;157:0;158:0;159:11;160:0;161:0;162:7;163:0;164:0;165:6;166:3;167:22;168:0;169:1;170:1;171:3;172:2;173:0;174:1;175:0;176:6;177:0;178:0;179:1;180:1;181:2;182:1;183:0;184:0;185:0;186:10;187:2;188:1;189:5;190:1;191:5;192:15;193:1;194:1;195:4;196:0;197:0;198:0;199:89;200:0;201:0;202:3;203:2;204:0;205:0;206:1;207:3;208:0;209:2;210:10;211:9;212:4;213:1;214:2;215:2;216:6;217:2;218:3;219:10;220:1;221:3;222:4;223:16;224:0;225:3;226:3;227:25;228:2;229:6;230:3;231:12;232:0;233:1;234:1;235:0;236:1;237:6;238:2;239:4;240:1;241:144;242:5;243:37;244:1;245:0;246:1;247:19;248:1;249:3720;250:16;251:12;252:5;253:0;254:0;255:5;";




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
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

        private void btnAMLBP_Click(object sender, EventArgs e)
        {
          
            AMLBP lbp = new AMLBP(original, 3);
            List<SanDictionaryItem > histogram = lbp.GetHistogram ();
            string temp = "";
            foreach (SanDictionaryItem  i in histogram )
            {
                temp += i.ToString();
            }
            MessageBox.Show(temp, "histogram");
            textBox1.Text = temp;
            Size sz = new Size(original.Width, original.Height);
            Image img = new Bitmap(lbp.GetPic());
            picBox.Image = new Bitmap(img, sz);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLBP_Click(object sender, EventArgs e)
        {
            LBP lbp = new LBP(original);
            List<SanDictionaryItem> histogram = lbp.GetHistogram();
            string temp = "";
            foreach (SanDictionaryItem i in histogram)
            {
                temp += i.ToString() ;
            }
            textBox1.Text = temp;
            MessageBox.Show(temp, "histogram");
            Size sz = new Size(original.Width, original.Height);
            Image img = new Bitmap(lbp.GetPic());
            picBox.Image = new Bitmap(img, sz);

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
            if(histogram1a is null)
            {

            }
            if (histogram2a is null)
            {

            }
            if (histogram3a is null)
            {

            }
        }
    }
}
