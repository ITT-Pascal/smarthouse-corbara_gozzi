using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions
{
    public abstract class AbstractDevice: ISwitchable
    {
        //   -------ATTRIBUTES AND PROPERTY-------
        public Guid ID { get; init; }
        public DeviceStatus DeviceStatus { get; protected set; }
        public DeviceName ?Name { get; protected set; }
        public DateTime DateTimeAtCreationUtc { get; init; }
        public DateTime? LastModifierAtUtc { get; protected set; }

        public List<DateTime> HistoryOfMod = new List<DateTime>();

        //      ------CONSTRUCTORS------
        public AbstractDevice()
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = Guid.NewGuid();
            Name = new DeviceName("ABSTRACT_DEVICE");
        }
        public AbstractDevice(Guid guid)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = guid;
            Name = new DeviceName("ABSTRACT_DEVICE");
        }
        public AbstractDevice(Guid guid, string name)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = guid;
            Name = new DeviceName(name);
        }

        //        ------METHODS------

        //--SWITCH METHODS--
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

        //--CHANGER METHODS--

        public void RenameTo(DeviceName newName)
        {
            Name = newName;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }

        //--RETURN METHODS--

        /// <summary>
        /// metodo che ritorna con lo string builder tutto lo storico delle modifiche
        /// </summary>
        /// <returns></returns>
        public string ReturnAllModifiesOfDevice(AbstractDevice device)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"----{Name} modifies----");
            sb.Append(string.Join("\n", HistoryOfMod));
            return sb.ToString();
        }
    }
}
