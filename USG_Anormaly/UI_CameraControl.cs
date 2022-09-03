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

namespace USG_Anormaly
{
    public delegate void settingValueChanged(CameraIdx idx, CameraParam cameraParam);
    public delegate void uploadCalibrationFile(bool cameraPose);
    public partial class UI_CameraControl : UserControl
    {
        public UI_CameraControl()
        {
            InitializeComponent();
            resetCalParam();
            tb_exposureTime.MouseWheel += Control_MouseWheel;

        }
        public event settingValueChanged OnSettingValueChanged;
        public event uploadCalibrationFile OnUploadCalibrationFile;
        CameraIdx _idx = CameraIdx.Front;
        bool _connected = false;
        public CameraIdx camIdx 
        { 
            set 
            { 
                _idx = value;
                btStatusName();
            } 
        }
        public bool cameraConnected 
        {
            set
            {
                _connected = value;
                btStatusChange();
            }
        }
        public CameraParam cameraParam  = null;
        private void btStatusName()
        {
            if(_idx == CameraIdx.Front)
            {
                bt_camera_status.Text = "Camera Front";
            }
            else
            {
                bt_camera_status.Text = "Camera Side";
                panel2.Enabled = false;
            }
            groupBox1.Text = bt_camera_status.Text;
        }
        public void btStatusChange()
        {
            if (_connected)
            {
                bt_camera_status.BackColor = Color.Green;
                bt_camera_status.ForeColor = Color.Transparent;
            }
            else
            {
                bt_camera_status.BackColor = SystemColors.ControlDarkDark;
                bt_camera_status.ForeColor = Color.Black;
            }
        }
        private void tb_focus_ValueChanged(object sender, EventArgs e)
        {
            txt_expouserTime.Text = tb_exposureTime.Value.ToString();
            //if (OnSettingValueChanged != null)
            //    OnSettingValueChanged(_idx, cameraParam);
        }
        
        private void Control_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void tb_focus_MouseUp(object sender, MouseEventArgs e)
        {
            if(cameraParam == null)
                return;
            setParam();
            if (OnSettingValueChanged != null)
                OnSettingValueChanged(_idx,cameraParam);
        }
        public void loadConfig(CameraParam param)
        {
            cameraParam = param;
            tb_exposureTime.Value = cameraParam.ExposureTime;
            cb_flip_ver.Checked = cameraParam.FlipVertical;
            cb_flip_hor.Checked = cameraParam.FlipHorizontal;
            //if (OnSettingValueChanged != null)
            //    OnSettingValueChanged(_idx, cameraParam);
        }
        private void setParam()
        {
            if (cameraParam == null)
                return;
            cameraParam.ExposureTime = tb_exposureTime.Value;
            cameraParam.FlipVertical = cb_flip_ver.Checked;
            cameraParam.FlipHorizontal = cb_flip_hor.Checked;
        }

        private void cb_flip_Click(object sender, EventArgs e)
        {
            if (cameraParam == null)
                return;
            setParam();
            if (OnSettingValueChanged != null)
                OnSettingValueChanged(_idx, cameraParam);
        }

        private void bt_uploadCal_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (OnUploadCalibrationFile != null)
                OnUploadCalibrationFile((bt.Name == bt_upload_camPos.Name));
        }

        public void camParamAndPoseUpdate(HTuple param,HTuple pose)
        {
            try
            {
                if(param == null || pose == null)
                {
                    return;
                }
                //CameraParameters := ['area_scan_division',0.0038423,2015.9,1.3992e-06,1.4e-06,1296.68,928.763,2592,1944]
                //CameraPose:= [-0.225425, -0.161473, 0.488293, 358.892, 0.444085, 359.778, 0]
                lb_camPosX.Text = $"X : {(pose[0].D*1000).ToString("#.###")} um";
                lb_camPosY.Text = $"Y : {(pose[1].D*1000).ToString("#.###")} um";
                lb_camPosZ.Text = $"Z : {(pose[2].D*1000).ToString("#.###")} um";

                lb_camRotateX.Text = $"RX : {pose[3].D.ToString("#.###")} deg";
                lb_camRotateX.Text = $"RY : {pose[4].D.ToString("#.###")} deg";
                lb_camRotateX.Text = $"RZ : {pose[5].D.ToString("#.###")} deg";

                lb_camParam_Sx.Text = $"Cell Width (Sx) : {(param[3].D*1000000).ToString("#.###")} um";
                lb_camParam_Sy.Text = $"Cell Height (Sy) : {(param[4].D*1000000).ToString("#.###")} um";
                lb_camParam_FocalLength.Text = $"Focal Length : {(param[1].D*1000).ToString("#.###")} mm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Calibration Data Error !!!",
                                "File format not correct !!!",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);

            }
        }
        public void resetCalParam()
        {
            lb_camPosX.Text = $"X : 0 um";
            lb_camPosY.Text = $"Y : 0 um";
            lb_camPosZ.Text = $"Z : 0 um";

            lb_camRotateX.Text = $"RX : 0 deg";
            lb_camRotateX.Text = $"RY : 0 deg";
            lb_camRotateX.Text = $"RZ : 0 deg";

            lb_camParam_Sx.Text = $"Cell Width (Sx) : 0 um";
            lb_camParam_Sy.Text = $"Cell Height (Sy) : 0 um";
            lb_camParam_FocalLength.Text = $"Focal Length : 0 mm";
        }

        private void tb_exposureTime_Scroll(object sender, EventArgs e)
        {

        }
    }
}
