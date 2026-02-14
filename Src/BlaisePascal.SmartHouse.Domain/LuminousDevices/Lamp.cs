using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices
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
