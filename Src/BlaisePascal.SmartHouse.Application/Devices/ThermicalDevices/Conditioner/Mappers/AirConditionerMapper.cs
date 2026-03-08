using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Mappers
{
    public class AirConditionerMapper
    {
		public static AirConditionerDto ToDto(AirConditioner cond)
		{
			return new AirConditionerDto
			{
				ID = cond.ID,
				Name = cond.Name.Name,
				DeviceStatus = DeviceStatusMapper.ToDto(cond.DeviceStatus),
				Speed = cond.Speed.Value,
				Temperature = cond.Temperature.Heat,
				CustomTemperature = cond.CustomTemperature.Heat,
				AcMode = AcModeMapper.ToDto(cond.AcMode),
				AcDictionary = AirConditionerDictionaryMapper.ToDto(cond.AcDictionary),
				DateTimeAtCreationUtc = cond.DateTimeAtCreationUtc,
				LastModifierAtUtc = cond.LastModifierAtUtc
			};
		}

		public static AirConditioner ToDomain(AirConditionerDto dto)
		{
			return new AirConditioner(
				dto.ID,
				new DeviceName(dto.Name),
				DeviceStatusMapper.ToDomain(dto.DeviceStatus),
				new SpeedRPM(dto.Speed),
				new Temperature(dto.Temperature),
				new Temperature(dto.CustomTemperature),
				AcModeMapper.ToDomain(dto.AcMode),
				AirConditionerDictionaryMapper.ToDomain(dto.AcDictionary),
				dto.DateTimeAtCreationUtc,
				dto.LastModifierAtUtc
				);
		}
	}
}
