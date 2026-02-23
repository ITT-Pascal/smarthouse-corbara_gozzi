using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;

namespace BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories
{
    public interface IAirConditionerRepository
    {
        void AddAirConditioner(AirConditioner ac);
        void UpdateAirConditioner(AirConditioner ac);
        void DeleteAirConditioner(Guid id);
        AirConditioner GetAirConditionerById(Guid id);
        List<AirConditioner> GetAllAirConditioner();
    }
}
