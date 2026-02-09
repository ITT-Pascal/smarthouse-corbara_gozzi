using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.Thermic
{
    public class Thermostat : AbstractDevice, IToggable, ISwitchable
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
        public Thermostat(Guid Id): base(Id)
        {
            CurrentTemperature = Temperature.NewTemperature(tempAtOn);
            TargetTemperature = Temperature.NewTemperature(defaultTarget);
        }
        public Thermostat(Guid Id, string name): base(Id, name)
        {
            CurrentTemperature = Temperature.NewTemperature(tempAtOn);
            TargetTemperature = Temperature.NewTemperature(defaultTarget);
        }
        public Thermostat(Guid Id, string name, int targetTemperature):base(Id, name)
        {
            CurrentTemperature = Temperature.NewTemperature(tempAtOn);
            TargetTemperature = Temperature.NewTemperature(targetTemperature);
        }

        //        ------METHODS------

        //--ON/OFF METHODS--

        public sealed override void SwitchOn()
        {
            base.SwitchOn();
            EqualsTemperatureTo();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public sealed override void SwitchOff()
        {
            base.SwitchOff();
        }

        //--CHANGER TEMPERATURE METHODS--

        private void EqualsTemperatureTo()
        {
            if (CurrentTemperature.Value > TargetTemperature.Value)
                SwitchOff();
            else
                while (!IsTemperatureEquals())
                    AddTemperature();
        }
        public void ChangeTargetTemperatureTo(int newTemp)
        {
            TargetTemperature = Temperature.NewTemperature(newTemp);
            EqualsTemperatureTo();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        private void AddTemperature()
        {
            CurrentTemperature = Temperature.NewTemperature(CurrentTemperature.Value+tempAdder);
        }

        //--OTHER METHODS--

        public bool IsTemperatureEquals()
        {
            return CurrentTemperature == TargetTemperature;
        }
    }
}
