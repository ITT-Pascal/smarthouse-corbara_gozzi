using BlaisePascal.SmartHouse.Domain.Luminous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public sealed class TwoLampsDevice(AbstractLamp firstLamp, AbstractLamp secondLamp)
    {
        //   -------ATTRIBUTES AND PROPERTY-------
        public AbstractLamp FirstLamp { get; private set; } = firstLamp;
        public AbstractLamp SecondLamp { get; private set; } = secondLamp;

        //       ------METHODS------

        //--SWITCH METHODS--

        public void SwitchOnFirstLamp() 
        {
            FirstLamp.SwitchOn();
        }
        public void SwitchOnSecondLamp() 
        {
            SecondLamp.SwitchOn(); 
        }
        public void SwitchOnAllLamps()
        {
            FirstLamp.SwitchOn();
            SecondLamp.SwitchOn();
        }
        public void SwitchOffAllLamps()
        {
            FirstLamp.SwitchOff();
            SecondLamp.SwitchOff();
        }
        public void SwitchOffFirstLamp() 
        { 
            FirstLamp.SwitchOff(); 
        }
        public void SwitchOffSecondLamp()
        { 
            SecondLamp.SwitchOff(); 
        }

        //--CHANGER INTENSITY METHODS--

        public void SetIntensityOfLampsTo(Intensity intensity)
        {
            FirstLamp.IsDeviceOn();
            FirstLamp.IsDeviceOn();
            FirstLamp.SetIntensityTo(intensity);
            SecondLamp.SetIntensityTo(intensity);
        }
    }
}
