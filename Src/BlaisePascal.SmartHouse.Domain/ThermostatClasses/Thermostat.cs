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
        public float CurrentTemperature { get; set; }
        public float TargetTemperature { get; set; }

        public Thermostat()
        {

        }
        public Thermostat(Guid Id)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            CurrentTemperature = 0;
            TargetTemperature = 20;
            ID = Id;
        }
        public Thermostat(Guid Id, string name)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            CurrentTemperature = 0;
            TargetTemperature = 20;
            ID = new Guid();
            Name = name;
        }
        public Thermostat(Guid Id, string name, int targetTemperature)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            CurrentTemperature = 0;
            TargetTemperature = targetTemperature;
            ID = new Guid();
            Name = name;
        }
        public override void SwitchOn()
        {
            while (!IsTemperatureEquals())
                AddTemperature();
            SwitchOff();
        }
        public bool IsTemperatureEquals(){ return CurrentTemperature == TargetTemperature; }
        private void AddTemperature(){ CurrentTemperature += 2; }
        public void ChangeTargetTemperature(int temp)
        {
            TargetTemperature = DeviceManager.ValidateTargetTemperature(temp);
            LastModifierAtUtc = DateTime.UtcNow;
        }
    }
}
