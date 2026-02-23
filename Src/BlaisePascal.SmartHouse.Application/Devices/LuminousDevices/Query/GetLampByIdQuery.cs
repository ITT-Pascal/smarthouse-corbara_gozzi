using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Query
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
