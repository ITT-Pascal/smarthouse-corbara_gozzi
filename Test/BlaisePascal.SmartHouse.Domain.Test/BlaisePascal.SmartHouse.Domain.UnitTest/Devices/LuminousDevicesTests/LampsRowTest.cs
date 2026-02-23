using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.LuminousDevicesTests
{
    public class LampsRowTest
    {
        LampsRow TestLampsRow = new LampsRow();

        [Fact]
        public void LampsRow_WhenCreated_IsEmpty()
        {
            Assert.Empty(TestLampsRow.LampRow);
        }

        [Fact]
        public void LampsRow_AddNewLamp_AddANewEcoLamp()
        {
            EcoLamp eco = new EcoLamp();
            TestLampsRow.AddLamp(eco);
            Assert.Single(TestLampsRow.LampRow);
            Assert.IsType<EcoLamp>(TestLampsRow.LampRow[0]);
        }

        [Fact]
        public void LampsRow_AddANewLamp_CanAddANewLamp()
        {
            Lamp lamp = new Lamp();
            TestLampsRow.AddLamp(lamp);
            Assert.Single(TestLampsRow.LampRow);
            Assert.IsType<Lamp>(TestLampsRow.LampRow[0]);
        }

        [Fact]
        public void LampsRow_AddNewLamp_AddANewEcoLampAndALamp()
        {
            TestLampsRow.AddLamp(new EcoLamp());
            TestLampsRow.AddLamp(new Lamp());
            Assert.Equal(2, TestLampsRow.LampRow.Count);
            Assert.IsType<EcoLamp>(TestLampsRow.LampRow[0]);
            Assert.IsType<Lamp>(TestLampsRow.LampRow[1]);
        }

        [Fact]
        public void LampsRow_AddLampInPosition_WeAddALampNamedBrasoInPos1()
        {
            TestLampsRow.AddLamp(new EcoLamp());
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.AddLampInPositio(new Lamp("Braso"), 1);
            Assert.Equal("Braso", TestLampsRow.LampRow[1].Name);
        }

        [Fact]
        public void LampsRow_RemoveLamp_RemoveTheLampFromName()
        {
            TestLampsRow.AddLamp(new EcoLamp());
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.RemoveLamp("Ciao");
            Assert.Equal("Sas", TestLampsRow.LampRow[0].Name);
            Assert.Single(TestLampsRow.LampRow);
        }

        [Fact]
        public void LampsRow_RemoveLamp_RemoveTheLampFromGuid()
        {
            Guid testId = new Guid();
            Guid testId2 = new Guid();
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.RemoveLampBy(testId);
            Assert.Single(TestLampsRow.LampRow);
            Assert.Equal(testId2, TestLampsRow.LampRow[0].ID);
        }

        [Fact]
        public void LampsRow_RemoveLampInPosition_RemoveTheLampInPosition1()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.RemoveLampAt(1);
            Assert.Single(TestLampsRow.LampRow);
            Assert.Equal("lamp", TestLampsRow.LampRow[0].Name);
        }

        [Fact]
        public void LampsRow_SwitchOn_SwitchOnAllLamps()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn();
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[1].DeviceStatus);
        }

        [Fact]
        public void LampsRow_SwitchOn_SwitchOnLampFromID()
        {
            Guid testId = new Guid();
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOnBy(testId);
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[1].DeviceStatus);
        }

        [Fact]
        public void LampsRow_SwitchOn_SwitchOnLampFromName()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn("Sas");
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[1].DeviceStatus);
        }

        [Fact]
        public void LampsRow_SwitchOn_SwitchOnMultipleLampsFromName()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn("Sas");
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[1].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[2].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[1].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[1].DeviceStatus);
        }

        [Fact]
        public void LampsRow_SwitchOff_SwitchOffAllLamps()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn();
            TestLampsRow.SwitchOff();
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[0].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[1].DeviceStatus);
        }

        [Fact]
        public void LampsRow_SwitchOff_SwitchOffLampFromID()
        {
            Guid testId = new Guid();
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn();
            TestLampsRow.SwitchOffBy(testId);
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[0].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[1].DeviceStatus);
        }

        [Fact]
        public void LampsRow_SwitchOff_SwitchOffLampFromName()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn();
            TestLampsRow.SwitchOff("Sas");
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[0].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[1].DeviceStatus);
        }

        [Fact]
        public void LampsRow_SwitchOff_SwitchOffMultipleLampsFromName()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn();
            TestLampsRow.SwitchOff("Sas");
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[0].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[1].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[2].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[1].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestLampsRow.LampRow[1].DeviceStatus);
        }

        [Fact]
        public void LampsRow_SetIntensityForAllLamps_IfLampsAreOffIntensityIsNotSet()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn();
            TestLampsRow.SetIntensityForAllLamps(10);
            Assert.Equal(10, TestLampsRow.LampRow[0].Intensity);
            Assert.Equal(10, TestLampsRow.LampRow[1].Intensity);
        }

        [Fact]
        public void LampsRow_SetIntensityForAllLamps_SetIntensityForAllLamps()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn();
            TestLampsRow.SetIntensityForAllLamps(10);
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestLampsRow.LampRow[1].DeviceStatus);
            Assert.Equal(10, TestLampsRow.LampRow[0].Intensity);
            Assert.Equal(10, TestLampsRow.LampRow[1].Intensity);
        }

        [Fact]
        public void LampsRow_SetIntensityForLamp_SetIntensityOfLampFromID()
        {
            Guid testId = new Guid();
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn();
            TestLampsRow.SetIntensityForLamp(10, testId);
            Assert.Equal(50, TestLampsRow.LampRow[0].Intensity);
            Assert.Equal(10, TestLampsRow.LampRow[1].Intensity);
        }

        [Fact]
        public void LampsRow_SetIntensityForLamp_SetIntensityOfLampFromName()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn();
            TestLampsRow.SetIntensityForLamp(10, "Sas");
            Assert.Equal(50, TestLampsRow.LampRow[0].Intensity);
            Assert.Equal(10, TestLampsRow.LampRow[1].Intensity);
        }

        [Fact]
        public void LampsRow_SetIntensityForLamp_SwitchOffMultipleLampsFromName()
        {
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.AddLamp(new Lamp("lamp"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.AddLamp(new Lamp("Sas"));
            TestLampsRow.SwitchOn();
            TestLampsRow.SetIntensityForLamp(20, "Sas");
            Assert.Equal(50, TestLampsRow.LampRow[0].Intensity);
            Assert.Equal(20, TestLampsRow.LampRow[1].Intensity);
            Assert.Equal(50, TestLampsRow.LampRow[2].Intensity);
            Assert.Equal(20, TestLampsRow.LampRow[3].Intensity);
            Assert.Equal(20, TestLampsRow.LampRow[4].Intensity);
        }
    }
}
