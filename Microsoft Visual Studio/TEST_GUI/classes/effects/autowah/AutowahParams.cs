using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
   public class AutowahParams : Parameters
    {

  
      public  float           freq_low;
      public  float           freq_high;
      public  int             wah_count;	/* number of "cries" processed */
      public  float           f,		/* resonance frequency ? */
                              df;		/* delta frequency ? */
      public  FilterData      fd;
      public  short           mixx;


      public AutowahParams()
      {
          fd = new FilterData();
      }

        public void time_changed(long time)
    {

        this.df = (freq_high - freq_low) * 1000 * sys.buffer_size / (sys.sample_rate * sys.nchannels * time);

    }
        public void freq_low_changed(long freq)
        {
             freq_low = (float) freq;
            f = freq_low;
            RCFilter.RC_setup(10, 1.5, fd);
             RCFilter.RC_set_freq(f, fd);
        }

        public void freq_high_changed(long reeq_hi)
        {
             freq_high = (float) reeq_hi;
    RCFilter.RC_setup(10, 1.5, fd);
    RCFilter.RC_set_freq(f,fd);



        }

        
    }


   

}