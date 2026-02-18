using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.CCTVDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Domain.Application.Devices.CCTVDevices.Query
{
    public class GetAllCCTVsByIdQuery
    {
		private readonly ICCTVRepository Repository;
		public GetAllCCTVsByIdQuery(ICCTVRepository repository)
		{
			Repository = repository;
		}
		public List<CCTV> Execute()
		{
			List<CCTV> cams = Repository.GetAllCCTV();
			return cams;
		}
	}
}
