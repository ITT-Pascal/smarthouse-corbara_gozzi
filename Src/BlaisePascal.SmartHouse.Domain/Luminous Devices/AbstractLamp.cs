using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Luminous_Devices;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public abstract class AbstractLamp: AbstractDevice, ILamp
    {
        private const int intensityAtOn = 50;
        private const int intensityJump = 10;

        //  -------ATTRIBUTES AND PROPERTY-------

        public Intensity Intensity { get; protected set; }
        
        //      ------CONSTRUCTORS------
        protected AbstractLamp(): base()
        {
            Intensity = Intensity.NewIntensity(Intensity.minPercentage);
        }
        protected AbstractLamp(Guid id) : base(id)
        {
            Intensity = Intensity.NewIntensity(Intensity.minPercentage);
        }
        protected AbstractLamp( Guid id, DeviceName name) : base(id, name)
        {
            Intensity = Intensity.NewIntensity(Intensity.minPercentage);
        }

        //     ------METHODS------

        //--ON/OFF METHODS--

        public override void SwitchOn()
        {
            base.SwitchOn();
            Intensity = Intensity.NewIntensity(intensityAtOn);
        }
        public virtual void SwitchOn(bool enableAutoOff)
        {
            base.SwitchOn();
        }
        public virtual void SwitchOn(int autoOffMinutes)
        {
            base.SwitchOn();
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            Intensity = Intensity.NewIntensity(Intensity.minPercentage);
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

        //--CHANGER INTENSITY METHODS--

        public virtual void IncreaseBy()
        {
            CheckStatusWith(DeviceStatus.On);
            Intensity = Intensity.NewIntensity(Intensity.Value + intensityJump);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public virtual void DecreaseBy()
        {
            CheckStatusWith(DeviceStatus.On);
            Intensity = Intensity.NewIntensity(Intensity.Value - intensityJump);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public virtual void SetIntensityTo(Intensity intensity)
        {
            CheckStatusWith(DeviceStatus.On);
            Intensity = intensity;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
    }
}
