using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace USG_Anormaly_lib
{
    public static class AnormalyPathProcess
    {
        static string _path = null;
        private static void checkDrivesInPC()
        {
            string dir = "";
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            foreach (DriveInfo drive in driveInfo)
            {
                dir = Path.Combine(drive.Name, "Anormaly_configuration");
                if (Directory.Exists(dir))
                {
                    _path = dir;
                    return;
                }
            }

            var a = (from b in driveInfo
                     where b.DriveType == DriveType.Fixed
                     orderby b.TotalSize descending
                     select b).Take(1);

            dir = Path.Combine(a.ToArray()[0].Name, "Anormaly_configuration");
            _path = dir;
        }
        public static void createPath(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static string mainPath 
        {
            get
            {
                if(_path == null)
                {
                    checkDrivesInPC();
                }
                string path = _path;
                createPath(path);
                return path;
            }
        }
        public static string zipPath
        {
            get
            {
                string path = Path.Combine(mainPath, "ZipModel");
                createPath(path);
                return path;
            }
        }

        public static string chunkPath
        {
            get
            {
                string path = Path.Combine(mainPath, "chunkData");
                createPath(path);
                return path;
            }
        }
    }
    public static class ConfigPath
    {
        public static string mainConfig
        {
            get
            {
                string path = Path.Combine(AnormalyPathProcess.mainPath, "Config");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }     
    }
    public static class CameraConfigPath
    {
        public static string cameraConfig
        {
            get
            {
                string path = Path.Combine(ConfigPath.mainConfig, "CameraConfig");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
        public static string cameraParam
        {
            get
            {
                string path = Path.Combine(cameraConfig, "CameraParam");
                AnormalyPathProcess.createPath(path);
                return Path.Combine(path, "config.json");
            }
        }
        /// <summary>
        /// 0 Param
        /// 1 Pose
        /// </summary>
        public static string[] cameraCalibrate
        {
            get
            {
                string path = Path.Combine(cameraConfig, "CameraCalibrateFile");
                AnormalyPathProcess.createPath(path);
                return new string[2] { Path.Combine(path, "CamFront_Param.cal"),Path.Combine(path,"CamFront_Pose.dat") };
            }
        }
    }
    public static class TrainingCacheFilePath
    {
        public static string cacheMainPath
        {
            get
            {
                string path = Path.Combine(AnormalyPathProcess.mainPath, "TrainingCache");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
        public static string frontCachePath
        {
            get 
            {
                string path = Path.Combine(cacheMainPath, "FrontCamDataSet");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
        public static string sideCachePath1
        {
            get
            {
                string path = Path.Combine(cacheMainPath, "SideCamDataSet1");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
        public static string sideCachePath2
        {
            get
            {
                string path = Path.Combine(cacheMainPath, "SideCamDataSet2");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
    }
    public static class UploadPath
    {
        public static string frontCacheZipPath
        {
            get
            {
                string path = Path.Combine(AnormalyPathProcess.zipPath, "FrontCamDataSet","good");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
        public static string sideCacheZipPath1
        {
            get
            {
                string path = Path.Combine(AnormalyPathProcess.zipPath, "SideCamDataSet1","good");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
        public static string sideCacheZipPath2
        {
            get
            {
                string path = Path.Combine(AnormalyPathProcess.zipPath, "SideCamDataSet2","good");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }


        public static string frontForzip
        {
            get
            {
                string path = Path.Combine(AnormalyPathProcess.zipPath, "FrontCamDataSet");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
        public static string side1Forzip
        {
            get
            {
                string path = Path.Combine(AnormalyPathProcess.zipPath, "SideCamDataSet1");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
        public static string side2Forzip
        {
            get
            {
                string path = Path.Combine(AnormalyPathProcess.zipPath, "SideCamDataSet2");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }

        public static string zipSave
        {
            get
            {
                string path = Path.Combine(AnormalyPathProcess.zipPath,"ZipSave");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
    }
    public static class ServerConfigPath
    {
        public static string serverConfigPath
        {
            get
            {
                string path = Path.Combine(ConfigPath.mainConfig, "ServerConfig");
                AnormalyPathProcess.createPath(path);
                return path;
            }
        }
    }

}
