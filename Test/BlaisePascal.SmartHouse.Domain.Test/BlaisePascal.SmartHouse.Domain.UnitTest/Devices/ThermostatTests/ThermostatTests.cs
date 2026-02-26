using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.ThermostatTests
{
    public class ThermostatTests
    {
        Thermostat Thermo = new Thermostat();
        
        [Fact]
        public void Thermostat_Creation_WhenCreatedTempIs0AndTargetIs20AndStatusIsOff()
        {
            Assert.Equal(Temperature.NewTemperature(0), Thermo.CurrentTemperature);
            Assert.Equal(Temperature.NewTemperature(20), Thermo.TargetTemperature);
            Assert.Equal(DeviceStatus.Off, Thermo.DeviceStatus);
        }

        [Fact]
        public void Thermostat_CreationWithTargetTemp_WhenCreatedTempIs0AndTargetIs20AndStatusIsOff()
        {
            Thermostat Thermo = new Thermostat(Guid.NewGuid(), DeviceName.NewDeviceName("Ciao"), Temperature.NewTemperature(23));
            Assert.Equal(Temperature.NewTemperature(0), Thermo.CurrentTemperature);
            Assert.Equal(Temperature.NewTemperature(23), Thermo.TargetTemperature);
            Assert.Equal(DeviceStatus.Off, Thermo.DeviceStatus);
        }

        [Fact]
        public void Thermostat_IsTemperatureEqual_ReturnFalseWith0And20()
        {
            Thermostat Thermo = new Thermostat();
            Thermo.IsTemperatureEquals();
            Assert.False(Thermo.IsTemperatureEquals());
        }

        [Fact]
        public void Thermostat_IsTemperatureEqual_ReturnTrueWith20And20()
        {
            Thermo.SwitchOn();
            Assert.True(Thermo.IsTemperatureEquals());
        }

        [Fact]
        public void Thermostat_SwitchOn_WhenSwitchedOnStatusIsOnAndTheThermostatPutTemperatureToTarget()
        {
            Thermo.SwitchOn();
            Assert.Equal(DeviceStatus.On, Thermo.DeviceStatus);
            Assert.Equal(Temperature.NewTemperature(20), Thermo.CurrentTemperature);
        }

        [Fact]
        public void Thermostat_SwitchOff_WhenSwitchedOffStatusIsOffAndTheThermostatPutTemperatureToTarget()
        {
            Thermo.SwitchOn();
            Thermo.SwitchOff();
            Assert.Equal(DeviceStatus.On, Thermo.DeviceStatus);
            Assert.Equal(Temperature.NewTemperature(20), Thermo.CurrentTemperature);
        }

        [Fact]
        public void Thermostat_ChangeTargetTemperature_ChangedTo30()
        {
            Thermo.SwitchOn();
            Thermo.ChangeTargetTemperatureTo(Temperature.NewTemperature(30));
            Assert.Equal(Temperature.NewTemperature(30), Thermo.TargetTemperature);
        }
    }
}
