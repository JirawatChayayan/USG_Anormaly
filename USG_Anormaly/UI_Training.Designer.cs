namespace USG_Anormaly
{
    partial class UI_Training
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_status = new System.Windows.Forms.RichTextBox();
            this.bt_training = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_checkNameInuse = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_recipe = new System.Windows.Forms.TextBox();
            this.bgw_Upload_data = new System.ComponentModel.BackgroundWorker();
            this.timer_fetchServerInfo = new System.Windows.Forms.Timer(this.components);
            this.uI_preTrain_imgfront = new USG_Anormaly.UI_PretrainImage();
            this.uI_preTrain_imgside1 = new USG_Anormaly.UI_PretrainImage();
            this.uI_preTrain_imgside2 = new USG_Anormaly.UI_PretrainImage();
            this.uI_ParameterTrain1 = new USG_Anormaly.UI_ParameterTrain();
            this.uI_WaitTrainingProcess1 = new USG_Anormaly.UI_WaitTrainingProcess();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_status);
            this.groupBox1.Controls.Add(this.bt_training);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dgv_result);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bt_checkNameInuse);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_recipe);
            this.groupBox1.Controls.Add(this.uI_WaitTrainingProcess1);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 592);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anormaly Training";
            // 
            // rtb_status
            // 
            this.rtb_status.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rtb_status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_status.Location = new System.Drawing.Point(6, 400);
            this.rtb_status.Name = "rtb_status";
            this.rtb_status.Size = new System.Drawing.Size(426, 70);
            this.rtb_status.TabIndex = 9;
            this.rtb_status.Text = "";
            // 
            // bt_training
            // 
            this.bt_training.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_training.Location = new System.Drawing.Point(6, 327);
            this.bt_training.Name = "bt_training";
            this.bt_training.Size = new System.Drawing.Size(426, 54);
            this.bt_training.TabIndex = 8;
            this.bt_training.Text = "Training";
            this.bt_training.UseVisualStyleBackColor = true;
            this.bt_training.Click += new System.EventHandler(this.bt_training_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 476);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Server Training Infomation";
            // 
            // dgv_result
            // 
            this.dgv_result.AllowUserToAddRows = false;
            this.dgv_result.AllowUserToDeleteRows = false;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Location = new System.Drawing.Point(6, 492);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.ReadOnly = true;
            this.dgv_result.RowHeadersVisible = false;
            this.dgv_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_result.Size = new System.Drawing.Size(426, 94);
            this.dgv_result.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(86, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "system will reduce img quality from BMP -> JPG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(85, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Please upload only good image for training and then if image > 30 per cam ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(11, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Note :";
            // 
            // bt_checkNameInuse
            // 
            this.bt_checkNameInuse.Location = new System.Drawing.Point(367, 44);
            this.bt_checkNameInuse.Name = "bt_checkNameInuse";
            this.bt_checkNameInuse.Size = new System.Drawing.Size(65, 31);
            this.bt_checkNameInuse.TabIndex = 3;
            this.bt_checkNameInuse.Text = "Check";
            this.bt_checkNameInuse.UseVisualStyleBackColor = true;
            this.bt_checkNameInuse.Click += new System.EventHandler(this.bt_checkNameInuse_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(6, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(426, 247);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uI_preTrain_imgfront);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(418, 221);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Front Image";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uI_preTrain_imgside1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(418, 221);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Side Image 1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.uI_preTrain_imgside2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(418, 221);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Side Image 2";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.flowLayoutPanel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(418, 221);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Parameter";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.uI_ParameterTrain1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(418, 217);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recipe ";
            // 
            // txt_recipe
            // 
            this.txt_recipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_recipe.Location = new System.Drawing.Point(89, 44);
            this.txt_recipe.Name = "txt_recipe";
            this.txt_recipe.Size = new System.Drawing.Size(271, 31);
            this.txt_recipe.TabIndex = 0;
            this.txt_recipe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_recipe_KeyPress);
            // 
            // bgw_Upload_data
            // 
            this.bgw_Upload_data.WorkerReportsProgress = true;
            this.bgw_Upload_data.WorkerSupportsCancellation = true;
            this.bgw_Upload_data.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Upload_data_DoWork);
            this.bgw_Upload_data.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_Upload_data_ProgressChanged);
            this.bgw_Upload_data.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_Upload_data_RunWorkerCompleted);
            // 
            // timer_fetchServerInfo
            // 
            this.timer_fetchServerInfo.Interval = 5000;
            this.timer_fetchServerInfo.Tick += new System.EventHandler(this.timer_fetchServerInfo_Tick);
            // 
            // uI_preTrain_imgfront
            // 
            this.uI_preTrain_imgfront.Location = new System.Drawing.Point(0, 1);
            this.uI_preTrain_imgfront.Name = "uI_preTrain_imgfront";
            this.uI_preTrain_imgfront.Size = new System.Drawing.Size(418, 221);
            this.uI_preTrain_imgfront.TabIndex = 0;
            // 
            // uI_preTrain_imgside1
            // 
            this.uI_preTrain_imgside1.Location = new System.Drawing.Point(0, 1);
            this.uI_preTrain_imgside1.Name = "uI_preTrain_imgside1";
            this.uI_preTrain_imgside1.Size = new System.Drawing.Size(418, 221);
            this.uI_preTrain_imgside1.TabIndex = 0;
            // 
            // uI_preTrain_imgside2
            // 
            this.uI_preTrain_imgside2.Location = new System.Drawing.Point(0, 1);
            this.uI_preTrain_imgside2.Name = "uI_preTrain_imgside2";
            this.uI_preTrain_imgside2.Size = new System.Drawing.Size(418, 221);
            this.uI_preTrain_imgside2.TabIndex = 1;
            // 
            // uI_ParameterTrain1
            // 
            this.uI_ParameterTrain1.Location = new System.Drawing.Point(3, 3);
            this.uI_ParameterTrain1.Name = "uI_ParameterTrain1";
            this.uI_ParameterTrain1.Size = new System.Drawing.Size(395, 696);
            this.uI_ParameterTrain1.TabIndex = 0;
            // 
            // uI_WaitTrainingProcess1
            // 
            this.uI_WaitTrainingProcess1.Location = new System.Drawing.Point(5, 77);
            this.uI_WaitTrainingProcess1.Name = "uI_WaitTrainingProcess1";
            this.uI_WaitTrainingProcess1.Size = new System.Drawing.Size(430, 303);
            this.uI_WaitTrainingProcess1.TabIndex = 10;
            // 
            // UI_Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UI_Training";
            this.Size = new System.Drawing.Size(448, 595);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_checkNameInuse;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_recipe;
        private System.Windows.Forms.RichTextBox rtb_status;
        private System.Windows.Forms.Button bt_training;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_result;
        private UI_PretrainImage uI_preTrain_imgfront;
        private UI_PretrainImage uI_preTrain_imgside1;
        private System.ComponentModel.BackgroundWorker bgw_Upload_data;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;
        private UI_PretrainImage uI_preTrain_imgside2;
        private UI_WaitTrainingProcess uI_WaitTrainingProcess1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UI_ParameterTrain uI_ParameterTrain1;
        private System.Windows.Forms.Timer timer_fetchServerInfo;
    }
}
