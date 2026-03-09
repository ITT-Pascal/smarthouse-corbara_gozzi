using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.CCTVDevices
{
    public class CCTVSetTests
    {
        CCTVSet cctvPass = new(Password.NewPassword("Ale6767?"));
        CCTVSet cctvSet = new();
        CCTV c = new();
        CCTV cam = new(Guid.NewGuid(), DeviceName.NewDeviceName("Braso"));

        [Fact]
        public void CCTVSetTest_Constructor_Empty()
        {
            Assert.NotNull(cctvSet);
            Assert.NotNull(cctvSet.SetOfCCTV);
            Assert.Empty(cctvSet.SetOfCCTV);
            Assert.Equal(Password.NewPassword("Ale6767!"), cctvSet.AdminPassword);
        }

        [Fact]
        public void CCTVSetTest_Constructor_WithPassword()
        {
            Assert.Equal(Password.NewPassword("Ale6767?"), cctvPass.AdminPassword);
            Assert.NotNull(cctvPass);
            Assert.NotNull(cctvPass.SetOfCCTV);
            Assert.Empty(cctvPass.SetOfCCTV);
        }

        [Fact]
        public void CCTVSetTest_AccessToSistem_WrongPassword()
        {
            Assert.Throws<ArgumentException>(() => cctvSet.AccessToSistem(Password.NewPassword("Ale6768!")));
        }

        [Fact]
        public void CCTVSetTest_AccessToSistem_RightPassWord()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            Assert.True(cctvSet.AccessPermission);
        }

        [Fact]
        public void CCTVSetTest_AddCCTV_IsNull()
        {
            Assert.Throws<ArgumentNullException>(() => cctvSet.AddCCTV(null));
        }

        [Fact]
        public void CCTVSetTest_AddCCTV_AddsACCTV()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(c);
            Assert.Single(cctvSet.SetOfCCTV);
        }

        [Fact]
        public void CCTVSetTest_AddCCTV_NoAccessToSistem()
        {
            Assert.Throws<InvalidOperationException>(() => cctvSet.AddCCTV(c));
        }

        [Fact]
        public void CCTVSetTest_AddCCTVIn_IsNull()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            Assert.Throws<ArgumentNullException>(() => cctvSet.AddCCTVIn(0, null));
        }

        [Fact]
        public void CCTVSetTest_AddCCTVIn_NoAccessToSistem()
        {
            Assert.Throws<ArgumentException>(() => cctvSet.AddCCTVIn(0, c));
        }

        [Fact]
        public void CCTVSetTest_AddCCTVIn_OutOfRange()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            Assert.Throws<ArgumentOutOfRangeException>(() => cctvSet.AddCCTVIn(-1, c));
        }

        [Fact]
        public void CCTVSet_AddCCTVIn_ItAddsANewCCTV()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTVIn(0, c);
            Assert.Single(cctvSet.SetOfCCTV);
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVAt_NoAcces()
        {
            Assert.Throws<ArgumentException>(() => cctvSet.RemoveCCTVAt(0));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVAt_RangeExeption()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            Assert.Throws<ArgumentOutOfRangeException>(() => cctvSet.RemoveCCTVAt(-1));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVAt_ItRemoveTheCCTV()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTVIn(0, c);
            cctvSet.RemoveCCTVAt(0);
            Assert.Empty(cctvSet.SetOfCCTV);
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVBy_NameNoAccess() 
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(c);
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            Assert.Throws<InvalidOperationException>(() => cctvSet.RemoveCCTVBy(DeviceName.NewDeviceName("Braso")));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVBy_NameItRemoveIt()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(cam);
            cctvSet.RemoveCCTVBy(DeviceName.NewDeviceName("Braso"));
            Assert.Empty(cctvSet.SetOfCCTV);
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVBy_GuidNoAccess()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(cam);
            cctvSet.AccessToSistem(Password.NewPassword("12345678"));
            Assert.Throws<InvalidOperationException>(() => cctvSet.RemoveCCTVBy(cam.ID));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVBy_GuidItRemoveIt()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(cam);
            cctvSet.RemoveCCTVBy(cam.ID);
            Assert.Empty(cctvSet.SetOfCCTV);
        }

        [Fact]
        public void CCTVSetTest_SwitchOnBy_GuidNoAccess()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(cam);
            cctvSet.AccessToSistem(Password.NewPassword("12345678"));
            Assert.Throws<InvalidOperationException>(() => cctvSet.SwitchOnBy(cam.ID));
        }

        [Fact]
        public void CCTVSetTest_SwitchOnBy_GuidItSwitchOnIt()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(cam);
            cctvSet.SwitchOnBy(cam.ID);         
            Assert.Equal(DeviceStatus.On, cctvSet.SetOfCCTV[0].DeviceStatus); 
        }

        [Fact]
        public void CCTVSetTest_SwitchOnBy_NameNoAccess()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(c);
            cctvSet.AccessToSistem(Password.NewPassword("12345678"));
            Assert.Throws<InvalidOperationException>(() => cctvSet.SwitchOnBy(new DeviceName("Braso")));
        }

        [Fact]
        public void CCTVSetTest_SwitchOnBy_NameItSwitchOn() 
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(cam);
            cctvSet.SwitchOnBy(cam.Name);
            Assert.Equal(DeviceStatus.On, cctvSet.SetOfCCTV[0].DeviceStatus);
        }

        [Fact]
        public void CCTVSetTest_SwitchOffBy_GuidNoAccess() 
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(cam);
            cctvSet.SwitchOnBy(cam.ID);
            cctvSet.AccessToSistem(Password.NewPassword("12345678"));
            Assert.Throws<InvalidOperationException>(() => cctvSet.SwitchOffBy(cam.ID));
        }

        [Fact]
        public void CCTVSetTest_SwitchOffBy_GuidItSwitchOnIt() 
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(cam);
            cctvSet.SwitchOnBy(cam.ID);
            cctvSet.SwitchOffBy(cam.ID);
            Assert.Equal(DeviceStatus.Off, cctvSet.SetOfCCTV[0].DeviceStatus);
        }

        [Fact]
        public void CCTVSetTest_SwitchOffBy_NameNoAccess() 
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(cam);
            cctvSet.SwitchOnBy(cam.Name);
            cctvSet.AccessToSistem(Password.NewPassword("12345678"));
            Assert.Throws<InvalidOperationException>(() => cctvSet.SwitchOffBy(new DeviceName("Braso")));
        }

        [Fact]
        public void CCTVSetTest_SwitchOffBy_NameItSwitchOn() 
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767!"));
            cctvSet.AddCCTV(cam);
            cctvSet.SwitchOnBy(cam.Name);
            cctvSet.SwitchOffBy(cam.Name);
            Assert.Equal(DeviceStatus.Off, cctvSet.SetOfCCTV[0].DeviceStatus);
        }

        


    }
} 