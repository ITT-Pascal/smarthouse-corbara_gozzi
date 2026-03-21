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

        #region ON - OFF TESTS

        [Fact]
        public void CCTVTest_SwitchOn_IsOffAndItSwitchOn()
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

        #endregion

        #region DEGREES TESTS

        [Fact]
        public void CCTVTest_SetCCTVDegreesTo_ErrorBecauseOff()
        {
            Assert.Throws<InvalidOperationException>(() => cctv.SetCCTVDegreesTo(new Degrees(10)));
            Assert.Equal(DeviceStatus.Error, cctv.DeviceStatus);
        }

        [Fact]
        public void CCTVTest_SetCCTVDegreesTo_ItBecameTheNumber()
        {
            cctv.SwitchOn();

            cctv.SetCCTVDegreesTo(new Degrees(125));

            Assert.Equal(new Degrees(125).Angle, cctv.Degrees.Angle);
        }

        [Fact]
        public void CCTVTest_SetCCTVDegreesTo_ItBecame360IfIsOverMax()
        {
            cctv.SwitchOn();

            cctv.SetCCTVDegreesTo(new Degrees(365));

            Assert.Equal(new Degrees(5).Angle, cctv.Degrees.Angle);
        }

        [Fact]
        public void CCTVTest_IncreaseDegreesBy_ErrorBecauseOff()
        {    
            Assert.Throws<InvalidOperationException> (() => cctv.IncreaseDegreesBy());
            Assert.Equal(DeviceStatus.Error, cctv.DeviceStatus);
        }

        [Fact]
        public void CCTVTest_IncreaseDegreesBy_IsOnSoItIncrease()
        {
			cctv.SwitchOn();

            cctv.IncreaseDegreesBy();

            Assert.Equal(new Degrees(10).Angle, cctv.Degrees.Angle);
        }

        [Fact]
        public void CCTVTest_IncreaseDegreesBy_IfIsOver360ItReturnFrom0()
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
            Assert.Equal(DeviceStatus.Error, cctv.DeviceStatus);
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
        public void CCTVTest_DecreaseDegreesBy_IfIsUnder0ItReturnFrom360()
        {
            cctv.SwitchOn();
            cctv.IncreaseDegreesBy();

            cctv.DecreaseDegreesBy();
            cctv.DecreaseDegreesBy();

            Assert.Equal(new Degrees(350).Angle, cctv.Degrees.Angle);
        }

        #endregion

        #region ZOOM TESTS

        [Fact]
        public void CCTVTest_SetCCTVZoomTo_ErrorBecauseOff()
        {
            Assert.Throws<InvalidOperationException>(() => cctv.SetCCTVZoomTo(new Zoom(10)));
            Assert.Equal(DeviceStatus.Error, cctv.DeviceStatus);
        }

        [Fact]
        public void CCTVTest_SetCCTVZoomTo_ZoomIsSetToValue()
        {
            cctv.SwitchOn();

            cctv.SetCCTVZoomTo(new Zoom(150));

            Assert.Equal(new Zoom(150).Value, cctv.Zoom.Value);
        }

        [Fact]
        public void CCTVTest_SetCCTVZoomTo_ZoomIsSetToMinIfIsUnderIt()
        {
            cctv.SwitchOn();

            cctv.SetCCTVZoomTo(new Zoom(5));

            Assert.Equal(new Zoom(10).Value, cctv.Zoom.Value);
        }

        [Fact]
        public void CCTVTest_SetCCTVZoomTo_ZoomIsSetToMaxIfIsOverIt()
        {
            cctv.SwitchOn();

            cctv.SetCCTVZoomTo(new Zoom(251));

            Assert.Equal(new Zoom(200).Value, cctv.Zoom.Value);
        }

        [Fact]
        public void CCTVTest_IncreaseZoomBy_ErrorBecouseOff()
        {
            Assert.Throws<InvalidOperationException>(() => cctv.IncreaseZoomBy());
            Assert.Equal(DeviceStatus.Error, cctv.DeviceStatus);
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
        public void CCTVTest_DecreaseZoomBy_ErrorBecouseOff()
        {
            Assert.Throws<InvalidOperationException>(() => cctv.DecreaseZoomBy());
            Assert.Equal(DeviceStatus.Error, cctv.DeviceStatus);
        }

        [Fact]
        public void CCTVTest_DecreaseZoomBy_ItDecrease() 
        {
            cctv.SwitchOn();

            cctv.DecreaseZoomBy();

            Assert.Equal(new Zoom(90).Value, cctv.Zoom.Value);
        }

        [Fact]
        public void CCTVTest_DecreaseZoomBy_IfUnder10IsSetTo10()
        {
            cctv.SwitchOn();
            cctv.SetCCTVZoomTo(new Zoom(15));

            cctv.DecreaseZoomBy();

            Assert.Equal(new Zoom(10).Value, cctv.Zoom.Value);
        }

        #endregion
    }
}
