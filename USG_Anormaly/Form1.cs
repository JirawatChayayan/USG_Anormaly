using HalconDotNet;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace USG_Anormaly
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += Form1_MouseWheel;
            uI_Anormaly_System1.OnSelectedImageTraining += UI_Anormaly_System1_OnSelectedImageTraining;
        }

        private void UI_Anormaly_System1_OnSelectedImageTraining(USG_Anormaly_lib.CameraIdx idx, HObject imgSelect)
        {
            hs_windowsOther.HalconWindow.DispObj(imgSelect);
            hs_windowsOther.SetFullImagePart();
            imgSelect.Dispose();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            Point pt1 = hs_imgFront.Location;
            Size size = hs_imgFront.Size;
            //Point pt2 = hs_imgSide.Location;
            int x1 = pt1.X;
            int y1 = pt1.Y;
            int x2 = pt1.X + size.Width;
            int y2 = pt1.Y + size.Height;
            if ((e.X >= x1 && e.X <= x2) && (e.Y >= y1 && e.Y <= y2))
            {
                MouseEventArgs newe = new MouseEventArgs(e.Button,
                                         e.Clicks,
                                         e.X - pt1.X,
                                         e.Y - pt1.Y,
                                         e.Delta);
                hs_imgFront.HSmartWindowControl_MouseWheel(sender, newe);
                return;
            }

            Point pt2 = hs_imgSide.Location;
            Size size2 = hs_imgSide.Size;
            int x1_2 = pt2.X;
            int y1_2 = pt2.Y;
            int x2_2 = pt2.X + size2.Width;
            int y2_2 = pt2.Y + size2.Height;
            if ((e.X >= x1_2 && e.X <= x2_2) && (e.Y >= y1_2 && e.Y <= y2_2))
            {
                MouseEventArgs newe = new MouseEventArgs(e.Button,
                                         e.Clicks,
                                         e.X - pt2.X,
                                         e.Y - pt2.Y,
                                         e.Delta);
                hs_imgSide.HSmartWindowControl_MouseWheel(sender, newe);
                return;
            }

            Point pt3 = hs_windowsOther.Location;
            Size size3 = hs_windowsOther.Size;
            int x1_3 = pt3.X;
            int y1_3 = pt3.Y;
            int x2_3 = pt3.X + size3.Width;
            int y2_3 = pt3.Y + size3.Height;
            if ((e.X >= x1_3 && e.X <= x2_3) && (e.Y >= y1_3 && e.Y <= y2_3))
            {
                MouseEventArgs newe = new MouseEventArgs(e.Button,
                                         e.Clicks,
                                         e.X - pt3.X,
                                         e.Y - pt3.Y,
                                         e.Delta);
                hs_windowsOther.HSmartWindowControl_MouseWheel(sender, newe);
                return;
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            uI_Anormaly_System1.enableCamera();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            uI_Anormaly_System1.disableCamera();
        }

        bool onlive = false;
        string liveCamera = "";
        Button btLive;
        private void bt_live_click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if(onlive)
            {
                StopLive();
            }
            else
            {
                timer_live.Enabled = true;
                timer_live.Start();
                onlive=true;
                liveCamera = bt.Text;
                bt.BackColor = Color.Red;
                bt.ForeColor = Color.White;
                btLive = bt;
            }
        }

        private void StopLive()
        {
            timer_live.Enabled = false;
            timer_live.Stop();
            onlive = false;
            liveCamera = "";
            try
            {
                btLive.UseVisualStyleBackColor = true;
                btLive.ForeColor = Color.Black;
                btLive = null;
            }
            catch(Exception ex)
            {

            }
        }

        private void timer_live_Tick(object sender, EventArgs e)
        {
            timer_live.Stop();
            if (!onlive)
            {
               StopLive();
                return;
            }
                
            try
            {
                if (liveCamera == bt_LiveFront.Text)
                {
                    HObject img = uI_Anormaly_System1.grabImageFront();
                    hs_imgFront.HalconWindow.DispObj(img);
                    img.Dispose();

                }
                else if (liveCamera == bt_LiveSide.Text)
                {
                    HObject img = uI_Anormaly_System1.grabImageSide();
                    hs_imgSide.HalconWindow.DispObj(img);
                    img.Dispose();
                }
                else if (liveCamera == bt_LiveAll.Text)
                {
                    var imgs = uI_Anormaly_System1.grab2Image();
                    hs_imgFront.HalconWindow.DispObj(imgs.ImageFront);
                    hs_imgSide.HalconWindow.DispObj(imgs.ImageSide);
                    imgs.ImageSide.Dispose();
                    imgs.ImageFront.Dispose();
                }
                else
                {
                    timer_live.Enabled = false;
                    timer_live.Stop();
                    onlive = false;
                    liveCamera = "";

                    btLive.UseVisualStyleBackColor = true;
                    btLive.ForeColor = Color.Black;
                    btLive = null;
                    return;
                }
                timer_live.Start();
            }
            catch (Exception ex)
            {
                StopLive();
            }

        }

        private void hs_imgFront_HMouseDoubleClick(object sender, HMouseEventArgs e)
        {
            hs_imgFront.SetFullImagePart();
        }

        private void hs_imgSide_HMouseDoubleClick(object sender, HMouseEventArgs e)
        {
            hs_imgSide.SetFullImagePart();
        }

        private void bt_grabImg(object sender, EventArgs e)
        {
            StopLive();
            Button bt = (Button)sender;
            try
            {
                if (bt.Text == bt_grabFront.Text)
                {
                    HObject img = uI_Anormaly_System1.grabImageFront();
                    hs_imgFront.HalconWindow.DispObj(img);
                    img.Dispose();

                }
                else if (bt.Text == bt_grabSide.Text)
                {
                    HObject img = uI_Anormaly_System1.grabImageSide();
                    hs_imgSide.HalconWindow.DispObj(img);
                    img.Dispose();
                }
                else if (bt.Text == bt_grabAll.Text)
                {
                    var imgs = uI_Anormaly_System1.grab2Image();
                    hs_imgFront.HalconWindow.DispObj(imgs.ImageFront);
                    hs_imgSide.HalconWindow.DispObj(imgs.ImageSide);
                    imgs.ImageSide.Dispose();
                    imgs.ImageFront.Dispose();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void uI_Anormaly_System1_Load(object sender, EventArgs e)
        {

        }
    }
}
