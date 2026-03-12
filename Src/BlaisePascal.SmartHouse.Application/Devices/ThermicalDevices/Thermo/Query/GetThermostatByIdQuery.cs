using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Dto;
using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Mappers;
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

        public ThermostatDto Execute(Guid id)
        {
            var thermo = _thermoRepository.GetThermostatById(id);
            return ThermostatMapper.ToDto(thermo);
        }
    }
}
