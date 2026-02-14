using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.DoorDevices.ValueObjects
{
    public class DoorCode
    {
        private const int codeLenght = 6;
        public uint Code {get; }

        //CODICE A 6 CIFRE
        public DoorCode(uint code)
        {
            if (code.ToString().Length != codeLenght)
                throw new ArgumentException($"Code[{code}]: Code value must be positiove and a lenght of 6");
            Code = code;
        }
        public static DoorCode NewDoorCode(uint code)
        {
            return new DoorCode(code);
        }
    }
}
