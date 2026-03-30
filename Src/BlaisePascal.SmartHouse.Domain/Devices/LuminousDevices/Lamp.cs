using System.Runtime.CompilerServices;
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

        public void SwitchOn()
        {
            if (DeviceStatus == DeviceStatus.On)
                return;
            DeviceStatus = DeviceStatus.On;
            LastModifierAtUtc = DateTime.Now;
            Intensity = Intensity.NewHalfIntensity();
        }
        public virtual void SwitchOff()
        {
            if (DeviceStatus == DeviceStatus.Off)
                return;
            DeviceStatus = DeviceStatus.Off;
            LastModifierAtUtc = DateTime.Now;
            Intensity = Intensity.NewMinIntensity();
        }
        public override void Toggle()
        {
            CheckIsNot(DeviceStatus.Error);
            if (DeviceStatus == DeviceStatus.On)
                DeviceStatus = DeviceStatus.Off;
            else
                DeviceStatus = DeviceStatus.On;
            LastModifierAtUtc = DateTime.Now;
        }

        //--CHANGER INTENSITY METHODS--

        public virtual void IncreaseBy()
        {
            CheckIsNot(DeviceStatus.Off);
            CheckIsNot(DeviceStatus.Error);
            Intensity += intensityJump;
            LastModifierAtUtc = DateTime.Now;
        }
        public virtual void DecreaseBy()
        {
            CheckIsNot(DeviceStatus.Off);
            CheckIsNot(DeviceStatus.Error);
            Intensity -= intensityJump;
            LastModifierAtUtc = DateTime.Now;
        }
        public virtual void SetIntensityTo(Intensity intensity)
        {
            CheckIsNot(DeviceStatus.Off);
            CheckIsNot(DeviceStatus.Error);
            Intensity = intensity;
            LastModifierAtUtc = DateTime.Now;
        }
    }
}
