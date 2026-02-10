using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class Intensity
    {
        public int MaxPercentage { get; } = 100;
        public int MinPercentage { get; } = 0;
        public int Value { get; }

        public Intensity(int val)
        {
            if (val < MinPercentage || val > MaxPercentage)
                throw new ArgumentException("Percentuale di intensità fuori al range 0 e 100");
            Value = val;
        }
        public static Intensity NewIntensity(int val)
        {
            return new Intensity(val);
        }
    }
}
