using BlaisePascal.SmartHouse.Domain.Abstractions;
using System.Reflection.Metadata.Ecma335;
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
            ValueOfIncreaseAndDescrease = valOfIncreaseAndDecrease;
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
            if (DeviceStatus == DeviceStatus.On)
            {
                Intensity = Math.Min(Intensity + ValueOfIncreaseAndDescrease, MaxIntensity);
                LastModifierAtUtc = DateTime.UtcNow;
            }
        }
        public virtual void DecreaseBy()
        {
            if (DeviceStatus == DeviceStatus.On)
            {
                Intensity = Math.Max(Intensity - ValueOfIncreaseAndDescrease, MinIntensity);
                LastModifierAtUtc = DateTime.UtcNow;
            }
        }
        public virtual void SetIntensity(int value)
        {
            if (DeviceStatus == DeviceStatus.On)
            {
                Intensity = DeviceValidator.ValidateIntensityBetweenRange(value, MaxIntensity);
                LastModifierAtUtc = DateTime.UtcNow;
            }
        }
        public virtual void ChangeValueOfIncreaseAndDecrease(int newVal)
        {
            ValueOfIncreaseAndDescrease = ReturnValidation(newVal);
        }
        protected int ReturnValidation(int val) { return DeviceValidator.ValidateIntensityBetweenRange(val, MaxIntensity); }
    }
}
