namespace USG_Anormaly
{
    partial class UI_ParameterTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_ParameterTrain));
            this.trackBar_NumEpochs = new System.Windows.Forms.TrackBar();
            this.label_NumEpochs_Value = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox_Pretrained_DL = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_TrainingImgSize = new System.Windows.Forms.ComboBox();
            this.comboBox_Spilt_Data = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_defaultGeneral = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel_Complexity = new System.Windows.Forms.Panel();
            this.numericUpDown_Complexity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Error_Threshold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Regularization_Noise = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Domain_Ratio = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.numericUpDown_SD_Factor = new System.Windows.Forms.NumericUpDown();
            this.button_defaultHyperParam = new System.Windows.Forms.Button();
            this.toolTip_detail_parameter = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_NumEpochs)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Complexity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Error_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Regularization_Noise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Domain_Ratio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SD_Factor)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar_NumEpochs
            // 
            this.trackBar_NumEpochs.BackColor = System.Drawing.Color.White;
            this.trackBar_NumEpochs.LargeChange = 1;
            this.trackBar_NumEpochs.Location = new System.Drawing.Point(83, 146);
            this.trackBar_NumEpochs.Maximum = 1000;
            this.trackBar_NumEpochs.Minimum = 10;
            this.trackBar_NumEpochs.Name = "trackBar_NumEpochs";
            this.trackBar_NumEpochs.Size = new System.Drawing.Size(300, 45);
            this.trackBar_NumEpochs.TabIndex = 63;
            this.trackBar_NumEpochs.Value = 100;
            this.trackBar_NumEpochs.Scroll += new System.EventHandler(this.trackBar_NumEpochs_Scroll);
            // 
            // label_NumEpochs_Value
            // 
            this.label_NumEpochs_Value.AutoSize = true;
            this.label_NumEpochs_Value.Location = new System.Drawing.Point(32, 168);
            this.label_NumEpochs_Value.Name = "label_NumEpochs_Value";
            this.label_NumEpochs_Value.Size = new System.Drawing.Size(10, 13);
            this.label_NumEpochs_Value.TabIndex = 61;
            this.label_NumEpochs_Value.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 62;
            this.label13.Text = "NumEpochs";
            // 
            // comboBox_Pretrained_DL
            // 
            this.comboBox_Pretrained_DL.DisplayMember = "1";
            this.comboBox_Pretrained_DL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Pretrained_DL.FormattingEnabled = true;
            this.comboBox_Pretrained_DL.Items.AddRange(new object[] {
            "initial_dl_anomaly_medium.hdl",
            "initial_dl_anomaly_large.hdl"});
            this.comboBox_Pretrained_DL.Location = new System.Drawing.Point(92, 11);
            this.comboBox_Pretrained_DL.Name = "comboBox_Pretrained_DL";
            this.comboBox_Pretrained_DL.Size = new System.Drawing.Size(291, 21);
            this.comboBox_Pretrained_DL.TabIndex = 60;
            this.comboBox_Pretrained_DL.ValueMember = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "TrainingImgSize";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Split DL dataset";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "TrainingPercent/ValidationPercent/TestingPercent";
            // 
            // comboBox_TrainingImgSize
            // 
            this.comboBox_TrainingImgSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TrainingImgSize.FormattingEnabled = true;
            this.comboBox_TrainingImgSize.Items.AddRange(new object[] {
            "1728 X 1312",
            "1312 X 992",
            "1024 X 768",
            "864 X 640"});
            this.comboBox_TrainingImgSize.Location = new System.Drawing.Point(88, 66);
            this.comboBox_TrainingImgSize.Name = "comboBox_TrainingImgSize";
            this.comboBox_TrainingImgSize.Size = new System.Drawing.Size(289, 21);
            this.comboBox_TrainingImgSize.TabIndex = 57;
            // 
            // comboBox_Spilt_Data
            // 
            this.comboBox_Spilt_Data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Spilt_Data.FormattingEnabled = true;
            this.comboBox_Spilt_Data.Items.AddRange(new object[] {
            "60/20/20",
            "70/15/15",
            "80/10/10"});
            this.comboBox_Spilt_Data.Location = new System.Drawing.Point(88, 36);
            this.comboBox_Spilt_Data.Name = "comboBox_Spilt_Data";
            this.comboBox_Spilt_Data.Size = new System.Drawing.Size(289, 21);
            this.comboBox_Spilt_Data.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Pretrained DL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(5, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 31);
            this.label4.TabIndex = 68;
            this.label4.Text = "Structural anomalies";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(5, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 25);
            this.label5.TabIndex = 65;
            this.label5.Text = "Anomaly Detection";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(8, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(286, 15);
            this.label6.TabIndex = 67;
            this.label6.Text = "A score is assigned to every pixel of the input image";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(8, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(375, 15);
            this.label8.TabIndex = 66;
            this.label8.Text = "Assign to each pixel the likelihood that it shows an unknown feature.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_defaultGeneral);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBox_Spilt_Data);
            this.groupBox1.Controls.Add(this.comboBox_TrainingImgSize);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label_NumEpochs_Value);
            this.groupBox1.Controls.Add(this.trackBar_NumEpochs);
            this.groupBox1.Location = new System.Drawing.Point(6, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 215);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Parameter of Deep learning ";
            // 
            // button_defaultGeneral
            // 
            this.button_defaultGeneral.Location = new System.Drawing.Point(251, 182);
            this.button_defaultGeneral.Name = "button_defaultGeneral";
            this.button_defaultGeneral.Size = new System.Drawing.Size(126, 27);
            this.button_defaultGeneral.TabIndex = 65;
            this.button_defaultGeneral.Text = "Default";
            this.button_defaultGeneral.UseVisualStyleBackColor = true;
            this.button_defaultGeneral.Click += new System.EventHandler(this.button_defaultGeneral_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(344, 39);
            this.label9.TabIndex = 64;
            this.label9.Text = "* Define the input image size. It should be chosen sufficiently large such\r\n* tha" +
    "t small defects are still visible.\r\n* restrictions depending on the network type" +
    ".";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Controls.Add(this.button_defaultHyperParam);
            this.groupBox2.Location = new System.Drawing.Point(5, 467);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 224);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "hyper parameter";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.84848F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.15152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.69697F));
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel_Complexity, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_Complexity, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_Error_Threshold, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_Regularization_Noise, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_Domain_Ratio, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_SD_Factor, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(333, 163);
            this.tableLayoutPanel1.TabIndex = 42;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(46, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Complexity";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(269, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(34, 26);
            this.panel3.TabIndex = 41;
            this.toolTip_detail_parameter.SetToolTip(this.panel3, "* Regularization noise can help to make the training more robust.");
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Error Threshold";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(269, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(34, 26);
            this.panel1.TabIndex = 41;
            this.toolTip_detail_parameter.SetToolTip(this.panel1, "* Set the domain ratio which controls the fraction of each image used for trainin" +
        "g.");
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Domain Ratio";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(269, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(34, 26);
            this.panel4.TabIndex = 41;
            this.toolTip_detail_parameter.SetToolTip(this.panel4, "* Set a threshold for the training error and a maximum number of training epochs." +
        "");
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Regularization Noise";
            // 
            // panel_Complexity
            // 
            this.panel_Complexity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel_Complexity.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Complexity.BackgroundImage")));
            this.panel_Complexity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Complexity.Location = new System.Drawing.Point(269, 3);
            this.panel_Complexity.Name = "panel_Complexity";
            this.panel_Complexity.Size = new System.Drawing.Size(34, 26);
            this.panel_Complexity.TabIndex = 41;
            this.toolTip_detail_parameter.SetToolTip(this.panel_Complexity, "* Set the complexity which describes the capability of the model to handle");
            // 
            // numericUpDown_Complexity
            // 
            this.numericUpDown_Complexity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown_Complexity.Location = new System.Drawing.Point(155, 6);
            this.numericUpDown_Complexity.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_Complexity.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Complexity.Name = "numericUpDown_Complexity";
            this.numericUpDown_Complexity.Size = new System.Drawing.Size(104, 20);
            this.numericUpDown_Complexity.TabIndex = 29;
            this.numericUpDown_Complexity.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numericUpDown_Error_Threshold
            // 
            this.numericUpDown_Error_Threshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown_Error_Threshold.DecimalPlaces = 4;
            this.numericUpDown_Error_Threshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDown_Error_Threshold.Location = new System.Drawing.Point(155, 38);
            this.numericUpDown_Error_Threshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Error_Threshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDown_Error_Threshold.Name = "numericUpDown_Error_Threshold";
            this.numericUpDown_Error_Threshold.Size = new System.Drawing.Size(104, 20);
            this.numericUpDown_Error_Threshold.TabIndex = 29;
            this.numericUpDown_Error_Threshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // numericUpDown_Regularization_Noise
            // 
            this.numericUpDown_Regularization_Noise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown_Regularization_Noise.DecimalPlaces = 3;
            this.numericUpDown_Regularization_Noise.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown_Regularization_Noise.Location = new System.Drawing.Point(155, 102);
            this.numericUpDown_Regularization_Noise.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Regularization_Noise.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown_Regularization_Noise.Name = "numericUpDown_Regularization_Noise";
            this.numericUpDown_Regularization_Noise.Size = new System.Drawing.Size(104, 20);
            this.numericUpDown_Regularization_Noise.TabIndex = 29;
            this.numericUpDown_Regularization_Noise.Value = new decimal(new int[] {
            10,
            0,
            0,
            196608});
            // 
            // numericUpDown_Domain_Ratio
            // 
            this.numericUpDown_Domain_Ratio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown_Domain_Ratio.DecimalPlaces = 2;
            this.numericUpDown_Domain_Ratio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_Domain_Ratio.Location = new System.Drawing.Point(155, 70);
            this.numericUpDown_Domain_Ratio.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.numericUpDown_Domain_Ratio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_Domain_Ratio.Name = "numericUpDown_Domain_Ratio";
            this.numericUpDown_Domain_Ratio.Size = new System.Drawing.Size(104, 20);
            this.numericUpDown_Domain_Ratio.TabIndex = 29;
            this.numericUpDown_Domain_Ratio.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Standard Deviation Factor";
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(269, 131);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(34, 29);
            this.panel5.TabIndex = 41;
            this.toolTip_detail_parameter.SetToolTip(this.panel5, "* Set the factor used to calculate the anomaly score. ");
            // 
            // numericUpDown_SD_Factor
            // 
            this.numericUpDown_SD_Factor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown_SD_Factor.DecimalPlaces = 1;
            this.numericUpDown_SD_Factor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_SD_Factor.Location = new System.Drawing.Point(155, 135);
            this.numericUpDown_SD_Factor.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_SD_Factor.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDown_SD_Factor.Name = "numericUpDown_SD_Factor";
            this.numericUpDown_SD_Factor.Size = new System.Drawing.Size(104, 20);
            this.numericUpDown_SD_Factor.TabIndex = 29;
            this.numericUpDown_SD_Factor.Value = new decimal(new int[] {
            30,
            0,
            0,
            65536});
            // 
            // button_defaultHyperParam
            // 
            this.button_defaultHyperParam.Location = new System.Drawing.Point(252, 191);
            this.button_defaultHyperParam.Name = "button_defaultHyperParam";
            this.button_defaultHyperParam.Size = new System.Drawing.Size(126, 27);
            this.button_defaultHyperParam.TabIndex = 40;
            this.button_defaultHyperParam.Text = "Default";
            this.button_defaultHyperParam.UseVisualStyleBackColor = true;
            this.button_defaultHyperParam.Click += new System.EventHandler(this.button_defaultHyperParam_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::USG_Anormaly.Properties.Resources.overview2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(61, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 87);
            this.panel2.TabIndex = 64;
            // 
            // UI_ParameterTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox_Pretrained_DL);
            this.Controls.Add(this.label1);
            this.Name = "UI_ParameterTrain";
            this.Size = new System.Drawing.Size(399, 696);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_NumEpochs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Complexity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Error_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Regularization_Noise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Domain_Ratio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SD_Factor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar_NumEpochs;
        private System.Windows.Forms.Label label_NumEpochs_Value;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox comboBox_Pretrained_DL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_TrainingImgSize;
        private System.Windows.Forms.ComboBox comboBox_Spilt_Data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_defaultGeneral;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel_Complexity;
        private System.Windows.Forms.NumericUpDown numericUpDown_Complexity;
        private System.Windows.Forms.NumericUpDown numericUpDown_Error_Threshold;
        private System.Windows.Forms.NumericUpDown numericUpDown_Regularization_Noise;
        private System.Windows.Forms.NumericUpDown numericUpDown_Domain_Ratio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown numericUpDown_SD_Factor;
        private System.Windows.Forms.Button button_defaultHyperParam;
        private System.Windows.Forms.ToolTip toolTip_detail_parameter;
    }
}
