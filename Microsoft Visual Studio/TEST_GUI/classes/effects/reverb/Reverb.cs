using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;
using System.Windows.Forms;

namespace AEF
{
   public class Reverb : Effect
    {


       public Reverb()
       {
           effect_name = "Reverb";
           ReverbParams dr = new ReverbParams();

           
            parameters = dr;
            parameters.enable = true;
            Form_Reverb form = new Form_Reverb();
            form.reverb = this;
            this.controler = form;

        
    
    dr.history = new ReverbBuffer ( 2000);

    dr.delay = (int) (dr.history.nChunks * 0.3);
    dr.wet = 80;
    dr.dry = 254;
    dr.regen = 100;


       }
        public override void process_int(Channel input1, BlueWave.Interop.Asio.Channel left_op1, BlueWave.Interop.Asio.Channel right_op1)
        {
//            reverb_filter(struct effect *p, struct data_block *db)
//{
    ReverbParams dr;
    Channel     s;
    int             Dry,
                    Wet,
                    Rgn,
                    dd,
                    count;
    float[]     Old,
                   Old2
                    ;
    float      tmp,Out,
                    tot;
    dr =(ReverbParams) parameters;

    s = input1;
    count = input1.BufferSize;

    /*
     * get delay 
     */
    dd = dr.delay;
    dd = (dd < 1) ? 1 : ((dd >= dr.history.nChunks) ? dr.history.nChunks -1 : dd);

    /*
     * get parms 
     */
    Dry = dr.dry;
    Wet = dr.wet;
    Rgn = dr.regen;

    Old =  dr.history.reverbBuffer_getChunk(dd);

    if (Old == null)
        MessageBox.Show("no old data");
    Old2 = Old;
            int  i=0,oldi =0;
    while (count>0) {
	/*
	 * mix Old and In into Out, based upon Wet/Dry
	 * then mix Out and In back into In, based upon Rgn/1 
	 */
	tmp = s[i];
	tmp *= Dry;
	tmp /= 256;
    try
    {
        tot = Old[i];
    }
    catch (Exception)
    {

    //    MessageBox.Show("exception in old");
        tot = 1;
    }

	tot *= Wet;
	tot /= 256;
	tot += tmp;
	Out = tot;

	tot *= Rgn;
	tot /= 256;
	tot += s[i];

	s[i] = tot;
	i++;
	oldi++;
	count--;
    }


    float[] tobeadde = new float[s.BufferSize];
    for (int l = 0; l < s.BufferSize; l++) tobeadde[l] = s[l];
 
    dr.history.reverbBuffer_addChunk(tobeadde);
    Old2 = null;

        }
    }
}
