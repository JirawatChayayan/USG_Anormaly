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
using HalconDotNet;
using System.Diagnostics;

namespace USG_Anormaly
{
    public partial class frmTestingModel : Form
    {
        public frmTestingModel()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            getRecipeModelList();
            this.MouseWheel += FrmTestingModel_MouseWheel;
            uI_testingProgressBar1.start();
        }

        private void FrmTestingModel_MouseWheel(object sender, MouseEventArgs e)
        {
            Point pt1 = pb_imageTest.Location;
            Size size = pb_imageTest.Size;
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
                pb_imageTest.HSmartWindowControl_MouseWheel(sender, newe);
                return;
            }

            Point pt2 = pb_imgResult.Location;
            Size size2 = pb_imgResult.Size;
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
                pb_imgResult.HSmartWindowControl_MouseWheel(sender, newe);
                return;
            }
        }

        Dictionary<string, string> _imgPath = new Dictionary<string, string>();
        public void getRecipeModelList()
        {
            comboBox_modelList.Text = "Please Select . . ."; 
            comboBox_modelList.Items.Clear();
            List<ModelStatus> model = (new ServerInterface()).getModelFinished();
            if (model == null)
                return;
            foreach (ModelStatus modelStatus in model)
            {
                if (modelStatus != null)
                {
                    comboBox_modelList.Items.Add(modelStatus.recipeName);
                }
            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            getRecipeModelList();
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


        private void updateList()
        {
            image_List.Items.Clear();
            foreach(var img in _imgPath)
            {
                image_List.Items.Add(img.Key);
            }
        }

        private void button_loadImage_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult da = dialog.ShowDialog();
            dialog.Description = "Broswer folder for upload image.";
            if (da == DialogResult.Yes || da == DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                //List<string> imgPaths = Directory.GetFiles(path,"*.png",SearchOption.AllDirectories).ToList();

                var filters = new string[] { "jpg", "jpeg", "png", "tiff", "tif", "bmp", "hobj" };
                List<string> imgPaths = GetFilesFrom(path, filters, true);

                if (imgPaths.Count == 0)
                {
                    MessageBox.Show("Not found image format (jpg,jpeg,png,tiff,bmp,hobj).", "Upload Image !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _imgPath.Clear();
                foreach(string imgPath in imgPaths)
                {
                    string im = Path.GetFileName(imgPath);
                    _imgPath[im] = imgPath; 
                }
                updateList();
            }
        }

        private void image_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            string imgPath = _imgPath[lb.SelectedItem.ToString()];
            if(File.Exists(imgPath))
            {
                HObject img = new HObject();
                img.GenEmptyObj();
                HOperatorSet.ReadImage(out img, imgPath);
                HOperatorSet.DispObj(img, pb_imageTest.HalconWindow);
                pb_imageTest.SetFullImagePart();
                img.Dispose();
            }
            else
            {
                MessageBox.Show($"Not found image file {imgPath}", "Load image !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_test_Click(object sender, EventArgs e)
        {
            string recipe = comboBox_modelList.SelectedItem.ToString();
            if(recipe == "" || recipe == "Please Select . . .")
            {
                MessageBox.Show($"Please select recipe.", "Testing !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AIInferenceModel model = new AIInferenceModel();
            model.recipe = recipe;

            if(rad_front.Checked)
            {
                model.CameraIdx = CameraIdx.Front;
            }
            else if(rad_side1.Checked)
            {
                model.CameraIdx = CameraIdx.Side;
            }
            else
            {
                model.CameraIdx = CameraIdx.Side2;
            }

            model.reqImgDisplay = true;
            string imgPath = _imgPath[image_List.SelectedItem.ToString()];
            if (!File.Exists(imgPath))
            {
                MessageBox.Show($"Not found image file {imgPath}", "Load image !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            model.b64Img = (new ImageConvert()).pathImg2Base64str(imgPath,ImgFormat.jpg);
            uI_testingProgressBar1.start();
            uI_testingProgressBar1.BringToFront();
            uI_result1.reset();
            dimControl(false);
            bgw_test1.RunWorkerAsync(model);

        }

        private void rad_side2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bgw_test1_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
               
                
                var result = (new ServerInterface()).inference((AIInferenceModel)e.Argument);
                var img = (new ImageConvert()).strbase64toHalconImage(result.b64ImgDisp);
                HOperatorSet.DispObj(img, pb_imgResult.HalconWindow);
                pb_imgResult.SetFullImagePart();
                img.Dispose();
                sw.Stop();
                uI_result1.disp(result,sw.Elapsed.TotalMilliseconds);
            }
            catch (Exception ex)
            {

            }
            sw.Stop();
        }

        private void bgw_test1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgw_test1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            uI_result1.BringToFront();
            uI_testingProgressBar1.stop();
            dimControl(true);
        }

        private void dimControl(bool dim)
        {
            bt_test.Enabled = dim;
            bt_refresh.Enabled = dim;
            bt_loadImage.Enabled = dim;
            comboBox_modelList.Enabled = dim;
            image_List.Enabled = dim;
            panel_cameraIdx.Enabled = dim;
        }
    }
}
