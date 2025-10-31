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
            var lamp = new Lamp();
            Assert.Equal(0, lamp.Brightness);
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void Lamp_Brightness_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new Lamp();
            Assert.Equal(0, lamp.Brightness);

        }

        [Fact]

        public void Lamp_Status_WhenCreatedIsOffAndIsOff()
        {
            var lamp = new Lamp();

            Assert.False(lamp.IsOn);
        }


        [Fact]

        public void Lamp_TurnOn_WhenTurnedOnTheBrightnessIs50AndIsOn()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            Assert.Equal(50, lamp.Brightness);
            Assert.True(lamp.IsOn);
        }

        [Fact]

        public void Lamp_TurnOn_WhenTurnedOnTheBrightnessIs50()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            Assert.Equal(50, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnOn_WhenTurnedOnIsOn()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            Assert.True(lamp.IsOn);
        }

        [Fact]

        public void Lamp_TurnOff_WhenTurnedOnAndOffIsOffAndTheBrightnessIs0()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]

        public void Lamp_TurnOff_WhenTurnedOnAndOffIsOff()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);

        }

        [Fact]

        public void Lamp_TurnOff_WhenTurnedOnAndOffTheBrightnessIs0()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]

        public void Lamp_TurnUpBrightness_WhenIsOffItRemain0()
        {
            var lamp = new Lamp();
            lamp.TurnUpBrightness(83);
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]

        public void Lamp_TurnDownBrightness_WhenIsOffItRemain0()
        {
            var lamp = new Lamp();
            lamp.TurnDownBrightness(83);
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]

        public void Lamp_TurnUpBrightness_WhenIsOnAndTurnUpOf10ItIncrease()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnUpBrightness(10);
            Assert.Equal(60, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnUpBrightness_WhenIsOnAndTurnUpOf100ItGoToTheMax()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnUpBrightness(100);
            Assert.Equal(100, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnDownBrightness_WhenIsOnAndTurnDownOf10ItDecrease()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnDownBrightness(10);
            Assert.Equal(40, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnDownBrightness_WhenIsOnAndTurnDownOf50ItDecrease()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnDownBrightness(50);
            Assert.Equal(1, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnUpBrightness_WhenIsOnAndTurnUpOf50ItIncrease()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnUpBrightness(50);
            Assert.Equal(100, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnUpBrightness_WhenIsOnAndDecreasrdAndIncreased()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnDownBrightness(50);
            lamp.TurnUpBrightness(24);
            Assert.Equal(25, lamp.Brightness);

        }

        [Fact]

        public void Lamp_TurnUpBrightness_WhenIsOnAndIncreasedAndDecreaded()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnUpBrightness(50);
            lamp.TurnDownBrightness(75);
            Assert.Equal(25, lamp.Brightness);

        }

        //TODO finire test
    }
}
