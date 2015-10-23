using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace AEF
{
    class ByPass : Effect
    {
        public override void process_int(Channel input1, Channel left_op1, Channel right_op1)
        {

            float max = 0;
            for (int i = 0; i < input1.BufferSize; i++)
            {

                if (max < input1[i]) max = input1[i];

                left_op1[i] = input1[i];
                right_op1[i] = input1[i];
            }


            // DEBUG purpose
        //    sys.mainGUI.listBox2.Items.Add(max);

            //if (sys.mainGUI.listBox2.InvokeRequired)
            //{
            //    sys.mainGUI.listBox2.Invoke(new MethodInvoker(delegate { sys.mainGUI.listBox2.Items.Add(max); }));
            //}


        }


    }
}
