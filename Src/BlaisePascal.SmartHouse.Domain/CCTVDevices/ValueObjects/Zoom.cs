using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTV_Devices
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
    }
}
