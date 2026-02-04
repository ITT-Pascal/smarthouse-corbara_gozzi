using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class Degrees
    {
        public int Value { get; }

        public Degrees(int val)
        {
            if (val > 360 || val < 0)
                throw new ArgumentException("Inserire gradi validi(0-360)");
            Value = val;
        }
    }
}
