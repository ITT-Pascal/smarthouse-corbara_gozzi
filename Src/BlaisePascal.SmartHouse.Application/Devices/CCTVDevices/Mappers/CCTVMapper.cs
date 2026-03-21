using BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Mappers
{
    public class CCTVMapper
    {
        public static CCTVDto ToDto(CCTV cam)
        {
            return new CCTVDto
            {
                ID = cam.ID,
                Name = cam.Name.DevName,
                DeviceStatus = DeviceStatusMapper.ToDto(cam.DeviceStatus),
                Zoom = cam.Zoom.Value,
                Degrees = cam.Degrees.Angle,
                CameraLamp = LampMapper.ToDto(cam.CameraLamp),
                DateTimeAtCreationUtc = cam.DateTimeAtCreationUtc,
                LastModifierAtUtc = cam.LastModifierAtUtc
            };
        }

        public static CCTV ToDomain(CCTVDto dto)
        {
            return new CCTV(
                dto.ID,
                new DeviceName(dto.Name),
                DeviceStatusMapper.ToDomain(dto.DeviceStatus),
                dto.Zoom,
                dto.Degrees,
                LampMapper.ToDomain(dto.CameraLamp),
                dto.DateTimeAtCreationUtc,
                dto.LastModifierAtUtc
                );
        }
    }
}
