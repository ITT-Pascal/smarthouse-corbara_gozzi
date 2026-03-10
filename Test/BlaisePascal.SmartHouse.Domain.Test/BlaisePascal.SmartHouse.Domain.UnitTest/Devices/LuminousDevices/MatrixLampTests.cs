using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.LuminousDevices
{
    public class MatrixLampTests
    {
        [Fact]
        public void MatrixLamp_Constructor_InitializeMatrixWithGivenSize()
        {
            uint rows = 5;
            uint cols = 5;
            MatrixLamp matrixLamp = new MatrixLamp(rows, cols);
            Assert.NotNull(matrixLamp.LampMatrix);
            Assert.Equal(rows, matrixLamp.rowSize);
            Assert.Equal(cols, matrixLamp.colsSize);
        }

        [Fact]
        public void MatrixLamp_Constructor_InitializeMatrixWithDefaultSize()
        {
            MatrixLamp matrixLamp = new MatrixLamp();
            Assert.NotNull(matrixLamp.LampMatrix);
            Assert.Equal(10, (int)matrixLamp.rowSize);
            Assert.Equal(10, (int)matrixLamp.colsSize);
        }

        [Fact]
        public void MatrixLamp_AddLampInPosition_AddsLampToMatrix()
        {
            MatrixLamp matrixLamp = new MatrixLamp(3, 3);
            Lamp lamp = new Lamp();
            matrixLamp.AddLampInPosition(1, 1, lamp);
            Assert.Equal(lamp, matrixLamp.LampMatrix[1, 1]);
        }

        [Fact]
        public void MatrixLamp_AddLampInPosition_ThrowsExceptionWhenPositionIsTaken()
        {
            MatrixLamp matrixLamp = new MatrixLamp(3, 3);
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            matrixLamp.AddLampInPosition(1, 1, lamp1);
            Assert.Throws<ArgumentOutOfRangeException>(() => matrixLamp.AddLampInPosition(1, 1, lamp2));
        }

        [Fact]
        public void MatrixLamp_AddLampInPosition_ThrowsExceptionOutOfRange()
        {
            MatrixLamp matrixLamp = new MatrixLamp(3, 3);
            Lamp lamp = new Lamp();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrixLamp.AddLampInPosition(3, 1, lamp));
            Assert.Throws<ArgumentOutOfRangeException>(() => matrixLamp.AddLampInPosition(1, 3, lamp));
        }

        [Fact]
        public void MatrixLamp_RemoveLampInPosition_RemovesLampFromMatrix()
        {
            MatrixLamp matrixLamp = new MatrixLamp(3, 3);
            Lamp lamp = new Lamp();
            matrixLamp.AddLampInPosition(1, 1, lamp);
            matrixLamp.RemoveLampInPosition(1, 1);
            Assert.Null(matrixLamp.LampMatrix[1, 1]);
        }

        [Fact]
        public void MatrixLamp_RemoveLampInPosition_ThrowsExceptionOutOfRange()
        {
            MatrixLamp matrixLamp = new MatrixLamp(3, 3);
            Assert.Throws<ArgumentOutOfRangeException>(() => matrixLamp.RemoveLampInPosition(3, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => matrixLamp.RemoveLampInPosition(1, 3));
        }

        [Fact]
        public void MatrixLamp_SwitchOn_SwitchesOnAllLampsInMatrix()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2);
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            matrixLamp.AddLampInPosition(0, 0, lamp1);
            matrixLamp.AddLampInPosition(0, 1, lamp2);
            matrixLamp.SwitchOn();
            Assert.Equal(DeviceStatus.On, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.On, lamp2.DeviceStatus);
        }

        [Fact]
        public void MatrixLamp_SwitchOff_SwitchesOffAllLampsInMatrix()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2);
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            matrixLamp.AddLampInPosition(0, 0, lamp1);
            matrixLamp.AddLampInPosition(0, 1, lamp2);
            matrixLamp.SwitchOn();
            matrixLamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, lamp2.DeviceStatus);
        }

        [Fact]
        public void MatrixLamp_Toggle_TogglesAllLampsInMatrix()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2);
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            matrixLamp.AddLampInPosition(0, 0, lamp1);
            matrixLamp.AddLampInPosition(0, 1, lamp2);
            matrixLamp.Toggle();
            Assert.Equal(DeviceStatus.On, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.On, lamp2.DeviceStatus);
            matrixLamp.Toggle();
            Assert.Equal(DeviceStatus.Off, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, lamp2.DeviceStatus);
        }

        [Fact]
        public void MatrixLamp_SwitchOnLikeChessboard_SwitchesOnLampsInChessboardPattern()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2);
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            Lamp lamp3 = new Lamp();
            Lamp lamp4 = new Lamp();
            matrixLamp.AddLampInPosition(0, 0, lamp1);
            matrixLamp.AddLampInPosition(0, 1, lamp2);
            matrixLamp.AddLampInPosition(1, 0, lamp3);
            matrixLamp.AddLampInPosition(1, 1, lamp4);
            matrixLamp.SwitchOnLikeChessboard();
            Assert.Equal(DeviceStatus.On, lamp1.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, lamp2.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, lamp3.DeviceStatus);
            Assert.Equal(DeviceStatus.On, lamp4.DeviceStatus);
        }

        [Fact]
        public void MatrixLamp_SetIntensityTo_SetsIntensityOfAllLampsInMatrix()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2);
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            matrixLamp.AddLampInPosition(0, 0, lamp1);
            matrixLamp.AddLampInPosition(0, 1, lamp2);
            matrixLamp.SetIntensityTo(Intensity.NewIntensity(70));
            Assert.Equal(Intensity.NewIntensity(70), lamp1.Intensity);
            Assert.Equal(Intensity.NewIntensity(70), lamp2.Intensity);
        }

        [Fact]
        public void MatricLamp_SetIntensityInPosition_SetsIntensityOfLampInGivenPosition()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2);
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            matrixLamp.AddLampInPosition(0, 0, lamp1);
            matrixLamp.AddLampInPosition(0, 1, lamp2);
            matrixLamp.SetIntensityInPosition(0, 0, Intensity.NewIntensity(50));
            Assert.Equal(Intensity.NewIntensity(50), lamp1.Intensity);
            Assert.Equal(Intensity.NewIntensity(0), lamp2.Intensity);
        }

        [Fact]
        public void MatricLamp_SetIntensityInPosition_ThrowsExceptionOutOfRange()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2);
            Assert.Throws<ArgumentOutOfRangeException>(() => matrixLamp.SetIntensityInPosition(3, 1, Intensity.NewIntensity(50)));
            Assert.Throws<ArgumentOutOfRangeException>(() => matrixLamp.SetIntensityInPosition(1, 3, Intensity.NewIntensity(50)));
        }

        [Fact]
        public void MatricLamp_SetIntensityInPosition_ThrowsExceptionWhenNoLampInPosition()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2);
            Assert.Throws<ArgumentNullException>(() => matrixLamp.SetIntensityInPosition(0, 0, Intensity.NewIntensity(50)));
        }

        [Fact]
        public void MatrixLamp_IncreaseBy_IncreasesIntensityOfAllLampsInMatrix()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2);
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            matrixLamp.AddLampInPosition(0, 0, lamp1);
            matrixLamp.AddLampInPosition(0, 1, lamp2);
            matrixLamp.SetIntensityTo(Intensity.NewIntensity(50));
            matrixLamp.IncreaseBy();
            Assert.Equal(Intensity.NewIntensity(60), lamp1.Intensity);
            Assert.Equal(Intensity.NewIntensity(60), lamp2.Intensity);
        }

        [Fact]
        public void MatrixLamp_DecreaseBy_DecreasesIntensityOfAllLampsInMatrix()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2);
            Lamp lamp1 = new Lamp();
            Lamp lamp2 = new Lamp();
            matrixLamp.AddLampInPosition(0, 0, lamp1);
            matrixLamp.AddLampInPosition(0, 1, lamp2);
            matrixLamp.SetIntensityTo(Intensity.NewIntensity(50));
            matrixLamp.DecreaseBy();
            Assert.Equal(Intensity.NewIntensity(40), lamp1.Intensity);
            Assert.Equal(Intensity.NewIntensity(40), lamp2.Intensity);
        }

        public void MatrixLamp_CheckIsNotNull_ThrowsExceptionWhenObjectIsNull()
        {
            MatrixLamp matrixLamp = new MatrixLamp();
            Assert.Throws<ArgumentNullException>(() => matrixLamp.CheckIsNotNull(null));
        }
    }
}

    

