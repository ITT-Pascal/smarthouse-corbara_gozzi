using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.LAMP;

namespace BlaisePascal.SmartHouse.Domain.CCTV
{
    public class CCTV
    {
        private const int intensityOfLed = 100;
        private const int intesnityOfLedOnStanby = 20;
        //-------ATTRIBUTES AND PROPERTY-------
        public DeviceStatus CameraStatus { get; set; }
        public string ?CameraName { get; set; }
        public Guid ID { get; set; }
        public Lamp CameraLed { get; set; }
        public VideoQuality QualityOfVideo { get; set; }

        //------CONSTRUCTORS------
        public CCTV()
        {
            CameraStatus = DeviceStatus.Off;
            ID = new Guid();
            CameraLed = new Lamp("CameraLed");
            CameraLed.lampStatus = DeviceStatus.Off;
        }
        public CCTV(Guid id)
        {
            CameraStatus = DeviceStatus.Off;
            ID = id;
            CameraLed = new Lamp("CameraLed");
            CameraLed.lampStatus = DeviceStatus.Off;
        }
        public CCTV(Guid id, string name)
        {
            CameraStatus = DeviceStatus.Off;
            ID = id;
            CameraName = name;
            CameraLed = new Lamp("CameraLed");
            CameraLed.lampStatus = DeviceStatus.Off;
        }

        //------METHODS------
        public void SwitchOnCCTV()
        {
            CameraStatus = DeviceStatus.On;
            CameraLed.SwitchOn();
            CameraLed.Intensity = intensityOfLed;
            QualityOfVideo = VideoQuality._720P_60;
        }
        public void SwitchOffCCTV()
        {
            CameraStatus = DeviceStatus.Off;
            CameraLed.SwitchOff();
        }
        public void PutInStanby()
        {
            if (CameraStatus == DeviceStatus.On)
            {
                CameraStatus = DeviceStatus.Stanby;
                CameraLed.Intensity = intesnityOfLedOnStanby;
            }
        }
        public void ChangeQualityOfVideo(VideoQuality newQuality)
        {
            if (QualityOfVideo != newQuality)
            {
                QualityOfVideo = newQuality;
            }
        }
    }
}
