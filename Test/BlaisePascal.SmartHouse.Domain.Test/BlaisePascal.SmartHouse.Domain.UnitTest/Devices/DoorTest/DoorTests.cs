using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.DoorTest
{
    public class DoorTests
    {
        Door testDoor = new();
        Door testDoorCode = new(DoorCode.NewDoorCode(654321));
        [Fact]
        public void Door_Constructor_WhenCreatedIsClosedAndCodeIsBasicCode()
        {
            
            Assert.Equal(DeviceStatus.Closed, testDoor.DeviceStatus);
            var exception = Record.Exception(() => testDoor.IsCodeCorrect(DoorCode.NewDoorCode(123456)));
            Assert.Null(exception);
        }

        [Fact]
        public void Door_Constructor_WhenCreatedIsClosedAndCodeIsSetToAValue()
        {
            
            Assert.Equal(DeviceStatus.Closed, testDoor.DeviceStatus);
            var exception = Record.Exception(() => testDoorCode.IsCodeCorrect(DoorCode.NewDoorCode(654321)));
            Assert.Null(exception);
        }

        [Fact]
        public void Door_OpenDoor_NotOpenWhenLocked()
        {
            testDoor.LockDoor();
            Assert.Throws<InvalidOperationException>(() => testDoor.OpenDoor());
        }

        [Fact]
        public void Door_OpenDoor_OpenWhenClosed()
        {
            testDoor.OpenDoor();
            Assert.Equal(DeviceStatus.Open, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_OpenDoor_OpenWhenOpen()
        {
            testDoor.OpenDoor();
            testDoor.OpenDoor();
            Assert.Equal(DeviceStatus.Open, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_UnlockDoor_WrongCode()
        {
            testDoor.LockDoor();
            Assert.Throws<ArgumentException>(() => testDoor.UnlockDoor(DoorCode.NewDoorCode(676767)));
        }

        [Fact]
        public void Door_UnlockDoor_LockedRightCode()
        {
            testDoor.UnlockDoor(DoorCode.NewDoorCode(123456));
            Assert.Equal(DeviceStatus.Open, testDoor.DeviceStatus);
        }
        [Fact]
        public void Door_CloseDoor_LockedDoor()
        {
            testDoor.LockDoor();
            Assert.Throws<InvalidOperationException>(() => testDoor.OpenDoor());
        }

        [Fact]
        public void Door_CloseDoor_ClosedDoor()
        {
            testDoor.CloseDoor();
            Assert.Equal(DeviceStatus.Closed, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_CloseDoor_OpenDoor()
        {
            testDoor.OpenDoor();
            testDoor.CloseDoor();
            Assert.Equal(DeviceStatus.Closed, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_LockDoor_OpenDoor()
        {
            testDoor.LockDoor();
            Assert.Equal(DeviceStatus.Locked, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_LockDoor_ClosedDoor()
        {
            testDoor.LockDoor();
            testDoor.LockDoor();
            Assert.Equal(DeviceStatus.Locked, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_LockDoor_LockedDoor()
        {
            testDoor.LockDoor();
            testDoor.LockDoor();
            Assert.Equal(DeviceStatus.Locked, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_ChangeCode_CorrectCode()
        {
            testDoor.ChangeCodeTo(DoorCode.NewDoorCode(676767), DoorCode.NewDoorCode(123456));
            testDoor.UnlockDoor(DoorCode.NewDoorCode(676767));
            Assert.Equal(DeviceStatus.Open, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_Toggle_WhenIsClosedTheDoorWillBeOpen()
        {
            testDoor.Toggle();
            Assert.Equal(DeviceStatus.Open, testDoor.DeviceStatus);
        }
        [Fact]
        public void Door_Toggle_WhenIsOpenTheDoorWillBeClosed()
        {
            testDoor.OpenDoor();
            testDoor.Toggle();
            Assert.Equal(DeviceStatus.Closed, testDoor.DeviceStatus);
        }
        [Fact]
        public void Door_Toggle_WhenIsLockedCannotBeToggled()
        {
            testDoor.LockDoor();
            testDoor.Toggle();
            Assert.Throws<InvalidOperationException>(() => testDoor.Toggle());
        }
    }
}
