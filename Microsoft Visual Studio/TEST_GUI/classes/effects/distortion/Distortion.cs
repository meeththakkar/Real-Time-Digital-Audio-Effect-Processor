using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BlueWave.Interop.Asio;

namespace AEF
{
    public  class Distortion : Effect
    {

     

        public Distortion()
        {
            this.effect_name = "Distortion";
             DistortionParams dp = new DistortionParams();
             this.parameters = dp;
            Form_Distortion form = new Form_Distortion();
            form.effect = this;
            controler = form;
            dp.enable = true;


            dp.sat = 0.7f;
            dp.level = .6f;
            dp.drive = 10;
            dp.lowpass = 350;
            dp.noisegate = 1000;

            RCFilter.RC_setup(1, 1, dp.fd);
            RCFilter.RC_set_freq(dp.lowpass, dp.fd);

            RCFilter.RC_setup(1, 1, dp.noise);
            RCFilter.RC_set_freq(dp.noisegate, dp.noise);



        }


        public override void process_int(Channel input1, Channel left_op1, Channel right_op1)
        {

            if (this.parameters.enable)
            {

                Effect p = this;
                Channel db = input1;

                int count,
                      currchannel = 0;
                Channel s;
                DistortionParams dp;

                dp = (DistortionParams)this.parameters;
                /*
                 * sat clips derivative by limiting difference between samples. Use lastval 
                 * member to store last sample for seamlessness between chunks. 
                 */
                count = db.BufferSize;
                s = input1; ;

                RCFilter.RC_highpass(input1, input1.BufferSize, dp.fd);

                int i = 0;
                while (count > 0)
                {
                    /*
                     * apply drive  
                     */
                    input1[i] *= dp.drive;
                   //   input1[i] /= 16;

                    /*
                     * apply sat 
                     */



                      if ((s[i] - dp.lastval[currchannel]) > dp.sat)
                          s[i] = dp.lastval[currchannel] + dp.sat;
                      else if ((dp.lastval[currchannel] - s[i]) > dp.sat)
                          s[i] = dp.lastval[currchannel] - dp.sat;

                    dp.lastval[currchannel] = input1[i];


                    input1[i] *= dp.level;
                   //input1[i] /= 256;

                    // debug

                    count--;
                    i++;

                }

                 RCFilter.LC_filter(db, db.BufferSize, sys.LOWPASS, dp.lowpass, dp.noise);

            }
        }
    }
}
