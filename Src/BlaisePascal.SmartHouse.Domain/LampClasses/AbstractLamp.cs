using BlaisePascal.SmartHouse.Domain.Abstractions;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public abstract class AbstractLamp: AbstractDevice
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public int Intensity { get;  protected set; }
        public int MaxIntensity { get; protected set; }
        public int MinIntensity { get; protected set; }
        public int IntensityAtOn { get; protected set; }
        public int ValueOfIncreaseAndDescrease { get; protected set; }

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
        public sealed override void SwitchOn()
        {
            base.SwitchOn();
            Intensity = IntensityAtOn;
        }
        public sealed override void SwitchOff()
        {
            base.SwitchOff();
            Intensity = 0;
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
