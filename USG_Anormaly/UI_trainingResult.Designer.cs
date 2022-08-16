namespace USG_Anormaly
{
    partial class UI_trainingResult
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.pb_precision = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.pb_recall = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_AD_Classification_Threshold = new System.Windows.Forms.Label();
            this.label_AD_Segmentation_Threshold = new System.Windows.Forms.Label();
            this.pb_confusion_matrix = new System.Windows.Forms.PictureBox();
            this.pb_score_legend = new System.Windows.Forms.PictureBox();
            this.pb_score_histogram = new System.Windows.Forms.PictureBox();
            this.lb_camera = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_precision)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_recall)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_confusion_matrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_score_legend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_score_histogram)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(521, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "absolute_confusion_matrix";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(521, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "score_legend";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "score_histogram";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(921, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 539);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.pb_precision);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(646, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Precision";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "pie_charts_precision";
            // 
            // pb_precision
            // 
            this.pb_precision.BackColor = System.Drawing.Color.Black;
            this.pb_precision.ErrorImage = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pb_precision.Image = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pb_precision.Location = new System.Drawing.Point(0, 0);
            this.pb_precision.Name = "pb_precision";
            this.pb_precision.Size = new System.Drawing.Size(646, 513);
            this.pb_precision.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_precision.TabIndex = 2;
            this.pb_precision.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.pb_recall);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(646, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Recall";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "pie_charts_recall";
            // 
            // pb_recall
            // 
            this.pb_recall.BackColor = System.Drawing.Color.Black;
            this.pb_recall.ErrorImage = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pb_recall.Image = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pb_recall.Location = new System.Drawing.Point(0, 0);
            this.pb_recall.Name = "pb_recall";
            this.pb_recall.Size = new System.Drawing.Size(646, 513);
            this.pb_recall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_recall.TabIndex = 3;
            this.pb_recall.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(646, 513);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Threshold";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.35484F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_AD_Classification_Threshold, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_AD_Segmentation_Threshold, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 513);
            this.tableLayoutPanel1.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 50);
            this.label4.TabIndex = 34;
            this.label4.Text = "Anomaly Segmentation Threshold";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 50);
            this.label5.TabIndex = 34;
            this.label5.Text = "Anomaly Classification Thresholds";
            // 
            // label_AD_Classification_Threshold
            // 
            this.label_AD_Classification_Threshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AD_Classification_Threshold.AutoSize = true;
            this.label_AD_Classification_Threshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AD_Classification_Threshold.Location = new System.Drawing.Point(437, 372);
            this.label_AD_Classification_Threshold.Name = "label_AD_Classification_Threshold";
            this.label_AD_Classification_Threshold.Size = new System.Drawing.Size(19, 25);
            this.label_AD_Classification_Threshold.TabIndex = 34;
            this.label_AD_Classification_Threshold.Text = "-";
            // 
            // label_AD_Segmentation_Threshold
            // 
            this.label_AD_Segmentation_Threshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AD_Segmentation_Threshold.AutoSize = true;
            this.label_AD_Segmentation_Threshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AD_Segmentation_Threshold.Location = new System.Drawing.Point(437, 115);
            this.label_AD_Segmentation_Threshold.Name = "label_AD_Segmentation_Threshold";
            this.label_AD_Segmentation_Threshold.Size = new System.Drawing.Size(19, 25);
            this.label_AD_Segmentation_Threshold.TabIndex = 34;
            this.label_AD_Segmentation_Threshold.Text = "-";
            // 
            // pb_confusion_matrix
            // 
            this.pb_confusion_matrix.BackColor = System.Drawing.Color.Black;
            this.pb_confusion_matrix.ErrorImage = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pb_confusion_matrix.Image = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pb_confusion_matrix.Location = new System.Drawing.Point(521, 278);
            this.pb_confusion_matrix.Name = "pb_confusion_matrix";
            this.pb_confusion_matrix.Size = new System.Drawing.Size(394, 259);
            this.pb_confusion_matrix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_confusion_matrix.TabIndex = 10;
            this.pb_confusion_matrix.TabStop = false;
            // 
            // pb_score_legend
            // 
            this.pb_score_legend.ErrorImage = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pb_score_legend.Image = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pb_score_legend.Location = new System.Drawing.Point(521, 24);
            this.pb_score_legend.Name = "pb_score_legend";
            this.pb_score_legend.Size = new System.Drawing.Size(394, 510);
            this.pb_score_legend.TabIndex = 9;
            this.pb_score_legend.TabStop = false;
            // 
            // pb_score_histogram
            // 
            this.pb_score_histogram.ErrorImage = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pb_score_histogram.Image = global::USG_Anormaly.Properties.Resources.No_image_available_svg;
            this.pb_score_histogram.Location = new System.Drawing.Point(0, 24);
            this.pb_score_histogram.Name = "pb_score_histogram";
            this.pb_score_histogram.Size = new System.Drawing.Size(515, 513);
            this.pb_score_histogram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_score_histogram.TabIndex = 8;
            this.pb_score_histogram.TabStop = false;
            this.pb_score_histogram.Tag = "Please Select . . .";
            // 
            // lb_camera
            // 
            this.lb_camera.AutoSize = true;
            this.lb_camera.BackColor = System.Drawing.Color.PowderBlue;
            this.lb_camera.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_camera.Location = new System.Drawing.Point(0, -1);
            this.lb_camera.Name = "lb_camera";
            this.lb_camera.Size = new System.Drawing.Size(62, 25);
            this.lb_camera.TabIndex = 14;
            this.lb_camera.Text = "Front";
            // 
            // UI_trainingResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_camera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pb_confusion_matrix);
            this.Controls.Add(this.pb_score_legend);
            this.Controls.Add(this.pb_score_histogram);
            this.Name = "UI_trainingResult";
            this.Size = new System.Drawing.Size(1575, 542);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_precision)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_recall)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_confusion_matrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_score_legend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_score_histogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pb_precision;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pb_recall;
        private System.Windows.Forms.PictureBox pb_confusion_matrix;
        private System.Windows.Forms.PictureBox pb_score_legend;
        private System.Windows.Forms.PictureBox pb_score_histogram;
        private System.Windows.Forms.Label lb_camera;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_AD_Classification_Threshold;
        private System.Windows.Forms.Label label_AD_Segmentation_Threshold;
    }
}
