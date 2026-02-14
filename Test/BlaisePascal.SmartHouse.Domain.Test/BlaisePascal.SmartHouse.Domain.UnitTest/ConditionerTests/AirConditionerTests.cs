using BlaisePascal.SmartHouse.Domain.Shared;
using BlaisePascal.SmartHouse.Domain.ThermicalDevices;
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
            Assert.Equal(1, cond.Speed);
            Assert.Equal(0, cond.Temperature);
            Assert.Equal(DeviceStatus.Off , cond.DeviceStatus);
        }

        [Fact]
        public void AirConditioner_SwitchOff_TurnedOnAndOff()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            Assert.Equal(0, cond.Speed);
            Assert.Equal(0, cond.Temperature);
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
            Assert.Equal(10, cond.Temperature);
            Assert.Equal(1, cond.Speed);

            Assert.Equal(DeviceStatus.On, cond.DeviceStatus);
        }

        [Fact]
        public void AirConditioner_ChangeMode_WhenOffItGaveError()
        {
            cond.SwitchOff();
            Assert.Throws<ArgumentException>(() => cond.ChangeModeTo(AcMode.Cool));
        }

        [Fact]
        public void AirConditioner_ChangeMode_IfIPutTheSameItRemainThatMode()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Cool);
            Assert.Equal(AcMode.Cool, cond.ModeOfAc);
            Assert.Equal(10, cond.Temperature);
            Assert.Equal(1, cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeMode_ToHeatTheHeatIs30()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Heat);
            Assert.Equal(AcMode.Heat, cond.ModeOfAc);
            Assert.Equal(30, cond.Temperature);
            Assert.Equal(1, cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeMode_ToDryTheHeatIs0()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Dry);
            Assert.Equal(AcMode.Dry, cond.ModeOfAc);
            Assert.Equal(0, cond.Temperature);
            Assert.Equal(1, cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeSpeed_IfOffItGivesError()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            Assert.Throws<ArgumentException>(() => cond.ChangeSpeedTo(10));
        }

        [Fact]
        public void AirConditioner_ChangeSpeed_IfToHighItGoToTheMaxSpeed()
        {
            cond.SwitchOn();
            cond.ChangeSpeedTo(100000000);
            Assert.Equal(10, cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeSpeed_IfNegativeItBecameMinSpeed()
        {
            cond.SwitchOn();
            cond.ChangeSpeedTo(-104);
            Assert.Equal(1, cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeSpeed_IfBecameTheAmountTyped()
        {
            cond.SwitchOn();
            cond.ChangeSpeedTo(4);
            Assert.Equal(4, cond.Speed);
        }
    }
}
