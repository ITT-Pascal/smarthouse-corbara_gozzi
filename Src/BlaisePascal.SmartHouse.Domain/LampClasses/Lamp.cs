using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public class Lamp:AbstractLamp
    {
        private const int maxIntensity = 100;
        private const int minIntensity = 1;
        private const int intensityAtOn = 50;
        
        //------CONSTRUCTORS------
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
        public Lamp(string name, Guid Id) : base(name, Id) 
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public Lamp(string name, Guid Id, int valOfIncreaseAndDecrease) : base(name, Id, valOfIncreaseAndDecrease)
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
            ValueOfIncreaseAndDescrease = BrightnessGestor.ValidatIntensityBetweenRange(valOfIncreaseAndDecrease, MaxIntensity);
        }
    }
}
