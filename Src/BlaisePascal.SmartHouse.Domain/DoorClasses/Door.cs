using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.DoorClasses
{
    public class Door : AbstractDevice
    {
        //-------ATTRIBUTES AND PROPERTY-------
        private int Code { get; set; }
        private string? AdminPassword;

        //------CONSTRUCTORS------
        public Door(int code)
        {
            DeviceStatus = DeviceStatus.Locked;
            ID = new Guid();
            Name = "Door";
            Code = code;
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }
        public Door(string name, int code)
        {
            DeviceStatus = DeviceStatus.Locked;
            ID = new Guid();
            Name = name;
            Code = code;
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }
        public Door(string name, Guid guid, int code)
        {
            DeviceStatus = DeviceStatus.Locked;
            ID = guid;
            Name = name;
            Code = code;
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }
        public Door(string name, Guid guid, int code, string adminCode)
        {
            DeviceStatus = DeviceStatus.Locked;
            ID = guid;
            Name = name;
            Code = code;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            AdminPassword = adminCode;
        }

        //------METHODS------
        public int ReturnCode(string adminCode)
        {
            if (AdminPassword == adminCode)
                return Code;
            else
                throw new ArgumentException("Password errata");
        }
        public void OpenDoor()
        {
            if (DeviceStatus != DeviceStatus.Locked)
                DeviceStatus = DeviceStatus.Open;
            else
                throw new ArgumentException("For Open the locked door you need to insert the code");
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public void OpenDoor(int codeValidator)
        {
            if (DeviceStatus == DeviceStatus.Closed || DeviceStatus == DeviceStatus.Open)
                DeviceStatus = DeviceStatus.Open;
            else
            {
                if (codeValidator == Code)
                    DeviceStatus = DeviceStatus.Open;
                else
                    throw new ArgumentException("The Code Is Wrong");
            }
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public void CloseDoor()
        {
            if (DeviceStatus != DeviceStatus.Locked)
            {
                DeviceStatus = DeviceStatus.Closed;
                LastModifierAtUtc = DateTime.UtcNow;
            }
            else
                throw new ArgumentException("You need to unlock the door");
        }
        public void LockDoor(int codeValidator)
        {
            if (DeviceStatus == DeviceStatus.Closed && codeValidator == Code)
                DeviceStatus = DeviceStatus.Locked;
            else
                throw new ArgumentException("If You want to lock the door it has to be closed , remember to insert right code");
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public void UnlockDoor(int codeValidator)
        {
            if (DeviceStatus == DeviceStatus.Locked && codeValidator == Code)
                DeviceStatus = DeviceStatus.Closed;
            else
                throw new ArgumentException("If You want to unlock the door it has to be locked , remember to insert right code");
            LastModifierAtUtc = DateTime.UtcNow;
        }
    }
}
