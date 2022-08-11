using System;
using System.Collections.Generic;

namespace USG_Anormaly_Server.Models.db
{
    public partial class TblTrainingStatusDetail
    {
        public int StatusId { get; set; }
        public string? StatusDetail { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Activeflag { get; set; }
    }
    public partial class TrainingStatusDetail
    {
        public int StatusId { get; set; }
        public string? StatusDetail { get; set; }
    }
}
