using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace AEF
{
    class Biquad
    {
        public double a0,
                    a1,
                    a2,
                    b1,
                    b2;		/* coefficients */
        double[]  mem;	/* memory for the filter , must be
				 * alocated by the caller, 4 * number of
		
		 * channels */

  
double doBiquad(double x, int channel)
{

    double y;
    double[] mem1;
    mem1 = this.mem;
    y = x * a0 + mem1[0] * a1 + mem[1] * a2 + mem[2] * b1 +mem[3] * b2;
    mem[1] = mem[0];
    mem[0] = x;
    mem[3] = mem[2];
    mem[2] = y;
    return y;
}

    }
}
