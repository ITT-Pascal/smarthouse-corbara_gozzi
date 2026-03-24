using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Query;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command
{
    public class ToggleLampCommand
    {
        private readonly ILampRepository LampRepository;

        public ToggleLampCommand(ILampRepository lampRepository)
        {
            LampRepository = lampRepository;
		}

        public void Execute(Guid id) 
        {
            var lamp = LampRepository.GetLampById(id);
            if (lamp.DeviceStatus == DeviceStatus.On)
                lamp.SwitchOff();
            else
                lamp.SwitchOn();
            LampRepository.UpdateLamp(lamp);
		}
	}
}
