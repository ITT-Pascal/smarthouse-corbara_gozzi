using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampsDevice
    {
        public AbstractLamp FirstLamp { get; set; }
        public AbstractLamp SecondLamp { get; set; }

        public TwoLampsDevice()
        {
            FirstLamp = new Lamp();
            SecondLamp = new Lamp();
        }
        public TwoLampsDevice(AbstractLamp firstLamp, AbstractLamp secondLamp)
        {
            FirstLamp = firstLamp;
            SecondLamp = secondLamp;
        }

        public  void TurnOnFirstLamp()
        {
            FirstLamp.TurnOn();
        }
        public void TurnOnSecondLamp()
        {
            SecondLamp.TurnOn();
        }
        public void TurnOnAllLamps()
        {
            FirstLamp.TurnOn();
            SecondLamp.TurnOn();
        }
        public void TurnOffFirstLamp()
        {
            FirstLamp.TurnOff();
        }
        public void TurnOffSecondLamp()
        {
            FirstLamp.TurnOff();
        }
        public void TurnOffAllLamps()
        {
            FirstLamp.TurnOff();
            SecondLamp.TurnOff();
        }
        /// <summary>
        /// Cambia la brightness a tutte e due
        /// </summary>
        /// <param name="brightnessToAdd"></param>
        public void ChangeBrightnessOfLamps(int brightnessToAdd) 
        {
            if (FirstLamp.IsOn && SecondLamp.IsOn)
            {
                FirstLamp.ChangeBrightness(brightnessToAdd);
                SecondLamp.ChangeBrightness(brightnessToAdd);
            }
        }
    }
}
