using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories
{
    public interface ILampRepository
    {
        void AddLamp(Lamp lamp);
        void UpdateLamp(Lamp lamp);
        void DeleteLamp(Guid id);
        Lamp GetLampById(Guid id);
        List<Lamp> GetAllLamps();
    }
}
