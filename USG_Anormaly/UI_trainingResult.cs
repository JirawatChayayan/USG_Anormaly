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
    public partial class UI_trainingResult : UserControl
    {
        public UI_trainingResult()
        {
            InitializeComponent();
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

        public void displayImg(ImageResultModel img,string label)
        {
            lb_camera.Text = label;
            dispFromStr(pb_score_histogram, img.score_histogram);
            dispFromStr(pb_confusion_matrix, img.absolute_confusion_matrix);
            dispFromStr(pb_precision, img.pie_charts_precision);
            dispFromStr(pb_score_legend, img.score_legend);
            dispFromStr(pb_recall, img.pie_charts_recall);
            if(img.anomalyThreshold != null)
            {
                if(img.anomalyThreshold.anoClassificationThreshold != null)
                {
                    label_AD_Classification_Threshold.Text = img.anomalyThreshold.anoClassificationThreshold;
                }
                if(img.anomalyThreshold.anoSegmentThreshold != null)
                {
                    label_AD_Segmentation_Threshold.Text = img.anomalyThreshold.anoSegmentThreshold;
                }
            }
        }
    }
}
