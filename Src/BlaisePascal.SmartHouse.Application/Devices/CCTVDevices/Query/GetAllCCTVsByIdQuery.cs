using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Query
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
