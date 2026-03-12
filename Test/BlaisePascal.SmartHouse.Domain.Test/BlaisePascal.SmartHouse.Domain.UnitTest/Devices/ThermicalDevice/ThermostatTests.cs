using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.ThermicalDevice
{
    public class ThermostatTests
    {
        private readonly Thermostat Thermo = new();
        private readonly Temperature basicTemp = Temperature.NewTemperature(20);
        private readonly Temperature zeroTemp = Temperature.NewZeroTemperature();
        
        [Fact]
        public void Thermostat_Creation_WhenCreatedTempIs0AndTargetIs20AndStatusIsOff()
        {
            Assert.Equal(zeroTemp.Heat, Thermo.CurrentTemperature.Heat);
            Assert.Equal(basicTemp.Heat, Thermo.TargetTemperature.Heat);
            Assert.Equal(DeviceStatus.Off, Thermo.DeviceStatus);
        }

        [Fact]
        public void Thermostat_CreationWithTargetTemp_WhenCreatedTempIs0AndTargetIs20AndStatusIsOff()
        {
            Temperature temp = Temperature.NewTemperature(23);
            Thermostat Thermo = new(Guid.NewGuid(), DeviceName.NewDeviceName("Ciao"), temp);
            Assert.Equal(zeroTemp.Heat, Thermo.CurrentTemperature.Heat);
            Assert.Equal(temp.Heat, Thermo.TargetTemperature.Heat);
            Assert.Equal(DeviceStatus.Off, Thermo.DeviceStatus);
        }

        [Fact]
        public void Thermostat_IsTemperatureEqual_ReturnFalseWith0And20()
        {
            Thermo.IsTemperatureEquals();
            Assert.False(Thermo.IsTemperatureEquals());
        }

        [Fact]
        public void Thermostat_IsTemperatureEqual_ReturnTrueWith20And20()
        {
            Thermostat thermo = new(Guid.NewGuid(), DeviceName.NewBasicName(), DeviceStatus.On, Temperature.NewTemperature(20), Temperature.NewTemperature(20), DateTime.Now, DateTime.Now);
            Assert.True(thermo.IsTemperatureEquals());
        }

        [Fact]
        public void Thermostat_SwitchOn_WhenSwitchedOnStatusIsOnAndTheThermostatPutTemperatureToTarget()
        {
            Thermo.SwitchOn();
            Assert.Equal(DeviceStatus.On, Thermo.DeviceStatus);
			Assert.Equal(Thermo.CurrentTemperature.Heat, Thermo.TargetTemperature.Heat);
		}

        [Fact]
        public void Thermostat_SwitchOff_WhenSwitchedOffStatusIsOffAndTheThermostatPutTemperatureToTarget()
        {
            Thermo.SwitchOn();
            Thermo.SwitchOff();
            Assert.Equal(DeviceStatus.Off, Thermo.DeviceStatus);
			Assert.Equal(Thermo.CurrentTemperature.Heat, Thermo.TargetTemperature.Heat);
		}

        [Fact]
        public void Thermostat_ChangeTargetTemperature_ChangedTo30()
        {
            Temperature temp = Temperature.NewTemperature(30);
            Thermo.SwitchOn();
            Thermo.ChangeTargetTemperatureTo(temp);
            Assert.Equal(temp.Heat, Thermo.TargetTemperature.Heat);
			Assert.Equal(Thermo.CurrentTemperature.Heat, Thermo.TargetTemperature.Heat);
		}
    }
}
