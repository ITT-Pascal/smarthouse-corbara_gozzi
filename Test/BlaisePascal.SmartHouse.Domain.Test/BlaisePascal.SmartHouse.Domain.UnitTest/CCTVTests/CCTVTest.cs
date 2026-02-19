using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.CCTVTests
{
    public class CCTVTest
    {
        private readonly Guid id;
        private readonly CCTV cctv;

        
        public CCTVTest()
        {
            id = Guid.NewGuid(); 
            cctv = new CCTV(id, DeviceName.NewDeviceName("MR.Braso"));
        }

        [Fact]
        public void CCTVest_Created_CCTVIsEmpty()
        {
            Assert.NotNull(cctv);
            Assert.Equal(id, cctv.ID);
            Assert.Equal("MR.Braso");
        }
    }
}
