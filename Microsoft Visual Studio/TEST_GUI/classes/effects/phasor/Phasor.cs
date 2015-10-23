using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
 public   class Phasor : Effect 
    {
     public Phasor()
     {
         effect_name = "Phasor";
         PhasorParams pp = new PhasorParams();
         parameters = pp;
         pp.enable = true;
         Form_Phasor fp = new Form_Phasor();
         fp.phasor = this;
         controler = fp;
    

    pp.freq_low = 300.0f;
    pp.freq_high = 2500.0f;
    pp.f = pp.freq_low;
    pp.df = 42.0f;
    pp.bandpass = 0;
       

    RCFilter.RC_setup(10, 1.25, (pp.fd));
    RCFilter.RC_set_freq(pp.f, (pp.fd));


     }
        public override void process_int(Channel input1, Channel left_op1, Channel right_op1)
        {

            // (struct effect *p, struct data_block *db)

            Channel db = input1;
            PhasorParams pp = (PhasorParams) this.parameters;

    RCFilter.LC_filter(db, db.BufferSize, sys.HIGHPASS, pp.f, pp.fd);

    if (pp.bandpass!=0)
	RCFilter.RC_bandpass(db, db.BufferSize, (pp.fd));

    pp.f += pp.df;
    if (pp.f >= pp.freq_high || pp.f <= pp.freq_low)
	pp.df = -pp.df;

    RCFilter.RC_set_freq(pp.f, (pp.fd));

        }
    }
}
