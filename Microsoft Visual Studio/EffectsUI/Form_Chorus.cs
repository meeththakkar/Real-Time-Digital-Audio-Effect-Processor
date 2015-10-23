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
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            label11.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            label12.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            label13.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            label14.Text = trackBar4.Value.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            label15.Text = trackBar5.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Delay d = new Form_Delay();
            d.Show();
            this.Hide();
        }
    }
}
