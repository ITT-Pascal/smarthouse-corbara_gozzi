using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices
{
    public sealed class BatteryLamp: AbstractLamp
    {
        private const int batteryChargeAtCreation = 50;
        private const int dischargeCoefficientVal = 6;
        private const int rechargeCoefficientVal = 2;
        //    -------ATTRIBUTES AND PROPERTY-------

        public Battery LampBattery { get; private set; }

        private int TimeOfUseInMin;
        private int TimeOfChargeInMin;
        private DateTime LastActionTime;
        private DateTime ChargeStarterTime;

        //        ------CONSTRUCTORS------
        public BatteryLamp() : base()
        {
            LampBattery = Battery.NewChargeLevel(batteryChargeAtCreation);
        }
        public BatteryLamp(Guid id) : base(id)
        {
            LampBattery = Battery.NewChargeLevel(batteryChargeAtCreation);
        }
        public BatteryLamp(Guid id, DeviceName name) : base(id, name)
        {
            LampBattery = Battery.NewChargeLevel(batteryChargeAtCreation);
        }

        //        -----METHODS-----

        /// <summary>
        /// metodo per controllare che la lampada non sia scarica
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void IsNotOutOfCharge()
        {
            if (LampBattery.ChargeValue == Battery.minPercentage)
                SwitchOff();
            throw new Exception($"Battery[{LampBattery.ChargeValue}]: LampBattery is out of charge");
        }

        //--ON/OFF METHODS--
        public override void SwitchOn()
        {
            IsNotOutOfCharge();
            base.SwitchOn();
            LastActionTime = DateTime.UtcNow;
        }
        public override void SwitchOff()
        {
            TimeOfUseInMin = DateTime.UtcNow.Minute - LastActionTime.Minute;
            LampBattery -= (uint)(TimeOfUseInMin / dischargeCoefficientVal);
            base.SwitchOff();
        }
        public override void Toggle()
        {
            IsNotOutOfCharge();
            base.Toggle();
            TimeOfUseInMin = DateTime.UtcNow.Minute - LastActionTime.Minute;
            LampBattery -= (uint)(TimeOfUseInMin / dischargeCoefficientVal);
            LastActionTime = DateTime.UtcNow;
        }

        //--CHANGER INTENSITY METHODS--

        public override void IncreaseBy()
        {
            IsNotOutOfCharge();
            base.IncreaseBy();
            TimeOfUseInMin = DateTime.UtcNow.Minute - LastActionTime.Minute;
            LampBattery -= (uint)(TimeOfUseInMin / dischargeCoefficientVal);
            LastActionTime = DateTime.UtcNow;
        }
        public override void DecreaseBy()
        {
            IsNotOutOfCharge();
            base.DecreaseBy();
            TimeOfUseInMin = DateTime.UtcNow.Minute - LastActionTime.Minute;
            LampBattery -= (uint)(TimeOfUseInMin / dischargeCoefficientVal);
            LastActionTime = DateTime.UtcNow;
        }
        public override void SetIntensityTo(Intensity intensity)
        {
            IsNotOutOfCharge();
            base.SetIntensityTo(intensity);
            TimeOfUseInMin = DateTime.UtcNow.Minute - LastActionTime.Minute;
            LampBattery -= (uint)(TimeOfUseInMin / dischargeCoefficientVal);
            LastActionTime = DateTime.UtcNow;
        }

        //--CHANGER CHARGE--
        public void PlugLamp()
        {
            if (DeviceStatus != DeviceStatus.Off)
                throw new Exception($"Status[{DeviceStatus}]: You need to switch off to charge lamp");
            ChargeStarterTime = DateTime.UtcNow;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void UnplugLamp()
        {
            TimeOfChargeInMin = DateTime.UtcNow.Minute - ChargeStarterTime.Minute;
            LampBattery += (uint)(TimeOfChargeInMin / rechargeCoefficientVal);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
    }
}
