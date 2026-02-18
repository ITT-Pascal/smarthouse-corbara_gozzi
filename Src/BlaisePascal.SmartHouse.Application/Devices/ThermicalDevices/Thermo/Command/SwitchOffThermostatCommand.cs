using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Command
{
    public class SwitchOffThermostatCommand
    {
        private readonly IThermostatRepository _thermostatRepository;

        public SwitchOffThermostatCommand(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(Guid id)
        {
            var thermostat = _thermostatRepository.GetThermostatById(id);
            if (thermostat != null)
            {
                thermostat.SwitchOff();
                _thermostatRepository.UpdateThermostat(thermostat);
            }
        }
    }
}
