using BlaisePascal.SmartHouse.Domain.Abstractions;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public abstract class AbstractLamp: AbstractDevice, ISwitchable, IToggable
    {
        public int minIntensity = 1; //Se private reca errori in lampsrow
        private int intensityAtOff = 0;
        private Intensity valOfIncreaseAndDecrease = new Intensity(10);
        //-------ATTRIBUTES AND PROPERTY-------
        public Intensity Intensity { get; protected set; }
        public Intensity IntensityAtOn = new Intensity(50);

        //------CONSTRUCTORS------
        protected AbstractLamp(): base()
        {
            Intensity = new Intensity(intensityAtOff);
        }
        protected AbstractLamp(string name) : base()
        {
            Name = new Name(name);
            Intensity = new Intensity(intensityAtOff);
        }
        protected AbstractLamp(Guid id) : base(id)
        {
            Intensity = new Intensity(intensityAtOff);
        }
        protected AbstractLamp( Guid guid, string name) : base(guid, name)
        {
            Intensity = new Intensity(intensityAtOff);
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
            Intensity = new Intensity(intensityAtOff);
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
                Intensity = new Intensity(Math.Min(Intensity. + valOfIncreaseAndDecrease, MaxIntensity));
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
