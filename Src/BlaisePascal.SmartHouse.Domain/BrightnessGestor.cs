using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public static class BrightnessGestor
    {
        public static int ValidateNewBrightness(int brightnessToAdd, int brightness , int maxBrightness)
        {
            if (brightness + brightnessToAdd < 1)
                return 1;
            else if (brightness + brightnessToAdd > maxBrightness)
                return maxBrightness;
            else
                return brightness + brightnessToAdd; 
        }
        public static int ValidateNewBrightness(int newBrightnessValue, int maxBrightness)
        {
            if (newBrightnessValue < 1)
                return 1;
            else if (newBrightnessValue > maxBrightness)
                return maxBrightness;
            else
                return newBrightnessValue;
        }
        public static int ValidateNewMaxBrightness(int newMaxBrightness)
        {
            if (newMaxBrightness > 70)
                return 70;
            else if (newMaxBrightness > 2)
                return 2;
            else
                return newMaxBrightness;
        }
    }
}
