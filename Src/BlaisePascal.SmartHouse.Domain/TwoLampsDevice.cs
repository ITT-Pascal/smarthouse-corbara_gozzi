using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampsDevice
    {
        public Lamp FirstLamp { get; set; }
        public Lamp SecondLamp { get; set; }
        private const int minValueOfMaxBrightness = 1;
        private const int maxValueOfMaxBrightness = 100;
        private const int brightnessValueAtTurnOn = 50;
        public TwoLampsDevice(Lamp firstLamp, Lamp secondLamp)
        {
            FirstLamp = new Lamp();
            
            SecondLamp = new Lamp();
        }

        public  void TurnOnFirstLamp()
        {
            if (!FirstLamp.IsOn)
            {
                FirstLamp.IsOn = true;
                FirstLamp.Brightness = brightnessValueAtTurnOn;
            }
        }

        public void TurnOnSecondLamp()
        {
            if (!SecondLamp.IsOn)
            {
                SecondLamp.IsOn = true;
                SecondLamp.Brightness = brightnessValueAtTurnOn;
            }
        }


        public void TurnOnAllLamps()
        {
            if (!(FirstLamp.IsOn && SecondLamp.IsOn)) 
            { 
                FirstLamp.IsOn = true;
                SecondLamp.IsOn = true;
                FirstLamp.Brightness = brightnessValueAtTurnOn;
                SecondLamp.Brightness = brightnessValueAtTurnOn;
            }
        }
        public void TurnOffFirstLamp()
        {
            if (FirstLamp.IsOn)
                FirstLamp.IsOn = false;  
        }
        public void TurnOffSecondLamp()
        {
            if (SecondLamp.IsOn)
                SecondLamp.IsOn = false;
        }

        public void TurnOffAllLamps()
        {
            if (FirstLamp.IsOn && SecondLamp.IsOn)
            {
                FirstLamp.IsOn = false;
                SecondLamp.IsOn = false;
            }
        }
        public void ChangeBrightnessOfLamps(int brightness) 
        {
            if (FirstLamp.IsOn && SecondLamp.IsOn)
            { 
                FirstLamp.Brightness = Math.Max(FirstLamp.Brightness + brightness, minValueOfMaxBrightness);
                FirstLamp.Brightness = Math.Min(FirstLamp.Brightness, maxValueOfMaxBrightness);
                SecondLamp.Brightness = Math.Max(SecondLamp.Brightness + brightness, minValueOfMaxBrightness);
                SecondLamp.Brightness = Math.Min(SecondLamp.Brightness, maxValueOfMaxBrightness);
            }
        }
    }
}
