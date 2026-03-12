using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Mappers
{
    public class AcModeMapper
    {
		public static string ToDto(AcMode mode)
		{
			return mode switch
            {
                AcMode.Hot => "HOT",
                AcMode.Heat => "HEAT",
                AcMode.Cool => "COOL",
                AcMode.Freeze => "FREEZE",
                AcMode.Custom => "CUSTOM",
                AcMode.Dry => "DRY",
                _ => throw new NotImplementedException()
            };
		}
		public static AcMode ToDomain(string mode)
		{
			return mode switch
            {
                "HOT" => AcMode.Hot,
                "HEAT" => AcMode.Heat,
                "COOL" => AcMode.Cool,
                "FREEZE" => AcMode.Freeze,
                "CUSTOM" => AcMode.Custom,
                "DRY" => AcMode.Dry,
                _ => throw new NotImplementedException()
            };
		}
	}
}
