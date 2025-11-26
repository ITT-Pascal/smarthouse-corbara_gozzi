using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTVClasses;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.CCTVTests
{
    public class CCTVTest
    {
        [Fact]
        public void CCTV_Created_WhenIsCreatedTheStatusIsOffAlsoTheLampStatusIsOff()
        {
            CCTV TestCCTV = new CCTV();
            Assert.Equal(DeviceStatus.Off, TestCCTV.CameraStatus);
            Assert.Equal(DeviceStatus.Off, TestCCTV.CameraLed.LampStatus);
        }

        [Fact]
        public void CCTV_SwitchOn_WhenSwitchedOnTheLampStatusIsOnAndTheLedIsOnWithIntensity100AndVideoQualityIs720()
        {
            CCTV TestCCTV = new CCTV();
            TestCCTV.SwitchOnCCTV();
            Assert.Equal(DeviceStatus.On, TestCCTV.CameraStatus);
            Assert.Equal(DeviceStatus.On, TestCCTV.CameraLed.LampStatus);
            Assert.Equal(100, TestCCTV.CameraLed.Intensity);
            Assert.Equal(VideoQuality._720P_60, TestCCTV.QualityOfVideo);
        }

        [Fact]
        public void CCTV_SwitchOff_WhenSwitchedOffTheLampStatusIsOffAndTheLedIsOffAndVideoQualityIs720()
        {
            CCTV TestCCTV = new CCTV();
            TestCCTV.SwitchOnCCTV();
            TestCCTV.SwitchOffCCTV();
            Assert.Equal(DeviceStatus.Off, TestCCTV.CameraStatus);
            Assert.Equal(DeviceStatus.Off, TestCCTV.CameraLed.LampStatus);
            Assert.Equal(0, TestCCTV.CameraLed.Intensity);
            Assert.Equal(VideoQuality._720P_60, TestCCTV.QualityOfVideo);
        }

        [Fact]
        public void CCTV_PutInStanby_IfPutInStanbyTheStatusIsStanbyAndLedIntensityIs20()
        {
            CCTV TestCCTV = new CCTV();
            TestCCTV.SwitchOnCCTV();
            TestCCTV.PutInStanby();
            Assert.Equal(DeviceStatus.Stanby, TestCCTV.CameraStatus);
            Assert.Equal(DeviceStatus.On, TestCCTV.CameraLed.LampStatus);
            Assert.Equal(20, TestCCTV.CameraLed.Intensity);
            Assert.Equal(VideoQuality._720P_60, TestCCTV.QualityOfVideo);
        }

        [Fact]
        public void CCTV_ChangeQualityOfVideo_IfQualityIsSameItDoesNotChange()
        {
            CCTV TestCCTV = new CCTV();
            TestCCTV.SwitchOnCCTV();
            TestCCTV.ChangeQualityOfVideo(VideoQuality._720P_60);
            Assert.Equal(VideoQuality._720P_60, TestCCTV.QualityOfVideo);
        }

        [Fact]
        public void CCTV_ChangeQualityOfVideo_IfNewQualityIs1080TheNewIs1080()
        {
            CCTV TestCCTV = new CCTV();
            TestCCTV.SwitchOnCCTV();
            TestCCTV.ChangeQualityOfVideo(VideoQuality._1080P_HD);
            Assert.Equal(VideoQuality._1080P_HD, TestCCTV.QualityOfVideo);
        }

    }
}
