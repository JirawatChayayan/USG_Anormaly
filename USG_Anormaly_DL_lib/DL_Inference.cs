using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using USG_Anormaly_lib;
using BitmapHImage;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Newtonsoft.Json;

namespace USG_Anormaly_DL_lib
{
    public class ImageSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class DL_InferenceResult
    {
        public string anormalyClass { get; set; }
        public double anormalyScore { get; set; }
        public string b64ImgRegion { get; set; }
        public string b64ImgDisp { get; set; } = null;
        public ImageSize trainingImgSize { get; set; }
    }

    public class rejectPos
    {
        public int R1 { get; set; }
        public int C1 { get; set; }
        public int R2 { get; set; }
        public int C2 { get; set; }
    }

    public class DL_Inference
    {

        public DL_InferenceResult inference(out string posRejectAll,string b64img,string recipeName, CameraIdx idx,bool reqImgPaint = false)
        {

            posRejectAll = null;
            DL_InferenceResult result = new DL_InferenceResult();
            //read model
            ModelPath dl_model_path = PathProcess.modelSavePath(recipeName, idx);
            HTuple DLModelHandle = new HTuple(); DLModelHandle.Dispose();
            HTuple DLDataset = new HTuple(); DLDataset.Dispose();

            if (!File.Exists(dl_model_path.model) || !File.Exists(dl_model_path.dataset))
                throw new FileNotFoundException("Not found recipe model file !!!");


            HOperatorSet.ReadDlModel(dl_model_path.model, out DLModelHandle);
            HOperatorSet.ReadDict(dl_model_path.dataset, new HTuple(), new HTuple(), out DLDataset);

            HObject Image = new HObject(); Image.GenEmptyObj();
            Image = (new ImageConvert()).strbase64toHalconImage(b64img);

            HTuple DLPreprocessParam = new HTuple(); DLPreprocessParam.Dispose();
            HTuple MetaData = new HTuple(); MetaData.Dispose();
            HTuple AnomalyClassificationThresholds = new HTuple(); AnomalyClassificationThresholds.Dispose();   
            HTuple AnomalySegmentationThreshold = new HTuple(); AnomalySegmentationThreshold.Dispose();
            HOperatorSet.GetDictTuple(DLDataset, "preprocess_param", out DLPreprocessParam);
            HOperatorSet.GetDlModelParam(DLModelHandle, "meta_data", out MetaData);
            HOperatorSet.GetDictTuple(MetaData, "anomaly_classification_threshold", out AnomalyClassificationThresholds);
            HOperatorSet.GetDictTuple(MetaData, "anomaly_segmentation_threshold", out AnomalySegmentationThreshold);

            HTuple DLResult = new HTuple(); DLResult.Dispose();
            HTuple Result_Class = new HTuple(); Result_Class.Dispose();
            HTuple Result_Confident = new HTuple(); Result_Confident.Dispose();


            DL_AD_GC dlTraining = new DL_AD_GC();

            HTuple DLSample = new HTuple(); DLSample.Dispose();
            // Normal Image Display Mode
            dlTraining.gen_dl_samples_from_images(Image, out DLSample);
            dlTraining.preprocess_dl_samples(DLSample, DLPreprocessParam);

            HTuple DLDevice = new HTuple();
            HOperatorSet.QueryAvailableDlDevices((new HTuple("runtime")).TupleConcat("id"), (new HTuple("cpu")).TupleConcat(0), out DLDevice);
            HOperatorSet.SetDlModelParam(DLModelHandle, "device", DLDevice);


            // Predict
            HOperatorSet.ApplyDlModel(DLModelHandle, DLSample, new HTuple(), out DLResult);
            Task T1 = Task.Run(() =>
            {
                HOperatorSet.ClearDlModel(DLModelHandle);
            });

            //Apply thresholds to classify regions and the entire image.
            dlTraining.threshold_dl_anomaly_results(AnomalySegmentationThreshold.TupleNumber(), 
                                                    AnomalyClassificationThresholds.TupleNumber(), DLResult);

            //Display the inference result.
            //dlTraining.dev_display_dl_data(DLSample, DLResult, DLDataset, (new HTuple("anomaly_result")).TupleConcat("anomaly_image"), new HTuple(), WindowDict);
            HTuple img_width = new HTuple(), img_height = new HTuple();
            HOperatorSet.GetDictTuple(DLResult, "anomaly_class", out Result_Class);
            HOperatorSet.GetDictTuple(DLResult, "anomaly_score", out Result_Confident);
            HOperatorSet.GetDictTuple(DLPreprocessParam, "image_width", out img_width);
            HOperatorSet.GetDictTuple(DLPreprocessParam, "image_height", out img_height);

            HObject AnormalyRegion = new HObject(); AnormalyRegion.GenEmptyObj();
            HOperatorSet.GetDictObject(out AnormalyRegion, DLResult, "anomaly_region");
            
            HObject ImageROI = genImgResult(AnormalyRegion,img_width,img_height);

            result.anormalyScore = Result_Confident[0].D;
            result.anormalyClass = Result_Class[0].S;
            result.trainingImgSize = new ImageSize();
            result.trainingImgSize.Width = img_width[0].I;
            result.trainingImgSize.Height = img_height[0].I;


            HImage imgHRoi = new HImage(ImageROI);
            Bitmap imgROI = (new BitmapHImageConverter()).HImage2Bitmap(imgHRoi);

            result.b64ImgRegion = (new ImageConvert()).image2Base64str(imgROI, ImgFormat.png);

            if(result.anormalyClass == "nok")
            {
                try
                {
                    posRejectAll = JsonConvert.SerializeObject(getRejectPos(ImageROI));
                }
                catch (Exception ex)
                {
                    posRejectAll = null;
                }
            }



            imgROI.Dispose();


            imgHRoi.Dispose();
            ImageROI.Dispose();


            if (reqImgPaint)
            {
                HObject ImgPaint = null;
                ImgPaint = new HObject();
                ImgPaint.GenEmptyObj();
                ImgPaint = genImageDisplay(AnormalyRegion, Image, img_width, img_height);


                HImage imgHPaint = new HImage(ImgPaint);
                Bitmap imgPaint = (new BitmapHImageConverter()).HImage2Bitmap(imgHPaint);
                result.b64ImgDisp = (new ImageConvert()).image2Base64str(imgPaint, ImgFormat.jpg);
                imgPaint.Dispose();
                imgHPaint.Dispose();
                ImgPaint.Dispose();

            }
            else
            {
                result.b64ImgDisp = null;
            }

            
            DLSample.ClearHandle();
            DLResult.ClearHandle();
            DLPreprocessParam.ClearHandle();
            MetaData.ClearHandle();
            T1.Wait();
            DLSample.Dispose();
            DLResult.Dispose();
            DLPreprocessParam.Dispose();
            MetaData.Dispose();
            Result_Class.Dispose();
            Result_Confident.Dispose();
            img_width.Dispose();
            img_height.Dispose();
            AnormalyRegion.Dispose();
            Image.Dispose();
            return result;
        }

