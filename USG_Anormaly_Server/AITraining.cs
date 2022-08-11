
using Newtonsoft.Json;
using USG_Anormaly_Server.Models;
namespace USG_Anormaly_Server
{
    public enum StatusMode
    {
        InQueue= 1,
        OnTraining = 2,
        Finished = 3,
        Error = 4,
    }

    public class AIDatabaseProcess
    {
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
        public string img2Base64(string imgPath)
        {
            string extension = Path.GetExtension(imgPath);
            //'data:image/jpeg;base64,
            //'data:image/png;base64,
            string header = "";
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".JPG" || extension == ".JPEG")
                header = "data:image/jpeg;base64";
            else
                header = "data:image/png;base64";
            byte[] imageArray = System.IO.File.ReadAllBytes(imgPath);
            string base64ImageRepresentation = $"{header},{Convert.ToBase64String(imageArray)}";
            return base64ImageRepresentation;
        }

        private readonly usg_anormaly_mvi_systemContext _dbcontext;
        public AIDatabaseProcess(usg_anormaly_mvi_systemContext context)
        {
            _dbcontext = context;
        }
        public async Task<List<TrainingStatusDetail>> statusDetail()
        {
            var db = from a in _dbcontext.TblTrainingStatusDetails
                     where a.Activeflag == true
                     select new
                     {
                         a.StatusId,
                         a.StatusDetail
                     };

            var data = await db.ToListAsync();
            List<TrainingStatusDetail> result = new List<TrainingStatusDetail>();
            foreach (var item in data)
            {
                result.Add(new TrainingStatusDetail
                {
                    StatusId = item.StatusId,
                    StatusDetail = item.StatusDetail
                });
            }
            return result;
        }
        public async Task<bool> nameInUse(string? recipeName)
        {
            if(recipeName == null || recipeName == "")
                throw new ArgumentNullException(nameof(recipeName));
            var db = from a in _dbcontext.TblTrainingModelDetails
                     where a.Activeflag == true && a.RecipeName == recipeName
                     select new
                     {
                         a.RecipeName
                     };
            var res = await db.ToListAsync();
            if (res == null)
            {
                return false;
            }
            if (res.Count == 0)
            {
                return false;
            }
            return true;
        }
        public async Task<List<ModelStatus>?> modelList(StatusMode mode)
        {
            var db = from a in _dbcontext.TblTrainingModelDetails
                     join b in _dbcontext.TblTrainingStatusDetails
                     on a.TrainingStatus equals b.StatusId
                     where a.Activeflag == true && a.TrainingStatus == (int)mode
                     orderby a.TimeStamp ascending
                     select new
                     {
                         a.RecipeName,
                         b.StatusDetail,
                         a.TimeStamp
                     };
            var result = await db.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            List<ModelStatus> res = new List<ModelStatus>();
            foreach (var item in result)
            {
                ModelStatus mds = new ModelStatus();
                mds.status = item.StatusDetail;
                mds.recipeName = item.RecipeName;
                mds.timestamp = (DateTime)item.TimeStamp;
                res.Add(mds);
            }
            return res;
        }
        public async Task<List<ModelStatus>?> modelList()
        {
            var db = from a in _dbcontext.TblTrainingModelDetails
                     join b in _dbcontext.TblTrainingStatusDetails
                     on a.TrainingStatus equals b.StatusId
                     where a.Activeflag == true
                     orderby a.TimeStamp ascending
                     select new
                     {
                         a.RecipeName,
                         b.StatusDetail,
                         a.TimeStamp
                     };
            var result = await db.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            List<ModelStatus> res = new List<ModelStatus>();
            foreach (var item in result)
            {
                ModelStatus mds = new ModelStatus();
                mds.status = item.StatusDetail;
                mds.recipeName = item.RecipeName;
                mds.timestamp = (DateTime)item.TimeStamp;
                res.Add(mds);
            }
            return res;
        }

        public async Task<List<ModelStatus>?> modelOnTrainingInQueue()
        {
            var ontraining = await modelList(StatusMode.OnTraining);
            var inqueue = await modelList(StatusMode.InQueue);

            List<ModelStatus> res = new List<ModelStatus>();
            if(ontraining != null)
                foreach(var item in ontraining)
                {
                    res.Add(item);
                }
            if(inqueue != null)
                foreach(var item in inqueue)
                {
                    res.Add(item);
                }
            return res;
            
        }


