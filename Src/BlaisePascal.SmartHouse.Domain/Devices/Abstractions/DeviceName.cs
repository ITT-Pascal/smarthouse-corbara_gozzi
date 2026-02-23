namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions
{
    public class DeviceName
    {
        public string Name { get; }

        public DeviceName(string name)
        {
            //CONTROLLO CHE IL NOME NON SIA VUOTO E CHE NON ABBIA PUNTI O SPAZI
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"DeviceName[{name}]: There is no char");
            if(name.Contains(' ') || name.Contains('.'))
                throw new ArgumentException($"DeviceName[{name}]: Name can't contain spaces[ ] or points[.]");
            Name = name;
        }
        public static DeviceName NewDeviceName(string name)
        {
            return new DeviceName(name);
        }
    }
}
