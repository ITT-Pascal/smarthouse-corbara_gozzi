using BlaisePascal.SmartHouse.Domain.Abstractions;
using System.ComponentModel.Design;
using System.Text;

namespace BlaisePascal.SmartHouse.Domain.DoorClasses
{
    public class Door
    {

        //-------ATTRIBUTES AND PROPERTY-------
        private int Code { get; set; }
        public DoorStatus Status { get; private set; }
        public DateTime DateTimeAtCreationUtc { get; private set;}
        public DateTime? LastModifierAtUtc { get; protected set; }

        public List<DateTime> HistoryOfDoorMod = new List<DateTime>();

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
            {
                Status = DoorStatus.Open;
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfDoorMod.Add(DateTime.UtcNow);
            }
            else
                throw new ArgumentException("For Open the locked door you need to insert the code");
            
        }
        public void UnlockDoor(int code)
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
        public void ChangeCode(int code)
        {
            if (code.ToString().Length <= 6 && code.ToString().Length > 1)
            {
                Code = code;
                LastModifierAtUtc = DateTime.UtcNow;
                HistoryOfDoorMod.Add(DateTime.UtcNow);
            }
            else
                throw new ArgumentException("The Code Has to be at least 2 number and maximus 6 numbers");
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
