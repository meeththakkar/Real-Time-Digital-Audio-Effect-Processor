using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AEF
{
    public class ReverbBuffer
    {
        public float[] data;
        public int nChunks;
        public int nCursor;


        public ReverbBuffer(int chunks)
        {
            data = new float[(chunks * sys.buffer_size)];
            nChunks = chunks;
            nCursor = 0;
        }
        
        public float[] newChunk()
        {
        return new float[sys.buffer_size];
        }

 public  void reverbBuffer_addChunk(float[] chunk)
{
    Array.Copy(chunk,0,data,nCursor*sys.buffer_size,sys.buffer_size);
    nCursor++;
    nCursor %= nChunks;
}


 public       float[]
reverbBuffer_getChunk( int delay)
{
    int             nFrom;
    int     getFrom;
    float[]     giveTo;

    Debug.Assert((delay >= 0) && (delay < this.nChunks));
    nFrom = this.nCursor - delay;
    while (nFrom < 0)
	nFrom += this.nChunks;
    getFrom =  nFrom * sys.buffer_size;
    giveTo = newChunk();
    Array.Copy(data, nFrom, giveTo, 0, sys.buffer_size);
    //memcpy(giveTo, getFrom, buffer_size * sizeof(DSP_SAMPLE));
     return giveTo;
}




    }
}
