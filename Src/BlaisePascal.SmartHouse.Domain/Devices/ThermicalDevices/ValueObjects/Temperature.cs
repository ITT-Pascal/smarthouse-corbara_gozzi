namespace BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects
{
    public class Temperature
    {
        public const int minHeat = -10; 
        public const int maxHeat = 30;
        public int Heat { get; }

        public Temperature(int val)
        {
            if (val < minHeat || val > maxHeat)
                throw new ArgumentOutOfRangeException(nameof(val), $"Heat: Heat out of range[out of -10..30]");
            Heat = val;
        }
        public static Temperature NewTemperature(int val)
        {
            return new Temperature(val);
        }
        public static Temperature NewZeroTemperature()
        {
            return new Temperature(0);
        }
    }
}
