using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class CCTV : AbstractDevice, ISwitchable
    {
        private const int degreesAtCreation = 0;
        //-------ATTRIBUTES AND PROPERTY-------
        public Intensity intensityOfLedAtOn { get; init; }
        public Lamp CameraLed { get; private set; }
        public VideoQuality QualityOfVideo { get; private set; }
        public Degrees Degrees { get; private set; }

        //------CONSTRUCTORS------
        public CCTV(): base()
        {
            intensityOfLedAtOn = new Intensity(20);
            CameraLed = new Lamp();
            Degrees = new Degrees(degreesAtCreation);
        }
        public CCTV(Guid id): base(id)
        {
            intensityOfLedAtOn = new Intensity(20);
            CameraLed = new Lamp();
            Degrees = new Degrees(degreesAtCreation);
        }
        public CCTV(Guid id, string name): base(id, name)
        {
            intensityOfLedAtOn = new Intensity(20);
            CameraLed = new Lamp();
            Degrees = new Degrees(degreesAtCreation);
        }

        //------METHODS------
        public override void SwitchOn()
        {
            base.SwitchOn();
            CameraLed.SwitchOn();
            CameraLed.SetIntensityTo(intensityOfLedAtOn);
            QualityOfVideo = VideoQuality._720P_60;
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            CameraLed.SwitchOff();
        }
        public void ChangeQualityOfVideoTo(VideoQuality newQuality)
        { 
            QualityOfVideo = newQuality;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void SetCCTVDegreesInto(Degrees newDegrees)
        {
            Degrees = newDegrees;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        /// <summary>
        /// MODALITA' VISIONE NOTTURNA
        /// </summary>
        public void SetNightVision()
        {
            QualityOfVideo = VideoQuality.NightVision;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void ReturnAllModifiesOfDevice() => ReturnAllModifiesOfDevice(this);
    }
}
