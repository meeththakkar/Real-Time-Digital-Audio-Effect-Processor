using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;


namespace AEF
{
    public class ReverbParams : Parameters
    {

       public   ReverbBuffer history;
     public int             dry,
                    wet,
                    regen,
                    delay;
        
    

                public void
        update_reverb_wet(int adj)
        {
           this.wet = (int) (adj * 2.56);
        }

        public void
        update_reverb_dry(int adj)
        {
           this.dry = (int) (adj * 2.56);
        }

        public void
        update_reverb_delay(int adj)
        {
           this.delay =
	        (int)( adj * sys.nchannels * sys.sample_rate )/( (1000 * sys.buffer_size));
        }

        public void
        update_reverb_regen(int adj)
        {
           this.regen = (int) (adj * 2.56);
        }


    }
}



