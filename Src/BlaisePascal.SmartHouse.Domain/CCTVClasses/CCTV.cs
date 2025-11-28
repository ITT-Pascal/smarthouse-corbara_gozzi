using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.LampClasses;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class CCTV : AbstractDevice
    {
        private const int intensityOfLed = 100;
        private const int intesnityOfLedOnStanby = 20;
        //-------ATTRIBUTES AND PROPERTY-------
        public Lamp CameraLed { get; set; }
        public VideoQuality QualityOfVideo { get; set; }

        //------CONSTRUCTORS------
        public CCTV(): base()
        {
            ID = new Guid();
            CameraLed = new Lamp("CameraLed");
            CameraLed.DeviceStatus = DeviceStatus.Off;
        }
        public CCTV(Guid id)
        {
            ID = id;
            CameraLed = new Lamp("CameraLed");
            CameraLed.DeviceStatus = DeviceStatus.Off;
        }
        public CCTV(Guid id, string name)
        {
            ID = id;
            Name = name;
            CameraLed = new Lamp("CameraLed");
            CameraLed.DeviceStatus = DeviceStatus.Off;
        }

        //------METHODS------
        public override void SwitchOn()
        {
            CameraLed.SwitchOn();
            CameraLed.Intensity = intensityOfLed;
            QualityOfVideo = VideoQuality._720P_60;
        }
        public override void SwitchOff()
        {
            CameraLed.SwitchOff();
        }
        public void PutInStanby()
        {
            if (DeviceStatus == DeviceStatus.On)
            {
                DeviceStatus = DeviceStatus.Stanby;
                CameraLed.Intensity = intesnityOfLedOnStanby;
                LastModifierAtUtc = DateTime.UtcNow;
            }
            
        }
        public void ChangeQualityOfVideo(VideoQuality newQuality){ QualityOfVideo = newQuality;}
    }
}
