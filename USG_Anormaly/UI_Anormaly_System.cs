using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USG_Anormaly_lib;
using HalconDotNet;
using System.Threading;

namespace USG_Anormaly
{
    public partial class UI_Anormaly_System : UserControl
    {
        public UI_Anormaly_System()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            uI_CameraSetting1.OnSettingValueChanged += UI_CameraSetting1_OnSettingValueChanged;
            uI_Training1.OnRequireCaptureImage += UI_Training1_OnRequireCaptureImage;
        }

        private HObject UI_Training1_OnRequireCaptureImage(CameraIdx idx)
        {
            try
            {
                if (idx == CameraIdx.Front)
                {
                    return grabImageFront();
                }
                else
                {
                    return grabImageSide();
                }
            }
            catch
            {
                return null;
            }
           
        }

        public struct ImageFrontSide
        {
            public HObject ImageFront;
            public HObject ImageSide;
        }
        public Button[] bt_controlMain
        {
            get 
            {
                return (new Button[] { bt_home, bt_camera_setting, bt_anormaly_training, bt_anormaly_testing });
            }
        }
        Color higlightColor = SystemColors.Highlight;
        Color lowLightColor = Color.Transparent;

        CameraParamAll cameraParam = new CameraParamAll();
        ueyeCameraConnect ueyeCameraFront = new ueyeCameraConnect();
        ueyeCameraConnect ueyeCameraSide = new ueyeCameraConnect();
        Mutex camera1Lock = new Mutex();
        Mutex camera2Lock = new Mutex();
        public event SelectedImageTraining OnSelectedImageTraining;

        public void initialLoad()
        {
            uI_Training1.initial();
            uI_Training1.OnSelectedImageTraining += UI_Training1_OnSelectedImageTraining;

            Task.Run(() =>
            {
                uI_HomePage1.initial();
            });


        }

        private void UI_Training1_OnSelectedImageTraining(CameraIdx idx, HObject imgSelect)
        {
            if(OnSelectedImageTraining != null)
            {
                OnSelectedImageTraining(idx, imgSelect);
            }
            else
            {
                imgSelect.Dispose();
            }
        }

        public void enableCamera()
        {
            initialLoad();


            cameraParam.loadConfig();
            uI_CameraSetting1.CameraParamAll = cameraParam;
            Task T1 = Task.Run(() =>
            {
                if (!ueyeCameraFront.camera_IsOpen)
                {
                    ueyeCameraFront.OpenFrameGraber(CameraIdx.Front);
                }
                uI_HomePage1.cameraConnection(CameraIdx.Front, ueyeCameraFront.camera_IsOpen);
               
            });
            Task T2 = Task.Run(() =>
            {
                if (!ueyeCameraSide.camera_IsOpen)
                {
                    ueyeCameraSide.OpenFrameGraber(CameraIdx.Side);
                }
                uI_HomePage1.cameraConnection(CameraIdx.Side, ueyeCameraSide.camera_IsOpen);
            });
            T2.Wait();
            T1.Wait();
            uI_CameraSetting1.cameraConnected(CameraIdx.Front, ueyeCameraFront.camera_IsOpen);
            uI_CameraSetting1.cameraConnected(CameraIdx.Side,ueyeCameraSide.camera_IsOpen);
        }
        public void disableCamera()
        {
            ueyeCameraFront.closeCamera();
            ueyeCameraSide.closeCamera();
        }

        public HObject grabImageFront()
        {
            if (!ueyeCameraFront.camera_IsOpen)
                throw new Exception("Camera is not open !!!");
            camera1Lock.WaitOne();
            HObject img = ueyeCameraFront.grabImg();
            camera1Lock.ReleaseMutex();
            return img;
        }
        public HObject grabImageSide()
        {
            if (!ueyeCameraSide.camera_IsOpen)
                throw new Exception("Camera is not open !!!");
            camera2Lock.WaitOne();
            HObject img = ueyeCameraSide.grabImg();
            camera2Lock.ReleaseMutex();
            return img;
        }
        public ImageFrontSide grab2Image()
        {
            if (!ueyeCameraSide.camera_IsOpen)
                throw new Exception("Camera side is not open !!!");
            if (!ueyeCameraFront.camera_IsOpen)
                throw new Exception("Camera front is not open !!!");

            HObject imgFront = new HObject();imgFront.GenEmptyObj();
            HObject imgSide = new HObject();imgSide.GenEmptyObj();
            Task T1 = Task.Run(() =>
            {
                imgFront = grabImageFront();
            });
            Task T2 = Task.Run(() =>
            {
                imgSide = grabImageSide();
            });
            while (!(T1.IsCompleted && T2.IsCompleted))
            {
                Thread.Sleep(1);
            }

            return new ImageFrontSide
            {
                ImageFront = imgFront,
                ImageSide = imgSide,
            };
        }



        //pass parameter from sub UI in camerasetting
        private void UI_CameraSetting1_OnSettingValueChanged(CameraIdx idx, CameraParam param)
        {
            cameraParam.param[idx] = param;
            cameraParam.saveConfig();
            if(idx == CameraIdx.Front)
            {
                ueyeCameraFront.updateSetting(param);
            }
            else
            {
                ueyeCameraSide.updateSetting(param);
            }
        }
        
        private void changeColor(Button bt)
        {
            Button[] btAll = bt_controlMain;
            for (int i = 0; i < btAll.Length; i++)
            {
                if(btAll[i].Name != bt.Name)
                {
                    btAll[i].BackColor = lowLightColor;
                    btAll[i].ForeColor = higlightColor;
                }
                else
                {
                    btAll[i].ForeColor = lowLightColor;
                    btAll[i].BackColor = higlightColor;
                }
            }

            
        }
        private void bt_menu(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            changeColor(bt);
            uI_Training1.stopStartFetchdata(false);
            if (bt.Name == bt_home.Name)
            {
                uI_HomePage1.BringToFront();
            }
            if(bt.Name==bt_camera_setting.Name)
            {
                uI_CameraSetting1.BringToFront();
            }
            if(bt.Name==bt_anormaly_training.Name)
            {
                uI_Training1.BringToFront();
                uI_Training1.update_imgPath();
                uI_Training1.stopStartFetchdata(true);
            }
        }
    }
}
