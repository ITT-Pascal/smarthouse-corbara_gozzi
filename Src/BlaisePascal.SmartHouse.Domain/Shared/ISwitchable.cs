using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Shared
{
    public interface ISwitchable
    {
        void SwitchOn();
        void SwitchOff();
    }
}
