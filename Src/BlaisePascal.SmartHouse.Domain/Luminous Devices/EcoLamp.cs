using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class EcoLamp : AbstractLamp
    {
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;
        private DateTime? autoOffAtUtc;

        //      ------CONSTRUCTORS------
        public EcoLamp() : base()
        {

        }
        public EcoLamp(Guid Id) : base(Id)
        {

        }
        public EcoLamp(Guid id, string name) : base(id, name)
        { 

        }

        //     --------METHODS-------

        //--ON/OFF METHODS--
        
        public void SwitchOn(bool enableAutoOff)
        {
            SwitchOn();
            autoOffAtUtc = enableAutoOff
            ?DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes): null;
        }
        public void SwitchOn(int autoOffMinutes)
        {
            if (autoOffMinutes < MinAutoOffMinutes)
                throw new ArgumentOutOfRangeException(nameof(autoOffMinutes));
            SwitchOn();
            autoOffAtUtc = DateTime.UtcNow.AddMinutes(autoOffMinutes);
        }
        public sealed override void SwitchOff()
        {
            base.SwitchOff();
            autoOffAtUtc = null;
        }
        public void CheckAutoOff()
        {
            CheckIsOn();
            if (autoOffAtUtc.HasValue && DateTime.UtcNow >= autoOffAtUtc.Value)
                SwitchOff();
        }
        private void ResetAutoOffIfNeeded()
        {
            if (autoOffAtUtc.HasValue)
                autoOffAtUtc = DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes);
        }

        //--CHANGER INTENSITY METHODS--

        public sealed override void SetIntensityTo(Intensity intensity)
        {
            base.SetIntensityTo(intensity);
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
    }
}