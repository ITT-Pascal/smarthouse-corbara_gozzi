namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects
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
