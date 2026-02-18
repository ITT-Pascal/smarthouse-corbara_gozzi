using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Query
{
    public class GetAllLampsByIdQuery
    {
        private readonly ILampRepository Repository;
        public GetAllLampsByIdQuery(ILampRepository repository)
        {
            Repository = repository;
		}
        public List<AbstractLamp> Execute()
        {
            List<AbstractLamp> lamps = Repository.GetAllLamps();
            return lamps;
		}
	}
}
