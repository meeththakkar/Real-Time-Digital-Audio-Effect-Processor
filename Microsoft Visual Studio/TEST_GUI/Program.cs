using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AEF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        // we'll store the samples in a 2d array (one dimension is the buffer index,
        // the other is the delay count)
        public static float[,] _delayBuffer;

        // how many buffers to keep for delay purposes
        public const int MaxBuffers = 100;

        // the delay (in whole buffers) for the left and right channels
        public static int _leftDelay = 5;
        public static int _rightDelay = 5;

        // a counter to keep track of where we are in the delay array
        public static int _counter;


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainGUI mg = new MainGUI();
            
             Application.Run(mg);
             sys.mainGUI = mg;
        }
    }
}
