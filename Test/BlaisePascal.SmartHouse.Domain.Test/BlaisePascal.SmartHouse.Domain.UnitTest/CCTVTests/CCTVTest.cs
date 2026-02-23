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
        public void CCTVTest_Created_NameAndGuid()
        {
            Assert.NotNull(cctv);
            Assert.NotNull(cctv.CameraLamp);
            Assert.Equal(id, cctv.ID);
            Assert.Equal(new Zoom(100) , cctv.Zoom);
            Assert.Equal(new Degrees(0), cctv.Degrees);
            Assert.Equal(DeviceStatus.Off, cctv.DeviceStatus);
        }

        [Fact]
        public void CCTVTest_Created_Guid()
        {
            Assert.NotNull(cctv);
            Assert.NotNull(cctv.CameraLamp);
            Assert.Equal(id, cctv.ID);
            Assert.Equal(new Zoom(100), cctv.Zoom);
            Assert.Equal(new Degrees(0), cctv.Degrees);
            Assert.Equal(DeviceStatus.Off, cctv.DeviceStatus);
        }

        [Fact]
        public void CCTVTest_Created_Empty()
        {
            Assert.NotNull(cctv);
            Assert.NotNull(cctv.CameraLamp);
            Assert.Equal(id, cctv.ID);
            Assert.Equal(new Zoom(100), cctv.Zoom);
            Assert.Equal(new Degrees(0), cctv.Degrees);
            Assert.Equal(DeviceStatus.Off, cctv.DeviceStatus);
        }

        [Fact]
        public void CCTVTest_SwitchOn_ItTurnOn()
        {
            cctv.SwitchOn();
            Assert.Equal(DeviceStatus.On, cctv.DeviceStatus);
            Assert.Equal(DeviceStatus.On, cctv.CameraLamp.DeviceStatus);
        }

        [Fact]
        public void CCTVTest_SwitchOff_ItTurnOff()
        {
            cctv.SwitchOn();
            cctv.SwitchOff();
            Assert.Equal(DeviceStatus.Off, cctv.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, cctv.CameraLamp.DeviceStatus);
        }

        [Fact]
        public void CCTVTest_IncreaseDegreesBy_ErrorBecouseOff()
        {    
            Assert.Throws<ArgumentException> (() => cctv.IncreaseDegreesBy());
        }

        [Fact]
        public void CCTVTest_IncreaseDegreesBy_ItIncrease()
        {
            cctv.SwitchOn();
            cctv.IncreaseDegreesBy();
            Assert.Equal(new Degrees(110), cctv.Degrees);
        }

        [Fact]
        public void CCTVTest_IncreaseDegreesBy_IfMax()
        {
            cctv.SwitchOn();
            for(int i = 0; i < 36; i++)
            {
                cctv.IncreaseDegreesBy();
            }
            cctv.IncreaseDegreesBy();
            Assert.Equal(new Degrees(360), cctv.Degrees);
        }

        [Fact]
        public void CCTVTest_DecreaseDegreesBy_ErrorBecouseOff()
        {
            Assert.Throws<ArgumentException>(() => cctv.DecreaseDegreesBy());
        }

        [Fact]
        public void CCTVTest_DecreaseDegreesBy_ItDecrease()
        {
            cctv.SwitchOn();
            cctv.IncreaseDegreesBy();
            cctv.IncreaseDegreesBy();
            cctv.DecreaseDegreesBy();
            Assert.Equal(new Degrees(10), cctv.Degrees);
        }

        [Fact]
        public void CCTVTest_DecreaseDegreesBy_IfMin()
        {
            cctv.SwitchOn();
            cctv.DecreaseDegreesBy();
            Assert.Equal(new Degrees(0), cctv.Degrees);
        }

        [Fact]
        public void CCTVTest_DecreaseZoomBy_ErrorBecouseOff()
        {
            Assert.Throws<ArgumentException>(() => cctv.DecreaseZoomBy());
        }

        [Fact]
        public void CCTVTest_DecreaseZoomBy_ItDecrease() 
        {
            cctv.SwitchOn();
            cctv.DecreaseZoomBy();
            Assert.Equal(new Zoom(90), cctv.Zoom);
        }

        [Fact]
        public void CCTVTest_DecreaseZoomBy_IfMin()  
        {
            cctv.SwitchOn();
            for (int i = 0; i < 10; i++)
            {
                cctv.DecreaseZoomBy();
            }
            cctv.DecreaseZoomBy();
            Assert.Equal(new Zoom(0), cctv.Zoom);
        }

        [Fact]
        public void CCTVTest_IncreaseZoomBy_ErrorBecouseOff()
        {
            Assert.Throws<ArgumentException>(() => cctv.IncreaseZoomBy());
        }

        [Fact]
        public void CCTVTest_IncreaseZoomBy_ItDecrease()
        {
            cctv.SwitchOn();
            cctv.IncreaseZoomBy();
            Assert.Equal(new Zoom(110), cctv.Zoom);
        }

        [Fact]
        public void CCTVTest_IncreaseZoomBy_IfMin()
        {
            cctv.SwitchOn();
            for (int i = 0; i < 10; i++)
            {
                cctv.IncreaseZoomBy();
            }
            cctv.IncreaseZoomBy();
            Assert.Equal(new Zoom(200), cctv.Zoom);
        }

        [Fact]
        public void CCTVTest_SetCCTVDegreesTo_ErrorBecouseOff()
        {
            Assert.Throws<ArgumentException>(() => cctv.SetCCTVDegreesTo(new Degrees(10)));
        }

        [Fact]
        public void CCTVTest_SetCCTVDegreesTo_IsTooHighSoGoToMax()
        {
            cctv.SwitchOn();
            cctv.SetCCTVDegreesTo(new Degrees(1000));
            Assert.Equal(new Degrees(200), cctv.Degrees);
        }

        [Fact]
        public void CCTVTest_SetCCTVDegreesTo_ItBecameTheNumber()
        {
            cctv.SwitchOn();
            cctv.SetCCTVDegreesTo(new Degrees(125));
            Assert.Equal(new Degrees(125), cctv.Degrees);
        }

        [Fact]
        public void CCTVTest_SetCCTVZoomTo_ErrorBecouseOff()
        {
            Assert.Throws<ArgumentException>(() => cctv.SetCCTVZoomTo(new Zoom(10)));
        }

        [Fact]
        public void CCTVTest_SetCCTVZoomTo_IsTooHighSoGoToMax()
        {
            cctv.SwitchOn();
            cctv.SetCCTVZoomTo(new Zoom(1000));
            Assert.Equal(new Zoom(200), cctv.Zoom);
        }

        [Fact]
        public void CCTVTest_SetCCTVZoomTo_ItBecameTheNumber()
        {
            cctv.SwitchOn();
            cctv.SetCCTVZoomTo(new Zoom(125));
            Assert.Equal(new Zoom(125), cctv.Zoom);
        }
    }
}
