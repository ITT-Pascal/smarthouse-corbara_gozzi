using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: AbstractLamp
    {
        public int MaxBrightness { get; set; }
        private const int minValueOfMaxBrightness = 2;
        private const int maxValueOfMaxBrightness = 90;
        public EcoLamp(int maxBrightness)
        {
            IsOn = false;
            Brightness = 0;
            Guid = new Guid();
            if (maxBrightness <= 1)
            {
                MaxBrightness = minValueOfMaxBrightness;
            }
            else if (maxBrightness >= maxValueOfMaxBrightness)
            {
                MaxBrightness = maxValueOfMaxBrightness;
            }
            else
            {
                MaxBrightness = maxBrightness;
            }
        }

        public EcoLamp() : this(70) { }
        public EcoLamp(int maxBrightness, Guid guid)
        {
            IsOn = false;
            Brightness = 0;
            MaxBrightness = maxBrightness;
            Guid = guid;
        }


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
            MaxBrightness = Math.Max(minValueOfMaxBrightness, newMaxBrightness);
            MaxBrightness = Math.Min(maxValueOfMaxBrightness, newMaxBrightness);
            Brightness = newMaxBrightness / 2;
        }
    }
}
