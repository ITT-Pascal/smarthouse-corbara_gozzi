using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class Lamp:AbstractLamp
    {
        private const int maxIntensity = 100;
        private const int intensityAtOn = 50;
        
        //------CONSTRUCTORS------
        public Lamp() : base() 
        {
            MaxIntensity = maxIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public Lamp(string name) : base(name)
        {
            MaxIntensity = maxIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public Lamp(Guid Id) : base(Id)
        {
            MaxIntensity = maxIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public Lamp(Guid Id, string name) : base(Id, name) 
        {
            MaxIntensity = maxIntensity;
            IntensityAtOn = intensityAtOn;
        }
    }
}
