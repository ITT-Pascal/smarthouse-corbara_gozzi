using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public class EcoLamp : AbstractLamp
    {
        private const int maxIntensity = 70;
        private const int intensityAtOn = 30;
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;

        private DateTime? autoOffAtUtc;

        //------CONSTRUCTORS------
        public EcoLamp() : base()
        {
            MaxIntensity = maxIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public EcoLamp(Guid Id) : base(Id)
        {
            MaxIntensity = maxIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public EcoLamp(Guid id, string name):base(id, name)
        {
            MaxIntensity = maxIntensity;
            IntensityAtOn = intensityAtOn;
        }

        //--------METHODS-------
        public void SwitchOn(bool enableAutoOff)
        {
            base.SwitchOn();
            autoOffAtUtc = enableAutoOff
            ?DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes): null;
        }
        public void SwitchOn(int autoOffMinutes)
        {
            if (autoOffMinutes < MinAutoOffMinutes)
                throw new ArgumentOutOfRangeException(nameof(autoOffMinutes));
            base.SwitchOn();
            autoOffAtUtc = DateTime.UtcNow.AddMinutes(autoOffMinutes);
        }

        public sealed override void SetIntensity(int value)
        {
            base.SetIntensity(value);
            ResetAutoOffIfNeeded();
        }
        public sealed override void IncreaseBy()
        {
            base.IncreaseBy();
            ResetAutoOffIfNeeded();
        }
        public sealed override void DecreaseBy()
        {
            base.DecreaseBy();
            ResetAutoOffIfNeeded();
        }
        public sealed override void SwitchOff()
        {
            base.SwitchOff();
            autoOffAtUtc = null;
        }
        public void CheckAutoOff()
        {
            if (DeviceStatus == DeviceStatus.On &&autoOffAtUtc.HasValue && DateTime.UtcNow >= autoOffAtUtc.Value)
                SwitchOff();
        }
        private void ResetAutoOffIfNeeded()
        {
            if (autoOffAtUtc.HasValue)
                autoOffAtUtc = DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes);
        }
    }
}