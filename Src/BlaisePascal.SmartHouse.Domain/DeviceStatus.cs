using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public enum DeviceStatus
    {
        Unknown,
        On,
        Off,
        Error,
        Stanby,
        Open,
        Closed,
        Locked
    }
}
