using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Dto;
using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Query
{
    public class GetAllThermostatQuery
    {
        private readonly IThermostatRepository _thermoRepository;

        public GetAllThermostatQuery(IThermostatRepository thermoRepository)
        {
            _thermoRepository = thermoRepository;
        }

        public List<ThermostatDto> Execute()
        {
            List<ThermostatDto> thermostatDto = [];
            foreach (var thermo in _thermoRepository.GetAllThermostat())
                thermostatDto.Add(ThermostatMapper.ToDto(thermo));
            return thermostatDto;
        }

    }
}
