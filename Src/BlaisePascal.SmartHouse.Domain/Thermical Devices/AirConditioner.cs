using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.Thermic
{
    public class AirConditioner: AbstractDevice, IToggable, ISwitchable
    {
        private const int speedAtOff = 0;
        private const int speedAtOn = 0;
        private const int minTemp = 0;
        private const int starterCustomTemp = 15;
        //     -------ATTRIBUTES AND PROPERTY-------

        public SpeedRPM Speed { get; private set; }
        public Temperature Temperature { get; private set; }
        public Temperature CustomTemperature { get; private set; } = Temperature.NewTemperature(starterCustomTemp);
        public AcMode ModeOfAc { get; private set; }

        public Dictionary<AcMode, Temperature> HeatForAcModes = new()
        {
            { AcMode.Hot, Temperature.NewTemperature(30) },
            { AcMode.Heat, Temperature.NewTemperature(20) },
            { AcMode.Cool, Temperature.NewTemperature(10) },
            { AcMode.Freeze, Temperature.NewTemperature(-10) },
            { AcMode.Dry,Temperature.NewTemperature(0) }
        };

        //      ------CONSTRUCTORS------
        public AirConditioner(): base()
        {
            Speed = SpeedRPM.NewSpeed(speedAtOff);
            Temperature = Temperature.NewTemperature(minTemp);
        }
        public AirConditioner(Guid id) : base(id)
        {
            Speed = SpeedRPM.NewSpeed(speedAtOff);
            Temperature = Temperature.NewTemperature(minTemp);
        }

        public AirConditioner(string name, Guid guid): base(guid, name)
        {
            Speed = SpeedRPM.NewSpeed(speedAtOff);
            Temperature = Temperature.NewTemperature(minTemp);
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
            Temperature = Temperature.NewTemperature(minTemp);
        }

        //--CHANGER METHODS--

        //cambia la velocità delle ventole
        public void ChangeSpeedTo(int speed)
        {

            // INSERIRE CONTROLLO DEVICE STATUS ON
            switch (this.ModeOfAc)
            {
                case AcMode.Dry:
                    Speed = SpeedRPM.NewSpeed(-speed);
                    break;
                default:
                    Speed = SpeedRPM.NewSpeed(speed);
                    break;
            }
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);             
        }
        public void ChangeModeTo(AcMode newMode)
        {
            // INSERIRE CONTROLLO DEVICE STATUS ON
            switch (newMode)
            {
                case AcMode.Custom:
                    Temperature = CustomTemperature;
                    LastModifierAtUtc = DateTime.UtcNow;
                    HistoryOfMod.Add(DateTime.UtcNow);
                    break;
                default:
                    ModeOfAc = newMode;
                    Temperature = HeatForAcModes[ModeOfAc];
                    LastModifierAtUtc = DateTime.UtcNow;
                    HistoryOfMod.Add(DateTime.UtcNow);
                    break;
            }
        }
        public void ChangeCustomTemperatureTo(int newTemp)
        {
            CustomTemperature = Temperature.NewTemperature(newTemp);
        }

        //--OTHER METHODS--

        private void PutStarterStatus()
        {
            ModeOfAc = AcMode.Cool;
            Temperature = HeatForAcModes[ModeOfAc];
            Speed = SpeedRPM.NewSpeed(speedAtOn);
        }
    }
}

