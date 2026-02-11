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
        private const int codeLenght = 6;
        public uint Value {get; }

        //CODICE A 6 CIFRE
        public DoorCode(uint val)
        {
            if (val.ToString().Length != codeLenght)
                throw new ArgumentException("Code: Code value must be positiove and a lenght of 6");
            Value = val;
        }
        public static DoorCode NewDoorCode(uint val)
        {
            return new DoorCode(val);
        }
    }
}
