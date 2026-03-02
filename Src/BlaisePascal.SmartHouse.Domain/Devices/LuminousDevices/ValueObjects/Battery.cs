namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects
{
    public class Battery
    {
        public const uint minPercentage = 0;
        public const uint maxPercentage = 100;

        //UNA SCARICA COMPLETA DURA 10 h (600 min)  1 unità di scarica = 6 min

        //UNA RICARICA COMPLETA DURA 3 h (ca 200 min) 1 unità di carica = 2 min

        public uint Percentage { get; }

        public Battery(uint charge)
        {
            if (charge < minPercentage)
                Percentage = minPercentage;
            else if (charge > maxPercentage)
                Percentage = maxPercentage;
            else
                Percentage = charge;
        }
        public static Battery NewChargeLevel(uint charge)
        {
            return new Battery(charge);
        }
        public static Battery NewBasicChargeLevel()
        {
            return new Battery(50);
        }
        public static Battery operator +(Battery charge, uint jump)
        {
            if (charge.Percentage + jump > maxPercentage)
                return NewChargeLevel(maxPercentage);
            return NewChargeLevel(charge.Percentage + jump);
        }
        public static Battery operator -(Battery charge, uint jump)
        {
            if (charge.Percentage - jump < minPercentage)
                return NewChargeLevel(minPercentage);
            return NewChargeLevel(charge.Percentage - jump);
        }

    }
}
