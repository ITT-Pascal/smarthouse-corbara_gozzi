using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class Intensity
    {
        int maxPercentage = 100;
        int minPercentage = 0;
        int Value { get; }

        public Intensity(int val)
        {
            if (val < minPercentage || val > maxPercentage)
                throw new ArgumentException("Inserire una percentuale di intensità tra 0 e 100");
            Value = val;
        }

        public void AddIntensity(int newIntensity)
        {
        }
    }
}
