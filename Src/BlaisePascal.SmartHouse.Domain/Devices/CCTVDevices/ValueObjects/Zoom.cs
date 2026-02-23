namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects
{
    public class Zoom
    {
        private const uint minZoom = 10;
        private const uint maxZoom = 200;
        public uint Value { get; }

        public Zoom(uint val)
        {
            if (!(val is >= minZoom and <= maxZoom))
            {
                throw new ArgumentException($"Zoom[{val}]: Invalid Zoom value[out of 10..200]");
            }
            Value = val;
        }
        public static Zoom NewZoom(uint val)
        {
            return new Zoom(val);
        }
        public static Zoom operator +(Zoom zoom, uint jump)
        {
            if (zoom.Value + jump > maxZoom)
                return NewZoom(maxZoom);
            return NewZoom(zoom.Value + jump);
        }
        public static Zoom operator -(Zoom zoom, uint jump)
        {
            if (zoom.Value + jump < minZoom)
                return NewZoom(minZoom);
            return NewZoom(zoom.Value - jump);
        }
    }
}
