using System;
using System.Collections.Generic;

namespace USG_Anormaly_Server.Models.db
{
    public partial class TblTrainingModelDetail
    {
        public int Item { get; set; }
        public string? MachineName { get; set; }
        public string? RecipeName { get; set; }
        public string? TrainingParameter { get; set; }
        public string? FrontPath { get; set; }
        public string? SidePath1 { get; set; }
        public string? SidePath2 { get; set; }
        public DateTime? TimeStamp { get; set; }
        public DateTime? TrainingDate { get; set; }
        public DateTime? TrainingFinish { get; set; }
        public int? TrainingStatus { get; set; }
        public string? ModelPath { get; set; }
        public string? ErrorRemark { get; set; }
        public bool? Activeflag { get; set; }
    }
}
