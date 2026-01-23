using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Runtime.CompilerServices;
using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.LAMPTESTS
{
    public class EcoLampTest
    {
        [Fact]
        public void Created_EcoLamp_IsOff_WithZeroBrightness()
        {
            EcoLamp lamp = new EcoLamp();
            Assert.Equal(0, lamp.Intensity);
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
        }

        [Fact]
        public void EcoLamp_SwitchOn_WhenTurnedOnTheBrightnessIs30()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOn();
            Assert.Equal(DeviceStatus.On, lamp.DeviceStatus);
            Assert.Equal(30, lamp.Intensity);
        }

        [Fact]
        public void EcoLamp_SwitchOff_WhenSwitchedOffTheBrightnessIs0AndIsOff()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
            Assert.Equal(0, lamp.Intensity);
        }

        [Fact]
        public void EcoLamp_Toggle_ALampWithStatusOffBecameOn()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.Toggle();
            Assert.Equal(DeviceStatus.On, lamp.DeviceStatus);
        }

        [Fact]
        public void EcoLamp_Toggle_ALampWithStatusOnBecameOff()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOn();
            lamp.Toggle();
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
        }

        [Fact]
        public void EcoLamp_IncreaseBy_With30BrightnessTheNewBrightnessIs40()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOn(); 
            lamp.IncreaseBy();
            Assert.Equal(40, lamp.Intensity);
        }

        [Fact]
        public void EcoLamp_DecreaseBy_With30BrightnessTheNewBrightnessIs20()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOn();
            lamp.DecreaseBy();
            Assert.Equal(20, lamp.Intensity);
        }

        [Fact]
        public void EcoLamp_IncreaseBy_With30BrightnessTheNewBrightnessIs50BecauseOfNewChangerValue()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOn(); // 30
            lamp.IncreaseBy();
            Assert.Equal(50, lamp.Intensity);
        }

        [Fact]
        public void EcoLamp_DecreaseBy_With30BrightnessTheNewBrightnessIs10BecauseOfNewChangerValue()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOn(); // 30
            lamp.DecreaseBy();
            Assert.Equal(10, lamp.Intensity);
        }

        [Fact]
        public void EcoLamp_SetIntensity_NewIntensityIsSetTo50()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOn();
            lamp.SetIntensity(50);
            Assert.Equal(50, lamp.Intensity);
        }

        [Fact]
        public void EcoLamp_SetIntensity_NewIntensityIsSetToMin()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOn();
            lamp.SetIntensity(1);
            Assert.Equal(1, lamp.Intensity);
        }

        [Fact]
        public void EcoLamp_SetIntensity_NewIntensityIsSetToMax()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOn();
            lamp.SetIntensity(70);
            Assert.Equal(70, lamp.Intensity);
        }

       
    }
}
