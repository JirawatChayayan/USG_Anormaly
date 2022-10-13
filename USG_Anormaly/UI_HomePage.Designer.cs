namespace USG_Anormaly
{
    partial class UI_HomePage
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
            this.bt_aiserver_Status = new System.Windows.Forms.Button();
            this.bt_camera2_status = new System.Windows.Forms.Button();
            this.bt_camera1_status = new System.Windows.Forms.Button();
            this.timer_fetch_api = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_MoreInfo = new System.Windows.Forms.Button();
            this.uI_ImageDisplay1 = new USG_Anormaly.UI_ImageDisplay();
            this.listBox_ModelName = new System.Windows.Forms.ListBox();
            this.lb_Loading = new System.Windows.Forms.Label();
            this.txt_trainingInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_modelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_aiserver_Status);
            this.groupBox1.Controls.Add(this.bt_camera2_status);
            this.groupBox1.Controls.Add(this.bt_camera1_status);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // bt_aiserver_Status
            // 
            this.bt_aiserver_Status.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_aiserver_Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_aiserver_Status.Location = new System.Drawing.Point(290, 18);
            this.bt_aiserver_Status.Name = "bt_aiserver_Status";
            this.bt_aiserver_Status.Size = new System.Drawing.Size(129, 45);
            this.bt_aiserver_Status.TabIndex = 1;
            this.bt_aiserver_Status.Text = "AI Server";
            this.bt_aiserver_Status.UseVisualStyleBackColor = false;
            // 
            // bt_camera2_status
            // 
            this.bt_camera2_status.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_camera2_status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_camera2_status.Location = new System.Drawing.Point(155, 18);
            this.bt_camera2_status.Name = "bt_camera2_status";
            this.bt_camera2_status.Size = new System.Drawing.Size(129, 45);
            this.bt_camera2_status.TabIndex = 1;
            this.bt_camera2_status.Text = "Camera Side";
            this.bt_camera2_status.UseVisualStyleBackColor = false;
            // 
            // bt_camera1_status
            // 
            this.bt_camera1_status.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_camera1_status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_camera1_status.ForeColor = System.Drawing.Color.Black;
            this.bt_camera1_status.Location = new System.Drawing.Point(20, 18);
            this.bt_camera1_status.Name = "bt_camera1_status";
            this.bt_camera1_status.Size = new System.Drawing.Size(129, 45);
            this.bt_camera1_status.TabIndex = 1;
            this.bt_camera1_status.Text = "Camera Front";
            this.bt_camera1_status.UseVisualStyleBackColor = false;
            // 
            // timer_fetch_api
            // 
            this.timer_fetch_api.Interval = 30000;
            this.timer_fetch_api.Tick += new System.EventHandler(this.timer_fetch_api_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_MoreInfo);
            this.groupBox2.Controls.Add(this.uI_ImageDisplay1);
            this.groupBox2.Controls.Add(this.listBox_ModelName);
            this.groupBox2.Controls.Add(this.lb_Loading);
            this.groupBox2.Controls.Add(this.txt_trainingInfo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_modelName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(1, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 513);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AI Model ";
            // 
            // bt_MoreInfo
            // 
            this.bt_MoreInfo.Location = new System.Drawing.Point(178, 477);
            this.bt_MoreInfo.Name = "bt_MoreInfo";
            this.bt_MoreInfo.Size = new System.Drawing.Size(260, 27);
            this.bt_MoreInfo.TabIndex = 7;
            this.bt_MoreInfo.Text = "Click me for more detail";
            this.bt_MoreInfo.UseVisualStyleBackColor = true;
            this.bt_MoreInfo.Click += new System.EventHandler(this.bt_MoreInfo_Click);
            // 
            // uI_ImageDisplay1
            // 
            this.uI_ImageDisplay1.frontImg = null;
            this.uI_ImageDisplay1.Location = new System.Drawing.Point(178, 205);
            this.uI_ImageDisplay1.Name = "uI_ImageDisplay1";
            this.uI_ImageDisplay1.side1Img = null;
            this.uI_ImageDisplay1.side2Img = null;
            this.uI_ImageDisplay1.Size = new System.Drawing.Size(260, 267);
            this.uI_ImageDisplay1.TabIndex = 6;
            // 
            // listBox_ModelName
            // 
            this.listBox_ModelName.FormattingEnabled = true;
            this.listBox_ModelName.Location = new System.Drawing.Point(6, 19);
            this.listBox_ModelName.Name = "listBox_ModelName";
            this.listBox_ModelName.ScrollAlwaysVisible = true;
            this.listBox_ModelName.Size = new System.Drawing.Size(163, 485);
            this.listBox_ModelName.TabIndex = 0;
            this.listBox_ModelName.SelectedIndexChanged += new System.EventHandler(this.listBox_ModelName_SelectedIndexChanged);
            // 
            // lb_Loading
            // 
            this.lb_Loading.AutoSize = true;
            this.lb_Loading.BackColor = System.Drawing.Color.White;
            this.lb_Loading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_Loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Loading.Location = new System.Drawing.Point(16, 253);
            this.lb_Loading.Name = "lb_Loading";
            this.lb_Loading.Size = new System.Drawing.Size(128, 24);
            this.lb_Loading.TabIndex = 5;
            this.lb_Loading.Text = "Loading . . . . .";
            // 
            // txt_trainingInfo
            // 
            this.txt_trainingInfo.Location = new System.Drawing.Point(178, 75);
            this.txt_trainingInfo.Multiline = true;
            this.txt_trainingInfo.Name = "txt_trainingInfo";
            this.txt_trainingInfo.ReadOnly = true;
            this.txt_trainingInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_trainingInfo.Size = new System.Drawing.Size(260, 124);
            this.txt_trainingInfo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Training Info";
            // 
            // txt_modelName
            // 
            this.txt_modelName.Location = new System.Drawing.Point(178, 35);
            this.txt_modelName.Name = "txt_modelName";
            this.txt_modelName.ReadOnly = true;
            this.txt_modelName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_modelName.Size = new System.Drawing.Size(260, 20);
            this.txt_modelName.TabIndex = 4;
            this.txt_modelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ModelName";
            // 
            // UI_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UI_HomePage";
            this.Size = new System.Drawing.Size(448, 595);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_camera1_status;
        private System.Windows.Forms.Button bt_aiserver_Status;
        private System.Windows.Forms.Button bt_camera2_status;
        private System.Windows.Forms.Timer timer_fetch_api;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_ModelName;
        private System.Windows.Forms.TextBox txt_trainingInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_modelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_Loading;
        private UI_ImageDisplay uI_ImageDisplay1;
        private System.Windows.Forms.Button bt_MoreInfo;
    }
}
