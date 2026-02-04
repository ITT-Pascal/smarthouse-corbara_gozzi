using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions
{
    public abstract class AbstractDevice
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public Guid ID { get; init; }
        public DeviceStatus DeviceStatus { get; protected set; }
        public Name ?Name { get; protected set; }
        public DateTime DateTimeAtCreationUtc { get; init; }
        public DateTime? LastModifierAtUtc { get; protected set; }

        public List<DateTime> HistoryOfMod = new List<DateTime>();

        //------CONSTRUCTORS------
        public AbstractDevice()
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = new Guid();
            Name = new Name("ABSTRACT_DEVICE");
        }
        public AbstractDevice(Guid guid)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = guid;
            Name = new Name("ABSTRACT_DEVICE");
        }
        public AbstractDevice(Guid guid, string name)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = guid;
            Name = new Name(name);
        }

        //------METHODS------
        public virtual void SwitchOn()
        {
            DeviceStatus = DeviceStatus.On;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public virtual void SwitchOff()
        {
            DeviceStatus = DeviceStatus.Off;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        /// <summary>
        /// metodo che permette di eliminare lo status di errore
        /// </summary>
        public void FixErrors()
        {
            if (DeviceStatus == DeviceStatus.Error)
            {
                DeviceStatus = DeviceStatus.On;
            }
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void RenameDevice(Name newName)
        {
            Name = newName;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        /// <summary>
        /// metodo che ritorna con lo string builder tutto lo storico delle modifiche
        /// </summary>
        /// <returns></returns>
        public string ReturnAllModifiesOfDevice(AbstractDevice device)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"----{device.GetType}----");
            foreach (DateTime modifie in HistoryOfMod)
            {
                sb.Append(modifie);
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
