using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class AbstractLamp
    {
        public abstract void TurnOn();


        public abstract void TurnOff();


        public abstract void ChangeBrightness(int brightnessValue);
        
    }
}
