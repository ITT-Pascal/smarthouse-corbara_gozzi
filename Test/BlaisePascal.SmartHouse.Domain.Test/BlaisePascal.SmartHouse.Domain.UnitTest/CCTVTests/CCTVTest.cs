using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.CCTVTests
{
    public class CCTVTest
    {
        [Fact]
        public void CCTV_Created_WhenIsCreatedTheStatusIsOffAlsoTheLampStatusIsOff()
        {
            CCTV TestCCTV = new CCTV();
            Assert.Equal(DeviceStatus.Off, TestCCTV.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestCCTV.CameraLamp.DeviceStatus);
        }

        [Fact]
        public void CCTV_SwitchOn_WhenSwitchedOnTheLampStatusIsOnAndTheLedIsOnWithIntensity100AndVideoQualityIs720()
        {
            CCTV TestCCTV = new CCTV();
            TestCCTV.SwitchOn();
            Assert.Equal(DeviceStatus.On, TestCCTV.DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestCCTV.CameraLamp.DeviceStatus);
            Assert.Equal(100, TestCCTV.CameraLamp.Intensity);
            Assert.Equal(VideoQuality._720P_60, TestCCTV.QualityOfVideo);
        }

        [Fact]
        public void CCTV_SwitchOff_WhenSwitchedOffTheLampStatusIsOffAndTheLedIsOffAndVideoQualityIs720()
        {
            CCTV TestCCTV = new CCTV();
            TestCCTV.SwitchOn();
            TestCCTV.SwitchOff();
            Assert.Equal(DeviceStatus.Off, TestCCTV.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestCCTV.CameraLamp.DeviceStatus);
            Assert.Equal(0, TestCCTV.CameraLamp.Intensity);
            Assert.Equal(VideoQuality._720P_60, TestCCTV.QualityOfVideo);
        }

        [Fact]
        public void CCTV_ChangeQualityOfVideo_IfQualityIsSameItDoesNotChange()
        {
            CCTV TestCCTV = new CCTV();
            TestCCTV.SwitchOn();
            TestCCTV.ChangeQualityOfVideoTo(VideoQuality._720P_60);
            Assert.Equal(VideoQuality._720P_60, TestCCTV.QualityOfVideo);
        }

        [Fact]
        public void CCTV_ChangeQualityOfVideo_IfNewQualityIs1080TheNewIs1080()
        {
            CCTV TestCCTV = new CCTV();
            TestCCTV.SwitchOn();
            TestCCTV.ChangeQualityOfVideoTo(VideoQuality._1080P_HD);
            Assert.Equal(VideoQuality._1080P_HD, TestCCTV.QualityOfVideo);
        }

    }
}
