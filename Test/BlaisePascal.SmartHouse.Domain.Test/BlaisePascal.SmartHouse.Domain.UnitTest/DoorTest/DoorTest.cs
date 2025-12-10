
using BlaisePascal.SmartHouse.Domain.DoorClasses;
namespace BlaisePascal.SmartHouse.Domain.UnitTest.DoorTest
{
    public class DoorTest
    {
        Door Door = new Door("Braso", new Guid(), 1234, "PASSWORD");

        [Fact]

        public void Door_Constructor_Code()
        {
            Assert.Equal(1234, Door.ReturnCode("PASSWORD"));
        }

        [Fact]

        public void Door_Constructor_CodeAndName()
        {
            Assert.Equal(1234, Door.ReturnCode("PASSWORD"));
            Assert.Equal("Braso", Door.Name);
        }

        [Fact]

        public void Door_Constructor_CodeNameAndGuid()
        {
            Guid id = new Guid();
            Assert.Equal(1234, Door.ReturnCode("PASSWORD"));
            Assert.Equal("Braso", Door.Name);
            Assert.Equal(id,Door.ID);
        }

        [Fact]
        public void Door_OpenDoor_WithCode()
        {
            Door.OpenDoor(1234);
            Assert.Equal(DeviceStatus.Open, Door.DeviceStatus);
        }

        [Fact]
        public void Door_OpenDoor_NoCodeAndClosed()
        {
            Door.UnlockDoor(1234);
            Door.OpenDoor();
            Assert.Equal(DeviceStatus.Open, Door.DeviceStatus);
        }

        [Fact]
        public void Door_OpenDoor_IsJustOpen()
        {
            Door.OpenDoor(1234);
            Door.OpenDoor(1234);
            Assert.Equal(DeviceStatus.Open, Door.DeviceStatus);
        }

        [Fact]
        public void Door_CloseDoor_IsOpen()
        {
            Door.OpenDoor(1234);
            Door.CloseDoor();
            Assert.Equal(DeviceStatus.Closed, Door.DeviceStatus);
        }

        [Fact]
        public void Door_CloseDoor_IsJustClosed()
        {
            Door.OpenDoor(1234);
            Door.CloseDoor();
            Door.CloseDoor();
            Assert.Equal(DeviceStatus.Closed, Door.DeviceStatus);
        }

        [Fact]
        public void Door_LockDoor_IsClosed()
        {
            Door.OpenDoor(1234);
            Door.CloseDoor();
            Door.LockDoor(1234);
            Assert.Equal(DeviceStatus.Locked, Door.DeviceStatus);
        }

        [Fact]
        public void Door_LockDoor_Islocked()
        {           
            Door.UnlockDoor(1234);
            Door.LockDoor(1234);
            Assert.Equal(DeviceStatus.Locked, Door.DeviceStatus);
        }
    }
}
