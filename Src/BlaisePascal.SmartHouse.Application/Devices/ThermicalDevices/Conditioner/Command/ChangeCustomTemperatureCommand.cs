using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Command
{
    public class ChangeCustomTemperatureCommand
    {
        private readonly IAirConditionerRepository _airConditionerRepository;

        public ChangeCustomTemperatureCommand(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
		}

        public void Execute(Guid id, int newCustomTemperature)
        {
            var airConditioner = _airConditionerRepository.GetAirConditionerById(id);
            airConditioner.ChangeCustomTemperatureTo(Temperature.NewTemperature(newCustomTemperature));
            _airConditionerRepository.UpdateAirConditioner(airConditioner);
		}
	}
}
