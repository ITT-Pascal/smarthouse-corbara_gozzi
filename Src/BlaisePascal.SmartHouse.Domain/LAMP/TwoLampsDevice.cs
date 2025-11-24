using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LAMP
{
    public class TwoLampsDevice
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public AbstractLamp FirstLamp { get; set; }
        public AbstractLamp SecondLamp { get; set; }
        
        //------CONSTRUCTORS------
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

        //------METHODS------
        public void TurnOnFirstLamp()
        {
            FirstLamp.SwitchOn();
        }
        public void TurnOnSecondLamp()
        {
            SecondLamp.SwitchOn();
        }
        public void TurnOnAllLamps()
        {
            FirstLamp.SwitchOn();
            SecondLamp.SwitchOn();
        }
        public void TurnOffFirstLamp()
        {
            FirstLamp.SwitchOff();
        }
        public void TurnOffSecondLamp()
        {
            FirstLamp.SwitchOff();
        }
        public void TurnOffAllLamps()
        {
            FirstLamp.SwitchOff();
            SecondLamp.SwitchOff();
        }
        public void ChangeBrightnessOfLamps(int value)
        {
            FirstLamp.SetIntensity(value);
            SecondLamp.SetIntensity(value);
        }
    }
}
