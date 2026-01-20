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
        private const int tempAtOn = 0;
        private const int defaultTarget = 2;

        //-------ATTRIBUTES AND PROPERTY-------
        public float CurrentTemperature { get; private set; }
        public float TargetTemperature { get; private set; }

        //------CONSTRUCTORS------
        public Thermostat():base()
        {
            CurrentTemperature = tempAtOn;
            TargetTemperature = defaultTarget;
        }
        public Thermostat(Guid Id): base(Id)
        {
            CurrentTemperature = tempAtOn;
            TargetTemperature = defaultTarget;
        }
        public Thermostat(Guid Id, string name): base(Id, name)
        {
            CurrentTemperature = tempAtOn;
            TargetTemperature = defaultTarget;
        }
        public Thermostat(Guid Id, string name, int targetTemperature):base(Id, name)
        {
            CurrentTemperature = tempAtOn;
            TargetTemperature = targetTemperature;
        }
        
        //------METHODS------
        public sealed override void SwitchOn()
        {
            while (!IsTemperatureEquals())
                AddTemperature();
            SwitchOff();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
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
            HistoryOfMod.Add(DateTime.UtcNow);
        }
    }
}
