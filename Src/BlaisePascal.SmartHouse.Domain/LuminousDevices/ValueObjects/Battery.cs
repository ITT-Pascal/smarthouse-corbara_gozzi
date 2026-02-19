using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices.ValueObjects
{
    public class Battery
    {
        public const uint minPercentage = 0;
        public const uint maxPercentage = 100;

        //UNA SCARICA COMPLETA DURA 10 h (600 min)  1 unità di scarica = 6 min

        //UNA RICARICA COMPLETA DURA 3 h (ca 200 min) 1 unità di carica = 2 min

        public uint ChargeValue { get; }

        public Battery(uint charge)
        {
            if (charge < minPercentage)
                ChargeValue = minPercentage;
            else if (charge > maxPercentage)
                ChargeValue = maxPercentage;
            else
                ChargeValue = charge;
        }
        public static Battery NewChargeLevel(uint charge)
        {
            return new Battery(charge);
        }
        public static Battery operator +(Battery charge, uint jump)
        {
            if (charge.ChargeValue + jump > maxPercentage)
                return NewChargeLevel(maxPercentage);
            return NewChargeLevel(charge.ChargeValue + jump);
        }
        public static Battery operator -(Battery charge, uint jump)
        {
            if (charge.ChargeValue - jump < minPercentage)
                return NewChargeLevel(minPercentage);
            return NewChargeLevel(charge.ChargeValue - jump);
        }

    }
}
