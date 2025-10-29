using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public bool IsOn { get; set; }
        
        public void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
            }
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
            }
        }
    }
}
