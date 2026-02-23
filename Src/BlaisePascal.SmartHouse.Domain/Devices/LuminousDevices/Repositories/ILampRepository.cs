using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories
{
    public interface ILampRepository
    {
        void AddLamp(AbstractLamp lamp);
        void UpdateLamp(AbstractLamp lamp);
        void DeleteLamp(Guid id);
        AbstractLamp GetLampById(Guid id);
        List<AbstractLamp> GetAllLamps();
    }
}
