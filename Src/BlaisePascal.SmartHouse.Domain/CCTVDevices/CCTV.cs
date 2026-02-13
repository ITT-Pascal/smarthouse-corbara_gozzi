using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.CCTV_Devices;
using BlaisePascal.SmartHouse.Domain.Luminous;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class CCTV : AbstractDevice, ISwitchable
    {
        private const int basicZoom = 100;
        private const int basicJump = 10;
        //    -------ATTRIBUTES AND PROPERTY-------
        public Lamp CameraLamp { get; private set; }
        public Degrees Degrees { get; private set; }
        public Zoom Zoom { get; private set; }

        //       ------CONSTRUCTORS------
        public CCTV(): base()
        {
            CameraLamp = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("CAMERA_LED"));
            Degrees = Degrees.NewDegrees(Degrees.minDegrees);
            Zoom = Zoom.NewZoom(basicZoom);
        }
        public CCTV(Guid id): base(id)
        {
            CameraLamp = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("CAMERA_LED"));
            Degrees = Degrees.NewDegrees(Degrees.minDegrees);
            Zoom = Zoom.NewZoom(basicZoom);
        }
        public CCTV(Guid id, DeviceName name): base(id, name)
        {
            CameraLamp = new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName("CAMERA_LED"));
            Degrees = Degrees.NewDegrees(Degrees.minDegrees);
            Zoom = Zoom.NewZoom(basicZoom);
        }

        //          ------METHODS------

        //--SWITCH METHODS--

        public override void SwitchOn()
        {
            base.SwitchOn();
            CameraLamp.SwitchOn();
        }
        public override void SwitchOff()
        {
            base.SwitchOff();
            CameraLamp.SwitchOff();
        }

        // --CHANGER METHODS--

        public void IncreaseDegreesBy()
        {
            CheckMethodCompatibilityWith(DeviceStatus.Off);
            Degrees = Degrees.NewDegrees(Degrees.Angle + basicJump);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void DecreaseDegreesBy()
        {
            CheckMethodCompatibilityWith(DeviceStatus.Off);
            Degrees = Degrees.NewDegrees(Degrees.Angle - basicJump);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void SetCCTVDegreesTo(Degrees newDegrees)
        {
            CheckMethodCompatibilityWith(DeviceStatus.Off);
            Degrees = newDegrees;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void IncreaseZoomBy()
        {
            Zoom = Zoom.NewZoom(Zoom.Value + basicJump);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void DecreaseZoomBy()
        {
            Zoom = Zoom.NewZoom(Zoom.Value - basicJump);
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
        public void SetCCTVZoomTo(Zoom zoom)
        {
            CheckMethodCompatibilityWith(DeviceStatus.Off);
            Zoom = zoom;
            LastModifierAtUtc = DateTime.UtcNow;
            HistoryOfMod.Add(DateTime.UtcNow);
        }
    }
}
