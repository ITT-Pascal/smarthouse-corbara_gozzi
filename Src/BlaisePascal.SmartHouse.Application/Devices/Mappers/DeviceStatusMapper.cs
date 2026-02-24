using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;

namespace BlaisePascal.SmartHouse.Application.Devices.Mappers
{
    public class DeviceStatusMapper
    {
        public static string ToDto(DeviceStatus status)
        {
            return status switch
            {
                DeviceStatus.On => "ON",
                DeviceStatus.Off => "OFF",
                DeviceStatus.Open => "OPEN",
                DeviceStatus.Closed => "CLOSED",
                DeviceStatus.Locked => "LOCKED",
                DeviceStatus.Error => "ERROR",
                _ => "UNKNOWN"
            };
        }
        public static DeviceStatus ToDomain(string status)
        {
            return status switch
            {
                "ON" => DeviceStatus.On,
                "OFF" => DeviceStatus.Off,
                "OPEN" => DeviceStatus.Open,
                "CLOSED" => DeviceStatus.Closed,
                "LOCKED" => DeviceStatus.Locked,
                "ERROR" => DeviceStatus.Error,
                _ => DeviceStatus.Unknown
            };
        }
    }
}
