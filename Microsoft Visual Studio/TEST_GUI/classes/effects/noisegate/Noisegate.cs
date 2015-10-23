using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
    public class Noisegate : Effect
    {

       

        public Noisegate()
        {
            parameters = new NoisegateParams();
            effect_name = "Noisegate";
            this.controler = new Form_Noisegate();
            ((Form_Noisegate)controler).ngp = (NoisegateParams) this.parameters;
            parameters.enable = true;
        }

        public override void process_int(Channel input1, Channel left_op1, Channel right_op1)
        {
         //  (struct effect *p, struct data_block *db)



          
    int             	 count;
    Channel     	 s;
    NoisegateParams  ngp;
    int hold_counter=0;    /* how much longer before we start 
					     * to supress the signal */
    int release_counter=0; /* how much longer before we 
					     * fade out to nothing - 
					     * fadeout counter */
     float    	 release_amp = 1.0f;
     float	 attack_amp = 1.0f;
     int  attack_counter = 0;
     short         fadeout = 0;	/* if non-zero, we use hysteresis to
					 * suppress the sound.
	
				 * Otherwise, we use the threshold.  */

     Channel db = input1;
    ngp =  (NoisegateParams) this.parameters;

    count = db.BufferSize;
    s = db;

    int i = 0;

    while (count > 0) {
	/* signal is below the threshold, we're not already fading out */
	if ((((s[i] >= 0 && s[i] < ngp.threshold) || (s[i] <= 0 && s[i] > -ngp.threshold)) && !(0<fadeout))
	    ||   /* or signal is below the hysteresis (stop threshold),
	     * and we're already fading out */
	    (((s[i] >= 0 && s[i] < ngp.hysteresis)
	      || (s[i] <= 0 && s[i] > -ngp.hysteresis)) && (0<fadeout))) {

	    /* When the signal is near the zero for the hold time long,
	     * we do the fadeout  */
	    hold_counter++;
	    if (hold_counter >= ngp.hold_time) {
		/* we're within the hysteresis - init the fadein attack vars,
		 * also we'll now react on threshold instead of hysteresis
		 * (fadeout = 0) */
		if ((s[i] >= 0 && s[i] < ngp.hysteresis)
		    || (s[i] <= 0 && s[i] > -ngp.hysteresis)) {
		    attack_counter = 0;
		    attack_amp = 1;
		    fadeout = 0;
		}

		/* we're fading out - adjust the fadeout amplify coefficient */
		if ((ngp.release_time!=0) && release_counter < ngp.release_time) {
		    release_counter++;
		    release_amp =
			((float) ngp.release_time -
			 (float) release_counter) /
			(float) ngp.release_time;
		/* otherwise, cut off the signal immediately */
		} else if (!(0<ngp.release_time))
		    release_amp = 0;
	    }
	/* signal is above the threshold/hysteresis */
	} else {
	    /* Init vars. Don't be confused by setting up a fadeout.
	     * It only will start if we'll become lower than hysteresis. */
	    hold_counter = 0;
	    release_counter = 0;
	    release_amp = 1.0f;
	    fadeout = 1;

	    /* if fadein is setup, we adjust the attack amp.coeff. */
	    if ((ngp.attack>0) && attack_counter < ngp.attack) {
		attack_counter++;
		attack_amp = (float) attack_counter / (float) ngp.attack;
	    /* otherwise, it's always 1 */
	    } else
		attack_amp = 1;
	}
	s[i] *= attack_amp * release_amp;
	i++;
	count--;
    
}


    
        }
    }
}
