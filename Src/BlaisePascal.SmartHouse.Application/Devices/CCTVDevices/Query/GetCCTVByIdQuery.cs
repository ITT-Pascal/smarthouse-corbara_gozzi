using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;
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
		public CCTV Execute(Guid id)
		{
			var cam = Repository.GetCCTVById(id);
			return cam;
		}
	}
}
