using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class Degrees
    {
        private const int maxDegrees = 360;
        private const int minDegrees = 0;
        public int Value { get; }

        public Degrees(int val)
        {
            if (val > maxDegrees || val < minDegrees)
                throw new ArgumentException("Inserire gradi validi(0-360)");
            Value = val;
        }
        public static Degrees NewDegrees(int val)
        {
            return new Degrees(val);
        }
    }
}
