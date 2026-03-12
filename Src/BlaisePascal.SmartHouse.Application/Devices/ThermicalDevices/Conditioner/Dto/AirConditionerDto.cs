using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Conditioner.Dto
{
    public class AirConditionerDto
    {
		public Guid ID { get; set; }
		public string Name { get; set; }
		public string DeviceStatus { get; set; }
		public int Speed { get; set; }
		public int Temperature { get; set; }
		public int CustomTemperature { get; set; }
		public string AcMode { get; set; }
		public string AcDictionary { get; set; }
		public DateTime DateTimeAtCreationUtc { get; set; }
		public DateTime LastModifierAtUtc { get; set; }

		public override string ToString()
		{
			return
				$"ID: {ID}\n" +
				$"Name: {Name}\n" +
				$"DeviceStatus: {DeviceStatus}\n" +
				$"Intensity: {Speed}\n" +
				$"Temperature: {Temperature}\n" +
				$"CustomTemperature: {CustomTemperature}\n" +
				$"AcMode: {AcMode}\n" +
				$"AcDictionary: {AcDictionary}\n" +
				$"DateTimeAtCreation: {DateTimeAtCreationUtc}\n" +
				$"LastModifierAtUtc: {LastModifierAtUtc}";
		}
	}
}
