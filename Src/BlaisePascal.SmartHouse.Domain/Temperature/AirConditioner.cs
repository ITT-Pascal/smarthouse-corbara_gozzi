using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.Temperature
{
    public class AirConditioner: AbstractDevice, ISwitchable, IToggable
    {
        private const int minSpeed = 1;
        private const int maxSpeed = 10;
        private const int minHeat = 0;
        //-------ATTRIBUTES AND PROPERTY-------

        public uint Speed { get; private set; }
        public Heat Heat { get; private set; }
        public Heat CustomHeat = new Heat(15);
        public AcMode ModeOfAc { get; private set; }

        public Dictionary<AcMode, Heat> HeatForAcModes = new Dictionary<AcMode, Heat>()
        {
            { AcMode.Hot, new Heat(30) },
            { AcMode.Heat, new Heat(20) },
            { AcMode.Cool, new Heat(10) },
            { AcMode.Freeze, new Heat(-10) },
            { AcMode.Dry, new Heat(0) }
        };

        //------CONSTRUCTORS------
        public AirConditioner(): base()
        {
            Speed = minSpeed;
            Heat = new Heat(minHeat);
        }
        public AirConditioner(Guid id) : base(id)
        {
            Speed = minSpeed;
            Heat = new Heat(minHeat);
        }

        public AirConditioner(string name, Guid guid): base(guid, name)
        {
            Speed = minSpeed;
            Heat = new Heat(minHeat);
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
            Heat = new Heat(0);
            Speed = 0;
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
        public void ChangeSpeed(int amount)
        {           
            if (DeviceStatus == DeviceStatus.On)
            {
                if (ModeOfAc == AcMode.Dry)
                    Speed = -DeviceValidator.ValidateAcSpeed(amount, maxSpeed);
                else
                    Speed = DeviceValidator.ValidateAcSpeed(amount, maxSpeed);
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfMod.Add(DateTime.UtcNow);
            }
            else
                throw new ArgumentException("You have to turn it on.");                  
        }
        public void ChangeMode(AcMode mode)
        {
            if (DeviceStatus == DeviceStatus.On)
            {
                ModeOfAc = mode;
                Heat = HeatForAcModes[ModeOfAc];
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfMod.Add(DateTime.UtcNow);
            }
            else if (mode == AcMode.Custom)
            {
                Heat = CustomHeat;
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfMod.Add(DateTime.UtcNow);
            }
            else
                throw new ArgumentException("You have to turn it on.");
        }
        private void PutStarterStatus()
        {
            ModeOfAc = AcMode.Cool;
            Heat = HeatForAcModes[ModeOfAc];
        }
        public void ChangeHeatCustomMode(Heat newHeat)
        {
            CustomHeat = newHeat;
        }
    }
}

