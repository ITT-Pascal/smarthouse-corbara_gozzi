using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
{
    public class SwitchOffCCTVCommand
    {
		private readonly ICCTVRepository Repository;

		public SwitchOffCCTVCommand(ICCTVRepository repository)
		{
			Repository = repository;
		}

		public void Execute(Guid id)
		{
			var cam = Repository.GetCCTVById(id);
			if (cam != null)
			{
				cam.SwitchOff();
				Repository.UpdateCCTV(cam);
			}
		}
	}
}
