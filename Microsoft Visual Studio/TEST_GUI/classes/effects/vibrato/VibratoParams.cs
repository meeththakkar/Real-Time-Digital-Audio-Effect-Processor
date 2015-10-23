using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
    class VibratoParams : Parameters
    {
        public float vibrato_amplitude;
        public int vibrato_speed,
                        vibrato_phase_buffer_size,
                        vibrato_phase;
        public float[] phase_buffer;

        public VibratoParams()
        {


            int i;


            vibrato_amplitude = 1;
            vibrato_speed = 1000;
            vibrato_phase_buffer_size = sys.MAX_VIBRATO_BUFSIZE;

            phase_buffer = new float[sys.MAX_VIBRATO_BUFSIZE];
            vibrato_phase = 0;

            for (i = 0; i < vibrato_phase_buffer_size; i++)
            {
                phase_buffer[i] = (float) ( 2.0f * Math.Sin(2.0f * Math.PI * (((double)i) / (double)vibrato_phase_buffer_size)));

            }
        }
    }
}
