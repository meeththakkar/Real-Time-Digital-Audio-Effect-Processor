using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BlueWave.Interop.Asio;
using System.Threading;
 

namespace AEF
{
    public partial class Form_old : Form
    {
        AsioDriver driver = AsioDriver.SelectDriver(AsioDriver.InstalledDrivers[0]);

        public Form_old()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         //   Thread.CurrentThread.Priority = ThreadPriority.Highest;
            
            // popup the driver's control panel for configuration
            driver.ShowControlPanel();
            // get our driver wrapper to create its buffers
            
            driver.CreateBuffers(false);
            

            // create a an array of standard sized buffers with a size of 100 
            
            Program._delayBuffer = new float[driver.BufferSizex.PreferredSize, Program.MaxBuffers];


            listBox1.Items.Add("buffer size " + Program._delayBuffer.Length + driver.BufferSizex.MinSize);
            

            
            // this is our buffer fill event we need to respond to
            driver.BufferUpdate += new EventHandler(AsioDriver_BufferUpdate);
           

            // and off we go
            driver.Start();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            driver.Stop();
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private static void AsioDriver_BufferUpdate(object sender, EventArgs e)
        {
            // the driver is the sender
            AsioDriver driver = sender as AsioDriver;

            
            // increment the delay buffer counter
            Program._counter++;

            // and wrap if nede be
            if (Program._counter >= 100) Program._counter = 0;

            // get the input channel and the stereo output channels
            Channel input = driver.InputChannels[0];
            Channel leftOutput = driver.OutputChannels[0];
            Channel rightOutput = driver.OutputChannels[1];

            for (int indx = 0; indx < leftOutput.BufferSize; indx++)
            {
                //copy input in given buffer  
          //      Program._delayBuffer[index, Program._counter] = input[index];
                if (indx < (leftOutput.BufferSize / 2))
                {
                    leftOutput[indx] = input[indx];
                    rightOutput[indx] = input[leftOutput.BufferSize-indx];
                }
                else
                {
                    rightOutput[indx] = input[leftOutput.BufferSize - indx];
                    leftOutput[indx] = input[indx];
                }
            }


            //for (int index = 0; index < leftOutput.BufferSize; index++)
            //{
            //    // copy the input buffer to our delay array
            //    Program._delayBuffer[index, Program._counter] = input[index];

            //    // and copy from the delay array to the output buffers (wrapping as needed)
            //    leftOutput[index] = Program._delayBuffer[index, (Program._counter - Program._leftDelay) >= 0 ? Program._counter - Program._leftDelay : Program._counter - Program._leftDelay + Program.MAX_BUFFERS];
            //    rightOutput[index] = Program._delayBuffer[index, (Program._counter - Program._rightDelay) >= 0 ? Program._counter - Program._rightDelay : Program._counter - Program._rightDelay + Program.MAX_BUFFERS];
            //}
       
        

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
