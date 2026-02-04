using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.DoorClasses
{
    public class DoorCode
    {
        public int Value {get; }

        public DoorCode(int val)
        {
            if (val < 0 || val.ToString().Length != 6)
                throw new ArgumentException("Inserire codice positivo a 6 cifre");
            Value = val;
        }
    }
}
