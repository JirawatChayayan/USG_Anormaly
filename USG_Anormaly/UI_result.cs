using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USG_Anormaly_lib;

namespace USG_Anormaly
{
    public partial class UI_result : UserControl
    {
        public UI_result()
        {
            InitializeComponent();
        }

        public void reset()
        {
            lb_class.Text = "-";
            lb_imageSize.Text = "-";
            lb_score.Text = "-";
            lb_class.BackColor = SystemColors.Control;
            lb_processTime.Text = "-";
        }
        public void disp(DL_InferenceResult result,double processtime)
        {
            try
            {
                lb_class.Text = result.anormalyClass;
                lb_score.Text = result.anormalyScore.ToString("0.000");
                lb_imageSize.Text = $"{result.trainingImgSize.Width} X {result.trainingImgSize.Height}";
                if(lb_class.Text == "nok")
                {
                    lb_class.BackColor = Color.IndianRed;
                }
                else
                {
                    lb_class.BackColor = Color.LightGreen;
                }
                lb_processTime.Text = processtime.ToString("0.000")+ " ms";

            }
            catch (Exception ex)
            {
                reset();
            }

        }
    }
}
