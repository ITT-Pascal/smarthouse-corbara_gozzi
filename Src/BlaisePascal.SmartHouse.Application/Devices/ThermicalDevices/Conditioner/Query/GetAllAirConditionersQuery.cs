using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Dto;
using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Query
{
    public class GetAllAirConditionersQuery
    {
		private readonly IAirConditionerRepository Repository;
		public GetAllAirConditionersQuery(IAirConditionerRepository repository)
		{
			Repository = repository;
		}
		public List<AirConditionerDto> Execute()
		{
			List<AirConditionerDto> condDto = [];
			foreach (var cond in Repository.GetAllAirConditioner())
				condDto.Add(AirConditionerMapper.ToDto(cond));
			return condDto;
		}
	}
}
