using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AEF;
using BlueWave.Interop.Asio;
using System.Windows.Forms;

namespace AEF
{
    public abstract class Effect
    {

     
        public string effect_name;
        public abstract void process_int( Channel input1 , Channel left_op1 , Channel right_op1 ) ;
        public Form controler;
        public Parameters parameters;

        public override String ToString()
        {
            return effect_name;
        }

        public void process(Channel input1, Channel left, Channel right)
        {
            if (this.parameters.enable)
            {
                process_int(input1, left, right);
            }
        }
    }
}
