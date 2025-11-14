using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public static class BrightnessValidator
    {
        public static int ValidateBrightness(int brightness, Lamp lamp)
        {
            if (!(brightness > lamp.MinValueOfBrightness && brightness < lamp.MaxValueOfBrightness))
                throw new ArgumentException("brightness must be between min brightness and max brightness");
            
            return brightness;
        }
    }
}
