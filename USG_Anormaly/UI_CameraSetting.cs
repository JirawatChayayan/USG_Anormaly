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

namespace USG_Anormaly
{

    public partial class UI_CameraSetting : UserControl
    {
        CamCalibration camCalibration = new CamCalibration();
        public CameraParamAll CameraParamAll
        {
            set
            {
                uI_CameraControl_front.loadConfig(value.param[CameraIdx.Front]);
                uI_CameraControl_side.loadConfig(value.param[CameraIdx.Side]);
                
            }
        }
        public UI_CameraSetting()
        {
            InitializeComponent();
            uI_CameraControl_front.camIdx = CameraIdx.Front;
            uI_CameraControl_side.camIdx = CameraIdx.Side;
            uI_CameraControl_front.OnUploadCalibrationFile += UI_CameraControl1_OnUploadCalibrationFile;

            uI_CameraControl_front.OnSettingValueChanged += UI_CameraControl_OnSettingValueChanged;
            uI_CameraControl_side.OnSettingValueChanged += UI_CameraControl_OnSettingValueChanged;

            loadCalibrateFile();
        }

        public event settingValueChanged OnSettingValueChanged;
        private void UI_CameraControl_OnSettingValueChanged(CameraIdx idx, CameraParam cameraParam)
        {
            if(OnSettingValueChanged != null)
                OnSettingValueChanged(idx, cameraParam);
        }
        private void UI_CameraControl1_OnUploadCalibrationFile(bool cameraPose)
        {
            string msg = cameraPose ? "camera pose" : "camera parameter";
            string filter = cameraPose ? "CameraPos (.dat)|*.dat" : "CameraParam (.cal)|*.cal";
            DialogResult da = MessageBox.Show($"Are you shure to update {msg} file? ",
                                              $"Upload {msg} !!!",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);
            if (da == DialogResult.No)
                return;

            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = filter;
                if(op.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (cameraPose)
                        {
                            camCalibration.uploadCamPose(op.FileName);
                        }
                        else
                        {
                            camCalibration.uploadCalParam(op.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error !!!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                loadCalibrateFile();
            }
        }
        private void loadCalibrateFile()
        {
            camCalibration.load();
            uI_CameraControl_front.camParamAndPoseUpdate(camCalibration.calParam, camCalibration.camPose);
        }

        public void cameraConnected(CameraIdx idx,bool connected)
        {
            if(idx == CameraIdx.Front)
            {
                uI_CameraControl_front.cameraConnected = connected;
                uI_CameraControl_front.Enabled = connected;
                    
            }
            else
            {
                uI_CameraControl_side.cameraConnected = connected;
                uI_CameraControl_side.Enabled = connected;
            }
        }
    }
}
