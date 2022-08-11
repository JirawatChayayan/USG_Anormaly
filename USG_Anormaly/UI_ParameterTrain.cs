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
    public partial class UI_ParameterTrain : UserControl
    {
        public UI_ParameterTrain()
        {
            InitializeComponent();
            defaultGeneralParam();
            defaultHyperParam();
        }
        private void trackBar_NumEpochs_Scroll(object sender, EventArgs e)
        {
            label_NumEpochs_Value.Text = trackBar_NumEpochs.Value.ToString();
        }
        private void defaultGeneralParam()
        {
            trackBar_NumEpochs.Value = 100;
            label_NumEpochs_Value.Text = trackBar_NumEpochs.Value.ToString();

            comboBox_Pretrained_DL.SelectedIndex = 0;

            comboBox_Spilt_Data.SelectedIndex = 0;
            
            comboBox_TrainingImgSize.SelectedIndex = 1;
        }
        private void defaultHyperParam()
        {
            numericUpDown_Complexity.Value = 15;
            numericUpDown_SD_Factor.Value = (decimal)3.0;

            numericUpDown_Error_Threshold.Value = (decimal)0.0010;
            numericUpDown_Domain_Ratio.Value = (decimal)0.25;
            numericUpDown_Regularization_Noise.Value = (decimal)0.010;
        }
        private void button_defaultHyperParam_Click(object sender, EventArgs e)
        {
            defaultHyperParam();
        }
        private void button_defaultGeneral_Click(object sender, EventArgs e)
        {
            defaultGeneralParam();
        }

        public UploadFileModel getParam()
        {
            UploadFileModel model = new UploadFileModel();  
            model.machineName = Environment.MachineName;
            model.pretrainedDL = comboBox_Pretrained_DL.Text;
            model.generalDLParam = new GeneralDLParam();

            #region splitData
            if (comboBox_Spilt_Data.SelectedIndex == 0)
            {
                //60/20/20
                model.generalDLParam.trainingPercent = 60;
                model.generalDLParam.validatePercent = 20;
            }
            else if (comboBox_Spilt_Data.SelectedIndex == 1)
            {
                //70/15/15
                model.generalDLParam.trainingPercent = 70;
                model.generalDLParam.validatePercent = 15;
            }
            else
            {
                //80/10/10
                model.generalDLParam.trainingPercent = 80;
                model.generalDLParam.validatePercent = 10;
            }
            #endregion

            #region TrainingImgSize
            if (comboBox_TrainingImgSize.SelectedIndex == 0)
            {
                //1728 X 1312
                model.generalDLParam.imgSize.width = 1728;
                model.generalDLParam.imgSize.height = 1312;

            }
            else if (comboBox_TrainingImgSize.SelectedIndex == 1)
            {
                //1312 X 992
                model.generalDLParam.imgSize.width = 1312;
                model.generalDLParam.imgSize.height = 992;
            }
            else if (comboBox_TrainingImgSize.SelectedIndex == 2)
            {
                //1024 X 768
                model.generalDLParam.imgSize.width = 1024;
                model.generalDLParam.imgSize.height = 768;
            }
            else
            {
                //864 X 640
                model.generalDLParam.imgSize.width = 864;
                model.generalDLParam.imgSize.height = 640;
            }
            #endregion

            model.generalDLParam.numEpochs = trackBar_NumEpochs.Value;
            
            model.hyperDLParam = new HyperDLParam();
            model.hyperDLParam.complexity = (int)numericUpDown_Complexity.Value;
            model.hyperDLParam.domainRatio = (double)numericUpDown_Domain_Ratio.Value;
            model.hyperDLParam.standardDeviationFactor = (double)numericUpDown_SD_Factor.Value;
            model.hyperDLParam.regularizationNoise = (double)numericUpDown_Regularization_Noise.Value;
            model.hyperDLParam.errorThreshold = (double)numericUpDown_Error_Threshold.Value;
            return model; 
           
        }
    }
}