        public async Task<AITrainingModel?> modelFinishedDetail(string recipeName,bool reqImageAll = false)
        {
            var db = (from a in _dbcontext.TblTrainingModelDetails
                     where a.RecipeName == recipeName.Trim() && a.TrainingStatus == 3 && a.Activeflag == true
                     select a).Distinct();
            var result = await db.ToListAsync();
            if (result == null)
            {
                return null;
            }
            else if (result.Count == 0)
            {
                return null;
            }
            else
            {
                var trainingDetail = JsonConvert.DeserializeObject<UploadFileModel>(result[0].TrainingParameter);

                var filters = new string[] { "jpg", "jpeg", "png", "tiff", "bmp", "hobj" };
                var frontPathFile = GetFilesFrom(result[0].FrontPath, filters, true);
                var sidePathFile = GetFilesFrom(result[0].SidePath1, filters, true);
                var side2PathFile = GetFilesFrom(result[0].SidePath2, filters, true);
                //string FrontImage = Path.Combine(result[0].FrontPath)

                //var ImgPath = (new PathProcess())._imageSamplePath(result[0].RecipeName);
                //foreach(var item in ImgPath)
                //{
                //    if(!File.Exists(item))
                //        return null;
                //}
                


                ImageResultModel front = new ImageResultModel();
                ImageResultModel side1 = new ImageResultModel();
                ImageResultModel side2 = new ImageResultModel();

                front.sample_image = img2Base64(Path.Combine(result[0].FrontPath, "sample_image.jpg"));
                side1.sample_image = img2Base64(Path.Combine(result[0].SidePath1, "sample_image.jpg"));
                side2.sample_image = img2Base64(Path.Combine(result[0].SidePath2, "sample_image.jpg"));

                if(reqImageAll)
                {
                    front.absolute_confusion_matrix = img2Base64(Path.Combine(result[0].FrontPath, "absolute_confusion_matrix.png"));
                    front.score_legend = img2Base64(Path.Combine(result[0].FrontPath, "score_legend.png"));
                    front.pie_charts_precision = img2Base64(Path.Combine(result[0].FrontPath, "pie_charts_precision.png"));
                    front.pie_charts_recall = img2Base64(Path.Combine(result[0].FrontPath, "pie_charts_recall.png"));
                    front.score_histogram = img2Base64(Path.Combine(result[0].FrontPath, "score_histogram.png"));


                    side1.absolute_confusion_matrix = img2Base64(Path.Combine(result[0].SidePath1, "absolute_confusion_matrix.png"));
                    side1.score_legend = img2Base64(Path.Combine(result[0].SidePath1, "score_legend.png"));
                    side1.pie_charts_precision = img2Base64(Path.Combine(result[0].SidePath1, "pie_charts_precision.png"));
                    side1.pie_charts_recall = img2Base64(Path.Combine(result[0].SidePath1, "pie_charts_recall.png"));
                    side1.score_histogram = img2Base64(Path.Combine(result[0].SidePath1, "score_histogram.png"));

                    side2.absolute_confusion_matrix = img2Base64(Path.Combine(result[0].SidePath2, "absolute_confusion_matrix.png"));
                    side2.score_legend = img2Base64(Path.Combine(result[0].SidePath2, "score_legend.png"));
                    side2.pie_charts_precision = img2Base64(Path.Combine(result[0].SidePath2, "pie_charts_precision.png"));
                    side2.pie_charts_recall = img2Base64(Path.Combine(result[0].SidePath2, "pie_charts_recall.png"));
                    side2.score_histogram = img2Base64(Path.Combine(result[0].SidePath2, "score_histogram.png"));

                    string frontPath = Path.Combine(result[0].FrontPath, "threshold_result.json");
                    string side1Path = Path.Combine(result[0].SidePath1, "threshold_result.json");
                    string side2Path = Path.Combine(result[0].SidePath2, "threshold_result.json");
                    if (File.Exists(frontPath))
                    {
                        front.anomalyThreshold = JsonConvert.DeserializeObject<AnomalyThreshold>(File.ReadAllText(frontPath));
                    }
                    if (File.Exists(side1Path))
                    {
                        side1.anomalyThreshold = JsonConvert.DeserializeObject<AnomalyThreshold>(File.ReadAllText(side1Path));
                    }
                    if(File.Exists(side2Path))
                    {
                        side2.anomalyThreshold = JsonConvert.DeserializeObject<AnomalyThreshold>(File.ReadAllText(side2Path));
                    }


                }

                return new AITrainingModel
                {
                    resultFront = front,
                    resultSide1 = side1,
                    resultSide2 = side2,
                    recipeName = result[0].RecipeName,
                    trainingFromMC = result[0].MachineName,
                    trainingDateTime = result[0].TrainingDate,
                    trainingFinished = result[0].TrainingFinish,
                    pretrainedDL = trainingDetail.pretrainedDL,
                    hyperDLParam = trainingDetail.hyperDLParam,
                    generalDLParam = trainingDetail.generalDLParam,
                };
            }
        }
        public async Task<UploadFileModel?> getTrainingData(string recipeName)
        {
            var db = from a in _dbcontext.TblTrainingModelDetails
                     where a.RecipeName == recipeName && (a.TrainingStatus == 1 || a.TrainingStatus == 2) && a.Activeflag == true
                     select a;
            var result = await db.ToListAsync();
            if (result == null)
            {
                return null;
            }
            else if (result.Count == 0)
            {
                return null;
            }
            else
            {
                var trainingDetail = JsonConvert.DeserializeObject<UploadFileModel>(result[0].TrainingParameter);
                return trainingDetail;
            }
        }

