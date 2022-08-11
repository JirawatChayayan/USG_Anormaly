using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using USG_Anormaly_lib;

namespace USG_Anormaly
{

    public enum LogLevel
    {
        INFO,
        Warning,
        ERROR
    }
    public delegate void statusDispde(string msg, LogLevel level);
    public partial class UI_Training : UserControl
    {
        
        Mutex mutStatus = new Mutex();

        public UI_Training()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

        }
        public event SelectedImageTraining OnSelectedImageTraining;
        public event RequireCaptureImage OnRequireCaptureImage;
        public void initial()
        {
            uI_preTrain_imgfront.CameraIdx = CameraIdx.Front;
            uI_preTrain_imgside1.CameraIdx = CameraIdx.Side;
            uI_preTrain_imgside2.CameraIdx = CameraIdx.Side2;

            uI_preTrain_imgfront.OnSelectedImageTraining += OnSelected_ImageTraining;
            uI_preTrain_imgside1.OnSelectedImageTraining += OnSelected_ImageTraining;
            uI_preTrain_imgside2.OnSelectedImageTraining += OnSelected_ImageTraining;


            uI_preTrain_imgfront.OnRequireCaptureImage += OnRequireCapture;
            uI_preTrain_imgside1.OnRequireCaptureImage += OnRequireCapture;
            uI_preTrain_imgside2.OnRequireCaptureImage += OnRequireCapture;

            uI_preTrain_imgfront.OnUpdateStatus += OnStatusUpdate;
            uI_preTrain_imgside1.OnUpdateStatus += OnStatusUpdate;
            uI_preTrain_imgside2.OnUpdateStatus += OnStatusUpdate;
        }

        private void OnStatusUpdate(string msg, LogLevel level)
        {
            statusDispde de = new statusDispde(statusDisplay);
            de(msg, level);
        }

