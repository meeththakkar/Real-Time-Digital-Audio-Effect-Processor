using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
 public   class SustainParams :Parameters
    {
     public int sust,
                   noise,
                   threshold,
                   volaccum;

     
public void
update_sustain_sust(int adj)
{
    sust = (int)( adj * 2.56);
}

public void
update_sustain_noise(int adj)
{
    noise = (int) 
        (adj * 2.56);
}

public void
update_sustain_gate(int adj)
{
    threshold = (int) (adj * 2.56);
}



    }
}
