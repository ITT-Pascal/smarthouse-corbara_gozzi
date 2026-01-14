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
        private const int intensityOfLedOnStandby = 20;
        //-------ATTRIBUTES AND PROPERTY-------
        public Lamp CameraLed { get; set; }
        public VideoQuality QualityOfVideo { get; private set; }

        //------CONSTRUCTORS------
        public CCTV(): base()
        {
            ID = new Guid();
            CameraLed = new Lamp("CameraLed");
        }
        public CCTV(Guid id): base()
        {
            ID = id;
            CameraLed = new Lamp("CameraLed");
        }
        public CCTV(Guid id, string name): base()
        {
            ID = id;
            Name = name;
            CameraLed = new Lamp("CameraLed");
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

        public void PutInStanby()
        {
            if (DeviceStatus == DeviceStatus.On)
            {
                DeviceStatus = DeviceStatus.Stanby;
                CameraLed.SetIntensity(intensityOfLedOnStandby);
                LastModifierAtUtc = DateTime.UtcNow;
            }
        }

        public void ChangeQualityOfVideo(VideoQuality newQuality)
        { 
            QualityOfVideo = newQuality;
        }

        //TODO: possibilità di farla girare di tot gradi

    }
}
