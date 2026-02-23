using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.CCTVDevices.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.CCTVTests
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