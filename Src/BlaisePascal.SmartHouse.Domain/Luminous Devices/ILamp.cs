using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.Luminous_Devices
{
    public interface ILamp : ISwitchable, IToggable
    {
        void IncreaseBy();
        void DecreaseBy();
        void SetIntensityTo(Intensity intensity);
    }
}
