using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Dto;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Dto
{
    public class CCTVDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string DeviceStatus { get; set; }
        public LampDto CameraLamp { get; set; }
        public uint Degrees { get; set; }
        public uint Zoom { get; set; }
        public DateTime DateTimeAtCreationUtc { get; set; }
        public DateTime LastModifierAtUtc { get; set; }

        public override string ToString()
        {
            return
                $"ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"DeviceStatus: {DeviceStatus}\n" +
                $"CameraLamp: {CameraLamp}\n" +
                $"Degrees: {Degrees}\n" +
                $"Zoom: {Zoom}\n" +
                $"DateTimeAtCreation: {DateTimeAtCreationUtc}" +
                $"LastModifierAtUtc: {LastModifierAtUtc}";
        }
    }
}
