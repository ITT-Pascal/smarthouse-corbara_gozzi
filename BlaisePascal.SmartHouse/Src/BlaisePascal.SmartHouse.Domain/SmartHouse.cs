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

        public Lamp()
        {
            IsOn = false;
            Brightness = 0;
        }

        public void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                Brightness = 50;
            }
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                Brightness = 0;
            }
        }

        public void TurnUpBrightness(int brightValue)
        {
            if (IsOn)
            {
                Brightness = Math.Min(100, Brightness +  brightValue);
            }


        }

        public void TurnDownBrightness(int brightValue)
        {
            if (IsOn)
            {
                Brightness = Math.Max(1, Brightness - brightValue);

            }
        }
    }
}
