using BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Query
{
    public class GetCCTVByIdQuery
    {
		private readonly ICCTVRepository Repository;
		public GetCCTVByIdQuery(ICCTVRepository repository)
		{
			Repository = repository;
		}
		public CCTVDto Execute(Guid id)
		{
			var cam = Repository.GetCCTVById(id);
			return CCTVMapper.ToDto(cam);
		}
	}
}
