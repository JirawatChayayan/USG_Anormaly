namespace USG_Anormaly
{
    partial class Sub_UI_LightingControl
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
            this.group_main = new System.Windows.Forms.GroupBox();
            this.bt_activate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.tb_val = new System.Windows.Forms.TrackBar();
            this.group_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_val)).BeginInit();
            this.SuspendLayout();
            // 
            // group_main
            // 
            this.group_main.BackColor = System.Drawing.SystemColors.Control;
            this.group_main.Controls.Add(this.bt_activate);
            this.group_main.Controls.Add(this.label1);
            this.group_main.Controls.Add(this.txt_value);
            this.group_main.Controls.Add(this.tb_val);
            this.group_main.Location = new System.Drawing.Point(1, 0);
            this.group_main.Name = "group_main";
            this.group_main.Size = new System.Drawing.Size(139, 291);
            this.group_main.TabIndex = 17;
            this.group_main.TabStop = false;
            this.group_main.Text = "Front Lighting";
            // 
            // bt_activate
            // 
            this.bt_activate.Location = new System.Drawing.Point(45, 250);
            this.bt_activate.Name = "bt_activate";
            this.bt_activate.Size = new System.Drawing.Size(75, 23);
            this.bt_activate.TabIndex = 16;
            this.bt_activate.Text = "Activate ";
            this.bt_activate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Value";
            // 
            // txt_value
            // 
            this.txt_value.BackColor = System.Drawing.SystemColors.Control;
            this.txt_value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_value.Location = new System.Drawing.Point(35, 128);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(92, 42);
            this.txt_value.TabIndex = 15;
            this.txt_value.Text = "128";
            this.txt_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_val
            // 
            this.tb_val.LargeChange = 1;
            this.tb_val.Location = new System.Drawing.Point(13, 18);
            this.tb_val.Maximum = 255;
            this.tb_val.Name = "tb_val";
            this.tb_val.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tb_val.Size = new System.Drawing.Size(45, 255);
            this.tb_val.TabIndex = 10;
            this.tb_val.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_val.Value = 128;
            this.tb_val.ValueChanged += new System.EventHandler(this.tb_val_ValueChanged);
            // 
            // Sub_UI_LightingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.group_main);
            this.Name = "Sub_UI_LightingControl";
            this.Size = new System.Drawing.Size(142, 291);
            this.group_main.ResumeLayout(false);
            this.group_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_val)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_main;
        private System.Windows.Forms.Button bt_activate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.TrackBar tb_val;
    }
}
