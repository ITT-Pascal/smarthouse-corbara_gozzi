using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command
{
    public class DeleteLampCommand
    {
        private readonly ILampRepository Repository;

        public DeleteLampCommand(ILampRepository repository)
        {
            Repository = repository;
		}

        public void Execute(Guid id)
        {
            Repository.DeleteLamp(id);
        }
	}
}
