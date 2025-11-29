using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class ThermostatTest
    {

        [Fact]
        public void Thermostat_CreationWithGuid_AtCreationStatusIsOffAndTemperatureAre0And20AndGuidIsCorrect()
        {
            Guid id = new Guid();
            Thermostat Thermo = new Thermostat(id);
            Assert.Equal(DeviceStatus.Off, Thermo.DeviceStatus);
            Assert.Equal(0, Thermo.CurrentTemperature);
            Assert.Equal(20, Thermo.TargetTemperature);
            Assert.Equal(id, Thermo.ID);
        }

        [Fact]
        public void Thermostat_CreationWithGuidAndName_AtCreationStatusIsOffAndTemperatureAre0And20AndOtherParameterAreCorrect()
        {
            Guid id = new Guid();
            Thermostat Thermo = new Thermostat(id, "Teodo");
            Assert.Equal(DeviceStatus.Off, Thermo.DeviceStatus);
            Assert.Equal(0, Thermo.CurrentTemperature);
            Assert.Equal(20, Thermo.TargetTemperature);
            Assert.Equal(id, Thermo.ID);
            Assert.Equal("Teodo", Thermo.Name);
        }

        [Fact]
        public void Thermostat_CreationWithGuidAndNameAndTargetTemp_AtCreationStatusIsOffAndTemperatureAre0And20AndOtherParameterAreCorrect()
        {
            Guid id = new Guid();
            Thermostat Thermo = new Thermostat(id, "Teodo", 26);
            Assert.Equal(DeviceStatus.Off, Thermo.DeviceStatus);
            Assert.Equal(0, Thermo.CurrentTemperature);
            Assert.Equal(26, Thermo.TargetTemperature);
            Assert.Equal(id, Thermo.ID);
            Assert.Equal("Teodo", Thermo.Name);
        }

        [Fact]
        public void Thermostat_IsTemperatureEqual_ReturnFalseWith0And20()
        {
            Thermostat Thermo = new Thermostat() { CurrentTemperature = 2, TargetTemperature = 20 };
            Thermo.IsTemperatureEquals();
            Assert.False(Thermo.IsTemperatureEquals());
        }

        [Fact]
        public void Thermostat_IsTemperatureEqual_ReturnTrueWith20And20()
        {
            Thermostat Thermo = new Thermostat() { CurrentTemperature = 20, TargetTemperature = 20 };
            Thermo.IsTemperatureEquals();
            Assert.True(Thermo.IsTemperatureEquals());
        }

        [Fact]
        public void Thermostat_SwitchOn_WhenSwitchedOnStatusIsOffAndTheThermostatPutTemperatureToTarget()
        {
            Guid id = new Guid();
            Thermostat Thermo = new Thermostat(id, "Teodo");
            Thermo.SwitchOn();
            Assert.Equal(DeviceStatus.Off, Thermo.DeviceStatus);
            Assert.Equal(20, Thermo.CurrentTemperature);
            Assert.Equal(20, Thermo.TargetTemperature);
        }

        [Fact]
        public void Thermostat_ChangeTargetTemperature_WithNumberGreaterThan36TheTargetIs36()
        {
            Guid id = new Guid();
            Thermostat Thermo = new Thermostat(id, "Teodo");
            Thermo.ChangeTargetTemperature(37);
            Assert.Equal(36, Thermo.TargetTemperature);
        }

        [Fact]
        public void Thermostat_ChangeTargetTemperature_WithNumberLessThanMinTheTargetIs1()
        {
            Guid id = new Guid();
            Thermostat Thermo = new Thermostat(id, "Teodo");
            Thermo.ChangeTargetTemperature(-37);
            Assert.Equal(1, Thermo.TargetTemperature);
        }

        [Fact]
        public void Thermostat_ChangeTargetTemperature_WithNumberInCorrectRangeTheNewTempIsSet()
        {
            Guid id = new Guid();
            Thermostat Thermo = new Thermostat(id, "Teodo");
            Thermo.ChangeTargetTemperature(21);
            Assert.Equal(21, Thermo.TargetTemperature);
        }
    }
}
