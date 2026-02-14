using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Domain.Application.Devices.LuminousDevices.Query
{
    public class GetLampByIdQuery
    {
		private readonly ILampRepository Repository;

		public GetLampByIdQuery(ILampRepository repository)
		{
			Repository = repository;
		}

		public AbstractLamp Execute(Guid id)
		{
			AbstractLamp lamp = Repository.GetLampById(id);
			return lamp;
		}
	}
}
