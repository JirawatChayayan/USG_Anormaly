namespace USG_Anormaly
{
    partial class UI_ImageDisplay
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
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Front = new System.Windows.Forms.Button();
            this.bt_Side1 = new System.Windows.Forms.Button();
            this.bt_Side2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Image Model";
            // 
            // bt_Front
            // 
            this.bt_Front.Location = new System.Drawing.Point(0, 16);
            this.bt_Front.Name = "bt_Front";
            this.bt_Front.Size = new System.Drawing.Size(81, 43);
            this.bt_Front.TabIndex = 5;
            this.bt_Front.Text = "Front";
            this.bt_Front.UseVisualStyleBackColor = true;
            this.bt_Front.Click += new System.EventHandler(this.bt_displayIme);
            // 
            // bt_Side1
            // 
            this.bt_Side1.Location = new System.Drawing.Point(90, 16);
            this.bt_Side1.Name = "bt_Side1";
            this.bt_Side1.Size = new System.Drawing.Size(81, 43);
            this.bt_Side1.TabIndex = 5;
            this.bt_Side1.Text = "Side1";
            this.bt_Side1.UseVisualStyleBackColor = true;
            this.bt_Side1.Click += new System.EventHandler(this.bt_displayIme);
            // 
            // bt_Side2
            // 
            this.bt_Side2.Location = new System.Drawing.Point(179, 16);
            this.bt_Side2.Name = "bt_Side2";
            this.bt_Side2.Size = new System.Drawing.Size(81, 43);
            this.bt_Side2.TabIndex = 5;
            this.bt_Side2.Text = "Side2";
            this.bt_Side2.UseVisualStyleBackColor = true;
            this.bt_Side2.Click += new System.EventHandler(this.bt_displayIme);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.ErrorImage = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pictureBox1.Image = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pictureBox1.InitialImage = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pictureBox1.Location = new System.Drawing.Point(0, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // UI_ImageDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bt_Side2);
            this.Controls.Add(this.bt_Side1);
            this.Controls.Add(this.bt_Front);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UI_ImageDisplay";
            this.Size = new System.Drawing.Size(260, 269);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bt_Front;
        private System.Windows.Forms.Button bt_Side1;
        private System.Windows.Forms.Button bt_Side2;
    }
}
