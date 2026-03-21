using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.DoorDevices
{
    public class DoorTests
    {
        private readonly Door testDoor = new();
        private readonly Door testDoorCode = new(DoorCode.NewDoorCode(654321));
        private readonly DoorCode newCode = DoorCode.NewDoorCode(676767);


        [Fact]
        public void Door_Constructor_WhenCreatedIsClosedAndCodeIsBasicCode()
        {
            Assert.Equal(DeviceStatus.Closed, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_ConstructorWithCode_WhenCreatedIsClosedAndCodeIsSetToAValue()
        {
            Assert.Equal(DeviceStatus.Closed, testDoorCode.DeviceStatus);
            Assert.Equal(DoorCode.NewDoorCode(654321).Digits, testDoorCode.Code.Digits);
        }

        #region OPEN - CLOSE DOOR

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
        public void Door_CloseDoor_ClosedDoor()
        {
            testDoor.CloseDoor();

            Assert.Equal(DeviceStatus.Closed, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_CloseDoor_OpenedDoor()
        {
            testDoor.OpenDoor();

            testDoor.CloseDoor();

            Assert.Equal(DeviceStatus.Closed, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_CloseDoor_CannotCloseLockedDoor()
        {
            testDoor.LockDoor();

            Assert.Throws<InvalidOperationException>(() => testDoor.CloseDoor());
        }

        #endregion

        #region LOCK - UNLOCK DOOR

        [Fact]
        public void Door_UnlockDoor_WrongCode()
        {
            testDoor.LockDoor();

            Assert.Throws<ArgumentException>(() => testDoor.UnlockDoor(newCode));
        }

        [Fact]
        public void Door_UnlockDoor_LockedRightCode()
        {
            testDoor.LockDoor();

			testDoor.UnlockDoor(DoorCode.NewDoorCode(123456));

            Assert.Equal(DeviceStatus.Open, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_LockDoor_LockedOpenDoor()
        {
            testDoor.OpenDoor();

            testDoor.LockDoor();

            Assert.Equal(DeviceStatus.Locked, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_LockDoor_LockedClosedDoor()
        {
            testDoor.LockDoor();

            Assert.Equal(DeviceStatus.Locked, testDoor.DeviceStatus);
        }

        [Fact]
        public void Door_LockDoor_LockedLockedDoor()
        {
            testDoor.LockDoor();

            testDoor.LockDoor();

            Assert.Equal(DeviceStatus.Locked, testDoor.DeviceStatus);
        }

        #endregion

        [Fact]
        public void Door_ChangeCode_CorrectIsChanged()
        {
            testDoor.ChangeCodeTo(newCode, DoorCode.NewDoorCode(123456));
            testDoor.LockDoor();
            testDoor.UnlockDoor(newCode);

            Assert.Equal(DeviceStatus.Open, testDoor.DeviceStatus);
        }        
        
        [Fact]
        public void Door_SwitchOn_ThrowsError()
        {
            Assert.Throws<NotSupportedException>(() => testDoor.SwitchOn());
        }

        [Fact]
        public void Door_SwitchOff_ThrowsError()
        {
            Assert.Throws<NotSupportedException>(() => testDoor.SwitchOff());
        }

        #region TOGGLE DOOR

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

            Assert.Throws<InvalidOperationException>(() => testDoor.Toggle());
        }

        #endregion
    }
}
