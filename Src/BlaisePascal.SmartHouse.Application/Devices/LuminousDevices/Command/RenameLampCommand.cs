using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command
{
    public class RenameLampCommand
    {
        private readonly ILampRepository LampRepository;

        public RenameLampCommand(ILampRepository lampRepository)
        {
            LampRepository = lampRepository;
		}

        public void Execute(Guid id, string newName)
        {
            var lamp = LampRepository.GetLampById(id);
            lamp.RenameTo(DeviceName.NewDeviceName(newName));
            LampRepository.UpdateLamp(lamp);
		}
	}
}
