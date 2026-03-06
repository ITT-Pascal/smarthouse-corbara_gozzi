using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices
{
    public sealed class EcoLamp : Lamp
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

        public void SwitchOn(bool enableAutoOff)
        {
            SwitchOn();
            autoOffAtUtc = enableAutoOff
            ? DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes) : null;
        }
        public void SwitchOn(int autoOffMinutes)
        {
            if (autoOffMinutes < MinAutoOffMinutes)
            {
                DeviceStatus = DeviceStatus.Error;
                throw new ArgumentOutOfRangeException(nameof(autoOffMinutes));
            }   
            SwitchOn();
            autoOffAtUtc = DateTime.Now.AddMinutes(autoOffMinutes);
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            autoOffAtUtc = null;
        }
        public void CheckAutoOff()
        {
            CheckIsNot(DeviceStatus.Off);
            if (autoOffAtUtc.HasValue && DateTime.Now >= autoOffAtUtc.Value)
                SwitchOff();
        }
        private void ResetAutoOffIfNeeded()
        {
            if (autoOffAtUtc.HasValue)
                autoOffAtUtc = DateTime.Now.AddMinutes(DefaultAutoOffMinutes);
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