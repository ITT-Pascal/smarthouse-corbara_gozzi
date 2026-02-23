using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

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
