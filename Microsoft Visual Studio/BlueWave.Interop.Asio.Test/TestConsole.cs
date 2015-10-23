#region
//
// BlueWave.Interop.Asio by Rob Philpott. Please send all bugs/enhancements to
// rob@bigdevelopments.co.uk.  This file and the code contained within is freeware and may be
// distributed and edited without restriction. You may be bound by licencing restrictions
// imposed by Steinberg - check with them prior to distributing anything.
// 

#endregion

using System;
using System.Threading;
using BlueWave.Interop.Asio;

namespace BlueWave.Interop.Asio.Test
{
	/// <summary>
	/// A simple test console application
	/// </summary>
	public class TestConsole
	{
        // we'll store the samples in a 2d array (one dimension is the buffer index,
        // the other is the delay count)
		private static float[,] _delayBuffer;

		// how many buffers to keep for delay purposes
		private const int MaxBuffers = 100;

		// the delay (in whole buffers) for the left and right channels
        private static int _leftDelay = 0;
        private static int _rightDelay = 0;

        // a counter to keep track of where we are in the delay array
        private static int _counter;
        
        // STAThread is ESSENTIAL to make this work
		[STAThread] public static void Main(string[] args)
		{
            // no messing, this is high priority stuff
			//Thread.CurrentThread.Priority = ThreadPriority.Highest;
            
			// make sure we have at least one ASIO driver installed
			if (AsioDriver.InstalledDrivers.Length == 0)
			{
				Console.WriteLine("There appears to be no ASIO drivers installed on your system.");
				Console.WriteLine("If your soundcard supports ASIO natively, install the driver");
				Console.WriteLine("from the support disc. If your soundcard has no native ASIO support");
				Console.WriteLine("you can probably use the generic ASIO4ALL driver.");
				Console.WriteLine("You can download this from: http://www.asio4all.com/");
				Console.WriteLine("It's very good!");
				Console.WriteLine();
				Console.WriteLine("Hit Enter to exit...");
				Console.ReadLine();
				return;
			}

            // bingo, we've go at least one
			Console.WriteLine("Your system has the following ASIO drivers installed:");
			Console.WriteLine();

            // so iterate through them
			for (int index = 0; index < AsioDriver.InstalledDrivers.Length; index++)
			{
                // and display them
				Console.WriteLine(string.Format("  {0}. {1}", index + 1, AsioDriver.InstalledDrivers[index]));
			}

			Console.WriteLine();

			int driverNumber = 0;

            // get them to choose one
			while (driverNumber < 1 || driverNumber > AsioDriver.InstalledDrivers.Length)
			{
				// we'll keep telling them this until they make a valid selection
				Console.Write("Select which driver you wish to use (x for exit): ");
				ConsoleKeyInfo key = Console.ReadKey();
				Console.WriteLine();

				// deal with exit condition
				if (key.KeyChar == 'x') return;

				// convert from ASCII to int
				driverNumber = key.KeyChar - 48;
			}

			Console.WriteLine();
			Console.WriteLine("Using: " + AsioDriver.InstalledDrivers[driverNumber - 1]);
			Console.WriteLine();

			// load and activate the desited driver
			AsioDriver driver = AsioDriver.SelectDriver(AsioDriver.InstalledDrivers[driverNumber - 1]);

			// popup the driver's control panel for configuration
            driver.ShowControlPanel();

			// now dump some details
            Console.WriteLine("  Driver name = " + driver.DriverName);
            Console.WriteLine("  Driver version = " + driver.Version);
            Console.WriteLine("  Input channels = " + driver.NumberInputChannels);
            Console.WriteLine("  Output channels = " + driver.NumberOutputChannels);
            Console.WriteLine("  Min buffer size = " + driver.BufferSizex.MinSize);
            Console.WriteLine("  Max buffer size = " + driver.BufferSizex.MaxSize);
            Console.WriteLine("  Preferred buffer size = " + driver.BufferSizex.PreferredSize);
            Console.WriteLine("  Granularity = " + driver.BufferSizex.Granularity);
            Console.WriteLine("  Sample rate = " + driver.SampleRate);

			// get our driver wrapper to create its buffers
			driver.CreateBuffers(false);

			// write out the input channels
            Console.WriteLine("  Input channels found = " + driver.InputChannels.Length);
			Console.WriteLine("  ----");

            foreach (Channel channel in driver.InputChannels)
			{
				Console.WriteLine(channel.Name);
			}

			// and the output channels
            Console.WriteLine("  Output channels found = " + driver.OutputChannels.Length);
            Console.WriteLine("----");

            foreach (Channel channel in driver.OutputChannels)
			{
				Console.WriteLine(channel.Name);
			}

            // create a an array of standard sized buffers with a size of 100 
            _delayBuffer = new float[driver.BufferSizex.PreferredSize, MaxBuffers];
            
            // this is our buffer fill event we need to respond to
            driver.BufferUpdate += new EventHandler(AsioDriver_BufferUpdate);

            // and off we go
            driver.Start();

            // wait for enter key
            Console.WriteLine();
            Console.WriteLine("Press Enter to end");
			Console.ReadLine();

            // and all donw
            driver.Stop();
		}

		/// <summary>
		/// Called when a buffer update is required
		/// </summary>
		private static void AsioDriver_BufferUpdate(object sender, EventArgs e)
		{
			// the driver is the sender
            AsioDriver driver = sender as AsioDriver;
	
			// increment the delay buffer counter
			_counter++;

			// and wrap if nede be
			if (_counter >= 100) _counter = 0;

			// get the input channel and the stereo output channels
            Channel input = driver.InputChannels[0];
			Channel leftOutput = driver.OutputChannels[0];
			Channel rightOutput = driver.OutputChannels[1];

			for (int index = 0; index < leftOutput.BufferSize; index++)
			{
				// copy the input buffer to our delay array
				_delayBuffer[index, _counter] = input[index];

				// and copy from the delay array to the output buffers (wrapping as needed)
				leftOutput[index] = _delayBuffer[index, (_counter - _leftDelay) >= 0 ? _counter - _leftDelay : _counter - _leftDelay + MaxBuffers];
				rightOutput[index] = _delayBuffer[index, (_counter - _rightDelay) >= 0 ? _counter - _rightDelay : _counter - _rightDelay + MaxBuffers];
			}
		}
	}
}
