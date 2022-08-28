namespace USG_Anormaly_Server.Models
{

    public class FileListDownload
    {
        public string recipe { get; set; }
        public string status { get; set; }
        public FileListUpload files { get; set; }
    }

    public static class MimeTypes
    {
        public static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".zip", "application/zip"}
            };
        }
    }
}
