using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices
{
    public class AirConditioner: AbstractDevice, IToggable, ISwitchable
    {
        private const int starterCustomTemp = 15;
        //     -------ATTRIBUTES AND PROPERTY-------

        public SpeedRPM Speed { get; private set; }
        public Temperature Temperature { get; private set; }
        public Temperature CustomTemperature { get; private set; } = Temperature.NewTemperature(starterCustomTemp);
        public AcMode AcMode { get; private set; }
        public Dictionary<AcMode, Temperature> AcDictionary { get; init; } = new()
        {
            { AcMode.Hot, Temperature.NewTemperature(Temperature.maxHeat) },
            { AcMode.Heat, Temperature.NewTemperature(20) },
            { AcMode.Cool, Temperature.NewTemperature(10) },
            { AcMode.Freeze, Temperature.NewTemperature(Temperature.minHeat) },
            { AcMode.Dry,Temperature.NewZeroTemperature() }
        };

        //      ------CONSTRUCTORS------
        public AirConditioner(): base()
        {
            Speed = SpeedRPM.NewZeroSpeed();
            Temperature = Temperature.NewZeroTemperature();
        }
        public AirConditioner(Guid id) : base(id)
        {
            Speed = SpeedRPM.NewZeroSpeed();
            Temperature = Temperature.NewZeroTemperature();
        }

        public AirConditioner(Guid id, DeviceName name) : base(id, name)
        {
            Speed = SpeedRPM.NewZeroSpeed();
            Temperature = Temperature.NewZeroTemperature();
        }

        public AirConditioner(Guid id, DeviceName name, DeviceStatus deviceStatus, SpeedRPM speedRPM, Temperature temperature, Temperature customTemperature, AcMode acMode, Dictionary<AcMode, Temperature> dictionary, DateTime dateTimeAtCreationUtc, DateTime lastModifierAtUtc) : this(id, name)
        {
            ID = id;
            Name = name;
            DeviceStatus = deviceStatus;
            Speed = speedRPM;
            Temperature = temperature;
            CustomTemperature = customTemperature;
            AcMode = acMode;
            AcDictionary = dictionary;
            LastModifierAtUtc = lastModifierAtUtc;
            DateTimeAtCreationUtc = dateTimeAtCreationUtc;
        }

        //      ------METHODS------

        //--ON/OFF METHODS--

        public sealed override void SwitchOn()
        {
            base.SwitchOn();
            PutStarterStatus();
        }
        public sealed override void SwitchOff()
        {
            base.SwitchOff();
            Speed = SpeedRPM.NewZeroSpeed();
            Temperature = Temperature.NewZeroTemperature();
        }
        public void Toggle()
        {
            if (DeviceStatus == DeviceStatus.On)
                SwitchOff();
            else
                SwitchOn();
            LastModifierAtUtc = DateTime.Now;
        }

        //--CHANGER METHODS--

        //cambia la velocità delle ventole
        public void ChangeSpeedTo(int speed)
        {
            CheckIsNot(DeviceStatus.Off);
            Speed = AcMode switch
            {
                AcMode.Dry => SpeedRPM.NewSpeed(-Math.Abs(speed)),
                _ => SpeedRPM.NewSpeed(Math.Abs(speed)),
                //SE E' DRY FA COSI, _(altri casi) FAI COSA'
            };
            LastModifierAtUtc = DateTime.Now;            
        }
        public void ChangeModeTo(AcMode newMode)
        {
            CheckIsNot(DeviceStatus.Off);
            switch (newMode)
            {
                case AcMode.Custom:
                    Temperature = CustomTemperature;
                    break;
                default:
                    AcMode = newMode;
                    Temperature = AcDictionary[AcMode];
                    break;
            }
            LastModifierAtUtc = DateTime.Now;
        }
        public void ChangeCustomTemperatureTo(Temperature newTemp)
        {
            CheckIsNot(DeviceStatus.Off);
            CustomTemperature = newTemp;
            LastModifierAtUtc = DateTime.Now;
        }

        //--OTHER METHODS--

        private void PutStarterStatus()
        {
            AcMode = AcMode.Cool;
            Temperature = AcDictionary[AcMode];
            Speed = SpeedRPM.NewBasicSpeed();
            LastModifierAtUtc = DateTime.Now;
        }
    }
}

