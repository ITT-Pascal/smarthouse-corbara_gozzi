using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices.ValueObjects
{
    public class Intensity
    {
        public const uint minPercentage  = 0;
        public const uint maxPercentage = 100;

        public uint Value { get; }

        public Intensity(uint val)
        {
            if (val < minPercentage)
                Value = minPercentage;
            else if (val > maxPercentage)
                Value = maxPercentage;
            else
                Value = val;
        }
        public static Intensity NewIntensity(uint val)
        {
            return new Intensity(val);
        }
        public static Intensity operator +(Intensity intensity, uint jump)
        {
            if (intensity.Value + jump > maxPercentage)
                return NewIntensity(maxPercentage);
            return NewIntensity(intensity.Value + jump);
        }
        public static Intensity operator -(Intensity intensity, uint jump)
        {
            if (intensity.Value - jump < minPercentage)
                return NewIntensity(minPercentage);
            return NewIntensity(intensity.Value - jump);
        }
    }
}
