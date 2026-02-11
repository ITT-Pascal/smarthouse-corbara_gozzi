using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.Abstractions
{
    public abstract class AbstractDevice
    {
        //   -------ATTRIBUTES AND PROPERTY-------
        public Guid ID { get; init; }
        public DeviceStatus DeviceStatus { get; protected set; }
        public DeviceName Name { get; protected set; }
        public DateTime DateTimeAtCreationUtc { get; init; }
        public DateTime? LastModifierAtUtc { get; protected set; }

        public List<DateTime> HistoryOfMod = []; // <= new()  <= new List<DateTime>()

        //      ------CONSTRUCTORS------
        public AbstractDevice()
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = Guid.NewGuid();
            Name = DeviceName.NewDeviceName("ABSTRACT_DEVICE");
        }
        public AbstractDevice(Guid id)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = id;
            Name = DeviceName.NewDeviceName("ABSTRACT_DEVICE");
        }
        public AbstractDevice(Guid id, DeviceName name)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = id;
            Name = name;
        }

        //        ------METHODS------

        //--CHECK METHODS--

        public void CheckStatusWith(DeviceStatus status)
        {
            if (DeviceStatus == status)
                throw new ArgumentException("Status: Status is not compatible with this method actions");
        }

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
        public string ReturnAllModifiesOfDevice()
        {
            StringBuilder sb = new();
            sb.Append($"----{Name} modifies----");
            sb.Append(string.Join('\n', HistoryOfMod));
            return sb.ToString();
        }
    }
}
