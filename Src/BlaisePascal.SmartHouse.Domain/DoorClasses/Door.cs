using BlaisePascal.SmartHouse.Domain.Abstractions;
using System.ComponentModel.Design;
using System.Text;

namespace BlaisePascal.SmartHouse.Domain.DoorClasses
{
    public class Door
    {

        //-------ATTRIBUTES AND PROPERTY-------
        private DoorCode Code { get; set; }
        public DoorStatus Status { get; private set; }
        public DateTime DateTimeAtCreationUtc { get; init;}
        public DateTime? LastModifierAtUtc { get; protected set; }

        public List<DateTime> HistoryOfDoorMod = new List<DateTime>();

        //------CONSTRUCTORS------
        public Door()
        {
            Status = DoorStatus.Closed;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            Code = new DoorCode(123456);
        }
        public Door(DoorCode code)
        {
            Status = DoorStatus.Locked;
            Code = code;
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }

        //------METHODS------
        public void OpenDoor()
        {
            if (Status != DoorStatus.Locked)
            {
                Status = DoorStatus.Open;
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfDoorMod.Add(DateTime.UtcNow);
            }
            else
                throw new ArgumentException("For Open the locked door you need to insert the code");
            
        }
        public void UnlockDoor(DoorCode code)
        { 
            if (code == Code)
            {
                Status = DoorStatus.Open;
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfDoorMod.Add(DateTime.UtcNow);
            }
            else
               throw new ArgumentException("You Insert The Wrong Code");
             

        }
        public void CloseDoor()
        {
            if (Status != DoorStatus.Locked)
            {
                Status = DoorStatus.Closed;
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfDoorMod.Add(DateTime.UtcNow);
            }
            else
                throw new ArgumentException("You need to unlock the door");
        }
        public void LockDoor()
        {
            Status = DoorStatus.Locked;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfDoorMod.Add(DateTime.UtcNow);
        }
        public void ChangeCode(DoorCode code, DoorCode newCode)
        {
            if (code == Code)
            {
                Code = newCode;
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfDoorMod.Add(DateTime.UtcNow);
            }
            else
                throw new ArgumentException("Put first the previous code to change it");
        }
        /// <summary>
        /// metodo che ritorna con lo string builder tutto lo storico delle modifiche della porta
        /// </summary>
        /// <returns></returns>
        public string ReturnAllModifiesOfDoor()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"----DOOR----");
            foreach (DateTime modifie in HistoryOfDoorMod)
            {
                sb.Append(modifie);
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}      
