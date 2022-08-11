namespace USG_Anormaly
{
    partial class UI_PretrainImage
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
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_capture = new System.Windows.Forms.Button();
            this.bt_upload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.listBox_dir = new System.Windows.Forms.ListBox();
            this.bt_deleteAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_delete
            // 
            this.bt_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_delete.Location = new System.Drawing.Point(295, 90);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(117, 35);
            this.bt_delete.TabIndex = 3;
            this.bt_delete.Text = "Delete";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_capture
            // 
            this.bt_capture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_capture.Location = new System.Drawing.Point(295, 5);
            this.bt_capture.Name = "bt_capture";
            this.bt_capture.Size = new System.Drawing.Size(117, 35);
            this.bt_capture.TabIndex = 4;
            this.bt_capture.Text = "Capture";
            this.bt_capture.UseVisualStyleBackColor = true;
            this.bt_capture.Click += new System.EventHandler(this.bt_capture_Click);
            // 
            // bt_upload
            // 
            this.bt_upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_upload.Location = new System.Drawing.Point(295, 46);
            this.bt_upload.Name = "bt_upload";
            this.bt_upload.Size = new System.Drawing.Size(117, 38);
            this.bt_upload.TabIndex = 5;
            this.bt_upload.Text = "Upload";
            this.bt_upload.UseVisualStyleBackColor = true;
            this.bt_upload.Click += new System.EventHandler(this.bt_upload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status";
            // 
            // txt_status
            // 
            this.txt_status.BackColor = System.Drawing.SystemColors.Control;
            this.txt_status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_status.Enabled = false;
            this.txt_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_status.Location = new System.Drawing.Point(295, 191);
            this.txt_status.Name = "txt_status";
            this.txt_status.ReadOnly = true;
            this.txt_status.Size = new System.Drawing.Size(117, 13);
            this.txt_status.TabIndex = 8;
            this.txt_status.Text = "Waitting Image";
            this.txt_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBox_dir
            // 
            this.listBox_dir.FormattingEnabled = true;
            this.listBox_dir.Location = new System.Drawing.Point(6, 5);
            this.listBox_dir.Name = "listBox_dir";
            this.listBox_dir.Size = new System.Drawing.Size(284, 212);
            this.listBox_dir.TabIndex = 6;
            this.listBox_dir.SelectedIndexChanged += new System.EventHandler(this.listBox_dir_SelectedIndexChanged);
            // 
            // bt_deleteAll
            // 
            this.bt_deleteAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_deleteAll.Location = new System.Drawing.Point(295, 131);
            this.bt_deleteAll.Name = "bt_deleteAll";
            this.bt_deleteAll.Size = new System.Drawing.Size(117, 35);
            this.bt_deleteAll.TabIndex = 3;
            this.bt_deleteAll.Text = "Delete All";
            this.bt_deleteAll.UseVisualStyleBackColor = true;
            this.bt_deleteAll.Click += new System.EventHandler(this.bt_reset_Click);
            // 
            // UI_PretrainImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_dir);
            this.Controls.Add(this.bt_deleteAll);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.bt_capture);
            this.Controls.Add(this.bt_upload);
            this.Name = "UI_PretrainImage";
            this.Size = new System.Drawing.Size(418, 221);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_capture;
        private System.Windows.Forms.Button bt_upload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_status;
        private System.Windows.Forms.ListBox listBox_dir;
        private System.Windows.Forms.Button bt_deleteAll;
    }
}
