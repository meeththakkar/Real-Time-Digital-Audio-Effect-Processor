using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueWave.Interop.Asio;

namespace AEF
{
   public class Delay : Effect
    {

       public Delay()
       {
           effect_name = "Delay";
           

           parameters = new DelayParams();
           this.parameters.enable = true;

           DelayParams dp = (DelayParams)parameters;

           Form_Delay fd = new Form_Delay();
           controler = fd;
           fd.delay = this;

           dp.update_delay_decay(50);
           dp.update_delay_repeat(4);
           dp.update_delay_time(500);

       }
       public override void process_int(BlueWave.Interop.Asio.Channel input1, BlueWave.Interop.Asio.Channel left_op1, BlueWave.Interop.Asio.Channel right_op1)
       {
           if (parameters.enable)
           {
               DelayParams dp;
               int i,
                               count,
                               current_decay;
               Channel s;

               dp = (DelayParams)this.parameters;

               s = input1;
               count = s.BufferSize;

               int j = 0;
               while (count > 0)
               {
                   /*
                    * add sample to history 
                    */
                   dp.history[dp.index++] = s[j];
                   /*
                    * wrap around 
                    */
                   if (dp.index == dp.delay_size)
                       dp.index = 0;

                   current_decay = dp.delay_decay;
                   for (i = 0; i < dp.delay_count; i++)
                   {
                       if (dp.index >= dp.idelay[i])
                       {
                           if (dp.index - dp.idelay[i] ==
                               dp.delay_start + i * dp.delay_step)
                               dp.idelay[i]++;
                       }
                       else if (dp.delay_size + dp.index - dp.idelay[i] ==
                              dp.delay_start + i * dp.delay_step)
                       {
                           dp.idelay[i]++;
                       }
                       if (dp.idelay[i] == dp.delay_size)
                           dp.idelay[i] = 0;

                       s[j] += dp.history[dp.idelay[i]] * current_decay / 1000;
                       current_decay = current_decay * dp.delay_decay / 1000;
                   }

                   j++;
                   count--;
               }
           }
       }
    }
}
