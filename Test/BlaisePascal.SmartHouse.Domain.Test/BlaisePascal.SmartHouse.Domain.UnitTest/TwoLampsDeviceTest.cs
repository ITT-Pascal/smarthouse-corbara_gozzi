using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class TwoLampsDeviceTest
    {
        [Fact]
        public void TwoLampsDevice_StatusAndBrightness_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new Lamp();
            Assert.Equal(0, lamp.Intensity);
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void TwoLampsDevice_Brightness_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new Lamp();
            Assert.Equal(0, lamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_Status_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new Lamp();
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void TwoLampsDevice_TurnOnFirstLamp_WhenTurnedOnIsOn()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnFirstLamp();
            Assert.True(twoLampsDevice.FirstLamp.IsOn);
            Assert.False(twoLampsDevice.SecondLamp.IsOn);
        }

        [Fact]
        public void TwoLampsDevice_TurnOnSecondLamp_WhenTurnedOnIsOn()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnSecondLamp();
            Assert.False(twoLampsDevice.FirstLamp.IsOn);
            Assert.True(twoLampsDevice.SecondLamp.IsOn);
        }

        [Fact]
        public void TwoLampsDevice_TurnOnAllLamps_WhenTurnedOnBothAreOn()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnAllLamps();
            Assert.True(twoLampsDevice.FirstLamp.IsOn);
            Assert.True(twoLampsDevice.SecondLamp.IsOn);
        }

        [Fact]
        public void TwoLampsDevice_TurnOffFirstLamp_WhenTurnedOffIsOff()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnFirstLamp();
            twoLampsDevice.TurnOffFirstLamp();
            Assert.False(twoLampsDevice.FirstLamp.IsOn);
            Assert.False(twoLampsDevice.SecondLamp.IsOn);
        }

        [Fact]
        public void TwoLampsDevice_TurnOffSecondLamp_WhenTurnedOffIsOff()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnSecondLamp();
            twoLampsDevice.TurnOffSecondLamp();
            Assert.False(twoLampsDevice.SecondLamp.IsOn);

        }

        [Fact]
        public void TwoLampsDevice_TurnOffAllLamps_WhenTurnedOffBothAreOff()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnAllLamps();
            twoLampsDevice.TurnOffAllLamps();
            Assert.False(twoLampsDevice.FirstLamp.IsOn);
            Assert.False(twoLampsDevice.SecondLamp.IsOn);
        }

        [Fact]
        public void TwoLampsDevice_Brightness_WhenTheFirstIsOnTheBrightnessIs50()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnFirstLamp();
            Assert.Equal(50, twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(0, twoLampsDevice.SecondLamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_ChangeBrightnessOfLamps_WhenBothAreOnBrightnessChanges()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnAllLamps();
            twoLampsDevice.ChangeBrightnessOfLamps(30);
            Assert.Equal(80, twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(80, twoLampsDevice.SecondLamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_ChangeBrightnessOfLamps_WhenIsIncreasedItGoAt100()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnAllLamps();
            twoLampsDevice.ChangeBrightnessOfLamps(100);
            Assert.Equal(100, twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(100, twoLampsDevice.SecondLamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_ChangeBrightnessOfLamps_WhenTheBrightnessIsLowerThan0ItBecame0()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.ChangeBrightnessOfLamps(-100);
            Assert.Equal(0, twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(0, twoLampsDevice.SecondLamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_ChangeBrightnessOfLamps_WhenAreOffBrightnessDoesNotChange()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.ChangeBrightnessOfLamps(30);
            Assert.Equal(0, twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(0, twoLampsDevice.SecondLamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_ChangeBrightnessOfLamps_WhenBothAreOnTheBrightnessIs50()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnAllLamps();
            Assert.Equal(50, twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(50, twoLampsDevice.SecondLamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_ChangeBrightnessOfLamps_WhenOnlyTheFirstIsOn()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnFirstLamp();
            twoLampsDevice.ChangeBrightnessOfLamps(20);
            Assert.Equal(50, twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(0, twoLampsDevice.SecondLamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_ChangeBrightnessOfLamps_WhenDecreaseBelow0WhileOnBecomes0()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnAllLamps();
            twoLampsDevice.ChangeBrightnessOfLamps(-60);
            Assert.Equal(1, twoLampsDevice.FirstLamp.Intensity);
            Assert.Equal(1, twoLampsDevice.SecondLamp.Intensity);
        }

        [Fact]
        public void Lamp_TurnOn_IsOnAndBrightness50()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            Assert.True(lamp.IsOn);
            Assert.Equal(50, lamp.Intensity);
        }

        [Fact]
        public void Lamp_TurnOff_SetsIsOffAndBrightness0()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.SwitchOff();
            Assert.False(lamp.IsOn);
            Assert.Equal(0, lamp.Intensity);
        }

        [Fact]
        public void Lamp_ChangeBrightness_RespectsBounds()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.ChangeBrightness(1000);
            Assert.Equal(100, lamp.Intensity);

            lamp.ChangeBrightness(-1000);
            Assert.Equal(1, lamp.Intensity);
        }

        [Fact]
        public void TwoLampsDevice_DefaultConstructor_InitializesTwoLampsIfAvailable()
        {
            var twoLampsDevice = new TwoLampsDevice();
            Assert.NotNull(twoLampsDevice.FirstLamp);
            Assert.NotNull(twoLampsDevice.SecondLamp);
        }
    }
}
