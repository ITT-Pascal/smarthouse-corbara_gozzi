using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampsRowTest
    {

        List<AbstractLamp> lampList = new List<AbstractLamp>();
        LampsRow newLampsRow = new LampsRow();

        [Fact]
        public void LampsRow_WhenCreated_IsEmpty()
        {
            Assert.Empty(newLampsRow._lampsRow);
        }


        [Fact]
        public void LampsRow_AddNewLamp_AddANewEcoLamp()
        {
            newLampsRow.AddLamp(new EcoLamp());

            Assert.IsType<EcoLamp>(newLampsRow._lampsRow[0]);
        }

        [Fact]
        public void LampsRow_AddANewLamp_CanAddANewLamp()
        {

            newLampsRow.AddLamp(new Lamp());

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
            newLampsRow.AddLamp(new EcoLamp());
            newLampsRow.AddLamp(new Lamp());
            newLampsRow.RemoveLamp(1);

            Assert.IsType<Lamp>(newLampsRow._lampsRow[0]);
        }

        [Fact]
        public void LampsRow_RemoveLamp_RemoveAll()
        {
            newLampsRow.AddLamp(new EcoLamp());
            newLampsRow.AddLamp(new Lamp());
            newLampsRow.RemoveLamp(1);
            newLampsRow.RemoveLamp(1);

            Assert.Empty(newLampsRow._lampsRow);
        }

        [Fact]

        public void LampsRow_TurnOnAllLamps_AllLampsAreOn()
        {
            newLampsRow.AddLamp(new EcoLamp());
            newLampsRow.AddLamp(new Lamp());
            newLampsRow.TurnOnAllLamps();
            Assert.True(newLampsRow._lampsRow[0].IsOn);
            Assert.True(newLampsRow._lampsRow[1].IsOn);
        }

        [Fact]

        public void LampsRow_TurnOffAllLamps_AllLampsAreOff()
        {
            newLampsRow.AddLamp(new EcoLamp());
            newLampsRow.AddLamp(new Lamp());
            newLampsRow.TurnOnAllLamps();
            newLampsRow.TurnOffAllLamps();
            Assert.False(newLampsRow._lampsRow[0].IsOn);
            Assert.False(newLampsRow._lampsRow[1].IsOn);
        }      
    }
}
