using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.LampClasses;
using BlaisePascal.SmartHouse.Domain.CCTVClasses;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.CCTVTests
{
    public class CCTVSetTest
    {
        CCTVSet TestCCTVset = new CCTVSet("123456");

        [Fact]
        public void CCTVSet_Created_CCTVSetIsEmpty(){ Assert.Empty(TestCCTVset.CCTVset); }

        [Fact]
        public void CCTVSet_AddCCTV_ANewCCTVIsAdded()
        {
            CCTV cam = new CCTV();
            TestCCTVset.AddCCTV(cam);
            Assert.Single(TestCCTVset.CCTVset);
        }

        [Fact]
        public void CCTVSet_AddCCTV_AddTwoCCTVs()
        {
            TestCCTVset.AddCCTV(new CCTV());
            TestCCTVset.AddCCTV(new CCTV());
            Assert.Equal(2, TestCCTVset.CCTVset.Count);
        }

        [Fact]
        public void CCTVSet_AddCCTVInPosition_WeAddALampNamedBrasoInPos1()
        {
            TestCCTVset.AddCCTV(new CCTV());
            TestCCTVset.AddCCTV(new CCTV());
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Braso"), 1);
            Assert.Equal("Braso", TestCCTVset.CCTVset[1].Name);
        }

        [Fact]
        public void CCTVSet_RemoveCCTVInPosition_IfAdminPasswordIsCorrectTheCCTVIsRemoved()
        {
            TestCCTVset.AddCCTV(new CCTV());
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Ciao"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Braso"), 1);
            TestCCTVset.RemoveCCTV(1, "123456");
            Assert.Equal("Ciao", TestCCTVset.CCTVset[1].Name);
        }

        [Fact]
        public void CCTVSet_RemoveCCTV_CCTVRemovedFromID()
        {
            Guid testId = new Guid();
            Guid testId2 = new Guid();
            TestCCTVset.AddCCTV(new CCTV(testId, "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(testId2, "CCTV"));
            TestCCTVset.RemoveCCTV(testId2, "123456");
            Assert.Single(TestCCTVset.CCTVset);
            Assert.Equal(testId, TestCCTVset.CCTVset[0].ID);
        }

        [Fact]
        public void CCTVSet_RemoveCCTV_CCTVRemovedFromName()
        {
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Braso controllore"));
            TestCCTVset.RemoveCCTV("Braso controllore", "123456");
            Assert.Single(TestCCTVset.CCTVset);
            Assert.Equal("CCTV", TestCCTVset.CCTVset[0].Name);
        }

        [Fact]
        public void CCTVSet_SwitchOn_SwitchOnAllCCTVs()
        {
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Braso controllore"));
            TestCCTVset.SwitchOn();
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[1].DeviceStatus);
        }

        [Fact]
        public void CCTVSet_SwitchOn_SwitchOnCCTVFromID()
        {
            Guid testId = new Guid();
            Guid testId2 = new Guid();
            TestCCTVset.AddCCTV(new CCTV(testId, "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(testId2, "CCTV"));
            TestCCTVset.SwitchOn(testId2);
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[1].DeviceStatus);
        }

        [Fact]
        public void CCTVSet_SwitchOn_SwitchOnCCTVFromName()
        {
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Sas"));
            TestCCTVset.SwitchOn("Sas");
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[1].DeviceStatus);
        }

        [Fact]
        public void CCTVSet_SwitchOn_SwitchOnMultipleCCTVsFromName()
        {
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Sas"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Sas"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Sas"));
            TestCCTVset.SwitchOn("Sas");
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[1].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[2].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[1].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[1].DeviceStatus);
        }

        [Fact]
        public void CCTVSet_SwitchOff_SwitchOffAllCCTVs()
        {
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Sas"));
            TestCCTVset.SwitchOn();
            TestCCTVset.SwitchOff("123456");
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[0].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[1].DeviceStatus);
        }

        [Fact]
        public void CCTVSet_SwitchOff_SwitchOffCCTVFromID()
        {
            Guid testId = new Guid();
            Guid testId2 = new Guid();
            TestCCTVset.AddCCTV(new CCTV(testId, "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(testId2, "CCTV"));
            TestCCTVset.SwitchOn();
            TestCCTVset.SwitchOff(testId, "123456");
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[0].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[1].DeviceStatus);
        }

        [Fact]
        public void CCTVSet_SwitchOff_SwitchOffCCTVFromName()
        {
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Sas"));
            TestCCTVset.SwitchOn("Sas");
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[1].DeviceStatus);
        }

        [Fact]
        public void CCTVSet_SwitchOff_SwitchOffMultipleCCTVsFromName()
        {
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Sas"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "CCTV"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Sas"));
            TestCCTVset.AddCCTV(new CCTV(new Guid(), "Sas"));
            TestCCTVset.SwitchOn();
            TestCCTVset.SwitchOff("Sas", "123456");
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[0].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[1].DeviceStatus);
            Assert.Equal(DeviceStatus.On, TestCCTVset.CCTVset[2].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[1].DeviceStatus);
            Assert.Equal(DeviceStatus.Off, TestCCTVset.CCTVset[1].DeviceStatus);
        }
    }
}