namespace USG_Anormaly_Server.Models
{
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
        public string? zipNameFront { get; set; }
        public string? zipNameSide1 { get; set; }
        public string? zipNameSide2 { get; set; }
    }
    public class UploadFileModel
    {
        public string machineName { get; set; }
        public string recipeName { get; set; }
        public string pretrainedDL { get; set; } = "initial_dl_anomaly_medium.hdl";
        public GeneralDLParam generalDLParam { get; set; }
        public HyperDLParam hyperDLParam { get; set; }
        public FileListUpload fileUpload { get; set; }
        public UploadFileModel()
        {
            machineName = Environment.MachineName;
            pretrainedDL = "initial_dl_anomaly_medium.hdl";
            generalDLParam = new GeneralDLParam();
            hyperDLParam = new HyperDLParam();
        }
    }

    public class AnomalyThreshold
    {
        public string? anoSegmentThreshold { get; set; }
        public string? anoClassificationThreshold {get;set;}
    }

    public class ImageResultModel
    {
        public string? absolute_confusion_matrix { get; set; }
        public string? score_histogram { get; set; }
        public string? pie_charts_precision { get; set; }
        public string? pie_charts_recall { get; set; }
        public string? score_legend { get; set; }
        public string? sample_image { get; set; }

        public AnomalyThreshold? anomalyThreshold { get; set; }

    }

    public class AITrainingModel
    {
        public ImageResultModel? resultFront { get; set; }
        public ImageResultModel? resultSide1 { get; set; }
        public ImageResultModel? resultSide2 { get; set; }
        public string? trainingFromMC { get; set; }
        public string? recipeName { get; set; }
        public DateTime? trainingDateTime { get; set; }
        public DateTime? trainingFinished { get; set; }
        public string pretrainedDL { get; set; }
        public GeneralDLParam generalDLParam { get;set; }
        public HyperDLParam hyperDLParam { get; set; }
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

    public class ModelStatus
    {
        public string recipeName { get; set; }
        public string status { get; set; }
        public DateTime timestamp { get; set; }
    }

}
