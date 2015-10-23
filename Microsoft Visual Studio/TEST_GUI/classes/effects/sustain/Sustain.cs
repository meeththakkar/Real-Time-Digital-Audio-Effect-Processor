using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
   public class Sustain : Effect
    {

       public Sustain()
       {
           effect_name = "Sustain";
            SustainParams psustain = new SustainParams();
          
    parameters = psustain;
    parameters.enable = true;
    psustain.noise = 40;
    psustain.sust = 256;
    psustain.threshold = 256;
    Form_Sustain form = new Form_Sustain();
    form.sustain = this;
    this.controler = form;
           
       }
        public override void process_int(BlueWave.Interop.Asio.Channel input1, BlueWave.Interop.Asio.Channel left_op1, BlueWave.Interop.Asio.Channel right_op1)
        {
            
//            sustain_filter(struct effect *p, struct data_block *db)
//{

    int             count;
    Channel     s, db;
    SustainParams ds;
    float      volAccum,
                    tmp;
    float           CompW1;
    float           CompW2;
    float           gateFac;
    float           compFac;

    ds = (SustainParams) parameters;
            db= input1;
    count = db.BufferSize;
    s = db;

    volAccum = ds.volaccum;
    CompW1 = ds.sust / 100.0f;
    CompW2 = 1.0f - CompW1;

            int i = 0;
    while (count > 0) {
	tmp = s[i];
	/*
	 * update volAccum 
	 */
	tmp = (tmp < 0) ? -tmp : tmp;
	volAccum = (256 - ds.noise) * volAccum + ds.noise * tmp;
	volAccum /= 256;

	/*
	 * handle compression 
	 */
	compFac = 30000.0f / (float) volAccum;
	compFac = CompW1 * compFac + CompW2;
	/*
	 * handle gate 
	 */
	if (ds.threshold <= 1.0f)
	    gateFac = 1.0f;
	else
	    gateFac = (volAccum > (ds.threshold * 100)) ? 1.0f :
		((float) (volAccum) / (float) (ds.threshold * 100));
	/*
	 * process signal... 
	 */
	tmp = ((float) (s[i]) * compFac * gateFac);
	s[i] = tmp;
	i++;
	count--;
    }
    ds.volaccum =(int) volAccum;


        }
    }
}
