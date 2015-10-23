using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AEF
{
    public partial class Form_Noisegate : Form
    {
        public Form_Noisegate()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ngp.update_noise_threshold(trackBar1.Value);
            label6.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            ngp.update_noise_hold(trackBar2.Value);
            label7.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            ngp.update_noise_release(trackBar3.Value);
            label8.Text = trackBar3.Value.ToString();

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            ngp.update_noise_attack(trackBar4.Value);
            label9.Text = trackBar4.Value.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            ngp.update_noise_hyst(trackBar5.Value);
            label10.Text = trackBar5.Value.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ngp.enable_changed(checkBox1.Checked);
        }

        private void Form_Noisegate_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

    }
}
