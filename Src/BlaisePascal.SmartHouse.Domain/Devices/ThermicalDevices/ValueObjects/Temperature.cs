namespace BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects
{
    public class Temperature
    {
        private const int minHeat = -10; 
        private const int maxHeat = 30;
        public int Heat { get; }

        public Temperature(int val)
        {
            if (val < minHeat || val > maxHeat)
                throw new ArgumentException($"Heat[{val}]: Heat out of range[out of -10..30]");
            Heat = val;
        }
        public static Temperature NewTemperature(int val)
        {
            return new Temperature(val);
        }
    }
}
