using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Query
{
    public class GetAllThermostatByIdQuery
    {
        private readonly IThermostatRepository _thermoRepository;

        public GetAllThermostatByIdQuery(IThermostatRepository thermoRepository)
        {
            _thermoRepository = thermoRepository;
        }

        public List<Thermostat> Execute()
        {
            List<Thermostat> thermostats = _thermoRepository.GetAllThermostat();
            return thermostats;
        }

    }
}
