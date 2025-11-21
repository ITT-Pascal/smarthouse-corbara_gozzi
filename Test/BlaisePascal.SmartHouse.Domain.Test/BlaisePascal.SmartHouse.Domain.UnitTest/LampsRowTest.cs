using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampsRowTest
    {

        List<Lamp> lampList = new List<Lamp>();
        LampsRow newLampsRow = new LampsRow();

        [Fact]
        public void LampsRow_WhenCreated_IsEmpty()
        {
            Assert.Empty(newLampsRow._lampsRow);
        }

        [Fact]
        public void LampsRow_AddNewLamp_AddANewEcoLamp()
        {
            var eco = new EcoLamp();
            newLampsRow.AddLamp(eco);

            Assert.IsType<EcoLamp>(newLampsRow._lampsRow[0]);
        }

        [Fact]
        public void LampsRow_AddANewLamp_CanAddANewLamp()
        {
            var lamp = new Lamp();
            newLampsRow.AddLamp(lamp);

            Assert.IsType<Lamp>(newLampsRow._lampsRow[0]);
        }

        [Fact]
        public void LampsRow_AddNewLamp_AddANewEcoLampAndALamp()
        {
            newLampsRow.AddLamp(new EcoLamp());
            newLampsRow.AddLamp(new Lamp());

            Assert.IsType<EcoLamp>(newLampsRow._lampsRow[0]);
            Assert.IsType<Lamp>(newLampsRow._lampsRow[1]);
        }

        [Fact]
        public void LampsRow_RemoveLamp_RemoveTheFirstLamp()
        {
            var eco = new EcoLamp();
            var lamp = new Lamp();
            newLampsRow.AddLamp(eco);
            newLampsRow.AddLamp(lamp);

            newLampsRow.RemoveLampInPosition(0);

            Assert.IsType<Lamp>(newLampsRow._lampsRow[0]);
            
        }

        /*[Fact]
        public void LampsRow_RemoveLamp_RemoveAll()
        {
            newLampsRow.AddLamp(new EcoLamp());
            newLampsRow.AddLamp(new Lamp());
            

            Assert.Empty(newLampsRow._lampsRow);
        }*/

        [Fact]
        public void LampsRow_TurnOnAllLamps_AllLampsAreOn()
        {
            newLampsRow.AddLamp(new EcoLamp());
            newLampsRow.AddLamp(new Lamp());

            newLampsRow.SwitchOn();

            Assert.True(newLampsRow._lampsRow[0].IsOn);
            Assert.True(newLampsRow._lampsRow[1].IsOn);
        }

        /*[Fact]
        public void LampsRow_TurnOffAllLamps_AllLampsAreOff()
        {
            newLampsRow.AddLamp(new EcoLamp());
            newLampsRow.AddLamp(new Lamp());

            newLampsRow.SwitchOff();

            Assert.False(newLampsRow._lampsRow[0].IsOn);
            Assert.False(newLampsRow._lampsRow[1].IsOn);
        }*/

        /*[Fact]
        public void LampsRow_SwitchOnById_OnlyTargetIsOn()
        {
            var lamp1 = new Lamp("L1");
            var lamp2 = new Lamp("L2");
            newLampsRow.AddLamp(lamp1);
            newLampsRow.AddLamp(lamp2);

            newLampsRow.SwitchOn(lamp2.ID);

            Assert.False(newLampsRow._lampsRow.First(l => l.ID == lamp1.ID).IsOn);
            Assert.True(newLampsRow._lampsRow.First(l => l.ID == lamp2.ID).IsOn);
        } */

        /*[Fact]
        public void LampsRow_SwitchOffByName_OnlyTargetIsOff()
        {
            var lamp1 = new Lamp("A");
            var lamp2 = new Lamp("B");
            newLampsRow.AddLamp(lamp1);
            newLampsRow.AddLamp(lamp2);

            newLampsRow.SwitchOn();
            newLampsRow.SwitchOff("A");

            Assert.False(newLampsRow._lampsRow.First(l => l.Name == "A").IsOn);
            Assert.True(newLampsRow._lampsRow.First(l => l.Name == "B").IsOn);
        }*/

        [Fact]
        public void LampsRow_AddLampInPosition_InsertsAtPosition()
        {
            var first = new Lamp("First");
            var second = new Lamp("Second");
            newLampsRow.AddLamp(first);
            newLampsRow.AddLampInPosition(second, 0);

            Assert.Equal("Second", newLampsRow._lampsRow[0].Name);
            Assert.Equal("First", newLampsRow._lampsRow[1].Name);
        }

        /*[Fact]
        public void LampsRow_SetIntensityForAllLamps_SetsBrightness()
        {
            var l1 = new Lamp("X");
            var l2 = new Lamp("Y");
            newLampsRow.AddLamp(l1);
            newLampsRow.AddLamp(l2);

            newLampsRow.SetIntensityForAllLamps(75);
            newLampsRow.SwitchOn();

            Assert.Equal(75, newLampsRow._lampsRow[0].Brightness);
            Assert.Equal(75, newLampsRow._lampsRow[1].Brightness);
        } */

        [Fact]
        public void LampsRow_SetIntensityForLampByName_SetsOnlyTarget()
        {
            var l1 = new Lamp("Alpha");
            var l2 = new Lamp("Beta");
            newLampsRow.AddLamp(l1);
            newLampsRow.AddLamp(l2);

            newLampsRow.SetIntensityForLamp(30, "Beta");

            Assert.Equal(0, newLampsRow._lampsRow.First(l => l.Name == "Alpha").Brightness);
            Assert.Equal(30, newLampsRow._lampsRow.First(l => l.Name == "Beta").Brightness);
        }
    }
}
