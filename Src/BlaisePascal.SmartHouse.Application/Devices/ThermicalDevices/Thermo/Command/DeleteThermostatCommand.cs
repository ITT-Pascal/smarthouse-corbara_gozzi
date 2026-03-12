using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Command
{
    public class DeleteThermostatCommand
    {
        private readonly IThermostatRepository _thermoRepository;

        public DeleteThermostatCommand(IThermostatRepository thermoRepository)
        {
            _thermoRepository = thermoRepository;
        }

        public void Execute(Guid id)
        {
            _thermoRepository.DeleteThermostat(id);
        }
    }
}