        public async Task<bool> changeModeToOnTraining(string recipeName)
        {
            try
            {
                var db = _dbcontext.TblTrainingModelDetails.First(a => a.RecipeName == recipeName && a.Activeflag == true && a.TrainingStatus == 1);
                if (db == null)
                    throw new Exception($"No data {recipeName} in system");
                db.TrainingStatus = 2;
                db.TrainingDate = DateTime.Now;
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> changeModeToError(ErrorTrainingModel dataItem)
        {
            try
            {


                var db = await _dbcontext.TblTrainingModelDetails.FirstAsync(a => a.RecipeName == dataItem.recipe && a.Activeflag == true && a.TrainingStatus == 2);
                if (db == null)
                    throw new Exception($"No data {dataItem.recipe} in system");
                db.TrainingStatus = 4;
                db.TrainingFinish = DateTime.Now;
                db.ErrorRemark = dataItem.msg;
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> changeModeToFinish(FinishedTrainingModel dataItem)
        {
            try
            {
                var db = _dbcontext.TblTrainingModelDetails.First(a => a.RecipeName == dataItem.recipe &&
                                                                       a.Activeflag == true &&
                                                                       a.TrainingStatus == 2);
                if (db == null)
                    throw new Exception($"No data {dataItem.recipe} in system");
                db.TrainingStatus = 3;
                db.TrainingFinish = DateTime.Now;
                db.ModelPath = dataItem.modelPath;
                db.FrontPath = dataItem.frontPath;
                db.SidePath1 = dataItem.sidePath1;
                db.SidePath2 = dataItem.sidePath2;
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private bool haveFile(string fileName)
        {
            string path = Path.Combine(PathProcess._uploadPath,fileName);
            return File.Exists(path);
        }
        public async Task<string> uploadTrainingModelDetail(UploadFileModel modelDetail)
        {
            bool inuse = await nameInUse(modelDetail.recipeName);
            if (inuse)
                return "InUse";

            bool front = haveFile(modelDetail.fileUpload.zipNameFront);
            if (!front)
                return ($"Not have file '{modelDetail.fileUpload.zipNameFront}' in system");

            bool side1 = haveFile(modelDetail.fileUpload.zipNameSide1);
            if (!side1)
                return ($"Not have file '{modelDetail.fileUpload.zipNameSide1}' in system");

            bool side2 = haveFile(modelDetail.fileUpload.zipNameSide2);
            if (!side2)
                return ($"Not have file '{modelDetail.fileUpload.zipNameSide2}' in system");


            
            TblTrainingModelDetail detail = new TblTrainingModelDetail();
            detail.MachineName = modelDetail.machineName.Trim();
            detail.RecipeName = modelDetail.recipeName.Trim();
            detail.TrainingParameter = JsonConvert.SerializeObject(modelDetail);
            detail.TrainingStatus = 1;
            _dbcontext.TblTrainingModelDetails.Add(detail);
            await _dbcontext.SaveChangesAsync();
            return "OK";
        }
    }
}