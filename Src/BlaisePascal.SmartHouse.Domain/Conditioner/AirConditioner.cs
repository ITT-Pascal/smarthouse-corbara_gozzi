using BlaisePascal.SmartHouse.Domain.Conditioner;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain
{
    public class AirConditioner: AbstractDevice
    {
        private const int minPower = 1;
        private const int maxPower = 10;
        private const int minHeat = 5;
        private const int maxHeat = 45;

        public int PowerIntensity { get; set; }
        public int Heat { get; set; }
        public AcMode ModeOfAc { get; set; }

        //------CONSTRUCTORS------
        public AirConditioner()
        {
            DeviceStatus = DeviceStatus.Off;
            ID = new Guid();
            Name = "Conditioner";
        }

        public AirConditioner(string name, Guid guid)
        {
            DeviceStatus = DeviceStatus.Off;
            ID = guid;
            Name = name;
        }

        //------METHODS------
        public override void SwitchOn(){this.PutStarterStatus();}
        public override void SwitchOff()
        {
            Heat = 0;
            PowerIntensity = 0;
        }

        public void ChangePower(int amount)
        {           
            if (DeviceStatus == DeviceStatus.On)
            {
                PowerIntensity = DeviceGestor.ValidatePowerAc(amount, maxPower);
                LastModifierAtUtc = DateTime.UtcNow;
            }
            else
                throw new ArgumentException("You have to turn it on.");                  
        }

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
                Heat = DeviceGestor.ValidateHeatInCustomMode(heat, minHeat, maxHeat);
                LastModifierAtUtc = DateTime.UtcNow;
            }
            else
                throw new ArgumentException("You have to turn it on.");
        }      

        private void PutStarterStatus()
        {
            ModeOfAc = AcMode.FAN;
            Heat = 20;
            PowerIntensity = 5;
        }

        private void PutCustomMode()
        {
            ModeOfAc = (AcMode)AcMode.CUSTOM;
            Heat = 25;
        }
    }
}

