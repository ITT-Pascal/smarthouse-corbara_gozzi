using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.AirConditionerTest
{
    public class AirConditionersTest
    {
        AirConditioners cond = new AirConditioners();

        [Fact]

        public void AirConditioner_SwitchOn_ItTurnOn()
        {
            cond.SwitchOn();
            Assert.Equal(DeviceStatus.On, cond.State());
        }

        [Fact]

        public void AirConditioner_SwitchOn_ItTurnOnAlsoWithName()
        {
            AirConditioners cond = new AirConditioners("Cond", new Guid());
            cond.SwitchOn("Cond");
            Assert.Equal(DeviceStatus.On, cond.State());
        }
        [Fact]

        public void AirConditioner_SwitchOn_ItTurnOnAlsoWithGuid()
        {
            AirConditioners cond = new AirConditioners("Cond", new Guid());
            cond.SwitchOn(); // TODO : TESTARE GUID
            Assert.Equal(DeviceStatus.On, cond.State());
        }

        [Fact]

        public void AirConditioner_SwitchOff_ItTurnOff()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            Assert.Equal(DeviceStatus.Off, cond.State());
        }

        [Fact]

        public void AirConditioner_SwitchOn_HeatIs20AndPower5()
        {
            cond.SwitchOn();
            Assert.Equal(20, cond.Heat);
            Assert.Equal(5, cond.PowerIntensity);
        }

        [Fact]

        public void AirConditioner_SwitchOff_HeatIs0AndPowerAlso()
        {
            cond.SwitchOn();
            cond.SwitchOff();
            Assert.Equal(0, cond.Heat);
            Assert.Equal(0, cond.PowerIntensity); //agagga
        }

        [Fact]

        public void AirConditioner_SwitchOn_ModeIsFan()
        {
            cond.SwitchOn();
            Assert.Equal(ModeTypes.FAN, cond.ModeState());
        }

        [Fact]

        public void AirConditioner_ChangePower_ItIncrease()
        {
            cond.SwitchOn();
            cond.ChangePower(7);
            Assert.Equal(7, cond.PowerIntensity);
        }

        [Fact]

        public void AirConditioner_ChangePower_ItIncreaseAtMin()
        {
            cond.SwitchOn();
            cond.ChangePower(-100);
            Assert.Equal(1, cond.PowerIntensity);
        }

        [Fact]

        public void AirConditioner_ChangePower_ItIncreaseAtMax()
        {
            cond.SwitchOn();
            cond.ChangePower(100);
            Assert.Equal(10, cond.PowerIntensity);
        }

        [Fact]

        public void AirConditioner_ChangePower_ItNotIncreaseIfOff()
        {
            cond.SwitchOn();
            cond.ChangePower(7);
            cond.SwitchOff();
            Assert.Equal(0, cond.PowerIntensity);
        }

        [Fact]

        public void AirConditioner_ChangeMode_ItBecameCool()
        {
            cond.SwitchOn();
            cond.ChangeMode(ModeTypes.COOL);
            Assert.Equal(ModeTypes.COOL, cond.ModeState());
            Assert.Equal(10, cond.Heat);
        }

        [Fact]

        public void AirConditioner_ChangeMode_ItBecameHeat()
        {
            cond.SwitchOn();
            cond.ChangeMode(ModeTypes.HEAT);
            Assert.Equal(ModeTypes.HEAT, cond.ModeState());
            Assert.Equal(30, cond.Heat);
        }

        [Fact]

        public void AirConditioner_ChangeMode_ItBecameCustom()
        {
            cond.SwitchOn();
            cond.ChangeMode(ModeTypes.CUSTOM);
            Assert.Equal(ModeTypes.CUSTOM, cond.ModeState());
        }

        [Fact]

        public void AirConditioner_ChangeHeatCustomMode_ItChange()
        {
            cond.SwitchOn();
            cond.ChangeMode(ModeTypes.CUSTOM);
            cond.ChangeHeatCustomMode(10);
            Assert.Equal(10, cond.Heat);
        }

        [Fact]

        public void AirConditioner_ChangeHeatCustomMode_ItChangeAtMin()
        {
            cond.SwitchOn();
            cond.ChangeMode(ModeTypes.CUSTOM);
            cond.ChangeHeatCustomMode(-110);
            Assert.Equal(1, cond.Heat);
        }

        [Fact]

        public void AirConditioner_ChangeHeatCustomMode_ItChangeAtMax()
        {
            cond.SwitchOn();
            cond.ChangeMode(ModeTypes.CUSTOM);
            cond.ChangeHeatCustomMode(1000);
            Assert.Equal(45, cond.Heat);
        }







    }
}
