using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AEF
{
    public partial class Form_Chorus : Form
    {
        public Form_Chorus()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //depth
            cp.update_chorus_depth(trackBar_depth.Value);
            label11.Text = trackBar_depth.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //speed

            cp.update_chorus_speed(trackBar_speed.Value);
            label12.Text = trackBar_speed.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            //wet
            cp.update_chorus_wet(trackBar3.Value);
            label13.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            //dry
            cp.update_chorus_dry(trackBar4.Value);
            label14.Text = trackBar4.Value.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            //regen
            cp.update_chorus_regen(trackBar5.Value);
            label15.Text = trackBar5.Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void flanger_CheckedChanged(object sender, EventArgs e)
        {

            if (flanger.Enabled)
                cp.update_chorus_mode(1);
            else cp.update_chorus_mode(0);
        }

        private void Form_Chorus_Load(object sender, EventArgs e)
        {

        }

        private void Form_Chorus_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void enable_CheckedChanged(object sender, EventArgs e)
        {
            this.cp.enable = enable.Checked;
        }
    }
}
