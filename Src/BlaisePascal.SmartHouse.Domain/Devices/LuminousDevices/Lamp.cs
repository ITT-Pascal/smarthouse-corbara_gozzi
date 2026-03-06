using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices
{
    public class Lamp: AbstractDevice, ILamp
    {
        private const int intensityJump = 10;

        //  -------ATTRIBUTES AND PROPERTY-------

        public Intensity Intensity { get; protected set; }
        
        //      ------CONSTRUCTORS------
        public Lamp(): base()
        {
            Intensity = Intensity.NewMinIntensity();
        }
        public Lamp(Guid id) : base(id)
        {
            Intensity = Intensity.NewMinIntensity();
        }
        public Lamp( Guid id, DeviceName name) : base(id, name)
        {
            Intensity = Intensity.NewMinIntensity();
        }
        public Lamp (Guid id, DeviceName name, DeviceStatus status, Intensity intensity, DateTime dateTimeCreation, DateTime lastModifier): base(id, name)
        {
            DeviceStatus = status;
            Intensity = intensity;
            DateTimeAtCreationUtc = dateTimeCreation;
            LastModifierAtUtc = lastModifier;
        }

        //     ------METHODS------

        //--ON/OFF METHODS--

        public override void SwitchOn()
        {
            base.SwitchOn();
            Intensity = Intensity.NewHalfIntensity();
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            Intensity = Intensity.NewMinIntensity();
        }
        public virtual void Toggle()
        {
            if (DeviceStatus == DeviceStatus.On)
                SwitchOff();
            else
                SwitchOn();
            LastModifierAtUtc = DateTime.Now;
        }

        //--CHANGER INTENSITY METHODS--

        public virtual void IncreaseBy()
        {
            CheckIsNot(DeviceStatus.Off);
            Intensity += intensityJump;
            LastModifierAtUtc = DateTime.Now;
        }
        public virtual void DecreaseBy()
        {
            CheckIsNot(DeviceStatus.Off);
            Intensity -= intensityJump;
            LastModifierAtUtc = DateTime.Now;
        }
        public virtual void SetIntensityTo(Intensity intensity)
        {
            CheckIsNot(DeviceStatus.Off);
            Intensity = intensity;
            LastModifierAtUtc = DateTime.Now;
        }
    }
}
