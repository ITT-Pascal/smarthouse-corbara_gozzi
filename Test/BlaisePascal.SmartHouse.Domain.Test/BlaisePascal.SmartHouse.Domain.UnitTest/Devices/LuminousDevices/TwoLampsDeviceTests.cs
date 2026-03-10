using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.LuminousDevices
{
    public class TwoLampsDeviceTests
    {
        Lamp lamp1 = new Lamp();
        EcoLamp lamp2 = new EcoLamp();

        [Fact]
        public void TwoLapsDevice_Constructor_CreateTwoLampsDevice()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            Assert.NotNull(twoLampsDevice);
            Assert.Equal(lamp1, twoLampsDevice.FirstLamp);
            Assert.Equal(lamp2, twoLampsDevice.SecondLamp);
        }

        [Fact]
        public void TwoLapsDevice_SwitchOnFirstLamp_SwitchOnFirstLamp()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOnFirstLamp();
            Assert.Equal(DeviceStatus.On, twoLampsDevice.FirstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, twoLampsDevice.SecondLamp.DeviceStatus);
        }

        [Fact]
        public void TwoLapsDevice_SwitchOnSecondLamp_SwitchOnSecondLamp()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOnSecondLamp();
            Assert.Equal(DeviceStatus.On, twoLampsDevice.SecondLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, twoLampsDevice.FirstLamp.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_SwitchOffFirstLamp_SwitchOffFirstLamp()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOn();
            twoLampsDevice.SwitchOffFirstLamp();
            Assert.Equal(DeviceStatus.Off, twoLampsDevice.FirstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, twoLampsDevice.SecondLamp.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_SwitchOffSecondLamp_SwitchOffSecondLamp()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOn();
            twoLampsDevice.SwitchOffSecondLamp();
            Assert.Equal(DeviceStatus.Off, twoLampsDevice.SecondLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, twoLampsDevice.FirstLamp.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_SwitchOn_SwitchOnBothLamps()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOn();
            Assert.Equal(DeviceStatus.On, twoLampsDevice.FirstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, twoLampsDevice.SecondLamp.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_SwitchOff_SwitchOffBothLamps()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOn();
            twoLampsDevice.SwitchOff();
            Assert.Equal(DeviceStatus.Off, twoLampsDevice.FirstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, twoLampsDevice.SecondLamp.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_Toggle_ToggleBothLampsOn()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.Toggle();
            Assert.Equal(DeviceStatus.On, twoLampsDevice.FirstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, twoLampsDevice.SecondLamp.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_Toggle_ToggleBothLampsOff()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SwitchOn();
            twoLampsDevice.Toggle();
            Assert.Equal(DeviceStatus.Off, twoLampsDevice.FirstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, twoLampsDevice.SecondLamp.DeviceStatus);
        }

        [Fact]
        public void TwoLampsDevice_SetIntensityTo_SetIntensityToBothLamps()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SetIntensityTo(Intensity.NewHalfIntensity());
            Assert.Equal(Intensity.NewHalfIntensity(), twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(Intensity.NewHalfIntensity(), twoLampsDevice.SecondLamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_IncreaseBy_IncreaseIntensityByOneLevel()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SetIntensityTo(Intensity.NewHalfIntensity());
            twoLampsDevice.IncreaseBy();
            Assert.Equal(Intensity.NewIntensity(60), twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(Intensity.NewIntensity(60), twoLampsDevice.SecondLamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_DecreaseBy_DecreaseIntensityByOneLevel()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice(lamp1, lamp2);
            twoLampsDevice.SetIntensityTo(Intensity.NewHalfIntensity());
            twoLampsDevice.DecreaseBy();
            Assert.Equal(Intensity.NewIntensity(40), twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(Intensity.NewIntensity(40), twoLampsDevice.SecondLamp.Intensity);
        }
    }
}
