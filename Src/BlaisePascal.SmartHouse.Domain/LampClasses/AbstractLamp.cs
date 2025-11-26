using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public abstract class AbstractLamp
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public DeviceStatus LampStatus { get; set; }
        public int Intensity { get; set; }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int MaxIntensity { get; set; }
        public int MinIntensity { get; set; }
        public int IntensityAtOn { get; set; }
        public DateTime DateTimeAtCreationUtc { get; set; }
        public DateTime ?LastModifierAtUtc { get; set; }
        public int ValueOfIncreaseAndDescrease { get; set; }

        //------CONSTRUCTORS------
        protected AbstractLamp()
        {
            LampStatus = DeviceStatus.Off;
            ID = new Guid();
            Intensity = 0;
            Name = "Lamp";
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ValueOfIncreaseAndDescrease = 10;
        }
        protected AbstractLamp(string name)
        {
            LampStatus = DeviceStatus.Off;
            ID = new Guid();
            Intensity = 0;
            Name = name;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ValueOfIncreaseAndDescrease = 10;

        }
        protected AbstractLamp(string name, Guid guid)
        {
            LampStatus = DeviceStatus.Off;
            ID = guid;
            Intensity = 0;
            Name = name;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ValueOfIncreaseAndDescrease = 10;

        }
        protected AbstractLamp(string name, Guid guid, int valOfIncreaseAndDecrease)
        {
            LampStatus = DeviceStatus.Off;
            ID = guid;
            Intensity = 0;
            Name = name;
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }

        //------METHODS------
        public virtual void SwitchOn()
        {
            LampStatus = DeviceStatus.On;
            Intensity = IntensityAtOn;
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public virtual void SwitchOff()
        {
            LampStatus = DeviceStatus.Off;
            Intensity = 0;
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public virtual void Toggle()
        {
            if (LampStatus == DeviceStatus.On)
                SwitchOff();

            else
                SwitchOn();
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public virtual void IncreaseBy()
        {
            Intensity = Math.Min(Intensity + ValueOfIncreaseAndDescrease, MaxIntensity);
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public virtual void DecreaseBy()
        {
            Intensity = Math.Max(Intensity - ValueOfIncreaseAndDescrease, MinIntensity);
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public virtual void SetIntensity(int value)
        {
            Intensity = BrightnessGestor.ValidatIntensityBetweenRange(value, MaxIntensity);
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public virtual void ChangeValueOfIncreaseAndDecrease(int val)
        {
            ValueOfIncreaseAndDescrease = BrightnessGestor.ValidatIntensityBetweenRange(val, MaxIntensity);
        }
    }
}
