using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Luminous_Devices;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class Lamp:AbstractLamp
    {

        //------CONSTRUCTORS------
        public Lamp() : base() 
        {

        }
        public Lamp(Guid id) : base(id)
        {
            
        }
        public Lamp(Guid id, DeviceName name) : base(id, name) 
        {
            
        }
    }
}
