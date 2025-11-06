using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class TwoLampsDeviceTest
    {
        [Fact]
        public void TwoLampDevice_StatusAndBrightness_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new Lamp();
            Assert.Equal(0, lamp.Brightness);
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void TwoLampDevice_Brightness_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new Lamp();
            Assert.Equal(0, lamp.Brightness);

        }

        [Fact]

        public void TwoLampDevice_Status_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new Lamp();

            Assert.False(lamp.IsOn);
        }

        [Fact]

        public void TwoLampDevice_TurnOnFirstLamp_WhenTurnedOnIsOn()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnFirstLamp();
            Assert.True(twoLampsDevice.FirstLamp.IsOn);
            Assert.False(twoLampsDevice.SecondLamp.IsOn);
        }

        [Fact]

        public void TwoLampDevice_TurnOnSecondLamp_WhenTurnedOnIsOn()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnSecondLamp();
            Assert.False(twoLampsDevice.FirstLamp.IsOn);
            Assert.True(twoLampsDevice.SecondLamp.IsOn);
        }

        [Fact]

        public void TwoLampDevice_TurnOnAllLamps_WhenTurnedOnBothAreOn()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnAllLamps();
            Assert.True(twoLampsDevice.FirstLamp.IsOn);
            Assert.True(twoLampsDevice.SecondLamp.IsOn);
        }

        [Fact]

        public void TwoLampDevice_TurnOffFirstLamp_WhenTurnedOffIsOff()
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

        public void TwoLampDevice_TurnOffSecondLamp_WhenTurnedOffIsOff()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp() ;
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnSecondLamp();
            twoLampsDevice.TurnOffSecondLamp();
            Assert.False(twoLampsDevice.FirstLamp.IsOn);
            Assert.False(twoLampsDevice.SecondLamp.IsOn);
        }

        [Fact]

        public void TwoLampDevice_TurnOffAllLamps_WhenTurnedOffBothAreOff()
        {
            var firstLamp = new Lamp() ;
            var secondLamp = new Lamp() ;
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnAllLamps();
            twoLampsDevice.TurnOffAllLamps();
            Assert.False(twoLampsDevice.FirstLamp.IsOn);
            Assert.False(twoLampsDevice.SecondLamp.IsOn);
        }

        [Fact]

        public void TwoLampDevice_Brightness_WhenOnlyTheFirstIsOnTheBrightnessIs0()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnFirstLamp();
            twoLampsDevice.TurnOnSecondLamp();
            Assert.Equal(0, twoLampsDevice.FirstLamp.Brightness);
            Assert.Equal(0, twoLampsDevice.SecondLamp.Brightness);
        }


        [Fact]

        public void TwoLampDevice_ChangeBrightnessOfLamps_WhenBothAreOnBrightnessChanges()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnAllLamps();
            twoLampsDevice.FirstLamp.ChangeBrightness(30);
            twoLampsDevice.SecondLamp.ChangeBrightness(50);
            Assert.Equal(30, twoLampsDevice.FirstLamp.Brightness);
            Assert.Equal(50, twoLampsDevice.SecondLamp.Brightness);
        }

        [Fact]

        public void TwoLampDevice_ChangeBrightnessOfLamps_WhenIsIncreasedItGoAt100()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.TurnOnAllLamps();
            twoLampsDevice.FirstLamp.ChangeBrightness(1000);
            twoLampsDevice.SecondLamp.ChangeBrightness(5000);
            Assert.Equal(100, twoLampsDevice.FirstLamp.Brightness);
            Assert.Equal(100, twoLampsDevice.SecondLamp.Brightness);
        }

        [Fact]

        public void TwoLampDevice_ChangeBrightnessOfLamps_WhenTheBrightnessIsLowerThan0ItBecame0()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.FirstLamp.ChangeBrightness(-1000);
            twoLampsDevice.SecondLamp.ChangeBrightness(-5000);
            Assert.Equal(0, twoLampsDevice.FirstLamp.Brightness);
            Assert.Equal(0, twoLampsDevice.SecondLamp.Brightness);
        }

        [Fact]

        public void TwoLampDevice_ChangeBrightnessOfLamps_WhenAreOffBrightnessDoesNotChange()
        {
            var firstLamp = new Lamp();
            var secondLamp = new Lamp();
            var twoLampsDevice = new TwoLampsDevice(firstLamp, secondLamp);
            twoLampsDevice.FirstLamp.ChangeBrightness(30);
            twoLampsDevice.SecondLamp.ChangeBrightness(50);
            Assert.Equal(0, twoLampsDevice.FirstLamp.Brightness);
            Assert.Equal(0, twoLampsDevice.SecondLamp.Brightness);
        }



    }
}
