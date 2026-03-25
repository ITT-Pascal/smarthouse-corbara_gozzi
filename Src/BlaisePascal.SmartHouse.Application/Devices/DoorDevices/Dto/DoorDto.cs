namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Dto
{
    public class DoorDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string DeviceStatus { get; set; }
        public uint Code { get; set; }
        public DateTime DateTimeAtCreationUtc { get; set; }
        public DateTime LastModifierAtUtc { get; set; }

        public override string ToString()
        {
            return
                $"ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"DeviceStatus: {DeviceStatus}\n" +
                $"Code: ******\n" +
                $"DateTimeAtCreation: {DateTimeAtCreationUtc}" +
                $"LastModifierAtUtc: {LastModifierAtUtc}";
        }

    }
}
