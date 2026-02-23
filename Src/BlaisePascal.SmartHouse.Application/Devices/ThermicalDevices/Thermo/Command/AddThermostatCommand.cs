using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

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
