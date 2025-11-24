using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LAMP
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
        public EcoLamp(Guid Id, string name) : base(name, Id)
        {
            MaxIntensity = maxIntensity;
            MinIntensity = minIntensity;
            IntensityAtOn = intensityAtOn;
        }
    }
}