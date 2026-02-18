using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.ThermicalDevices.Repositories;

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
