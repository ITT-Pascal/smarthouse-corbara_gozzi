using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.DoorClasses
{
    public class Door
    {
        //-------ENUM CLASS-------
        public enum DoorStatus 
        {
            Open,
            Closed,
            Locked
        }

        //-------ATTRIBUTES AND PROPERTY-------
        private int Code { get; set; }
        public DoorStatus Status { get; private set; }
        public DateTime DateTimeAtCreationUtc { get; private set;}
        public DateTime? LastModifierAtUtc { get; protected set; }

        //------CONSTRUCTORS------
        public Door()
        {
            Status = DoorStatus.Closed;
        }
        public Door(int code)
        {
            Status = DoorStatus.Locked;
            Code = code;
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }

        //------METHODS------
        public void OpenDoor()
        {
            if (Status != DoorStatus.Locked)
                Status = DoorStatus.Open;
            else
                throw new ArgumentException("For Open the locked door you need to insert the code");
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public void UnlockDoor(int code)
        {
            if (code == Code)
                Status = DoorStatus.Open;
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public void CloseDoor()
        {
            if (Status != DoorStatus.Locked)
            {
                Status = DoorStatus.Closed;
                LastModifierAtUtc = DateTime.UtcNow;
            }
            else
                throw new ArgumentException("You need to unlock the door");
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public void LockDoor()
        {
            Status = DoorStatus.Locked;
            LastModifierAtUtc = DateTime.UtcNow;
        }
        public void ChangeCode(int code)
        {
            Code = code;
            LastModifierAtUtc = DateTime.UtcNow;
        }
    }
}
