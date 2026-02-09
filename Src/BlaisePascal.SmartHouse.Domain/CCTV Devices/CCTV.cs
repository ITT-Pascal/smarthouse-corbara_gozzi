using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Luminous;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class CCTV : AbstractDevice, ISwitchable
    {
        private const int degreesAtCreation = 0;
        //    -------ATTRIBUTES AND PROPERTY-------
        public Lamp CameraLed { get; private set; }
        public Degrees Degrees { get; private set; }

        //       ------CONSTRUCTORS------
        public CCTV(): base()
        {
            CameraLed = new Lamp(Guid.NewGuid(), "CAMERA_LED");
            Degrees = Degrees.NewDegrees(degreesAtCreation);
        }
        public CCTV(Guid id): base(id)
        {
            CameraLed = new Lamp(Guid.NewGuid(), "CAMERA_LED");
            Degrees = Degrees.NewDegrees(degreesAtCreation);
        }
        public CCTV(Guid id, string name): base(id, name)
        {
            CameraLed = new Lamp(Guid.NewGuid(), "CAMERA_LED");
            Degrees = Degrees.NewDegrees(degreesAtCreation);
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
            ReturnAllModifiesOfDevice();
        }

        // --CHANGER METHODS--

        public void SetCCTVDegreesInto(Degrees newDegrees)
        {
            Degrees = newDegrees;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
    }
}
