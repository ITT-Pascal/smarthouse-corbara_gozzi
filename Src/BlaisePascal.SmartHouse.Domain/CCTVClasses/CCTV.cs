using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class CCTV : AbstractDevice
    {
        private const int degreesAtCreation = 0;
        private const int intensityAtOn = 60;
        //    -------ATTRIBUTES AND PROPERTY-------
        public Lamp CameraLed { get; private set; }
        public Degrees Degrees { get; private set; }

        //       ------CONSTRUCTORS------
        public CCTV(): base()
        {
            CameraLed = new Lamp();
            CameraLed.IntensityAtOn = new Intensity(intensityAtOn);
            Degrees = new Degrees(degreesAtCreation);
        }
        public CCTV(Guid id): base(id)
        {
            CameraLed = new Lamp();
            CameraLed.IntensityAtOn = new Intensity(intensityAtOn);
            Degrees = new Degrees(degreesAtCreation);
        }
        public CCTV(Guid id, string name): base(id, name)
        {
            CameraLed = new Lamp();
            CameraLed.IntensityAtOn = new Intensity(intensityAtOn);
            Degrees = new Degrees(degreesAtCreation);
        }

        //          ------METHODS------

        //--SWITCH METHODS--

        public override void SwitchOn()
        {
            base.SwitchOn();
            CameraLed.SwitchOn();
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            CameraLed.SwitchOff();
        }

        // --CHANGER METHODS--

        public void SetCCTVDegreesInto(Degrees newDegrees)
        {
            Degrees = newDegrees;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }

        //--RETURN METHODS--

        public void ReturnAllModifiesOfDevice() => ReturnAllModifiesOfDevice(this);
    }
}
