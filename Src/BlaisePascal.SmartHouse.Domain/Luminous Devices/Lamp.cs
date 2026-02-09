using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class Lamp:AbstractLamp
    {

        //------CONSTRUCTORS------
        public Lamp() : base() 
        {

        }
        public Lamp(Guid Id) : base(Id)
        {
            
        }
        public Lamp(Guid Id, string name) : base(Id, name) 
        {
            
        }
    }
}
