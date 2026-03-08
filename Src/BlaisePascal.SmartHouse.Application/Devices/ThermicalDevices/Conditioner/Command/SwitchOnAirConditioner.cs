using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Command
{
    public class SwitchOnAirConditioner
    {
		private readonly IAirConditionerRepository _repository;

		public SwitchOnAirConditioner(IAirConditionerRepository repository)
		{
			_repository = repository;
		}

		public void Execute(Guid id)
		{
			var conditioner = _repository.GetAirConditionerById(id);
			if (conditioner != null)
			{
				conditioner.SwitchOn();
				_repository.UpdateAirConditioner(conditioner);
			}
		}
	}
}
