using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class Intensity
    {
        public int maxPercentage = 100;
        public int minPercentage = 0;
        public int Value { get; }

        public Intensity(int val)
        {
            if (val < minPercentage || val > maxPercentage)
                throw new ArgumentException("Percentuale di intensità fuori al range 0 e 100");
            Value = val;
        }
        public Intensity SumOfIntensity(int newValue)
        {
            return new Intensity(Value + newValue);
        }
        public Intensity SubtractionOfIntensity(int newValue)
        {
            return new Intensity(Value - newValue);
        }
    }
}