        private HObject OnRequireCapture(CameraIdx idx)
        {
            if (OnRequireCaptureImage != null)
                return OnRequireCaptureImage(idx);
            else
                return null;
        }
        private void OnSelected_ImageTraining(CameraIdx idx, HObject imgSelect)
        {
            if (OnSelectedImageTraining != null)
            {
                OnSelectedImageTraining(idx, imgSelect);
            }
            else
            {
                imgSelect.Dispose();
            }
        }
        public void update_imgPath()
        {
            uI_preTrain_imgfront.updateList();
            uI_preTrain_imgside1.updateList();
            uI_preTrain_imgside2.updateList();
        }
        private bool checkRecipeNameInuse(string recipe)
        {
            return (new ServerInterface()).getNameInUse(recipe);
        }
        private void bt_training_Click(object sender, EventArgs e)
        {
            string recipe = txt_recipe.Text.Trim();
            if (recipe == "")
            {
                OnStatusUpdate("Please Fill Recipe name.", LogLevel.Warning);
                MessageBox.Show("Please Fill Recipe name.",
                                "Warning !!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (checkRecipeNameInuse(recipe))
            {
                OnStatusUpdate("This recipe name in use by another model !!!", LogLevel.Warning);
                MessageBox.Show("This recipe name in use by another model !!!",
                                "Warning !!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (uI_preTrain_imgfront.imageList.Count < 10)
            {
                OnStatusUpdate("Please check front image for training is not lower 10 img !!!", LogLevel.Warning);
                MessageBox.Show("Please check front image for training !!!" +
                                Environment.NewLine +
                                "Minimum image for training = 10.",
                                "Warning !!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (uI_preTrain_imgside1.imageList.Count < 10)
            {
                OnStatusUpdate("Please check side1 image for training is not lower 10 img !!!", LogLevel.Warning);
                MessageBox.Show("Please check side1 image for training !!!" +
                                Environment.NewLine +
                                "Minimum image for training = 10.",
                                "Warning !!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (uI_preTrain_imgside2.imageList.Count < 10)
            {
                OnStatusUpdate("Please check side2 image for training is not lower 10 img !!!", LogLevel.Warning);
                MessageBox.Show("Please check side2 image for training !!!" +
                                Environment.NewLine +
                                "Minimum image for training = 10.",
                                "Warning !!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            startWorker(recipe);
        }
        private void txt_recipe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space || 
                e.KeyChar == (char)Keys.OemBackslash || 
                e.KeyChar == '/' || 
                e.KeyChar == '*' || 
                e.KeyChar == '.' || 
                e.KeyChar == '+' ||
                e.KeyChar == '=' ||
                e.KeyChar == '{' ||
                e.KeyChar == '}' ||
                e.KeyChar == '|' ||
                e.KeyChar == '?' ||
                e.KeyChar == '"' ||
                e.KeyChar == '<' ||
                e.KeyChar == '@' ||
                e.KeyChar == '#' ||
                e.KeyChar == '%' ||
                e.KeyChar == '^' ||
                e.KeyChar == '&' ||
                e.KeyChar == '(' ||
                e.KeyChar == ')' ||
                e.KeyChar == '[' ||
                e.KeyChar == '~' ||
                e.KeyChar == '$' ||
                e.KeyChar == '!' ||
                e.KeyChar == '>')
            {
                e.Handled = true;
            }
        }

        public void statusDisplay(string msg,LogLevel level)
        {
            string msgAll = $"{DateTime.Now} {level} {msg.Trim()}\n";
            mutStatus.WaitOne();
            try
            {
                if (level == LogLevel.INFO)
                {
                    rtb_status.SelectionColor = Color.Black;
                }
                else if (level == LogLevel.Warning)
                {
                    rtb_status.SelectionColor = Color.Yellow;
                }
                else
                {
                    rtb_status.SelectionColor = Color.Red;
                }
                rtb_status.AppendText(msgAll);
                rtb_status.ScrollToCaret();
            }
            catch
            {

            }
            mutStatus.ReleaseMutex();
        }

        private void dimControl(bool dim)
        {
            txt_recipe.Enabled = !dim;
            bt_training.Enabled = !dim;
            tabControl1.Enabled = !dim;
            bt_checkNameInuse.Enabled = !dim;
        }


        private void startWorker(string recipe)
        {
            dimControl(true);
            uI_WaitTrainingProcess1.BringToFront();
            uI_WaitTrainingProcess1.startProgressBar();
            bgw_Upload_data.RunWorkerAsync(recipe);
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

        public int zipFile(string dirZip, string zipPath, string zipName,int currentCounter)
        {
            if (!Directory.Exists(dirZip))
            {
                throw new Exception("Not found directory to zip !!!");
            }
            if (!Directory.Exists(zipPath))
            {
                Directory.CreateDirectory(dirZip);
            }
            string outputPath = Path.Combine(zipPath, zipName + ".zip");
            if (File.Exists(zipName))
            {
                try
                {
                    File.Delete(zipName);
                }
                catch (Exception ex)
                {

                }
            }
            DirectoryInfo from = new DirectoryInfo(dirZip);
            int counter = 0;
            int len = 0;
            double percentage = 0;
            using (var zipToOpen = new FileStream(outputPath, FileMode.Create))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    var data = from.AllFilesAndFolders().OfType<FileInfo>();
                    len = data.Count();
                    percentage = 33 / len;
                    foreach (var file in data)
                    {
                        var relPath = file.FullName.Substring(from.FullName.Length + 1);
                        ZipArchiveEntry readmeEntry = archive.CreateEntryFromFile(file.FullName, relPath);
                        counter++;  
                        try
                        {
                            bgw_Upload_data.ReportProgress((int)(currentCounter + (counter * percentage)), $"{zipName} zip compression");
                        }
                        catch
                        {

                        }
                    }
                }
            }
            return (int)(currentCounter + (counter * percentage));
        }
        private void bgw_Upload_data_DoWork(object sender, DoWorkEventArgs e)
        {

            statusDispde de = new statusDispde(statusDisplay);
            de("Starting background process.", LogLevel.INFO);
            var filters = new string[] { "jpg", "jpeg", "png", "tiff", "bmp", "hobj" };
            bgw_Upload_data.ReportProgress(0, "List cache file..");
            var listFileFront = GetFilesFrom(TrainingCacheFilePath.frontCachePath, filters, true);
            var listFileSide1 = GetFilesFrom(TrainingCacheFilePath.sideCachePath1, filters, true);
            var listFileSide2 = GetFilesFrom(TrainingCacheFilePath.sideCachePath2, filters, true);
            int percent = 0;


            var trainingParam = uI_ParameterTrain1.getParam();


            #region image compression 
            de("Starting image compression.", LogLevel.INFO);
            double allImg = 100.00 / (double)(listFileFront.Count + listFileSide1.Count + listFileSide2.Count);
            int i = 0;
            Dictionary<string, List<string>> allimgsPath = new Dictionary<string, List<string>>();
            allimgsPath[UploadPath.frontCacheZipPath] = listFileFront;
            allimgsPath[UploadPath.sideCacheZipPath1] = listFileSide1;
            allimgsPath[UploadPath.sideCacheZipPath2] = listFileSide2;
            Mutex mutex = new Mutex();
            Parallel.ForEach(allimgsPath, imgsPathSide =>
            {
                int filescount = imgsPathSide.Value.Count;
                foreach (var pathImg in imgsPathSide.Value)
                {
                    HObject img = new HObject(); img.GenEmptyObj();
                    HObject imgZoom = new HObject(); imgZoom.GenEmptyObj();

                    HOperatorSet.ReadImage(out img, pathImg);
                    HOperatorSet.ZoomImageSize(img,
                                               out imgZoom,
                                               trainingParam.generalDLParam.imgSize.width,
                                               trainingParam.generalDLParam.imgSize.height,
                                               "constant");
                    string fileName = Path.GetFileNameWithoutExtension(pathImg);
                    if (filescount > 30)
                    {
                        HOperatorSet.WriteImage(imgZoom, "jpeg", 0, $"{imgsPathSide.Key}/{fileName}.jpg");
                    }
                    else
                    {
                        HOperatorSet.WriteImage(imgZoom, "png", 0, $"{imgsPathSide.Key}/{fileName}.png");
                    }
                    imgZoom.Dispose();
                    img.Dispose();
                    mutex.WaitOne();
                    i++;
                    bgw_Upload_data.ReportProgress((int)(i * allImg), "Image compression");
                    mutex.ReleaseMutex();
                }
            });
            allimgsPath.Clear();
            percent = (int)(i * allImg);
            de("Image compression finished.", LogLevel.INFO);
            #endregion

            #region Zip Compression 
            de("Starting file compression.", LogLevel.INFO);
            percent = zipFile(UploadPath.frontForzip, UploadPath.zipSave, "Front", 0);
            percent = zipFile(UploadPath.side1Forzip, UploadPath.zipSave, "Size_1", percent);
            percent = zipFile(UploadPath.side2Forzip, UploadPath.zipSave, "Size_2", percent+1);
            de("File compression finished.", LogLevel.INFO);
            #endregion

            #region Upload to server 
            bool UploadProcessError = false;
            try
            {
                de("Starting uploading File to server.", LogLevel.INFO);
                Thread.Sleep(10);
                bgw_Upload_data.ReportProgress((int)(0), "Front.zip Uploading");
                var retFront = (new ServerInterface()).uploadFile(Path.Combine(UploadPath.zipSave, "Front.zip"));
                bgw_Upload_data.ReportProgress((int)(33), "Size_1.zip Uploading");
                var retSize1 = (new ServerInterface()).uploadFile(Path.Combine(UploadPath.zipSave, "Size_1.zip"));
                bgw_Upload_data.ReportProgress((int)(66), "Size_2.zip Uploading");
                var retSize2 = (new ServerInterface()).uploadFile(Path.Combine(UploadPath.zipSave, "Size_2.zip"));
                UploadFileModel modelUploadTrig = new UploadFileModel();
                modelUploadTrig.recipeName = (string)e.Argument;
                modelUploadTrig.hyperDLParam = trainingParam.hyperDLParam;
                modelUploadTrig.generalDLParam = trainingParam.generalDLParam;

                modelUploadTrig.pretrainedDL = trainingParam.pretrainedDL;
                modelUploadTrig.fileUpload.zipNameFront = retFront.fileName;
                modelUploadTrig.fileUpload.zipNameSide1 = retSize1.fileName;
                modelUploadTrig.fileUpload.zipNameSide2 = retSize2.fileName;
                bool uploadOK = (new ServerInterface()).uploFileTrigger(modelUploadTrig);
                bgw_Upload_data.ReportProgress((int)(100), "Dataset Uploaded");
                if (!uploadOK)
                    UploadProcessError = true;


            }
            catch (Exception ex)
            {
                UploadProcessError = true;
            }

            if(UploadProcessError)
            {
                de("Upload file to server ERROR !!!!", LogLevel.ERROR);
            }
            else
            {
                de("File uploaded", LogLevel.INFO);
            }

            #endregion

            #region deleteFile 
            de("Start delete file.", LogLevel.INFO);
            var listFileFrontdelete = GetFilesFrom(UploadPath.frontCacheZipPath, filters, true);
            var listFileSide1delete = GetFilesFrom(UploadPath.sideCacheZipPath1, filters, true);
            var listFileSide2delete = GetFilesFrom(UploadPath.sideCacheZipPath2, filters, true);
            var zipFiledelete = GetFilesFrom(UploadPath.zipSave, new string[]{"zip"}, true);
            var daleteLists = listFileFrontdelete.Concat(listFileSide1delete).Concat(listFileSide2delete).Concat(zipFiledelete);
            double allDelete = 100.00 / (double)daleteLists.Count();
            i = 0;
            foreach (var file in daleteLists)
            {
                File.Delete(file);
                i++;
                if(UploadProcessError)
                {
                    bgw_Upload_data.ReportProgress((int)((i * allDelete)), "Upload Error !!! Delete file");
                }
                else
                {
                    bgw_Upload_data.ReportProgress((int)((i * allDelete)), "Delete file");
                }
                Thread.Sleep(1);
            }
            de("Deleted.", LogLevel.INFO);
            #endregion

        }

        private void bgw_Upload_data_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            uI_WaitTrainingProcess1.SendToBack();
            uI_WaitTrainingProcess1.stopProgressBar();
            dimControl(false);
        }

        private void bgw_Upload_data_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            uI_WaitTrainingProcess1.setText($"{(string)e.UserState} : {e.ProgressPercentage} %");
        }

        private void bt_checkNameInuse_Click(object sender, EventArgs e)
        {
            statusDispde de = new statusDispde(statusDisplay);
            if (txt_recipe.Text == "")
            {
                
                de("Please fill data in recie box", LogLevel.Warning);
                return;
            }

            bool res = checkRecipeNameInuse(txt_recipe.Text.Trim());

            if(res)
            {
                de($"Recipe name {txt_recipe.Text.Trim()} are inuse.", LogLevel.Warning);
            }
            else
            {
                de($"Recipe name {txt_recipe.Text.Trim()} it ok to use.", LogLevel.INFO);
            }
        }

        public void filledServerStatus()
        {
            try
            {
                var res = (new ServerInterface()).getModelStatusOnTrainingInQueue();
                if (res == null)
                {
                    dgv_result.Rows.Clear();
                    return;
                }
                DataTable dt = new DataTable();
                DataColumn colItem = new DataColumn("idx",typeof(int));
                DataColumn colRecipe = new DataColumn("recipe", typeof(string));
                DataColumn dataStatus = new DataColumn("status", typeof(string));
                DataColumn colDateTime = new DataColumn("datetime", typeof(DateTime));
                dt.Columns.Add(colItem);
                dt.Columns.Add(colRecipe);
                dt.Columns.Add(dataStatus);
                dt.Columns.Add(colDateTime);


                int i = 0;
                foreach (var item in res)
                {
                    i += 1;
                    dt.Rows.Add(i,item.recipeName,item.status,item.timestamp);
                }

                dgv_result.DataSource = dt;
                dgv_result.Columns[dt.Columns[0].ColumnName].Width = 40;
                dgv_result.Columns[dt.Columns[1].ColumnName].Width = 192;
                dgv_result.Columns[dt.Columns[2].ColumnName].Width = 70;
                dgv_result.Columns[dt.Columns[3].ColumnName].Width = 105;

                foreach (DataGridViewRow row in dgv_result.Rows)
                {
                    string status = row.Cells[2].Value.ToString();
                    if(status == "In Queue")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    else if(status == "On Training")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (status == "Finished")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }


            }
            catch (Exception ex)
            {

            }
        }
        public void stopStartFetchdata(bool start)
        {
            if(start)
            {


                timer_fetchServerInfo.Enabled = true;
                timer_fetchServerInfo.Start();
                timer_fetchServerInfo.Interval = 500;
            }
            else
            {
                
                timer_fetchServerInfo.Stop();
                timer_fetchServerInfo.Enabled = false;
            }
        }
        private void timer_fetchServerInfo_Tick(object sender, EventArgs e)
        {
            timer_fetchServerInfo.Interval = 5000;
            filledServerStatus();
        }
    }
}
