using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
    class TremoloParams : Parameters
    {

         public int             tremolo_size,
                    tremolo_amplitude,
                    tremolo_speed,
                    tremolo_phase_buffer_size,
		            
                    tremolo_phase;
        public int[]   tremolo_index, index;
    public float[,]     history;
    public float[] phase_buffer;


    public TremoloParams()
    {
        tremolo_index = new int[sys.MAX_CHANNELS];
        index = new int[sys.MAX_CHANNELS];

        tremolo_phase_buffer_size = sys.MAX_TREMOLO_BUFSIZE;
        tremolo_size = sys.MAX_TREMOLO_BUFSIZE;
        tremolo_amplitude = 25;
       
            tremolo_speed = (int)(sys.MAX_TREMOLO_BUFSIZE /5 / sys.nchannels);
       
        history = new float[sys.MAX_CHANNELS, tremolo_size];

        for (int i = 0; i < sys.MAX_CHANNELS; i++)
        {
                index[i] = 0;
                tremolo_index[i] = 0;
        }


        phase_buffer = new float[tremolo_phase_buffer_size];
            tremolo_phase = 0;
        
        for (int i = 0; i < tremolo_phase_buffer_size; i++) {
	                phase_buffer[i] = (float) (tremolo_amplitude *Math.Sin(2 * sys.M_PI * (i / tremolo_phase_buffer_size)));
    }
    }


    void
update_tremolo_speed(int adj)
{
    tremolo_speed =
	(int) ((float) sys.sample_rate * sys.nchannels * adj / 1000.0);

}



        
void
update_tremolo_amplitude(int adj)
{
    tremolo_amplitude = (int) adj * 20;
}


    }
}
