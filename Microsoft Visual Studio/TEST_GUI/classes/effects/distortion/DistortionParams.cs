using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
    public class DistortionParams :Parameters
    {
        
         public float sat,
                    level,
                    drive,
                    noisegate,
                    lowpass;

         public float[] lastval;
    public FilterData fd;
    public FilterData noise;

        public DistortionParams()
        {

            lastval = new float[sys.MAX_CHANNELS];
            fd = new FilterData();
            noise = new FilterData();
            fd.amplify = 1;
            noise.amplify = 1;
           

        }


       
      public  void
update_distort_level(int adj )
{
    level = (int)adj / 100f; ;
}

public  void
update_distort_sat(int adj )
{
    sat =  adj/5 ;
}

public  void
update_distort_drive(int adj )
{
    drive =  adj ;
}

public  void
update_distort_lowpass(int adj )
{
    lowpass = (int) adj;
}




    }
}
