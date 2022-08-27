using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using USG_Anormaly_DL_lib;
using USG_Anormaly_lib;

namespace AnomalyTraining_Service
{
    public partial class Service1 : ServiceBase
    {
        static Timer tFetch = new Timer();
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

        protected override void OnStop()
        {
            stop();
        }
        public void OnDebug()
        {
            this.OnStart(null);
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

        private static UploadFileModel ZipProcess(ModelStatus modelStatus)
        {
            if (modelStatus == null)
                throw new Exception("Error Process.");
            if (modelStatus.recipeName.Trim() == "")
                throw new Exception("Error Process.");


            var trainingData = (new ServerInterface()).getTrainingData(modelStatus.recipeName);

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
                        (new DL_Training()).training(trainingparam, CameraIdx.Front);
                    }
                    if (!(File.Exists(sidePath.model) && File.Exists(sidePath.dataset)))
                    {
                        (new DL_Training()).training(trainingparam, CameraIdx.Side);
                    }
                    if (!(File.Exists(side2Path.model) && File.Exists(side2Path.dataset)))
                    {
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
