using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.ValueObjects;
using System.ComponentModel.Design;
using System.Text;

namespace BlaisePascal.SmartHouse.Domain.Devices.DoorDevices
{
    public class Door: AbstractDevice
    {
        private const uint basicCode = 123456;

        //  -------ATTRIBUTES AND PROPERTY-------
        public DoorCode Code { get; private set; }

        //      ------CONSTRUCTORS------
        public Door() : this(DoorCode.NewDoorCode(basicCode)) 
        { 

        }
        public Door(DoorCode code) : base()
        {
            DeviceStatus = DeviceStatus.Closed;
            Code = code;
        }
        public Door(Guid id) : base(id)
        {
            DeviceStatus = DeviceStatus.Closed;
            Code = DoorCode.NewDoorCode(basicCode);
        }
        public Door(Guid id, DeviceName name) : this(id)
        {
            Name = name;
        }
        public Door(Guid id, DeviceName name, DoorCode code) : this(id, name)
        {
            Code = code;
        }
        public Door(Guid id, DeviceName name, DeviceStatus deviceStatus, DoorCode doorCode, DateTime dateTimeAtCreationUtc, DateTime lastModifierAtUtc): this(id, name, doorCode)
        {
            DeviceStatus = deviceStatus;
            DateTimeAtCreationUtc = dateTimeAtCreationUtc;
            LastModifierAtUtc = lastModifierAtUtc;
        }

        //       ------METHODS------

        //--CHECK METHODS--

        //METODO CHE LANCIA ERRORE PER PASSWORD ERRATA

        public void IsCodeCorrect(DoorCode Try)
        {
            if (Try.Digits != Code.Digits)
                throw new ArgumentException("Code: Incorrect try", nameof(Try));
        }
        public sealed override void Toggle()
        {
            CheckIsNot(DeviceStatus.Locked);
            if (DeviceStatus == DeviceStatus.Closed)
                OpenDoor();
            else
                CloseDoor();
            LastModifierAtUtc = DateTime.Now;
        }
        public void OpenDoor()
        {
            CheckIsNot(DeviceStatus.Locked);
            DeviceStatus = DeviceStatus.Open;
            LastModifierAtUtc = DateTime.Now;
        }
        public void CloseDoor()
        {
            CheckIsNot(DeviceStatus.Locked);
            DeviceStatus = DeviceStatus.Closed;
            LastModifierAtUtc = DateTime.Now;
            
        }
        public void LockDoor()
        {
            DeviceStatus = DeviceStatus.Locked;
            LastModifierAtUtc = DateTime.Now;
        }
        public void UnlockDoor(DoorCode code)
        {
            IsCodeCorrect(code);
            DeviceStatus = DeviceStatus.Open;
            LastModifierAtUtc = DateTime.Now;
        }
        public void ChangeCodeTo(DoorCode newCode, DoorCode code)
        {
            IsCodeCorrect(code);
            Code = newCode;
            LastModifierAtUtc = DateTime.Now;
        }

        
        
    }
}      
