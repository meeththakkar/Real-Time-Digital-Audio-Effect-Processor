using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
     public class PhasorParams : Parameters
    {
         public float           freq_low;
    public float           freq_high;
    public float           f,
                    df;
     public int           bandpass;
     public FilterData fd;

     public PhasorParams()
     {
         fd = new FilterData();

     }


 public void update_phasor_speed(int adj)
    {
        df = ((freq_high - freq_low) * 1000.0f * sys.buffer_size) / (sys.sample_rate * sys.nchannels *  (float) adj);
}

        public  void
update_phasor_freq_low(int adj)
{
    freq_low = (float) adj;
    f = freq_low;
}

        public void update_phasor_freq_high(int adj)
{
    freq_high = (float) adj;
}


         public void toggle_bandpass()
{

    if (bandpass == 0) bandpass = 1;
    else bandpass = 0;
}



         internal void toggle_bandpass(bool p)
         {
             if (p)
             {
                 bandpass = 1;
             }
             else 
             {
                 bandpass = 0;
             }
         }
    }
}
