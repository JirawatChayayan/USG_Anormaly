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
    public partial class UI_CurrentServerState : UserControl
    {
        public UI_CurrentServerState()
        {
            InitializeComponent();
        }


        private void stopTimer()
        {
            timer1_fetchServerLog.Stop();
            timer1_fetchServerLog.Enabled = false;
        }

        private void startTimer()
        {
            timer1_fetchServerLog.Enabled=true;
            timer1_fetchServerLog.Start();
        }

        DateTime startDate;
        List<LogTrainingModel> trainingModels;

        public void ShowTab()
        {
            startDate = DateTime.Now.AddMinutes(-60.00);
            trainingModels = getData(startDate);
            startTimer();
            if (trainingModels == null)
                return;
            richTextBox_logTraining.Clear();
            dispResult(trainingModels);
            
        }
        public void stopFetch()
        {
            if (timer1_fetchServerLog.Enabled == false)
                return;
            stopTimer();
            richTextBox_logTraining.Clear();
            if(trainingModels != null)
                trainingModels.Clear();
        }

        public List<LogTrainingModel> getData(DateTime fromDate)
        {
            try
            {
                return (new ServerInterface()).getLogTraining(fromDate, DateTime.Now);
            }
            catch (Exception ex)
            {
                //stopTimer();
                return null;
            }

        }

        private void dispResult(List<LogTrainingModel> log)
        {
            foreach (LogTrainingModel model in log)
            {
                
                if (model.logLevel == "INFO")
                {
                    richTextBox_logTraining.SelectionColor = Color.Black;
                }
                else if (model.logLevel == "ERROR")
                {
                    richTextBox_logTraining.SelectionColor = Color.Red;
                }
                else if(model.logLevel == "WARNING")
                {
                    richTextBox_logTraining.SelectionColor = Color.Orange;
                }
                else
                {
                    richTextBox_logTraining.SelectionColor = Color.White;
                }
                richTextBox_logTraining.AppendText($"{model.timeStamp} {model.logLevel} {model.logMessage}" + Environment.NewLine);
                richTextBox_logTraining.ScrollToCaret();
            }
        }

        private void timer1_fetchServerLog_Tick(object sender, EventArgs e)
        {
            var res = getData(startDate);
            if (res == null)
                return;
            stopTimer();
            if (trainingModels == null)
            {
                trainingModels = res;
                dispResult(trainingModels);
            }
            else
            {
                int newDataLen = res.Count();
                if(newDataLen == 0)
                {
                    return;
                }
                List<LogTrainingModel> cache = new List<LogTrainingModel>();
                var lastData = trainingModels.Last();
                for (int i = newDataLen-1; i>0; i--)
                {
                    if(res[i].timeStamp == lastData.timeStamp && 
                       res[i].logLevel == lastData.logLevel && 
                       res[i].logMessage == lastData.logMessage)
                    {
                        break;
                    }
                    cache.Add(res[i]);
                }

                var a = (from b in cache orderby b.timeStamp ascending select b).ToList();
                dispResult(a);
                foreach(var data in a)
                {
                    trainingModels.Add(data);
                }
                res.Clear();
                cache.Clear();
                a.Clear();
                
            }
            startTimer();
        }
    }
}
