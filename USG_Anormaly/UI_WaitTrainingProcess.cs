using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USG_Anormaly
{
    public partial class UI_WaitTrainingProcess : UserControl
    {
        public UI_WaitTrainingProcess()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        float RotationAngle1 = 90F;
        float RotationAngle2 = 0F;
        bool RotateFigures = false;
        System.Windows.Forms.Timer RotateTimer = null;


        int i_count = 1;
        private void RotateTick(object sender, EventArgs e)
        {
            RotationAngle1 += 10F;
            RotationAngle2 += 10F;
            transparentPanel1.Invalidate();
            transparentPanel2.Invalidate();
            i_count++;
            if(i_count == 10)
            {
                i_count = 0;
                timerdevided();
            }

        }
        int i = 0;
        private void timerdevided()
        {
            if (setAnimation)
            {
                if (msgAnimation == "")
                {
                    i = 0;
                    return;
                }

                if (i == 0)
                {
                    txt_status.Text = msgAnimation;
                    i += 1;
                }
                else if (i == 1)
                {
                    txt_status.Text = $"{msgAnimation} .";
                    i += 1;
                }
                else if (i == 2)
                {
                    txt_status.Text = $"{msgAnimation} . .";
                    i += 1;
                }
                else if (i == 3)
                {
                    txt_status.Text = $"{msgAnimation} . . .";
                    i = 0;
                }
            }
        }

        private void transparentPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (!RotateFigures) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            Rectangle rect = transparentPanel1.ClientRectangle;
            Rectangle rectInner = rect;

            using (Pen transpPen = new Pen(transparentPanel1.Parent.BackColor, 10))
            using (Pen penOuter = new Pen(Color.SteelBlue, 8))
            using (Pen penInner = new Pen(Color.Teal, 8))
            using (Matrix m1 = new Matrix())
            using (Matrix m2 = new Matrix())
            {
                m1.RotateAt(-RotationAngle1, new PointF(rect.Width / 2, rect.Height / 2));
                m2.RotateAt(RotationAngle1, new PointF(rect.Width / 2, rect.Height / 2));
                rect.Inflate(-(int)penOuter.Width, -(int)penOuter.Width);
                rectInner.Inflate(-(int)penOuter.Width * 3, -(int)penOuter.Width * 3);

                e.Graphics.Transform = m1;
                e.Graphics.DrawArc(transpPen, rect, -4, 94);
                e.Graphics.DrawArc(penOuter, rect, -90, 90);
                e.Graphics.ResetTransform();
                e.Graphics.Transform = m2;
                e.Graphics.DrawArc(transpPen, rectInner, 190, 100);
                e.Graphics.DrawArc(penInner, rectInner, 180, 90);
            }
        }
        private void transparentPanel2_Paint(object sender, PaintEventArgs e)
        {
            if (!RotateFigures) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            Rectangle rect = transparentPanel2.ClientRectangle;
            Rectangle rectInner = rect;

            using (Pen transpPen = new Pen(transparentPanel2.Parent.BackColor, 10))
            using (Pen penOuter = new Pen(Color.Orange, 8))
            using (Pen penInner = new Pen(Color.DarkRed, 8))
            using (Matrix m1 = new Matrix())
            using (Matrix m2 = new Matrix())
            {
                m1.RotateAt(RotationAngle2, new PointF(rect.Width / 2, rect.Height / 2));
                m2.RotateAt(-RotationAngle2, new PointF(rect.Width / 2, rect.Height / 2));
                rect.Inflate(-(int)penOuter.Width, -(int)penOuter.Width);
                rectInner.Inflate(-(int)penOuter.Width * 3, -(int)penOuter.Width * 3);

                e.Graphics.Transform = m1;
                e.Graphics.DrawArc(transpPen, rect, -4, 94);
                e.Graphics.DrawArc(penOuter, rect, 0, 90);
                e.Graphics.ResetTransform();
                e.Graphics.Transform = m2;
                e.Graphics.DrawArc(transpPen, rectInner, 190, 100);
                e.Graphics.DrawArc(penInner, rectInner, 180, 90);
            }
        }
        public void startProgressBar()
        {
            RotateFigures = true;
            RotateTimer = new System.Windows.Forms.Timer();
            RotateTimer.Interval = 25;
            RotateTimer.Enabled = false;
            RotateTimer.Tick += new EventHandler(this.RotateTick);
            RotateTimer.Start();
        }
        public void stopProgressBar()
        {
            RotationAngle1 += 90F;
            RotationAngle2 += 0F;
            RotateTimer.Stop();
            RotateTimer.Enabled = false;

            //transparentPanel1.Invalidate();
            //transparentPanel2.Invalidate();
            RotateFigures = false;
            //RotationAngle1 = 90F;
            //RotationAngle2 = 0F;
            
        }
        bool setAnimation = false;
        string msgAnimation = "";
        public void setText(string msg)
        {
            msgAnimation = "";
            setAnimation = false;
            i = 0;
            string message = msg.Trim();
            string[] msgSplit = message.Split(' ');
            if (msgSplit[1] == "Uploading")
            {
                setAnimation = true;
                msgAnimation = msgSplit[0] + " "+ msgSplit[1];
            }
            else
            {
                txt_status.Text = message;
            }


        }

    }
}
