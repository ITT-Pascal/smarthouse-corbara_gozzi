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
        public void AirConditioner_Constructor_WhenCreatedHeatAndSpeedAre0()
        {
            Assert.Equal(0, cond.Speed);
            Assert.Equal(0, cond.Heat);
            Assert.Equal(DeviceStatus.Off , cond.DeviceStatus);
        }

        [Fact]
        public void AirConditioner_SwitchOff_TurnedOnAndOff()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            Assert.Equal(0, cond.Speed);
            Assert.Equal(0, cond.Heat);
            Assert.Equal(DeviceStatus.Off, cond.DeviceStatus);
        }  

        [Fact]
        public void AirConditioner_Toggle_IfOnItTurnOff()
        {
            cond.SwitchOn();
            cond.Toggle();
            Assert.Equal(DeviceStatus.Off , cond.DeviceStatus);
        }

        [Fact]
        public void AirConditioner_Toggle_IfOffAndToggleItBecameOn()
        {
            cond.Toggle();
            Assert.Equal(DeviceStatus.On, cond.DeviceStatus);
        }

        [Fact]
        public void AirConditioner_Toggle_IfDoubleToggleReturnOff()
        {
            cond.Toggle();
            cond.Toggle();
            Assert.Equal(DeviceStatus.Off, cond.DeviceStatus);
        }

        [Fact]
        public void AirConditioner_SwitchOn_TurnedOnModeIsCoolAndHeatIs10()
        {
            cond.SwitchOn();
            Assert.Equal(AcMode.Cool, cond.ModeOfAc);
            Assert.Equal(10, cond.Heat);
            Assert.Equal(0, cond.Speed);

            Assert.Equal(DeviceStatus.On, cond.DeviceStatus);
        }

        [Fact]
        public void AirConditioner_ChangeMode_WhenOffItGaveError()
        {
            cond.SwitchOff();
            cond.ChangeMode(AcMode.Cool);
            Assert.Throws<ArgumentException>(() => "You have to turn it on.");
        }

        [Fact]
        public void AirConditioner_ChangeMode_IfIPutTheSameItRemainThatMode()
        {
            cond.SwitchOn();
            cond.ChangeMode(AcMode.Cool);
            Assert.Equal(AcMode.Cool, cond.ModeOfAc);
            Assert.Equal(10, cond.Heat);
            Assert.Equal(0, cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeMode_ToHeatTheHeatIs30()
        {
            cond.SwitchOn();
            cond.ChangeMode(AcMode.Heat);
            Assert.Equal(AcMode.Heat, cond.ModeOfAc);
            Assert.Equal(30, cond.Heat);
            Assert.Equal(0, cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeMode_ToDryTheHeatIs0()
        {
            cond.SwitchOn();
            cond.ChangeMode(AcMode.Dry);
            Assert.Equal(AcMode.Dry, cond.ModeOfAc);
            Assert.Equal(0, cond.Heat);
            Assert.Equal(0, cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeSpeed_IfOffItGivesError()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            cond.ChangeSpeed(10);
            Assert.Throws<ArgumentException>(() => "You have to turn it on.");
        }

        [Fact]
        public void AirConditioner_ChangeSpeed_IfToHighItGoToTheMaxSpeed()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            cond.ChangeSpeed(100000000);
            Assert.Equal(10, cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeSpeed_IfNegativeItBecameMinSpeed()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            cond.ChangeSpeed(-104);
            Assert.Equal(1, cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeSpeed_IfBecameTheAmountTyped()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            cond.ChangeSpeed(4);
            Assert.Equal(4, cond.Speed);
        }
    }
}
