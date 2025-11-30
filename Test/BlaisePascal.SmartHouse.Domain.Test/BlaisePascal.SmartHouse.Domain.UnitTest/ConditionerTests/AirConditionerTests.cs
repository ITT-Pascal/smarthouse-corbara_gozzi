using BlaisePascal.SmartHouse.Domain.ConditionerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.AirConditionerTest
{
    public class AirConditionersTest
    {
        AirConditioner cond = new AirConditioner();

        [Fact]
        public void AirConditioner_SwitchOn_ItTurnOnAndHeatIs20AndPower5()
        {
            cond.SwitchOn();
            Assert.Equal(DeviceStatus.On, cond.DeviceStatus);
            Assert.Equal(20, cond.Heat);
            Assert.Equal(5, cond.PowerIntensity);
            Assert.Equal(AcMode.FAN, cond.ModeOfAc);
        }

        [Fact]
        public void AirConditioner_SwitchOff_ItTurnOff()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            Assert.Equal(DeviceStatus.Off, cond.DeviceStatus);
            Assert.Equal(0, cond.Heat);
            Assert.Equal(0, cond.PowerIntensity);
        }

        [Fact]
        public void AirConditioner_ChangePower_ItIncrease()
        {
            cond.SwitchOn();
            cond.ChangePower(7);
            Assert.Equal(7, cond.PowerIntensity);
        }

        [Fact]
        public void AirConditioner_ChangePower_ItIncreaseAtMin()
        {
            cond.SwitchOn();
            cond.ChangePower(-100);
            Assert.Equal(1, cond.PowerIntensity);
        }

        [Fact]
        public void AirConditioner_ChangePower_ItIncreaseAtMax()
        {
            cond.SwitchOn();
            cond.ChangePower(100);
            Assert.Equal(10, cond.PowerIntensity);
        }

        [Fact]
        public void AirConditioner_ChangeMode_ItBecameCool()
        {
            cond.SwitchOn();
            cond.ChangeMode(AcMode.COOL);
            Assert.Equal(AcMode.COOL, cond.ModeOfAc);
            Assert.Equal(10, cond.Heat);
        }

        [Fact]
        public void AirConditioner_ChangeMode_ItBecameHeat()
        {
            cond.SwitchOn();
            cond.ChangeMode(AcMode.HEAT);
            Assert.Equal(AcMode.HEAT, cond.ModeOfAc);
            Assert.Equal(30, cond.Heat);
        }

        [Fact]
        public void AirConditioner_ChangeMode_ItBecameCustom()
        {
            cond.SwitchOn();
            cond.ChangeMode(AcMode.CUSTOM);
            Assert.Equal(AcMode.CUSTOM, cond.ModeOfAc);
        }

        [Fact]
        public void AirConditioner_ChangeHeatCustomMode_ItChange()
        {
            cond.SwitchOn();
            cond.ChangeMode(AcMode.CUSTOM);
            cond.ChangeHeatCustomMode(10);
            Assert.Equal(10, cond.Heat);
        }

        [Fact]
        public void AirConditioner_ChangeHeatCustomMode_ItChangeAtMin()
        {
            cond.SwitchOn();
            cond.ChangeMode(AcMode.CUSTOM);
            cond.ChangeHeatCustomMode(-110);
            Assert.Equal(5, cond.Heat);
        }

        [Fact]
        public void AirConditioner_ChangeHeatCustomMode_ItChangeAtMax()
        {
            cond.SwitchOn();
            cond.ChangeMode(AcMode.CUSTOM);
            cond.ChangeHeatCustomMode(1000);
            Assert.Equal(45, cond.Heat);
        }
    }
}
