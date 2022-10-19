namespace USG_Anormaly
{
    partial class UI_CameraControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_captureTime = new System.Windows.Forms.Label();
            this.cb_flip_hor = new System.Windows.Forms.CheckBox();
            this.cb_flip_ver = new System.Windows.Forms.CheckBox();
            this.txt_expouserTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_exposureTime = new System.Windows.Forms.TrackBar();
            this.bt_camera_status = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lb_camRotateZ = new System.Windows.Forms.Label();
            this.lb_camPosZ = new System.Windows.Forms.Label();
            this.lb_camRotateY = new System.Windows.Forms.Label();
            this.lb_camPosY = new System.Windows.Forms.Label();
            this.lb_camRotateX = new System.Windows.Forms.Label();
            this.lb_camPosX = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lb_camParam_FocalLength = new System.Windows.Forms.Label();
            this.lb_camParam_Sy = new System.Windows.Forms.Label();
            this.lb_camParam_Sx = new System.Windows.Forms.Label();
            this.bt_uploadCamParam = new System.Windows.Forms.Button();
            this.bt_upload_camPos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_exposureTime)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_captureTime);
            this.groupBox1.Controls.Add(this.cb_flip_hor);
            this.groupBox1.Controls.Add(this.cb_flip_ver);
            this.groupBox1.Controls.Add(this.txt_expouserTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_exposureTime);
            this.groupBox1.Controls.Add(this.bt_camera_status);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 592);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Front";
            // 
            // lb_captureTime
            // 
            this.lb_captureTime.AutoSize = true;
            this.lb_captureTime.Location = new System.Drawing.Point(114, 74);
            this.lb_captureTime.Name = "lb_captureTime";
            this.lb_captureTime.Size = new System.Drawing.Size(92, 13);
            this.lb_captureTime.TabIndex = 18;
            this.lb_captureTime.Text = "CaptureTime -- ms";
            // 
            // cb_flip_hor
            // 
            this.cb_flip_hor.AutoSize = true;
            this.cb_flip_hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_flip_hor.Location = new System.Drawing.Point(54, 316);
            this.cb_flip_hor.Name = "cb_flip_hor";
            this.cb_flip_hor.Size = new System.Drawing.Size(113, 28);
            this.cb_flip_hor.TabIndex = 14;
            this.cb_flip_hor.Text = "Horizontal";
            this.cb_flip_hor.UseVisualStyleBackColor = true;
            this.cb_flip_hor.Click += new System.EventHandler(this.cb_flip_Click);
            // 
            // cb_flip_ver
            // 
            this.cb_flip_ver.AutoSize = true;
            this.cb_flip_ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_flip_ver.Location = new System.Drawing.Point(54, 282);
            this.cb_flip_ver.Name = "cb_flip_ver";
            this.cb_flip_ver.Size = new System.Drawing.Size(91, 28);
            this.cb_flip_ver.TabIndex = 15;
            this.cb_flip_ver.Text = "Vertical";
            this.cb_flip_ver.UseVisualStyleBackColor = true;
            this.cb_flip_ver.Click += new System.EventHandler(this.cb_flip_Click);
            // 
            // txt_expouserTime
            // 
            this.txt_expouserTime.BackColor = System.Drawing.SystemColors.Control;
            this.txt_expouserTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_expouserTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_expouserTime.Location = new System.Drawing.Point(25, 142);
            this.txt_expouserTime.Name = "txt_expouserTime";
            this.txt_expouserTime.Size = new System.Drawing.Size(185, 73);
            this.txt_expouserTime.TabIndex = 13;
            this.txt_expouserTime.Text = "8000";
            this.txt_expouserTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Flip Image";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Exposure Time";
            // 
            // tb_exposureTime
            // 
            this.tb_exposureTime.LargeChange = 10;
            this.tb_exposureTime.Location = new System.Drawing.Point(0, 74);
            this.tb_exposureTime.Maximum = 15000;
            this.tb_exposureTime.Minimum = 1000;
            this.tb_exposureTime.Name = "tb_exposureTime";
            this.tb_exposureTime.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tb_exposureTime.Size = new System.Drawing.Size(45, 176);
            this.tb_exposureTime.TabIndex = 9;
            this.tb_exposureTime.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_exposureTime.Value = 8000;
            this.tb_exposureTime.Scroll += new System.EventHandler(this.tb_exposureTime_Scroll);
            this.tb_exposureTime.ValueChanged += new System.EventHandler(this.tb_focus_ValueChanged);
            this.tb_exposureTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tb_focus_MouseUp);
            // 
            // bt_camera_status
            // 
            this.bt_camera_status.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_camera_status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_camera_status.ForeColor = System.Drawing.Color.Black;
            this.bt_camera_status.Location = new System.Drawing.Point(11, 23);
            this.bt_camera_status.Name = "bt_camera_status";
            this.bt_camera_status.Size = new System.Drawing.Size(195, 45);
            this.bt_camera_status.TabIndex = 8;
            this.bt_camera_status.Text = "Camera Front";
            this.bt_camera_status.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.bt_uploadCamParam);
            this.panel2.Controls.Add(this.bt_upload_camPos);
            this.panel2.Location = new System.Drawing.Point(5, 356);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 230);
            this.panel2.TabIndex = 17;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 114);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 116);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lb_camRotateZ);
            this.tabPage1.Controls.Add(this.lb_camPosZ);
            this.tabPage1.Controls.Add(this.lb_camRotateY);
            this.tabPage1.Controls.Add(this.lb_camPosY);
            this.tabPage1.Controls.Add(this.lb_camRotateX);
            this.tabPage1.Controls.Add(this.lb_camPosX);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 90);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CameraPose";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lb_camRotateZ
            // 
            this.lb_camRotateZ.AutoSize = true;
            this.lb_camRotateZ.Location = new System.Drawing.Point(95, 62);
            this.lb_camRotateZ.Name = "lb_camRotateZ";
            this.lb_camRotateZ.Size = new System.Drawing.Size(58, 13);
            this.lb_camRotateZ.TabIndex = 19;
            this.lb_camRotateZ.Text = "RZ : 0 deg";
            // 
            // lb_camPosZ
            // 
            this.lb_camPosZ.AutoSize = true;
            this.lb_camPosZ.Location = new System.Drawing.Point(8, 62);
            this.lb_camPosZ.Name = "lb_camPosZ";
            this.lb_camPosZ.Size = new System.Drawing.Size(48, 13);
            this.lb_camPosZ.TabIndex = 20;
            this.lb_camPosZ.Text = "Z : 0 mm";
            // 
            // lb_camRotateY
            // 
            this.lb_camRotateY.AutoSize = true;
            this.lb_camRotateY.Location = new System.Drawing.Point(95, 38);
            this.lb_camRotateY.Name = "lb_camRotateY";
            this.lb_camRotateY.Size = new System.Drawing.Size(58, 13);
            this.lb_camRotateY.TabIndex = 21;
            this.lb_camRotateY.Text = "RY : 0 deg";
            // 
            // lb_camPosY
            // 
            this.lb_camPosY.AutoSize = true;
            this.lb_camPosY.Location = new System.Drawing.Point(8, 38);
            this.lb_camPosY.Name = "lb_camPosY";
            this.lb_camPosY.Size = new System.Drawing.Size(48, 13);
            this.lb_camPosY.TabIndex = 22;
            this.lb_camPosY.Text = "Y : 0 mm";
            // 
            // lb_camRotateX
            // 
            this.lb_camRotateX.AutoSize = true;
            this.lb_camRotateX.Location = new System.Drawing.Point(95, 15);
            this.lb_camRotateX.Name = "lb_camRotateX";
            this.lb_camRotateX.Size = new System.Drawing.Size(58, 13);
            this.lb_camRotateX.TabIndex = 23;
            this.lb_camRotateX.Text = "RX : 0 deg";
            // 
            // lb_camPosX
            // 
            this.lb_camPosX.AutoSize = true;
            this.lb_camPosX.Location = new System.Drawing.Point(8, 15);
            this.lb_camPosX.Name = "lb_camPosX";
            this.lb_camPosX.Size = new System.Drawing.Size(48, 13);
            this.lb_camPosX.TabIndex = 24;
            this.lb_camPosX.Text = "X : 0 mm";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lb_camParam_FocalLength);
            this.tabPage2.Controls.Add(this.lb_camParam_Sy);
            this.tabPage2.Controls.Add(this.lb_camParam_Sx);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 90);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CameraParam";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lb_camParam_FocalLength
            // 
            this.lb_camParam_FocalLength.AutoSize = true;
            this.lb_camParam_FocalLength.Location = new System.Drawing.Point(8, 62);
            this.lb_camParam_FocalLength.Name = "lb_camParam_FocalLength";
            this.lb_camParam_FocalLength.Size = new System.Drawing.Size(118, 13);
            this.lb_camParam_FocalLength.TabIndex = 0;
            this.lb_camParam_FocalLength.Text = "Focal Length : 1.40 mm";
            // 
            // lb_camParam_Sy
            // 
            this.lb_camParam_Sy.AutoSize = true;
            this.lb_camParam_Sy.Location = new System.Drawing.Point(8, 38);
            this.lb_camParam_Sy.Name = "lb_camParam_Sy";
            this.lb_camParam_Sy.Size = new System.Drawing.Size(129, 13);
            this.lb_camParam_Sy.TabIndex = 0;
            this.lb_camParam_Sy.Text = "Cell Height (Sy)  : 1.40 um";
            // 
            // lb_camParam_Sx
            // 
            this.lb_camParam_Sx.AutoSize = true;
            this.lb_camParam_Sx.Location = new System.Drawing.Point(8, 15);
            this.lb_camParam_Sx.Name = "lb_camParam_Sx";
            this.lb_camParam_Sx.Size = new System.Drawing.Size(126, 13);
            this.lb_camParam_Sx.TabIndex = 0;
            this.lb_camParam_Sx.Text = "Cell Width (Sx)  : 1.40 um";
            // 
            // bt_uploadCamParam
            // 
            this.bt_uploadCamParam.Location = new System.Drawing.Point(2, 58);
            this.bt_uploadCamParam.Name = "bt_uploadCamParam";
            this.bt_uploadCamParam.Size = new System.Drawing.Size(200, 52);
            this.bt_uploadCamParam.TabIndex = 16;
            this.bt_uploadCamParam.Text = "Upload Parameter File (.cal)";
            this.bt_uploadCamParam.UseVisualStyleBackColor = true;
            this.bt_uploadCamParam.Click += new System.EventHandler(this.bt_uploadCal_Click);
            // 
            // bt_upload_camPos
            // 
            this.bt_upload_camPos.Location = new System.Drawing.Point(2, 3);
            this.bt_upload_camPos.Name = "bt_upload_camPos";
            this.bt_upload_camPos.Size = new System.Drawing.Size(200, 52);
            this.bt_upload_camPos.TabIndex = 16;
            this.bt_upload_camPos.Text = "Upload Camera Pose File (.dat)";
            this.bt_upload_camPos.UseVisualStyleBackColor = true;
            this.bt_upload_camPos.Click += new System.EventHandler(this.bt_uploadCal_Click);
            // 
            // UI_CameraControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UI_CameraControl";
            this.Size = new System.Drawing.Size(221, 595);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_exposureTime)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_flip_hor;
        private System.Windows.Forms.CheckBox cb_flip_ver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_camera_status;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lb_camRotateZ;
        private System.Windows.Forms.Label lb_camPosZ;
        private System.Windows.Forms.Label lb_camRotateY;
        private System.Windows.Forms.Label lb_camPosY;
        private System.Windows.Forms.Label lb_camRotateX;
        private System.Windows.Forms.Label lb_camPosX;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lb_camParam_FocalLength;
        private System.Windows.Forms.Label lb_camParam_Sy;
        private System.Windows.Forms.Label lb_camParam_Sx;
        private System.Windows.Forms.Button bt_uploadCamParam;
        private System.Windows.Forms.Button bt_upload_camPos;
        private System.Windows.Forms.TextBox txt_expouserTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tb_exposureTime;
        private System.Windows.Forms.Label lb_captureTime;
    }
}
