using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Command
{
    public class ChangeSpeedAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;
        public ChangeSpeedAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid id, int speed)
        {
            var conditioner = _repository.GetAirConditionerById(id);
            if (conditioner != null)
            {
                conditioner.ChangeSpeedTo(speed);
                _repository.UpdateAirConditioner(conditioner);
            }
		}
	}
}
