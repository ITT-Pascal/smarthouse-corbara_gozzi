using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.DoorClasses;
using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.Thermic
{
    public class Temperature
    {
        private int minHeat = -10;
        private int maxHeat = 30;
        public int Value { get; }

        public Temperature(int val)
        {
            if (val < minHeat || val > maxHeat)
                throw new ArgumentException("Inserire heat tra -10 e 30");
            Value = val;
        }
        public static Temperature NewTemperature(int val)
        {
            return new Temperature(val);
        }
    }
}
