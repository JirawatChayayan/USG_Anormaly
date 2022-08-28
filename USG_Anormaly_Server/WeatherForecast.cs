
namespace USG_Anormaly_Server
{

    public class PathProcess
    {
        public static string _mainPath
        {
            get 
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false);
                IConfiguration configuration = builder.Build();
                string path = configuration.GetValue<string>("MainFolder");
                createFolder(path);
                return path;
            }
        } 
        public static string _uploadPath
        {
            get
            {
                string uploadPath = Path.Combine(_mainPath, "FileUpload");
                createFolder(uploadPath);
                return uploadPath;
            }
        }
        public static string _modelPath
        {
            get
            {
                string modelPath = Path.Combine(_mainPath, "DLModel");
                createFolder(modelPath);
                return modelPath;
            }
        }
        public static string _modelUpload
        {
            get
            {
                string modelPath = Path.Combine(_mainPath, "ModelUpload");
                createFolder(modelPath);
                return modelPath;
            }
        }
        public string[] _imageSamplePath(string recipe)
        {
            string path = Path.Combine(_modelPath, "SampleImg");
            createFolder(path);
            return new string[]
            {
                    Path.Combine(path,"front.jpg"),
                    Path.Combine(path,"side1.jpg"),
                    Path.Combine(path,"side2.jpg")
            };
        }
        private static void createFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
    public class WeatherForecast
    {

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}