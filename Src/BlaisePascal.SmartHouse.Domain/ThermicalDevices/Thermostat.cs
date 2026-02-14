using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.ThermicalDevices
{
    public sealed class Thermostat : AbstractDevice, ISwitchable
    {
        private const int tempAtOn = 0;
        private const int defaultTarget = 20;
        private const int tempAdder = 2;

        //     -------ATTRIBUTES AND PROPERTY-------
        public Temperature CurrentTemperature { get; private set; }
        public Temperature TargetTemperature { get; private set; }

        //         ------CONSTRUCTORS------
        public Thermostat():base()
        {
            CurrentTemperature = Temperature.NewTemperature(tempAtOn);
            TargetTemperature = Temperature.NewTemperature(defaultTarget);
        }
        public Thermostat(Guid id): base(id)
        {
            CurrentTemperature = Temperature.NewTemperature(tempAtOn);
            TargetTemperature = Temperature.NewTemperature(defaultTarget);
        }
        public Thermostat(Guid id, DeviceName name): base(id, name)
        {
            CurrentTemperature = Temperature.NewTemperature(tempAtOn);
            TargetTemperature = Temperature.NewTemperature(defaultTarget);
        }
        public Thermostat(Guid id, DeviceName name, Temperature targetTemperature):base(id, name)
        {
            CurrentTemperature = Temperature.NewTemperature(tempAtOn);
            TargetTemperature = targetTemperature;
            AirConditioner cond = new();
        }
       
        //        ------METHODS------

        //--ON/OFF METHODS--

        public override void SwitchOn()
        {
            base.SwitchOn();
            EqualsTemperatureToTarget();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
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
            TargetTemperature = newTemp;
            EqualsTemperatureToTarget();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        private void AddTemperature()
        {
            CurrentTemperature = Temperature.NewTemperature(CurrentTemperature.Heat+tempAdder);
        }

        //--OTHER METHODS--

        public bool IsTemperatureEquals()
        {
            return CurrentTemperature == TargetTemperature;
        }
    }
}
