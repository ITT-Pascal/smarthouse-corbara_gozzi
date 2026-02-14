using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Domain.Application.Devices.LuminousDevices.Command
{
    public class SwitchOnLampCommand
    {
        private readonly ILampRepository Repository;

        public SwitchOnLampCommand(ILampRepository repository)
        {
            Repository = repository;
		}

        public void Execute(Guid id)
        {
            var lamp = Repository.GetLampById(id);
            if(lamp != null)
            {
                lamp.SwitchOn();
                Repository.UpdateLamp(lamp);
			}
		}
	}
}
