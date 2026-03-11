using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;


namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.CCTVDevices
{
    public class CCTVTests        // #AvePulga 
    {                                   
        private readonly Guid id;
        private readonly CCTV cctv;


        public CCTVTests()
        {
            id = Guid.NewGuid();
            cctv = new CCTV(id, DeviceName.NewDeviceName("MRBraso"));
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
            Assert.Throws<InvalidOperationException> (() => cctv.IncreaseDegreesBy());
        }

        [Fact]
        public void CCTVTest_IncreaseDegreesBy_ItIncrease()
        {
			cctv.SwitchOn();
            cctv.IncreaseDegreesBy();
            Assert.Equal(new Degrees(10).Angle, cctv.Degrees.Angle);
        }
        [Fact]
        public void CCTVTest_IncreaseDegreesBy_IfMax()
        {
            cctv.SwitchOn();
            cctv.SetCCTVDegreesTo(new Degrees(350));
			cctv.IncreaseDegreesBy();
            cctv.IncreaseDegreesBy();
			Assert.Equal(new Degrees(10).Angle, cctv.Degrees.Angle);
		}

		[Fact]
        public void CCTVTest_DecreaseDegreesBy_ErrorBecouseOff()
        {
            Assert.Throws<InvalidOperationException>(() => cctv.DecreaseDegreesBy());
        }

        [Fact]
        public void CCTVTest_DecreaseDegreesBy_ItDecrease()
        {
            cctv.SwitchOn();
            cctv.IncreaseDegreesBy();
            cctv.IncreaseDegreesBy();
            cctv.DecreaseDegreesBy();
            Assert.Equal(new Degrees(10).Angle, cctv.Degrees.Angle);
        }

        [Fact]
        public void CCTVTest_DecreaseZoomBy_ErrorBecouseOff()
        {
            Assert.Throws<InvalidOperationException>(() => cctv.DecreaseZoomBy());
        }

        [Fact]
        public void CCTVTest_DecreaseZoomBy_ItDecrease() 
        {
            cctv.SwitchOn();
            cctv.DecreaseZoomBy();
            Assert.Equal(new Zoom(90).Value, cctv.Zoom.Value);
        }

        [Fact]
        public void CCTVTest_IncreaseZoomBy_ErrorBecouseOff()
        {
            Assert.Throws<InvalidOperationException>(() => cctv.IncreaseZoomBy());
        }

        [Fact]
        public void CCTVTest_IncreaseZoomBy_ItIncrease()
        {
            cctv.SwitchOn();
            cctv.IncreaseZoomBy();
            Assert.Equal(new Zoom(110).Value, cctv.Zoom.Value);
        }

        [Fact]
        public void CCTVTest_IncreaseZoomBy_IfMin()
        {
            cctv.SwitchOn();
            cctv.SetCCTVZoomTo(new Zoom(195));
            cctv.IncreaseZoomBy();
            Assert.Equal(new Zoom(200).Value, cctv.Zoom.Value);
		}

        [Fact]
        public void CCTVTest_SetCCTVDegreesTo_ErrorBecouseOff()
        {
            Assert.Throws<InvalidOperationException>(() => cctv.SetCCTVDegreesTo(new Degrees(10)));
        }

        [Fact]
        public void CCTVTest_SetCCTVDegreesTo_ItBecameTheNumber()
        {
            cctv.SwitchOn();
            cctv.SetCCTVDegreesTo(new Degrees(125));
            Assert.Equal(new Degrees(125).Angle, cctv.Degrees.Angle);
        }

        [Fact]
        public void CCTVTest_SetCCTVZoomTo_ErrorBecouseOff()
        {
            Assert.Throws<InvalidOperationException>(() => cctv.SetCCTVZoomTo(new Zoom(10)));
        }
    }
}
