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
                throw new ArgumentOutOfRangeException(nameof(val), "Zoom: Invalid Zoom value[out of 10..200]");
            }
            Value = val;
        }
        public static Zoom NewZoom(uint val)
        {
            return new Zoom(val);
        }
        public static Zoom NewMinZoom()
        {
            return new Zoom(10);
        }
        public static Zoom NewMaxZoom()
        {
            return new Zoom(200);
        }
        public static Zoom NewHalfZoom()
        {
            return new Zoom(100);
        }
        public static Zoom operator +(Zoom zoom, uint jump)
        {
            if (zoom.Value + jump > maxZoom)
                return NewMaxZoom();
            return NewZoom(zoom.Value + jump);
        }
        public static Zoom operator -(Zoom zoom, uint jump)
        {
            if (zoom.Value + jump < minZoom)
                return NewMinZoom();
            return NewZoom(zoom.Value - jump);
        }
    }
}
