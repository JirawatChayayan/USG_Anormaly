using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using HalconDotNet;
using BitmapHImage;

namespace USG_Anormaly_lib
{
    public enum ImgFormat
    {
        jpg,
        png
    }

    public class ImageConvert
    {
        public string pathImg2Base64str(string path, ImgFormat format = ImgFormat.jpg)
        {
            string dataImage = format == ImgFormat.jpg ? "data:image/jpeg;base64," : "data:image/png;base64,"; //data: image /{ }; base64,{ }
            return image2Base64str(Image.FromFile(path), format);
        }
        public string image2Base64str(Image img, ImgFormat format = ImgFormat.jpg)
        {
            string dataImage = format == ImgFormat.jpg ? "data:image/jpeg;base64," : "data:image/png;base64,"; //data: image /{ }; base64,{ }
            return dataImage + Convert.ToBase64String(imgToByteArray(img, format));
        }
        public byte[] imgToByteArray(Image img, ImgFormat format = ImgFormat.jpg)
        {
            using (MemoryStream mStream = new MemoryStream())
            {

                img.Save(mStream, format == ImgFormat.jpg ? ImageFormat.Jpeg : ImageFormat.Png);
                return mStream.ToArray();
            }
        }
        public string byteToBase64str(Bitmap btm, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                btm.Save(ms, format);
                byte[] byteImage = ms.ToArray();
                string base64str = Convert.ToBase64String(byteImage);
                string dataImage = format == ImageFormat.Jpeg ? "data:image/jpeg;base64," : "data:image/png;base64,";
                return dataImage + base64str;
            }
        }
        public HObject strbase64toHalconImage(string b64Imgstr)
        {
            var splitImg = b64Imgstr.Split(',');
            string imgStr = "";
            if (splitImg.Length >= 2)
            {
                imgStr = splitImg[1];
            }
            else
            {
                imgStr = b64Imgstr;
            }
            var byteArrScn = Convert.FromBase64String(imgStr);

            HObject img = null;
            using (MemoryStream ms = new MemoryStream(byteArrScn))
            {
                var image = Image.FromStream(ms);
                img = new HObject((new BitmapHImageConverter()).Bitmap2HImage((Bitmap)image));
            }
            return img;
        }
        public Image strbase64toImage(string b64Imgstr)
        {
            var splitImg = b64Imgstr.Split(',');
            string imgStr = "";
            if(splitImg.Length >=2)
            {
                imgStr = splitImg[1];
            }
            else
            {
                imgStr = b64Imgstr;
            }
            var byteArrScn = Convert.FromBase64String(imgStr);

            Image img;
            using (MemoryStream ms = new MemoryStream(byteArrScn))
            {
                img = Image.FromStream(ms);
            }
            return img;
        }

        public string halconImageTobase64(HObject img, ImgFormat format)
        {
            HImage himg =  new HImage(img);
            Image imgBmp = (new BitmapHImageConverter()).HImage2Bitmap(himg);
            string imgStr = image2Base64str(imgBmp, format);
            try
            {
                imgBmp.Dispose();
                himg.Dispose();
            }
            catch
            {

            }

            return imgStr;
        }


    }
}
