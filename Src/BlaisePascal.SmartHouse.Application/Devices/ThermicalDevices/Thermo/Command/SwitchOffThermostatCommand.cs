using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

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
