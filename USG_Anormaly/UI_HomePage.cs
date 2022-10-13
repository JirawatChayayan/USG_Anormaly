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
using Newtonsoft.Json;

namespace USG_Anormaly
{
    public partial class UI_HomePage : UserControl
    {
        public UI_HomePage()
        {
            InitializeComponent();
        }

        private void changeBtColor(Button bt,bool Connected)        
        {
            if(Connected)
            {
                bt.BackColor = Color.Green;
                bt.ForeColor = Color.Transparent;
            }
            else
            {
                bt.BackColor = SystemColors.ControlDarkDark;
                bt.ForeColor = Color.Black;
            }
        }
        public void cameraConnection(CameraIdx idx,bool connected)
        {
            if(idx == CameraIdx.Front)
            {
                changeBtColor(bt_camera1_status,connected);
            }
            else
            {
                changeBtColor(bt_camera2_status,connected);
            }
        }

        public void initial()
        {
            timer_fetch_api.Enabled = true;
            timer_fetch_api.Stop();
            callAPI();
            if(!serverConnecting)
            {
                txt_trainingInfo.Text = "Cannot connect server";
                bt_MoreInfo.Text = "Try to connect server Again";
            }
            else
            {
                serverConnecting = true;
                timer_fetch_api.Start();
            }
            
        }

        private void listBox_ModelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string recipe = listBox_ModelName.SelectedItem.ToString().Trim();
                txt_modelName.Text = recipe;
                var res = (new ServerInterface()).getFinishedData(recipe);
                var a = new
                {
                    pretrain = res.pretrainedDL,
                    generalParam = res.generalDLParam,
                    hyperParam = res.hyperDLParam,
                    trainingStart = res.trainingDateTime,
                    trainingFinish = res.trainingFinished,
                };
                txt_trainingInfo.Text = JsonConvert.SerializeObject(a,Formatting.Indented);
                uI_ImageDisplay1.setDispImg(res.resultFront.sample_image,
                                            res.resultSide1.sample_image,
                                            res.resultSide2.sample_image);
            }
            catch (Exception ex)
            {
                txt_trainingInfo.Text = ex.Message;
            }
            
        }

        int _countErrorFetchAPI = 0;
        bool serverConnecting = false;

        private void callAPI()
        {
            lb_Loading.BringToFront();
            listBox_ModelName.Enabled = false;
            listBox_ModelName.Items.Clear();
            try
            {
                var modelStatus = (new ServerInterface()).getModelFinished();
                if (modelStatus == null)
                {
                    changeBtColor(bt_aiserver_Status, false);
                    _countErrorFetchAPI += 1;
                    serverConnecting = false;
                }
                else
                {
                    changeBtColor(bt_aiserver_Status, true);

                    foreach (var model in modelStatus)
                    {
                        listBox_ModelName.Items.Add(model.recipeName);
                    }
                    _countErrorFetchAPI = 0;
                    serverConnecting = true;

                    bt_MoreInfo.Text = "Click me for more detail";
                }
            }
            catch (Exception ex)
            {
                changeBtColor(bt_aiserver_Status, false);
                _countErrorFetchAPI += 1;
                serverConnecting = false;
            }
            listBox_ModelName.Enabled = true;
            listBox_ModelName.BringToFront();
        }

        private void timer_fetch_api_Tick(object sender, EventArgs e)
        {
            initial();

        }

        private void bt_MoreInfo_Click(object sender, EventArgs e)
        {
            if(bt_MoreInfo.Text == "Try to connect server Again")
            {
                initial();
                return;
            }    

            if (!serverConnecting)
                return;
            string recipe = txt_modelName.Text.Trim();
            if (recipe == "")
                return;
            frmModelDetail frm = new frmModelDetail();
            frm.recipename = recipe;
            frm.ShowDialog();
        }
    }
}
