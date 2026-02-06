using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.Thermic
{
    public class Thermostat : AbstractDevice, IToggable
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
            CurrentTemperature = new Temperature(tempAtOn);
            TargetTemperature = new Temperature(defaultTarget);
        }
        public Thermostat(Guid Id): base(Id)
        {
            CurrentTemperature = new Temperature(tempAtOn);
            TargetTemperature = new Temperature(defaultTarget);
        }
        public Thermostat(Guid Id, string name): base(Id, name)
        {
            CurrentTemperature = new Temperature(tempAtOn);
            TargetTemperature = new Temperature(defaultTarget);
        }
        public Thermostat(Guid Id, string name, int targetTemperature):base(Id, name)
        {
            CurrentTemperature = new Temperature(tempAtOn);
            TargetTemperature = new Temperature(defaultTarget);
        }

        //        ------METHODS------

        //--ON/OFF METHODS--

        public sealed override void SwitchOn()
        {
            while (!IsTemperatureEquals())
                AddTemperature();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public sealed override void SwitchOff()
        {
            base.SwitchOff();
        }
        public void Toggle()
        {
            if (DeviceStatus == DeviceStatus.On)
                SwitchOff();
            else
                SwitchOn();
        }

        //--CHANGER TEMPERATURE METHODS--

        public void ChangeTargetTemperatureTo(Temperature newTemp)
        {
            TargetTemperature = newTemp;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        private void AddTemperature()
        {
            CurrentTemperature = new Temperature(CurrentTemperature.Value+tempAdder);
        }

        //--OTHER METHODS--

        public bool IsTemperatureEquals()
        {
            return CurrentTemperature == TargetTemperature;
        }
        public void ReturnAllModifiesOfDevice() => ReturnAllModifiesOfDevice(this);
    }
}
