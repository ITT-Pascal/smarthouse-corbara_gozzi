using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Command
{
    public class DeleteThermostaCommand
    {
        private readonly IThermostatRepository _thermoRepository;

        public DeleteThermostaCommand(IThermostatRepository thermoRepository)
        {
            _thermoRepository = thermoRepository;
        }

        public void Execute(Guid id)
        {
            _thermoRepository.DeleteThermostat(id);
        }
    }
}
