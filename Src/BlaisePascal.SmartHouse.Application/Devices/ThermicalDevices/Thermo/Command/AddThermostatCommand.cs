using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Command
{
    public class AddThermostatCommand
    {
        private readonly IThermostatRepository _thermostatRepository;

        public AddThermostatCommand(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(Thermostat thermo)
        {
            _thermostatRepository.AddThermostat(thermo);
        }
    }
}
