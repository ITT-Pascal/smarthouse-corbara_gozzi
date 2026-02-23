using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command
{
    public class SwitchOnLampCommand
    {
        private readonly ILampRepository Repository;

        public SwitchOnLampCommand(ILampRepository repository)
        {
            Repository = repository;
		}

        public void Execute(Guid id)
        {
            var lamp = Repository.GetLampById(id);
            if(lamp != null)
            {
                lamp.SwitchOn();
                Repository.UpdateLamp(lamp);
			}
		}
	}
}
