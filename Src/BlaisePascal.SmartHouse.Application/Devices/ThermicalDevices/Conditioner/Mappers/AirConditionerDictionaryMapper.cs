using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Mappers
{
    public class AirConditionerDictionaryMapper
    {
		public static string ToDto(Dictionary<AcMode,Temperature> dictionary)
		{
			string stringDictionary = JsonSerializer.Serialize(dictionary);
			return stringDictionary;
		}
		public static Dictionary<AcMode,Temperature> ToDomain(string stringDictionary)
		{
			var dictionary = JsonSerializer.Deserialize<Dictionary<AcMode, Temperature>>(stringDictionary);
            if (dictionary == null)
				throw new Exception("Deserialization failed");
			return dictionary;
		}
	}
}
