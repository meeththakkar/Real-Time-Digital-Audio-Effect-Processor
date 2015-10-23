using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;
using System.Windows.Forms;


namespace AEF
{
    class DSP
    {

        public static void start_DSP()
        {

        //    System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;

            // popup the driver's control panel for configuration
            sys.driver.ShowControlPanel();
            // get our driver wrapper to create its buffers

          //  MessageBox.Show( sys.mainGUI.sample_rate.SelectedItem.ToString());
          
            int samplrate = Int32.Parse( sys.mainGUI.sample_rate.SelectedItem.ToString());
            sys.driver.SetSampleRate((double) samplrate);
           
            sys.driver.CreateBuffers(false);
            // create a an array of standard sized buffers with a size of 100 

            Program._delayBuffer = new float[sys.driver.BufferSizex.PreferredSize, sys.MAX_BUFFERS];

            // this is our buffer fill event we need to respond to
            sys.driver.BufferUpdate += new EventHandler(DSP_process);

            // and off we go
            sys.driver.Start();

        }

        public static void DSP_process(object sender, EventArgs e)
        {

        //    System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
            AsioDriver driver = (AsioDriver) sender;

            Channel input = driver.InputChannels[0];
            Channel leftOutput = driver.OutputChannels[0];
            Channel rightOutput = driver.OutputChannels[1];


            // temporary Effect stack
          //  Effect[] tem_Effects1 = new Effect[sys.MaxEffectStackSize];
           
            //sys.mainGUI.listBox1.Items.CopyTo(tem_Effects1,0);

            for (int i = 0; i < sys.no_of_effects; i++)
            {
                
                   ((Effect)sys.mainGUI.listBox1.Items[i]).process(input, leftOutput, rightOutput);

            }
            for (int i = 0; i < input.BufferSize; i++)
            {
                leftOutput[i] = input[i];
                rightOutput[i] = input[i];
            }


            
        }
    }
}
