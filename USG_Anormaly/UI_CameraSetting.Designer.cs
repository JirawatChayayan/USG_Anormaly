namespace USG_Anormaly
{
    partial class UI_CameraSetting
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
            this.uI_CameraControl_side = new USG_Anormaly.UI_CameraControl();
            this.uI_CameraControl_front = new USG_Anormaly.UI_CameraControl();
            this.SuspendLayout();
            // 
            // uI_CameraControl_side
            // 
            this.uI_CameraControl_side.Enabled = false;
            this.uI_CameraControl_side.Location = new System.Drawing.Point(225, 2);
            this.uI_CameraControl_side.Name = "uI_CameraControl_side";
            this.uI_CameraControl_side.Size = new System.Drawing.Size(221, 595);
            this.uI_CameraControl_side.TabIndex = 0;
            // 
            // uI_CameraControl_front
            // 
            this.uI_CameraControl_front.Enabled = false;
            this.uI_CameraControl_front.Location = new System.Drawing.Point(1, 2);
            this.uI_CameraControl_front.Name = "uI_CameraControl_front";
            this.uI_CameraControl_front.Size = new System.Drawing.Size(221, 595);
            this.uI_CameraControl_front.TabIndex = 0;
            // 
            // UI_CameraSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uI_CameraControl_side);
            this.Controls.Add(this.uI_CameraControl_front);
            this.Name = "UI_CameraSetting";
            this.Size = new System.Drawing.Size(448, 595);
            this.ResumeLayout(false);

        }

        #endregion

        private UI_CameraControl uI_CameraControl_front;
        private UI_CameraControl uI_CameraControl_side;
    }
}
