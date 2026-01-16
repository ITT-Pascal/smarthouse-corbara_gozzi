using BlaisePascal.SmartHouse.Domain.ConditionerClasses;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain
{
    public class AirConditioner: AbstractDevice, ISwitchable
    {
        private const int minPower = 0;
        private const int maxPower = 10;
        private const int minHeat = 0;
        private const int maxHeat = 45;

        public int Power { get; private set; }
        public int Heat { get; private set; }
        public AcMode ModeOfAc { get; private set; }

        //------CONSTRUCTORS------
        public AirConditioner(): base()
        {
            Power = minPower;
            Heat = minHeat;
        }
        public AirConditioner(Guid id) : base(id)
        {
            Power = minPower;
            Heat = minHeat;
        }

        public AirConditioner(string name, Guid guid): base(guid, name)
        {
            Power = minPower;
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
            Power = 0;
        }

        public void ChangePower(int amount)
        {           
            if (DeviceStatus == DeviceStatus.On)
            {
                Power = DeviceValidator.ValidatePowerAc(amount, maxPower);
                LastModifierAtUtc = DateTime.UtcNow;
            }
            else
                throw new ArgumentException("You have to turn it on.");                  
        }
        //TODO: ricontrollare meglio il funzionamento del metodo
        public void ChangeMode(AcMode mode)
        {
            if (DeviceStatus == DeviceStatus.On)
            {
                if (mode == AcMode.FAN)
                {
                    Heat = 20;
                    ModeOfAc = (AcMode)AcMode.FAN;
                }
                else if (mode == AcMode.COOL)
                {
                    Heat = 10;
                    ModeOfAc = (AcMode)AcMode.COOL;
                }
                else if (mode == AcMode.HEAT)
                {
                    Heat = 30;
                    ModeOfAc = (AcMode)AcMode.HEAT;
                }
                else if (mode == AcMode.CUSTOM)
                    this.PutCustomMode();
                else
                    throw new ArgumentException("You havent say any mode , so it still the actual one");
            }
            else
                throw new ArgumentException("You have to turn it on.");
        }

        public void ChangeHeatCustomMode(int heat)
        {            
            if (DeviceStatus == DeviceStatus.On)
            {
                Heat = DeviceValidator.ValidateHeatInCustomMode(heat, minHeat, maxHeat);
                LastModifierAtUtc = DateTime.UtcNow;
            }
            else
                throw new ArgumentException("You have to turn it on.");
        }      

        private void PutStarterStatus()
        {
            ModeOfAc = AcMode.FAN;
            Heat = 20;
            Power = 5;
        }

        private void PutCustomMode()
        {
            ModeOfAc = (AcMode)AcMode.CUSTOM;
            Heat = 25;
        }
    }
}

