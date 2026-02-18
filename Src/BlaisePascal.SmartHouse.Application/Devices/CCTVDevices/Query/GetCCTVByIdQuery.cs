using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.CCTVDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Query
{
    public class GetCCTVByIdQuery
    {
		private readonly ICCTVRepository Repository;
		public GetCCTVByIdQuery(ICCTVRepository repository)
		{
			Repository = repository;
		}
		public CCTV Execute(Guid id)
		{
			var cam = Repository.GetCCTVById(id);
			return cam;
		}
	}
}
