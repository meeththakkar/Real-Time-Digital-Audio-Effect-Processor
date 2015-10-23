using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
    public class Autowah : Effect
    {

        public Autowah()
        {
            this.effect_name = "Autowah";
            AutowahParams ap = new AutowahParams();
            this.parameters =  ap;

            ap.freq_high = 1000;
            ap.freq_low = 150;
            ap.f = 150;
            ap.wah_count = 0;
            ap.mixx = 0;
            


             ap.df = (float) ((ap.freq_high -ap.freq_low) * 1000.0 * sys.buffer_size / (sys.sample_rate *
						     sys.nchannels *
						     (float) 500));

            ap.fd = new FilterData();
            ap.enable = true;

 
            RCFilter.RC_setup(10, 1.5, ap.fd);
            RCFilter.RC_set_freq(ap.f, ap.fd);
            
            Form_Autowah form = new Form_Autowah();
            form.effect = this;
            controler = form;


            

        }

        public override void process_int(Channel input1, Channel left_op1, Channel right_op1)
        {
            //throw new NotImplementedException();

            if (parameters.enable)
            {

                AutowahParams ap;
                ap = (AutowahParams)this.parameters;

                float[] dry = new float[input1.BufferSize];

                for (int ii = 0; ii < input1.BufferSize; ii++)
                {
                    dry[ii] = input1[ii];
                }

                int i;



                /*
                    if (ap->wah_count != 0) {
                    LC_filter(db->data, db->len, HIGHPASS,ap->freq_high, ap->fd);
                    }
                */

                ap.f += ap.df;
                if (ap.f >= ap.freq_high)
                {
                    ap.df = -ap.df;
                    ap.wah_count = 2;
                }

                if (ap.f <= ap.freq_low && ap.wah_count == 2)
                {
                    ap.wah_count = 0;
                }

                if (ap.wah_count == 1)
                {
                    ap.df = 0;
                    ap.f = ap.freq_low;
                    ap.wah_count = 0;
                }

                if (ap.df != 0)
                    RCFilter.RC_bandpass(input1, input1.BufferSize, ap.fd);

                ap.f += ap.df;
                if (ap.f >= ap.freq_high || ap.f <= ap.freq_low)
                {
                    ap.df = -ap.df;
                    ap.wah_count += 2;

                    if (ap.df != 0)
                        ap.wah_count++;
                }

                RCFilter.RC_set_freq(ap.f, ap.fd);

                if (ap.mixx == 1)
                {
                    for (i = 0; i < input1.BufferSize; i++)
                        input1[i] = (input1[i] + dry[i]) / 2;
                }

            }

        }



       public void update_wah_speed(AutowahParams prams , int adj_value)
{
    prams.df = (float) ((prams.freq_high - prams.freq_low) * 1000.0 * sys.buffer_size / (sys.sample_rate *
						     sys.nchannels *
						     (float) adj_value));
}

public void update_wah_freqlow(int adj_value)
{
    AutowahParams ap = (AutowahParams) this.parameters;
    ap.freq_low = (float) adj_value;
    ap.f = ap.freq_low;
    RCFilter.RC_setup(10, 1.5, ap.fd);
    RCFilter.RC_set_freq(ap.f, ap.fd);
}

void update_wah_freqhi(int adj_value)
{
    AutowahParams ap = (AutowahParams) this.parameters;
    ap.freq_high = (float) adj_value;
    RCFilter.RC_setup(10, 1.5, ap.fd);
    RCFilter.RC_set_freq(ap.f, ap.fd);
}


    }
}
