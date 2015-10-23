using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
  public  class Equalizer : Effect
    {
        public override void process_int(Channel input1, Channel left_op1, BlueWave.Interop.Asio.Channel right_op1)
        {
            throw new NotImplementedException();
        }
    }
}
