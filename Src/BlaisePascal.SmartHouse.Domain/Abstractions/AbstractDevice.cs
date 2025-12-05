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
        public Guid ID { get; protected set; }
        public DeviceStatus DeviceStatus { get; protected set; }
        public string ?Name { get; protected set; }
        public DateTime DateTimeAtCreationUtc { get; protected set; }
        public DateTime? LastModifierAtUtc { get; protected set; }

        //------CONSTRUCTORS------
        public AbstractDevice()
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
        }

        //------METHODS------
        public virtual void SwitchOn()
        {
            DeviceStatus = DeviceStatus.On;
            LastModifierAtUtc = DateTime.UtcNow;
        }

        public virtual void SwitchOff()
        {
            DeviceStatus = DeviceStatus.Off;
            LastModifierAtUtc = DateTime.UtcNow;
        }
    }
}
