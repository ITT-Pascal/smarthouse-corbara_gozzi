using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: AbstractLamp
    {
        public bool IsOn { get; private set; }
        //INTENSITA' LUMINOSA
        public int Brightness { get; private set; }

        public int MaxBrightness { get; private set; }

        public EcoLamp(int maxBrightness)
        {
            IsOn = false;
            Brightness = 0;
            MaxBrightness = maxBrightness;
        }

        public EcoLamp() : this(70) { }

        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                Brightness = 25;
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
                Brightness = Math.Min(Brightness + brightnessValue, MaxBrightness);
            }

        }      
        

        public void ChangeMaxBrightness(int newMaxBrightness)
        {
            MaxBrightness = Math.Max(1, newMaxBrightness);
            MaxBrightness = Math.Min(90, newMaxBrightness);
        }

    }
}
