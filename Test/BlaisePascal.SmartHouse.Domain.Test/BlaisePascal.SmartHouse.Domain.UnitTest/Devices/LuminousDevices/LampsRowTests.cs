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
            Assert.Throws<ArgumentOutOfRangeException>(() => TestLampsRow.AddLampIn(0, lamp2));
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
        public void LampsRow_RemoveLampBy_RemoveALampByNameNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => TestLampsRow.RemoveLampBy(DeviceName.NewDeviceName("NonExistingLamp")));
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
            TestLampsRow.SwitchOn();
            TestLampsRow.SetIntensityTo(new Intensity(50));
            Assert.Equal(new Intensity(50).Percentage, lamp1.Intensity.Percentage);
            Assert.Equal(new Intensity(50).Percentage, lamp2.Intensity.Percentage);
        }

        [Fact]
        public void LampsRow_SetIntensityTo_SetIntensityToAllLampsWithSomeOff()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
            TestLampsRow.SwitchOn();
            TestLampsRow.SetIntensityTo(new Intensity(51));
            Assert.Equal(new Intensity(51).Percentage, lamp1.Intensity.Percentage);
            Assert.Equal(new Intensity(50).Percentage, lamp2.Intensity.Percentage);
        }

        [Fact]
        public void LampsRow_SetIntensityTo_SetIntensityToAllLampsWithAllOff()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
			TestLampsRow.SetIntensityTo(new Intensity(50));
            Assert.Equal(new Intensity(50).Percentage, lamp1.Intensity.Percentage);
            Assert.Equal(new Intensity(50).Percentage, lamp2.Intensity.Percentage);
        }

        [Fact]
        public void LampsRow_SetIntensityForLampBy_SetIntensityForLampByGuid()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
			TestLampsRow.SetIntensityForLampBy(lamp1.ID, new Intensity(70));
            Assert.Equal(new Intensity(70).Percentage, lamp1.Intensity.Percentage);
            Assert.Equal(new Intensity(50).Percentage, lamp2.Intensity.Percentage);
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
			TestLampsRow.SwitchOn();
			TestLampsRow.SetIntensityForLampBy(DeviceName.NewDeviceName("Lamp1"), new Intensity(70));
            Assert.Equal(new Intensity(70).Percentage, lamp1.Intensity.Percentage);
            Assert.Equal(new Intensity(50).Percentage, lamp2.Intensity.Percentage);
        }

        [Fact]
        public void LampsRow_SetIntensityForLampBy_SetIntensityForLampByNameNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => TestLampsRow.SetIntensityForLampBy(DeviceName.NewDeviceName("NonExistingLamp"), new Intensity(70)));
        }

        [Fact]
        public void LampsRow_SetIntensityForLampBy_SetIntensityForLampByNameWithMultipleLampsWithSameName()
        {
            Lamp lamp1 = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("Lamp1"));
            Lamp lamp2 = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("Lamp2"));
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
			TestLampsRow.SetIntensityForLampBy(DeviceName.NewDeviceName("Lamp1"), new Intensity(70));
            Assert.Equal(new Intensity(70).Percentage, lamp1.Intensity.Percentage);
            Assert.Equal(new Intensity(50).Percentage, lamp2.Intensity.Percentage);
        }

        [Fact]
        public void LampsRow_IncreaseBy_IncreaseIntensityByAllLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
			TestLampsRow.IncreaseBy();
            Assert.Equal(new Intensity(60).Percentage, lamp1.Intensity.Percentage);
            Assert.Equal(new Intensity(60).Percentage, lamp2.Intensity.Percentage);
        }

        [Fact]
        public void LampsRow_DecreaseBy_DecreaseIntensityByAllLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
			TestLampsRow.DecreaseBy();
            Assert.Equal(Intensity.NewIntensity(40).Percentage, lamp1.Intensity.Percentage);
            Assert.Equal(Intensity.NewIntensity(40).Percentage, lamp2.Intensity.Percentage);
        }

        [Fact]
        public void LampsRow_FindLampWithMaxIntensity_FindLampWithMaxIntensity()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
			TestLampsRow.IncreaseBy();
            List<Lamp>? maxLamps = TestLampsRow.FindLampWithMaxIntensity();
            Assert.Null(maxLamps);
        }

        [Fact]
        public void LampsRow_FindLampWithMaxIntensity_FindMultipleLampsWithMaxIntensity()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
			TestLampsRow.IncreaseBy();
            TestLampsRow.IncreaseBy();
            List<Lamp>? maxLamps = TestLampsRow.FindLampWithMaxIntensity();
            Assert.Null(maxLamps);
        }

        [Fact]
        public void LampsRow_FindLampWithMaxIntensity_FindLampsWithMaxIntensity()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
            TestLampsRow.SetIntensityTo(new Intensity(100));
			List<Lamp>? maxLamps = TestLampsRow.FindLampWithMaxIntensity();
            Assert.NotNull(maxLamps);
            Assert.Equal(2, maxLamps.Count);
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
			TestLampsRow.SwitchOn();
			List<Lamp>? minLamps = TestLampsRow.FindLampWithMinIntensity();
            Assert.Null(minLamps);
        }

        [Fact]
        public void LampsRow_FindLampsByIntensityRange_FindLampsByIntensityRange()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
			TestLampsRow.IncreaseBy();
            List<Lamp>? lampsInRange = TestLampsRow.FindLampsByIntensityRange(50, 70);
            Assert.NotNull(lampsInRange);
            Assert.Equal(2, lampsInRange.Count);
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
			TestLampsRow.SwitchOn();
            TestLampsRow.SetIntensityTo(new Intensity(80));
			List<Lamp>? lampsInRange = TestLampsRow.FindLampsByIntensityRange(50, 70);
            Assert.Null(lampsInRange);
        }

        [Fact]
        public void LampsRow_FindAllOn_FindAllOnLamps()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
			List<Lamp>? onLamps = TestLampsRow.FindAllOn();
            Assert.NotNull(onLamps);
            Assert.Equal(2, onLamps.Count);
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
            Assert.Null(onLamps);
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
			TestLampsRow.SwitchOn();
			List<Lamp>? offLamps = TestLampsRow.FindAllOff();
            Assert.Null(offLamps);
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
        public void LampsRow_SortByIntensity_SortLampsByIntensity()
        {
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            TestLampsRow.AddLamp(lamp1);
            TestLampsRow.AddLamp(lamp2);
			TestLampsRow.SwitchOn();
			TestLampsRow.IncreaseBy();
            TestLampsRow.SetIntensityForLampBy(lamp2.ID, new Intensity(70));
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
