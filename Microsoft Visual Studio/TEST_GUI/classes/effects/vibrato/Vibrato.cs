using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
    public class Vibrato : Effect
    {

        public Vibrato()
        {
            effect_name = "Vibrato";
            VibratoParams vp = new VibratoParams();
            parameters = vp;
            vp.enable = true;
            Form_Vibrato form = new Form_Vibrato();
            controler = form;
            form.vibrato = this;
           
        }
        public override void process_int(BlueWave.Interop.Asio.Channel input1, BlueWave.Interop.Asio.Channel left_op1, BlueWave.Interop.Asio.Channel right_op1)
        {
            Channel s;
           float         ratio;
    int             count;
    VibratoParams vp;

    s = input1;
    count = input1.BufferSize;

    vp = (VibratoParams) parameters;
    int i = 0;
    while (count>0) {
	ratio =	    sys.VIBRATO_THRESHOLD + (vp.phase_buffer[vp.vibrato_phase] * vp.vibrato_amplitude);
	s[i] = s[i] * (ratio / sys.VIBRATO_THRESHOLD);

	vp.vibrato_phase++;

	if (vp.vibrato_phase >= vp.vibrato_speed ||
	    vp.vibrato_phase > sys.MAX_VIBRATO_BUFSIZE)
	    vp.vibrato_phase = 0;

	i++;
	count--;
    }
        }
    }
}
