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

        [Fact]
        public void AirConditioner_SwitchOn_WhenOnIsCoolAndStartingParameters()
        {
            cond.SwitchOn();
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

        [Fact]
        public void AirConditioner_ChangeModeTo_WhenOffItGaveError()
        {
            cond.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => cond.ChangeModeTo(AcMode.Cool));
        }

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

        [Fact]
        public void AirConditioner_ChangeModeTo_IfOffItGaveError()
        {
            Assert.Throws<InvalidOperationException>(() => cond.ChangeModeTo(AcMode.Hot));
        }

        [Fact]
        public void AirConditioner_ChangeModeTo_ItChangeMode()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Hot);
            Assert.Equal(AcMode.Hot, cond.AcMode);
        }

        [Fact]
        public void AirConditioner_ChangeModeTo_WhenHotChangeTemperature()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Hot);
            Assert.Equal(cond.AcDictionary[cond.AcMode], cond.Temperature);
        }

        [Fact]
        public void AirConditioner_ChangeModeTo_WhenCoolChangeTemperature()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Cool);
            Assert.Equal(cond.AcDictionary[cond.AcMode], cond.Temperature);
        }

        [Fact]
        public void AirConditioner_ChangeModeTo_WhenFreezeChangeTemperature()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Freeze);
            Assert.Equal(cond.AcDictionary[cond.AcMode], cond.Temperature);
        }

        [Fact]
        public void AirConditioner_ChangeModeTo_WhenDryChangeTemperature()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Dry);
            Assert.Equal(cond.AcDictionary[cond.AcMode], cond.Temperature);
        }

        [Fact]
        public void AirConditioner_ChangeModeTo_WhenCustomChangeTemperature()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Custom);
            Assert.Equal(Temperature.NewTemperature(15).Heat, cond.Temperature.Heat);
        }

        [Fact]
        public void AirConditioner_ChangeModeTo_WhenHeatChangeTemperature()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Heat);
            Assert.Equal(cond.AcDictionary[cond.AcMode], cond.Temperature);
        }

        [Fact]
        public void AirConditioner_ChangeCustomTemperatureTo_IfOffError()
        {
            Assert.Throws<InvalidOperationException>(() => cond.ChangeCustomTemperatureTo(Temperature.NewTemperature(23)));
        }
    }
}
