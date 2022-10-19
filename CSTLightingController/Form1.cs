using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSTLightingController
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            CSTLightingControl.OnSendDataFinished += CSTLightingControl_OnSendDataFinished;
            CSTLightingControl.OnRecieveLightingVal += CSTLightingControl_OnRecieveLightingVal;
            CSTLightingControl.OnRecieveTriggerVal += CSTLightingControl_OnRecieveTriggerVal;
        }

        private void CSTLightingControl_OnRecieveTriggerVal(TriggerMode val)
        {
            if(val == TriggerMode.Pos)
            {
                bt_pos.BackColor = Color.LightSalmon;
                bt_neg.UseVisualStyleBackColor = true;
            }
            else
            {
                bt_neg.BackColor = Color.LightSalmon;
                bt_pos.UseVisualStyleBackColor = true;
            }
        }

        private void CSTLightingControl_OnRecieveLightingVal(LightingCH ch, int val)
        {
            lb_val_get.Text = val.ToString();
        }

        private void CSTLightingControl_OnSendDataFinished()
        {
            
        }

        private void ch1_val_ValueChanged(object sender, EventArgs e)
        {
            int val = ((TrackBar)sender).Value;
            label_val.Text = val.ToString();
            string cmd = CSTLightingCommand.setLighting(LightingCH.CH1, val);
            CSTLightingControl.sendCommand(cmd);
        }

        private void bt_Connect_Click(object sender, EventArgs e)
        {
            if(bt_Connect.Text == "Connect")
            {
                ch1_val.Value = 0;
                CSTLightingControl.connect();
                bt_Connect.Text = "Disconnect";
                bt_Connect.BackColor = Color.LightGreen;

            }
            else
            {
                bt_Connect.Text = "Connect";
                bt_Connect.UseVisualStyleBackColor = true;
                CSTLightingControl.disconnect();
                bt_pos.UseVisualStyleBackColor = true;
                bt_neg.UseVisualStyleBackColor = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CSTLightingControl.disconnect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_pos_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            if(bt.Name == bt_pos.Name)
            {
                string cmd = CSTLightingCommand.setTrigger(TriggerMode.Pos);
                CSTLightingControl.sendCommand(cmd);
            }
            else
            {
                string cmd = CSTLightingCommand.setTrigger(TriggerMode.Neg);
                CSTLightingControl.sendCommand(cmd);
            }
            string cmd2 = CSTLightingCommand.getTrigger();
            CSTLightingControl.sendCommand(cmd2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd = CSTLightingCommand.getLighting(LightingCH.CH1);
            CSTLightingControl.sendCommand(cmd);
        }
    }
}
