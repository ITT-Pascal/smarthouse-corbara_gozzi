using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.ValueObjects;
using System.ComponentModel.Design;
using System.Text;

namespace BlaisePascal.SmartHouse.Domain.Devices.DoorDevices
{
    public class Door: AbstractDevice, IToggable
    {
        private const int basicCode = 123456;

        //  -------ATTRIBUTES AND PROPERTY-------
        private DoorCode Code { get; set; }

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
        public Door(Guid id, DeviceName name) : base(id, name)
        {
            DeviceStatus = DeviceStatus.Closed;
            Code = DoorCode.NewDoorCode(basicCode);
        }
        public Door(Guid id, DeviceName name, DoorCode code) : base(id, name)
        {
            Code = code;
        }

        //       ------METHODS------

        //--CHECK METHODS--

        //METODO CHE LANCIA ERRORE PER PASSWORD ERRATA

        private void IsCodeCorrect(DoorCode Try)
        {
            if (Try != Code)
                throw new ArgumentException($"Code: Incorrect try", nameof(Try));
        }

        /// <summary>
        /// METODI CHE LANCIANO ERRORI PERCHE' EREDITATI MA IMPOSSIBILI DA CHIAMARE SENNO' CAUSEREBBERO ERRORI
        /// </summary>
        public sealed override void SwitchOn() 
        {
            DeviceStatus = DeviceStatus.Error;
            throw new NotSupportedException($"Method call[Door.SwitchOn()]: Door is not switchable"); 
            //ERRORE CHE INDICA IL FATTO CHE LA FUNZIONALITA' NON E' SUPPORTATA
        }
        /// <summary>
        /// METODI CHE LANCIANO ERRORI PERCHE' EREDITATI MA IMPOSSIBILI DA CHIAMARE SENNO' CAUSEREBBERO ERRORI
        /// </summary>
        public sealed override void SwitchOff() 
        {
            DeviceStatus = DeviceStatus.Error;
            throw new NotSupportedException($"Method call[Door.SwitchOff()]: Door is not switchable"); 
        }

        public void Toggle()
        {
            CheckIsNot(DeviceStatus.Locked);
            if (DeviceStatus == DeviceStatus.Closed)
                OpenDoor();
            else
                CloseDoor();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void OpenDoor()
        {
            CheckIsNot(DeviceStatus.Locked);
            DeviceStatus = DeviceStatus.Open;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void CloseDoor()
        {
            CheckIsNot(DeviceStatus.Locked);
            DeviceStatus = DeviceStatus.Closed;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
            
        }
        public void LockDoor()
        {
            DeviceStatus = DeviceStatus.Locked;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void UnlockDoor(DoorCode code)
        {
            IsCodeCorrect(code);
            DeviceStatus = DeviceStatus.Open;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void ChangeCodeTo(DoorCode newCode, DoorCode code)
        {
            IsCodeCorrect(code);
            Code = newCode;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
    }
}      
