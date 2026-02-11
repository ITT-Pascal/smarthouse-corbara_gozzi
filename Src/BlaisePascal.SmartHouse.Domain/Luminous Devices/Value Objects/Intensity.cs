using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class Intensity
    {
        public int MinPercentage { get;  } = 0;
        public int MaxPercentage { get; } = 100;
        
        public int Value { get; protected set; }

        public Intensity(int val)
        {
            if (val < MinPercentage)
                Value = MinPercentage;
            else if (val > MaxPercentage)
                Value = MaxPercentage;
            else
                Value = val;
        }
        public virtual Intensity NewIntensity(int val)
        {
            return new Intensity(val);
        }
    }
}
