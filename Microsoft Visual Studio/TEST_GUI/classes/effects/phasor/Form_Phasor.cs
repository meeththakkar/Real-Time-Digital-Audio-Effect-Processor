using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AEF
{
    public partial class Form_Phasor : Form
    {
        public Form_Phasor()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            label7.Text = trackBar1.Value.ToString();
            ((PhasorParams) phasor.parameters).update_phasor_speed(trackBar1.Value);

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            label8.Text = trackBar2.Value.ToString();
            ((PhasorParams)phasor.parameters).update_phasor_freq_low(trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
           // this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            label9.Text = trackBar3.Value.ToString();
            ((PhasorParams)phasor.parameters).update_phasor_freq_high(trackBar3.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ((PhasorParams)phasor.parameters).enable = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ((PhasorParams)phasor.parameters).toggle_bandpass(checkBox2.Checked);
        }

        private void Form_Phasor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
