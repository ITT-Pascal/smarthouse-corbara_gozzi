using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Command
{
    public class ChangeTargetTemperatureCommand
    {
        private readonly IThermostatRepository Repo;

        public ChangeTargetTemperatureCommand(IThermostatRepository repo)
        {
            Repo = repo;
        }

        public void Execute(Guid id, int temp)
        {
            var thermo = Repo.GetThermostatById(id);
            if (thermo != null)
            {
                thermo.ChangeTargetTemperatureTo(Temperature.NewTemperature(temp));
                Repo.UpdateThermostat(thermo);
            }
        }
    }
}
