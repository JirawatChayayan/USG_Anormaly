using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using USG_Anormaly_lib;

namespace USG_Anormaly_DL_lib
{
    public class DL_Training
    {
        public void training(UploadFileModel dataItem , CameraIdx idx)
        {
            DL_AD_GC dlTraining = new DL_AD_GC();
            // Step 0: read_dl_dataset_anomaly
            string datasetPath = "";
            if (idx == CameraIdx.Front)
                datasetPath = PathProcess.frontImgDatasetFolder(dataItem.recipeName);
            else if (idx == CameraIdx.Side)
                datasetPath = PathProcess.side1DatasetFolder(dataItem.recipeName);
            else if (idx == CameraIdx.Side2)
                datasetPath = PathProcess.side2DatasetFolder(dataItem.recipeName);
            DirectoryInfo directoryInfo = new DirectoryInfo(datasetPath);
            var dirs = directoryInfo.GetDirectories("*", SearchOption.TopDirectoryOnly);

            string[] imageClass = new string[dirs.Length];
            int i = 0;
            foreach(var dir in dirs)
            {
                imageClass[i] = dir.Name;
                i += 1;
            }

            string camera = "Front";
            if (idx == CameraIdx.Front)
                camera = "Front";
            else if (idx == CameraIdx.Side)
                camera = "Side1";
            else
                camera = "Side2";


            HTuple GenParamDataset = new HTuple();
            GenParamDataset.Dispose();

            HOperatorSet.CreateDict(out GenParamDataset);
            HOperatorSet.SetDictTuple(GenParamDataset, "image_sub_dirs", imageClass); //new string[] { "good" }


            HTuple DLDataset = new HTuple(); DLDataset.Dispose();
            HTuple DLModelHandle = new HTuple(); DLModelHandle.Dispose();
            HTuple DLPreprocessParam = new HTuple(); DLPreprocessParam.Dispose();
            HTuple DL_DictHandle_AD = new HTuple(); DL_DictHandle_AD.Dispose();
            HTuple TrainParam = new HTuple(); TrainParam.Dispose();
            HTuple DLDatasetFileName = new HTuple(); DLDatasetFileName.Dispose();

            HTuple TrainResults = new HTuple(); TrainResults.Dispose();
            HTuple TrainInfos = new HTuple(); TrainInfos.Dispose();
            HTuple EvaluationInfos = new HTuple(); EvaluationInfos.Dispose();
            HTuple DLDevice = new HTuple(); DLDevice.Dispose();

            HTuple AnomalySegmentationThreshold = new HTuple(); AnomalySegmentationThreshold.Dispose();
            HTuple AnomalyClassificationThresholds = new HTuple(); AnomalyClassificationThresholds.Dispose();
            HTuple EvaluationResult = new HTuple(); EvaluationResult.Dispose();
            HTuple EvalParams = new HTuple(); EvalParams.Dispose();

            dlTraining.read_dl_dataset_anomaly(datasetPath, 
                                               new HTuple(), 
                                               new HTuple(), 
                                               new HTuple(), 
                                               GenParamDataset, 
                                               out DLDataset);

            Program.msgManage.msg($"Training {camera}", $"Step 1: Split DL dataset {dataItem.generalDLParam.trainingPercent}/{dataItem.generalDLParam.validatePercent}/{100-(dataItem.generalDLParam.trainingPercent + dataItem.generalDLParam.validatePercent)}", LogLevel.INFO);
            // Step 1: split_dl_dataset 
            dlTraining.split_dl_dataset(DLDataset, 
                             dataItem.generalDLParam.trainingPercent,
                             dataItem.generalDLParam.validatePercent, 
                             new HTuple());

            Program.msgManage.msg($"Training {camera}", $"Step 2: Load the anomaly detection model and set key parameters", LogLevel.INFO);
            // Step 2 : Load the anomaly detection model and set key parameters.
            HOperatorSet.ReadDlModel(dataItem.pretrainedDL, out DLModelHandle);
            HOperatorSet.SetDlModelParam(DLModelHandle, "image_width", dataItem.generalDLParam.imgSize.width);
            HOperatorSet.SetDlModelParam(DLModelHandle, "image_height", dataItem.generalDLParam.imgSize.height);
            HOperatorSet.SetDlModelParam(DLModelHandle, "complexity", dataItem.hyperDLParam.complexity);



            // Step 3: Set preprocessing parameters and preprocess the dataset.
            Program.msgManage.msg($"Training {camera}", $"Step 3: Set preprocessing parameters and preprocess the dataset.", LogLevel.INFO);
#if !(Halcon_20_11)
            create_dl_preprocess_param_from_model(DLModelHandle,
                                                 "constant_values",
                                                 "full_domain",
                                                 new HTuple(),
                                                 new HTuple(),
                                                 new HTuple(),
                                                 out DLPreprocessParam);
#else
            create_dl_preprocess_param("anomaly_detection",
                                       dataItem.generalDLParam.imgSize.width,
                                       dataItem.generalDLParam.imgSize.height, 
                                       3, new HTuple(), 
                                       new HTuple(), 
                                       "constant_values", 
                                       "full_domain",
                                       new HTuple(),
                                       new HTuple(), 
                                       new HTuple(), 
                                       new HTuple(), 
                                       out DLPreprocessParam);
#endif

            // Step 4: create_dl_train_param

            Program.msgManage.msg($"Training {camera}", $"Step 4: Create DL training parameter", LogLevel.INFO);

            HOperatorSet.CreateDict(out DL_DictHandle_AD);
            HOperatorSet.SetDictTuple(DL_DictHandle_AD, "error_threshold", dataItem.hyperDLParam.errorThreshold);
            HOperatorSet.SetDictTuple(DL_DictHandle_AD, "domain_ratio", (float)dataItem.hyperDLParam.domainRatio);
            HOperatorSet.SetDictTuple(DL_DictHandle_AD, "regularization_noise", (float)dataItem.hyperDLParam.regularizationNoise);


            dlTraining.create_dl_train_param(DLModelHandle, 
                                  dataItem.generalDLParam.numEpochs, 
                                  new HTuple(), 
                                  0,
                                  73,
                                  "anomaly", 
                                  DL_DictHandle_AD, out TrainParam);


            // Step 5.1: Set processer CPU or GPU
            //the anomaly detection model is trained on the CPU or GPU.
            Program.msgManage.msg($"Training {camera}", $"Step 5: Find processer to train DL on the CPU or GPU.", LogLevel.INFO);
            string computeUnit = "CPU";
            try
            {
                HOperatorSet.QueryAvailableDlDevices((new HTuple("runtime")).TupleConcat("id"), (new HTuple("gpu")).TupleConcat(0), out DLDevice);
                if (DLDevice.Length == 0)
                {
                    HOperatorSet.QueryAvailableDlDevices((new HTuple("runtime")).TupleConcat("id"), (new HTuple("cpu")).TupleConcat(0), out DLDevice);
                    computeUnit = "CPU";
                }
                else
                {
                    computeUnit = "GPU";
                }
                HOperatorSet.SetDlModelParam(DLModelHandle, "device", DLDevice);


            }
            catch (Exception ex)
            {
                HOperatorSet.QueryAvailableDlDevices((new HTuple("runtime")).TupleConcat("id"), (new HTuple("cpu")).TupleConcat(0), out DLDevice);
                HOperatorSet.SetDlModelParam(DLModelHandle, "device", DLDevice);
                computeUnit = "CPU";
            }

            Program.msgManage.msg($"Training {camera}", $"Step 5: Set processer to train DL on the {computeUnit}", LogLevel.INFO);



            string OutputDir = PathProcess.preprocessPath(dataItem.recipeName,idx);
            HTuple PreprocessSettings = new HTuple();
            HOperatorSet.CreateDict(out PreprocessSettings);
#if !(Halcon_22_05)
            HOperatorSet.SetDictTuple(PreprocessSettings, "overwrite_files", 1);
#else
            HOperatorSet.SetDictTuple(PreprocessSettings, "overwrite_files", "true");           
#endif
            dlTraining.preprocess_dl_dataset(DLDataset, 
                                  OutputDir, 
                                  DLPreprocessParam, 
                                  PreprocessSettings, 
                                  out DLDatasetFileName);


            Program.msgManage.msg($"Training {camera}", $"Step 6: Start training DL.", LogLevel.INFO);
            dlTraining.train_dl_model(DLDataset, DLModelHandle, TrainParam, 0, out TrainResults, out TrainInfos, out EvaluationInfos);
            Program.msgManage.msg($"Training {camera}", $"Step 6: Finished training DL.", LogLevel.INFO);


            Program.msgManage.msg($"Training {camera}", $"Step 7: Set model parameter.", LogLevel.INFO);
            HOperatorSet.SetDlModelParam(DLModelHandle, "standard_deviation_factor", (float)dataItem.hyperDLParam.standardDeviationFactor);

            HTuple GenParamThresholds_Display = new HTuple();
            HOperatorSet.CreateDict(out GenParamThresholds_Display);
            HOperatorSet.SetDictTuple(GenParamThresholds_Display, "enable_display", 0);

            HTuple GenParamEvaluation = new HTuple();
            HOperatorSet.CreateDict(out GenParamEvaluation);
            HOperatorSet.SetDictTuple(GenParamEvaluation, "measures", "all");
            HOperatorSet.SetDictTuple(GenParamEvaluation, "anomaly_classification_thresholds", AnomalyClassificationThresholds);

            Program.msgManage.msg($"Training {camera}", $"Step 8: Compute DL anomaly thresholds", LogLevel.INFO);
            dlTraining.compute_dl_anomaly_thresholds(DLModelHandle, DLDataset, GenParamThresholds_Display, out AnomalySegmentationThreshold, out AnomalyClassificationThresholds);
            HOperatorSet.SetDictTuple(GenParamEvaluation, "anomaly_classification_thresholds", AnomalyClassificationThresholds);


            // Step 9: evaluate_dl_model
            Program.msgManage.msg($"Training {camera}", $"Step 9: Evaluate DL model", LogLevel.INFO);
            dlTraining.evaluate_dl_model(DLDataset, DLModelHandle, "split", "test", GenParamEvaluation, out EvaluationResult, out EvalParams);


            Program.msgManage.msg($"Training {camera}", $"Step 10: Save weight model file, clear cache file and return memory to the system.", LogLevel.INFO);
            displayHandle(dataItem.recipeName,
                          idx,
                          AnomalyClassificationThresholds,
                          EvaluationResult,
                          EvalParams,
                          DLModelHandle,
                          AnomalySegmentationThreshold);

            #region clear
            if (DLModelHandle != null)
            {
                try
                {
                    HOperatorSet.ClearDlModel(DLModelHandle);
                    DLModelHandle.Dispose();
                    DLModelHandle = null;
                }
                catch
                {

                }
            }

            if (DLDataset != null)
            {
                try
                {
                    DLDataset.Dispose();
                }
                catch (Exception ex)
                {

                }
            }

            if (DL_DictHandle_AD != null)
            {
                try
                {
                    DL_DictHandle_AD.Dispose();
                }
                catch (Exception ex)
                {

                }
            }

            if (TrainParam != null)
            {
                try
                {
                    TrainParam.Dispose();
                }
                catch (Exception ex)
                {

                }
            }

            if (DLDatasetFileName != null)
            {
                try
                {
                    DLDatasetFileName.Dispose();
                }
                catch (Exception ex)
                {

                }
            }

            if (TrainResults != null)
            {
                try
                {
                    TrainResults.Dispose();
                }
                catch (Exception ex)
                {

                }
            }

            if (TrainInfos != null)
            {
                try
                {
                    TrainInfos.Dispose();
                }
                catch (Exception ex)
                {

                }
            }

            if (EvaluationInfos != null)
            {
                try
                {
                    EvaluationInfos.Dispose();
                }
                catch (Exception ex)
                {

                }
            }

            if (AnomalySegmentationThreshold != null)
            {
                try
                {
                    AnomalySegmentationThreshold.Dispose();
                }
                catch (Exception ex)
                {

                }
            }

            if (AnomalyClassificationThresholds != null)
            {
                try
                {
                    AnomalyClassificationThresholds.Dispose();
                }
                catch (Exception ex)
                {

                }
            }


            if (EvaluationResult != null)
            {
                try
                {
                    EvaluationResult.Dispose();
                }
                catch (Exception ex)
                {

                }
            }

            if (EvalParams != null)
            {
                try
                {
                    EvalParams.Dispose();
                }
                catch (Exception ex)
                {

                }
            }

            #endregion

            Program.msgManage.msg($"Training {camera}", $"Finished training process.", LogLevel.INFO);
        }
        private void displayHandle(string recipeName, CameraIdx idx, HTuple AnomalyClassificationThresholds, HTuple EvaluationResult, HTuple EvalParams, HTuple DLModelHandle, HTuple AnomalySegmentationThreshold)
        {
            HSmartWindowControl Hwin_score_histogram = new HSmartWindowControl();
            HSmartWindowControl Hwin_score_legend = new HSmartWindowControl();
            HSmartWindowControl Hwin_pie_charts_precision = new HSmartWindowControl();
            HSmartWindowControl Hwin_pie_charts_recall = new HSmartWindowControl();
            HSmartWindowControl Hwin_absolute_confusion_matrix = new HSmartWindowControl();

            HTuple ClassificationThresholdIndex = new HTuple(); ClassificationThresholdIndex.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                ClassificationThresholdIndex = (new HTuple(AnomalyClassificationThresholds.TupleLength())) - 1;
            }
            HTuple GenParamDisplay = new HTuple();
            HTuple GenParamWindowDict = new HTuple();
            GenParamDisplay.Dispose();
            HOperatorSet.CreateDict(out GenParamDisplay);
            HOperatorSet.SetDictTuple(GenParamDisplay,
                                      "display_mode",
                                      (new HTuple("score_histogram"))
                                      .TupleConcat("score_legend")
                                      .TupleConcat("pie_charts_precision")
                                      .TupleConcat("pie_charts_recall")
                                      .TupleConcat("absolute_confusion_matrix"));

