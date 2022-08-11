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

namespace USG_Anormaly
{
    public partial class UI_ImageDisplay : UserControl
    {
        public UI_ImageDisplay()
        {
            InitializeComponent();
        }
        public string frontImg { get; set; }
        public string side1Img { get; set; }
        public string side2Img { get; set; }

        public void setDispImg(string front,string side1,string side2)
        {
            frontImg = front;
            side1Img = side1;
            side2Img = side2;
            try
            {
                pictureBox1.Image = Base64ToImage(frontImg);
            }
            catch
            {
                pictureBox1.Image = pictureBox1.ErrorImage;
            }

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

        private void bt_displayIme(object sender, EventArgs e)
        {
            try
            {
                Button bt = (Button)sender;
                if(bt.Name == bt_Front.Name)
                {
                    pictureBox1.Image = Base64ToImage(frontImg);
                }
                else if(bt.Name == bt_Side1.Name)
                {
                    pictureBox1.Image = Base64ToImage(side1Img);
                }
                else
                {
                    pictureBox1.Image=Base64ToImage(side2Img);
                }
            }
            catch (Exception ex)
            {
                pictureBox1.Image = pictureBox1.ErrorImage;
            }
        }
    }
}
