using BlaisePascal.SmartHouse.Domain.Abstractions;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public abstract class AbstractLamp: AbstractDevice
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public int Intensity { get; set; }
        public int MaxIntensity { get; set; }
        public int MinIntensity { get; set; }
        public int IntensityAtOn { get; set; }
        public int ValueOfIncreaseAndDescrease { get; set; }

        //------CONSTRUCTORS------
        protected AbstractLamp(): base()
        {
            ID = new Guid();
            Intensity = 0;
            Name = "Lamp";
            ValueOfIncreaseAndDescrease = 10;
        }
        protected AbstractLamp(string name) : base()
        {
            ID = new Guid();
            Intensity = 0;
            Name = name;
            ValueOfIncreaseAndDescrease = 10;
        }
        protected AbstractLamp(string name, Guid guid) : base()
        {
            ID = guid;
            Intensity = 0;
            Name = name;
            ValueOfIncreaseAndDescrease = 10;
        }
        protected AbstractLamp(string name, Guid guid, int valOfIncreaseAndDecrease) : base()
        {
            ID = guid;
            Intensity = 0;
            Name = name;
        }

        //------METHODS------
        public override void SwitchOn()
        {
            DeviceStatus = DeviceStatus.On;
            Intensity = IntensityAtOn;
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public override void SwitchOff()
        {
            DeviceStatus = DeviceStatus.Off;
            Intensity = 0;
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public virtual void Toggle()
        {
            if (DeviceStatus == DeviceStatus.On)
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
