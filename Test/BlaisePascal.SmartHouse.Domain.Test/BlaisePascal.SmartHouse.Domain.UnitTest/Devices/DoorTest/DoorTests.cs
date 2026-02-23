using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.DoorTest
{
    public class DoorTests
    {
        readonly int pass = 1234;
        readonly int newPass = 4321;
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
            Assert.Equal(DoorStatus.Closed, DoorN.Status);
        }

        [Fact]
        public void Door_OpenDoor_OpenWhenLocked()
        {
            Assert.Throws<ArgumentException>(() => Door.OpenDoor());
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
            Assert.Throws<ArgumentException>(() => Door.UnlockDoor(6767));
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
            Door.UnlockDoor(1234);
            Assert.Equal(DoorStatus.Open, Door.Status);
        }

        [Fact]
        public void Door_UnlockDoor_OpenRightCode()
        {
            Door.UnlockDoor(1234);
            Door.UnlockDoor(1234);
            Assert.Equal(DoorStatus.Open, Door.Status);
        }

        [Fact]
        public void Door_CloseDoor_LockedDoor()
        {
            Assert.Throws<ArgumentException>(() => Door.CloseDoor());
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
            Assert.Equal(DoorStatus.Open, Door.Status);
        }

        [Fact]
        public void Door_ChangeCode_CodeTooLong()
        {
            Assert.Throws<ArgumentException>(() => Door.ChangeCode(67677935));
        }

        [Fact]
        public void Door_ChangeCode_CodeTooShort()
        {
            Assert.Throws<ArgumentException>(() => Door.ChangeCode(1));
        }

        //TODO Read only con pass e nuova pass
    }
}
