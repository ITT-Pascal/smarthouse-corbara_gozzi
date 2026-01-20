using BlaisePascal.SmartHouse.Domain.Abstractions;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public abstract class AbstractLamp: AbstractDevice, ISwitchable, IToggable
    {
        private int minIntensity = 1;
        private int intensityAtOff = 0;
        private int valOfIncreaseAndDecrease = 10;
        //-------ATTRIBUTES AND PROPERTY-------
        public int Intensity { get;  protected set; }
        public int MaxIntensity;
        public int IntensityAtOn;

        //------CONSTRUCTORS------
        protected AbstractLamp(): base()
        {
            Intensity = intensityAtOff;
        }
        protected AbstractLamp(string name) : base()
        {
            Name = name;
            Intensity = intensityAtOff;
        }
        protected AbstractLamp(Guid id) : base(id)
        {
            Intensity = intensityAtOff;
        }
        protected AbstractLamp( Guid guid, string name) : base(guid, name)
        {
            Intensity = intensityAtOff;
        }

        //------METHODS------
        public sealed override void SwitchOn()
        {
            base.SwitchOn();
            Intensity = IntensityAtOn;
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            Intensity = intensityAtOff;
        }
        public virtual void Toggle()
        {
            if (DeviceStatus == DeviceStatus.On)
                SwitchOff();
            else
                SwitchOn();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public virtual void IncreaseBy()
        {
            if (DeviceStatus == DeviceStatus.On)
            {
                Intensity = Math.Min(Intensity + valOfIncreaseAndDecrease, MaxIntensity);
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfMod.Add(DateTime.UtcNow);
            }
        }
        public virtual void DecreaseBy()
        {
            if (DeviceStatus == DeviceStatus.On)
            {
                Intensity = Math.Max(Intensity - valOfIncreaseAndDecrease, minIntensity);
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfMod.Add(DateTime.UtcNow);
            }
        }
        public virtual void SetIntensity(int value)
        {
            if (DeviceStatus == DeviceStatus.On)
            {
                Intensity = DeviceValidator.ValidateNewIntensity(value, MaxIntensity);
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfMod.Add(DateTime.UtcNow);
            }
        }
    }
}
