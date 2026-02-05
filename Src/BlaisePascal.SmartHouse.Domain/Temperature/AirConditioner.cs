using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.Temperature
{
    public class AirConditioner: AbstractDevice, ISwitchable, IToggable
    {
        private const int speedAtOff = 0;
        private const int speedAtOn = 0;
        private const int minTemp = 0;
        //-------ATTRIBUTES AND PROPERTY-------

        public SpeedRPM Speed { get; private set; }
        public Temperature Temperature { get; private set; }
        public Temperature CustomTemperature = new Temperature(15);
        public AcMode ModeOfAc { get; private set; }

        public Dictionary<AcMode, Temperature> HeatForAcModes = new Dictionary<AcMode, Temperature>()
        {
            { AcMode.Hot, new Temperature(30) },
            { AcMode.Heat, new Temperature(20) },
            { AcMode.Cool, new Temperature(10) },
            { AcMode.Freeze, new Temperature(-10) },
            { AcMode.Dry, new Temperature(0) }
        };

        //------CONSTRUCTORS------
        public AirConditioner(): base()
        {
            Speed = new SpeedRPM(speedAtOff);
            Temperature = new Temperature(minTemp);
        }
        public AirConditioner(Guid id) : base(id)
        {
            Speed = new SpeedRPM(speedAtOff);
            Temperature = new Temperature(minTemp);
        }

        public AirConditioner(string name, Guid guid): base(guid, name)
        {
            Speed = new SpeedRPM(speedAtOff);
            Temperature = new Temperature(minTemp);
        }

        //------METHODS------
        public sealed override void SwitchOn()
        {
            base.SwitchOn();
            PutStarterStatus();
        }
        public sealed override void SwitchOff()
        {
            base.SwitchOff();
            Temperature = new Temperature(0);
            Speed = new SpeedRPM(speedAtOff);
        }
        public void Toggle()
        {
            if (DeviceStatus == DeviceStatus.On)
                SwitchOff();
            else
                SwitchOn();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        //cambia la velocità delle ventole
        public void ChangeSpeedTo(int speed)
        {           
            if (DeviceStatus == DeviceStatus.On)
            {
                if (ModeOfAc == AcMode.Dry)
                    Speed = new SpeedRPM(-speed);
                else
                    Speed = new SpeedRPM(speed);
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfMod.Add(DateTime.UtcNow);
            }
            else
                throw new ArgumentException("You have to turn it on.");                  
        }
        public void ChangeModeTo(AcMode newMode)
        {
            if (DeviceStatus == DeviceStatus.On)
            {
                if (newMode == AcMode.Custom)
                {
                    Temperature = CustomTemperature;
                    LastModifierAtUtc = DateTime.UtcNow;
                    HistoryOfMod.Add(DateTime.UtcNow);
                }
                else
                {
                    ModeOfAc = newMode;
                    Temperature = HeatForAcModes[ModeOfAc];
                    LastModifierAtUtc = DateTime.UtcNow;
                    HistoryOfMod.Add(DateTime.UtcNow);
                }
            }
            else
                throw new ArgumentException("You have to turn it on.");
        }
        private void PutStarterStatus()
        {
            ModeOfAc = AcMode.Cool;
            Temperature = HeatForAcModes[ModeOfAc];
            Speed = new SpeedRPM(speedAtOn);
        }
        public void ChangeCustomTemperatureTo(Temperature newTemp)
        {
            CustomTemperature = newTemp;
        }
        public void ReturnAllModifiesOfDevice() => ReturnAllModifiesOfDevice(this);
    }
}

