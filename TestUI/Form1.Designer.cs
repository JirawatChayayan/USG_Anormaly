namespace TestUI
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
            this.uI_Anormaly_System3 = new USG_Anormaly.UI_Anormaly_System();
            this.SuspendLayout();
            // 
            // uI_Anormaly_System3
            // 
            this.uI_Anormaly_System3.Location = new System.Drawing.Point(12, 3);
            this.uI_Anormaly_System3.Name = "uI_Anormaly_System3";
            this.uI_Anormaly_System3.Size = new System.Drawing.Size(534, 600);
            this.uI_Anormaly_System3.TabIndex = 1;
            this.uI_Anormaly_System3.Load += new System.EventHandler(this.uI_Anormaly_System2_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 607);
            this.Controls.Add(this.uI_Anormaly_System3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private USG_Anormaly.UI_Anormaly_System uI_Anormaly_System3;
    }
}

