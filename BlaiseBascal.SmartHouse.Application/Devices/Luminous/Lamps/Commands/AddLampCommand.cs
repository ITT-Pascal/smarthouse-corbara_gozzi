using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaiseBascal.SmartHouse.Application.Devices.Luminous.Lamps.Commands
{
    public class AddLampCommand
    {
        private ILampRepository _lampRepository;

        public AddLampCommand(ILampRepositoryy lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(string lampName)
        {
            DeviceName deviceName = deviceName.NewDeviceName(lampName);

            _lampRepository.AddLamp(new Lamp(lampName));
        }

    }
}