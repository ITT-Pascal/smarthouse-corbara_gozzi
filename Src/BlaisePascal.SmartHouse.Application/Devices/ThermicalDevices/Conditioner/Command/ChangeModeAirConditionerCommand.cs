using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Command
{
    public class ChangeModeAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;
        public ChangeModeAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid id, string mode)
        {
            var conditioner = _repository.GetAirConditionerById(id);
            if (conditioner != null)
            {
                switch(mode)
                {
                    case "Cool":
						conditioner.ChangeModeTo(AcMode.Cool);
						break;
                    case "Heat":
						conditioner.ChangeModeTo(AcMode.Heat);
						break;
                    case "Hot":
						conditioner.ChangeModeTo(AcMode.Hot);
						break;
                    case "Dry":
						conditioner.ChangeModeTo(AcMode.Dry);
						break;
                    case "Freeze":
                        conditioner.ChangeModeTo(AcMode.Freeze);
                        break;
                    case "Custom":
                        conditioner.ChangeModeTo(AcMode.Custom);
                        break;
					default:
                        throw new ArgumentException("Invalid mode");
				}
                _repository.UpdateAirConditioner(conditioner);
            }
        }
    }
}
