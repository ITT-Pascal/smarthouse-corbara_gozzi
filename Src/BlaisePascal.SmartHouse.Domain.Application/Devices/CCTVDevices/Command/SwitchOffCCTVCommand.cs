using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Domain.Application.Devices.CCTVDevices.Command
{
    public class SwitchOffCCTVCommand
    {
		private readonly ICCTVRepository Repository;

		public SwitchOffCCTVCommand(ICCTVRepository repository)
		{
			Repository = repository;
		}

		public void Execute(Guid id)
		{
			var cam = Repository.GetCCTVById(id);
			if (cam != null)
			{
				cam.SwitchOff();
				Repository.UpdateCCTV(cam);
			}
		}
	}
}
