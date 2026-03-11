using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command
{
    public class DecreaseIntensityLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public DecreaseIntensityLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id)
        {
            var lamp = _lampRepository.GetLampById(id);
            if (lamp != null)
            {
                lamp.DecreaseBy();
                _lampRepository.UpdateLamp(lamp);
            }
        }
    }
}
