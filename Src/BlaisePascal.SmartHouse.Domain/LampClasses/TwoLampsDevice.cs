using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public sealed class TwoLampsDevice
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public AbstractLamp FirstLamp { get; private set; }
        public AbstractLamp SecondLamp { get; private set; }
        
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
        public void SwitchOffFirstLamp() { 
            FirstLamp.SwitchOff(); 
        }
        public void SwitchOffSecondLamp(){ 
            SecondLamp.SwitchOff(); 
        }
        public void SwitchOffAllLamps()
        {
            FirstLamp.SwitchOff();
            SecondLamp.SwitchOff();
        }
        //Set new intensity by a new value
        public void ChangeBrightnessOfLamps(int value)
        {
            if (FirstLamp.DeviceStatus == DeviceStatus.On && SecondLamp.DeviceStatus == DeviceStatus.On)
            {
                FirstLamp.SetIntensity(value);
                SecondLamp.SetIntensity(value);
            }
        }
    }
}
