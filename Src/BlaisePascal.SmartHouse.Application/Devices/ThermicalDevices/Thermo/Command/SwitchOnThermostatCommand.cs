using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Command
{
    public class SwitchOnThermostatCommand
    {
        private readonly IThermostatRepository _thermostatRepository;
    
        public SwitchOnThermostatCommand(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }
    
        public void Execute(Guid id)
        {
            var thermostat = _thermostatRepository.GetThermostatById(id);
            if (thermostat != null)
            {
                thermostat.SwitchOn();
                _thermostatRepository.UpdateThermostat(thermostat);
            }
        }
    }
}
