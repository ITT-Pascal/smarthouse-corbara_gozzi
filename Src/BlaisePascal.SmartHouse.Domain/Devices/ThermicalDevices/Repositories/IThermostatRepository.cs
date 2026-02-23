using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;

namespace BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories
{
    public interface IThermostatRepository
    {
        void AddThermostat(Thermostat thermo);
        void UpdateThermostat(Thermostat thermo);
        void DeleteThermostat(Guid id);
        Thermostat GetThermostatById(Guid id);
        List<Thermostat> GetAllThermostat();
    }
}
