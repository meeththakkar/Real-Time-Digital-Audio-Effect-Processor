using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
   public class RCFilter
    {
       
      public static void LC_filter(Channel sound, int count, int filter_no, double freq, FilterData pp)
{
    double          R, //
                    L, //
                    C, //
                    dt_div_L, //
                    dt_div_C; //
    double          du, //
                    d2i; //
    int             t, //
                    currchannel = 0; //

      freq *= sys.nchannels;
    L = 50e-3;			/* 
				 * like original crybaby wahwah, hehehe 
				 */

          
    C = 1.0 / (4.0 * Math.Pow(sys.M_PI * freq, 2.0) * L);
    R = 300.0;

    dt_div_C = 1.0 / (C * sys.sample_rate * sys.nchannels);
    dt_div_L = 1.0 / (L * sys.sample_rate * sys.nchannels);

    for (t = 0; t < count; t++) {
	du = (double) sound[t] - pp.last_sample[filter_no,0,currchannel];
	pp.last_sample[filter_no,0,currchannel] = (double) sound[t];

	d2i =  dt_div_L * (du - pp.i[filter_no,0,currchannel] * dt_div_C -
			R * pp.di[filter_no,0,currchannel]);

	pp.di[filter_no,0,currchannel] += d2i;
	pp.i[filter_no,0,currchannel] += pp.di[filter_no,0,currchannel];


    //sound[t] = (int) (pp.i[filter_no][0][currchannel] * 500.0); // is modified to 
  //  sound[t] = (float) pp.i[filter_no][0][currchannel]  ;
        
        sound[t] = (float) (pp.i[filter_no,0,currchannel] * 500);
        
	
    }
}




      public static double
      other(double f, double x)
      {
          return 1.0 / (2 * sys.M_PI * f * x);
      }

public static void RC_setup(int max, double amplify, FilterData pp)
{
    pp.max = max;
    pp.amplify = amplify;

  
}

public static  void RC_set_freq(double f, FilterData pp)
{
    pp.R = 1000.0;
   
    pp.C = other((((double) f * sys.nchannels)), pp.R);
    pp.invR = 1.0 / pp.R;
    pp.dt_div_C = (1.0 / (sys.sample_rate * sys.nchannels)) / pp.C;
}

public static void RC_filter(Channel sound, int count, int mode, int filter_no, FilterData pp)
{
    double          du,
                    di;
    int             t,
                    currchannel = 0;

    for (t = 0; t < count; t++) {
    du = (double) sound[t] - pp.last_sample[filter_no,mode,currchannel];
    pp.last_sample[filter_no,mode,currchannel] = (double) sound[t];

    di = pp.invR * (du -  pp.i[filter_no,mode,currchannel] *  pp.dt_div_C);
    pp.i[filter_no,mode,currchannel] += di;

    if (mode == sys.HIGHPASS)
        sound[t] =
        (float)((pp.i[filter_no,mode,currchannel] * pp.R) * pp.amplify);
    else
        sound[t] =(float) (((double) sound[t] -  pp.i[filter_no,mode,currchannel] * pp.R) *  pp.amplify);
    if (sys.nchannels > 1) { }
        //currchannel = !currchannel;

    
    }
}

public static void RC_bandpass(Channel sound, int count, FilterData pp)
{
    int             a;
    for (a = 0; a < pp.max; a++) {
    RC_filter(sound, count, sys.HIGHPASS, a, pp);
    RC_filter(sound, count, sys.LOWPASS, a, pp);
    }
}

public static void RC_highpass(Channel sound, int count, FilterData pp)
{
    int             a;

    for (a = 0; a < pp.max; a++)
    RC_filter(sound, count, sys.HIGHPASS, a, pp);
}

public  static void RC_lowpass(Channel sound, int count, FilterData pp)
{
    int             a;

    for (a = 0; a < pp.max; a++)
    RC_filter(sound, count, sys.LOWPASS, a, pp);
}

    }
}
