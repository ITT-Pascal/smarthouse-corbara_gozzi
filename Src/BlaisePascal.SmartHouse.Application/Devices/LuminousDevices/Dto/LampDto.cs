using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Dto
{
    public class LampDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string DeviceStatus { get; set; }
        public uint Intensity { get; set; }
        public DateTime DateTimeAtCreationUtc { get; set; }
        public DateTime ?LastModifierAtUtc { get; set; }

        public override string ToString()
        {
            return
                $"ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"DeviceStatus: {DeviceStatus}\n" +
                $"Intensity: {Intensity}\n" +
                $"DateTimeAtCreation: {DateTimeAtCreationUtc}" +
                $"LastModifierAtUtc: {LastModifierAtUtc}";
        }
    }
}
