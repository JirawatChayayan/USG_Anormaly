namespace USG_Anormaly
{
    partial class UI_result
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
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_class = new System.Windows.Forms.Label();
            this.lb_score = new System.Windows.Forms.Label();
            this.lb_imageSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_processTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "AnormalyClass:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(330, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "AnormalyScore:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(656, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Training Image Size:";
            // 
            // lb_class
            // 
            this.lb_class.AutoSize = true;
            this.lb_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_class.Location = new System.Drawing.Point(230, 13);
            this.lb_class.Name = "lb_class";
            this.lb_class.Size = new System.Drawing.Size(19, 25);
            this.lb_class.TabIndex = 0;
            this.lb_class.Text = "-";
            // 
            // lb_score
            // 
            this.lb_score.AutoSize = true;
            this.lb_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_score.Location = new System.Drawing.Point(521, 13);
            this.lb_score.Name = "lb_score";
            this.lb_score.Size = new System.Drawing.Size(19, 25);
            this.lb_score.TabIndex = 0;
            this.lb_score.Text = "-";
            // 
            // lb_imageSize
            // 
            this.lb_imageSize.AutoSize = true;
            this.lb_imageSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_imageSize.Location = new System.Drawing.Point(898, 13);
            this.lb_imageSize.Name = "lb_imageSize";
            this.lb_imageSize.Size = new System.Drawing.Size(19, 25);
            this.lb_imageSize.TabIndex = 0;
            this.lb_imageSize.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1056, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Process Time:";
            // 
            // lb_processTime
            // 
            this.lb_processTime.AutoSize = true;
            this.lb_processTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_processTime.Location = new System.Drawing.Point(1229, 13);
            this.lb_processTime.Name = "lb_processTime";
            this.lb_processTime.Size = new System.Drawing.Size(19, 25);
            this.lb_processTime.TabIndex = 0;
            this.lb_processTime.Text = "-";
            // 
            // UI_result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_score);
            this.Controls.Add(this.lb_class);
            this.Controls.Add(this.lb_processTime);
            this.Controls.Add(this.lb_imageSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "UI_result";
            this.Size = new System.Drawing.Size(1444, 52);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_class;
        private System.Windows.Forms.Label lb_score;
        private System.Windows.Forms.Label lb_imageSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_processTime;
    }
}
