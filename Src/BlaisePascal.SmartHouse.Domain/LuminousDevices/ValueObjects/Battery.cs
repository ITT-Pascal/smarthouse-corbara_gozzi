using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices.ValueObjects
{
    public class Battery
    {
        public const int minPercentage = 0;
        public const int maxPercentage = 100;

        //UNA SCARICA COMPLETA DURA 10 h (600 min)  1 unità di scarica = 6 min

        //UNA RICARICA COMPLETA DURA 3 h (ca 200 min) 1 unità di carica = 2 min

        public int ChargeValue { get; }

        public Battery(int charge)
        {
            if (charge < minPercentage)
                ChargeValue = minPercentage;
            else if (charge > maxPercentage)
                ChargeValue = maxPercentage;
            else
                ChargeValue = charge;
            
        }
        public static Battery NewChargeLevel(int charge)
        {
            return new Battery(charge);
        }
        
    }
}
