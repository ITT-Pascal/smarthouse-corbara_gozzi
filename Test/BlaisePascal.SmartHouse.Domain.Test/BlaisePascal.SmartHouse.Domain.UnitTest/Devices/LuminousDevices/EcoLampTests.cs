using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.LuminousDevices
{
    public class EcoLampTests
    {
        EcoLamp ecoLamp = new EcoLamp(Guid.NewGuid(), new DeviceName("TestEcoLamp"));

        [Fact]
        public void EcoLampTest_Created_NameAndGuid()
        {
            Assert.NotNull(ecoLamp);
            Assert.Equal(DeviceStatus.Off, ecoLamp.DeviceStatus);
            Assert.Equal("TestEcoLamp", ecoLamp.Name.Name);
        }

        [Fact]
        public void EcoLampTest_SwitchOnWithAutoOff_ItTurnOnAndSetAutoOff()
        {
            ecoLamp.SwitchOn(true);
            Assert.Equal(DeviceStatus.On, ecoLamp.DeviceStatus);
        }

        [Fact]
        public void EcoLampTest_SwitchOnWithAutoOff_ItTurnOnAndSetAutoOff2()
        {
            ecoLamp.SwitchOn(15);
            Assert.Equal(DeviceStatus.On, ecoLamp.DeviceStatus);
        }

        [Fact]
        public void EcoLampTest_SwitchOnWithAutoOff_ItGavesError()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ecoLamp.SwitchOn(0));
        }

        [Fact]
        public void EcoLampTest_SwitchOff_ItTurnOffAndResetAutoOff()
        {
            ecoLamp.SwitchOn(true);
            ecoLamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, ecoLamp.DeviceStatus);
        }

        [Fact]
        public void EcoLampTest_CheckAutoOff_ItTurnOffIfTimePassed()
        {
            ecoLamp.SwitchOn(true);
            ecoLamp.CheckAutoOff();
            Assert.Equal(DeviceStatus.Off, ecoLamp.DeviceStatus);
        }

        [Fact]
        public void EcoLampTest_CheckAutoOff_ItDoesNothingIfTimeNotPassed()
        {
            ecoLamp.SwitchOn(true);
            ecoLamp.CheckAutoOff();
            Assert.Equal(DeviceStatus.On, ecoLamp.DeviceStatus);
        }

        [Fact]
        public void EcoLampTest_CheckAutoOff_ItGavesErrorIfOff()
        {
            Assert.Throws<InvalidOperationException>(() => ecoLamp.CheckAutoOff());
        }
    }
}
