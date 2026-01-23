
using BlaisePascal.SmartHouse.Domain.DoorClasses;
namespace BlaisePascal.SmartHouse.Domain.UnitTest.DoorTest
{
    public class DoorTest
    {
        Door Door = new Door(1234);
        Door DoorN = new Door();

        [Fact]
        public void Door_Constructor_Code()
        {
            Assert.Equal(DoorStatus.Locked, Door.Status);
        }

        [Fact]
        public void Door_Constructor_NoCode()
        {
            Door DoorN = new Door();
            Assert.Equal(DoorStatus.Closed, Door.Status);
        }

        [Fact]
        public void Door_OpenDoor_OpenWhenLocked()
        {
            Door.OpenDoor();
            Assert.Throws<ArgumentException>(() => "For Open the locked door you need to insert the code");
        }

        [Fact]
        public void Door_OpenDoor_OpenWhenClosed()
        {
            DoorN.OpenDoor();
            Assert.Equal(DoorStatus.Open , DoorN.Status);
        }

        [Fact]
        public void Door_OpenDoor_OpenWhenOpen()
        {
            DoorN.OpenDoor();
            DoorN.OpenDoor();
            Assert.Equal(DoorStatus.Open, DoorN.Status);
        }

        [Fact]
        public void Door_UnlockDoor_WrongCode()
        {
            Door.UnlockDoor(6767);
            Assert.Throws<ArgumentException>(() => "You Insert The Wrong Code");
        }

        [Fact]
        public void Door_UnlockDoor_LockedRightCode()
        {
            Door.UnlockDoor(1234);
            Assert.Equal(DoorStatus.Open, Door.Status);
        }

        [Fact]
        public void Door_UnlockDoor_ClosedRightCode()
        {
            DoorN.UnlockDoor(1234);
            Assert.Equal(DoorStatus.Open, DoorN.Status);
        }

        [Fact]
        public void Door_UnlockDoor_OpenRightCode()
        {
            DoorN.OpenDoor();
            DoorN.UnlockDoor(1234);
            Assert.Equal(DoorStatus.Open, DoorN.Status);
        }

        [Fact]
        public void Door_CloseDoor_LockedDoor()
        {
            Door.CloseDoor();
            Assert.Throws<ArgumentException>(() => "You need to unlock the door");
        }

        [Fact]
        public void Door_CloseDoor_ClosedDoor()
        {
            DoorN.CloseDoor();
            Assert.Equal(DoorStatus.Closed, DoorN.Status);
        }

        [Fact]
        public void Door_CloseDoor_OpenDoor()
        {
            DoorN.OpenDoor();
            DoorN.CloseDoor();
            Assert.Equal(DoorStatus.Closed, DoorN.Status);
        }

        [Fact]
        public void Door_LockDoor_OpenDoor()
        {
            DoorN.OpenDoor();
            DoorN.LockDoor();
            Assert.Equal(DoorStatus.Locked, DoorN.Status);
        }

        [Fact]
        public void Door_LockDoor_ClosedDoor()
        {         
            DoorN.LockDoor();
            Assert.Equal(DoorStatus.Locked, DoorN.Status);
        }

        [Fact]
        public void Door_LockDoor_LockedDoor()
        {
            DoorN.LockDoor();
            DoorN.LockDoor();
            Assert.Equal(DoorStatus.Locked, DoorN.Status);
        }

        [Fact]
        public void Door_ChangeCode_CorrectCode()
        {
            Door.ChangeCode(6767);
            Door.UnlockDoor(6767);
            Assert.Equal(DoorStatus.Open, DoorN.Status);
        }

        [Fact]
        public void Door_ChangeCode_CodeTooLong()
        {
            Door.ChangeCode(67677935);
            Assert.Throws<ArgumentException>(() => "The Code Has to be at least 2 number and maximus 6 numbers");
        }

        [Fact]
        public void Door_ChangeCode_CodeTooShort()
        {
            Door.ChangeCode(1);
            Assert.Throws<ArgumentException>(() => "The Code Has to be at least 2 number and maximus 6 numbers");
        }
    }
}
