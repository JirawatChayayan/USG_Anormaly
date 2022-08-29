namespace USG_Anormaly
{
    partial class UI_TestingError
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
            this.text_msg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // text_msg
            // 
            this.text_msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.text_msg.ForeColor = System.Drawing.Color.IndianRed;
            this.text_msg.Location = new System.Drawing.Point(0, 6);
            this.text_msg.Name = "text_msg";
            this.text_msg.Size = new System.Drawing.Size(1444, 40);
            this.text_msg.TabIndex = 0;
            this.text_msg.Text = "Error !!!";
            this.text_msg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_TestingError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.text_msg);
            this.Name = "UI_TestingError";
            this.Size = new System.Drawing.Size(1444, 52);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_msg;
    }
}
