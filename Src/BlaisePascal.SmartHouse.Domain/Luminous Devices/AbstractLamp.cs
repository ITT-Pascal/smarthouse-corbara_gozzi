using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Luminous_Devices;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public abstract class AbstractLamp: AbstractDevice, ILamp
    {
        private const int intensityAtOff = 0;
        private const int intensityAtOn = 50;
        private const int valOfIncreaseAndDecrease = 10;

        //  -------ATTRIBUTES AND PROPERTY-------

        public Intensity Intensity { get; protected set; }
        
        //      ------CONSTRUCTORS------
        protected AbstractLamp(): base()
        {
            Intensity = Intensity.NewIntensity(intensityAtOff);
        }
        protected AbstractLamp(Guid id) : base(id)
        {
            Intensity = Intensity.NewIntensity(intensityAtOff);
        }
        protected AbstractLamp( Guid guid, string name) : base(guid, name)
        {
            Intensity = Intensity.NewIntensity(intensityAtOff);
        }

        //     ------METHODS------

        /// <summary>
        /// Metodo che lancia errore se il device è spento
        /// </summary>
        
        public void CheckIsOn()
        {
            if (DeviceStatus == DeviceStatus.Off)
                throw new Exception("Switch on device first");
        }

        //--ON/OFF METHODS--

        public override void SwitchOn()
        {
            base.SwitchOn();
            Intensity = Intensity.NewIntensity(intensityAtOn);
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            Intensity = Intensity.NewIntensity(intensityAtOff);
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
            CheckIsOn();
            Intensity = Intensity.NewIntensity(Intensity.Value + valOfIncreaseAndDecrease);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public virtual void DecreaseBy()
        {
            CheckIsOn();
            Intensity = Intensity.NewIntensity(Intensity.Value - valOfIncreaseAndDecrease);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public virtual void SetIntensityTo(Intensity intensity)
        {
            CheckIsOn();
            Intensity = intensity;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
    }
}
