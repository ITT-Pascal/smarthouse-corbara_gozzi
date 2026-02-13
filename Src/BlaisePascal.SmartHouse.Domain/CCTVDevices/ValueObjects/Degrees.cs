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
        public const uint minDegrees = 0;
        public const int maxDegrees = 360;
        public uint Angle { get; }

        public Degrees(uint angle)
        {
            if (angle > maxDegrees)
                throw new ArgumentException($"Degrees[{angle}]: Invalid Degrees value[out of 0..360]");
            Angle = angle;
        }
        public static Degrees NewDegrees(uint angle)
        {
            return new Degrees(angle);
        }
    }
}
