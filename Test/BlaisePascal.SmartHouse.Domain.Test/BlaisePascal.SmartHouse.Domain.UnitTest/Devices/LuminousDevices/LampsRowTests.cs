using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.LuminousDevices
{
    public class LampsRowTests
    {
        LampsRow TestLampsRow = new LampsRow();

        [Fact]
        public void LampsRow_WhenCreated_IsEmpty()
        {
            Assert.Empty(TestLampsRow.LampRow);
        }

        [Fact]
        public void LapsRow_CheckIsNotNull_ThrowExceptionIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => TestLampsRow.CheckIsNotNull(null));
        }

        [Fact]
        public void LampsRow_SwitchOnByGuid_SwitchOnTheLampWithThatGuid()
        {
            Lamp lamp = new Lamp();
            TestLampsRow.AddLamp(lamp);
            TestLampsRow.SwitchOnBy(lamp.ID);
            Assert.Equal(DeviceStatus.On, lamp.DeviceStatus);
        }

        [Fact]
        public void LampsRow_SwitchOffByGuid_SwitchOffTheLampWithThatGuid()
        {
            Lamp lamp = new Lamp();
            TestLampsRow.AddLamp(lamp);
            TestLampsRow.SwitchOnBy(lamp.ID);
            TestLampsRow.SwitchOffBy(lamp.ID);
            Assert.Equal(DeviceStatus.Off, lamp.DeviceStatus);
        }

        [Fact]
        public void LampsRow_SwitchOnByGuid_ThrowExceptionIfGuidNotFound()
        {
            Assert.Throws<ArgumentException>(() => TestLampsRow.SwitchOnBy(Guid.NewGuid()));
        }

        [Fact]
        public void LampsRow_SwitchOffByGuid_ThrowExceptionIfGuidNotFound()
        {
            Assert.Throws<ArgumentException>(() => TestLampsRow.SwitchOffBy(Guid.NewGuid()));
        }

        [Fact]
        public void LapmsRow_Toggle_ToggleTheStatusOfAllLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.Toggle();
            Assert.Equal(DeviceStatus.On, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.On, lamp2.DeviceStatus);
            TestLampsRow.Toggle();
            Assert.Equal(DeviceStatus.Off, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, lamp2.DeviceStatus);
        }

        [Fact]
        public void LampsRow_Toggle_ThrowExceptionIfNoLamps()
        {
            Assert.Throws<InvalidOperationException>(() => TestLampsRow.Toggle());
        }

        [Fact]
        public void LampsRow_AddLamp_AddANewLamp()
        {
            Lamp lamp = new Lamp();
            TestLampsRow.AddLamp(lamp);
            Assert.Single(TestLampsRow.LampRow);
            Assert.IsType<Lamp>(TestLampsRow.LampRow[0]);
        }

        [Fact]
        public void LampsRow_AddLamp_AddANewEcoLamp()
        {
            EcoLamp eco = new EcoLamp();
            TestLampsRow.AddLamp(eco);
            Assert.Single(TestLampsRow.LampRow);
            Assert.IsType<EcoLamp>(TestLampsRow.LampRow[0]);
        }

        [Fact]
        public void LampsRow_AddLamp_AddANewEcoLampAndALamp()
        {
            TestLampsRow.AddLamp(new EcoLamp());
            TestLampsRow.AddLamp(new Lamp());
            Assert.Equal(2, TestLampsRow.LampRow.Count);
            Assert.IsType<EcoLamp>(TestLampsRow.LampRow[0]);
            Assert.IsType<Lamp>(TestLampsRow.LampRow[1]);
        }

        [Fact]
        public void LampsRow_AddLamp_AddANewEcoLampAndALampAndAddSameLamp()
        {
            Lamp lamp = new Lamp();
            TestLampsRow.AddLamp(new EcoLamp());
            TestLampsRow.AddLamp(lamp);
            TestLampsRow.AddLamp(lamp);
            Assert.Equal(3, TestLampsRow.LampRow.Count);
            Assert.IsType<EcoLamp>(TestLampsRow.LampRow[0]);
            Assert.IsType<Lamp>(TestLampsRow.LampRow[1]);
            Assert.IsType<Lamp>(TestLampsRow.LampRow[2]);
        }

        [Fact]
        public void LampsRow_AddLampIn_AddALampInAPosition()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLampIn(0, lamp1);
            TestLampsRow.AddLampIn(0, lamp2);
            Assert.Equal(2, TestLampsRow.LampRow.Count);
            Assert.IsType<Lamp>(TestLampsRow.LampRow[0]);
            Assert.IsType<Lamp>(TestLampsRow.LampRow[1]);
            Assert.Equal(lamp2.ID, TestLampsRow.LampRow[0].ID);
            Assert.Equal(lamp1.ID, TestLampsRow.LampRow[1].ID);
        }

        [Fact]
        public void LampsRow_AddLampIn_AddALampInAPositionOutOfRange()
        {
            Lamp lamp = new Lamp();
            Assert.Throws<ArgumentOutOfRangeException>(() => TestLampsRow.AddLampIn(1, lamp));
        }

        [Fact]
        public void LampsRow_AddLampIn_AddALampInAPositionAlreadyOccupied()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLampIn(0, lamp1);
            Assert.Throws<ArgumentException>(() => TestLampsRow.AddLampIn(0, lamp2));
        }

        [Fact]
        public void LampsRow_RemoveLampBy_RemoveALampByGuid()
        {
            Lamp lamp = new Lamp();
            TestLampsRow.AddLamp(lamp);
            TestLampsRow.RemoveLampBy(lamp.ID);
            Assert.Empty(TestLampsRow.LampRow);
        }

        [Fact]
        public void LampsRow_RemoveLampBy_RemoveALampByGuidNotFound()
        {
            Assert.Throws<ArgumentException>(() => TestLampsRow.RemoveLampBy(Guid.NewGuid()));
        }

        [Fact]
        public void LampsRow_RemoveLampBy_RemoveALampByName()
        {
            Lamp lamp = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("Lamp1"));
            TestLampsRow.AddLamp(lamp);
            TestLampsRow.RemoveLampBy(DeviceName.NewDeviceName("Lamp1"));
            Assert.Empty(TestLampsRow.LampRow);
        }

        [Fact]
        public void LampsRow_RemoveLampBy_RemoveALampByNameNotFound()
        {
            Assert.Throws<ArgumentException>(() => TestLampsRow.RemoveLampBy(DeviceName.NewDeviceName("NonExistingLamp")));
        }

        [Fact]
        public void LampsRow_RemoveLampBy_RemoveALampByNameWithMultipleLampsWithSameName()
        {
            Lamp lamp1 = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("Lamp1"));
            Lamp lamp2 = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("Lamp1"));
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.RemoveLampBy(DeviceName.NewDeviceName("Lamp1"));
            Assert.Single(TestLampsRow.LampRow);
            Assert.Equal(lamp2.ID, TestLampsRow.LampRow[0].ID);
        }

        [Fact]
        public void LampsRow_RemoveLampAt_RemoveALampAtPosition()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.RemoveLampAt(0);
            Assert.Single(TestLampsRow.LampRow);
            Assert.Equal(lamp2.ID, TestLampsRow.LampRow[0].ID);
        }

        [Fact]
        public void LampsRow_RemoveLampAt_RemoveALampAtPositionOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TestLampsRow.RemoveLampAt(0));
        }

        [Fact]
        public void LampsRow_SetIntensityTo_SetIntensityToAllLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.SetIntensityTo(new Intensity(50));
            Assert.Equal(new Intensity(50), lamp1.Intensity);
            Assert.Equal(new Intensity(50), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_SetIntensityTo_SetIntensityToAllLampsWithSomeOff()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            TestLampsRow.SetIntensityTo(new Intensity(50));
            Assert.Equal(new Intensity(50), lamp1.Intensity);
            Assert.Equal(Intensity.NewMinIntensity(), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_SetIntensityTo_SetIntensityToAllLampsWithAllOff()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.SetIntensityTo(new Intensity(50));
            Assert.Equal(Intensity.NewMinIntensity(), lamp1.Intensity);
            Assert.Equal(Intensity.NewMinIntensity(), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_SetIntensityForLampBy_SetIntensityForLampByGuid()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.SetIntensityForLampBy(lamp1.ID, new Intensity(70));
            Assert.Equal(new Intensity(70), lamp1.Intensity);
            Assert.Equal(Intensity.NewMinIntensity(), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_SetIntensityForLampBy_SetIntensityForLampByGuidNotFound()
        {
            Assert.Throws<ArgumentException>(() => TestLampsRow.SetIntensityForLampBy(Guid.NewGuid(), new Intensity(70)));
        }

        [Fact]
        public void LampsRow_SetIntensityForLampBy_SetIntensityForLampByName()
        {
            Lamp lamp1 = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("Lamp1"));
            Lamp lamp2 = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("Lamp2"));
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.SetIntensityForLampBy(DeviceName.NewDeviceName("Lamp1"), new Intensity(70));
            Assert.Equal(new Intensity(70), lamp1.Intensity);
            Assert.Equal(Intensity.NewMinIntensity(), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_SetIntensityForLampBy_SetIntensityForLampByNameNotFound()
        {
            Assert.Throws<ArgumentException>(() => TestLampsRow.SetIntensityForLampBy(DeviceName.NewDeviceName("NonExistingLamp"), new Intensity(70)));
        }

        [Fact]
        public void LampsRow_SetIntensityForLampBy_SetIntensityForLampByNameWithMultipleLampsWithSameName()
        {
            Lamp lamp1 = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("Lamp1"));
            Lamp lamp2 = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("Lamp1"));
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.SetIntensityForLampBy(DeviceName.NewDeviceName("Lamp1"), new Intensity(70));
            Assert.Equal(new Intensity(70), lamp1.Intensity);
            Assert.Equal(Intensity.NewMinIntensity(), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_IncreaseBy_IncreaseIntensityByAllLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            lamp2.SwitchOn();
            TestLampsRow.IncreaseBy();
            Assert.Equal(new Intensity(60), lamp1.Intensity);
            Assert.Equal(new Intensity(60), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_IncreaseBy_IncreaseIntensityByAllLampsWithSomeOff()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            TestLampsRow.IncreaseBy();
            Assert.Equal(new Intensity(60), lamp1.Intensity);
            Assert.Equal(Intensity.NewMinIntensity(), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_IncreaseBy_IncreaseIntensityByAllLampsWithAllOff()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.IncreaseBy();
            Assert.Equal(Intensity.NewMinIntensity(), lamp1.Intensity);
            Assert.Equal(Intensity.NewMinIntensity(), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_DecreaseBy_DecreaseIntensityByAllLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            lamp2.SwitchOn();
            TestLampsRow.DecreaseBy();
            Assert.Equal(new Intensity(40), lamp1.Intensity);
            Assert.Equal(new Intensity(40), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_DecreaseBy_DecreaseIntensityByAllLampsWithSomeOff()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            TestLampsRow.DecreaseBy();
            Assert.Equal(new Intensity(40), lamp1.Intensity);
            Assert.Equal(Intensity.NewMinIntensity(), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_DecreaseBy_DecreaseIntensityByAllLampsWithAllOff()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.DecreaseBy();
            Assert.Equal(Intensity.NewMinIntensity(), lamp1.Intensity);
            Assert.Equal(Intensity.NewMinIntensity(), lamp2.Intensity);
        }

        [Fact]
        public void LampsRow_FindLampWithMaxIntensity_FindLampWithMaxIntensity()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            lamp2.SwitchOn();
            TestLampsRow.IncreaseBy();
            List<Lamp>? maxLamps = TestLampsRow.FindLampWithMaxIntensity();
            Assert.NotNull(maxLamps);
            Assert.Single(maxLamps);
            Assert.Equal(lamp1.ID, maxLamps[0].ID);
        }

        [Fact]
        public void LampsRow_FindLampWithMaxIntensity_FindMultipleLampsWithMaxIntensity()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            lamp2.SwitchOn();
            TestLampsRow.IncreaseBy();
            TestLampsRow.IncreaseBy();
            List<Lamp>? maxLamps = TestLampsRow.FindLampWithMaxIntensity();
            Assert.NotNull(maxLamps);
            Assert.Equal(2, maxLamps.Count);
            Assert.Contains(maxLamps, lamp => lamp.ID == lamp1.ID);
            Assert.Contains(maxLamps, lamp => lamp.ID == lamp2.ID);
        }

        [Fact]
        public void LampsRow_FindLampWithMaxIntensity_FindNoLampsWithMaxIntensity()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            List<Lamp>? maxLamps = TestLampsRow.FindLampWithMaxIntensity();
            Assert.NotNull(maxLamps);
            Assert.Empty(maxLamps);
        }

        [Fact]
        public void LampsRow_FindLampWithMinIntensity_FindLampWithMinIntensity()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            List<Lamp>? minLamps = TestLampsRow.FindLampWithMinIntensity();
            Assert.NotNull(minLamps);
            Assert.Equal(2, minLamps.Count);
            Assert.Contains(minLamps, lamp => lamp.ID == lamp1.ID);
            Assert.Contains(minLamps, lamp => lamp.ID == lamp2.ID);
        }

        [Fact]
        public void LampsRow_FindLampWithMinIntensity_FindMultipleLampsWithMinIntensity()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            List<Lamp>? minLamps = TestLampsRow.FindLampWithMinIntensity();
            Assert.NotNull(minLamps);
            Assert.Equal(2, minLamps.Count);
            Assert.Contains(minLamps, lamp => lamp.ID == lamp1.ID);
            Assert.Contains(minLamps, lamp => lamp.ID == lamp2.ID);
        }

        [Fact]
        public void LampsRow_FindLampWithMinIntensity_FindNoLampsWithMinIntensity()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            lamp2.SwitchOn();
            List<Lamp>? minLamps = TestLampsRow.FindLampWithMinIntensity();
            Assert.NotNull(minLamps);
            Assert.Empty(minLamps);
        }

        [Fact]
        public void LampsRow_FindLampsByIntensityRange_FindLampsByIntensityRange()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            TestLampsRow.IncreaseBy();
            List<Lamp>? lampsInRange = TestLampsRow.FindLampsByIntensityRange(50, 70);
            Assert.NotNull(lampsInRange);
            Assert.Single(lampsInRange);
            Assert.Equal(lamp1.ID, lampsInRange[0].ID);
        }

        [Fact]
        public void LampsRow_FindLampsByIntensityRange_FindMultipleLampsByIntensityRange()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            lamp2.SwitchOn();
            TestLampsRow.IncreaseBy();
            List<Lamp>? lampsInRange = TestLampsRow.FindLampsByIntensityRange(50, 70);
            Assert.NotNull(lampsInRange);
            Assert.Equal(2, lampsInRange.Count);
            Assert.Contains(lampsInRange, lamp => lamp.ID == lamp1.ID);
            Assert.Contains(lampsInRange, lamp => lamp.ID == lamp2.ID);
        }

        [Fact]
        public void LampsRow_FindLampsByIntensityRange_FindNoLampsByIntensityRange()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            List<Lamp>? lampsInRange = TestLampsRow.FindLampsByIntensityRange(50, 70);
            Assert.NotNull(lampsInRange);
            Assert.Empty(lampsInRange);
        }

        [Fact]
        public void LampsRow_FindAllOn_FindAllOnLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            List<Lamp>? onLamps = TestLampsRow.FindAllOn();
            Assert.NotNull(onLamps);
            Assert.Single(onLamps);
            Assert.Equal(lamp1.ID, onLamps[0].ID);
        }

        [Fact]
        public void LampsRow_FindAllOn_FindMultipleOnLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            lamp2.SwitchOn();
            List<Lamp>? onLamps = TestLampsRow.FindAllOn();
            Assert.NotNull(onLamps);
            Assert.Equal(2, onLamps.Count);
            Assert.Contains(onLamps, lamp => lamp.ID == lamp1.ID);
            Assert.Contains(onLamps, lamp => lamp.ID == lamp2.ID);
        }

        [Fact]
        public void LampsRow_FindAllOn_FindNoOnLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            List<Lamp>? onLamps = TestLampsRow.FindAllOn();
            Assert.NotNull(onLamps);
            Assert.Empty(onLamps);
        }

        [Fact]
        public void LampsRow_FindAllOff_FindAllOffLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            List<Lamp>? offLamps = TestLampsRow.FindAllOff();
            Assert.NotNull(offLamps);
            Assert.Single(offLamps);
            Assert.Equal(lamp2.ID, offLamps[0].ID);
        }

        [Fact]
        public void LampsRow_FindAllOff_FindMultipleOffLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            List<Lamp>? offLamps = TestLampsRow.FindAllOff();
            Assert.NotNull(offLamps);
            Assert.Equal(2, offLamps.Count);
            Assert.Contains(offLamps, lamp => lamp.ID == lamp1.ID);
            Assert.Contains(offLamps, lamp => lamp.ID == lamp2.ID);
        }

        [Fact]
        public void LampsRow_FindAllOff_FindNoOffLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            lamp2.SwitchOn();
            List<Lamp>? offLamps = TestLampsRow.FindAllOff();
            Assert.NotNull(offLamps);
            Assert.Empty(offLamps);
        }

        [Fact]
        public void LampsRow_FindLampBy_FindLampByGuid()
        {
            Lamp lamp = new Lamp();
            TestLampsRow.AddLamp(lamp);
            Lamp foundLamp = TestLampsRow.FindLampBy(lamp.ID);
            Assert.Equal(lamp.ID, foundLamp.ID);
        }

        [Fact]
        public void LampsRow_FindLampBy_FindLampByGuidNotFound()
        {
            Assert.Throws<ArgumentException>(() => TestLampsRow.FindLampBy(Guid.NewGuid()));
        }

        [Fact]
        public void LampsRow_SortByIntensity_SortLampsByIntensity()//?
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            TestLampsRow.IncreaseBy();
            TestLampsRow.SortByIntensity(true);
            Assert.Equal(lamp2.ID, TestLampsRow.LampRow[0].ID);
            Assert.Equal(lamp1.ID, TestLampsRow.LampRow[1].ID);
        }

        [Fact]
        public void LampsRow_SortByIntensity_SortLampsByIntensityWithSomeOff() //?
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            lamp1.SwitchOn();
            TestLampsRow.IncreaseBy();
            TestLampsRow.SortByIntensity(true);
            Assert.Equal(lamp2.ID, TestLampsRow.LampRow[0].ID);
            Assert.Equal(lamp1.ID, TestLampsRow.LampRow[1].ID);
        }

        [Fact]
        public void LampsRow_SortByIntensity_SortLampsByIntensityWithAllOff()//?
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.SortByIntensity(true);
            Assert.Equal(lamp1.ID, TestLampsRow.LampRow[0].ID);
            Assert.Equal(lamp2.ID, TestLampsRow.LampRow[1].ID);
        }
    }
}
