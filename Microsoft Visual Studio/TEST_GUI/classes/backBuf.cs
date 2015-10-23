using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;
using System.Diagnostics;

namespace AEF
{
    public class backBuf
    {
        public float[]      storage;
     int    nstor;
     int    curpos;


     public backBuf(int maxDelay)
     {
         nstor = maxDelay + 1;
         storage = new float[nstor];
         curpos = 0;
     }

         public void backbuff_add(float     d)
{
    curpos++;
    if (curpos == nstor)
	curpos = 0;
    storage[curpos] = d;


}

        public float backbuff_get(int Delay)
{
    int             getpos;
    Debug.Assert(Delay < nstor);
    getpos = (int) curpos;
    getpos -= Delay;
    if (getpos < 0)
	getpos += nstor;

    Debug.Assert(getpos >= 0 && getpos < (int) nstor);

    return  storage[getpos];
}


    }
}