        public List<rejectPos> getRejectPos(HObject img)
        {
            HObject reg = new HObject(); reg.GenEmptyObj();
            HObject regcon = new HObject(); regcon.GenEmptyObj();
            HOperatorSet.Threshold(img, out reg, 1, 1);
            HOperatorSet.Connection(reg, out regcon);
            HTuple row1= new HTuple(),col1 = new HTuple(), row2 = new HTuple(), col2 = new HTuple();
            HOperatorSet.SmallestRectangle1(regcon, out row1, out col1, out row2, out col2);
            reg.Dispose();
            regcon.Dispose();
            List <rejectPos> posAll = new List<rejectPos>();
            for (int i=0; i<row1.Length; i++)
            {
                rejectPos pos = new rejectPos();
                pos.R1 = row1[i];
                pos.C1 = col1[i];
                pos.R2 = row2[i];
                pos.C2 = col2[i];
                posAll.Add(pos);
            }
            row1.Dispose();
            row2.Dispose();
            col1.Dispose();
            col2.Dispose();
            return posAll;
        }

        public HObject genImgResult(HObject AnormalyRegion,int ImgWidth,int ImgHeight)
        {
            HObject imgConst = new HObject(); imgConst.GenEmptyObj();
            HObject imgPaint = new HObject(); imgPaint.GenEmptyObj();
            HOperatorSet.GenImageConst(out imgConst, "byte", ImgWidth, ImgHeight);
            HOperatorSet.PaintRegion(AnormalyRegion, imgConst, out imgPaint, 1, "fill");
            imgConst.Dispose();
            return imgPaint;
        }

        public HObject genImageDisplay(HObject AnormalyRegion,HObject ImageInput, int ImgWidth, int ImgHeight)
        {
            HTuple width_input = new HTuple(), height_input = new HTuple();
            HOperatorSet.GetImageSize(ImageInput, out width_input, out height_input);


            double scaleWidth = (width_input[0].I * 1.0) / (ImgWidth * 1.0);
            double scaleHeight = (height_input[0].I * 1.0) / (ImgHeight * 1.0);


            HTuple hommat2DScale = new HTuple();
            HOperatorSet.HomMat2dIdentity(out hommat2DScale);
            HOperatorSet.HomMat2dScale(hommat2DScale, scaleHeight, scaleWidth, 0, 0, out hommat2DScale);


            HObject AnormalyRegionTrans = new HObject(); AnormalyRegionTrans.GenEmptyObj();
            HOperatorSet.AffineTransRegion(AnormalyRegion, out AnormalyRegionTrans, hommat2DScale, "nearest_neighbor");

            HObject imgResult = pr_paintROI(ImageInput, AnormalyRegionTrans, new HTuple(218, 66, 245));

            AnormalyRegionTrans.Dispose();
            hommat2DScale.Dispose();
            return imgResult;
        }

