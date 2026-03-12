using BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Query
{
    public class GetAllCCTVsQuery
    {
		private readonly ICCTVRepository Repository;
		public GetAllCCTVsQuery(ICCTVRepository repository)
		{
			Repository = repository;
		}
		public List<CCTVDto> Execute()
		{
            List<CCTVDto> camDto = [];
            foreach (var cam in Repository.GetAllCCTV())
                camDto.Add(CCTVMapper.ToDto(cam));
            return camDto;
        }
	}
}
