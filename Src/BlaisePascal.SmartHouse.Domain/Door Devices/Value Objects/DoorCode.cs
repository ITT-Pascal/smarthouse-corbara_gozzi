using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTVClasses;

namespace BlaisePascal.SmartHouse.Domain.DoorClasses
{
    public class DoorCode
    {
        public int Value {get; }
        //CODICE A 6 CIFRE
        public DoorCode(int val)
        {
            if (val < 0 || val.ToString().Length != 6)
                throw new ArgumentException("Inserire codice positivo a 6 cifre");
            Value = val;
        }
        public static DoorCode NewDoorCode(int val)
        {
            return new DoorCode(val);
        }
    }
}
