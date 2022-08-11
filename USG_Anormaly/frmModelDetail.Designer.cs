namespace USG_Anormaly
{
    partial class frmModelDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModelDetail));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_trainingDetail = new System.Windows.Forms.TextBox();
            this.bt_front = new System.Windows.Forms.Button();
            this.bt_side1 = new System.Windows.Forms.Button();
            this.bt_side2 = new System.Windows.Forms.Button();
            this.pb_sample_side1 = new System.Windows.Forms.PictureBox();
            this.pb_sample_side2 = new System.Windows.Forms.PictureBox();
            this.pb_sample_front = new System.Windows.Forms.PictureBox();
            this.uI_trainingResult_front = new USG_Anormaly.UI_trainingResult();
            this.uI_trainingResult_side1 = new USG_Anormaly.UI_trainingResult();
            this.uI_trainingResult_side2 = new USG_Anormaly.UI_trainingResult();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sample_side1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sample_side2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sample_front)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(321, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "sample_img_front";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(842, 546);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "sample_img_side1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1363, 546);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "sample_img_side2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "training_detail";
            // 
            // txt_trainingDetail
            // 
            this.txt_trainingDetail.BackColor = System.Drawing.Color.PowderBlue;
            this.txt_trainingDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_trainingDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_trainingDetail.Location = new System.Drawing.Point(5, 70);
            this.txt_trainingDetail.Multiline = true;
            this.txt_trainingDetail.Name = "txt_trainingDetail";
            this.txt_trainingDetail.ReadOnly = true;
            this.txt_trainingDetail.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_trainingDetail.Size = new System.Drawing.Size(313, 874);
            this.txt_trainingDetail.TabIndex = 10;
            // 
            // bt_front
            // 
            this.bt_front.BackColor = System.Drawing.Color.PowderBlue;
            this.bt_front.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_front.ForeColor = System.Drawing.Color.Black;
            this.bt_front.Location = new System.Drawing.Point(5, 9);
            this.bt_front.Name = "bt_front";
            this.bt_front.Size = new System.Drawing.Size(99, 55);
            this.bt_front.TabIndex = 11;
            this.bt_front.Text = "Front";
            this.bt_front.UseVisualStyleBackColor = false;
            this.bt_front.Click += new System.EventHandler(this.bt_click);
            // 
            // bt_side1
            // 
            this.bt_side1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_side1.Location = new System.Drawing.Point(113, 9);
            this.bt_side1.Name = "bt_side1";
            this.bt_side1.Size = new System.Drawing.Size(99, 55);
            this.bt_side1.TabIndex = 11;
            this.bt_side1.Text = "Side1";
            this.bt_side1.UseVisualStyleBackColor = true;
            this.bt_side1.Click += new System.EventHandler(this.bt_click);
            // 
            // bt_side2
            // 
            this.bt_side2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_side2.Location = new System.Drawing.Point(219, 9);
            this.bt_side2.Name = "bt_side2";
            this.bt_side2.Size = new System.Drawing.Size(99, 55);
            this.bt_side2.TabIndex = 11;
            this.bt_side2.Text = "Side2";
            this.bt_side2.UseVisualStyleBackColor = true;
            this.bt_side2.Click += new System.EventHandler(this.bt_click);
            // 
            // pb_sample_side1
            // 
            this.pb_sample_side1.Image = ((System.Drawing.Image)(resources.GetObject("pb_sample_side1.Image")));
            this.pb_sample_side1.Location = new System.Drawing.Point(842, 546);
            this.pb_sample_side1.Name = "pb_sample_side1";
            this.pb_sample_side1.Size = new System.Drawing.Size(515, 398);
            this.pb_sample_side1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_sample_side1.TabIndex = 5;
            this.pb_sample_side1.TabStop = false;
            // 
            // pb_sample_side2
            // 
            this.pb_sample_side2.Image = ((System.Drawing.Image)(resources.GetObject("pb_sample_side2.Image")));
            this.pb_sample_side2.Location = new System.Drawing.Point(1363, 546);
            this.pb_sample_side2.Name = "pb_sample_side2";
            this.pb_sample_side2.Size = new System.Drawing.Size(529, 398);
            this.pb_sample_side2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_sample_side2.TabIndex = 5;
            this.pb_sample_side2.TabStop = false;
            // 
            // pb_sample_front
            // 
            this.pb_sample_front.Image = ((System.Drawing.Image)(resources.GetObject("pb_sample_front.Image")));
            this.pb_sample_front.Location = new System.Drawing.Point(321, 546);
            this.pb_sample_front.Name = "pb_sample_front";
            this.pb_sample_front.Size = new System.Drawing.Size(515, 398);
            this.pb_sample_front.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_sample_front.TabIndex = 5;
            this.pb_sample_front.TabStop = false;
            // 
            // uI_trainingResult_front
            // 
            this.uI_trainingResult_front.Location = new System.Drawing.Point(323, 2);
            this.uI_trainingResult_front.Name = "uI_trainingResult_front";
            this.uI_trainingResult_front.Size = new System.Drawing.Size(1575, 542);
            this.uI_trainingResult_front.TabIndex = 12;
            // 
            // uI_trainingResult_side1
            // 
            this.uI_trainingResult_side1.Location = new System.Drawing.Point(323, 2);
            this.uI_trainingResult_side1.Name = "uI_trainingResult_side1";
            this.uI_trainingResult_side1.Size = new System.Drawing.Size(1575, 542);
            this.uI_trainingResult_side1.TabIndex = 12;
            // 
            // uI_trainingResult_side2
            // 
            this.uI_trainingResult_side2.Location = new System.Drawing.Point(323, 2);
            this.uI_trainingResult_side2.Name = "uI_trainingResult_side2";
            this.uI_trainingResult_side2.Size = new System.Drawing.Size(1575, 542);
            this.uI_trainingResult_side2.TabIndex = 12;
            // 
            // frmModelDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1899, 947);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pb_sample_side1);
            this.Controls.Add(this.pb_sample_side2);
            this.Controls.Add(this.pb_sample_front);
            this.Controls.Add(this.bt_side2);
            this.Controls.Add(this.bt_side1);
            this.Controls.Add(this.bt_front);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_trainingDetail);
            this.Controls.Add(this.uI_trainingResult_front);
            this.Controls.Add(this.uI_trainingResult_side2);
            this.Controls.Add(this.uI_trainingResult_side1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModelDetail";
            this.Text = "frmModelDetail";
            this.Load += new System.EventHandler(this.frmModelDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_sample_side1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sample_side2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sample_front)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pb_sample_front;
        private System.Windows.Forms.PictureBox pb_sample_side1;
        private System.Windows.Forms.PictureBox pb_sample_side2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_trainingDetail;
        private System.Windows.Forms.Button bt_front;
        private System.Windows.Forms.Button bt_side1;
        private System.Windows.Forms.Button bt_side2;
        private UI_trainingResult uI_trainingResult_front;
        private UI_trainingResult uI_trainingResult_side1;
        private UI_trainingResult uI_trainingResult_side2;
    }
}