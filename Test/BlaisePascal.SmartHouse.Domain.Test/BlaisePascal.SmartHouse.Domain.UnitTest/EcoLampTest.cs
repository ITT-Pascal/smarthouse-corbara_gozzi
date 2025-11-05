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
        public void Lamp_StatusAndBrightness_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new EcoLamp();
            Assert.Equal(0, lamp.Brightness);
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void Lamp_Brightness_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new EcoLamp();
            Assert.Equal(0, lamp.Brightness);

        }

        [Fact]

        public void Lamp_Status_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new EcoLamp();

            Assert.False(lamp.IsOn);
        }


        [Fact]

        public void Lamp_TurnOn_WhenTurnedOnTheBrightnessIs50AndIsOn()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            Assert.Equal(50, lamp.Brightness);
            Assert.True(lamp.IsOn);
        }

        [Fact]

        public void Lamp_TurnOn_WhenTurnedOnTheBrightnessIs50()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            Assert.Equal(50, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnOn_WhenTurnedOnIsOn()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            Assert.True(lamp.IsOn);
        }

        [Fact]

        public void Lamp_TurnOff_WhenTurnedOnAndOffIsOffAndTheBrightnessIs0()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]

        public void Lamp_TurnOff_WhenTurnedOnAndOffIsOff()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);

        }

        [Fact]

        public void Lamp_TurnOff_WhenTurnedOnAndOffTheBrightnessIs0()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]

        public void Lamp_ChangeBrightness_WhenIsOffItRemain0()
        {
            var lamp = new EcoLamp();
            lamp.ChangeBrightness(83);
            Assert.Equal(0, lamp.Brightness);
        }

        

        [Fact]

        public void Lamp_ChangeBrightness_WhenIsOnAndTurnUpOf10ItIncrease()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(10);
            Assert.Equal(60, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnUpBrightness_WhenIsOnAndTurnUpOf100ItGoToTheMax()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(100);
            Assert.Equal(100, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnDownBrightness_WhenIsOnAndTurnDownOf10ItDecrease()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(15);
            Assert.Equal(55, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnDownBrightness_WhenIsOnAndTurnDownOf50ItDecrease()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(-10);
            Assert.Equal(5, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnUpBrightness_WhenIsOnAndTurnUpOf50ItIncrease()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(10);
            Assert.Equal(45, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnUpBrightness_WhenIsOnAndDecreasrdAndIncreased()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(10);
            lamp.ChangeBrightness(-10);
            Assert.Equal(25, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnUpBrightness_WhenIsOnAndIncreasedAndDecreaded()
        {
            var lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.ChangeBrightness(50);
            lamp.ChangeBrightness(-30);
            Assert.Equal(40, lamp.Brightness);

        }

        //FINIRE TEST (PRIMA RISOLVERE ERRORE NEL PROGRAMMA)
    }
}
