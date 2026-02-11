using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTV_Devices
{
    public class Zoom
    {
        private const int minZoom = 10;
        private const int maxZoom = 200;
        public int Value { get; }

        public Zoom(int val)
        {
            if (val < minZoom || val > maxZoom)
            {
                throw new ArgumentOutOfRangeException("Zoom fuori dal range possibile 10-200");
            }
        }
        public static Zoom NewZoom(int zoom)
        {
            return new Zoom(zoom);
        }
    }
}
