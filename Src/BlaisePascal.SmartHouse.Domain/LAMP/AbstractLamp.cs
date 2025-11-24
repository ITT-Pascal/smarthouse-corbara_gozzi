using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LAMP
{
    public abstract class AbstractLamp
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public DeviceStatus lampStatus { get; set; }
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
            lampStatus = DeviceStatus.Off;
            ID = new Guid();
            Intensity = 0;
            Name = "Lamp";
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }
        protected AbstractLamp(string name)
        {
            lampStatus = DeviceStatus.Off;
            ID = new Guid();
            Intensity = 0;
            Name = name;
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }
        protected AbstractLamp(string name, Guid guid)
        {
            lampStatus = DeviceStatus.Off;
            ID = guid;
            Intensity = 0;
            Name = name;
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }

        //------METHODS------
        public virtual void SwitchOn()
        {
            lampStatus = DeviceStatus.On;
            Intensity = IntensityAtOn;
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public virtual void SwitchOff()
        {
            lampStatus = DeviceStatus.Off;
            Intensity = 0;
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public virtual void Toggle()
        {
            if (lampStatus == DeviceStatus.On)
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
            Intensity = BrightnessGestor.ValidateNewBrightness(value, Intensity, MaxIntensity);
            LastModifierAtUtc = DateTime.UtcNow;
        }
    }
}
