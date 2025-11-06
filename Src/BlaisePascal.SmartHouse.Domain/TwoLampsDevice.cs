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
            }

            

        }

        public void TurnOnSecondLamp()
        {
            if (!SecondLamp.IsOn)
            {
                SecondLamp.IsOn = true;
            }
        }

        public void TurnOnAllLamps()
        {
            if (!(FirstLamp.IsOn && SecondLamp.IsOn)) 
            { 
                FirstLamp.IsOn = true;
                SecondLamp.IsOn = true;
            }
        }
        public void TurnOffFirstLamp()
        {
            if (FirstLamp.IsOn)
            {
                FirstLamp.IsOn = false;
            }
        }
        public void TurnOffSecondLamp()
        {
            if (SecondLamp.IsOn)
            {
                SecondLamp.IsOn = false;
            }
        }

        public void TurnOffAllLamps()
        {
            if (FirstLamp.IsOn && SecondLamp.IsOn)
            {
                FirstLamp.IsOn = false;
                SecondLamp.IsOn = false;
            }
        }
        public void changeBrightnessOfLamps(int brightness) 
        {
            if (FirstLamp.IsOn && SecondLamp.IsOn)
            { 
                FirstLamp.Brightness = Math.Max(FirstLamp.Brightness + brightness, 1);
                FirstLamp.Brightness = Math.Min(FirstLamp.Brightness, 100);
                SecondLamp.Brightness = Math.Max(SecondLamp.Brightness + brightness, 1);
                SecondLamp.Brightness = Math.Min(SecondLamp.Brightness, 100);
            }

        }
    }
}
