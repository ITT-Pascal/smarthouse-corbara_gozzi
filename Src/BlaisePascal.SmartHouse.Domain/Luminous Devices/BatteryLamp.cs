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
    public sealed class BatteryLamp: Lamp
    {
        private const int batteryChargeAtCreation = 50;
        private const int DischargeCoefficientVal = 6;
        private const int RechargeCoefficientVal = 2;
        //    -------ATTRIBUTES AND PROPERTY-------

        public Charge BatteryCharge { get; private set; }

        private int TimeOfUseInMin;
        private int TimeOfChargeInMin;
        private DateTime SwitchOnTime;
        private DateTime StartedChargeTime;

        //        ------CONSTRUCTORS------
        public BatteryLamp() : base()
        {
            BatteryCharge = Charge.NewChargeLevel(batteryChargeAtCreation);
        }
        public BatteryLamp(Guid Id) : base(Id)
        {
            BatteryCharge = Charge.NewChargeLevel(batteryChargeAtCreation);
        }
        public BatteryLamp(Guid Id, string name) : base(Id, name)
        {
            BatteryCharge = Charge.NewChargeLevel(batteryChargeAtCreation);
        }

        //        -----METHODS-----

        /// <summary>
        /// metodo per controllare che la lampada non sia scarica
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void IsNotOutOfCharge()
        {
            if (BatteryCharge.Value == BatteryCharge.MinCharge)
                throw new Exception("Battery is dead, charge it");
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
            DecreaseBatteryCharge();
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

        private void IncreaseBatteryCharge()
        {
            BatteryCharge = Charge.NewChargeLevel(BatteryCharge.Value + TimeOfChargeInMin / RechargeCoefficientVal);
        }
        private void DecreaseBatteryCharge()
        {
            BatteryCharge = Charge.NewChargeLevel(BatteryCharge.Value - TimeOfUseInMin / DischargeCoefficientVal);
        }
        public void PlugLamp()
        {
            if (DeviceStatus != DeviceStatus.Off)
                throw new Exception("You need to switch off to charge lamp");
            StartedChargeTime = DateTime.UtcNow;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void UnplugLamp()
        {
            TimeOfChargeInMin = DateTime.UtcNow.Minute - StartedChargeTime.Minute;
            IncreaseBatteryCharge();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
    }
}
