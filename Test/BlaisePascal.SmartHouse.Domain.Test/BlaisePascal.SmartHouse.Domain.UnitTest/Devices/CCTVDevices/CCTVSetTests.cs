using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.CCTVDevices
{
    public class CCTVSetTests
    {
        readonly CCTVSet cctvPass = new(Password.NewPassword("Ale6767!"));
        readonly CCTVSet cctvSet = new();
        readonly CCTV c = new();
        readonly CCTV cam = new(Guid.NewGuid(), DeviceName.NewDeviceName("Braso"));

        [Fact]
        public void CCTVSetTest_Constructor_Empty()
        {
            Assert.NotNull(cctvSet);
            Assert.NotNull(cctvSet.SetOfCCTV);
            Assert.Empty(cctvSet.SetOfCCTV);
            Assert.Equal(Password.NewPassword("Ale6767?").Word, cctvSet.AdminPassword.Word);
        }

        [Fact]
        public void CCTVSetTest_Constructor_WithPassword()
        {
            Assert.Equal(Password.NewPassword("Ale6767!").Word, cctvPass.AdminPassword.Word);
            Assert.NotNull(cctvPass);
            Assert.NotNull(cctvPass.SetOfCCTV);
            Assert.Empty(cctvPass.SetOfCCTV);
        }

        #region ACCESS TO SISTEM

        [Fact]
        public void CCTVSetTest_AccessToSistem_WrongPassword()
        {
            Assert.Throws<ArgumentException>(() => cctvSet.AccessToSistem(Password.NewPassword("Ale6767!")));
        }

        [Fact]
        public void CCTVSetTest_AccessToSistem_WrongPasswordModified()
        {
            Assert.Throws<ArgumentException>(() => cctvSet.AccessToSistem(Password.NewPassword("Ale6767/")));
        }

        [Fact]
        public void CCTVSetTest_AccessToSistem_RightPassWord()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));

            Assert.True(cctvSet.AccessPermission);
        }

        [Fact]
        public void CCTVSetTest_AccessToSistem_RightPassWordModified()
        {
            cctvPass.AccessToSistem(Password.NewPassword("Ale6767!"));

            Assert.True(cctvPass.AccessPermission);
        }

        #endregion

        #region ADD CCTV

        [Fact]
        public void CCTVSetTest_AddCCTV_AddsACCTV()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));

			cctvSet.AddCCTV(c);

            Assert.Single(cctvSet.SetOfCCTV);
        }

        [Fact]
        public void CCTVSetTest_AddCCTV_NoAccessToSistem()
        {
            Assert.Throws<InvalidOperationException>(() => cctvSet.AddCCTV(c));
        }

        [Fact]
        public void CCTVSetTest_AddCCTV_NullCCTV()
        {
            Assert.Throws<ArgumentNullException>(() => cctvSet.AddCCTV(null));
        }

        [Fact]
        public void CCTVSetTest_AddCCTVIn_AddsACCTVInPos0()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));

            cctvSet.AddCCTVIn(0, c);

            Assert.Single(cctvSet.SetOfCCTV);
            Assert.Equal(c.ID, cctvSet.SetOfCCTV[0].ID);
        }

        [Fact]
        public void CCTVSetTest_AddCCTVIn_AddsACCTVInPos0WithOtherCCTV()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(cam);

            cctvSet.AddCCTVIn(0, c);

            Assert.Equal(2, cctvSet.SetOfCCTV.Count);
            Assert.Equal(c.ID, cctvSet.SetOfCCTV[0].ID);
            Assert.Equal(cam.ID, cctvSet.SetOfCCTV[1].ID);
        }

        [Fact]
        public void CCTVSetTest_AddCCTVIn_NoAccessToSistem()
        {
            Assert.Throws<InvalidOperationException>(() => cctvSet.AddCCTVIn(0, c));
        }

        [Fact]
        public void CCTVSetTest_AddCCTVIn_NullCCTV()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));

            Assert.Throws<ArgumentNullException>(() => cctvSet.AddCCTVIn(0, null));
        }

        [Fact]

        public void CCTVSetTest_AddCCTVIn_AddsACCTVInPosOutOfRange()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));

            Assert.Throws<ArgumentOutOfRangeException>(() => cctvSet.AddCCTVIn(-1, c));
        }

        [Fact]  
        public void CCTVSetTest_AddCCTVIn_AddsACCTVInPosOutOfRange2()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));

            Assert.Throws<ArgumentOutOfRangeException>(() => cctvSet.AddCCTVIn(1, c));
        }

        #endregion



        [Fact]
        public void CCTVSetTest_RemoveCCTVAt_NoAcces()
        {
            Assert.Throws<InvalidOperationException>(() => cctvSet.RemoveCCTVAt(0));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVAt_RangeExeption()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));

            Assert.Throws<ArgumentOutOfRangeException>(() => cctvSet.RemoveCCTVAt(-1));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVAt_RangeExeption2()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(c);

            Assert.Throws<ArgumentOutOfRangeException>(() => cctvSet.RemoveCCTVAt(1));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVAt_RemovesCCTV()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(c);

            cctvSet.RemoveCCTVAt(0);

            Assert.Empty(cctvSet.SetOfCCTV);
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVAt_RemovesCCTVInPos1()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(c);
            cctvSet.AddCCTV(cam);

            cctvSet.RemoveCCTVAt(1);

            Assert.Single(cctvSet.SetOfCCTV);
            Assert.Equal(c.ID, cctvSet.SetOfCCTV[0].ID);
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVBy_NameNoAccess() 
        {
            Assert.Throws<InvalidOperationException>(() => cctvSet.RemoveCCTVBy(DeviceName.NewDeviceName("Braso")));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVBy_NameDoesNotExist()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(cam);

            Assert.Throws<InvalidOperationException>(() => cctvSet.RemoveCCTVBy(DeviceName.NewDeviceName("Braso")));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVBy_NameIsSuccesfullyRemoved()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(c);
            cctvSet.AddCCTV(cam);

            cctvSet.RemoveCCTVBy(DeviceName.NewDeviceName("Braso"));

            Assert.Single(cctvSet.SetOfCCTV);
            Assert.Equal(c.ID, cctvSet.SetOfCCTV[0].ID);
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVBy_GuidNoAccess()
        {
            Assert.Throws<InvalidOperationException>(() => cctvSet.RemoveCCTVBy(DeviceName.NewDeviceName("Braso")));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVBy_GuidDoesNotExist()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(cam);

            Assert.Throws<InvalidOperationException>(() => cctvSet.RemoveCCTVBy(Guid.NewGuid()));
        }

        [Fact]
        public void CCTVSetTest_RemoveCCTVBy_GuidIsSuccesfullyRemoved()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(c);
            cctvSet.AddCCTV(cam);

            cctvSet.RemoveCCTVBy(cam.ID);

            Assert.Single(cctvSet.SetOfCCTV);
            Assert.Equal(c.ID, cctvSet.SetOfCCTV[0].ID);
        }


        [Fact]
        public void CCTVSetTest_SwitchOnBy_GuidItSwitchOnIt()
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(cam);
            cctvSet.SwitchOnBy(cam.ID);         
            Assert.Equal(DeviceStatus.On, cctvSet.SetOfCCTV[0].DeviceStatus); 
        }


        [Fact]
        public void CCTVSetTest_SwitchOnBy_NameItSwitchOn() 
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(cam);
            cctvSet.SwitchOnBy(cam.Name);
            Assert.Equal(DeviceStatus.On, cctvSet.SetOfCCTV[0].DeviceStatus);
        }

        [Fact]
        public void CCTVSetTest_SwitchOffBy_GuidItSwitchOnIt() 
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(cam);
            cctvSet.SwitchOnBy(cam.ID);
            cctvSet.SwitchOffBy(cam.ID);
            Assert.Equal(DeviceStatus.Off, cctvSet.SetOfCCTV[0].DeviceStatus);
        }

        [Fact]
        public void CCTVSetTest_SwitchOffBy_NameItSwitchOn() 
        {
            cctvSet.AccessToSistem(Password.NewPassword("Ale6767?"));
            cctvSet.AddCCTV(cam);
            cctvSet.SwitchOnBy(cam.Name);
            cctvSet.SwitchOffBy(cam.Name);
            Assert.Equal(DeviceStatus.Off, cctvSet.SetOfCCTV[0].DeviceStatus);
        }

        


    }
} 