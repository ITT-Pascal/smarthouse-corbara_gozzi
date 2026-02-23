using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices
{
    public interface ILamp : ISwitchable, IToggable
    {
        void IncreaseBy();
        void DecreaseBy();
        void SetIntensityTo(Intensity intensity);
    }
}
