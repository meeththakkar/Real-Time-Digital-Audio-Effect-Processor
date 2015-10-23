using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
   
    public  class DelayParams :Parameters
    {
       public float[]     history;	/* history of samples */

    public int             index;	/* curr.index in the history array */
    public int             delay_size,	/* length of history */
                    delay_decay,	/* volume of processed signal */
                    delay_start,
                    delay_step,
                   
                    delay_count;	/* number of repeats */
    public int[] idelay;

       public void update_delay_decay(int adj)
{
    delay_decay = (int) adj * 10;
}

       public void update_delay_time(int adj)
{
    int             new_time;
    new_time = (int)adj * sys.sample_rate * sys.nchannels / 1000;
    delay_start = delay_step = new_time;
    index = 0;
    history = new float[sys.MAX_SIZE];
    idelay =  new int[sys.MAX_COUNT];
}

public void update_delay_repeat(int adj)
{
   delay_count = (int) adj;
   
}

    }
}
