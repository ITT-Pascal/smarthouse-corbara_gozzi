using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices
{
    public abstract class AbstractLamp: AbstractDevice, ILamp
    {
        protected const int intensityAtOn = 50;
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
            CheckIsNot(DeviceStatus.Off);
            Intensity += intensityJump;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public virtual void DecreaseBy()
        {
            CheckIsNot(DeviceStatus.Off);
            Intensity -= intensityJump;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public virtual void SetIntensityTo(Intensity intensity)
        {
            CheckIsNot(DeviceStatus.Off);
            Intensity = intensity;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
    }
}
