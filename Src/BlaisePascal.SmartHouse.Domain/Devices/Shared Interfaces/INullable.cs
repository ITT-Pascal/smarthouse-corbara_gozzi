using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices
{
    public interface INullable
    {
        void CheckIsNotNull(object obj);
    }
}
