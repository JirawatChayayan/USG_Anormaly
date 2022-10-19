namespace USG_Anormaly
{
    partial class Sub_UI_LigthinController2
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
            this.ui_front = new USG_Anormaly.Sub_UI_LightingControl();
            this.ui_side = new USG_Anormaly.Sub_UI_LightingControl();
            this.ui_side2 = new USG_Anormaly.Sub_UI_LightingControl();
            this.SuspendLayout();
            // 
            // ui_front
            // 
            this.ui_front.IsActivated = false;
            this.ui_front.lightingFor = USG_Anormaly_lib.CameraIdx.Front;
            this.ui_front.Location = new System.Drawing.Point(3, 0);
            this.ui_front.Name = "ui_front";
            this.ui_front.Size = new System.Drawing.Size(142, 291);
            this.ui_front.TabIndex = 0;
            // 
            // ui_side
            // 
            this.ui_side.IsActivated = false;
            this.ui_side.lightingFor = USG_Anormaly_lib.CameraIdx.Front;
            this.ui_side.Location = new System.Drawing.Point(147, 0);
            this.ui_side.Name = "ui_side";
            this.ui_side.Size = new System.Drawing.Size(142, 291);
            this.ui_side.TabIndex = 0;
            // 
            // ui_side2
            // 
            this.ui_side2.IsActivated = false;
            this.ui_side2.lightingFor = USG_Anormaly_lib.CameraIdx.Front;
            this.ui_side2.Location = new System.Drawing.Point(293, 0);
            this.ui_side2.Name = "ui_side2";
            this.ui_side2.Size = new System.Drawing.Size(142, 291);
            this.ui_side2.TabIndex = 0;
            // 
            // Sub_UI_LigthinController2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_side2);
            this.Controls.Add(this.ui_side);
            this.Controls.Add(this.ui_front);
            this.Name = "Sub_UI_LigthinController2";
            this.Size = new System.Drawing.Size(437, 292);
            this.ResumeLayout(false);

        }

        #endregion

        private Sub_UI_LightingControl ui_front;
        private Sub_UI_LightingControl ui_side;
        private Sub_UI_LightingControl ui_side2;
    }
}
