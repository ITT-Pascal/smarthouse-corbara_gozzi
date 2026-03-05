using System.Text;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions
{
    public abstract class AbstractDevice
    {
        //   -------ATTRIBUTES AND PROPERTY-------
        public Guid ID { get; init; }
        public DeviceStatus DeviceStatus { get; protected set; }
        public DeviceName Name { get; protected set; }
        public DateTime DateTimeAtCreationUtc { get; init; }
        public DateTime LastModifierAtUtc { get; protected set; }

        //      ------CONSTRUCTORS------
        public AbstractDevice()
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = Guid.NewGuid();
            Name = DeviceName.NewBasicName();
        }
        public AbstractDevice(Guid id)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.UtcNow;
            ID = id;
            Name = DeviceName.NewBasicName();
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

        public void CheckIsNot(DeviceStatus status)
        {
            if (DeviceStatus == status)
            {
                DeviceStatus = DeviceStatus.Error;
                throw new InvalidOperationException("Status: This status is not compatible with this method actions");
            }
            //ERRORE CHE INDICA L'INCOMPATIBILITA' DI UNO STATO ALLA CHIAMATA DEL METODO
        }

        //--SWITCH METHODS--
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

        //--CHANGER METHODS--

        public void RenameTo(DeviceName newName)
        {
            Name = newName;
            LastModifierAtUtc = DateTime.UtcNow;
        }
    }
}
