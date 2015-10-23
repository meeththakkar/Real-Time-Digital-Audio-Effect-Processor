using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
    public class NoisegateParams : Parameters
    {
       public  float threshold,
                    hold_time,
                    release_time,
                    attack,
            hysteresis;

        public void update_noise_threshold(int adj)
        {
            threshold = adj /100f;
        }

        public void update_noise_hold(int adj)
        {
            hold_time = (int)adj * sys.nchannels * sys.sample_rate / 1000;
        }

        public void update_noise_release(int adj)
        {
            release_time = (int)adj * sys.nchannels * sys.sample_rate / 1000;
        }

        public void update_noise_hyst(int adj)
        {
            hysteresis = adj/ 100f;
        }

        public void update_noise_attack(int adj)
        {
            attack = (int)adj * sys.nchannels * sys.sample_rate / 1000;
        }

        public NoisegateParams()
        {
           threshold = 0.500f;
           hold_time = 2 * sys.nchannels * sys.sample_rate / 1000;
           release_time = 500 * sys.nchannels * sys.sample_rate / 1000;
           attack =  sys.nchannels * sys.sample_rate / 1000;
           hysteresis = 0.410f;
        }
    }
}
