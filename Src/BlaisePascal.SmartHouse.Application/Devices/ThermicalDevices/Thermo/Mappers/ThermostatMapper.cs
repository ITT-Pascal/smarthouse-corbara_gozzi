using BlaisePascal.SmartHouse.Application.Devices.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Mappers
{
    public class ThermostatMapper
    {
        public static ThermostatDto ToDto(Thermostat thermo)
        {
            return new ThermostatDto
            {
                ID = thermo.ID,
                Name = thermo.Name.Name,
                DeviceStatus = DeviceStatusMapper.ToDto(thermo.DeviceStatus),
                CurrentTemperature = thermo.CurrentTemperature.Heat,
                TargetTemperature = thermo.TargetTemperature.Heat,
                DateTimeAtCreationUtc = thermo.DateTimeAtCreationUtc,
                LastModifierAtUtc = thermo.LastModifierAtUtc
            };
        }

        public static Thermostat ToDomain(ThermostatDto dto)
        {
            return new Thermostat(
                dto.ID,
                new DeviceName(dto.Name),
                DeviceStatusMapper.ToDomain(dto.DeviceStatus),
                Temperature.NewTemperature(dto.CurrentTemperature),
                Temperature.NewTemperature(dto.TargetTemperature),
                dto.DateTimeAtCreationUtc,
                dto.LastModifierAtUtc
                );
        }
    }
}
