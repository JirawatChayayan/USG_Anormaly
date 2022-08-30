using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using USG_Anormaly_DL_lib;
using USG_Anormaly_lib;
using static System.Net.Mime.MediaTypeNames;
using System.IO.Compression;

namespace AnormalyTraining_Service_Remote
{
    public partial class Service1 : ServiceBase
    {
        static Timer tFetch = new Timer();
        static bool remote_training = true;
        public static MessageManagement msgManage = new MessageManagement();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            msgManage.msg("System", "Training Service Started", LogLevel.INFO);
            tFetch.Elapsed += TFetch_Elapsed;

            getOntraining();
            start();
        }

        public void OnDebug()
        {
            //zipFile(@"C:\\AnormalyModelUpload\\DLModel\\TEST2", @"D:\", "TEST2");
            this.OnStart(null);
        }

        protected override void OnStop()
        {
            stop();
        }
        private static void start()
        {
            tFetch.Interval = 2000;
            tFetch.Enabled = true;
            tFetch.Start();
        }
        public static void stop()
        {
            tFetch.Stop();
            tFetch.Enabled = false;

        }
        private static void memory()
        {
            try
            {
                Process prs = Process.GetCurrentProcess();
                prs.MinWorkingSet = (IntPtr)((int)819200);
                GC.Collect(0);
            }
            catch
            {
            }
        }
        private static UploadFileModel ZipProcess(ModelStatus modelStatus)
        {
            if (modelStatus == null)
                throw new Exception("Error Process.");
            if (modelStatus.recipeName.Trim() == "")
                throw new Exception("Error Process.");
            var trainingData = (new ServerInterface()).getTrainingData(modelStatus.recipeName);



            if (remote_training)
            {
                var res = (new ServerInterface()).GetFileListDownloads();
                bool haveFile = false;
                foreach (var file in res)
                {
                    if (file.recipe == trainingData.recipeName)
                    {
                        (new ServerInterface()).downloadfileToLocal(file.files.zipNameFront);
                        (new ServerInterface()).downloadfileToLocal(file.files.zipNameSide1);
                        (new ServerInterface()).downloadfileToLocal(file.files.zipNameSide2);
                        haveFile = true;
                    }
                }
                if (!haveFile)
                    return null;
            }


            ZipProcess zipProcess = new ZipProcess();
            msgManage.msg("Unzip", $"Start Unzip training on {trainingData.recipeName}", LogLevel.INFO);
            string pathZipFront = Path.Combine(PathProcess.uploadPath, trainingData.fileUpload.zipNameFront);
            string pathZipSide1 = Path.Combine(PathProcess.uploadPath, trainingData.fileUpload.zipNameSide1);
            string pathZipSide2 = Path.Combine(PathProcess.uploadPath, trainingData.fileUpload.zipNameSide2);


            zipProcess.unZip(pathZipFront, PathProcess.frontImgDatasetFolder(trainingData.recipeName));
            zipProcess.unZip(pathZipSide1, PathProcess.side1DatasetFolder(trainingData.recipeName));
            zipProcess.unZip(pathZipSide2, PathProcess.side2DatasetFolder(trainingData.recipeName));
            msgManage.msg("Unzip", $"Finished Unzip training on {trainingData.recipeName}", LogLevel.INFO);
            (new ServerInterface()).setToOntraining(trainingData.recipeName);

            zipProcess.deleteZip(pathZipFront);
            zipProcess.deleteZip(pathZipSide1);
            zipProcess.deleteZip(pathZipSide2);
            return trainingData;
        }
        private static bool downloadFile(string recipeName,string zipName,CameraIdx idx)
        {
            msgManage.msg("Unzip", $"Downloading zip name {zipName}", LogLevel.INFO);
            (new ServerInterface()).downloadfileToLocal(zipName);
            ZipProcess zipProcess = new ZipProcess();
            string pathZipfileDownload = Path.Combine(PathProcess.uploadPath, zipName);

            if (File.Exists(pathZipfileDownload))
                return false;
            if(idx == CameraIdx.Front)
                zipProcess.unZip(pathZipfileDownload, PathProcess.frontImgDatasetFolder(recipeName));
            else if(idx == CameraIdx.Side)
                zipProcess.unZip(pathZipfileDownload, PathProcess.side1DatasetFolder(recipeName));
            else
                zipProcess.unZip(pathZipfileDownload, PathProcess.side2DatasetFolder(recipeName));
            zipProcess.deleteZip(pathZipfileDownload);
            return true;

        }
        public static void Training(UploadFileModel trainingparam, bool newTrain = true)
        {
            try
            {
                msgManage.msg("Training", $"Start training on {trainingparam.recipeName}", LogLevel.INFO);
                var frontPath = PathProcess.modelSavePath(trainingparam.recipeName, CameraIdx.Front);
                var sidePath = PathProcess.modelSavePath(trainingparam.recipeName, CameraIdx.Side);
                var side2Path = PathProcess.modelSavePath(trainingparam.recipeName, CameraIdx.Side2);

                if (newTrain)
                {
                    (new DL_Training()).training(trainingparam, CameraIdx.Front);
                    (new DL_Training()).training(trainingparam, CameraIdx.Side);
                    (new DL_Training()).training(trainingparam, CameraIdx.Side2);
                }
                else
                {
                    if (!(File.Exists(frontPath.model) && File.Exists(frontPath.dataset)))
                    {
                        if (remote_training)
                        {
                            bool res = downloadFile(trainingparam.recipeName,
                                                    trainingparam.fileUpload.zipNameFront,
                                                    CameraIdx.Front);
                            if (!res)
                                throw new Exception("Cannot download dataset zip file.");
                        }
                        (new DL_Training()).training(trainingparam, CameraIdx.Front);
                    }
                    if (!(File.Exists(sidePath.model) && File.Exists(sidePath.dataset)))
                    {
                        if (remote_training)
                        {
                            bool res = downloadFile(trainingparam.recipeName,
                                                        trainingparam.fileUpload.zipNameSide1,
                                                        CameraIdx.Front);
                            if (!res)
                                throw new Exception("Cannot download dataset zip file.");
                        }
                        (new DL_Training()).training(trainingparam, CameraIdx.Side);
                    }
                    if (!(File.Exists(side2Path.model) && File.Exists(side2Path.dataset)))
                    {
                        if (remote_training)
                        {
                            bool res = downloadFile(trainingparam.recipeName,
                                                    trainingparam.fileUpload.zipNameSide2,
                                                    CameraIdx.Front);
                            if (!res)
                                throw new Exception("Cannot download dataset zip file.");
                        }
                        (new DL_Training()).training(trainingparam, CameraIdx.Side2);
                    }

                }
                FinishedTrainingModel modelDetail = new FinishedTrainingModel();
                List<ModelPath> modelPaths = new List<ModelPath>();
                modelPaths.Add(frontPath);
                modelPaths.Add(sidePath);
                modelPaths.Add(side2Path);
                modelDetail.modelPath = JsonConvert.SerializeObject(modelPaths);
                modelPaths.Clear();
                memory();
                modelDetail.frontPath = PathProcess.trainingrResultSavePath(trainingparam.recipeName, CameraIdx.Front).main_path;
                memory();
                modelDetail.sidePath1 = PathProcess.trainingrResultSavePath(trainingparam.recipeName, CameraIdx.Side).main_path;
                memory();
                modelDetail.sidePath2 = PathProcess.trainingrResultSavePath(trainingparam.recipeName, CameraIdx.Side2).main_path;
                memory();
                modelDetail.recipe = trainingparam.recipeName;

                string modelFolder = PathProcess.modelRecipeFolder(trainingparam.recipeName);
                string pathModeZip = @"C:\AnormalyModelUpload\ModelUpload";
                if(!Directory.Exists(pathModeZip))
                {
                    Directory.CreateDirectory(pathModeZip);
                }
                string modelZip = zipFile(modelFolder,
                                          pathModeZip,
                                          trainingparam.recipeName);

                var result = (new ServerInterface()).uploadModelFile(modelZip);
                if (result == null)
                    throw new Exception("Can not upload file model !!!");

                (new ZipProcess()).deleteZip(modelZip);

                (new ServerInterface()).setToTrainingFinish(modelDetail);

                msgManage.msg("Training", $"Finish training on {trainingparam.recipeName}", LogLevel.INFO);

            }
            catch (Exception ex)
            {
                ErrorTrainingModel error = new ErrorTrainingModel();
                error.recipe = trainingparam.recipeName;
                error.msg = ex.Message;
                (new ServerInterface()).setToTrainingFail(error);
                msgManage.msg("Training", $"Error training on {trainingparam.recipeName} {ex.Message}", LogLevel.ERROR);
            }


        }
        public static string zipFile(string dirZip, string zipPath, string zipName)
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
            if (File.Exists(outputPath))
            {
                try
                {
                    File.Delete(outputPath);
                }
                catch (Exception ex)
                {

                }
            }


