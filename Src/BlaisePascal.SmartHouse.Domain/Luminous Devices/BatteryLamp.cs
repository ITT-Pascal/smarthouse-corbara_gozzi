using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Luminous;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.Luminous_Devices
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
        private DateTime SwitchOnTime;
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
                throw new Exception($"Battery[{LampBattery.ChargeValue}]: LampBattery is out of charge");
            SwitchOff();
        }

        //--ON/OFF METHODS--
        public override void SwitchOn()
        {
            IsNotOutOfCharge();
            base.SwitchOn();
            SwitchOnTime = DateTime.UtcNow;
        }
        public override void SwitchOff()
        {
            TimeOfUseInMin = DateTime.UtcNow.Minute - SwitchOnTime.Minute;
            DecreaseLampBattery();
            base.SwitchOff();
        }
        public override void Toggle()
        {
            IsNotOutOfCharge();
            base.Toggle();
        }

        //--CHANGER INTENSITY METHODS--

        public override void IncreaseBy()
        {
            IsNotOutOfCharge();
            base.IncreaseBy();
        }
        public override void DecreaseBy()
        {
            IsNotOutOfCharge();
            base.DecreaseBy();
        }
        public override void SetIntensityTo(Intensity intensity)
        {
            IsNotOutOfCharge();
            base.SetIntensityTo(intensity);
        }

        //--CHANGER CHARGE--

        private void IncreaseLampBattery()
        {
            LampBattery = Battery.NewChargeLevel(LampBattery.ChargeValue + TimeOfChargeInMin / rechargeCoefficientVal);
        }
        private void DecreaseLampBattery()
        {
            LampBattery = Battery.NewChargeLevel(LampBattery.ChargeValue - TimeOfUseInMin / dischargeCoefficientVal);
        }
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
            IncreaseLampBattery();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
    }
}
