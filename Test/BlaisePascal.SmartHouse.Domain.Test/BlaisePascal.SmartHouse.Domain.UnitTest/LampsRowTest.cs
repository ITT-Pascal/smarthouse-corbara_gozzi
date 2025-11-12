using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampsRowTest
    {
        LampsRow lampsRow = new LampsRow();
        List<AbstractLamp> lampList = new List<AbstractLamp>();
        AbstractLamp lamp = new Lamp();
        EcoLamp ecoLamp = new EcoLamp();

        [Fact]

        public void LampsRow_AddLamp_WhenIAddListNotempty()
        {
            lampsRow.AddLamp(lamp);
            Assert.Equal();
        }

    }
}
