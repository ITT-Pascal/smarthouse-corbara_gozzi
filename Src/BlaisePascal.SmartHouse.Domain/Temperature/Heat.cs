using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Temperature
{
    public class Heat
    {
        private int minHeat = -10;
        private int maxHeat = 30;
        public int Value { get; }

        public Heat(int val)
        {
            if (val < minHeat || val > maxHeat)
                throw new ArgumentException("Inserire heat tra -10 e 30");
            Value = val;
        }
    }
}
