using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.DoorClasses;
namespace BlaisePascal.SmartHouse.Domain.UnitTest.DoorTest
{
    public class DoorTest
    {
        Door door = new Door(1234);

        [Fact]

        public void Door_Constructor_Code()
        {
            Assert.Equal(1234, door.Code);
        }

        [Fact]

        public void Door_Constructor_Cofde()
        {
            Assert.Equal(1234, door.Code);
        }
    }
}
