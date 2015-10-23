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
    public partial class Form_Autowah : Form
    {
        AutowahParams effect_params ; 
        public Form_Autowah()
        {
            InitializeComponent();
           
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            l_time.Text = trackbar_time.Value.ToString();
            effect_params.time_changed(trackbar_time.Value);
        }

        private void Form_Autowah_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void Form_Autowah_Load(object sender, EventArgs e)
        {
            effect_params = (AutowahParams)effect.parameters;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            effect_params.enable_changed(checkBox2.Checked);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            l_low_pass.Text = trackBar2.Value.ToString();
            effect_params.freq_low_changed(trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            l_high_pass.Text = trackBar3.Value.ToString();
            effect_params.freq_high_changed(trackBar3.Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

      
    }
}
