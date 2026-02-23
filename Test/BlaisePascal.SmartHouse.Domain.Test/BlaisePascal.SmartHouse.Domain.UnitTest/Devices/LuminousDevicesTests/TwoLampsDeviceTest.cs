using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.LuminousDevicesTests
{
    public class TwoLampsDeviceTest
    {
        Lamp lamp1 = new Lamp();
        EcoLamp lamp2 = new EcoLamp();

        [Fact]
        public void TwoLampsDevice_StatusAndBrightness_WhenCreatedAllTwoLampsAre0IntensityAndOff()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            Assert.Equal(DeviceStatus.Off, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, lamp2.DeviceStatus);
            Assert.Equal(0, lamp1.Intensity);
            Assert.Equal(0, lamp2.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_SwitchOnFirstLamp_WhenSwitchedOnIsOn()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOnFirstLamp();
            Assert.Equal(DeviceStatus.On, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, lamp2.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_SwitchOnSecondLamp_WhenSwitchedOnIsOn()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOnSecondLamp();
            Assert.Equal(DeviceStatus.Off, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.On, lamp2.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_SwitchOnAllLamps_WhenSwitchedOnBothAreOn()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOnAllLamps();
            Assert.Equal(DeviceStatus.On, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.On, lamp2.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_SwitchOffFirstLamp_WhenSwitchedOffIsOff()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOnAllLamps();
            twoLampsDevice.SwitchOffFirstLamp();
            Assert.Equal(DeviceStatus.Off, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.On, lamp2.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_SwitchOffSecondLamp_WhenSwitchedOffIsOff()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOnAllLamps();
            twoLampsDevice.SwitchOffSecondLamp();
            Assert.Equal(DeviceStatus.On, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, lamp2.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_SwitchOffAllLamps_WhenSwitchedOffBothAreOff()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOnAllLamps();
            twoLampsDevice.SwitchOffAllLamps();
            Assert.Equal(DeviceStatus.Off, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, lamp2.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_ChangeBrightnessOfLamps_IfLampsAreOffWeCannotChangeBrightness()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SetIntensityOfLamps(10);
            Assert.Equal(0, lamp1.Intensity);
            Assert.Equal(0, lamp2.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_ChangeBrightnessOfLamps_WhenBothAreOnBrightnessChanges()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOnAllLamps();
            twoLampsDevice.SetIntensityOfLamps(10);
            Assert.Equal(10, lamp1.Intensity);
            Assert.Equal(10, lamp2.Intensity);
        }
    }
}
