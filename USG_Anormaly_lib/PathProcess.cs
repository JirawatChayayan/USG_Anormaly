using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USG_Anormaly_lib;

namespace USG_Anormaly_DL_lib
{

    public class ResultImagePath
    {
        //HOperatorSet.DumpWindow(Hwin_absolute_confusion_matrix.HalconWindow, "png", "D:/imgdump1.png");
        //HOperatorSet.DumpWindow(Hwin_score_histogram.HalconWindow, "png", "D:/imgdump2.png");
        //HOperatorSet.DumpWindow(Hwin_pie_charts_precision.HalconWindow, "png", "D:/imgdump3.png");
        //HOperatorSet.DumpWindow(Hwin_pie_charts_recall.HalconWindow, "png", "D:/imgdump4.png");
        //HOperatorSet.DumpWindow(Hwin_score_legend.HalconWindow, "png", "D:/imgdump5.png");
        public string main_path { get; set; }
        public string absolute_confusion_matrix { get; set; }
        public string score_histogram { get; set; }
        public string pie_charts_precision { get; set; }
        public string pie_charts_recall { get; set; }
        public string score_legend { get; set; }
        public string sample_image { get; set; }
        public string threshold_Result { get; set; }
    }

    public class ModelPath
    {
        public string dataset { get; set; }
        public string model { get; set; }
    }

    public static class PathProcess
    {

        static string _path = null;
        private static void checkDrivesInPC()
        {
            string dir = "";
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            foreach (DriveInfo drive in driveInfo)
            {
                dir = Path.Combine(drive.Name, "AnormalyModelUpload");
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

            dir = Path.Combine(a.ToArray()[0].Name, "AnormalyModelUpload");
            _path = dir;
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
                createFolder(path);
                return path;
            }
        }
        public static string uploadPath
        {
            get
            {
                string uploadPath = Path.Combine(mainPath, "FileUpload");
                createFolder(uploadPath);
                return uploadPath;
            }
        }
        public static string modelPath
        {
            get
            {
                string modelPath = Path.Combine(mainPath, "DLModel");
                createFolder(modelPath);
                return modelPath;
            }
        }
        public static string modelRecipeFolder(string recipeName)
        {
            string path = Path.Combine(modelPath, recipeName);
            createFolder(path);
            return path;

        }
        public static string frontImgDatasetFolder(string recipeName)
        {
            string path = Path.Combine(modelRecipeFolder(recipeName), "FrontCamDataSet");
            createFolder(path);
            return path;

        }
        public static string side1DatasetFolder(string recipeName)
        {
            string path = Path.Combine(modelRecipeFolder(recipeName), "SideCamDataSet1");
            createFolder(path);
            return path;

        }
        public static string side2DatasetFolder(string recipeName)
        {
            string path = Path.Combine(modelRecipeFolder(recipeName), "SideCamDataSet2");
            createFolder(path);
            return path;

        }

        public static string recipeModelFolder(string recipeName)
        {
            string path = Path.Combine(modelRecipeFolder(recipeName), "Model");
            createFolder(path);
            return path;
        }

        public static string preProcessFolder(string recipeName)
        {
            string path = Path.Combine(recipeModelFolder(recipeName), "PreProcess");
            createFolder(path);
            return path;
        }

        public static ModelPath modelSavePath(string recipename,CameraIdx idx)
        {
            string path = recipeModelFolder(recipename);
            ModelPath pathModel = new ModelPath();
            if (idx == CameraIdx.Front)
            {
                pathModel.model = Path.Combine(path,"front_model.hdl");
                pathModel.dataset = Path.Combine(path, "front_dataset.hdict");
            }
            else if (idx == CameraIdx.Side)
            {
                pathModel.model = Path.Combine(path, "side1_model.hdl");
                pathModel.dataset = Path.Combine(path, "side1_dataset.hdict");
            }
            else
            {
                pathModel.model = Path.Combine(path, "side2_model.hdl");
                pathModel.dataset = Path.Combine(path, "side2_dataset.hdict");
            }
            return pathModel;
        }

        public static string preprocessPath(string recipename, CameraIdx idx)
        {
            string path = preProcessFolder(recipename);
            if (idx == CameraIdx.Front)
            {
                path = Path.Combine(path, "front");
                createFolder(path);
            }
            else if (idx == CameraIdx.Side)
            {
                path = Path.Combine(path, "side1");
                createFolder(path);
            }
            else
            {
                path = Path.Combine(path, "side2");
                createFolder(path);
            }
            return path;
        }

        public static ResultImagePath trainingrResultSavePath(string recipename, CameraIdx idx)
        {
            string path = Path.Combine(modelRecipeFolder(recipename), "Model","result");
            createFolder(path);

            string key = "side2";

            if (idx == CameraIdx.Front)
                key = "front";
            else if (idx == CameraIdx.Side)
                key = "side1";
            else
                key = "side2";
            path = Path.Combine(modelRecipeFolder(recipename), "Model", "result",key);
            createFolder(path);

            ResultImagePath imgPath = new ResultImagePath();
            imgPath.main_path = path;
            imgPath.absolute_confusion_matrix = Path.Combine(path, "absolute_confusion_matrix.png");
            imgPath.score_histogram = Path.Combine(path, "score_histogram.png");
            imgPath.pie_charts_precision = Path.Combine(path, "pie_charts_precision.png");
            imgPath.pie_charts_recall = Path.Combine(path, "pie_charts_recall.png");
            imgPath.score_legend = Path.Combine(path, "score_legend.png");
            imgPath.sample_image = Path.Combine(path, "sample_image.jpg");
            imgPath.threshold_Result = Path.Combine(path, "threshold_result.json");
            return imgPath;
        }

        public static void createFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
