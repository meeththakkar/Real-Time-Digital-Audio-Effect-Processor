using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
    public class ChorusParams : Parameters
    {


    public int             wet,
                    dry,
                    depth;
    public short mode;
    public int speed,
                    regen;
    public float ang;

    public backBuf[] memory;

        


     public ChorusParams()
     {
         memory = new backBuf[sys.MAX_CHANNELS];


         update_chorus_depth(20);
         update_chorus_dry(20);
         update_chorus_mode(1);
         update_chorus_regen(15);
         update_chorus_speed(750);
         update_chorus_wet(20);


     }


       public void
update_chorus_speed(int adj)
{
    speed =	(int) 360.0 * sys.sample_rate / (adj * 1000 * sys.nchannels);
}

public void
update_chorus_depth(int adj)
{
    depth = (int) adj / 2;
}

public void
update_chorus_mode(int adj)
{
    if (mode == 0) {
	mode = 0;
    } else {
	mode = 1;
    }
}

public void
update_chorus_wet(int adj)
{
    wet = (int) (adj * 2.56);
}

public void
update_chorus_dry(int adj)
{
    dry = (int) (adj * 2.56);
}

public void
update_chorus_regen(int adj)
{
    regen = (int) (adj * 2.56);
}

    }
}
