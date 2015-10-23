using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AEF
{
    public partial class Form_Reverb : Form
    {
        public Form_Reverb()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            label9.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            label10.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            //this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            label11.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            //this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            label12.Text = trackBar4.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            
        }
    }
}
