using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.LAMPTESTS
{
    public class LampTest
    {
        [Fact]
        public void Created_Lamp_IsOff_WithZeroBrightness()
        {
            Lamp lamp = new Lamp();
            Assert.Equal(0, lamp.Intensity);
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
        }

        [Fact]
        public void Lamp_SwitchOn_WhenTurnedOnTheBrightnessIs30()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn();
            //BrightnessAtOn = 30
            Assert.Equal(DeviceStatus.On, lamp.DeviceStatus);
            Assert.Equal(50, lamp.Intensity);
        }

        [Fact]
        public void Lamp_SwitchOff_WhenSwitchedOffTheBrightnessIs0AndIsOff()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
            Assert.Equal(0, lamp.Intensity);
        }

        [Fact]
        public void Lamp_Toggle_ALampWithStatusOffBecameOn()
        {
            Lamp lamp = new Lamp();
            lamp.Toggle();
            Assert.Equal(DeviceStatus.On, lamp.DeviceStatus);
        }

        [Fact]
        public void Lamp_Toggle_ALampWithStatusOnBecameOff()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn();
            lamp.Toggle();
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
        }

        [Fact]
        public void Lamp_IncreaseBy_With50BrightnessTheNewBrightnessIs60()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn(); // 50
            lamp.IncreaseBy();
            Assert.Equal(60, lamp.Intensity);
        }

        [Fact]
        public void Lamp_DecreaseBy_With50BrightnessTheNewBrightnessIs40()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn();
            lamp.DecreaseBy();
            Assert.Equal(40, lamp.Intensity);
        }

        [Fact]
        public void Lamp_IncreaseBy_With50BrightnessTheNewBrightnessIs70BecauseOfNewChangerValue()
        {
            Lamp lamp = new Lamp("TestLamp", new Guid(), 20);
            lamp.SwitchOn(); // 50
            lamp.IncreaseBy();
            Assert.Equal(70, lamp.Intensity);
        }

        [Fact]
        public void Lamp_DecreaseBy_With50BrightnessTheNewBrightnessIs10BecauseOfNewChangerValue()
        {
            Lamp lamp = new Lamp("TestLamp", new Guid(), 40);
            lamp.SwitchOn(); // 50
            lamp.DecreaseBy();
            Assert.Equal(10, lamp.Intensity);
        }

        [Fact]
        public void Lamp_SetIntensity_NewIntensityIsSetTo60()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn();
            lamp.SetIntensity(60);
            Assert.Equal(60, lamp.Intensity);
        }

        [Fact]
        public void Lamp_SetIntensity_NewIntensityIsSetTo1Min()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn();
            lamp.SetIntensity(1);
            Assert.Equal(1, lamp.Intensity);
        }

        [Fact]
        public void Lamp_SetIntensity_NewIntensityIsSetToMax()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn();
            lamp.SetIntensity(100);
            Assert.Equal(100, lamp.Intensity);
        }

        [Fact]
        public void Lamp_ChangeValueOfIncreaseAndDecrease_TheValueIs30()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn();
            lamp.ChangeValueOfIncreaseAndDecrease(30);
            lamp.IncreaseBy();
            Assert.Equal(30, lamp.ValueOfIncreaseAndDescrease);
            Assert.Equal(80, lamp.Intensity);
        }

        [Fact]
        public void Lamp_ChangeValueOfIncreaseAndDecrease_TheValueIs1()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn();
            lamp.ChangeValueOfIncreaseAndDecrease(1);
            lamp.IncreaseBy();
            Assert.Equal(1, lamp.ValueOfIncreaseAndDescrease);
            Assert.Equal(51, lamp.Intensity);
        }
    }
}
