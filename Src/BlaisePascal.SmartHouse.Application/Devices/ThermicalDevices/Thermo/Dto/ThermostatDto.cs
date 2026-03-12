namespace BlaisePascal.SmartHouse.Application.Devices.ThermicalDevices.Thermo.Dto
{
    public class ThermostatDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string DeviceStatus { get; set; }
        public int CurrentTemperature { get; set; }
        public int TargetTemperature { get; set; }
        public DateTime DateTimeAtCreationUtc { get; set; }
        public DateTime LastModifierAtUtc { get; set; }

        public override string ToString()
        {
            return
                $"ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"DeviceStatus: {DeviceStatus}\n" +
                $"CurrentTemperature: {CurrentTemperature}\n" +
                $"TargetTemperature: {TargetTemperature}\n" +
                $"DateTimeAtCreation: {DateTimeAtCreationUtc}" +
                $"LastModifierAtUtc: {LastModifierAtUtc}";
        }
    }
}
