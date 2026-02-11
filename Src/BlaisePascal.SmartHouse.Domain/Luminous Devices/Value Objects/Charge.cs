using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.Luminous_Devices
{
    public class Charge
    {
        //UNA SCARICA COMPLETA DURA 10 h (600 min)  1 unità di scarica = 6 min

        //UNA RICARICA COMPLETA DURA 3 h (ca 200 min) 1 unità di carica = 2 min
        public int MaxCharge { get; private set; } = 100;
        public int MinCharge { get; private set; } = 0;
        public int Value { get; }

        public Charge(int val)
        {
            if (val < MinCharge)
                Value = MinCharge;
            else if (val > MaxCharge)
                Value = MaxCharge;
            else
                Value = val;
            
        }
        public static Charge NewChargeLevel(int val)
        {
            return new Charge(val);
        }
    }
}
