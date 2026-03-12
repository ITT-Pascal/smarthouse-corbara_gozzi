using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Command
{
    public class DeleteAirConditionerCommand
    {
		private readonly IAirConditionerRepository condRepo;

		public DeleteAirConditionerCommand(IAirConditionerRepository repo)
		{
			condRepo = repo;
		}

		public void Execute(Guid id)
		{
			condRepo.DeleteAirConditioner(id);
		}
	}
}
