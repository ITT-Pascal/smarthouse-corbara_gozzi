using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Mappers
{
    public class LampMapper
    {
        public static LampDto ToDto(Lamp lamp)
        {
            return new LampDto
            {
                ID = lamp.ID,
                Name = lamp.Name.DevName,
                DeviceStatus = DeviceStatusMapper.ToDto(lamp.DeviceStatus),
                Intensity = lamp.Intensity.Percentage,
                DateTimeAtCreationUtc = lamp.DateTimeAtCreationUtc,
                LastModifierAtUtc = lamp.LastModifierAtUtc
            };
        }

        public static Lamp ToDomain(LampDto dto)
        {
            return new Lamp(
                dto.ID,
                new DeviceName(dto.Name),
                DeviceStatusMapper.ToDomain(dto.DeviceStatus),
                Intensity.NewIntensity(dto.Intensity),
                dto.DateTimeAtCreationUtc,
                dto.LastModifierAtUtc
                );
        }
    }
}
