using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Mappers;
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

		public LampDto Execute(Guid id)
		{
			var lamp = Repository.GetLampById(id);
			return LampMapper.ToDto(lamp);
		}
	}
}
