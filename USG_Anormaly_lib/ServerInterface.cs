using Newtonsoft.Json;
using RestSharp;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Web;
using System.Windows.Forms;
using USG_Anormaly_DL_lib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace USG_Anormaly_lib
{
    public class TrainingParameter
    {
        public string machineName { get; set; }
        public string recipeName { get; set; }
        public string userEN { get; set; }
        public string zipName { get; set; }
        public string frontPath { get; set; }
        public string sidePath { get; set; }

        public TrainingParameter()
        {
            machineName = Environment.MachineName;
            recipeName = "";
            userEN = "";
            zipName = "";
            frontPath = "/FrontCamDataSet";
            sidePath = "/SideCamDataSet";
        }
    }
    
    public static class FileExtensions
    {
        public static IEnumerable<FileSystemInfo> AllFilesAndFolders(this DirectoryInfo dir)
        {
            foreach (var f in dir.GetFiles())
                yield return f;
            foreach (var d in dir.GetDirectories())
            {
                yield return d;
                foreach (var o in AllFilesAndFolders(d))
                    yield return o;
            }
        }
    }
    
    public class ServerConfig
    {
        public string serverPath { get; set; }
        public string serverInferPath { get; set; }

        public ServerConfig()
        {
            serverPath = "http://localhost/usg_mvi_anormaly";
            serverInferPath = "http://localhost:9999/api/infer";
        }
        public void loadConfig()
        {
            string path = Path.Combine(ServerConfigPath.serverConfigPath, "server.json");
            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(this));
            }
            var a = JsonConvert.DeserializeObject<ServerConfig>(File.ReadAllText(path));
            serverPath = a.serverPath.Trim();
            serverInferPath = a.serverInferPath.Trim();
        }
    }

    public class TrainingImageSize
    {
        public int width { get; set; }
        public int height { get; set; }
        public TrainingImageSize()
        {
            width = 1312;
            height = 992;
        }
    }

    public class GeneralDLParam
    {
        public int trainingPercent { get; set; } = 60;
        public int validatePercent { get; set; } = 20;
        public TrainingImageSize imgSize { get; set; }
        public int numEpochs { get; set; } = 100;
        public GeneralDLParam()
        {
            imgSize = new TrainingImageSize();
        }
    }
    
    public class HyperDLParam
    {
        public int complexity { get; set; } = 15;
        public double errorThreshold { get; set; } = 0.0010;
        public double domainRatio { get; set; } = 0.25;
        public double regularizationNoise { get; set; } = 0.010;
        public double standardDeviationFactor { get; set; } = 3.0;
    }

    public class FileListUpload
    {
        public string zipNameFront { get; set; }
        public string zipNameSide1 { get; set; }
        public string zipNameSide2 { get; set; }
    }

    public class UploadFileModel
    {
        public string machineName { get; set; }
        public string recipeName { get; set; }
        public string pretrainedDL { get; set; } = "initial_dl_anomaly_medium.hdl";
        public GeneralDLParam generalDLParam { get; set; }
        public HyperDLParam hyperDLParam { get; set;}
        public FileListUpload fileUpload { get; set; }
        public UploadFileModel()
        {
            machineName = Environment.MachineName;
            pretrainedDL = "initial_dl_anomaly_medium.hdl";
            generalDLParam = new GeneralDLParam();
            hyperDLParam = new HyperDLParam();
            fileUpload = new FileListUpload();
        }
    }
    
    public class ModelStatus
    {
        public string recipeName { get; set; }
        public string status { get; set; }
        public DateTime timestamp { get; set; }
    }

    public class ErrorTrainingModel
    {
        public string recipe { get; set; }
        public string msg { get; set; }
    }
    
    public class FinishedTrainingModel
    {
        public string recipe { get; set; }
        public string modelPath { get; set; }
        public string frontPath { get; set; }
        public string sidePath1 { get; set; }
        public string sidePath2 { get; set; }
    }

    public class UploadFileResultModel
    {
        public string msg { get; set; }
        public string fileName { get; set; }
    }

    public class ImageResultModel
    {
        public string absolute_confusion_matrix { get; set; }
        public string score_histogram { get; set; }
        public string pie_charts_precision { get; set; }
        public string pie_charts_recall { get; set; }
        public string score_legend { get; set; }
        public string sample_image { get; set; }
        public AnomalyThreshold anomalyThreshold { get; set; }
    }

    public class AnomalyThreshold
    {
        public string anoSegmentThreshold { get; set; }
        public string anoClassificationThreshold { get; set; }
    }

    public class AITrainingModel
    {
        public ImageResultModel resultFront { get; set; }
        public ImageResultModel resultSide1 { get; set; }
        public ImageResultModel resultSide2 { get; set; }
        public string trainingFromMC { get; set; }
        public string recipeName { get; set; }
        public DateTime trainingDateTime { get; set; }
        public DateTime trainingFinished { get; set; }
        public string pretrainedDL { get; set; }
        public GeneralDLParam generalDLParam { get; set; }
        public HyperDLParam hyperDLParam { get; set; }
    }


    public class LogTrainingInsertModel
    {
        public string logMessage { get; set; }
        public string logLevel { get; set; }
    }

    public class LogInferenceInsertModel
    {
        public string clientId { get; set; }
        public string modelName { get; set; }
        public bool result { get; set; }
        public string rejectPosition { get; set; }
        public string camera { get; set; }
        public double processTime { get; set; }
        public string remark { get; set; }
    }

    public class LogTrainingModel
    {
        public string logMessage { get; set; }
        public string logLevel { get; set; }
        public DateTime timeStamp { get; set; }
    }

    public class LogInferenceModel
    {
        public string clientId { get; set; }
        public string modelName { get; set; }
        public bool result { get; set; }
        public string camera { get; set; }
        public double processTime { get; set; }
        public string rejectPosition { get; set; }
        public string remark { get; set; }
        public DateTime timeStamp { get; set; }
    }

    public class ImageSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class DL_InferenceResult
    {
        public string anormalyClass { get; set; }
        public double anormalyScore { get; set; }
        public string b64ImgRegion { get; set; }
        public string b64ImgDisp { get; set; } = null;
        public ImageSize trainingImgSize { get; set; }
    }

    public class AIInferenceModel
    {
        public string b64Img { get; set; }
        public string recipe { get; set; }
        public CameraIdx CameraIdx { get; set; }
        public bool reqImgDisplay { get; set; } = false;
        public string clientId { get; set; } = Environment.MachineName;
        public AIInferenceModel()
        {
            clientId = Environment.MachineName;
        }
    }



    public class FileListDownload
    {
        public string recipe { get; set; }
        public string status { get; set; }
        public FileListUpload files { get; set; }
    }

    public class ServerInterface
    {
        public void zipFile(string dirZip,string zipPath,string zipName)
        {
            if(!Directory.Exists(dirZip))
            {
                throw new Exception("Not found directory to zip !!!");
            }
            if(!Directory.Exists(zipPath))
            {
                Directory.CreateDirectory(dirZip);
            }
            string outputPath = Path.Combine(zipPath,zipName+".zip");
            if(File.Exists(zipName))
            {
                try
                {
                    File.Delete(zipName);
                }
                catch(Exception ex)
                {

                }
            }
            DirectoryInfo from = new DirectoryInfo(dirZip);
            using (var zipToOpen = new FileStream(outputPath, FileMode.Create))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (var file in from.AllFilesAndFolders().OfType<FileInfo>())
                    {
                        var relPath = file.FullName.Substring(from.FullName.Length + 1);
                        ZipArchiveEntry readmeEntry = archive.CreateEntryFromFile(file.FullName, relPath);
                    }
                }
            }
        }
        public bool getNameInUse(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name.Trim() == "")
                throw new ArgumentNullException("name");
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/NameInUse/{name.Trim()}");
            client.Timeout = 5000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content == "true";
            }
            return true;

        }
        public List<ModelStatus> getModelFinished()
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/ModelName/3");
            client.Timeout = 5000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<ModelStatus>>(response.Content);
            }
            return null;
        }
        public List<ModelStatus> getModelOntraining()
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/ModelName/2");
            client.Timeout = 5000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<ModelStatus>>(response.Content);
            }
            return null;
        }
        public List<ModelStatus> getModelInQueue()
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/ModelName/1");
            client.Timeout = 5000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<ModelStatus>>(response.Content);
            }
            return null;
        }
        public List<ModelStatus> getModelStatusAll()
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/ModelName");
            client.Timeout = 5000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<ModelStatus>>(response.Content);
            }
            return null;
        }
        public List<ModelStatus> getModelStatusOnTrainingInQueue()
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/ModelNameOnTrainingInQueue");
            client.Timeout = 5000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<ModelStatus>>(response.Content);
            }
            return null;
        }
        public UploadFileModel getTrainingData(string recipeName)
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/ModelInfoTraining/{recipeName}");
            client.Timeout = 5000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<UploadFileModel>(response.Content);
            }
            return null;
        }

        public AITrainingModel getFinishedData(string recipeName,bool reqAllImg = false)
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/ModelInfo/{recipeName}?reqAllImg="+(reqAllImg? "true":"false"));
            client.Timeout = 5000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<AITrainingModel>(response.Content);
            }
            return null;
        }

        public bool uploFileTrigger(UploadFileModel dataItem)
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/ModelDetail");
            client.Timeout = 10000;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(dataItem), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public bool setToOntraining(string recipeName)
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/OnTraining/{recipeName}");
            client.Timeout = 5000;
            var request = new RestRequest(Method.PUT);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public bool setToTrainingFinish(FinishedTrainingModel dataItem)
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/TrainingFinished");
            client.Timeout = 5000;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(dataItem), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public bool setToTrainingFail(ErrorTrainingModel dataItem)
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/AIModelTraining/TrainingError");
            client.Timeout = 5000;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(dataItem), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.StatusCode == System.Net.HttpStatusCode.OK;


