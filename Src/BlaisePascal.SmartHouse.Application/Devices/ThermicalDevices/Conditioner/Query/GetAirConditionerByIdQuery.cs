using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Dto;
using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Query
{
    public class GetAirConditionerByIdQuery
    {
        private readonly IAirConditionerRepository _repository;

        public GetAirConditionerByIdQuery(IAirConditionerRepository repository)
        {
            _repository = repository;
		}

        public AirConditionerDto Execute(Guid id)
        {
			var cond = _repository.GetAirConditionerById(id);
			return AirConditionerMapper.ToDto(cond);
		}
	}
}
