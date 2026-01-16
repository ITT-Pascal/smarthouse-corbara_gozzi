using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.LampClasses;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class CCTV : AbstractDevice, ISwitchable
    {
        private const int intensityOfLed = 100;
        private const int degreesAtCreation = 90;
        //-------ATTRIBUTES AND PROPERTY-------
        public Lamp CameraLed { get; set; }
        public VideoQuality QualityOfVideo { get; private set; }
        public int Degrees { get; set; }

        //------CONSTRUCTORS------
        public CCTV(): base()
        {
            CameraLed = new Lamp("CameraLed");
            Degrees = degreesAtCreation;
        }
        public CCTV(Guid id): base(id)
        {
            CameraLed = new Lamp("CameraLed");
            Degrees = degreesAtCreation;
        }
        public CCTV(Guid id, string name): base(id, name)
        {
            CameraLed = new Lamp("CameraLed");
            Degrees = degreesAtCreation;
        }

        //------METHODS------
        public override void SwitchOn()
        {
            base.SwitchOn();
            CameraLed.SwitchOn();
            CameraLed.SetIntensity(intensityOfLed);
            QualityOfVideo = VideoQuality._720P_60;
        }

        public override void SwitchOff()
        {
            base.SwitchOff();
            CameraLed.SwitchOff();
        }

        public void ChangeQualityOfVideo(VideoQuality newQuality)
        { 
            QualityOfVideo = newQuality;
        }

        public void SetCCTVDegrees(int degrees)
        {
            Degrees = CCTVValidator.ValidateDegrees(degrees);
        }
    }
}
