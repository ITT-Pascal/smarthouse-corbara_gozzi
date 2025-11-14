using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: Lamp
    {
        public int MaxBrightness { get; set; }
        public EcoLamp(int maxBrightness, string name, int minValueOfBrightness, int maxValueOfBrightness, int brightnessValueAtTurnOn) : base(name)
        {
            if (maxBrightness <= 1)
            {
                MaxBrightness = maxBrightness;
            }
            else if (maxBrightness >= MaxValueOfBrightness)
            {
                MaxBrightness = MaxValueOfBrightness;
            }
            else
            {
                MaxBrightness = maxBrightness;
            }
            MinValueOfBrightness = minValueOfBrightness;
            MaxValueOfBrightness = maxValueOfBrightness;
            BrightnessValueAtTurnOn = maxValueOfBrightness / 2;
        }

        public EcoLamp(int maxBrightness, Guid guid, string name, int minValueOfBrightness, int maxValueOfBrightness, int brightnessValueAtTurnOn) : base(name)
        {
            IsOn = false;
            Brightness = 0;
            MaxBrightness = maxBrightness;
            Guid = guid;
            Name = name;
        }

        public override void TurnOn()
        {
            IsOn = true;
            Brightness = MaxBrightness/2;
        }

        public override void TurnOff()
        {
            
            IsOn = false;
            Brightness = 0;
        }

        public override void ChangeBrightness(Lamp lamp, int brightnessValue)
        {
            if (IsOn)
            {
                Brightness = BrightnessValidator.ValidateBrightness(brightnessValue, lamp);
            } 
        }

        public void ChangeMaxBrightness(int newMaxBrightness)
        {
            MaxBrightness = Math.Max(MinValueOfBrightness, newMaxBrightness);
            MaxBrightness = Math.Min(MaxValueOfBrightness, newMaxBrightness);
            Brightness = newMaxBrightness / 2;
        }
    }
}
