using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices
{
    public sealed class Thermostat : AbstractDevice, ISwitchable
    {
        private const int defaultTarget = 20;
        private const int tempAdder = 1;

        //     -------ATTRIBUTES AND PROPERTY-------
        public Temperature CurrentTemperature { get; private set; }
        public Temperature TargetTemperature { get; private set; }

        //         ------CONSTRUCTORS------
        public Thermostat():base()
        {
            CurrentTemperature = Temperature.NewZeroTemperature();
            TargetTemperature = Temperature.NewTemperature(defaultTarget);
        }
        public Thermostat(Guid id): base(id)
        {
            CurrentTemperature = Temperature.NewZeroTemperature();
            TargetTemperature = Temperature.NewTemperature(defaultTarget);
        }
        public Thermostat(Guid id, DeviceName name): base(id, name)
        {
            CurrentTemperature = Temperature.NewZeroTemperature();
            TargetTemperature = Temperature.NewTemperature(defaultTarget);
        }
        public Thermostat(Guid id, DeviceName name, Temperature targetTemperature):base(id, name)
        {
            CurrentTemperature = Temperature.NewZeroTemperature();
            TargetTemperature = targetTemperature;
        }

        public Thermostat(Guid id, DeviceName name, DeviceStatus deviceStatus, Temperature currentTemperature, Temperature targetTemperature, DateTime dateTimeAtCreationUtc, DateTime lastModifierAtUtc) : this(id, name, targetTemperature)
        {
            DeviceStatus = deviceStatus;
            CurrentTemperature = currentTemperature;
            TargetTemperature = targetTemperature;
            DateTimeAtCreationUtc = dateTimeAtCreationUtc;
            LastModifierAtUtc = lastModifierAtUtc;
        }

        //        ------METHODS------

        //--ON/OFF METHODS--

        public override void SwitchOn()
        {
            base.SwitchOn();
            EqualsTemperatureToTarget();
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
        }

        //--CHANGER TEMPERATURE METHODS--

        private void EqualsTemperatureToTarget()
        {
            if (CurrentTemperature.Heat > TargetTemperature.Heat)
                SwitchOff();
            else
                while (!IsTemperatureEquals())
                    AddTemperature();
        }
        public void ChangeTargetTemperatureTo(Temperature newTemp)
        {
            CheckIsNot(DeviceStatus.Off);
            TargetTemperature = newTemp;
            EqualsTemperatureToTarget();
            LastModifierAtUtc = DateTime.Now;
        }
        private void AddTemperature()
        {
            CurrentTemperature = Temperature.NewTemperature(CurrentTemperature.Heat + tempAdder);
        }

        //--OTHER METHODS--

        public bool IsTemperatureEquals()
        {
            return CurrentTemperature.Heat == TargetTemperature.Heat;
        }
    }
}
