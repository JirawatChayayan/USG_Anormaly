namespace USG_Anormaly
{
    partial class UI_WaitTrainingProcess
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
            this.transparentPanel1 = new System.Windows.Forms.Panel();
            this.transparentPanel2 = new System.Windows.Forms.Panel();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.Location = new System.Drawing.Point(130, 44);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Size = new System.Drawing.Size(115, 115);
            this.transparentPanel1.TabIndex = 10;
            this.transparentPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.transparentPanel1_Paint);
            // 
            // transparentPanel2
            // 
            this.transparentPanel2.Location = new System.Drawing.Point(187, 101);
            this.transparentPanel2.Name = "transparentPanel2";
            this.transparentPanel2.Size = new System.Drawing.Size(115, 115);
            this.transparentPanel2.TabIndex = 11;
            this.transparentPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.transparentPanel2_Paint);
            // 
            // txt_status
            // 
            this.txt_status.BackColor = System.Drawing.SystemColors.Control;
            this.txt_status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_status.ForeColor = System.Drawing.Color.Gray;
            this.txt_status.Location = new System.Drawing.Point(-1, 244);
            this.txt_status.Multiline = true;
            this.txt_status.Name = "txt_status";
            this.txt_status.ReadOnly = true;
            this.txt_status.Size = new System.Drawing.Size(432, 34);
            this.txt_status.TabIndex = 12;
            this.txt_status.Text = "Something Else .....";
            this.txt_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_WaitTrainingProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_status);
            this.Controls.Add(this.transparentPanel1);
            this.Controls.Add(this.transparentPanel2);
            this.Name = "UI_WaitTrainingProcess";
            this.Size = new System.Drawing.Size(430, 303);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel transparentPanel1;
        private System.Windows.Forms.Panel transparentPanel2;
        private System.Windows.Forms.TextBox txt_status;
    }
}
