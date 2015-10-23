using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
    public class FilterData : Parameters
    {
       public double[,,]     i   ,
                    last_sample ,
                    di ;
    public double          max,
                    amplify,
                    R,
                    C,
                    invR,
                    dt_div_C;


    public FilterData()
    {
       // i = new double[12, 12, 12];
        i = new double[sys.MAX_FILTERS, 2, sys.MAX_CHANNELS];
        
        last_sample = new double[sys.MAX_FILTERS, 2, sys.MAX_CHANNELS];
                    di = new double [sys.MAX_FILTERS,2,sys.MAX_CHANNELS];


    }
    }


    

}
