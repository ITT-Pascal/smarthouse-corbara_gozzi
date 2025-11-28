using BlaisePascal.SmartHouse.Domain.Conditioner;

namespace BlaisePascal.SmartHouse.Domain
{
    public class AirConditioners
    {
        private const int minPower = 1;
        private const int maxPower = 10;
        private const int minHeat = 5;
        private const int maxHeat = 45;

        public Guid ID { get; set; }
        public DeviceStatus ConditionerStatus { get; set; }
        public string Name { get; set; }
        public int PowerIntensity { get; set; }
        public int Heat { get; set; }
        public AcMode Status { get; set; }

        //------CONSTRUCTORS------
        public AirConditioners()
        {
            ConditionerStatus = DeviceStatus.Off;
            ID = new Guid();
            Name = "Conditioner";
        }

        public AirConditioners(string name, Guid guid)
        {
            ConditionerStatus = DeviceStatus.Off;
            ID = guid;
            Name = name;
        }

        //------METHODS------
        public void SwitchOn()
        {
            this.StartStatus();
        }

        public void SwitchOn(string name)
        {
            this.StartStatus();
        }

        public void SwitchOn(Guid guid)
        {
            this.StartStatus();
        }

        public void SwitchOff()
        {
            ConditionerStatus = DeviceStatus.Off;
            Heat = 0;
            PowerIntensity = 0;
        }

        public void ChangePower(int amount)
        {           
            if (ConditionerStatus == DeviceStatus.On)
                {
                if (amount > 10)
               {
                    PowerIntensity = Math.Min(maxPower, amount);                      
                }
                else if(amount <= 0)
                {
                    PowerIntensity = Math.Max(minPower, amount);
                }
                else
                {
                PowerIntensity = amount;
                }
            }
            else
            {
            throw new ArgumentException("You have to turn it on.");
            }                    
        }

        public void ChangeMode(AcMode mode)
        {
            if (ConditionerStatus == DeviceStatus.On)
            {
                if (mode == AcMode.FAN)
                {
                    Heat = 20;
                    Status = (AcMode)AcMode.FAN;
                }
                else if (mode == AcMode.COOL)
                {
                    Heat = 10;
                    Status = (AcMode)AcMode.COOL;
                }
                else if (mode == AcMode.HEAT)
                {
                    Heat = 30;
                    Status = (AcMode)AcMode.HEAT;
                }
                else if (mode == AcMode.CUSTOM)
                {
                    this.CustomMode();
                }
                else
                {
                    throw new ArgumentException("You havent say any mode , so it still the actual one");
                }
            }
            else
            {
                throw new ArgumentException("You have to turn it on.");
            }
        }

        public void ChangeHeatCustomMode(int heat)
        {            
            if (ConditionerStatus == DeviceStatus.On)
            {
                if (heat > 10)
                {
                    Heat = Math.Min(maxHeat, heat);
                }
                else if (heat <= 0)
                {
                    Heat = Math.Max(minHeat, heat);
                }
                else
                {
                    Heat = heat;
                }
            }
            else
            {
                throw new ArgumentException("You have to turn it on.");
            }
        }      

        public DeviceStatus State()
        {
            return ConditionerStatus;
        }

        public AcMode ModeState()
        {
            return (AcMode)Status;
        }

        private void StartStatus()
        {
            Status = AcMode.FAN;
            Heat = 20;
            PowerIntensity = 5;
            ConditionerStatus = DeviceStatus.On;
        }

        private void CustomMode()
        {
            Status = (AcMode)AcMode.CUSTOM;
            Heat = 25;
        }
    }




}

