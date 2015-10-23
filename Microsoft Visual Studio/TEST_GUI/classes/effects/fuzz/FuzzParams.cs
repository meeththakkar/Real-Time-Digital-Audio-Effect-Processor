using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEF
{
    public class FuzzParams: Parameters
    {
       public int fuzz_level;
        public int level;


        public FuzzParams()
        {
            fuzz_level = 30;
            level = 70;
        }

        public void update_fuzz_level(int adj)
        {
            fuzz_level = adj;
        }

        public void update_level(int adj)
        {
            level = adj;

        }



    }
}

