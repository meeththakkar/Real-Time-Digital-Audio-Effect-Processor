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

            int eff_no = (Int32.Parse(no));
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new MethodInvoker(delegate { listBox1.Items.Add((message)); }));
            }

           
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
    }
}