            //ZipFile.CreateFromDirectory(dirZip, outputPath);
            DirectoryInfo from = new DirectoryInfo(dirZip);
            using (var zipToOpen = new FileStream(outputPath, FileMode.Create))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    var data = from.AllFilesAndFolders().OfType<FileInfo>();
                    foreach (var file in data)
                    {
                        var relPath = file.FullName.Substring(from.FullName.Length + 1);
                        ZipArchiveEntry readmeEntry = archive.CreateEntryFromFile(file.FullName, relPath);
                    }
                }
            }
            return outputPath;
        }
        public static void getOntraining()
        {
            msgManage.msg("System", "Check OnTraining", LogLevel.INFO);
            List<ModelStatus> mds = (new ServerInterface()).getModelOntraining();
            if (mds == null)
            {
                msgManage.msg("System", "No on training process :)", LogLevel.INFO);
                return;
            }
            msgManage.msg("System", $"Have on training {mds.Count()} process.", LogLevel.INFO);
            foreach (ModelStatus status in mds)
            {
                try
                {
                    var trainingData = (new ServerInterface()).getTrainingData(status.recipeName);
                    if (trainingData != null)
                    {
                        Training(trainingData, false);
                    }
                }
                catch (Exception e)
                {
                    msgManage.msg("Training", $"Error training process {e.Message}", LogLevel.ERROR);
                }
            }
        }
        private static void TFetch_Elapsed(object sender, ElapsedEventArgs e)
        {
            stop();
            //Console.WriteLine(DateTime.Now.ToString());
            List<ModelStatus> mds = (new ServerInterface()).getModelInQueue();
            if (mds == null)
            {
                start();
                return;
            }
            if (mds.Count == 0)
            {
                start();
                return;
            }
            try
            {
                var trainingparam = ZipProcess(mds[0]);
                Training(trainingparam);


            }
            catch (Exception ex)
            {
                ErrorTrainingModel error = new ErrorTrainingModel();
                error.recipe = mds[0].recipeName;
                error.msg = ex.Message;
                (new ServerInterface()).setToTrainingFail(error);
                msgManage.msg("Unzip", $"Error Unzip on {error.recipe} {ex.Message}", LogLevel.ERROR);
            }
            start();

        }
    }
}
