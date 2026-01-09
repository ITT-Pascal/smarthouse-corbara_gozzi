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
        public Thermostat(Guid Id): base()
        {
            CurrentTemperature = 0;
            TargetTemperature = 20;
            ID = Id;
        }
        public Thermostat(Guid Id, string name): base()
        {
            CurrentTemperature = 0;
            TargetTemperature = 20;
            ID = new Guid();
            Name = name;
        }
        public Thermostat(Guid Id, string name, int targetTemperature):base()
        {
            CurrentTemperature = 0;
            TargetTemperature = targetTemperature;
            ID = new Guid();
            Name = name;
        }
        public Thermostat(int currenteTemperature) : base()
        {
            CurrentTemperature = currenteTemperature;
            TargetTemperature = 20;
            ID = new Guid();
        }
        public sealed override void SwitchOn()
        {
            while (!IsTemperatureEquals())
                AddTemperature();
            SwitchOff();
        }

        public bool IsTemperatureEquals()
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
