using BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Mappers
{
    public class DoorMapper
    {
        public static DoorDto ToDto(Door door)
        {
            return new DoorDto
            {
                ID = door.ID,
                Name = door.Name.DevName,
                DeviceStatus = DeviceStatusMapper.ToDto(door.DeviceStatus),
                Code = door.Code.Digits,
                DateTimeAtCreationUtc = door.DateTimeAtCreationUtc,
                LastModifierAtUtc = door.LastModifierAtUtc
            };
        }

        public static Door ToDomain(DoorDto dto)
        {
            return new Door(
                dto.ID,
                new DeviceName(dto.Name),
                DeviceStatusMapper.ToDomain(dto.DeviceStatus),
                DoorCode.NewDoorCode(dto.Code),
                dto.DateTimeAtCreationUtc,
                dto.LastModifierAtUtc
                );
        }
    }
}
