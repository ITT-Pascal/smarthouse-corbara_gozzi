using BlaisePascal.SmartHouse.Domain.DoorClasses;
namespace BlaisePascal.SmartHouse.Domain.UnitTest.DoorTest
{
    public class DoorTest
    {
        Door door = new Door(1234);
        Door doorWhitName = new Door("Braso", 1234);

        [Fact]

        public void Door_Constructor_Code()
        {
            Assert.Equal(1234, door.Code);
        }

        [Fact]

        public void Door_Constructor_CodeAndName()
        {
            Assert.Equal(1234, doorWhitName.Code);
            Assert.Equal("Braso", doorWhitName.Name);
        }

        [Fact]

        public void Door_Constructor_CodeNameAndGuid()
        {
            Guid id = new Guid();
            Door doorWhitGuid = new Door("Braso", id, 1234);
            Assert.Equal(1234, doorWhitGuid.Code);
            Assert.Equal("Braso", doorWhitGuid.Name);
            Assert.Equal(id, doorWhitGuid.ID);
        }

        //[Fact]
        //public void Door_OpenDoor_WithoutCode()
        //{
        //    door.OpenDoor();
        //    Assert.Throws<ArgumentException>( door.OpenDoor());
        //}

        [Fact]
        public void Door_OpenDoor_WithCode()
        {
            door.OpenDoor(1234);
            Assert.Equal(DeviceStatus.Open, door.DeviceStatus);
        }

        [Fact]
        public void Door_OpenDoor_NoCodeAndClosed()
        {
            door.UnlockDoor(1234);
            door.OpenDoor();
            Assert.Equal(DeviceStatus.Open, door.DeviceStatus);
        }

        [Fact]
        public void Door_OpenDoor_IsJustOpen()
        {
            door.OpenDoor(1234);
            door.OpenDoor(1234);
            Assert.Equal(DeviceStatus.Open, door.DeviceStatus);
        }

        [Fact]
        public void Door_CloseDoor_IsOpen()
        {
            door.OpenDoor(1234);
            door.CloseDoor();
            Assert.Equal(DeviceStatus.Closed, door.DeviceStatus);
        }

        [Fact]
        public void Door_CloseDoor_IsJustClosed()
        {
            door.OpenDoor(1234);
            door.CloseDoor();
            door.CloseDoor();
            Assert.Equal(DeviceStatus.Closed, door.DeviceStatus);
        }

        [Fact]
        public void Door_LockDoor_IsClosed()
        {
            door.OpenDoor(1234);
            door.CloseDoor();
            door.LockDoor(1234);
            Assert.Equal(DeviceStatus.Locked, door.DeviceStatus);
        }

        [Fact]
        public void Door_LockDoor_Islocked()
        {           
            door.UnlockDoor(1234);
            door.LockDoor(1234);
            Assert.Equal(DeviceStatus.Locked, door.DeviceStatus);
        }

    }
}
