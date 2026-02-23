using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Query
{
    public class GetThermostatByIdQuery
    {
        private readonly IThermostatRepository _thermoRepository;

        public GetThermostatByIdQuery(IThermostatRepository thermoRepository)
        {
            _thermoRepository = thermoRepository;
        }

        public Thermostat Execute(Guid id)
        {
            var thermo = _thermoRepository.GetThermostatById(id);
            return thermo;
        }
    }
}
