using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LAMP
{
    public class Lamp:AbstractLamp
    {
        private const int maxIntensity = 100;
        private const int minIntensity = 1;

        //------CONSTRUCTORS------
        private const int intensityAtOn = 50;
        public Lamp() : base() 
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public Lamp(string name) : base(name)
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public Lamp(Guid Id, string name) : base(name, Id) 
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
    }
}
