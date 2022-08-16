namespace USG_Anormaly_Server.Models
{
    public class LogTrainingInsertModel
    {
        public string? logMessage { get; set; }
        public string? logLevel { get; set; }
    }

    public class LogInferenceInsertModel
    {
        public string? clientId { get;set; }
        public string? modelName { get;set; }
        public bool? result { get;set; }
        public string? rejectPosition { get; set; }
        public string? camera { get; set; }
        public double? processTime { get; set; }
        public string? remark { get; set; }
    }

    public class LogTrainingModel
    {
        public string? logMessage { get; set; }
        public string? logLevel { get; set; }
        public DateTime? timeStamp { get; set; }
    }

    public class LogInferenceModel
    {
        public string? clientId { get; set; }
        public string? modelName { get; set; }
        public bool? result { get; set; }
        public string? camera { get; set; }
        public double? processTime { get; set; }
        public string? rejectPosition { get; set; }
        public string? remark { get; set; }
        public DateTime? timeStamp { get; set; }
    }
}
