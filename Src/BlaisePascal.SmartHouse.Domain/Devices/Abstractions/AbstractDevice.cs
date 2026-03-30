using System.Text;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions
{
    public abstract class AbstractDevice: IToggable
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
            DateTimeAtCreationUtc = DateTime.Now;
            ID = Guid.NewGuid();
            Name = DeviceName.NewBasicName();
            LastModifierAtUtc = DateTime.Now;
        }
        public AbstractDevice(Guid id)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.Now;
            ID = id;
            Name = DeviceName.NewBasicName();
            LastModifierAtUtc = DateTime.Now;
        }
        public AbstractDevice(Guid id, DeviceName name)
        {
            DeviceStatus = DeviceStatus.Off;
            DateTimeAtCreationUtc = DateTime.Now;
            ID = id;
            Name = name;
            LastModifierAtUtc = DateTime.Now;
        }

        //        ------METHODS------

        //--CHECK METHODS--

        public void CheckIsNot(DeviceStatus status)
        {
            if (DeviceStatus == status)
            {
                DeviceStatus = DeviceStatus.Error;
                throw new InvalidOperationException($"Device is in {status} status, operation not allowed.");
            }   
            //ERRORE CHE INDICA L'INCOMPATIBILITA' DI UNO STATO ALLA CHIAMATA DEL METODO
        }

        public virtual void Toggle()
        {
            CheckIsNot(DeviceStatus.Error);
            if (DeviceStatus == DeviceStatus.On)
                DeviceStatus = DeviceStatus.Off;
            else
                DeviceStatus = DeviceStatus.On;
            LastModifierAtUtc = DateTime.Now;
        }

        //--CHANGER METHODS--

        public void RenameTo(DeviceName newName)
        {
            Name = newName;
            LastModifierAtUtc = DateTime.Now;
        }
    }
}
