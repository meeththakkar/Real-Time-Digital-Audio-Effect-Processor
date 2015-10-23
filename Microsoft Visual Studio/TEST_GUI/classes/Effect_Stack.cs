using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AEF
{
    public class Effect_Stack
    {
        public Effect[] effects = new Effect[sys.MaxEffectStackSize];
        public int no_of_effects = 0 ; 

         public Effect_Stack()
        {
            


        }

         public void add_effect(Effect e)
         {
             effects[no_of_effects] = e;
             no_of_effects++;

         }

         public void delete_effect(int i)
         {
             throw new Exception("not impolemented");
         }

         internal void delete_effect(object selected)
         {
             no_of_effects = 0;
             Effect[] newe = new Effect[sys.MaxEffectStackSize];

             for (int i = 0; i < no_of_effects; i++)
             {
                 if( ! effects[i].Equals(selected))
                 {
                     newe[no_of_effects] = effects[i];
                     no_of_effects++;
                 }
             }
             
         }
    }
}
