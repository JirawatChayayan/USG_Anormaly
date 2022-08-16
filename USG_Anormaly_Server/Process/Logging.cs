
using Newtonsoft.Json;
using USG_Anormaly_Server.Models;

namespace USG_Anormaly_Server
{
    public class Logging
    {
        private readonly usg_anormaly_mvi_systemContext _dbcontext;
        public Logging(usg_anormaly_mvi_systemContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> InsertLogTraining(LogTrainingInsertModel dataItem)
        {
            if (dataItem == null)
                return false;
            if (dataItem.logLevel == "" || dataItem.logLevel == null)
                return false;
            if (dataItem.logMessage == "" || dataItem.logMessage == null)
                return false;
            //var db = from a in _dbcontext.TblStatusTrainingLogs
            TblStatusTrainingLog trainingLog = new TblStatusTrainingLog();
            trainingLog.LogLevel = dataItem.logLevel;
            trainingLog.LogMessage = dataItem.logMessage;
            trainingLog.Activeflag = true;
            _dbcontext.TblStatusTrainingLogs.Add(trainingLog);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        public async Task<List<LogTrainingModel>> getLogTraining(DateTime fromDate, DateTime? toDate)
        {
            if(toDate == null)
                toDate = DateTime.Now;
            var db = from a in _dbcontext.TblStatusTrainingLogs
                     where a.Activeflag == true && (a.TimeStamp > fromDate && a.TimeStamp < toDate)
                     select new
                     {
                         a.LogLevel,
                         a.LogMessage,
                         a.TimeStamp,
                     };
            var data = await db.ToListAsync();
            if (data == null)
                throw new Exception($"Not found data training log from {fromDate} to {toDate}");
            List<LogTrainingModel> res = new List<LogTrainingModel>();  
            foreach(var val in data)
            {
                res.Add(new LogTrainingModel
                {
                    logLevel = val.LogLevel,
                    logMessage = val.LogMessage,
                    timeStamp = val.TimeStamp,
                });
            }
            return res;
        }

        public async Task<bool> InsertLogInfer(LogInferenceInsertModel dataItem)
        {
            if (dataItem == null)
                return false;
            if (dataItem.camera == "" || dataItem.camera == null)
                return false;
            if (dataItem.rejectPosition == "" || dataItem.rejectPosition == null)
                return false;
            if (dataItem.clientId == "" || dataItem.clientId == null)
                return false;
            if (dataItem.modelName == "" || dataItem.modelName == null)
                return false;
            TblInferenceLog inferenceLog = new TblInferenceLog();
            inferenceLog.ClientID = dataItem.clientId;
            inferenceLog.ModelName = dataItem.modelName;
            inferenceLog.Result = dataItem.result;
            inferenceLog.Camera = dataItem.camera;
            inferenceLog.RejectPosition = dataItem.rejectPosition;
            inferenceLog.Remark = dataItem.remark;
            inferenceLog.ProcessTime = dataItem.processTime;
            inferenceLog.Activeflag = true;
            _dbcontext.TblInferenceLogs.Add(inferenceLog);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        public async Task<List<LogInferenceModel>> GetInferenceLogs(DateTime fromDate, DateTime? toDate)
        {
            if (toDate == null)
                toDate = DateTime.Now;
            var db = from a in _dbcontext.TblInferenceLogs
                     where a.Activeflag == true && (a.TimeStamp > fromDate && a.TimeStamp < toDate)
                     select new
                     {
                         a.ClientID,
                         a.ModelName,
                         a.Result,
                         a.Camera,
                         a.ProcessTime,
                         a.RejectPosition,
                         a.Remark,
                         a.TimeStamp
                     };
            var data = await db.ToListAsync();
            if (data == null)
                throw new Exception($"Not found data inference log from {fromDate} to {toDate}");
            List<LogInferenceModel> res = new List<LogInferenceModel>();
            foreach (var val in data)
            {
                res.Add(new LogInferenceModel
                {
                    clientId = val.ClientID,
                    modelName = val.ModelName,
                    result = val.Result,
                    camera = val.Camera,
                    processTime = val.ProcessTime,
                    rejectPosition = val.RejectPosition,
                    remark = val.Remark,
                    timeStamp = val.TimeStamp,
                });
            }
            return res;
        }
    }
}
