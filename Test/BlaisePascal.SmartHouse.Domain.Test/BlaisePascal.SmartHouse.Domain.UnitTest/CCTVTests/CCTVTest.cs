using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.CCTVDevices.ValueObjects;


namespace BlaisePascal.SmartHouse.Domain.UnitTest.CCTVTests
{
    public class CCTVTest        // #AvePulga 
    {                                   
        private readonly Guid id;
        private readonly CCTV cctv;


        public CCTVTest()
        {
            id = Guid.NewGuid();
            cctv = new CCTV(id, DeviceName.NewDeviceName("MR.Braso"));
        }

        [Fact]
        public void CCTVest_Created_NameAndGuid()
        {
            Assert.NotNull(cctv);
            Assert.NotNull(cctv.CameraLamp);
            Assert.Equal(id, cctv.ID);
            Assert.Equal(new Zoom(100) , cctv.Zoom);
            Assert.Equal(new Degrees(0), cctv.Degrees);
            Assert.Equal(DeviceStatus.Off, cctv.DeviceStatus);
        }

        [Fact]
        public void CCTVest_Created_Guid()
        {
            Assert.NotNull(cctv);
            Assert.NotNull(cctv.CameraLamp);
            Assert.Equal(id, cctv.ID);
            Assert.Equal(new Zoom(100), cctv.Zoom);
            Assert.Equal(new Degrees(0), cctv.Degrees);
            Assert.Equal(DeviceStatus.Off, cctv.DeviceStatus);
        }

        [Fact]
        public void CCTVest_Created_Empty()
        {
            Assert.NotNull(cctv);
            Assert.NotNull(cctv.CameraLamp);
            Assert.Equal(id, cctv.ID);
            Assert.Equal(new Zoom(100), cctv.Zoom);
            Assert.Equal(new Degrees(0), cctv.Degrees);
            Assert.Equal(DeviceStatus.Off, cctv.DeviceStatus);
        }

        [Fact]
        public void CCTVest_SwitchOn_ItTurnOn()
        {
            cctv.SwitchOn();
            Assert.Equal(DeviceStatus.On, cctv.DeviceStatus);
            Assert.Equal(DeviceStatus.On, cctv.CameraLamp.DeviceStatus);
        }

        [Fact]
        public void CCTVest_SwitchOff_ItTurnOff()
        {
            cctv.SwitchOn();
            cctv.SwitchOff();
            Assert.Equal(DeviceStatus.Off, cctv.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, cctv.CameraLamp.DeviceStatus);
        }

        [Fact]
        public void CCTVest_IncreaseDegreesBy_ErrorBecouseOff()
        {    
            Assert.Throws<ArgumentException> (() => cctv.IncreaseDegreesBy());
        }

        [Fact]
        public void CCTVest_IncreaseDegreesBy_ItIncrease()
        {
            cctv.SwitchOn();
            cctv.IncreaseDegreesBy();
            Assert.Equal(new Degrees(110), cctv.Degrees);
        }

        [Fact]
        public void CCTVest_IncreaseDegreesBy_IfMax()
        {
            cctv.SwitchOn();
            for(int i = 0; i < 26; i++)
            {
                cctv.IncreaseDegreesBy();
            }
            cctv.IncreaseDegreesBy();
            Assert.Equal(new Degrees(360), cctv.Degrees);
        }

        [Fact]
        public void CCTVest_DecreaseDegreesBy_ErrorBecouseOff()
        {
            Assert.Throws<ArgumentException>(() => cctv.DecreaseDegreesBy());
        }

        [Fact]
        public void CCTVest_DecreaseDegreesBy_ItDecrease()
        {
            cctv.SwitchOn();
            cctv.DecreaseDegreesBy();
            Assert.Equal(new Degrees(90), cctv.Degrees);
        }

        [Fact]
        public void CCTVest_DecreaseDegreesBy_IfMin()
        {
            cctv.SwitchOn();
            for (int i = 0; i < 10; i++)
            {
                cctv.DecreaseDegreesBy();
            }
            cctv.DecreaseDegreesBy();
            Assert.Equal(new Degrees(0), cctv.Degrees);
        }

        [Fact]
        public void CCTVest_DecreaseZoomBy_ErrorBecouseOff()
        {
            Assert.Throws<ArgumentException>(() => cctv.DecreaseZoomBy());
        }

        [Fact]
        public void CCTVest_DecreaseZoomBy_ItDecrease() // DA SISTEMARE
        {
            cctv.SwitchOn();
            cctv.DecreaseDegreesBy();
            Assert.Equal(new Degrees(90), cctv.Degrees);
        }

        [Fact]
        public void CCTVest_DecreaseZoomBy_IfMin()  //DA SISTEMARE
        {
            cctv.SwitchOn();
            for (int i = 0; i < 10; i++)
            {
                cctv.DecreaseDegreesBy();
            }
            cctv.DecreaseDegreesBy();
            Assert.Equal(new Degrees(0), cctv.Degrees);
        }
    }
}
