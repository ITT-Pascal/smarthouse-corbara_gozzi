using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.ThermicalDevice
{
    public class AirConditionersTest
    {
        private readonly AirConditioner cond = new();
        private readonly Temperature zeroTemp = Temperature.NewZeroTemperature();
        private readonly SpeedRPM zeroSpeed = SpeedRPM.NewZeroSpeed();
        private readonly SpeedRPM basicSpeed = SpeedRPM.NewBasicSpeed();
        private readonly SpeedRPM newSpeed = SpeedRPM.NewSpeed(670);

        [Fact]
        public void AirConditioner_Constructor_WhenCreatedHeatAndSpeedAre0()
        {
            Assert.Equal(zeroSpeed.Value, cond.Speed.Value);
            Assert.Equal(zeroTemp.Heat, cond.Temperature.Heat);
            Assert.Equal(DeviceStatus.Off , cond.DeviceStatus);
        }

        #region ON - OFF - TOGGLE TESTS

        [Fact]
        public void AirConditioner_SwitchOn_WhenOnIsCoolAndStartingParameters()
        {
            cond.SwitchOn();

            Assert.Equal(DeviceStatus.On, cond.DeviceStatus);
            Assert.Equal(AcMode.Cool, cond.AcMode);
            Assert.Equal(cond.AcDictionary[cond.AcMode].Heat, cond.Temperature.Heat);
            Assert.Equal(basicSpeed.Value, cond.Speed.Value);
        }

        [Fact]
        public void AirConditioner_SwitchOff_TurnedOnAndOff()
        {
            cond.SwitchOn();

            cond.SwitchOff();

            Assert.Equal(zeroSpeed.Value, cond.Speed.Value);
            Assert.Equal(zeroTemp.Heat, cond.Temperature.Heat);
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

        #endregion

        #region CHANGE MODE TESTS

        [Fact]
        public void AirConditioner_ChangeModeTo_WhenOffItGaveError()
        {
            Assert.Throws<InvalidOperationException>(() => cond.ChangeModeTo(AcMode.Custom));
        }

        [Fact]
        public void AirConditioner_ChangeModeTo_TheModeIsChangedToHot()
        {
            cond.SwitchOn();

            cond.ChangeModeTo(AcMode.Hot);

            Assert.Equal(AcMode.Hot, cond.AcMode);
            Assert.Equal(Temperature.maxHeat, cond.Temperature.Heat);
        }

        [Fact]
        public void AirConditioner_ChangeModeTo_TheModeIsChangedToFreeze()
        {
            cond.SwitchOn();

            cond.ChangeModeTo(AcMode.Freeze);

            Assert.Equal(AcMode.Freeze, cond.AcMode);
            Assert.Equal(Temperature.minHeat, cond.Temperature.Heat);
        }

        [Fact]
        public void AirConditioner_ChangeModeTo_TheModeIsChangedToCustomAndTempIsSetTo15()
        {
            cond.SwitchOn();

            cond.ChangeModeTo(AcMode.Custom);

            Assert.Equal(AcMode.Custom, cond.AcMode);
            Assert.Equal(Temperature.NewTemperature(15).Heat, cond.Temperature.Heat);
        }

        #endregion

        #region CHANGE SPEED TESTS

        [Fact]
        public void AirConditioner_ChangeSpeedTo_IfOffItGaveError()
        {
            Assert.Throws<InvalidOperationException>(() => cond.ChangeSpeedTo(basicSpeed.Value));
        }

        [Fact]
        public void AirConditioner_ChangeSpeedTo_ItChangeSpeed()
        {
            cond.SwitchOn();
            cond.ChangeSpeedTo(670);
            Assert.Equal(newSpeed.Value, cond.Speed.Value);
        }

        [Fact]
        public void AirConditioner_ChangeSpeedTo_WhenSpeedIsNegativeWithOtherModeTheValueIsPositive()
        {
            SpeedRPM speed = SpeedRPM.NewSpeed(-670);
            cond.SwitchOn();
            cond.ChangeSpeedTo(speed.Value);
            Assert.Equal(Math.Abs(speed.Value), cond.Speed.Value);
        }

        [Fact]
        public void AirConditioner_ChangeSpeedTo_WhenDryItChange()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Dry);
            cond.ChangeSpeedTo(newSpeed.Value);
            Assert.Equal(-Math.Abs(newSpeed.Value), cond.Speed.Value);
        }

        #endregion 

        [Fact]
        public void AirConditioner_ChangeCustomTemperatureTo_CustomIsSetTo23()
        {
            cond.ChangeCustomTemperatureTo(Temperature.NewTemperature(23));

            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Custom);

            Assert.Equal(Temperature.NewTemperature(23).Heat, cond.Temperature.Heat);
        }
    }
}
