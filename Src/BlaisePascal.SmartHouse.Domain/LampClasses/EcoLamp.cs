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
        private const int minIntensity = 1;
        private const int intensityAtOn = 30;
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;

        private DateTime? autoOffAtUtc;

        //------CONSTRUCTORS------
        public EcoLamp(string name) : base(name)
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public EcoLamp()
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public EcoLamp(string name, Guid id):base(name,id)
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public EcoLamp(string name, Guid id, int valueOfIncreaseAndDecrease):base(name, id, valueOfIncreaseAndDecrease)
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }

        public override void SwitchOn()
        {
            base.SwitchOn();
        }
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

        public override void SetIntensity(int value)
        {
            base.SetIntensity(value);
            ResetAutoOffIfNeeded();
        }
        public override void IncreaseBy()
        {
            base.IncreaseBy();
            ResetAutoOffIfNeeded();
        }
        public override void DecreaseBy()
        {
            base.DecreaseBy();
            ResetAutoOffIfNeeded();
        }
        public override void SwitchOff()
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