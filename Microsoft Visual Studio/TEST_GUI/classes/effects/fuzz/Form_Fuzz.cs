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
    public partial class Form_Fuzz : Form
    {
        public Form_Fuzz()
        {
            InitializeComponent();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            ((FuzzParams)fuzz.parameters).update_level(trackBar2.Value);
            label3.Text = trackBar2.Value.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fuzz.parameters.enable_changed(checkBox1.Checked);
        }

        private void Form_Fuzz_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ((FuzzParams)fuzz.parameters).update_fuzz_level(trackBar1.Value);
            label4.Text = trackBar1.Value.ToString();
        }

        private void Form_Fuzz_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
