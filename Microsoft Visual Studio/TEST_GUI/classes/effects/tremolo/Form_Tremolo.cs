using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AEF
{
    public partial class Form_Tremolo : Form
    {
        public Form_Tremolo()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            label5.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            label6.Text = trackBar2.Value.ToString();
        }

        private void Form_Tremolo_Load(object sender, EventArgs e)
        {

        }
    }
}
