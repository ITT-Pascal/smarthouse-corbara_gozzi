using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.Luminous_Devices
{
    public class Charge: Intensity
    {
        //UNA SCARICA COMPLETA DURA 10 h (600 min)  1 unità di scarica = 6 min

        //UNA RICARICA COMPLETA DURA 3 h (ca 200 min) 1 unità di carica = 2 min
        

        public Charge(int val): base(val)
        {
            if (val < MinPercentage)
                Value = MinPercentage;
            else if (val > MaxPercentage)
                Value = MaxPercentage;
            else
                Value = val;
            
        }
        public static Charge NewChargeLevel(int val)
        {
            return new Charge(val);
        }
        public sealed override Intensity NewIntensity(int val)
        {
            throw new Exception("Method call: You cannot call this method");
        }
        
    }
}
