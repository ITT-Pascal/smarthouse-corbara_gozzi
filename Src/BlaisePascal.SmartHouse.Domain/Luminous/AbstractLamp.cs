using BlaisePascal.SmartHouse.Domain.Abstractions;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public abstract class AbstractLamp: AbstractDevice, IToggable
    {
        private int intensityAtOff = 0;
        private int valOfIncreaseAndDecrease = 10;
        //  -------ATTRIBUTES AND PROPERTY-------
        public Intensity Intensity { get; protected set; }
        public Intensity IntensityAtOn = new Intensity(50);

        //      ------CONSTRUCTORS------
        protected AbstractLamp(): base()
        {
            Intensity = new Intensity(intensityAtOff);
        }
        protected AbstractLamp(Guid id) : base(id)
        {
            Intensity = new Intensity(intensityAtOff);
        }
        protected AbstractLamp( Guid guid, string name) : base(guid, name)
        {
            Intensity = new Intensity(intensityAtOff);
        }

        //     ------METHODS------

        /// <summary>
        /// Metodo che lancia errore se il device è spento
        /// </summary>
        
        public void IsDeviceOn()
        {
            if (DeviceStatus == DeviceStatus.Off)
                throw new ArgumentException("Device is off");
        }


        //--ON/OFF METHODS--

        public sealed override void SwitchOn()
        {
            base.SwitchOn();
            Intensity = IntensityAtOn;
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            Intensity = new Intensity(intensityAtOff);
        }
        public virtual void Toggle()
        {
            if (DeviceStatus == DeviceStatus.On)
                SwitchOff();
            else
                SwitchOn();
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }

        //--CHANGER INTENSITY METHODS--

        public virtual void IncreaseBy()
        {
            IsDeviceOn();
            Intensity = new Intensity(Intensity.Value+valOfIncreaseAndDecrease);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public virtual void DecreaseBy()
        {
            IsDeviceOn();
            Intensity = new Intensity(Intensity.Value - valOfIncreaseAndDecrease);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public virtual void SetIntensityTo(Intensity intensity)
        {
            IsDeviceOn();
            Intensity = intensity;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void ReturnAllModifiesOfDevice() => ReturnAllModifiesOfDevice(this);
    }
}
