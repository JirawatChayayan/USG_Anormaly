namespace USG_Anormaly
{
    partial class UI_Anormaly_System
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
            this.bt_home = new System.Windows.Forms.Button();
            this.bt_camera_setting = new System.Windows.Forms.Button();
            this.bt_anormaly_training = new System.Windows.Forms.Button();
            this.bt_anormaly_testing = new System.Windows.Forms.Button();
            this.bt_TrainingStatus = new System.Windows.Forms.Button();
            this.uI_HomePage1 = new USG_Anormaly.UI_HomePage();
            this.uI_CameraSetting1 = new USG_Anormaly.UI_CameraSetting();
            this.uI_Training1 = new USG_Anormaly.UI_Training();
            this.uI_CurrentServerState1 = new USG_Anormaly.UI_CurrentServerState();
            this.SuspendLayout();
            // 
            // bt_home
            // 
            this.bt_home.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_home.ForeColor = System.Drawing.Color.Transparent;
            this.bt_home.Location = new System.Drawing.Point(7, 7);
            this.bt_home.Name = "bt_home";
            this.bt_home.Size = new System.Drawing.Size(73, 44);
            this.bt_home.TabIndex = 0;
            this.bt_home.Text = "Home";
            this.bt_home.UseVisualStyleBackColor = false;
            this.bt_home.Click += new System.EventHandler(this.bt_menu);
            // 
            // bt_camera_setting
            // 
            this.bt_camera_setting.BackColor = System.Drawing.Color.Transparent;
            this.bt_camera_setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_camera_setting.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bt_camera_setting.Location = new System.Drawing.Point(7, 57);
            this.bt_camera_setting.Name = "bt_camera_setting";
            this.bt_camera_setting.Size = new System.Drawing.Size(73, 44);
            this.bt_camera_setting.TabIndex = 0;
            this.bt_camera_setting.Text = "Camera Setting";
            this.bt_camera_setting.UseVisualStyleBackColor = false;
            this.bt_camera_setting.Click += new System.EventHandler(this.bt_menu);
            // 
            // bt_anormaly_training
            // 
            this.bt_anormaly_training.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_anormaly_training.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bt_anormaly_training.Location = new System.Drawing.Point(7, 108);
            this.bt_anormaly_training.Name = "bt_anormaly_training";
            this.bt_anormaly_training.Size = new System.Drawing.Size(73, 44);
            this.bt_anormaly_training.TabIndex = 0;
            this.bt_anormaly_training.Text = "Anormaly Training";
            this.bt_anormaly_training.UseVisualStyleBackColor = true;
            this.bt_anormaly_training.Click += new System.EventHandler(this.bt_menu);
            // 
            // bt_anormaly_testing
            // 
            this.bt_anormaly_testing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_anormaly_testing.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bt_anormaly_testing.Location = new System.Drawing.Point(7, 208);
            this.bt_anormaly_testing.Name = "bt_anormaly_testing";
            this.bt_anormaly_testing.Size = new System.Drawing.Size(73, 44);
            this.bt_anormaly_testing.TabIndex = 0;
            this.bt_anormaly_testing.Text = "Anormaly Testing";
            this.bt_anormaly_testing.UseVisualStyleBackColor = true;
            this.bt_anormaly_testing.Click += new System.EventHandler(this.bt_menu);
            // 
            // bt_TrainingStatus
            // 
            this.bt_TrainingStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_TrainingStatus.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bt_TrainingStatus.Location = new System.Drawing.Point(7, 158);
            this.bt_TrainingStatus.Name = "bt_TrainingStatus";
            this.bt_TrainingStatus.Size = new System.Drawing.Size(73, 44);
            this.bt_TrainingStatus.TabIndex = 0;
            this.bt_TrainingStatus.Text = "Training Status";
            this.bt_TrainingStatus.UseVisualStyleBackColor = true;
            this.bt_TrainingStatus.Click += new System.EventHandler(this.bt_menu);
            // 
            // uI_HomePage1
            // 
            this.uI_HomePage1.Location = new System.Drawing.Point(84, 2);
            this.uI_HomePage1.Name = "uI_HomePage1";
            this.uI_HomePage1.Size = new System.Drawing.Size(448, 594);
            this.uI_HomePage1.TabIndex = 1;
            // 
            // uI_CameraSetting1
            // 
            this.uI_CameraSetting1.Location = new System.Drawing.Point(84, 2);
            this.uI_CameraSetting1.Name = "uI_CameraSetting1";
            this.uI_CameraSetting1.Size = new System.Drawing.Size(448, 595);
            this.uI_CameraSetting1.TabIndex = 2;
            // 
            // uI_Training1
            // 
            this.uI_Training1.Location = new System.Drawing.Point(84, 2);
            this.uI_Training1.Name = "uI_Training1";
            this.uI_Training1.Size = new System.Drawing.Size(448, 595);
            this.uI_Training1.TabIndex = 3;
            // 
            // uI_CurrentServerState1
            // 
            this.uI_CurrentServerState1.Location = new System.Drawing.Point(84, 2);
            this.uI_CurrentServerState1.Name = "uI_CurrentServerState1";
            this.uI_CurrentServerState1.Size = new System.Drawing.Size(448, 595);
            this.uI_CurrentServerState1.TabIndex = 4;
            // 
            // UI_Anormaly_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bt_TrainingStatus);
            this.Controls.Add(this.bt_anormaly_testing);
            this.Controls.Add(this.bt_anormaly_training);
            this.Controls.Add(this.bt_camera_setting);
            this.Controls.Add(this.bt_home);
            this.Controls.Add(this.uI_HomePage1);
            this.Controls.Add(this.uI_CameraSetting1);
            this.Controls.Add(this.uI_Training1);
            this.Controls.Add(this.uI_CurrentServerState1);
            this.Name = "UI_Anormaly_System";
            this.Size = new System.Drawing.Size(534, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_home;
        private System.Windows.Forms.Button bt_camera_setting;
        private System.Windows.Forms.Button bt_anormaly_training;
        private System.Windows.Forms.Button bt_anormaly_testing;
        private UI_HomePage uI_HomePage1;
        private UI_CameraSetting uI_CameraSetting1;
        private UI_Training uI_Training1;
        private System.Windows.Forms.Button bt_TrainingStatus;
        private UI_CurrentServerState uI_CurrentServerState1;
    }
}
