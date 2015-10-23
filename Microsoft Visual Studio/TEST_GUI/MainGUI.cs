using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AEF
{ 

   
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();

            sys.effect_stack = new Effect_Stack();
            sys.mainGUI = this;
            sys.sinLookUp = new int[360];
            sys.isSinLookUp = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DSP.start_DSP();
         //   MessageBox.Show("sample rate = " + sys.driver.SampleRate);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            sys.driver.ShowControlPanel();
        }

       


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            button1.Text = "started ";

            
            MessageBox.Show("cmm");
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        //    button1.Text = " completed";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sys.driver.Stop();

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

    

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (sys.form_Autowah == null)
                sys.form_Autowah = new Form_Autowah();
            sys.form_Autowah.Owner = this;
            sys.form_Autowah.Show();

        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
            sample_rate.SetSelected(0, true);
        }

        private void button14_Click(object sender, EventArgs e)
        {

            bool flag = true;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if( listBox1.Items[i].ToString().Equals(listBox2.SelectedItem.ToString()))
                {
                    flag = false;
                }
            }

            if (flag)
            {
                Effect ef = EffectFactory.getEffect(listBox2.SelectedItem.ToString());

                if (ef == null) MessageBox.Show("null");

                sys.no_of_effects++;

                listBox1.Items.Add(ef);
            }
            else
            {
                MessageBox.Show("can not add items twice ");
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if ( (listBox1.SelectedItem != null &&  !listBox1.SelectedItem.ToString().Equals("")))
            {
                Effect ef = (Effect)listBox1.SelectedItem;
                ef.controler.Show();
                ef.controler.BringToFront();
            }
        }

        private void MainGUI_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
            Environment.Exit(0);
        }

        private void MainGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
            
                Object selected = listBox1.SelectedItem;
                listBox1.Items.Remove(listBox1.SelectedItem);
                sys.no_of_effects--;
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            new Form1().Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != 0)
            {
                int index = listBox1.SelectedIndex;

                Effect effect = (Effect)listBox1.Items[index];
                Effect upper = (Effect)listBox1.Items[index - 1];

                //Effect temp = upper;
                //upper = effect;
                //effect = temp;

                listBox1.Items.RemoveAt(index);
                listBox1.Items.RemoveAt(index - 1);

                listBox1.Items.Insert(index - 1, effect);
                listBox1.Items.Insert(index, upper);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {


            if (listBox1.SelectedIndex != listBox1.Items.Count)
            {
                int index = listBox1.SelectedIndex;

                Effect effect = (Effect)listBox1.Items[index];
                Effect lower = (Effect)listBox1.Items[index + 1];

                //Effect temp = upper;
                //upper = effect;
                //effect = temp;
                sys.driver.Stop();
                

                listBox1.Items.RemoveAt(index);
                listBox1.Items.RemoveAt(index + 1);

                listBox1.Items.Insert(index , lower);
                listBox1.Items.Insert(index +1, effect);


                sys.driver.Start();
            }

        }

        private void sample_rate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
