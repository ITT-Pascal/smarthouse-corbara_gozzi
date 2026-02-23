using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Devices.CCTVTests
{
    public class CCTVSetTest
    {
        CCTVSet cctvSet = new CCTVSet();

        [Fact]
        public void CCTVSetTest_Constructor_Empty()
        {
            Assert.NotNull(cctvSet);
            Assert.NotNull(cctvSet.SetOfCCTV);
            Assert.Equal(0, cctvSet.SetOfCCTV.Count);
        }
    }
}