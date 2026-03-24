using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Command
{
    public class ToggleAirConditionerCommand
    {
        private readonly IAirConditionerRepository _airConditionerRepository;

        public ToggleAirConditionerCommand(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
		}

        public void Execute(Guid id)
        {
            var airConditioner = _airConditionerRepository.GetAirConditionerById(id);
            if (airConditioner != null)
            {
                if (airConditioner.DeviceStatus == DeviceStatus.On)
                    airConditioner.SwitchOff();
                else
                    airConditioner.SwitchOn();
				_airConditionerRepository.UpdateAirConditioner(airConditioner);
            }
		}
	}
}
