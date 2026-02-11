using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public sealed class EcoLamp : AbstractLamp
    {
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;
        private DateTime? autoOffAtUtc;

        //      ------CONSTRUCTORS------
        public EcoLamp() : base()
        {

        }
        public EcoLamp(Guid id) : base(id)
        {

        }
        public EcoLamp(Guid id, DeviceName name) : base(id, name)
        {

        }

        //     --------METHODS-------

        //--ON/OFF METHODS--

        public sealed override void SwitchOn(bool enableAutoOff)
        {
            SwitchOn();
            autoOffAtUtc = enableAutoOff
            ? DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes) : null;
        }
        public sealed override void SwitchOn(int autoOffMinutes)
        {
            if (autoOffMinutes < MinAutoOffMinutes)
                throw new ArgumentOutOfRangeException(nameof(autoOffMinutes));
            SwitchOn();
            autoOffAtUtc = DateTime.UtcNow.AddMinutes(autoOffMinutes);
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            autoOffAtUtc = null;
        }
        public void CheckAutoOff()
        {
            CheckStatusWith(DeviceStatus.On);
            if (autoOffAtUtc.HasValue && DateTime.UtcNow >= autoOffAtUtc.Value)
                SwitchOff();
        }
        private void ResetAutoOffIfNeeded()
        {
            if (autoOffAtUtc.HasValue)
                autoOffAtUtc = DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes);
        }

        //--CHANGER INTENSITY METHODS--

        public override void SetIntensityTo(Intensity intensity)
        {
            base.SetIntensityTo(intensity);
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
    }
}