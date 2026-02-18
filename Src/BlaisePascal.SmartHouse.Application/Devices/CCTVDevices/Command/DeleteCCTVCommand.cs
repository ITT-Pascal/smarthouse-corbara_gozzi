using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.CCTVDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
{
    public class DeleteCCTVCommand
    {
		private readonly ICCTVRepository Repository;

		public DeleteCCTVCommand(ICCTVRepository repository)
		{
			Repository = repository;
		}

		public void Execute(Guid id)
		{
			Repository.DeleteCCTV(id);
		}
	}
}
