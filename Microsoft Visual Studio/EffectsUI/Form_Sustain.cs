using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AEF
{
    public partial class Form_Sustain : Form
    {
        public Form_Sustain()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            label7.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            label8.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            label9.Text = trackBar3.Value.ToString();
        }
    }
}
