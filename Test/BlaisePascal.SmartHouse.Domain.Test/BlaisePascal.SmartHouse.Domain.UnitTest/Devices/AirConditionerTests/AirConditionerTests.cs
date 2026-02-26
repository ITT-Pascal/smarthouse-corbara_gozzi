using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.AirConditionerTests
{
    public class AirConditionersTest
    {
        readonly AirConditioner cond = new();

        [Fact]
        public void AirConditioner_Constructor_WhenCreatedHeatAndSpeedAre0()
        {
            Assert.Equal(SpeedRPM.NewSpeed(0), cond.Speed);
            Assert.Equal(Temperature.NewTemperature(0), cond.Temperature);
            Assert.Equal(DeviceStatus.Off , cond.DeviceStatus);
        }

        [Fact]
        public void AirConditioner_SwitchOn_WhenOnIsCoolAndStartingParameters()
        {
            cond.SwitchOn();
            Assert.Equal(AcMode.Cool, cond.AcMode);
            Assert.Equal(cond.AcDictionary[cond.AcMode], cond.Temperature);
            Assert.Equal(SpeedRPM.NewSpeed(700), cond.Speed);
        }

        [Fact]
        public void AirConditioner_SwitchOff_TurnedOnAndOff()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            Assert.Equal(SpeedRPM.NewSpeed(0), cond.Speed);
            Assert.Equal(Temperature.NewTemperature(0), cond.Temperature);
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
        public void AirConditioner_ChangeMode_WhenOffItGaveError()
        {
            cond.SwitchOff();
            Assert.Throws<ArgumentException>(() => cond.ChangeModeTo(AcMode.Cool));
        }

        [Fact]
        public void AirConditioner_ChangeSpeedTo_IfOffItGaveError()
        {
            Assert.Throws<InvalidOperationException>(() => cond.ChangeSpeedTo(1000));
        }

        [Fact]
        public void AirConditioner_ChangeSpeedTo_itChangeSpeed()
        {
            cond.SwitchOn();
            cond.ChangeSpeedTo(670);
            Assert.Equal(SpeedRPM.NewSpeed(670), cond.Speed);
        }

        [Fact]
        public void AirConditioner_ChangeSpeedTo_WhenDryItChange()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Dry);
            cond.ChangeSpeedTo(-670);
            Assert.Equal(SpeedRPM.NewSpeed(-670), cond.Speed);
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
            Assert.Equal(Temperature.NewTemperature(15), cond.Temperature);
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

        [Fact]
        public void AirConditioner_ChangeCustomTemperatureTo_ItChange()
        {
            cond.SwitchOn();
            cond.ChangeModeTo(AcMode.Custom);
            cond.ChangeCustomTemperatureTo(Temperature.NewTemperature(23));
            Assert.Equal(Temperature.NewTemperature(23), cond.Temperature);
        }
    }
}
