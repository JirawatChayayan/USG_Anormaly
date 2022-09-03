using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using Newtonsoft.Json;
using System.Diagnostics;


namespace USG_Anormaly_lib
{
    public delegate void captureTime(CameraIdx idx, double time);
    public enum CameraIdx
    {
        Front = 1,
        Side = 2,
        Side2 = 3,
    }
    public class CameraParam
    {
        public int ExposureTime { get; set; } = 5000;
        public int CameraID { get; set; }
        public bool FlipVertical { get; set; } = false;
        public bool FlipHorizontal { get; set; } = false;
    }
    public class CameraParamAll
    {
        public Dictionary<CameraIdx, CameraParam> param { get; set; }

        public CameraParamAll()
        {
            param = new Dictionary<CameraIdx, CameraParam>();
            param[CameraIdx.Front] = new CameraParam();
            param[CameraIdx.Side] = new CameraParam();

            param[CameraIdx.Front].CameraID = 1;
            param[CameraIdx.Side].CameraID = 2;


        }
        public void loadConfig()
        {
            if (!File.Exists(CameraConfigPath.cameraParam))
            {
                saveConfig();
            }
            string data = File.ReadAllText(CameraConfigPath.cameraParam);
            param = JsonConvert.DeserializeObject<Dictionary<CameraIdx, CameraParam>>(data);
        }
        public void saveConfig()
        {
            string serialize = JsonConvert.SerializeObject(param, Formatting.Indented);
            File.WriteAllText(CameraConfigPath.cameraParam, serialize);
        }
    }
    public class CamCalibration
    {
        public HTuple camPose;
        public HTuple calParam;
        public CamCalibration()
        {
            camPose = new HTuple(-0.225425, -0.161473, 0.488293, 358.892, 0.444085, 359.778, 0);
            calParam = new HTuple("area_scan_division", 0.0038423, 2015.9, 1.3992e-06, 1.4e-06, 1296.68, 928.763, 2592, 1944);
        }
        public void load()
        {
            HTuple _calParam = new HTuple();
            HTuple _camPose = new HTuple();
            if (!File.Exists(CameraConfigPath.cameraCalibrate[0]) && !File.Exists(CameraConfigPath.cameraCalibrate[1]))
            {
                return;
            }
            try
            {
                HOperatorSet.ReadCamPar(CameraConfigPath.cameraCalibrate[0], out _calParam);
                HOperatorSet.ReadPose(CameraConfigPath.cameraCalibrate[1], out _camPose);
                camPose = _camPose;
                calParam = _calParam;
            }
            catch (Exception ex)
            {
                camPose = null;
                calParam = null;
            }
        }
        public void uploadCalParam(string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new Exception("File not found !!!");
                HTuple _calParam = new HTuple();
                HOperatorSet.ReadCamPar(path, out _calParam);
                HOperatorSet.WriteCamPar(_calParam, CameraConfigPath.cameraCalibrate[0]);
                calParam = _calParam;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Read calibrate parameter file !!!");
            }
        }
        public void uploadCamPose(string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new Exception("File not found !!!");
                HTuple _camPose = new HTuple();
                HOperatorSet.ReadPose(path, out _camPose);
                HOperatorSet.WritePose(_camPose, CameraConfigPath.cameraCalibrate[1]);
                calParam = _camPose;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Read camera pose file !!!");
            }
        }
    }
    public class CameraConnect
    {
        HTuple _acqHandle;
        bool _camera_IsOpen = false;
        bool _flipHor = false;
        bool _flipVer = false;
        public event captureTime OnCaptureTimeUpdate;
        Stopwatch _sw = new Stopwatch();
        double last_stopwatch = 0;
        CameraIdx _cameraIdx;
        public HTuple AcqHandle
        {
            get
            {
                return _acqHandle;
            }
        }
        public bool camera_IsOpen
        {
            get { return _camera_IsOpen; }
        }
        CameraParam camParam = new CameraParam();
        public bool OpenFrameGraber(CameraIdx idx)
        {
            if (_camera_IsOpen)
                return true;
            CameraParamAll paramAll = new CameraParamAll();
            paramAll.loadConfig();
            camParam = paramAll.param[idx];

            try
            {
                _acqHandle = new HTuple();
                #region ueye
                //HOperatorSet.OpenFramegrabber("uEye", 1, 1, 0, 0, 0, 0,
                //                              "default", 8, "default", -1,
                //                              "false", "default", camParam.CameraID.ToString(), 0, -1, out _acqHandle);


                //HOperatorSet.SetFramegrabberParam(_acqHandle, "flip_horizontal", camParam.FlipHorizontal? "true" : "false");
                //HOperatorSet.SetFramegrabberParam(_acqHandle, "flip_vertical", camParam.FlipVertical ? "true" : "false");
                //HOperatorSet.SetFramegrabberParam(_acqHandle, "focus", camParam.ExposureTime);
                //HOperatorSet.SetFramegrabberParam(_acqHandle, "grab_timeout", 10000);
                //HOperatorSet.SetFramegrabberParam(_acqHandle, "image_format", "2592 x 1944  (5M)");
                //HOperatorSet.SetFramegrabberParam(_acqHandle, "white_balance", "disable");
                //HOperatorSet.GrabImageStart(_acqHandle, -1);
                #endregion
                HOperatorSet.OpenFramegrabber("GenICamTL", 0, 0, 0, 0, 0, 0,
                                              "progressive", -1, "gray", -1,
                                              "false", "default", "Hikrobot MV-CE200-10UM (02G05791359)",
                                              0, -1, out _acqHandle);
                HOperatorSet.SetFramegrabberParam(_acqHandle, "Width", 5472);
                HOperatorSet.SetFramegrabberParam(_acqHandle, "Height", 3648);
                HOperatorSet.SetFramegrabberParam(_acqHandle, "ExposureTime", (double)camParam.ExposureTime);
                HOperatorSet.GrabImageStart(_acqHandle, -1);
                _flipVer = camParam.FlipVertical;
                _flipHor = camParam.FlipHorizontal;
                _cameraIdx = idx;
                _camera_IsOpen = true;
            }
            catch (Exception e)
            {
                try
                {
                    if (_acqHandle != null)
                    {
                        HOperatorSet.CloseFramegrabber(_acqHandle);
                        _acqHandle.Dispose();
                        _camera_IsOpen = false;
                    }
                }
                catch (Exception)
                {

                }
                _acqHandle = null;
                _camera_IsOpen = false;
            }
            return camera_IsOpen;
        }
        public void closeCamera()
        {
            if (_camera_IsOpen)
            {
                if (_acqHandle != null)
                {
                    HOperatorSet.CloseFramegrabber(_acqHandle);
                    _acqHandle.Dispose();
                    _camera_IsOpen = false;
                }
            }
        }
        private void timerSW(bool start)
        {
            if (OnCaptureTimeUpdate == null)
                return;
            if (start)
            {
                _sw.Stop();
                _sw.Reset();
                _sw.Start();
            }
            else
            {
                _sw.Stop();
                last_stopwatch = _sw.Elapsed.TotalMilliseconds;
                _sw.Reset();
                OnCaptureTimeUpdate(_cameraIdx, last_stopwatch);
            }
        }
        public HObject grabImg()
        {
            timerSW(true);
            HObject img = new HObject(); img.GenEmptyObj();
            HOperatorSet.GrabImageAsync(out img, _acqHandle, -1);
            if (_flipHor)
            {
                HObject imgFlipH = new HObject(); imgFlipH.GenEmptyObj();
                HOperatorSet.MirrorImage(img, out imgFlipH, "column");
                img.Dispose();
                img = imgFlipH;
            }

            if (_flipVer)
            {
                HObject imgFlipV = new HObject(); imgFlipV.GenEmptyObj();
                HOperatorSet.MirrorImage(img, out imgFlipV, "row");
                img.Dispose();
                img = imgFlipV;
            }
            timerSW(false);
            return img;
        }

        public void updateSetting(CameraParam param)
        {
            if (!_camera_IsOpen)
            {
                return;
            }

            camParam.FlipHorizontal = param.FlipHorizontal;
            camParam.FlipVertical = param.FlipVertical;

            _flipVer = camParam.FlipVertical;
            _flipHor = camParam.FlipHorizontal;
            if (camParam.ExposureTime != param.ExposureTime)
            {
                camParam.ExposureTime = param.ExposureTime;
                HOperatorSet.SetFramegrabberParam(_acqHandle, "ExposureTime", (double)camParam.ExposureTime);
            }

        }
    }

}
