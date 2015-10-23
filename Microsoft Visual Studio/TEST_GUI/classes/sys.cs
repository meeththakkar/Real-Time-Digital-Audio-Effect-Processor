using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
   public static class sys
    {
        //Forms

        public static MainGUI mainGUI;
        public static Form_Autowah form_Autowah;

        public static AsioDriver driver = AsioDriver.SelectDriver(AsioDriver.InstalledDrivers[0]);

      
        public static float[,] _delayBuffer;
        // how many buffers to keep for delay purposes
        public const int MAX_BUFFERS = 1024;

        // the delay (in whole buffers) for the left and right channels
        public static int _leftDelay = 0;
        public static int _rightDelay = 0;
        // a counter to keep track of where we are in the delay array
        public static int _counter;


        public const float M_PI = 3.1415926535897932384626433832795f;

        // maximum effects in effect stack 
        public const int MaxEffectStackSize = 10;
        public const int MAX_SAMPLE = 32767;

        public const int MIN_BUFFER_SIZE = 128;
        public const int MAX_BUFFER_SIZE = 65536;
        public const int MAX_CHANNELS = 2;
        public const int MAX_SAMPLE_RATE = 96000;	/* 48000 produces more noise */
        public const int MAX_EFFECTS = 50;
        public const int EFFECT_AMOUNT = 13;
        public const int HIGHPASS = 0;
        public const int LOWPASS = 1;
        public const int MAX_FILTERS= 10;
        public const int nchannels = 1;
        public const int sample_rate = 96000;
        public const int bits = 16;
        public const int buffer_size = MIN_BUFFER_SIZE * 2;
        public const int nbuffers = MAX_BUFFERS;
       



        //DELAY
        public const int MAX_STEP=  65000;
		public const int MAX_COUNT =100;
		public const int MAX_SIZE =(MAX_STEP*MAX_COUNT);

        //ECHO
        public const int  MAX_ECHO_COUNT = 20;
        public const int MAX_ECHO_SIZE = 1000;
            
        //TREMOLO
        public const int MAX_TREMOLO_BUFSIZE = MAX_SAMPLE_RATE*MAX_CHANNELS/2;

        //VIBRATO
        public static int MAX_VIBRATO_BUFSIZE = sample_rate*MAX_CHANNELS;
        public const int VIBRATO_THRESHOLD = 1500;


        //CHORUS
        public static int[]          sinLookUp= new int[360];
        public  static short          isSinLookUp = 0;

        
        public static int no_of_effects =0;



        public static Effect_Stack effect_stack = new Effect_Stack();
        public static RCFilter rcfilter = new RCFilter();


    }
}