        private HObject pr_paintROI(HObject Image, HObject Region, HTuple colorRGB)
        {




            // Local iconic variables 

            HObject imageRun, Image1 = null, Image2 = null;
            HObject Image3 = null, ImagePaint, ImageAdd1, ImageAdd2;
            HObject Contours, Region1, RegionDilation;

            // Local control variables 

            HTuple Channels = new HTuple();
            HObject ImageResult = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ImageResult);
            HOperatorSet.GenEmptyObj(out imageRun);
            HOperatorSet.GenEmptyObj(out Image1);
            HOperatorSet.GenEmptyObj(out Image2);
            HOperatorSet.GenEmptyObj(out Image3);
            HOperatorSet.GenEmptyObj(out ImagePaint);
            HOperatorSet.GenEmptyObj(out ImageAdd1);
            HOperatorSet.GenEmptyObj(out ImageAdd2);
            HOperatorSet.GenEmptyObj(out Contours);
            HOperatorSet.GenEmptyObj(out Region1);
            HOperatorSet.GenEmptyObj(out RegionDilation);
            try
            {
                Channels.Dispose();
                HOperatorSet.CountChannels(Image, out Channels);
                imageRun.Dispose();
                HOperatorSet.GenEmptyObj(out imageRun);
                if ((int)(new HTuple(Channels.TupleEqual(3))) != 0)
                {
                    imageRun.Dispose();
                    HOperatorSet.CopyImage(Image, out imageRun);
                }
                else
                {
                    Image1.Dispose();
                    HOperatorSet.AccessChannel(Image, out Image1, 1);
                    Image2.Dispose();
                    HOperatorSet.CopyImage(Image1, out Image2);
                    Image3.Dispose();
                    HOperatorSet.CopyImage(Image2, out Image3);
                    imageRun.Dispose();
                    HOperatorSet.Compose3(Image1, Image2, Image3, out imageRun);
                }
                //reduce_domain (imageRun, Region, ImageReduced)
                ImagePaint.Dispose();
                HOperatorSet.PaintRegion(Region, imageRun, out ImagePaint, colorRGB,
                    "fill");
                ImageAdd1.Dispose();
                HOperatorSet.AddImage(imageRun, ImagePaint, out ImageAdd1, 0.5, 0);
                //HObject temp = new HObject(); temp.GenEmptyObj();
                //HObject temp2 = new HObject(); temp2.GenEmptyObj();
                //HObject temp3 = new HObject(); temp3.GenEmptyObj();
                //HOperatorSet.AddImage(ImageAdd1, ImagePaint, out temp, 0.5, 0);
                //ImageAdd1.Dispose();
                //ImageAdd1 = temp;
                //HOperatorSet.AddImage(ImageAdd1, ImagePaint, out temp2, 0.5, 0);
                //ImageAdd1.Dispose();
                //ImageAdd1 = temp2;
                //HOperatorSet.AddImage(ImageAdd1, ImagePaint, out temp3, 0.5, 0);
                //ImageAdd1.Dispose();
                //ImageAdd1 = temp3;


                ImageAdd2.Dispose();
                HOperatorSet.AddImage(imageRun, ImageAdd1, out ImageAdd2, 0.5, 0);
                Contours.Dispose();
                HOperatorSet.GenContourRegionXld(Region, out Contours, "border");
                Region1.Dispose();
                HOperatorSet.GenRegionContourXld(Contours, out Region1, "margin");
                RegionDilation.Dispose();
                HOperatorSet.DilationCircle(Region1, out RegionDilation, 0.95);
                ImageResult.Dispose();
                HOperatorSet.PaintRegion(RegionDilation, ImageAdd2, out ImageResult,
                    colorRGB, "fill");
                //paint_region (Region, ImageAdd2, ImageResult, colorRGB, 'margin')
                imageRun.Dispose();
                Image1.Dispose();
                Image2.Dispose();
                Image3.Dispose();
                ImagePaint.Dispose();
                ImageAdd1.Dispose();
                ImageAdd2.Dispose();
                Contours.Dispose();
                Region1.Dispose();
                RegionDilation.Dispose();

                Channels.Dispose();

                return ImageResult;
            }
            catch (HalconException HDevExpDefaultException)
            {
                imageRun.Dispose();
                Image1.Dispose();
                Image2.Dispose();
                Image3.Dispose();
                ImagePaint.Dispose();
                ImageAdd1.Dispose();
                ImageAdd2.Dispose();
                Contours.Dispose();
                Region1.Dispose();
                RegionDilation.Dispose();

                Channels.Dispose();

                throw HDevExpDefaultException;
            }
        }

    }
}
