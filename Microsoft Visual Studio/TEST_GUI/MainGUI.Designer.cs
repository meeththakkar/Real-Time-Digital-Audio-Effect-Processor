namespace AEF
{
    partial class MainGUI
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

            sys.driver.Stop();

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
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sample_rate = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 85);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 173);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Location = new System.Drawing.Point(495, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(495, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "ASIO Config";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Effect stack";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(138, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 29);
            this.button3.TabIndex = 4;
            this.button3.Text = "Move Up";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(138, 118);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 39);
            this.button4.TabIndex = 5;
            this.button4.Text = "Move Down";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "Autowah",
            "Chorus",
            "Delay",
            "Distortion",
            "Fuzz",
            "Noisegate",
            "Phasor",
            "Sustain"});
            this.listBox2.Location = new System.Drawing.Point(204, 85);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(121, 173);
            this.listBox2.TabIndex = 6;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(495, 118);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 35);
            this.button5.TabIndex = 7;
            this.button5.Text = "Stop";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(138, 163);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(60, 27);
            this.button14.TabIndex = 17;
            this.button14.Text = "<< Add";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(138, 202);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(60, 29);
            this.button15.TabIndex = 18;
            this.button15.Text = "- Delete";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM33";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(495, 233);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 41);
            this.button6.TabIndex = 20;
            this.button6.Text = "Pedal Board";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Sample Rate";
            // 
            // sample_rate
            // 
            this.sample_rate.FormatString = "N0";
            this.sample_rate.FormattingEnabled = true;
            this.sample_rate.Items.AddRange(new object[] {
            "44100",
            "48000",
            "96000"});
            this.sample_rate.Location = new System.Drawing.Point(352, 95);
            this.sample_rate.Name = "sample_rate";
            this.sample_rate.Size = new System.Drawing.Size(120, 95);
            this.sample_rate.TabIndex = 24;
            this.sample_rate.SelectedIndexChanged += new System.EventHandler(this.sample_rate_SelectedIndexChanged);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 296);
            this.Controls.Add(this.sample_rate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "MainGUI";
            this.Text = "MainGUI";
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainGUI_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGUI_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListBox sample_rate;

    }
}