using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public bool IsOn { get; set; }
        //INTENSITA' LUMINOSA
        public int Brightness { get; set; }

        public void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
            }
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
            }
        }

        public void TurnUpBrightness(int brightValue)
        {
            if (IsOn)
            {
                if (Brightness + brightValue > 100)
                {
                    Brightness = 100;
                }
                else
                {
                    Brightness += brightValue;
                }
            }


        }

        public void TurnDownBrightness(int brightValue)
        {
            if (IsOn)
            {
                if (Brightness - brightValue < 1)
                {
                    Brightness = 1;
                }
                else
                {
                    Brightness -= brightValue;
                }

            }
        }
    }
}