            GenParamWindowDict.Dispose();
            HOperatorSet.CreateDict(out GenParamWindowDict);
            // Step 5.2: Set Hwindows for display
            HOperatorSet.SetDictTuple(GenParamWindowDict, "window_score_histogram", new HTuple(Hwin_score_histogram.HalconWindow));
            HOperatorSet.SetDictTuple(GenParamWindowDict, "window_score_legend", new HTuple(Hwin_score_legend.HalconWindow));
            HDevWindowStack.Push(Hwin_score_histogram.HalconWindow);
            HDevWindowStack.Push(Hwin_score_legend.HalconWindow);
            //Visualize several evaluation results such as precision, recall, and confusion matrix
            //for a given classification threshold.
            HOperatorSet.SetDictTuple(GenParamWindowDict, "window_pie_charts_precision", new HTuple(Hwin_pie_charts_precision.HalconWindow));
            HOperatorSet.SetDictTuple(GenParamWindowDict, "window_pie_charts_recall", new HTuple(Hwin_pie_charts_recall.HalconWindow));
            HOperatorSet.SetDictTuple(GenParamWindowDict, "window_absolute_confusion_matrix", new HTuple(Hwin_absolute_confusion_matrix.HalconWindow));
            // 'pie_charts_precision', 'pie_charts_recall', 'absolute_confusion_matrix'
            HDevWindowStack.Push(Hwin_pie_charts_precision.HalconWindow);
            HDevWindowStack.Push(Hwin_pie_charts_recall.HalconWindow);
            HDevWindowStack.Push(Hwin_absolute_confusion_matrix.HalconWindow);

