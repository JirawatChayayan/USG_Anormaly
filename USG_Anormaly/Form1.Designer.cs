namespace USG_Anormaly
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.bt_LiveFront = new System.Windows.Forms.Button();
            this.bt_LiveSide = new System.Windows.Forms.Button();
            this.bt_LiveAll = new System.Windows.Forms.Button();
            this.bt_grabFront = new System.Windows.Forms.Button();
            this.bt_grabSide = new System.Windows.Forms.Button();
            this.hs_imgFront = new HalconDotNet.HSmartWindowControl();
            this.hs_imgSide = new HalconDotNet.HSmartWindowControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer_live = new System.Windows.Forms.Timer(this.components);
            this.bt_grabAll = new System.Windows.Forms.Button();
            this.uI_Anormaly_System1 = new USG_Anormaly.UI_Anormaly_System();
            this.hs_windowsOther = new HalconDotNet.HSmartWindowControl();
            this.SuspendLayout();
            // 
            // bt_LiveFront
            // 
            this.bt_LiveFront.Location = new System.Drawing.Point(12, 427);
            this.bt_LiveFront.Name = "bt_LiveFront";
            this.bt_LiveFront.Size = new System.Drawing.Size(123, 60);
            this.bt_LiveFront.TabIndex = 1;
            this.bt_LiveFront.Text = "Live Front";
            this.bt_LiveFront.UseVisualStyleBackColor = true;
            this.bt_LiveFront.Click += new System.EventHandler(this.bt_live_click);
            // 
            // bt_LiveSide
            // 
            this.bt_LiveSide.Location = new System.Drawing.Point(150, 427);
            this.bt_LiveSide.Name = "bt_LiveSide";
            this.bt_LiveSide.Size = new System.Drawing.Size(121, 60);
            this.bt_LiveSide.TabIndex = 1;
            this.bt_LiveSide.Text = "Live Side";
            this.bt_LiveSide.UseVisualStyleBackColor = true;
            this.bt_LiveSide.Click += new System.EventHandler(this.bt_live_click);
            // 
            // bt_LiveAll
            // 
            this.bt_LiveAll.Location = new System.Drawing.Point(285, 427);
            this.bt_LiveAll.Name = "bt_LiveAll";
            this.bt_LiveAll.Size = new System.Drawing.Size(119, 60);
            this.bt_LiveAll.TabIndex = 1;
            this.bt_LiveAll.Text = "Live All";
            this.bt_LiveAll.UseVisualStyleBackColor = true;
            this.bt_LiveAll.Click += new System.EventHandler(this.bt_live_click);
            // 
            // bt_grabFront
            // 
            this.bt_grabFront.Location = new System.Drawing.Point(431, 427);
            this.bt_grabFront.Name = "bt_grabFront";
            this.bt_grabFront.Size = new System.Drawing.Size(123, 60);
            this.bt_grabFront.TabIndex = 1;
            this.bt_grabFront.Text = "Grab Front";
            this.bt_grabFront.UseVisualStyleBackColor = true;
            this.bt_grabFront.Click += new System.EventHandler(this.bt_grabImg);
            // 
            // bt_grabSide
            // 
            this.bt_grabSide.Location = new System.Drawing.Point(560, 427);
            this.bt_grabSide.Name = "bt_grabSide";
            this.bt_grabSide.Size = new System.Drawing.Size(120, 60);
            this.bt_grabSide.TabIndex = 1;
            this.bt_grabSide.Text = "Grab Side";
            this.bt_grabSide.UseVisualStyleBackColor = true;
            this.bt_grabSide.Click += new System.EventHandler(this.bt_grabImg);
            // 
            // hs_imgFront
            // 
            this.hs_imgFront.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hs_imgFront.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.hs_imgFront.HDoubleClickToFitContent = true;
            this.hs_imgFront.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.hs_imgFront.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hs_imgFront.HKeepAspectRatio = true;
            this.hs_imgFront.HMoveContent = true;
            this.hs_imgFront.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.hs_imgFront.Location = new System.Drawing.Point(12, 39);
            this.hs_imgFront.Margin = new System.Windows.Forms.Padding(0);
            this.hs_imgFront.Name = "hs_imgFront";
            this.hs_imgFront.Size = new System.Drawing.Size(392, 364);
            this.hs_imgFront.TabIndex = 3;
            this.hs_imgFront.WindowSize = new System.Drawing.Size(392, 364);
            this.hs_imgFront.HMouseDoubleClick += new HalconDotNet.HMouseEventHandler(this.hs_imgFront_HMouseDoubleClick);
            // 
            // hs_imgSide
            // 
            this.hs_imgSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hs_imgSide.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.hs_imgSide.HDoubleClickToFitContent = true;
            this.hs_imgSide.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.hs_imgSide.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hs_imgSide.HKeepAspectRatio = true;
            this.hs_imgSide.HMoveContent = true;
            this.hs_imgSide.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.hs_imgSide.Location = new System.Drawing.Point(431, 39);
            this.hs_imgSide.Margin = new System.Windows.Forms.Padding(0);
            this.hs_imgSide.Name = "hs_imgSide";
            this.hs_imgSide.Size = new System.Drawing.Size(392, 364);
            this.hs_imgSide.TabIndex = 3;
            this.hs_imgSide.WindowSize = new System.Drawing.Size(392, 364);
            this.hs_imgSide.HMouseDoubleClick += new HalconDotNet.HMouseEventHandler(this.hs_imgSide_HMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "ImageFront";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(424, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "ImageSide";
            // 
            // timer_live
            // 
            this.timer_live.Interval = 2;
            this.timer_live.Tick += new System.EventHandler(this.timer_live_Tick);
            // 
            // bt_grabAll
            // 
            this.bt_grabAll.Location = new System.Drawing.Point(686, 427);
            this.bt_grabAll.Name = "bt_grabAll";
            this.bt_grabAll.Size = new System.Drawing.Size(132, 60);
            this.bt_grabAll.TabIndex = 1;
            this.bt_grabAll.Text = "Grab ALL";
            this.bt_grabAll.UseVisualStyleBackColor = true;
            this.bt_grabAll.Click += new System.EventHandler(this.bt_grabImg);
            // 
            // uI_Anormaly_System1
            // 
            this.uI_Anormaly_System1.Location = new System.Drawing.Point(833, 3);
            this.uI_Anormaly_System1.Name = "uI_Anormaly_System1";
            this.uI_Anormaly_System1.Size = new System.Drawing.Size(534, 600);
            this.uI_Anormaly_System1.TabIndex = 2;
            this.uI_Anormaly_System1.Load += new System.EventHandler(this.uI_Anormaly_System1_Load);
            // 
            // hs_windowsOther
            // 
            this.hs_windowsOther.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hs_windowsOther.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.hs_windowsOther.HDoubleClickToFitContent = true;
            this.hs_windowsOther.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.hs_windowsOther.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hs_windowsOther.HKeepAspectRatio = true;
            this.hs_windowsOther.HMoveContent = true;
            this.hs_windowsOther.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.hs_windowsOther.Location = new System.Drawing.Point(12, 511);
            this.hs_windowsOther.Margin = new System.Windows.Forms.Padding(0);
            this.hs_windowsOther.Name = "hs_windowsOther";
            this.hs_windowsOther.Size = new System.Drawing.Size(392, 364);
            this.hs_windowsOther.TabIndex = 3;
            this.hs_windowsOther.WindowSize = new System.Drawing.Size(392, 364);
            this.hs_windowsOther.HMouseDoubleClick += new HalconDotNet.HMouseEventHandler(this.hs_imgSide_HMouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 884);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hs_windowsOther);
            this.Controls.Add(this.hs_imgSide);
            this.Controls.Add(this.hs_imgFront);
            this.Controls.Add(this.uI_Anormaly_System1);
            this.Controls.Add(this.bt_grabAll);
            this.Controls.Add(this.bt_grabSide);
            this.Controls.Add(this.bt_grabFront);
            this.Controls.Add(this.bt_LiveSide);
            this.Controls.Add(this.bt_LiveAll);
            this.Controls.Add(this.bt_LiveFront);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_LiveFront;
        private System.Windows.Forms.Button bt_LiveSide;
        private System.Windows.Forms.Button bt_LiveAll;
        private System.Windows.Forms.Button bt_grabFront;
        private System.Windows.Forms.Button bt_grabSide;
        private UI_Anormaly_System uI_Anormaly_System1;
        private HalconDotNet.HSmartWindowControl hs_imgFront;
        private HalconDotNet.HSmartWindowControl hs_imgSide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_live;
        private System.Windows.Forms.Button bt_grabAll;
        private HalconDotNet.HSmartWindowControl hs_windowsOther;
    }
}

