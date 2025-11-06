using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class EcoLampTest
    {
        [Fact]
        public void EcoLamp_StatusAndBrightness_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new EcoLamp();
            Assert.Equal(0, lamp.Brightness);
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void EcoLamp_Brightness_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new EcoLamp();
            Assert.Equal(0, lamp.Brightness);

        }

        [Fact]

        public void EcoLamp_Status_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new EcoLamp();

            Assert.False(lamp.IsOn);
        }


        [Fact]

        public void EcoLamp_TurnOn_WhenTurnedOnTheBrightnessIsHalfMaxBrightness70AndIsOn()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            Assert.Equal(35, lamp.Brightness);
            Assert.True(lamp.IsOn);
        }

        [Fact]

        public void EcoLamp_TurnOn_WhenTurnedWithMaxBrightnessOf80ItTurnOnWith40()
        {
            var lamp = new EcoLamp(80);
            lamp.TurnOn();
            Assert.Equal(40, lamp.Brightness);

        }

        [Fact]

        public void EcoLamp_TurnOn_WhenTurnedOnIsOn()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            Assert.True(lamp.IsOn);
        }

        [Fact]

        public void EcoLamp_TurnOff_WhenTurnedOnAndOffIsOffAndTheBrightnessIs0()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]

        public void EcoLamp_TurnOff_WhenTurnedOnAndOffIsOff()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);

        }

        [Fact]

        public void EcoLamp_TurnOff_WhenTurnedOnAndOffTheBrightnessIs0()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]

        public void EcoLamp_ChangeBrightness_WhenIsOffItRemain0()
        {
            var lamp = new EcoLamp();
            lamp.ChangeBrightness(83);
            Assert.Equal(0, lamp.Brightness);
        }

        

        [Fact]

        public void EcoLamp_ChangeBrightness_WhenIsOnAndTurnUpOf10ItIncrease()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(10);
            Assert.Equal(45, lamp.Brightness);

        }

        [Fact]

        public void EcoLamp_ChangeBrightness_WhenIsOnAndTurnUpOf100ItGoToTheMax()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(100);
            Assert.Equal(70, lamp.Brightness);

        }

        [Fact]

        public void EcoLamp_ChangeBrightness_WhenIsOnAndTurnDownOf10ItDecrease()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(-10);
            Assert.Equal(25, lamp.Brightness);

        }

        [Fact]

        public void EcoLamp_ChangeBrightness_WhenIsOnAndTurnDownInNegative50ItSetAt1()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(-50);
            Assert.Equal(1, lamp.Brightness);

        }

        
        

        [Fact]

        public void EcoLamp_ChangeBrightness_WhenIsOnAndDecreasreOf10AndIncreasedOf15ItIs40()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(-10);
            lamp.ChangeBrightness(15);
            Assert.Equal(40, lamp.Brightness);

        }

    }
}
