using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class Intensity
    {
        public const int minPercentage  = 0;
        public const int maxPercentage = 0;

        public int Value { get; }

        public Intensity(int val)
        {
            if (val < minPercentage)
                Value = minPercentage;
            else if (val > maxPercentage)
                Value = maxPercentage;
            else
                Value = val;
        }
        public static Intensity NewIntensity(int val)
        {
            return new Intensity(val);
        }
    }
}
