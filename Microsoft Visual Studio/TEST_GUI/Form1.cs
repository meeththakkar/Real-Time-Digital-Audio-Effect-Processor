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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            String message = serialPort1.ReadLine();

            String no= message.Substring(0, 1);

            bool high_low;
            if ( message.EndsWith("HIGH")) high_low = true;
            else high_low = false;

            int eff_no = (Int32.Parse(no));
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new MethodInvoker(delegate { listBox1.Items.Add((message)); }));
            }

            if (sys.no_of_effects >= (eff_no+1))
            ((Effect)sys.mainGUI.listBox1.Items[eff_no]).parameters.enable = high_low;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
            }
            catch (Exception)
            {

                MessageBox.Show("cant open port");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
    }
}
