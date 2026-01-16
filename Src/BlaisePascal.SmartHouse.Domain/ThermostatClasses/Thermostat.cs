using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.ThermostatClasses
{
    public class Thermostat : AbstractDevice
    {
        public float CurrentTemperature { get; private set; }
        public float TargetTemperature { get; private set; }

        public Thermostat():base()
        {
            CurrentTemperature = 0;
            TargetTemperature = 20;
        }
        public Thermostat(Guid Id): base(Id)
        {
            CurrentTemperature = 0;
            TargetTemperature = 20;
        }
        public Thermostat(Guid Id, string name): base(Id, name)
        {
            CurrentTemperature = 0;
            TargetTemperature = 20;
        }
        public Thermostat(Guid Id, string name, int targetTemperature):base(Id, name)
        {
            CurrentTemperature = 0;
            TargetTemperature = targetTemperature;
        }

        public sealed override void SwitchOn()
        {
            while (!IsTemperatureEquals())
                AddTemperature();
            SwitchOff();
            LastModifierAtUtc = DateTime.UtcNow;
        }

        private bool IsTemperatureEquals()
        { 
            return CurrentTemperature == TargetTemperature; 
        }
        private void AddTemperature()
        { 
            CurrentTemperature += 2; 
        }
        public void ChangeTargetTemperature(int temp)
        {
            TargetTemperature = DeviceValidator.ValidateTargetTemperature(temp);
            LastModifierAtUtc = DateTime.UtcNow;
        }
    }
}
