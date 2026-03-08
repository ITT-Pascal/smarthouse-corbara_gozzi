using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Command
{
    public class SwitchOffAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;

        public SwitchOffAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
		}

        public void Execute(Guid id)
        {
            var conditioner = _repository.GetAirConditionerById(id);
            if (conditioner != null)
            {
                conditioner.SwitchOff();
                _repository.UpdateAirConditioner(conditioner);
            }
		}
	}
}
