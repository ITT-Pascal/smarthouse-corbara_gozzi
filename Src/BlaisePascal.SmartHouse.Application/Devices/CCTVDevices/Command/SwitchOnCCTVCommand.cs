using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
{
    public class SwitchOnCCTVCommand
    {
		private readonly ICCTVRepository Repository;

		public SwitchOnCCTVCommand(ICCTVRepository repository)
		{
			Repository = repository;
		}

		public void Execute(Guid id)
		{
			var cam = Repository.GetCCTVById(id);
			if (cam != null)
			{
				cam.SwitchOn();
				Repository.UpdateCCTV(cam);
			}
		}
	}
}
