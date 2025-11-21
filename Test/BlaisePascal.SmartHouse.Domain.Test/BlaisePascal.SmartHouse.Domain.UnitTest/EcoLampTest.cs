using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BlaisePascal.SmartHouse.Domain;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class EcoLampTest
    {
        [Fact]
        public void Created_Lamp_IsOff_WithZeroBrightness()
        {
            var lamp = new EcoLamp();
            Assert.Equal(0, lamp.Intensity);
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void EcoLamp_TurnOn_WhenTurnedOnTheBrightnessIsHalfMaxBrightness70AndIsOn()
        {
            var lamp = new EcoLamp();
            lamp.SwitchOn();
            Assert.True(lamp.IsOn);
            // metà di MaxBrightness di default (70) => 35
            Assert.Equal(35, lamp.Intensity);
        }

        [Fact]
        public void TurnOn_WithMax70_SetsBrightnessTo35()
        {
            var lamp = new EcoLamp();
            lamp.ChangeMaxBrightness(70);
            lamp.SwitchOn();
            Assert.Equal(35, lamp.Intensity);
        }

        [Fact]
        public void TurnOn_WithMax1_SetsBrightnessTo1AndMAxTo2()
        {
            var lamp = new EcoLamp();
            lamp.ChangeMaxBrightness(1);
            lamp.SwitchOn();
            // se la metà è < 1, la brightness minima all'accensione deve essere 1
            Assert.Equal(1, lamp.Intensity);
        }

        [Fact]
        public void TurnOn_WithVeryLargeMax_IsCappedAndHalfApplied()
        {
            var lamp = new EcoLamp();
            lamp.ChangeMaxBrightness(1000);
            lamp.SwitchOn();
            // MaxBrightness è cap-protected a 70 => metà = 45
            Assert.Equal(35, lamp.Intensity);
        }

        [Fact]
        public void TurnOff_AfterTurnOn_ResultsInOffAndZeroBrightness()
        {
            var lamp = new EcoLamp();
            lamp.SwitchOn();
            lamp.SwitchOff();
            Assert.False(lamp.IsOn);
            Assert.Equal(0, lamp.Intensity);
        }

        [Fact]
        public void ChangeBrightness_WhileOff_DoesNotChangeBrightness()
        {
            var lamp = new EcoLamp();
            lamp.ChangeBrightness(83);
            Assert.Equal(0, lamp.Intensity);
        }

        [Fact]
        public void ChangeBrightness_WhileOn_IncreasesBrightnessByValue()
        {
            var lamp = new EcoLamp();
            lamp.SwitchOn(); // 35
            lamp.ChangeBrightness(10);
            Assert.Equal(45, lamp.Intensity);
        }

        [Fact]
        public void ChangeBrightness_WhileOn_ExceedsMaxGoesToMax()
        {
            var lamp = new EcoLamp();
            lamp.SwitchOn(); // 35
            lamp.ChangeBrightness(100);
            // non può superare MaxBrightness di default (70)
            Assert.Equal(70, lamp.Intensity);
        }

        [Fact]
        public void ChangeBrightness_WhileOn_DecreasesBrightnessByValue()
        {
            var lamp = new EcoLamp();
            lamp.SwitchOn(); // 35
            lamp.ChangeBrightness(-10);
            Assert.Equal(25, lamp.Intensity);
        }

        [Fact]
        public void ChangeBrightness_WhileOn_DecreaseBelowMinimumSetsToOne()
        {
            var lamp = new EcoLamp();
            lamp.SwitchOn(); // 35
            lamp.ChangeBrightness(-50);
            Assert.Equal(1, lamp.Intensity);
        }

        [Fact]
        public void ChangeBrightness_Sequence_ProducesExpectedResult()
        {
            var lamp = new EcoLamp();
            lamp.SwitchOn(); // 35
            lamp.ChangeBrightness(-10); // 25
            lamp.ChangeBrightness(15); // 40
            Assert.Equal(40, lamp.Intensity);
        }

        [Fact]
        public void ChangeMaxBrightness_UpdatesMaxValue()
        {
            var lamp = new EcoLamp();
            lamp.ChangeMaxBrightness(70);
            Assert.Equal(70, lamp.MaxIntensity);
        }

        [Fact]
        public void ChangeMaxBrightness_AboveLimit_IsCapped()
        {
            var lamp = new EcoLamp();
            lamp.ChangeMaxBrightness(200);
            // cap massimo per la lampada eco = 70
            Assert.Equal(70, lamp.MaxIntensity);
        }

        [Fact]
        public void ChangeMaxBrightness_WhileOn_AdjustsBrightnessToNewHalf()
        {
            var lamp = new EcoLamp();
            lamp.SwitchOn(); // 35
            lamp.ChangeMaxBrightness(60); // nuova metà = 30
            Assert.Equal(30, lamp.Intensity);
        }
    }
}
