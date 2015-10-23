using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AEF
{
    public partial class Form_Delay : Form
    {
        public Form_Delay()
        {
            InitializeComponent();
        }

        private void delay_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
          //  this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            label9.Text = trackBar3.Value.ToString();
            ((DelayParams)delay.parameters).update_delay_repeat(trackBar3.Value);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ((DelayParams)delay.parameters).update_delay_decay(trackBar1.Value);
            label7.Text = trackBar1.Value.ToString();

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
           // this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            label8.Text = trackBar2.Value.ToString();
            ((DelayParams)delay.parameters).update_delay_time(trackBar2.Value);
        }

       

        private void Form_Delay_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide(); 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ((DelayParams)delay.parameters).enable_changed(checkBox1.Checked);
        }
    }
}
