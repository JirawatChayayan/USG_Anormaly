using System;
using System.Collections.Generic;

namespace USG_Anormaly_Server.Models.db
{
    public partial class TblStatusTrainingLog
    {
        public int Item { get; set; }
        public string? LogMessage { get; set; }
        public string? LogLevel { get; set; }
        public DateTime? TimeStamp { get; set; }
        public bool? Activeflag { get; set; }
    }
}
