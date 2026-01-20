using BlaisePascal.SmartHouse.Domain.ConditionerClasses;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain
{
    public class AirConditioner: AbstractDevice, ISwitchable, IToggable
    {
        private const int minSpeed = 1;
        private const int maxSpeed = 10;
        private const int minHeat = 0;
        private const int maxHeat = 0;
        //-------ATTRIBUTES AND PROPERTY-------

        public int Speed { get; private set; }
        public int Heat { get; private set; }
        public AcMode ModeOfAc { get; private set; }

        public Dictionary<AcMode, int> HeatForAcModes = new Dictionary<AcMode, int>()
        {
            { AcMode.Heat, 30 },
            { AcMode.Cool, 10 },
            { AcMode.Dry, 0 }
        };

        //------CONSTRUCTORS------
        public AirConditioner(): base()
        {
            Speed = minSpeed;
            Heat = minHeat;
            
        }
        public AirConditioner(Guid id) : base(id)
        {
            Speed = minSpeed;
            Heat = minHeat;
        }

        public AirConditioner(string name, Guid guid): base(guid, name)
        {
            Speed = minSpeed;
            Heat = minHeat;
        }

        //------METHODS------
        public sealed override void SwitchOn()
        {
            base.SwitchOn();
            this.PutStarterStatus();
        }
        public sealed override void SwitchOff()
        {
            base.SwitchOff();
            Heat = 0;
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
                    Speed = -(DeviceValidator.ValidateAcSpeed(amount, maxSpeed));
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
            else
                throw new ArgumentException("You have to turn it on.");
        }
        private void PutStarterStatus()
        {
            ModeOfAc = AcMode.Cool;
            Heat = HeatForAcModes[ModeOfAc];
        }
    }
}

