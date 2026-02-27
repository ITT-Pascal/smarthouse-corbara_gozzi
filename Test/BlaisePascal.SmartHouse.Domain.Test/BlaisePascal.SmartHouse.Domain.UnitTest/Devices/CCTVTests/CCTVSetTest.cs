using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.CCTVTests
{
    public class CCTVSetTest
    {
        CCTVSet cctvPass = new CCTVSet(Password.NewPassword("676767"));
        CCTVSet cctvSet = new CCTVSet();

        [Fact]
        public void CCTVSetTest_Constructor_Empty()
        {
            Assert.NotNull(cctvSet);
            Assert.NotNull(cctvSet.SetOfCCTV);
            Assert.Equal(0, cctvSet.SetOfCCTV.Count);
            Assert.Equal(Password.NewPassword("1234567890"), cctvSet.AdminPassword);
        }

        [Fact]
        public void CCTVSetTest_Constructor_WithPassword()
        {
            Assert.Equal(Password.NewPassword("676767"), cctvPass.AdminPassword);
            Assert.NotNull(cctvPass);
            Assert.NotNull(cctvPass.SetOfCCTV);
            Assert.Equal(0, cctvPass.SetOfCCTV.Count);
        }

        [Fact]
        public void CCTVSetTest_AccessToSistem_WrongPassword()
        {
            Assert.Throws<ArgumentException>(() => cctvSet.AccessToSistem(Password.NewPassword("1234")));
        }

        [Fact]
        public void CCTVSetTest_AccessToSistem_RightPassWord()
        {
            cctvSet.AccessToSistem(Password.NewPassword("123456789"));
            Assert.Equal(true, cctvSet.AccessPermission);
        }

        [Fact]
        public void CCTVSetTest_AddCCTV_IsNull()
        {
            Assert.Throws<ArgumentNullException>(() => cctvSet.AddCCTV(null));
        }

        [Fact]
        public void CCTVSetTest_AddCCTV_AddsACCTV()
        { 
            CCTV c = new CCTV();
            cctvSet.AccessToSistem(Password.NewPassword("1234567890"));
            cctvSet.AddCCTV(c);
            Assert.Equal(1, cctvSet.SetOfCCTV.Count);
        }

        [Fact]
        public void CCTVSetTest_AddCCTV_NoAccessToSistem()
        {
            CCTV c = new CCTV();
            Assert.Throws<InvalidOperationException>(() => cctvSet.AddCCTV(c));
        }

        [Fact]
        public void CCTVSetTest_AddCCTVIn_IsNull()
        {
            Assert.Throws<ArgumentNullException>(() => cctvSet.AddCCTVIn(0, null));
        }

        [Fact]
        public void CCTVSetTest_AddCCTVIn_NoAccessToSistem()
        {
            CCTV c = new CCTV();
            Assert.Throws<ArgumentException>(() => cctvSet.AddCCTVIn(0, c));
        }

        [Fact]
        public void CCTVSetTest_AddCCTVIn_OutOfRange()
        {
            CCTV c = new CCTV();
            Assert.Throws<ArgumentOutOfRangeException>(() => cctvSet.AddCCTVIn(-1, c));
        }

        [Fact]
        public void CCTVSet_A



    }
} //InvalidOperationException