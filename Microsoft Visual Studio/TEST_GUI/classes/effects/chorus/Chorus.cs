using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
    public class Chorus : Effect
    {

        

        public Chorus()
        {
            effect_name = "Chorus";
            initSinLookUp();

            parameters = new ChorusParams();
            ChorusParams cp = (ChorusParams)parameters;



            Form_Chorus fc = new Form_Chorus();
            controler = fc;

            parameters = cp;

            fc.cp = (ChorusParams)parameters;

            //cp.memory = new backBuf(sys.sample_rate);

            this.parameters.enable = true;
            
              for (int i = 0; i < sys.MAX_CHANNELS; i++) {
                  cp.memory[i] = new backBuf(sys.sample_rate);
    }

    cp.ang = 0.0f;
    cp.depth = 50;
    cp.speed = 5;
    cp.mode = 0;
    cp.wet = 250;
    cp.dry = 200;
    cp.regen = 0;

        }
        public override void process_int(BlueWave.Interop.Asio.Channel input1, BlueWave.Interop.Asio.Channel left_op1, BlueWave.Interop.Asio.Channel right_op1)
        {

            if (parameters.enable)
            {
                // struct effect *p, struct data_block *db
                ChorusParams cp;
                int count;
                Channel s;
                int dly = 0;
                float AngInc,
                                Ang;
                float tmp,
                                tot,
                                rgn;
                int currchannel = 0;

                cp = (ChorusParams)this.parameters;

                s = input1;
                count = input1.BufferSize;

                //#define MaxDly ((int)cp->depth * 8)
                int MaxDly = (cp.depth * 8);
                AngInc = cp.speed / 1000.0f;
                Ang = cp.ang;

                /*
                 * process the samples 
                 */
                int ii = 0;
                while (0 < count)
                {
                    tmp = s[ii];
                    tmp *= cp.dry;
                    tmp /= 256;
                    switch (cp.mode)
                    {
                        case 0:		/* chorus */
                            dly = MaxDly * (1024 + sys.sinLookUp[(int)cp.ang]);
                            break;
                        case 1:		/* flange */
                            dly = 16 * MaxDly * (1024 + sys.sinLookUp[(int)Ang] / 16);
                            break;
                    };
                    dly /= 2048;
                    Ang += AngInc;
                    if (Ang >= 359.0f)
                        Ang = 0.0f;
                    if (dly < 0)
                        dly = 0;

                    tot = cp.memory[currchannel].backbuff_get(dly);
                    tot *= cp.wet;
                    tot /= 256;
                    tot += tmp;

                    rgn =
                        (cp.memory[currchannel].backbuff_get(dly) * cp.regen) / 256 + s[ii];


                    cp.memory[currchannel].backbuff_add(rgn);
                    s[ii] = tot;


                    ii++;
                    count--;
                }

                cp.ang = Ang;

            }
        }


       public void
initSinLookUp()
{
    int             i;
    float           arg,
                    val;

    if (sys.isSinLookUp == 1)
	return;

    for (i = 0; i < 360; i++) {
	arg = ((float) i * sys.M_PI) / 180.0f;
	val = (float) Math.Sin(arg);
	sys.sinLookUp[i] = (int) (val * 1024);
    }
    sys.isSinLookUp = 1;
}
    }
}
