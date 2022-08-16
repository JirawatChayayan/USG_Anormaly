using System;
using System.Collections.Generic;
namespace USG_Anormaly_Server.Models.db
{
    public partial class TblInferenceLog
    {
        public int Item { get; set; }
        public string? ClientID { get; set; }
        public string? ModelName { get; set; }
        public bool? Result { get; set; }
        public string? RejectPosition { get; set; }
        public string? Camera { get; set; }
        public double? ProcessTime { get; set; }
        public string? Remark { get; set; }
        public DateTime? TimeStamp { get; set; }
        public bool? Activeflag { get; set; }
    }
}