//            var client = new RestClient("http://localhost/usg_mvi_anormaly/AIModelTraining/TrainingError");
//            client.Timeout = -1;
//            var request = new RestRequest(Method.PUT);
//            request.AddHeader("Content-Type", "application/json");
//            var body = @"{
//" + "\n" +
//            @"  ""recipe"": ""TEST_5-1"",
//" + "\n" +
//            @"  ""msg"": ""Someting Wrong""
//" + "\n" +
//            @"}";
//            request.AddParameter("application/json", body, ParameterType.RequestBody);
//            IRestResponse response = client.Execute(request);
//            Console.WriteLine(response.Content);


        }

        public UploadFileResultModel uploadFile(string FilePath)
        {
            if (!File.Exists(FilePath))
                throw new FileLoadException($"File {FilePath} not found");
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/FileUpload");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddFile("file", FilePath);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<UploadFileResultModel>(response.Content);
            }
            return null;
        }

        public UploadFileResultModel uploadModelFile(string FilePath)
        {
            if (!File.Exists(FilePath))
                throw new FileLoadException($"File {FilePath} not found");
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/FileUpload/UploadTrainedModel");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddFile("file", FilePath);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<UploadFileResultModel>(response.Content);
            }
            return null;
        }

        private UploadFileResultModel uploadModelFiletochunkServer(string FilePath)
        {
            if (!File.Exists(FilePath))
                throw new FileLoadException($"File {FilePath} not found");
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/FileUpload/UploadTrainedModelChunk");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddFile("file", FilePath);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<UploadFileResultModel>(response.Content);
            }
            return null;
        }

        private UploadFileResultModel uploadFiletochunkServer(string FilePath)
        {
            if (!File.Exists(FilePath))
                throw new FileLoadException($"File {FilePath} not found");
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/FileUploadChunk");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddFile("file", FilePath);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (response.Content == "")
                    return null;
                return JsonConvert.DeserializeObject<UploadFileResultModel>(response.Content);
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public UploadFileResultModel uploadModelFilechunk(string FilePath)
        {
            if (!File.Exists(FilePath))
                throw new FileLoadException($"File {FilePath} not found");
            Utils ut = new Utils();

            ut.FileName = FilePath;
            ut.TempFolder = AnormalyPathProcess.chunkPath;
            if (!Directory.Exists(ut.TempFolder))
                Directory.CreateDirectory(ut.TempFolder);
            ut.MaxFileSizeMB = 1;
            ut.SplitFile();
            UploadFileResultModel res = null;
            List<string> files_Error1 = null;
            List<string> files_Error2 = null;
            List<string> files_Error3 = null;
            List<string> files_Error4 = null;


            foreach (string file in ut.FileParts)
            {
                try
                {
                    res = uploadModelFiletochunkServer(file);
                }
                catch
                {
                    if (files_Error1 == null)
                        files_Error1 = new List<string>();
                    files_Error1.Add(file);
                }
            }

            //check error 1st time
            if (files_Error1 != null)
            {
                foreach (string file in files_Error1)
                {
                    try
                    {
                        res = uploadModelFiletochunkServer(file);
                    }
                    catch
                    {

                        if (files_Error2 == null)
                            files_Error2 = new List<string>();
                        files_Error2.Add(file);
                    }
                }
            }

            //check error 2nd time
            if (files_Error2 != null)
            {
                foreach (string file in files_Error2)
                {
                    try
                    {
                        res = uploadModelFiletochunkServer(file);
                    }
                    catch
                    {
                        if (files_Error3 == null)
                            files_Error3 = new List<string>();
                        files_Error3.Add(file);
                    }
                }
            }

            //check error 3rd time
            if (files_Error3 != null)
            {
                foreach (string file in files_Error3)
                {
                    try
                    {
                        res = uploadModelFiletochunkServer(file);
                    }
                    catch
                    {
                        if (files_Error4 == null)
                            files_Error4 = new List<string>();
                        files_Error4.Add(file);
                    }
                }
            }

            //check error 3th time
            if (files_Error4 != null)
            {
                foreach (string file in files_Error4)
                {
                    try
                    {
                        res = uploadModelFiletochunkServer(file);
                    }
                    catch
                    {

                    }
                }
            }



            foreach (string file in ut.FileParts)
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {

                }
            }
            return res;
        }

        public UploadFileResultModel uploadFilechunk(string FilePath)
        {
            if (!File.Exists(FilePath))
                throw new FileLoadException($"File {FilePath} not found");
            Utils ut = new Utils();

            ut.FileName = FilePath;
            ut.TempFolder = AnormalyPathProcess.chunkPath;
            if (!Directory.Exists(ut.TempFolder))
                Directory.CreateDirectory(ut.TempFolder);
            ut.MaxFileSizeMB = 1;
            ut.SplitFile(true);
            UploadFileResultModel res = null;
            List<string> files_Error1 = null;
            List<string> files_Error2 = null;
            List<string> files_Error3 = null;
            List<string> files_Error4 = null;


            foreach (string file in ut.FileParts)
            {
                try
                {
                    res = uploadFiletochunkServer(file);
                }
                catch
                {
                    if (files_Error1 == null)
                        files_Error1 = new List<string>();
                    files_Error1.Add(file);
                }
            }

            //check error 1st time
            if (files_Error1 != null)
            {
                foreach (string file in files_Error1)
                {
                    try
                    {
                        res = uploadFiletochunkServer(file);
                    }
                    catch
                    {

                        if (files_Error2 == null)
                            files_Error2 = new List<string>();
                        files_Error2.Add(file);
                    }
                }
            }

            //check error 2nd time
            if(files_Error2 != null)
            {
                foreach (string file in files_Error2)
                {
                    try
                    {
                        res = uploadFiletochunkServer(file);
                    }
                    catch
                    {
                        if(files_Error3 == null)
                            files_Error3 = new List<string>();
                        files_Error3.Add(file);
                    }
                }
            }

            //check error 3rd time
            if (files_Error3 != null)
            {
                foreach (string file in files_Error3)
                {
                    try
                    {
                        res = uploadFiletochunkServer(file);
                    }
                    catch
                    {
                        if (files_Error4 == null)
                            files_Error4 = new List<string>();
                        files_Error4.Add(file);
                    }
                }
            }

            //check error 3th time
            if (files_Error4 != null)
            {
                foreach (string file in files_Error4)
                {
                    try
                    {
                        res = uploadFiletochunkServer(file);
                    }
                    catch
                    {

                    }
                }
            }

            //delete
            foreach (string file in ut.FileParts)
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {

                }
            }
            return res;
        }


        public void postInferLog(LogInferenceInsertModel insertLog)
        {
            try
            {
                ServerConfig serverConfig = new ServerConfig();
                serverConfig.loadConfig();
                var client = new RestClient($"{serverConfig.serverPath}/Logging/log-inference");
                client.Timeout = 3000;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(insertLog);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            catch (Exception ex)
            {

            }
        }
        public void postTrainingLog(LogTrainingInsertModel insertLog)
        {
            try
            {
                ServerConfig serverConfig = new ServerConfig();
                serverConfig.loadConfig();
                var client = new RestClient($"{serverConfig.serverPath}/Logging/log-training");
                client.Timeout = 3000;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(insertLog);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            catch (Exception ex)
            {

            }
        }

        public List<LogInferenceModel> getLogInfer(DateTime fromDate,DateTime toDate)
        {
            if (fromDate == null)
                throw new ArgumentNullException("fromdate parameter is require !!!!");
            if(toDate == null)
            {
                toDate = DateTime.Now;
            }
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();

            var client = new RestClient($"{serverConfig.serverPath}/Logging/retrieve-log-inference");
            client.Timeout = 3000;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var aaa = new
            {
                fromDate = fromDate,
                toDate = toDate,
            };
            var body = JsonConvert.SerializeObject(aaa);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<LogInferenceModel>>(response.Content);
            }
            return null;
        }
        public List<LogTrainingModel> getLogTraining(DateTime fromDate, DateTime toDate)
        {
            if (fromDate == null)
                throw new ArgumentNullException("fromdate parameter is require !!!!");
            if (toDate == null)
            {
                toDate = DateTime.Now;
            }
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/Logging/retrieve-log-training");
            client.Timeout = 3000;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var aaa = new
            {
                fromDate = fromDate,
                toDate = toDate,
            };
            var body = JsonConvert.SerializeObject(aaa);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<LogTrainingModel>>(response.Content);
            }
            return null;
        }

        public DL_InferenceResult inference(AIInferenceModel dataItem)
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverInferPath}");
            client.Timeout = 20000;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(dataItem);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<DL_InferenceResult>(response.Content);
            }
            throw new Exception(response.Content);
        }

        public List<FileListDownload> GetFileListDownloads()
        {
            //http://colorcam.nseb.co.th:81/usg_mvi_anormaly/api/list-dataset-file-model
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            var client = new RestClient($"{serverConfig.serverPath}/list-dataset-file-model");
            client.Timeout = 5000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<FileListDownload>>(response.Content);
            }
            return null;
        }

        public void downloadfileToLocal(string fileNameDownload)
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.loadConfig();
            string remoteUri = $"{serverConfig.serverPath}/download-dataset-file?fileName={fileNameDownload.Trim()}";
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(remoteUri, Path.Combine(PathProcess.uploadPath,fileNameDownload));
        }
    }
}
