using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.ThermicalDevices.Thermo.InMemory
{
    public class InMemoryThermostatRepository
    {
        private readonly List<Thermostat> _thermos;

        public InMemoryThermostatRepository()
        {
            _thermos =
            [
                new(Guid.NewGuid(), DeviceName.NewDeviceName("THERMO1")),
                new(Guid.NewGuid(), DeviceName.NewDeviceName("THERMO2")),
                new(Guid.NewGuid(), DeviceName.NewDeviceName("THERMO3")),
            ];
        }

        public List<Thermostat> GetAllThermostat()
        {
            return _thermos;
        }

        public Thermostat GetThermostatById(Guid id)
        {
            return _thermos.First(thermo => thermo.ID == id);
        }

        public void AddThermostat(Thermostat thermo)
        {
            if (thermo != null)
                _thermos.Add(thermo);
            else
                throw new ArgumentException("Thermostat cannot be null");
        }

        public void DeleteThermostat(Guid id)
        {
            var thermo = GetThermostatById(id);

            if (thermo != null)
                _thermos.Remove(thermo);
        }

        public void UpdateThermostat(Thermostat thermo)
        {
            //To do
        }
    }
}
