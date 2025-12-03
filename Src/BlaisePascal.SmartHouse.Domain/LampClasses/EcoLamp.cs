using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public class EcoLamp : AbstractLamp
    {
        private const int maxIntensity = 70;
        private const int minIntensity = 1;
        private const int intensityAtOn = 30;

        //------CONSTRUCTORS------
        public EcoLamp() : base()
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public EcoLamp(string name) : base(name)
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public EcoLamp(string name, Guid Id) : base(name, Id)
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
        public EcoLamp(string name, Guid Id, int valOfIncreaseAndDecrease) : base(name, Id, valOfIncreaseAndDecrease)
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
            ValueOfIncreaseAndDescrease = ReturnValidation(valOfIncreaseAndDecrease);
        }
    }
}