using HalconDotNet;
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
    public delegate void SelectedImageTraining(CameraIdx idx,HObject imgSelect);
    public delegate HObject RequireCaptureImage(CameraIdx idx);
   
    public partial class UI_PretrainImage : UserControl
    {
       
        public UI_PretrainImage()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        Dictionary<string,string> images = new Dictionary<string, string>();
        public Dictionary<string, string> imageList
        {
            get { return images; }
        }
        public string mainPath = TrainingCacheFilePath.frontCachePath;
        public event SelectedImageTraining OnSelectedImageTraining;
        public event RequireCaptureImage OnRequireCaptureImage;
        public event statusDispde OnUpdateStatus;
        CameraIdx _idx = CameraIdx.Front;
        public CameraIdx CameraIdx
        {
            set
            {
                _idx = value;
                if(_idx == CameraIdx.Front)
                {
                    mainPath = TrainingCacheFilePath.frontCachePath;
                }
                else if(_idx == CameraIdx.Side)
                {
                    mainPath = TrainingCacheFilePath.sideCachePath1;
                }
                else
                {
                    mainPath = TrainingCacheFilePath.sideCachePath2;
                }
                updateList();
            }
        }
        public static List<string> GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, string.Format("*.{0}", filter), searchOption));
            }
            return filesFound;
        }

        public void updateList()
        {
            try
            {
                if (mainPath == "")
                    return;
                //var files = Directory.GetFiles(mainPath, "*.png").ToList();

                var filters = new string[] { "jpg", "jpeg", "png", "tiff", "tif", "bmp", "hobj" };
                var files = GetFilesFrom(mainPath, filters, true);

                images.Clear();
                listBox_dir.Items.Clear();
                foreach (var file in files)
                {
                    string fName = (string)Path.GetFileName(file);
                    images[fName] = file;
                    listBox_dir.Items.Add(fName);
                }
                txt_status.Text = $"ImageCount : {images.Count()}";
                dispMsg($"have img for train : {images.Count()}", LogLevel.INFO);
            }
            catch (Exception ex)
            {
                txt_status.Text = $"Not Found !!!";
                dispMsg($"{ex.Message}", LogLevel.ERROR);
            }
            
        }
        private void dispMsg(string msg,LogLevel level)
        {
            if (OnUpdateStatus != null)
            {
                string cam = "";
                if(_idx == CameraIdx.Front)
                {
                    cam = "Front";
                }
                else if(_idx == CameraIdx.Side)
                {
                    cam = "Side 1";
                }
                else if(_idx == CameraIdx.Side2)
                {
                    cam = "Side 2";
                }
                OnUpdateStatus($"{cam} camera {msg}", level);
            }
        }
        private void bt_reset_Click(object sender, EventArgs e)
        {
           
            if (images.Count == 0)
            {
                dispMsg($"no image to delete.", LogLevel.Warning);
                MessageBox.Show("No image to delete.",
                                  "Infomation !!!", MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                return;
            }
            DialogResult da = MessageBox.Show("Do you want to delete all image ?",
                                  "Warning !!!", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Warning);
            if (da == DialogResult.No)
            {
                dispMsg("cancle delete image.",LogLevel.Warning);
                return;
            }
            try
            {
                dispMsg("start delete image.", LogLevel.INFO);
                Parallel.ForEach(images, imgFile =>
                {
                    try
                    {
                        string imgName = imgFile.Value;
                        File.Delete(imgName);
                    }
                    catch
                    {

                    }
                });
                txt_status.Text = "Deleted.";
                dispMsg("delete image finished.", LogLevel.INFO);


            }
            catch (Exception ex)
            {
                txt_status.Text = "Cannot Delete";
                dispMsg($"cannot delete file : {ex.Message}", LogLevel.Warning);
                MessageBox.Show($"Cannot delete file : {ex.Message}",
                                 "Delete Image.",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
            updateList();
        }
        private void listBox_dir_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_status.Text = $"{listBox_dir.SelectedItem}";
            dispMsg($"select image {listBox_dir.SelectedItem}", LogLevel.INFO);
            if (OnSelectedImageTraining != null)
            {
                try
                {
                    string imgPath = images[listBox_dir.Text.Trim()];
                    if(File.Exists(imgPath))
                    {
                        HObject img = new HObject(); img.GenEmptyObj();
                        HOperatorSet.ReadImage(out img, imgPath);
                        OnSelectedImageTraining(_idx,img);
                    }
                    else
                    {
                        updateList();
                        
                    }
                }
                catch(Exception ex)
                {
                    txt_status.Text = "Error read img selected.";
                    dispMsg($"error to select image {listBox_dir.SelectedItem}", LogLevel.ERROR);
                }
            }
        }
        private void bt_upload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult da = dialog.ShowDialog();
            dialog.Description = "Broswer folder for upload image.";
            dispMsg($"Broswer folder for upload image.", LogLevel.INFO);
            if (da == DialogResult.Yes || da == DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                //List<string> imgPaths = Directory.GetFiles(path,"*.png",SearchOption.AllDirectories).ToList();

                var filters = new string[] { "jpg", "jpeg", "png", "tiff", "bmp","hobj" };
                List<string> imgPaths = GetFilesFrom(path, filters, true);


                if (imgPaths.Count == 0)
                {
                    dispMsg($"Not found image file", LogLevel.Warning);
                    MessageBox.Show("Not found image format (jpg,jpeg,png,tiff,bmp,hobj).", "Upload Image !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Parallel.ForEach(imgPaths, imgFile =>
                {
                    try
                    {
                        HObject img = new HObject(); img.GenEmptyObj(); img.Dispose();
                        string destPath = Path.Combine(mainPath, Path.GetFileNameWithoutExtension(imgFile)+".bmp");
                        HOperatorSet.ReadImage(out img, imgFile);
                        HOperatorSet.WriteImage(img, "bmp", 0, destPath);
                        img.Dispose();
                    }
                    catch
                    {

                    }
                });
                updateList();
            }
            else
            {
                dispMsg($"cancel", LogLevel.INFO);
            }
        }
        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (images.Count == 0)
            {
                dispMsg("no image to delete.", LogLevel.Warning);
                MessageBox.Show("No image to delete.",
                                  "Infomation !!!", MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                return;
            }
            string imgName = listBox_dir.Text;
            try
            {
                
                File.Delete(images[imgName]);
                txt_status.Text = "Deleted.";
                dispMsg($"deleted image {imgName}.", LogLevel.Warning);

            }
            catch (Exception ex)
            {
                txt_status.Text = "Cannot Delete";
                dispMsg($"cannot delete file : {imgName}.", LogLevel.ERROR);
                MessageBox.Show($"Cannot delete file : {ex.Message}",
                                 "Delete Image.",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
            updateList();
        }
        private void bt_capture_Click(object sender, EventArgs e)
        {
            if (OnRequireCaptureImage != null)
            {
                HObject img = OnRequireCaptureImage(_idx);
                if (img == null)
                {
                    txt_status.Text = "Cannot Capture";
                    dispMsg($"cannot capture image.", LogLevel.ERROR);
                    return;
                }

                Int32 second = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                Int32 millisecond = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Milliseconds;
                string destPath = Path.Combine(mainPath, $"{second}-{millisecond.ToString("000")}.bmp");
                HOperatorSet.WriteImage(img, "bmp", 0, destPath);
                dispMsg($"capture image : {Path.GetFileName(destPath)}.", LogLevel.INFO);
                updateList();
                //img.Dispose();
                if (OnSelectedImageTraining != null)
                {
                    OnSelectedImageTraining(_idx, img);
                }
                
            }
        }
    }
}
