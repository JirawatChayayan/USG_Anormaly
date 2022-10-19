namespace CSTLightingController
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
            this.bt_Connect = new System.Windows.Forms.Button();
            this.ch1_val = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label_val = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_neg = new System.Windows.Forms.Button();
            this.bt_pos = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_val_get = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ch1_val)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Connect
            // 
            this.bt_Connect.Location = new System.Drawing.Point(12, 12);
            this.bt_Connect.Name = "bt_Connect";
            this.bt_Connect.Size = new System.Drawing.Size(207, 119);
            this.bt_Connect.TabIndex = 0;
            this.bt_Connect.Text = "Connect";
            this.bt_Connect.UseVisualStyleBackColor = true;
            this.bt_Connect.Click += new System.EventHandler(this.bt_Connect_Click);
            // 
            // ch1_val
            // 
            this.ch1_val.Location = new System.Drawing.Point(225, 35);
            this.ch1_val.Maximum = 255;
            this.ch1_val.Name = "ch1_val";
            this.ch1_val.Size = new System.Drawing.Size(569, 45);
            this.ch1_val.TabIndex = 1;
            this.ch1_val.ValueChanged += new System.EventHandler(this.ch1_val_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "CH1 Lighting value";
            // 
            // label_val
            // 
            this.label_val.AutoSize = true;
            this.label_val.Location = new System.Drawing.Point(764, 19);
            this.label_val.Name = "label_val";
            this.label_val.Size = new System.Drawing.Size(13, 13);
            this.label_val.TabIndex = 2;
            this.label_val.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_neg);
            this.groupBox1.Controls.Add(this.bt_pos);
            this.groupBox1.Location = new System.Drawing.Point(228, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TriggerMode";
            // 
            // bt_neg
            // 
            this.bt_neg.Location = new System.Drawing.Point(170, 19);
            this.bt_neg.Name = "bt_neg";
            this.bt_neg.Size = new System.Drawing.Size(132, 40);
            this.bt_neg.TabIndex = 0;
            this.bt_neg.Text = "- Neg";
            this.bt_neg.UseVisualStyleBackColor = true;
            this.bt_neg.Click += new System.EventHandler(this.bt_pos_Click);
            // 
            // bt_pos
            // 
            this.bt_pos.Location = new System.Drawing.Point(6, 19);
            this.bt_pos.Name = "bt_pos";
            this.bt_pos.Size = new System.Drawing.Size(146, 40);
            this.bt_pos.TabIndex = 0;
            this.bt_pos.Text = "+ Pos";
            this.bt_pos.UseVisualStyleBackColor = true;
            this.bt_pos.Click += new System.EventHandler(this.bt_pos_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_val_get);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(542, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 65);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lighting Value";
            // 
            // lb_val_get
            // 
            this.lb_val_get.AutoSize = true;
            this.lb_val_get.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_val_get.Location = new System.Drawing.Point(181, 22);
            this.lb_val_get.Name = "lb_val_get";
            this.lb_val_get.Size = new System.Drawing.Size(31, 33);
            this.lb_val_get.TabIndex = 1;
            this.lb_val_get.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Lighting Value";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 143);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_val);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ch1_val);
            this.Controls.Add(this.bt_Connect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ch1_val)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Connect;
        private System.Windows.Forms.TrackBar ch1_val;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_val;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_neg;
        private System.Windows.Forms.Button bt_pos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_val_get;
        private System.Windows.Forms.Button button1;
    }
}

