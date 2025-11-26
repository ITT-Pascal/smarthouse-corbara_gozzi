using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public static class BrightnessGestor
    {
        private const int minBrightness = 1;
        public static int ValidatIntensityBetweenRange(int valChanger, int maxBrightness)
        {
            if (valChanger < minBrightness)
                throw new ArgumentException("Negative number can't be avariable");
            else if(valChanger > maxBrightness)
                throw new ArgumentException("Can't be a number greater than max brightness of lamp");
            return valChanger;
        }
    }
}
