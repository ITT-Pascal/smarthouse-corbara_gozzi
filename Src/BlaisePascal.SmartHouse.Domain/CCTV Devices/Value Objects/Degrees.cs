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
        public uint Value { get; }

        public Degrees(uint val)
        {
            if (val > maxDegrees)
                throw new ArgumentException("Degrees: Invalid Degrees value[out of 0..360]");
            Value = val;
        }
        public static Degrees NewDegrees(uint val)
        {
            return new Degrees(val);
        }
    }
}
