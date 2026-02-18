using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.CCTVDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
{
    public class SwitchOnCCTVCommand
    {
		private readonly ICCTVRepository Repository;

		public SwitchOnCCTVCommand(ICCTVRepository repository)
		{
			Repository = repository;
		}

		public void Execute(Guid id)
		{
			var cam = Repository.GetCCTVById(id);
			if (cam != null)
			{
				cam.SwitchOn();
				Repository.UpdateCCTV(cam);
			}
		}
	}
}