            HOperatorSet.SetDictTuple(GenParamDisplay, "classification_threshold_index", ClassificationThresholdIndex);




            HTuple MetaData = new HTuple();
            MetaData.Dispose();
            HOperatorSet.GetDlModelParam(DLModelHandle, "meta_data", out MetaData);
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                HOperatorSet.SetDictTuple(MetaData, "anomaly_segmentation_threshold", AnomalySegmentationThreshold.TupleString("1.16e"));
            }
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                HOperatorSet.SetDictTuple(MetaData, "anomaly_classification_threshold",((AnomalyClassificationThresholds.TupleSelect(ClassificationThresholdIndex))).TupleString("1.16e"));
            }
            HOperatorSet.SetDlModelParam(DLModelHandle, "meta_data", MetaData);
            string anoSegmentThreshold = AnomalySegmentationThreshold.ToString();
            string anoClassificationThreshold = AnomalyClassificationThresholds.ToString();
            //Store the trained model.
            var pathModelSave = PathProcess.modelSavePath(recipeName, idx);
            string OutputDir = PathProcess.preprocessPath(recipeName, idx);
            HOperatorSet.CopyFile(Path.Combine(OutputDir, "dl_dataset.hdict"), pathModelSave.dataset);
            HOperatorSet.WriteDlModel(DLModelHandle, pathModelSave.model);


            if (ClassificationThresholdIndex != null)
            {
                try
                {
                    ClassificationThresholdIndex.Dispose();
                }
                catch (Exception ex)
                {

                }
            }
            GenParamDisplay.Dispose();
            GenParamWindowDict.Dispose();
            MetaData.Dispose();

            #region SaveResultDL

            (new DL_AD_GC()).dev_display_anomaly_detection_evaluation(EvaluationResult, EvalParams, GenParamDisplay, GenParamWindowDict);

            Hwin_score_histogram.SetFullImagePart();
            Hwin_score_legend.SetFullImagePart();
            Hwin_pie_charts_precision.SetFullImagePart();
            Hwin_pie_charts_recall.SetFullImagePart();
            Hwin_absolute_confusion_matrix.SetFullImagePart();

            ResultImagePath resultImage = PathProcess.trainingrResultSavePath(recipeName, idx);
            HOperatorSet.DumpWindow(Hwin_absolute_confusion_matrix.HalconWindow, "png", resultImage.absolute_confusion_matrix);
            HOperatorSet.DumpWindow(Hwin_score_histogram.HalconWindow, "png", resultImage.score_histogram);
            HOperatorSet.DumpWindow(Hwin_pie_charts_precision.HalconWindow, "png", resultImage.pie_charts_precision);
            HOperatorSet.DumpWindow(Hwin_pie_charts_recall.HalconWindow, "png", resultImage.pie_charts_recall);
            HOperatorSet.DumpWindow(Hwin_score_legend.HalconWindow, "png", resultImage.score_legend);
            var thresholdRes = new
            {
                anoSegmentThreshold = anoSegmentThreshold,
                anoClassificationThreshold = anoClassificationThreshold
            };
            File.WriteAllText(resultImage.threshold_Result,JsonConvert.SerializeObject(thresholdRes,Formatting.Indented));

            Hwin_score_histogram.Dispose();
            Hwin_score_legend.Dispose();
            Hwin_pie_charts_precision.Dispose();
            Hwin_pie_charts_recall.Dispose();
            Hwin_absolute_confusion_matrix.Dispose();
            #endregion

            #region ImageSampleResize
            string datasetPath = "";
            if (idx == CameraIdx.Front)
                datasetPath = PathProcess.frontImgDatasetFolder(recipeName);
            else if (idx == CameraIdx.Side)
                datasetPath = PathProcess.side1DatasetFolder(recipeName);
            else if (idx == CameraIdx.Side2)
                datasetPath = PathProcess.side2DatasetFolder(recipeName);
            var filters = new string[] { "jpg", "jpeg", "png", "tiff", "bmp", "hobj" };
            var img =  GetFilesFrom(datasetPath, filters, true);
            HObject imgObj = new HObject(); imgObj.GenEmptyObj(); imgObj.Dispose();
            HObject imgObjZoom = new HObject(); imgObjZoom.GenEmptyObj(); imgObjZoom.Dispose();
            HTuple width = new HTuple(), height = new HTuple();


            HOperatorSet.ReadImage(out imgObj, img[0]);
            HOperatorSet.GetImageSize(imgObj, out width, out height);

            if (width[0].I > 1728 && height[0].I > 1312)
                HOperatorSet.ZoomImageFactor(imgObj, out imgObjZoom, 0.25, 0.25, "constant");
            else if (width[0].I > 864 && height[0].I > 640)
                HOperatorSet.ZoomImageFactor(imgObj, out imgObjZoom, 0.4, 0.4, "constant");
            else
                imgObj = imgObjZoom;

            HOperatorSet.WriteImage(imgObjZoom, "jpeg", 0, resultImage.sample_image);
            imgObj.Dispose();
            imgObjZoom.Dispose();
            width.Dispose();
            height.Dispose();
            #endregion

            #region DeleteFile
            try
            {
                Directory.Delete(OutputDir, true);
            }
            catch (Exception ex)
            {

            }
            try
            {
                Directory.Delete(datasetPath, true);
            }
            catch (Exception ex)
            {

            }
            try
            {
                Directory.Delete(PathProcess.preProcessFolder(recipeName), true);
            }
            catch
            {

            }
            #endregion

        }
        public static List<string> GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, string.Format("*.{0}", filter), searchOption));
            }
            return filesFound;
        }
        public void create_dl_preprocess_param_from_model(HTuple hv_DLModelHandle, HTuple hv_NormalizationType,
                                                          HTuple hv_DomainHandling, HTuple hv_SetBackgroundID, HTuple hv_ClassIDsBackground,
                                                          HTuple hv_GenParam, out HTuple hv_DLPreprocessParam)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_ModelType = new HTuple(), hv_ImageWidth = new HTuple();
            HTuple hv_ImageHeight = new HTuple(), hv_ImageNumChannels = new HTuple();
            HTuple hv_ImageRangeMin = new HTuple(), hv_ImageRangeMax = new HTuple();
            HTuple hv_IgnoreClassIDs = new HTuple(), hv_InstanceType = new HTuple();
            HTuple hv_IsInstanceSegmentation = new HTuple(), hv_IgnoreDirection = new HTuple();
            HTuple hv_ClassIDsNoOrientation = new HTuple();
            HTuple hv_GenParam_COPY_INP_TMP = new HTuple(hv_GenParam);

            // Initialize local and output iconic variables 
            hv_DLPreprocessParam = new HTuple();
            try
            {
                //
                //This procedure creates a dictionary with all parameters needed for preprocessing
                //according to a model provided through DLModelHandle.
                //
                //Get the relevant model parameters.
                hv_ModelType.Dispose();
                HOperatorSet.GetDlModelParam(hv_DLModelHandle, "type", out hv_ModelType);
                hv_ImageWidth.Dispose();
                HOperatorSet.GetDlModelParam(hv_DLModelHandle, "image_width", out hv_ImageWidth);
                hv_ImageHeight.Dispose();
                HOperatorSet.GetDlModelParam(hv_DLModelHandle, "image_height", out hv_ImageHeight);
                hv_ImageNumChannels.Dispose();
                HOperatorSet.GetDlModelParam(hv_DLModelHandle, "image_num_channels", out hv_ImageNumChannels);
                hv_ImageRangeMin.Dispose();
                HOperatorSet.GetDlModelParam(hv_DLModelHandle, "image_range_min", out hv_ImageRangeMin);
                hv_ImageRangeMax.Dispose();
                HOperatorSet.GetDlModelParam(hv_DLModelHandle, "image_range_max", out hv_ImageRangeMax);
                hv_IgnoreClassIDs.Dispose();
                hv_IgnoreClassIDs = new HTuple();
                //
                //Get model specific parameters.
                if ((int)((new HTuple(hv_ModelType.TupleEqual("anomaly_detection"))).TupleOr(
                    new HTuple(hv_ModelType.TupleEqual("gc_anomaly_detection")))) != 0)
                {
                    //No specific parameters for both anomaly detection
                    //and Global Context Anomaly Detection model types.
                }
                else if ((int)(new HTuple(hv_ModelType.TupleEqual("classification"))) != 0)
                {
                    //No classification specific parameters.
                }
                else if ((int)(new HTuple(hv_ModelType.TupleEqual("detection"))) != 0)
                {
                    //Get detection specific parameters.
                    //If GenParam has not been created yet, create it to add new generic parameters.
                    if ((int)(new HTuple((new HTuple(hv_GenParam_COPY_INP_TMP.TupleLength())).TupleEqual(
                        0))) != 0)
                    {
                        hv_GenParam_COPY_INP_TMP.Dispose();
                        HOperatorSet.CreateDict(out hv_GenParam_COPY_INP_TMP);
                    }
                    //Add instance_type.
                    hv_InstanceType.Dispose();
                    HOperatorSet.GetDlModelParam(hv_DLModelHandle, "instance_type", out hv_InstanceType);
                    //If the model can do instance segmentation, the preprocessing instance_type
                    //needs to be 'mask'.
                    hv_IsInstanceSegmentation.Dispose();
                    HOperatorSet.GetDlModelParam(hv_DLModelHandle, "instance_segmentation", out hv_IsInstanceSegmentation);
                    if ((int)(new HTuple(hv_IsInstanceSegmentation.TupleEqual("true"))) != 0)
                    {
                        HOperatorSet.SetDictTuple(hv_GenParam_COPY_INP_TMP, "instance_type", "mask");
                    }
                    else
                    {
                        HOperatorSet.SetDictTuple(hv_GenParam_COPY_INP_TMP, "instance_type", hv_InstanceType);
                    }
                    //For instance_type 'rectangle2', add the boolean ignore_direction and class IDs without orientation.
                    if ((int)(new HTuple(hv_InstanceType.TupleEqual("rectangle2"))) != 0)
                    {
                        hv_IgnoreDirection.Dispose();
                        HOperatorSet.GetDlModelParam(hv_DLModelHandle, "ignore_direction", out hv_IgnoreDirection);
                        if ((int)(new HTuple(hv_IgnoreDirection.TupleEqual("true"))) != 0)
                        {
                            HOperatorSet.SetDictTuple(hv_GenParam_COPY_INP_TMP, "ignore_direction",
                                1);
                        }
                        else if ((int)(new HTuple(hv_IgnoreDirection.TupleEqual("false"))) != 0)
                        {
                            HOperatorSet.SetDictTuple(hv_GenParam_COPY_INP_TMP, "ignore_direction",
                                0);
                        }
                        hv_ClassIDsNoOrientation.Dispose();
                        HOperatorSet.GetDlModelParam(hv_DLModelHandle, "class_ids_no_orientation",
                            out hv_ClassIDsNoOrientation);
                        HOperatorSet.SetDictTuple(hv_GenParam_COPY_INP_TMP, "class_ids_no_orientation",
                            hv_ClassIDsNoOrientation);
                    }
                }
                else if ((int)(new HTuple(hv_ModelType.TupleEqual("segmentation"))) != 0)
                {
                    //Get segmentation specific parameters.
                    hv_IgnoreClassIDs.Dispose();
                    HOperatorSet.GetDlModelParam(hv_DLModelHandle, "ignore_class_ids", out hv_IgnoreClassIDs);
                }
                //
                //Create the dictionary with the preprocessing parameters returned by this procedure.
                hv_DLPreprocessParam.Dispose();
                (new DL_AD_GC()).create_dl_preprocess_param(hv_ModelType, hv_ImageWidth, hv_ImageHeight, hv_ImageNumChannels,
                    hv_ImageRangeMin, hv_ImageRangeMax, hv_NormalizationType, hv_DomainHandling,
                    hv_IgnoreClassIDs, hv_SetBackgroundID, hv_ClassIDsBackground, hv_GenParam_COPY_INP_TMP,
                    out hv_DLPreprocessParam);
                //

                hv_GenParam_COPY_INP_TMP.Dispose();
                hv_ModelType.Dispose();
                hv_ImageWidth.Dispose();
                hv_ImageHeight.Dispose();
                hv_ImageNumChannels.Dispose();
                hv_ImageRangeMin.Dispose();
                hv_ImageRangeMax.Dispose();
                hv_IgnoreClassIDs.Dispose();
                hv_InstanceType.Dispose();
                hv_IsInstanceSegmentation.Dispose();
                hv_IgnoreDirection.Dispose();
                hv_ClassIDsNoOrientation.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_GenParam_COPY_INP_TMP.Dispose();
                hv_ModelType.Dispose();
                hv_ImageWidth.Dispose();
                hv_ImageHeight.Dispose();
                hv_ImageNumChannels.Dispose();
                hv_ImageRangeMin.Dispose();
                hv_ImageRangeMax.Dispose();
                hv_IgnoreClassIDs.Dispose();
                hv_InstanceType.Dispose();
                hv_IsInstanceSegmentation.Dispose();
                hv_IgnoreDirection.Dispose();
                hv_ClassIDsNoOrientation.Dispose();

                throw HDevExpDefaultException;
            }
        }

    }

    public class ZipProcess
    {
        public bool unZip(string zipPath,string destinationPath)
        {
            
            if(!File.Exists(zipPath))
                return false;
            if (!Directory.Exists(destinationPath))
                return false;

            var fileList = Directory.GetFiles(destinationPath,"*",SearchOption.AllDirectories);
            foreach(var file in fileList)
            {
                try
                {
                    File.Delete(file);
                }
                catch(Exception ex)
                {

                }
            }

            ZipFile.ExtractToDirectory(zipPath, destinationPath);
            Console.WriteLine("Extracted Successfully");
            return true;
        }
        public bool deleteZip(string zipPath)
        {
            if(!File.Exists(zipPath))
            {
                return false;
            }
            File.Delete(zipPath);
            return true;
        }
    }
}
