namespace AEF
{
    partial class Form_Autowah
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
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            //base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackbar_time = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.l_time = new System.Windows.Forms.Label();
            this.l_low_pass = new System.Windows.Forms.Label();
            this.l_high_pass = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // trackbar_time
            // 
            this.trackbar_time.LargeChange = 1;
            this.trackbar_time.Location = new System.Drawing.Point(67, 33);
            this.trackbar_time.Maximum = 20000;
            this.trackbar_time.Minimum = 100;
            this.trackbar_time.Name = "trackbar_time";
            this.trackbar_time.Size = new System.Drawing.Size(260, 45);
            this.trackbar_time.TabIndex = 0;
            this.trackbar_time.Value = 1000;
            this.trackbar_time.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(67, 65);
            this.trackBar2.Maximum = 300;
            this.trackBar2.Minimum = 150;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(260, 45);
            this.trackBar2.TabIndex = 2;
            this.trackBar2.Value = 150;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(67, 106);
            this.trackBar3.Maximum = 3500;
            this.trackBar3.Minimum = 500;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(260, 45);
            this.trackBar3.TabIndex = 3;
            this.trackBar3.Value = 500;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(79, 147);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Mix";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(144, 147);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(65, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Enabled";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Low Pass";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "High Pass";
            // 
            // l_time
            // 
            this.l_time.AutoSize = true;
            this.l_time.Location = new System.Drawing.Point(336, 40);
            this.l_time.Name = "l_time";
            this.l_time.Size = new System.Drawing.Size(35, 13);
            this.l_time.TabIndex = 9;
            this.l_time.Text = "label4";
            // 
            // l_low_pass
            // 
            this.l_low_pass.AutoSize = true;
            this.l_low_pass.Location = new System.Drawing.Point(333, 65);
            this.l_low_pass.Name = "l_low_pass";
            this.l_low_pass.Size = new System.Drawing.Size(35, 13);
            this.l_low_pass.TabIndex = 10;
            this.l_low_pass.Text = "label5";
            // 
            // l_high_pass
            // 
            this.l_high_pass.AutoSize = true;
            this.l_high_pass.Location = new System.Drawing.Point(342, 106);
            this.l_high_pass.Name = "l_high_pass";
            this.l_high_pass.Size = new System.Drawing.Size(35, 13);
            this.l_high_pass.TabIndex = 11;
            this.l_high_pass.Text = "label6";
            // 
            // Form_Autowah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 174);
            this.Controls.Add(this.l_high_pass);
            this.Controls.Add(this.l_low_pass);
            this.Controls.Add(this.l_time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackbar_time);
            this.MaximizeBox = false;
            this.Name = "Form_Autowah";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Autowah";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_Autowah_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Autowah_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Autowah effect; 
        private System.Windows.Forms.TrackBar trackbar_time;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label l_time;
        private System.Windows.Forms.Label l_low_pass;
        private System.Windows.Forms.Label l_high_pass;
    }
}