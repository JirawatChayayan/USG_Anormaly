using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USG_Anormaly
{
    public partial class UI_testingProgressBar : UserControl
    {
        public UI_testingProgressBar()
        {
            InitializeComponent();
        }

        Image blueImg = global::USG_Anormaly.Properties.Resources.MicrosoftTeams_image__20_;
        Image grayImg = global::USG_Anormaly.Properties.Resources.MicrosoftTeams_image__19_;
        Image blueblueImg = global::USG_Anormaly.Properties.Resources.MicrosoftTeams_image__21_;

        public PictureBox[] pictureBoxes
        {
            get
            {
                return new PictureBox[] { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8, pb9, pb10 };
            }
        }

        public void start()
        {
            resetUI();
            timer_trigerProgress.Enabled = true;
            timer_trigerProgress.Start();
        }
        public void stop()
        {
            resetUI();
            timer_trigerProgress.Stop();
            timer_trigerProgress.Enabled = false;
        }
        public void resetUI()
        {
            foreach(PictureBox pb in pictureBoxes)
            {
                if (pb.Tag.ToString() == "1")
                {
                    pb.Image = grayImg;
                    pb.Tag = 0;
                }
            }
        }
        int counter = 0;
        public void display()
        {
            resetUI();
            PictureBox pb = pictureBoxes[counter];
            pb.Image = blueblueImg;
            pb.Tag = 1;
            counter++;
            //PictureBox pb2 = pictureBoxes[counter];
            //pb2.Image = blueImg;
            //pb2.Tag = 1;
            //counter++;
            if (counter > 9)
            {
                counter = 0;
            }
        }
        private void timer_trigerProgress_Tick(object sender, EventArgs e)
        {
            display();
        }
    }
}
