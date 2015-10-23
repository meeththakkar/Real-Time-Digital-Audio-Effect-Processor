using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AEF
{
    public partial class Form_Distortion : Form
    {

        DistortionParams effect_params;

        public Form_Distortion()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            effect_params.update_distort_drive(trackBar1.Value);
            label5.Text= trackBar1.Value.ToString();
            //MessageBox.Show(trackBar1.Value.ToString());
            // label5.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            effect_params.update_distort_level(trackBar2.Value);
            label6.Text = trackBar2.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            effect_params.update_distort_sat(trackBar4.Value);
            label7.Text = trackBar4.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            effect_params.update_distort_lowpass(trackBar3.Value);
            label8.Text = trackBar3.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form_Distortion_Load(object sender, EventArgs e)
        {
            effect_params = (DistortionParams)effect.parameters;
        }

        private void Form_Distortion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            effect.parameters.enable = checkBox1.Checked;
        }
    }
}
