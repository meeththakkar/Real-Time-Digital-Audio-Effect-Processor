using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
   public class Tremolo : Effect
    {

        public Tremolo()
        {
            TremoloParams tp = new TremoloParams();
            effect_name = "Tremolo";
            Form_Tremolo form = new Form_Tremolo();
            
            this.controler = form;
            form.tremolo = this;
            parameters =  tp;
            parameters.enable = true;
            
        }
        public override void process_int(Channel input1, Channel left_op1, Channel right_op1)
        {
//            tremolo_filter(struct effect *p, struct data_block *db)

    TremoloParams tp;
    int             ef_index,
                    count,
                    currchannel = 0;
    Channel     s;

    tp = (TremoloParams) parameters;

    s = input1;
    count = s.BufferSize;

    int i = 0;
    while (count>0) {
	tp.history[currchannel,tp.index[currchannel]++] = s[i];	/* add 
									 * sample 
									 * to 
									 * history 
									 */
	if (tp.index[currchannel] == tp.tremolo_size)
	    tp.index[currchannel] = 0;	/* wrap around */

	ef_index = tp.index[currchannel];
	if (tp.index[currchannel] < tp.tremolo_index[currchannel])
	    ef_index += tp.tremolo_size;
	tp.tremolo_phase++;
	if (tp.tremolo_phase >= tp.tremolo_speed)
	    tp.tremolo_phase = 0;

	tp.tremolo_index[currchannel] =
	   (int)( ef_index - tp.tremolo_amplitude - tp.tremolo_amplitude -
	    tp.phase_buffer[tp.tremolo_phase * tp.tremolo_phase_buffer_size /tp.tremolo_speed]);
	if (tp.tremolo_index[currchannel] >= tp.tremolo_size)
	    tp.tremolo_index[currchannel] -= tp.tremolo_size;
	if (tp.tremolo_index[currchannel] < 0)
	    tp.tremolo_index[currchannel] = 0;
	s[i] = tp.history[currchannel,tp.tremolo_index[currchannel]];

  

	i++;
	count--;
    }

        }
    }
}
