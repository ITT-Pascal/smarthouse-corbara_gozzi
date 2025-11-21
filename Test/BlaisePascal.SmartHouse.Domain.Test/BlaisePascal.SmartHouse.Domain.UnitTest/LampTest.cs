namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampTest
    {
        
        [Fact]
        public void Lamp_StatusAndBrightness_WhenCreatedIsOffA()
        {
            var lamp = new Lamp();
            Assert.Equal(0, lamp.Intensity);
            Assert.False(lamp.IsOn);
        }


        [Fact]
        public void Lamp_TurnOn_WhenTurnedOnTheBrightnessIs50AndIsOn()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            Assert.Equal(50, lamp.Intensity);
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void Lamp_TurnOn_WhenTurnedOnTheBrightnessIs50()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            Assert.Equal(50, lamp.Intensity);        }

        [Fact]
        public void Lamp_TurnOn_WhenTurnedOnIsOn()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void Lamp_TurnOff_WhenTurnedOnAndOffIsOffAndTheBrightnessIs0()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.SwitchOff();
            Assert.False(lamp.IsOn);
            Assert.Equal(0, lamp.Intensity);
        }

        [Fact]
        public void Lamp_TurnOff_WhenTurnedOnAndOffIsOff()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.SwitchOff();
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void Lamp_TurnOff_WhenTurnedOnAndOffTheBrightnessIs0()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.SwitchOff();
            Assert.Equal(0, lamp.Intensity);
        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenIsOffItRemain0()
        {
            var lamp = new Lamp();
            lamp.ChangeBrightness(83);
            Assert.Equal(0, lamp.Intensity);
        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenIsOnAndTurnUpOf10ItIncrease()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.ChangeBrightness(10);
            Assert.Equal(60, lamp.Intensity);
        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenIsOnAndTurnUpOf90ItGoToTheMax()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.ChangeBrightness(90);
            Assert.Equal(100, lamp.Intensity);
        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenIsOnAndTurnDownOf10ItDecrease()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.ChangeBrightness(-10);
            Assert.Equal(40, lamp.Intensity);
        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenIsOnAndTurnDownOf50ItDecreaseToMin1()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.ChangeBrightness(-50);
            Assert.Equal(1, lamp.Intensity);
        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenIsOnAndTurnUpOf50ItIncrease()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.ChangeBrightness(50);
            Assert.Equal(100, lamp.Intensity);
        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenIsOnAndDecreaseOf20dAndIncreaseOf30TheBrightnessIs60()
        {
            var lamp = new Lamp();
            lamp.SwitchOn();
            lamp.ChangeBrightness(-20);
            lamp.ChangeBrightness(30);
            Assert.Equal(60, lamp.Intensity);
        }
    }
}
