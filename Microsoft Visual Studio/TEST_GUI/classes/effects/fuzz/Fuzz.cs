using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;


namespace AEF
{
    public class Fuzz : Effect
    {

        public Fuzz()
        {
            effect_name = "Fuzz";
            this.parameters = new FuzzParams();
            parameters.enable = true;
            Form_Fuzz form =  new Form_Fuzz();
            controler= form;
            form.fuzz = this;
        }
        public override void process_int(Channel input1, Channel left_op1, Channel right_op1)
        {
           // if (parameters.enable) { throw new Exception("its not enabled"); }
            FuzzParams fp = (FuzzParams) parameters;
            for (int i = 0; i < input1.BufferSize; i++)
            {
                if ((input1[i]*100) > fp.fuzz_level )
                {
                    input1[i] = fp.fuzz_level;

                }
                if ((input1[i] * 100) < -fp.fuzz_level)
                {
                    input1[i] = -fp.fuzz_level;

                }
                
                input1[i] *= (((float)fp.level )/ 100.0f);

            }
        }
    }
}
