using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Shared;
using System.ComponentModel.Design;
using System.Text;

namespace BlaisePascal.SmartHouse.Domain.DoorClasses
{
    public class Door: AbstractDevice, IToggable
    {

        //  -------ATTRIBUTES AND PROPERTY-------
        private DoorCode Code { get; set; }

        public List<DateTime> HistoryOfDoorMod = [];

        //      ------CONSTRUCTORS------
        public Door()
        {
            DeviceStatus = DeviceStatus.Closed;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            Code = DoorCode.NewDoorCode(123456);
        }
        public Door(DoorCode code)
        {
            DeviceStatus = DeviceStatus.Closed;
            Code = code;
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }

        //       ------METHODS------

        //--CHECK METHODS--

        /// <summary>
        /// Metodo che verifica se la porta è locked
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        
        private void IsDoorLocked()
        {
            if (DeviceStatus == DeviceStatus.Locked)
                throw new ArgumentException("Impossibile, la porta è chiusa");

        }

        //METODO CHE LANCIA ERRORE PER PASSWORD ERRATA

        private void IsCodeCorrect(DoorCode Try)
        {
            if (Try != Code)
                throw new ArgumentException("Codice errato");
        }

        /// <summary>
        /// METODI CHE LANCIANO ERRORI PERCHE' EREDITATI MA IMPOSSIBILI DA CHIAMARE SENNO' CAUSEREBBERO ERRORI
        /// </summary>
        public sealed override void SwitchOn()
        {
            throw new ArgumentException("Door is not switchable");
        }
        /// <summary>
        /// METODI CHE LANCIANO ERRORI PERCHE' EREDITATI MA IMPOSSIBILI DA CHIAMARE SENNO' CAUSEREBBERO ERRORI
        /// </summary>
        public sealed override void SwitchOff()
        {
            throw new ArgumentException("Door is not switchable");
        }

        public sealed override void Toggle()
        {
            IsDoorLocked();
            if (DeviceStatus == DeviceStatus.Closed)
                OpenDoor();
            else
                CloseDoor();
        }
        public void OpenDoor()
        {
            IsDoorLocked();
            DeviceStatus = DeviceStatus.Open;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfDoorMod.Add(DateTime.UtcNow);
        }
        public void CloseDoor()
        {
            IsDoorLocked();
            DeviceStatus = DeviceStatus.Closed;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfDoorMod.Add(DateTime.UtcNow);
            
        }
        public void LockDoor()
        {
            DeviceStatus = DeviceStatus.Locked;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfDoorMod.Add(DateTime.UtcNow);
        }
        public void UnlockDoor(DoorCode code)
        {
            IsCodeCorrect(code);
            DeviceStatus = DeviceStatus.Open;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfDoorMod.Add(DateTime.UtcNow);
        }
        public void ChangeCodeTo(DoorCode newCode, DoorCode code)
        {
            IsCodeCorrect(code);
            Code = newCode;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfDoorMod.Add(DateTime.UtcNow);
        }

        /// <summary>
        /// metodo che ritorna con lo string builder tutto lo storico delle modifiche della porta
        /// </summary>
        /// <returns></returns>
        public string ReturnAllModifiesOfDoor()
        {
            StringBuilder sb = new();
            sb.Append($"----DOOR----");
            foreach (DateTime modifie in HistoryOfDoorMod)
            {
                sb.Append(modifie);
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}      
