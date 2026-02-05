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
        /// <summary>
        /// metodi per somma e differenza del tipo intensity
        /// </summary>
        /// <param name="otherIntensity"></param>
        /// <returns></returns>
        public Intensity SumOfIntensityWith(int otherIntensity)
        {
            return new Intensity(Value + otherIntensity);
        }
        public Intensity SubtractionOfIntensityWith(int otherIntensity)
        {
            return new Intensity(Value - otherIntensity);
        }
    }
}
