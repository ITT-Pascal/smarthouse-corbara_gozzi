namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects
{
    public class Intensity
    {
        public const uint minPercentage  = 0;
        public const uint maxPercentage = 100;

        public uint Percentage { get; }

        public Intensity(uint val)
        {
            if (val < minPercentage)
                Percentage = minPercentage;
            else if (val > maxPercentage)
                Percentage = maxPercentage;
            else
                Percentage = val;
        }
        public static Intensity NewIntensity(uint val)
        {
            return new Intensity(val);
        }
        public static Intensity NewMinIntensity()
        {
            return new Intensity(0);
        }
        public static Intensity NewMaxIntensity()
        {
            return new Intensity(100);
        }
        public static Intensity NewHalfIntensity()
        {
            return new Intensity(50);
        }
        public static Intensity operator +(Intensity intensity, uint jump)
        {
            if (intensity.Percentage + jump > maxPercentage)
                return NewIntensity(maxPercentage);
            return NewIntensity(intensity.Percentage + jump);
        }
        public static Intensity operator -(Intensity intensity, uint jump)
        {
            if (intensity.Percentage - jump < minPercentage)
                return NewIntensity(minPercentage);
            return NewIntensity(intensity.Percentage - jump);
        }
    }
}
