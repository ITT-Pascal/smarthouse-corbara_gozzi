using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command
{
    public class AddLampCommand
    {
		private readonly ILampRepository Repository;

		public AddLampCommand(ILampRepository repository)
		{
			Repository = repository;
		}

		public void Execute(AbstractLamp lamp)
		{
			Repository.AddLamp(lamp);
		}
	}
}
