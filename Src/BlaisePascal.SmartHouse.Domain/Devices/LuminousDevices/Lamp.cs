using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices
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
