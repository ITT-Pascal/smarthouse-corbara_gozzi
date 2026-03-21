using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.LuminousDevices
{
    public class LampTests
    {
        Lamp lamp = new Lamp();

        [Fact]
        public void Lamp_Contructor_ItsOffAndIntensityAtMinimum()
        {
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
            Assert.Equal(new Intensity(0).Percentage, lamp.Intensity.Percentage);
        }

        [Fact]
        public void Lamp_Constructor_IsOffAndIntensityCustom()
        {
            Lamp lamp = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("Lamp"), DeviceStatus.Off, new Intensity(50), DateTime.Now, DateTime.Now);
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
            Assert.Equal("Lamp", lamp.Name.DevName);
            Assert.Equal(new Intensity(50).Percentage, lamp.Intensity.Percentage);
        }

        [Fact]
        public void Lamp_SwitchOn_ItTurnOnAndIntensityIsHalf()
        {
            lamp.SwitchOn();
            Assert.Equal(DeviceStatus.On, lamp.DeviceStatus);
            Assert.Equal(new Intensity(50).Percentage, lamp.Intensity.Percentage);
        }

        [Fact]
        public void Lamp_SwitchOff_ItTurnOffAndIntensityIsMinimum()
        {
            lamp.SwitchOn();
            lamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
            Assert.Equal(new Intensity(0).Percentage, lamp.Intensity.Percentage);
        }

        [Fact]
        public void Lamp_Toggle_ItToggleToON()
        {
            lamp.Toggle();
            Assert.Equal(DeviceStatus.On, lamp.DeviceStatus);
            Assert.Equal(new Intensity(50).Percentage, lamp.Intensity.Percentage);
        }

        [Fact]
        public void Lamp_Toggle_ItToggleToOFF()
        {
            lamp.Toggle();
            lamp.Toggle();
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
            Assert.Equal(new Intensity(0).Percentage, lamp.Intensity.Percentage);
        }

        [Fact]
        public void Lamp_IncreaseBy_ErrorBecouseOff()
        {
            Assert.Throws<InvalidOperationException>(() => lamp.IncreaseBy());
        }

        [Fact]
        public void Lamp_IncreaseBy_ItIncrease()
        {
            lamp.SwitchOn();
            lamp.IncreaseBy();
            Assert.Equal(new Intensity(60).Percentage, lamp.Intensity.Percentage);
        }

        [Fact]
        public void Lamp_DecreaseBy_ErrorBecouseOff()
        {
            Assert.Throws<InvalidOperationException>(() => lamp.DecreaseBy());
        }

        [Fact]
        public void Lamp_DecreaseBy_ItDecrease()
        {
            lamp.SwitchOn();
            lamp.DecreaseBy();
            Assert.Equal(new Intensity(40).Percentage, lamp.Intensity.Percentage);
        }

        [Fact]
        public void Lamp_IncreaseBy_ItIncreaseToMax()
        {
            lamp.SwitchOn();
            for (int i = 0; i < 10; i++)
                lamp.IncreaseBy();
            Assert.Equal(new Intensity(100).Percentage, lamp.Intensity.Percentage);
        }

        [Fact]
        public void Lamp_SetIntensityTo_ItSetIntensity()
        {
            lamp.SwitchOn();
            lamp.SetIntensityTo(new Intensity(70));
            Assert.Equal(new Intensity(70).Percentage, lamp.Intensity.Percentage);
        }

        [Fact]
        public void Lamp_SetIntensityTo_ErrorBecouseOff()
        {
            Assert.Throws<InvalidOperationException>(() => lamp.SetIntensityTo(new Intensity(70)));
        }

        [Fact]
        public void Lamp_SetIntensityTo_ItSetIntensityToMax()
        {
            lamp.SwitchOn();
            lamp.SetIntensityTo(new Intensity(150));
            Assert.Equal(new Intensity(100).Percentage, lamp.Intensity.Percentage);
        }
    }
}
