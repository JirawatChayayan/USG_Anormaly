namespace USG_Anormaly
{
    partial class frmTestingModel
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_modelList = new System.Windows.Forms.ComboBox();
            this.bt_loadImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_test = new System.Windows.Forms.Button();
            this.image_List = new System.Windows.Forms.ListBox();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.panel_cameraIdx = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rad_side2 = new System.Windows.Forms.RadioButton();
            this.rad_side1 = new System.Windows.Forms.RadioButton();
            this.rad_front = new System.Windows.Forms.RadioButton();
            this.pb_imageTest = new HalconDotNet.HSmartWindowControl();
            this.pb_imgResult = new HalconDotNet.HSmartWindowControl();
            this.uI_testingProgressBar1 = new USG_Anormaly.UI_testingProgressBar();
            this.uI_result1 = new USG_Anormaly.UI_result();
            this.bgw_test1 = new System.ComponentModel.BackgroundWorker();
            this.panel_cameraIdx.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(262, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 25);
            this.label10.TabIndex = 10;
            this.label10.Text = "ImageTest";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(986, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "ImageResult";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Recipe";
            // 
            // comboBox_modelList
            // 
            this.comboBox_modelList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_modelList.FormattingEnabled = true;
            this.comboBox_modelList.Items.AddRange(new object[] {
            "Please Select . . ."});
            this.comboBox_modelList.Location = new System.Drawing.Point(4, 35);
            this.comboBox_modelList.Name = "comboBox_modelList";
            this.comboBox_modelList.Size = new System.Drawing.Size(254, 32);
            this.comboBox_modelList.TabIndex = 0;
            this.comboBox_modelList.Text = "Please Select . . .";
            // 
            // bt_loadImage
            // 
            this.bt_loadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_loadImage.Location = new System.Drawing.Point(4, 108);
            this.bt_loadImage.Name = "bt_loadImage";
            this.bt_loadImage.Size = new System.Drawing.Size(254, 40);
            this.bt_loadImage.TabIndex = 11;
            this.bt_loadImage.Text = "Load Image";
            this.bt_loadImage.UseVisualStyleBackColor = true;
            this.bt_loadImage.Click += new System.EventHandler(this.button_loadImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "LoadImage";
            // 
            // bt_test
            // 
            this.bt_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_test.Location = new System.Drawing.Point(2, 734);
            this.bt_test.Name = "bt_test";
            this.bt_test.Size = new System.Drawing.Size(254, 52);
            this.bt_test.TabIndex = 0;
            this.bt_test.Text = "Test !!!";
            this.bt_test.UseVisualStyleBackColor = true;
            this.bt_test.Click += new System.EventHandler(this.bt_test_Click);
            // 
            // image_List
            // 
            this.image_List.FormattingEnabled = true;
            this.image_List.Location = new System.Drawing.Point(4, 154);
            this.image_List.Name = "image_List";
            this.image_List.Size = new System.Drawing.Size(252, 537);
            this.image_List.TabIndex = 0;
            this.image_List.SelectedIndexChanged += new System.EventHandler(this.image_List_SelectedIndexChanged);
            // 
            // bt_refresh
            // 
            this.bt_refresh.Location = new System.Drawing.Point(185, 6);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(73, 25);
            this.bt_refresh.TabIndex = 11;
            this.bt_refresh.Text = "Refresh";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // panel_cameraIdx
            // 
            this.panel_cameraIdx.Controls.Add(this.label4);
            this.panel_cameraIdx.Controls.Add(this.rad_side2);
            this.panel_cameraIdx.Controls.Add(this.rad_side1);
            this.panel_cameraIdx.Controls.Add(this.rad_front);
            this.panel_cameraIdx.Location = new System.Drawing.Point(3, 695);
            this.panel_cameraIdx.Name = "panel_cameraIdx";
            this.panel_cameraIdx.Size = new System.Drawing.Size(252, 35);
            this.panel_cameraIdx.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Camera Idx";
            // 
            // rad_side2
            // 
            this.rad_side2.AutoSize = true;
            this.rad_side2.Location = new System.Drawing.Point(195, 9);
            this.rad_side2.Name = "rad_side2";
            this.rad_side2.Size = new System.Drawing.Size(52, 17);
            this.rad_side2.TabIndex = 12;
            this.rad_side2.Text = "Side2";
            this.rad_side2.UseVisualStyleBackColor = true;
            this.rad_side2.CheckedChanged += new System.EventHandler(this.rad_side2_CheckedChanged);
            // 
            // rad_side1
            // 
            this.rad_side1.AutoSize = true;
            this.rad_side1.Location = new System.Drawing.Point(139, 9);
            this.rad_side1.Name = "rad_side1";
            this.rad_side1.Size = new System.Drawing.Size(52, 17);
            this.rad_side1.TabIndex = 12;
            this.rad_side1.Text = "Side1";
            this.rad_side1.UseVisualStyleBackColor = true;
            this.rad_side1.CheckedChanged += new System.EventHandler(this.rad_side2_CheckedChanged);
            // 
            // rad_front
            // 
            this.rad_front.AutoSize = true;
            this.rad_front.Checked = true;
            this.rad_front.Location = new System.Drawing.Point(83, 9);
            this.rad_front.Name = "rad_front";
            this.rad_front.Size = new System.Drawing.Size(49, 17);
            this.rad_front.TabIndex = 12;
            this.rad_front.TabStop = true;
            this.rad_front.Text = "Front";
            this.rad_front.UseVisualStyleBackColor = true;
            this.rad_front.CheckedChanged += new System.EventHandler(this.rad_side2_CheckedChanged);
            // 
            // pb_imageTest
            // 
            this.pb_imageTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pb_imageTest.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.pb_imageTest.HDoubleClickToFitContent = true;
            this.pb_imageTest.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.pb_imageTest.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.pb_imageTest.HKeepAspectRatio = true;
            this.pb_imageTest.HMoveContent = true;
            this.pb_imageTest.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.pb_imageTest.Location = new System.Drawing.Point(262, 7);
            this.pb_imageTest.Margin = new System.Windows.Forms.Padding(0);
            this.pb_imageTest.Name = "pb_imageTest";
            this.pb_imageTest.Size = new System.Drawing.Size(720, 720);
            this.pb_imageTest.TabIndex = 12;
            this.pb_imageTest.WindowSize = new System.Drawing.Size(720, 720);
            // 
            // pb_imgResult
            // 
            this.pb_imgResult.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pb_imgResult.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.pb_imgResult.HDoubleClickToFitContent = true;
            this.pb_imgResult.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.pb_imgResult.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.pb_imgResult.HKeepAspectRatio = true;
            this.pb_imgResult.HMoveContent = true;
            this.pb_imgResult.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.pb_imgResult.Location = new System.Drawing.Point(986, 7);
            this.pb_imgResult.Margin = new System.Windows.Forms.Padding(0);
            this.pb_imgResult.Name = "pb_imgResult";
            this.pb_imgResult.Size = new System.Drawing.Size(720, 720);
            this.pb_imgResult.TabIndex = 12;
            this.pb_imgResult.WindowSize = new System.Drawing.Size(720, 720);
            // 
            // uI_testingProgressBar1
            // 
            this.uI_testingProgressBar1.Location = new System.Drawing.Point(262, 734);
            this.uI_testingProgressBar1.Name = "uI_testingProgressBar1";
            this.uI_testingProgressBar1.Size = new System.Drawing.Size(1444, 52);
            this.uI_testingProgressBar1.TabIndex = 13;
            // 
            // uI_result1
            // 
            this.uI_result1.Location = new System.Drawing.Point(262, 734);
            this.uI_result1.Name = "uI_result1";
            this.uI_result1.Size = new System.Drawing.Size(1444, 52);
            this.uI_result1.TabIndex = 14;
            // 
            // bgw_test1
            // 
            this.bgw_test1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_test1_DoWork);
            this.bgw_test1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_test1_ProgressChanged);
            this.bgw_test1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_test1_RunWorkerCompleted);
            // 
            // frmTestingModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1711, 791);
            this.Controls.Add(this.uI_result1);
            this.Controls.Add(this.uI_testingProgressBar1);
            this.Controls.Add(this.panel_cameraIdx);
            this.Controls.Add(this.image_List);
            this.Controls.Add(this.bt_test);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.bt_loadImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox_modelList);
            this.Controls.Add(this.pb_imageTest);
            this.Controls.Add(this.pb_imgResult);
            this.Name = "frmTestingModel";
            this.Text = "frmTestingModel";
            this.panel_cameraIdx.ResumeLayout(false);
            this.panel_cameraIdx.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_modelList;
        private System.Windows.Forms.Button bt_loadImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_test;
        private System.Windows.Forms.ListBox image_List;
        private System.Windows.Forms.Button bt_refresh;
        private System.Windows.Forms.Panel panel_cameraIdx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rad_side2;
        private System.Windows.Forms.RadioButton rad_side1;
        private System.Windows.Forms.RadioButton rad_front;
        private HalconDotNet.HSmartWindowControl pb_imageTest;
        private HalconDotNet.HSmartWindowControl pb_imgResult;
        private UI_testingProgressBar uI_testingProgressBar1;
        private UI_result uI_result1;
        private System.ComponentModel.BackgroundWorker bgw_test1;
    }
}