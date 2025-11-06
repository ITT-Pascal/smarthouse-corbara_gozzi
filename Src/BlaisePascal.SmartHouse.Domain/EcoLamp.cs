using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: AbstractLamp
    {
        public bool IsOn { get; set; }
        //INTENSITA' LUMINOSA
        public int Brightness { get; set; }

        public int MaxBrightness { get; set; }

        public EcoLamp(int maxBrightness)
        {
            IsOn = false;
            Brightness = 0;
            if (maxBrightness <= 1)
            {
                MaxBrightness = 2;
            }
            else if (maxBrightness >= 90)
            {
                MaxBrightness = 90;
            }
            else
            {
                MaxBrightness = maxBrightness;


            }
        }

        public EcoLamp() : this(70) { }

        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                Brightness = MaxBrightness/2;
            }
        }

        public override void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                Brightness = 0;
            }
        }

        public override void ChangeBrightness(int brightnessValue)
        {
            if (IsOn)
            {
                Brightness = Math.Max(Brightness + brightnessValue, 1);
                Brightness = Math.Min(Brightness, MaxBrightness);
            } 

        }      
        

        public void ChangeMaxBrightness(int newMaxBrightness)
        {
            MaxBrightness = Math.Max(2, newMaxBrightness);
            MaxBrightness = Math.Min(90, newMaxBrightness);

            Brightness = newMaxBrightness / 2;
        }

    }
}
