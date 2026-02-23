using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
{
    public class DeleteCCTVCommand
    {
		private readonly ICCTVRepository Repository;

		public DeleteCCTVCommand(ICCTVRepository repository)
		{
			Repository = repository;
		}

		public void Execute(Guid id)
		{
			Repository.DeleteCCTV(id);
		}
	}
}
