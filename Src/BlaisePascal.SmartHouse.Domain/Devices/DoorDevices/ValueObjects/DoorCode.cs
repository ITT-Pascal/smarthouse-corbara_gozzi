namespace BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.ValueObjects
{
    public class DoorCode
    {
        private const int codeLenght = 6;
        public uint Code {get; }

        //CODICE A 6 CIFRE
        public DoorCode(uint code)
        {
            if (code.ToString().Length != codeLenght)
                throw new ArgumentException($"Code: Code value must be positive and a lenght of 6");
            Code = code;
        }
        public static DoorCode NewDoorCode(uint code)
        {
            return new DoorCode(code);
        }
    }
}
