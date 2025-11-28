using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public static class DeviceGestor
    {
        private const int minValueOfDevices = 1;
        public static int ValidatIntensityBetweenRange(int valChanger, int maxBrightness)
        {
            if (valChanger < minValueOfDevices)
                throw new ArgumentException("Negative number can't be avariable");
            else if(valChanger > maxBrightness)
                throw new ArgumentException("Can't be a number greater than max brightness of lamp");
            return valChanger;
        }
        public static int ValidateHeatInCustomMode(int heat, int minHeat, int maxHeat)
        {
            if (heat < minHeat)
                return minHeat;
            else if (heat > maxHeat)
                return maxHeat;
            else
                return heat;
        }
        public static int ValidatePowerAc(int amount, int maxPower)
        {
            if (amount > maxPower)
                return maxPower;
            else if (amount < minValueOfDevices)
                return minValueOfDevices;
            else
                return amount;
        }
    }
}
