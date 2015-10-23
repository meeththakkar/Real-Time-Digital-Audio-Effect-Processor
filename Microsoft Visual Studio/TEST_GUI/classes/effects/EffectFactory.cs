using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
   public class EffectFactory
    {

        public static Effect getEffect(String effect_name)
        {
            object[] effects = {
            "Autowah",
            "Chorus",
            "Delay",
            "Distortion",
            "Equalizer",
            "Fuzz",
            "Noisegate",
            "Phasor",
            "Reverb",
            "Sustain",
            "Tremolo",
            "Vibrato"};


            switch (effect_name)
            {

                    //done 
                case "Autowah":
                    return new Autowah();

                    //done
                case "Chorus":
                    return new Chorus();
  
                  
                    //done
                case "Delay" :
                    return new Delay();
                    
                    //done
                case "Distortion" :
                    return new Distortion();

                    
                //case "Equalizer":
                //    return new Equalizer();
                   

                    //done
                case "Fuzz" :
                    return new Fuzz();


                    //done
                case "Noisegate":
                    return new Noisegate();


                case "Phasor":
                    return new Phasor();


                case "Reverb":
                    return new Reverb();
                    

                case "Sustain":
                    return new Sustain();


                case "Tremolo":
                    return new Tremolo();


                case "Vibrato":
                    return new Vibrato();
                    break;

                   

            }
            return null;
        }
    }
}
