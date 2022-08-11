using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USG_Anormaly_lib;

namespace USG_Anormaly
{
    public partial class frmModelDetail : Form
    {
        public frmModelDetail()
        {
            InitializeComponent();
        }
        public string recipename { get; set; }

        private void frmModelDetail_Load(object sender, EventArgs e)
        {
            this.Text = $"Model detail {recipename}";
            callData();
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String.Split(',')[1].Trim());
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }


        public void dispFromStr(PictureBox pb, string imgB64)
        {
            try
            {
                pb.Image = Base64ToImage(imgB64);
            }
            catch (Exception ex)
            {
                pb.Image = pb.ErrorImage;
            }
        }

        private void callData()
        {
            var res = (new ServerInterface()).getFinishedData(recipename,true);
            var a = new
            {
                recipename = res.recipeName,
                trainingFromMC = res.trainingFromMC,
                pretrain = res.pretrainedDL,
                generalParam = res.generalDLParam,
                hyperParam = res.hyperDLParam,
                trainingStart = res.trainingDateTime,
                trainingFinish = res.trainingFinished,
            };
            txt_trainingDetail.Text = ( Environment.NewLine + Environment.NewLine+JsonConvert.SerializeObject(a, Formatting.Indented));

            //pb_score_histogram.Image = Base64ToImage(res.resultFront.score_histogram);
            uI_trainingResult_front.displayImg(res.resultFront,"Front");
            uI_trainingResult_side1.displayImg(res.resultSide1,"Side1");
            uI_trainingResult_side2.displayImg(res.resultSide2,"Side2");

            dispFromStr(pb_sample_front, res.resultFront.sample_image);
            dispFromStr(pb_sample_side1, res.resultSide1.sample_image);
            dispFromStr(pb_sample_side2 , res.resultSide2.sample_image);
        }

        private Button[] btSelect()
        {
            return new Button[]
            {
                bt_front,
                bt_side1,
                bt_side2
            };
        }


        private void bt_click(object sender, EventArgs e)
        {

            Color ckAdtive = Color.PowderBlue;
            Button bt = (Button)sender;
            var btAll = btSelect();
            foreach(var btn in btAll)
            {
                if(btn.Name != bt.Name)
                {
                    btn.UseVisualStyleBackColor = true;
                }
                else
                {
                    btn.BackColor = ckAdtive;
                }
            }
            if(bt.Name == bt_front.Name)
            {
                uI_trainingResult_front.BringToFront();
            }
            else if(bt.Name == bt_side1.Name)
            {
                uI_trainingResult_side1.BringToFront();
            }
            else if(bt.Name == bt_side2.Name)
            {
                uI_trainingResult_side2.BringToFront();
            }
        }
    }
}
