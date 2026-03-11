using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command
{
    public class IncreaseIntensityLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public IncreaseIntensityLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id)
        {
            var lamp = _lampRepository.GetLampById(id);
            if (lamp != null)
            {
                lamp.IncreaseBy();
                _lampRepository.UpdateLamp(lamp);
            }
        }
    }
}
