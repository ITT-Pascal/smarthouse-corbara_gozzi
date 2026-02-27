using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Infrastructure.Repositories.Devices.LuminousDevices.InMemory
{
    public class InMemoryLampRepository
    {
        private readonly List<Lamp> _lampRepo = [];

        public InMemoryLampRepository()
        {
            _lampRepo = new { };
        }
    }
}